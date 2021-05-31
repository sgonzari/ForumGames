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

        /*
         * Devuelve una lista con todas las plataformas.
         */
        public IEnumerable<PlataformaDTO> Get()
        {
            var plataformas = _context.Platforms.ToList();

            List<PlataformaDTO> plataformasDTO = new List<PlataformaDTO>();
            foreach (var i in plataformas)
            {
                var plataforma = new PlataformaDTO
                {
                    IdPlatform = i.IdPlatform,
                    Name = i.Platform
                };
                plataformasDTO.Add(plataforma);
            }
            return plataformasDTO;
        }
    }
}
