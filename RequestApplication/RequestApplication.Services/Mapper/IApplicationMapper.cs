using AutoMapper;

namespace RequestApplication.Services.Mapper
{
    public interface IApplicationMapper
    {
        IConfigurationProvider ConfigurationProvider { get; }
        T Map<T>(object source);
        void Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
