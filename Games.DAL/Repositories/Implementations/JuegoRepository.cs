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

        public void Add(JuegoDTO juegoDTO)
        {
            var juegos = new Games.DAL.Entities.Games
            {
                Title = juegoDTO.Title,
                Description = juegoDTO.Description,
                LaunchDate = juegoDTO.LaunchDate,
                Height = juegoDTO.Height,
                Multiplayer = juegoDTO.Multiplayer,
                FkUsername = "root"   //Modificar esto por el usuario de la cuenta a realizar esto
            };
            _context.Games.Add(juegos);
            _context.SaveChanges();
        }

        // MODIFICAR por el usuario de la cuenta
        public string GetUsername()
        {
            return "root";
        }

        // Obtiene la id del juego por el titulo y el usuario
        public int GetIdGame(string Title)
        {
            var juegos = _context.Games.ToList();

            foreach (var i in juegos)
            {
                if (i.Title.Equals(Title) && (i.FkUsername.Equals(GetUsername())))
                {
                    return i.IdGame;
                }
            }

            return 0;
        }

        public void Remove(JuegoDTO juegoDTO)
        {
            var juegos = new Games.DAL.Entities.Games
            {
                Title = juegoDTO.Title,
                IdGame = GetIdGame(juegoDTO.Title)
            };
            _context.Games.Remove(juegos);
            _context.SaveChanges();
        }
    }
}
