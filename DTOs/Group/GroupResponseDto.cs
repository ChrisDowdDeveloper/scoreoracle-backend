using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Group
{
    public class GroupResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }

        public Guid CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }

        public Guid LeagueId { get; set; }
        public string LeagueName { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}