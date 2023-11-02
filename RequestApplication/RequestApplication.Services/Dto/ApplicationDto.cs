using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestApplication.Services.Dto
{
    public class ApplicationDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
