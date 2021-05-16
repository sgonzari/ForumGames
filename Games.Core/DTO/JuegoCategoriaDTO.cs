using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.CORE.DTO
{
    public class JuegoCategoriaDTO
    {
        public int FkIdGame { get; set; }
        public int FkIdCategory { get; set; }

        public JuegoCategoriaDTO()
        {
        }
    }
}
