using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreoracle_backend.DTOs.Pick
{
    public class PickRequestDto
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public Guid GameId { get; set; }
        public Guid PredictedWinnerId { get; set; }
    }
}