using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace scoreoracle_backend.Models
{
    public class Sport : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("logo_url")]
        public string LogoUrl { get; set; }
    }
}