using RequestApplicatioin.DB;
using RequestApplication.Entities;
using RequestApplication.Services.Dto;
using RequestApplication.Services.Mapper;

namespace RequestApplication.Services.Services
{
    public class RequestService : BaseService<Request, RequestDto>
    {
        public RequestService(IDbRepository<Request> repository, IApplicationMapper mapper) : base(repository, mapper) { }
    }
}
