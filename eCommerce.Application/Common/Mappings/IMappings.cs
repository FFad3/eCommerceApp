using AutoMapper;

namespace eCommerce.Application.Common.Mappings
{
    public interface IMapFrom<TEntity> where TEntity : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TEntity), GetType());
    }

    public interface IMapTo<Type> where Type : class
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(Type));
    }

    public interface IMapMutually<Type1, Type2>
        where Type1 : class
        where Type2 : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(Type1), typeof(Type2)).ReverseMap();
    }
}