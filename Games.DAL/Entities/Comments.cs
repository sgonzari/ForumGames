using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
{
    public partial class Comments
    {
        public int IdComment { get; set; }
        public int FkIdGame { get; set; }
        public string FkUsername { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }

        public virtual Games FkIdGameNavigation { get; set; }
        public virtual Users FkUsernameNavigation { get; set; }
    }
}
