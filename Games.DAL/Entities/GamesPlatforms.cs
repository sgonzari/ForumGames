using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
{
    public partial class GamesPlatforms
    {
        public int IdGamesPlatform { get; set; }
        public int FkIdGame { get; set; }
        public int FkIdPlatform { get; set; }

        public virtual Games FkIdGameNavigation { get; set; }
        public virtual Platforms FkIdPlatformNavigation { get; set; }
    }
}
