using System;

namespace Games.CORE.DTO
{
    public class JuegoDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LaunchDate { get; set; }
        public decimal Height { get; set; }
        public bool Multiplayer { get; set; }

        public JuegoDTO()
        {
        }
    }
}
