using RequestApplicatioin.DB;
using RequestApplication.Entities;
using RequestApplication.Services.Dto;
using RequestApplication.Services.Mapper;

namespace RequestApplication.Services.Services
{
    public class ApplicationService : BaseService<Application, ApplicationDto>
    {
        public ApplicationService(IDbRepository<Application> repository, IApplicationMapper mapper) : base(repository, mapper) { }
    }
}