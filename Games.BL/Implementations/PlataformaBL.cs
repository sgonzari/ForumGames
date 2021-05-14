using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Games.DAL.Repositories.Contracts;

namespace Games.BL.Implementations
{
    public class PlataformaBL : IPlataformaBL
    {
        public IPlataformaRepository _plataformaRepository { get; set; }

        public PlataformaBL(IPlataformaRepository plataformaRepository)
        {
            _plataformaRepository = plataformaRepository;
        }

        public IEnumerable<PlataformaDTO> Get()
        {
            var plataformas = _plataformaRepository.Get();
            return plataformas;
        }
    }
}
