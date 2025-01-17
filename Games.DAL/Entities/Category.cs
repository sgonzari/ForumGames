﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games.DAL.Entities
{
    public partial class Category
    {
        public Category()
        {
            GamesCategory = new HashSet<GamesCategory>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GamesCategory> GamesCategory { get; set; }
    }
}
