using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Sport
{
    public class UpdateSportDto
    {
        public string? Name { get; set; }
        public string? LogoUrl { get; set; }
    }
}