using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberDto
    {
        public int ID { get; set; }

        public String Username { get; set; }

        public String PhotoUrl { get; set; }
        public int Age { get; set; }

        public string KnownAs { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime LastActive { get; set; } = DateTime.Now;

        public string Gender { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public ICollection<PhotoDTO> Photos { get; set; }

    }
}
