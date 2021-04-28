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
    }
}
