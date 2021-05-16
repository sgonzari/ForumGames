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
        public db_gamesContext _context { get; set; }

        public JuegoRepository(db_gamesContext context)
        {
            _context = context;
        }

        public IEnumerable<JuegoDTO> Get()
        {
            var juegos = _context.Games.ToList();
            List<int> juegoscategoriasDTO = new List<int>();

            List<JuegoDTO> juegosDTO = new List<JuegoDTO>();
            foreach (var i in juegos)
            {
                foreach (var o in i.GamesCategory)
                {
                    juegoscategoriasDTO.Add(o.FkIdCategory);
                }
                var listaJuegosCategorias = String.Join("", 
                    juegoscategoriasDTO.ConvertAll(x => x.ToString()).ToArray());
                var juego = new JuegoDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    LaunchDate = i.LaunchDate,
                    Height = i.Height,
                    Multiplayer = i.Multiplayer,
                    Categoria = new List<JuegoCategoriaDTO>()
                    {
                        new JuegoCategoriaDTO()
                        {
                            FkIdCategory = int.Parse(listaJuegosCategorias)
                        }
                    }
                };
                juegosDTO.Add(juego);
            }

            return juegosDTO;
        }

        public void Add(JuegoDTO juegoDTO)
        {
            var juegosCategorias = new GamesCategory();

            if (!existGame(juegoDTO))
            {
                var juegos = new Entities.Games
                {
                    Title = juegoDTO.Title,
                    Description = juegoDTO.Description,
                    LaunchDate = juegoDTO.LaunchDate,
                    Height = juegoDTO.Height,
                    Multiplayer = juegoDTO.Multiplayer,
                    FkUsername = getUsername(),   //Modificar esto por el usuario de la cuenta a realizar esto
                };
                _context.Games.Add(juegos);
                _context.SaveChanges();
                if (juegoDTO.Categoria != null)
                {
                    foreach (var i in juegoDTO.Categoria.ToList())
                    {
                        juegosCategorias = new GamesCategory
                        {
                            FkIdGame = getIdGame(juegoDTO),
                            FkIdCategory = i.FkIdCategory
                        };
                        _context.GamesCategory.Add(juegosCategorias);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                throw new Exception("El juego existe");
            }
        }

        public bool existGame(JuegoDTO juegoDTO)
        {
            var titleLinq = from o in _context.Games
                         where o.Title == juegoDTO.Title
                         && o.FkUsername == getUsername()
                         select o.Title;

            if (titleLinq.Any())
            {
                return true;
            }
            return false;
        }

        public int getIdGame(JuegoDTO juegoDTO)
        {
            var idLinq = from o in _context.Games
                     where o.Title == juegoDTO.Title 
                     && o.FkUsername == getUsername()
                     select o.IdGame;
            int id = idLinq.First();
            return id;
        }

        // MODIFICAR por el usuario de la cuenta
        public string getUsername()
        {
            return "root";
        }

        public void Remove(JuegoDTO juegoDTO)
        {
            var idLinq = from o in _context.Games
                         where o.Title == juegoDTO.Title
                         select o.IdGame;
            int id = idLinq.First();

            var juegos = new Entities.Games
            {
                IdGame = id
            };
            _context.Games.Remove(juegos);
            _context.SaveChanges();
        }
    }
}
