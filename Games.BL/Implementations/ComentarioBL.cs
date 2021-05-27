using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Games.DAL.Repositories.Contracts;

namespace Games.BL.Implementations
{
    public class ComentarioBL : IComentarioBL
    {
        public IComentarioRepository _comentarioRepository { get; set; }

        public ComentarioBL(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public IEnumerable<ComentarioDTO> GetCommentFromId(int idGame)
        {
            var comentarios = _comentarioRepository.GetCommentFromId(idGame);
            return comentarios;
        }
    }
}
