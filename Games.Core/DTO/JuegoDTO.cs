using System;
using System.Collections.Generic;

namespace Games.CORE.DTO
{
    public class JuegoDTO
    {
        public int IdGame { get; set; }
        public string Title { get; set; }
        public string FkUsername { get; set; }
        public string Description { get; set; }
        public DateTime? LaunchDate { get; set; }
        public float Height { get; set; }
        public bool Multiplayer { get; set; }
        public List<int> IdCategory { get; set; }
        public List<string> TitleCategory { get; set; }
        public List<int> IdPlataform { get; set; }
        public List<string> TitlePlataform { get; set; }

        public JuegoDTO()
        {
        }
    }
}
