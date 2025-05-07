using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.GroupMember
{
    public class GroupMemberRequestDto
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
        public Guid GroupId { get; set; }
    }
}