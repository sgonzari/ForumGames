using System;
using System.Linq;
using Games.CORE.DTO;
using Games.DAL.Entitites;
using Games.DAL.Repositories.Contracts;


namespace Games.DAL.Repositories.Implementations
{

    public class UsuarioRepository : IUsuarioRepository
    {
        public db_gamesContext _context { get; set; }


        public UsuarioRepository(db_gamesContext context)
        {
            _context = context;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _context.Users.Any(u => u.Username == usuarioDTO.Username && 
            u.Passwd == usuarioDTO.Password);
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            var usuario = new Users
            {
                Username = usuarioDTO.Username,
                Passwd = usuarioDTO.Password,
                FirstName = usuarioDTO.Nombre,
                Surname = usuarioDTO.Apellidos,
                Email = usuarioDTO.Correo,
                Phone = usuarioDTO.Telefono
            };
            _context.Users.Add(usuario);
            _context.SaveChanges();
        }
    }
}
