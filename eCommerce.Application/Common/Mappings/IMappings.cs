using AutoMapper;

namespace eCommerce.Application.Common.Mappings
{
    /// <summary>
    /// Map from given type to current
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IMapFrom<TEntity> where TEntity : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TEntity), GetType());
    }

    /// <summary>
    /// Map from current type to specified type
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public interface IMapTo<Type> where Type : class
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(Type));
    }

    /// <summary>
    /// Map mutually from type1 to type 2 and reverse
    /// </summary>
    /// <typeparam name="Type1"></typeparam>
    /// <typeparam name="Type2"></typeparam>
    public interface IMapMutually<Type1, Type2>
        where Type1 : class
        where Type2 : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(Type1), typeof(Type2)).ReverseMap();
    }
}