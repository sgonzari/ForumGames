using System;
using System.Collections.Generic;
using System.Linq;
using Games.CORE.DTO;
using Games.DAL.Entities;
using Games.DAL.Repositories.Contracts;

namespace Games.DAL.Repositories.Implementations
{
    public class ComentarioRepository : IComentarioRepository
    {
        public db_gamesContext _context { get; set; }

        public ComentarioRepository(db_gamesContext context)
        {
            _context = context;
        }

        public IEnumerable<ComentarioDTO> GetCommentFromId(int idGame)
        {
            var comentarios = _context.Comments.ToList().Where(x => x.FkIdGame == idGame);
            List<ComentarioDTO> comentariosDTO = new List<ComentarioDTO>();

            foreach(var i in comentarios)
            {
                var comentario = new ComentarioDTO
                {
                    IdComment = i.IdComment,
                    IdGame = i.FkIdGame,
                    Username = i.FkUsername,
                    Comment = i.Comment,
                    Date = i.Date
                };
                comentariosDTO.Add(comentario);
            }
            return comentariosDTO;
        }

        public void Add(ComentarioDTO comentarioDTO)
        {
            var comentarios = new Comments
            {
                FkIdGame = comentarioDTO.IdGame,
                FkUsername = comentarioDTO.Username,
                Comment = comentarioDTO.Comment,
                Date = comentarioDTO.Date
            };
            _context.Comments.Add(comentarios);
            _context.SaveChanges();
        }
    }
}
