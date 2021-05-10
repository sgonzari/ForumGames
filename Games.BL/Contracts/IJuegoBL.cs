using System;
using System.Collections.Generic;
using Games.CORE.DTO;

namespace Games.BL.Contracts
{
    public interface IJuegoBL
    {
        IEnumerable<JuegoDTO> Get();
    }
}
