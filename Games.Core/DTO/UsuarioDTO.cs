using System;

namespace Games.CORE.DTO
{
    public class UsuarioDTO
    {
        public string Username { get; set; }
        public string Group { get; set; }
        public string Passwd { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }

        public UsuarioDTO() 
        {
        }
    }
}
