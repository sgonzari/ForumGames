using System;
using System.Collections.Generic;
using System.Linq;
using Games.CORE.DTO;
using Games.DAL.Entities;
using Games.DAL.Repositories.Contracts;

namespace Games.DAL.Repositories.Implementations
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public db_gamesContext _context { get; set; }

        public CategoriaRepository(db_gamesContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoriaDTO> Get()
        {
            throw new NotImplementedException();
        }
    }
}
