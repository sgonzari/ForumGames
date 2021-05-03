using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
{
    public partial class Games
    {
        public int IdGame { get; set; }
        public int FkIdCategory { get; set; }
        public string FkUsername { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Platform { get; set; }
        public int Height { get; set; }
        public string Requirements { get; set; }
        public bool Multiplayer { get; set; }

        public virtual Category FkIdCategoryNavigation { get; set; }
        public virtual Users FkUsernameNavigation { get; set; }
    }
}
