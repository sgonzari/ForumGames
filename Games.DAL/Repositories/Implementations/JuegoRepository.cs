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

        /*
         * Devuelve una lista con todos los juegos, incluyendo categoría y plataformas.
         */
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
                foreach (var platforma in plataformaJuegos)
                {
                    juegosplataformasDTO.Add(platforma);
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
                    IdPlatform = plataformaJuegos,
                    TitlePlatform = getTitlePlataforms(plataformaJuegos),
                    url = i.url,
                    NewComment = i.NewComment
                };
                juegosDTO.Add(juego);
                juegoscategoriasDTO.Clear();
                juegosplataformasDTO.Clear();
            }

            return juegosDTO;
        }

        /*
         * Devuelve una lista con la información del titulo del juego pasado y usuario.
         */
        public IEnumerable<JuegoDTO> GetData(string title, string username)
        {
            var juegos = _context.Games.ToList().Where(x => x.Title == title && x.FkUsername == username);
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
                foreach (var platforma in plataformaJuegos)
                {
                    juegosplataformasDTO.Add(platforma);
                }

                var juego = new JuegoDTO
                {
                    IdGame = i.IdGame,
                    FkUsername = i.FkUsername,
                    Title = i.Title,
                    Description = i.Description,
                    LaunchDate = i.LaunchDate,
                    Height = i.Height,
                    Multiplayer = i.Multiplayer,
                    IdCategory = categoriaJuegos,
                    TitleCategory = getTitleCategories(categoriaJuegos),
                    IdPlatform = plataformaJuegos,
                    TitlePlatform = getTitlePlataforms(plataformaJuegos),
                    url = i.url,
                    NewComment = i.NewComment
                };
                juegosDTO.Add(juego);
                juegoscategoriasDTO.Clear();
                juegosplataformasDTO.Clear();
            }

            return juegosDTO;
        }

        /*
         * Devuelve una lista con la información de un juego.
         */
        public IEnumerable<JuegoDTO> GetDataFromTitle(string title)
        {
            var juegos = _context.Games.ToList().Where(x => x.Title == title);
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
                foreach (var platforma in plataformaJuegos)
                {
                    juegosplataformasDTO.Add(platforma);
                }

                var juego = new JuegoDTO
                {
                    IdGame = i.IdGame,
                    Title = i.Title,
                    FkUsername = i.FkUsername,
                    Description = i.Description,
                    LaunchDate = i.LaunchDate,
                    Height = i.Height,
                    Multiplayer = i.Multiplayer,
                    IdCategory = categoriaJuegos,
                    TitleCategory = getTitleCategories(categoriaJuegos),
                    IdPlatform = plataformaJuegos,
                    TitlePlatform = getTitlePlataforms(plataformaJuegos),
                    url = i.url,
                    NewComment = i.NewComment
                };
                juegosDTO.Add(juego);
                juegoscategoriasDTO.Clear();
                juegosplataformasDTO.Clear();
            }
            return juegosDTO;
        }

        /*
         * Devuelve una lista con todos los juegos creado por un usuario.
         */
        public IEnumerable<JuegoDTO> getDataFromUsername(string username)
        {
            var juegos = _context.Games.ToList().Where(x => x.FkUsername == username);
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
                foreach (var platforma in plataformaJuegos)
                {
                    juegosplataformasDTO.Add(platforma);
                }

                var juego = new JuegoDTO
                {
                    IdGame = i.IdGame,
                    Title = i.Title,
                    FkUsername = i.FkUsername,
                    Description = i.Description,
                    LaunchDate = i.LaunchDate,
                    Height = i.Height,
                    Multiplayer = i.Multiplayer,
                    IdCategory = categoriaJuegos,
                    TitleCategory = getTitleCategories(categoriaJuegos),
                    IdPlatform = plataformaJuegos,
                    TitlePlatform = getTitlePlataforms(plataformaJuegos),
                    url = i.url,
                    NewComment = i.NewComment
                };
                juegosDTO.Add(juego);
                juegoscategoriasDTO.Clear();
                juegosplataformasDTO.Clear();
            }

            return juegosDTO;
        }

        /*
         * Guarda la información de un juego si no lo ha creado antes.
         */
        public void Add(JuegoDTO juegoDTO)
        {
            if (!existGame(juegoDTO))
            {
                var juegosCategorias = new GamesCategory();
                var juegosPlataformas = new GamesPlatforms();

                var juegos = new Entities.Games
                {
                    Title = juegoDTO.Title,
                    Description = juegoDTO.Description,
                    LaunchDate = juegoDTO.LaunchDate,
                    Height = juegoDTO.Height,
                    Multiplayer = juegoDTO.Multiplayer,
                    FkUsername = juegoDTO.FkUsername,
                    url = juegoDTO.url
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
                if (juegoDTO.IdPlatform != null)
                {
                    foreach (var i in juegoDTO.IdPlatform.ToList())
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
            } else
            {
                throw new Exception();
            }
            
        }

        /*
         * Cambiar el valor de newComment en la base de datos
         */
        public void PostNotifiationComment(JuegoDTO juegoDTO)
        {
            var query = (from o in _context.Games
                         where o.IdGame == juegoDTO.IdGame
                         select o).FirstOrDefault();

            query.NewComment = juegoDTO.NewComment;

            _context.SaveChanges();
        }

        /*
         * Actualiza la información de un juego.
         */
        public void UpdateGame(JuegoDTO juegoDTO)
        {
            var juegosCategorias = new GamesCategory();
            var juegosPlataformas = new GamesPlatforms();
            var cantCategory = (from o in _context.GamesCategory
                                where o.FkIdGame == juegoDTO.IdGame
                                select o).ToList();
            var cantPlatform = (from o in _context.GamesPlatforms
                                where o.FkIdGame == juegoDTO.IdGame
                                select o).ToList();
            foreach (var categories in cantCategory)
            {
                _context.GamesCategory.Remove(categories);
            }
            foreach (var platforms in cantPlatform)
            {
                _context.GamesPlatforms.Remove(platforms);
            }

            var juegos = new Entities.Games
                {
                IdGame = juegoDTO.IdGame,
                Title = juegoDTO.Title,
                Description = juegoDTO.Description,
                LaunchDate = juegoDTO.LaunchDate,
                Height = juegoDTO.Height,
                Multiplayer = juegoDTO.Multiplayer,
                FkUsername = juegoDTO.FkUsername,
                url = juegoDTO.url
            };
            _context.Games.Update(juegos);
            _context.SaveChanges();
            if (juegoDTO.IdCategory != null)
            {
                foreach (var i in juegoDTO.IdCategory.ToList())
                {
                    juegosCategorias = new GamesCategory
                    {
                        FkIdGame = juegoDTO.IdGame,
                        FkIdCategory = i
                    };
                    _context.GamesCategory.Add(juegosCategorias);
                    _context.SaveChanges();
                }
            }
            if (juegoDTO.IdPlatform != null)
            {
                foreach (var i in juegoDTO.IdPlatform.ToList())
                {
                    juegosPlataformas = new GamesPlatforms
                    {
                        FkIdGame = juegoDTO.IdGame,
                        FkIdPlatform = i
                    };
                    _context.GamesPlatforms.Add(juegosPlataformas);
                       _context.SaveChanges();
                }
            }
        }

        /*
         * Elimina un juego.
         */
        public void Remove(JuegoDTO juegoDTO)
        {
            var juegos = new Entities.Games
            {
                IdGame = juegoDTO.IdGame
            };
            _context.Games.Remove(juegos);
            _context.SaveChanges();
        }

        /*
         * Método que devuelve true or false si existe un juego.
         */
        public bool existGame(JuegoDTO juegoDTO)
        {
            var titleLinq = from o in _context.Games
                         where o.Title == juegoDTO.Title
                         && o.FkUsername == juegoDTO.FkUsername
                         select o.Title;

            if (titleLinq.Any())
            {
                return true;
            }
            return false;
        }

        /*
         * Método que devuelve el id del juego.
         */
        public int getIdGame(JuegoDTO juegoDTO)
        {
            var idLinq = from o in _context.Games
                     where o.Title == juegoDTO.Title 
                     && o.FkUsername == juegoDTO.FkUsername
                     select o.IdGame;
            int id = idLinq.First();
            return id;
        }

        /*
         * Método que devuelve una lista con los nombres de las categorías
         * pasandole una lista con las ids de las categorías.
         */
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

        /*
         * Método que devuelve una lista con los nombres de las plataformas
         * pasandole una lista con las ids de las plataformas.
         */
        public List<string> getTitlePlataforms(List<int> plataformaJuegos)
        {
            List<string> titlePlataforms = new List<string>();

            foreach (var idPlatforms in plataformaJuegos)
            {
                var titlePlataformsLinq = (from o in _context.Platforms
                                           where o.IdPlatform == idPlatforms
                                           select o.Platform).ToList();
                foreach (var platformsGames in titlePlataformsLinq)
                {
                    titlePlataforms.Add(platformsGames);
                }
            }
            return titlePlataforms;
        }
    }
}
