using System;
using System.Collections.Generic;
using System.Linq;
using Games.CORE.DTO;
using Games.DAL.Entities;
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
            u.Passwd == usuarioDTO.Passwd);
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            var usuario = new Users
            {
                Username = usuarioDTO.Username,
                Passwd = usuarioDTO.Passwd,
                FirstName = usuarioDTO.Firstname,
                Surname = usuarioDTO.Surname,
                Email = usuarioDTO.Email,
                Phone = usuarioDTO.Phone
            };
            _context.Users.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _context.Users.ToList();

            //Mapeo de Usuario a UsuarioDTO
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            foreach (var i in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    Username = i.Username,
                    Group = i.Group,
                    Passwd = i.Passwd,
                    Email = i.Email,
                    Firstname = i.FirstName,
                    Surname = i.Surname,
                    Phone = i.Phone
                };
                usuariosDTO.Add(usuario);
            }
            return usuariosDTO;
        }
    }
}
