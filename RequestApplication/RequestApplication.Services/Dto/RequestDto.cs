using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RequestApplication.Services.Dto
{
    public class RequestDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public long ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
