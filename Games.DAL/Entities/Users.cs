using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
{
    public partial class Users
    {
        public Users()
        {
            Games = new HashSet<Games>();
        }

        public string Username { get; set; }
        public string Group { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string Passwd { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
