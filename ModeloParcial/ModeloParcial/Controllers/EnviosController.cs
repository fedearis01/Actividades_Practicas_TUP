using Microsoft.AspNetCore.Mvc;
using ModeloParcial.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModeloParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {

        private readonly IEnvioService _service;
        public EnviosController(IEnvioService service) 
        {
            _service = service;
        }
        // Fix for CS1750: Change 'bool estado = null' to 'bool? estado = null' (nullable bool)
        [HttpGet("/envios")]
        public IActionResult GetEnvios([FromQuery] string direccion = null, [FromQuery] bool estado = false)
        {
            try
            {
                
                var lste = _service.GetEnvios(direccion, estado);
                if (lste != null)
                {
                    return Ok(lste);
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, new { msj = "no se pudo obtener" });
            }
        }

        
        // DELETE api/<EnviosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _service.DeleteEnvio(id);
                if (result)
                {
                    return Ok("se elimino correctante");
                }
                else
                {
                    return BadRequest(); 
                }
            }
            catch (Exception)
            {

                return StatusCode(500, new { msj = "no se pudo eliminar" });
            }
        }
    }
}
