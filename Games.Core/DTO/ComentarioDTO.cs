using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.CORE.DTO
{
    public class ComentarioDTO
    {
        public int IdComment { get; set; }
        public int IdGame { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }
    }
}
