﻿using eCommerce.Application.Contracts.Persistence.Repositories.Base;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Contracts.Persistence.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}