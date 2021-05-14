using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Games.DAL.Repositories.Contracts;

namespace Games.BL.Implementations
{
    public class CategoriaBL : ICategoriaBL
    {
        public ICategoriaRepository _categoriaRepository { get; set; }

        public CategoriaBL(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<CategoriaDTO> Get()
        {
            var categorias = _categoriaRepository.Get();
            return categorias;
        }
    }
}
