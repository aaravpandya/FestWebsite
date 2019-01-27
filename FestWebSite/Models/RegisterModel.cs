using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestWebSite.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniversityName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int NumberOfParticipants { get; set; }
        public bool Accomodation { get; set; }
        public string Events { get; set; }
    }
}
