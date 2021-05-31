using System;
using System.Collections.Generic;
using Games.BL.Contracts;
using Games.CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuegoController : ControllerBase
    {
        public IJuegoBL _juegoBL { get; set; }

        public JuegoController(IJuegoBL juegoBL)
        {
            _juegoBL = juegoBL;
        }

        /*
         * Devuelve una lista con todos los juegos.
         */
        public ActionResult<IEnumerable<JuegoDTO>> Get()
        {
            return Ok(_juegoBL.Get());
        }

        /*
         * Devuelve una lista de información de un juego pasandole su título y su usuario.
         */
        [HttpGet]
        [Route("getData")]
        public ActionResult<IEnumerable<JuegoDTO>> getData(string title, string username)
        {
            return Ok(_juegoBL.GetData(title, username));
        }

        /*
         * Devuelve una lista de información de todos los juegos pasandole su título.
         */
        [HttpGet]
        [Route("getDataTitle")]
        public ActionResult<IEnumerable<JuegoDTO>> getDataFromTitle(string title)
        {
            return Ok(_juegoBL.GetDataFromTitle(title));
        }

        /*
         * Devuelve una lista de juegos pasandole su usuario.
         */
        [HttpGet]
        [Route("getDataUsername")]
        public ActionResult<IEnumerable<JuegoDTO>> getDataFromUsername(string username)
        {
            return Ok(_juegoBL.getDataFromUsername(username));
        }

        /*
         * Devuelve un status 200 si se ha añadido el juego correctamente,
         * Devuelve un status 400 si intenta añadir un juego con un título ya creado
         */
        [HttpPost]
        public ActionResult<bool> Add(JuegoDTO juegoDTO)
        {
            try
            {
                _juegoBL.Add(juegoDTO);
                return Ok(true);
            } catch (Exception e)
            {
                return NotFound();
            }
            
        }

        /*
         * Devuelve un status 200 si se ha actualizado el juego correctamente.
         */
        [HttpPost]
        [Route("update")]
        public ActionResult<bool> UpdateGame(JuegoDTO juegoDTO)
        {
            _juegoBL.UpdateGame(juegoDTO);
            return Ok(true);
        }

        /*
         * Devuelve un status 200 si se ha eliminado el juego correctamente.
         */
        [HttpDelete]
        public ActionResult<bool> Remove(JuegoDTO juegoDTO)
        {
            _juegoBL.Remove(juegoDTO);
            return Ok(true);
        }
    }
}
