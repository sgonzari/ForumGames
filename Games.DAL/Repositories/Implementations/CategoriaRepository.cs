﻿using System;
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

        /*
         * Devuelve una lista con todas las categorías.
         */
        public IEnumerable<CategoriaDTO> Get()
        {
            var categorias = _context.Category.ToList();

            List<CategoriaDTO> categoriasDTO = new List<CategoriaDTO>();
            foreach (var i in categorias)
            {
                var categoria = new CategoriaDTO
                {
                    IdCategory = i.IdCategory,
                    Name = i.Name
                };
                categoriasDTO.Add(categoria);
            }
            return categoriasDTO;
        }
    }
}
