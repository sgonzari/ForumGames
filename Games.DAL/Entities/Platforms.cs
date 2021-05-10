using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
{
    public partial class Platforms
    {
        public Platforms()
        {
            GamesPlatforms = new HashSet<GamesPlatforms>();
        }

        public int IdPlatform { get; set; }
        public string Platform { get; set; }

        public virtual ICollection<GamesPlatforms> GamesPlatforms { get; set; }
    }
}
