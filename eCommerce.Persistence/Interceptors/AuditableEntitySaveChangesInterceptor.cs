﻿using eCommerce.Application.Contracts.Infrastructure;
using eCommerce.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace eCommerce.Persistence.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ICurrentUserService _currentUserService;

        public AuditableEntitySaveChangesInterceptor(IDateTimeService dateTimeService, ICurrentUserService currentUserService)
        {
            _dateTimeService = dateTimeService;
            _currentUserService = currentUserService;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context is null) return;
            var changedEntities = context.ChangeTracker.Entries<AuditableEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in changedEntities)
            {
                entry.Entity.LastModifiedDate = _dateTimeService.Now;
                entry.Entity.LastModifiedBy = _currentUserService.UserId ?? "UNKNOWN";

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = _dateTimeService.Now;
                    entry.Entity.CreatedBy = _currentUserService.UserId ?? "UNKNOWN";
                }
            }
        }
    }
}