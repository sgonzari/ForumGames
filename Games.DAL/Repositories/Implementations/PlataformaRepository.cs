using System;
using System.Collections.Generic;
using System.Linq;
using Games.CORE.DTO;
using Games.DAL.Entities;
using Games.DAL.Repositories.Contracts;

namespace Games.DAL.Repositories.Implementations
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public db_gamesContext _context { get; set; }

        public PlataformaRepository(db_gamesContext context)
        {
            _context = context;
        }

        public IEnumerable<PlataformaDTO> Get()
        {
            throw new NotImplementedException();
        }
    }
}
