using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Group
{
    public class GroupRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public Guid CreatedByUserId { get; set; }
    }
}