using AutoMapper;
using RequestApplication.Entities;
using RequestApplication.Services.Dto;

namespace RequestApplication.Services.Mapper
{
    public class ApplicationMapper : IApplicationMapper
    {
        public IConfigurationProvider ConfigurationProvider => Mapper.ConfigurationProvider;
        protected IMapper Mapper { get; set; }
        public ApplicationMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Request, RequestDto>();
                cfg.CreateMap<RequestDto, Request>();
                cfg.CreateMap<Application, ApplicationDto>();
                cfg.CreateMap<ApplicationDto, Application>();
            });

            Mapper = config.CreateMapper();
        }

        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }
    }
}
