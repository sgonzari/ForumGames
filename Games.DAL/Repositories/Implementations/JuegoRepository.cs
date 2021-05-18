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
            List<int> juegosplataformasDTO = new List<int>();

            List<JuegoDTO> juegosDTO = new List<JuegoDTO>();
            foreach (var i in juegos)
            {
                var categoriaJuegos = (from o in _context.GamesCategory
                                      where o.FkIdGame == i.IdGame
                                      select o.FkIdCategory).ToList();
                var plataformaJuegos = (from o in _context.GamesPlatforms
                                       where o.FkIdGame == i.IdGame
                                       select o.FkIdPlatform).ToList();

                foreach (var categoria in categoriaJuegos)
                {
                    juegoscategoriasDTO.Add(categoria);
                }
                foreach (var plataforma in plataformaJuegos)
                {
                    juegosplataformasDTO.Add(plataforma);
                }

                var juego = new JuegoDTO
                {
                    IdGame = i.IdGame,
                    Title = i.Title,
                    Description = i.Description,
                    LaunchDate = i.LaunchDate,
                    Height = i.Height,
                    Multiplayer = i.Multiplayer,
                    IdCategory = categoriaJuegos,
                    TitleCategory = getTitleCategories(categoriaJuegos),
                    IdPlataform = plataformaJuegos,
                    TitlePlataform = getTitlePlataforms(plataformaJuegos)
                };
                juegosDTO.Add(juego);
                juegoscategoriasDTO.Clear();
                juegosplataformasDTO.Clear();
            }

            return juegosDTO;
        }

        public IEnumerable<JuegoDTO> GetDataFromTitle(string title, string username)
        {
            List<JuegoDTO> juegosDTO = new List<JuegoDTO>();
            List<int> juegoscategoriasDTO = new List<int>();
            List<int> juegosplataformasDTO = new List<int>();
            var juegos = from o in _context.Games
                         where o.Title == title && o.FkUsername == username
                         select o;
            var idGame = (from o in _context.Games
                          where o.Title == title && o.FkUsername == username
                          select o.IdGame).First();
            var categoriaJuegos = (from o in _context.GamesCategory
                                   where o.FkIdGame == idGame
                                   select o.FkIdCategory).ToList();
            var plataformaJuegos = (from o in _context.GamesPlatforms
                                    where o.FkIdGame == idGame
                                    select o.FkIdPlatform).ToList();

            foreach (var categoria in categoriaJuegos)
            {
                juegoscategoriasDTO.Add(categoria);
            }
            foreach (var plataforma in plataformaJuegos)
            {
                juegosplataformasDTO.Add(plataforma);
            }

            var TitleCategories = getTitleCategories(categoriaJuegos);
            var TitlePlatforms = getTitlePlataforms(plataformaJuegos);

            foreach (var info in juegos)
            {
                var juego = new JuegoDTO
                {
                    Title = info.Title,
                    Description = info.Description,
                    LaunchDate = info.LaunchDate,
                    Height = info.Height,
                    Multiplayer = info.Multiplayer,
                    IdCategory = categoriaJuegos,
                    TitleCategory = TitleCategories,
                    IdPlataform = plataformaJuegos,
                    TitlePlataform = TitlePlatforms
                };
                juegosDTO.Add(juego);
            }

            return juegosDTO;
        }

        public IEnumerable<JuegoDTO> GetDataFromTitle(string title)
        {
            List<JuegoDTO> juegosDTO = new List<JuegoDTO>();
            List<int> juegoscategoriasDTO = new List<int>();
            List<int> juegosplataformasDTO = new List<int>();
            var juegos = from o in _context.Games
                         where o.Title == title
                         select o;
            var idGame = (from o in _context.Games
                          where o.Title == title
                          select o.IdGame).First();
            var categoriaJuegos = (from o in _context.GamesCategory
                                   where o.FkIdGame == idGame
                                   select o.FkIdCategory).ToList();
            var plataformaJuegos = (from o in _context.GamesPlatforms
                                    where o.FkIdGame == idGame
                                    select o.FkIdPlatform).ToList();

            foreach (var categoria in categoriaJuegos)
            {
                juegoscategoriasDTO.Add(categoria);
            }
            foreach (var plataforma in plataformaJuegos)
            {
                juegosplataformasDTO.Add(plataforma);
            }

            var TitleCategories = getTitleCategories(categoriaJuegos);
            var TitlePlatforms = getTitlePlataforms(plataformaJuegos);

            foreach (var info in juegos)
            {
                var juego = new JuegoDTO
                {
                    IdGame = info.IdGame,
                    Title = info.Title,
                    FkUsername = info.FkUsername,
                    Description = info.Description,
                    LaunchDate = info.LaunchDate,
                    Height = info.Height,
                    Multiplayer = info.Multiplayer,
                    IdCategory = categoriaJuegos,
                    TitleCategory = TitleCategories,
                    IdPlataform = plataformaJuegos,
                    TitlePlataform = TitlePlatforms
                };
                juegosDTO.Add(juego);
            }

            return juegosDTO;
        }

        public void Add(JuegoDTO juegoDTO)
        {
            var juegosCategorias = new GamesCategory();
            var juegosPlataformas = new GamesPlatforms();

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
                if (juegoDTO.IdCategory != null)
                {
                    foreach (var i in juegoDTO.IdCategory.ToList())
                    {
                        juegosCategorias = new GamesCategory
                        {
                            FkIdGame = getIdGame(juegoDTO),
                            FkIdCategory = i
                        };
                        _context.GamesCategory.Add(juegosCategorias);
                        _context.SaveChanges();
                    }
                }
                if (juegoDTO.IdPlataform != null)
                {
                    foreach (var i in juegoDTO.IdPlataform.ToList())
                    {
                        juegosPlataformas = new GamesPlatforms
                        {
                            FkIdGame = getIdGame(juegoDTO),
                            FkIdPlatform = i
                        };
                        _context.GamesPlatforms.Add(juegosPlataformas);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                throw new Exception("El juego existe");
            }
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

        public List<string> getTitleCategories(List<int>categoriaJuegos)
        {
            List<string> titleCategories = new List<string>();

            foreach(var idCategories in categoriaJuegos)
            {
                var titleCategoriesLinq = (from o in _context.Category
                                           where o.IdCategory == idCategories
                                           select o.Name).ToList();
                foreach (var categoriesGames in titleCategoriesLinq)
                {
                    titleCategories.Add(categoriesGames);
                }
            }
            return titleCategories;
        }

        public List<string> getTitlePlataforms(List<int> plataformaJuegos)
        {
            List<string> titlePlataforms = new List<string>();

            foreach (var idPlataforms in plataformaJuegos)
            {
                var titlePlataformsLinq = (from o in _context.Platforms
                                           where o.IdPlatform == idPlataforms
                                           select o.Platform).ToList();
                foreach (var plataformsGames in titlePlataformsLinq)
                {
                    titlePlataforms.Add(plataformsGames);
                }
            }
            return titlePlataforms;
        }
    }
}
