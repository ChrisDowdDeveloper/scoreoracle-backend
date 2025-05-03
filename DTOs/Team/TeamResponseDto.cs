using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Team
{
    public class TeamResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }

        public Guid SportId { get; set; }
        public string SportName { get; set; }

        public Guid LeagueId { get; set; }
        public string LeagueName { get; set; }

        public string LogoUrl { get; set; }
        public string Abbreviation { get; set; }
    }
}