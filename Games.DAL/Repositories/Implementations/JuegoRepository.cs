using System;
using System.Collections.Generic;
using System.Linq;
using Games.CORE.DTO;
using Games.DAL.Entities;
using Games.DAL.Repositories.Contracts;

namespace Games.DAL.Repositories.Implementations
{
    public class JuegoRepository : IJuegoRepository
    {
        public db_gamesContext _context { get; set;}

        public JuegoRepository(db_gamesContext context)
        {
            _context = context;
        }

        public IEnumerable<JuegoDTO> Get()
        {
            var juegos = _context.Games.ToList();

            List<JuegoDTO> juegosDTO = new List<JuegoDTO>();
            foreach (var i in juegos)
            {
                var juego = new JuegoDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    LaunchDate = i.LaunchDate,
                    Height = i.Height,
                    Multiplayer = i.Multiplayer
                };
                juegosDTO.Add(juego);
            }

            return juegosDTO;
        }
    }
}
