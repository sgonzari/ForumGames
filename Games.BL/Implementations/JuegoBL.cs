using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Games.DAL.Repositories.Contracts;

namespace Games.BL.Implementations
{
    public class JuegoBL : IJuegoBL
    {
        public IJuegoRepository _juegoRepository { get; set; }

        public JuegoBL(IJuegoRepository juegoRepository)
        {
            _juegoRepository = juegoRepository;
        }

        public IEnumerable<JuegoDTO> Get()
        {
            var juegos = _juegoRepository.Get();
            return juegos;
        }

        public IEnumerable<JuegoDTO> GetData(string title, string username)
        {
            var juegos = _juegoRepository.GetData(title, username);
            return juegos;
        }

        public IEnumerable<JuegoDTO> GetDataFromTitle(string title)
        {
            var juegos = _juegoRepository.GetDataFromTitle(title);
            return juegos;
        }
        public IEnumerable<JuegoDTO> getDataFromUsername(string username)
        {
            var juegos = _juegoRepository.getDataFromUsername(username);
            return juegos;
        }

        public void Add(JuegoDTO juegoDTO)
        {
            _juegoRepository.Add(juegoDTO);
        }

        public void UpdateGame(JuegoDTO juegoDTO)
        {
            _juegoRepository.UpdateGame(juegoDTO);
        }

        public void Remove(JuegoDTO juegoDTO)
        {
            _juegoRepository.Remove(juegoDTO);
        }
    }
}
