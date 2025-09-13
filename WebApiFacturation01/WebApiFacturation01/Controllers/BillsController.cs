using Microsoft.AspNetCore.Mvc;
using Practica01.Data.DataApi;
using Practica01.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFacturation01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private IDataApi dataApi;


        public BillsController()
        {
            dataApi = new DataApiImp();
        }
        // GET: api/<BillsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Bills> lst = null;
            try
            {
                lst = dataApi.GetBills();
                return Ok(lst);

            }
            catch (Exception)
            {
                return StatusCode(500, (new { mesage = "error a la hora de mostrar" }));
            }
        }

        // GET api/<BillsController>/5
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                var b = dataApi.GetBillById(id);
                if (b == null)
                {
                    return NotFound($"no se encontro el producto con el id {id}");
                }
                else
                {
                    return Ok(b);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, (new { mesage = "error a la hora de mostrar" }));
            }
        }

        // POST api/<BillsController>
        [HttpPost]
        public IActionResult Post(Bills b)
        {
            try
            {
                if (b == null)
                {
                    return BadRequest("Datos erroneos de producto");
                }
                bool result = dataApi.SaveBills(b);
                if (result)
                {
                    return Ok("se guardo el producto");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, (new { mesage = "error a la hora de crear" }));
            }
        }

        // PUT api/<BillsController>/5
       

        // DELETE api/<BillsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int rowaff = dataApi.DeleteBills(id);
                if (rowaff >= 0)
                {
                    return Ok("producto eliminado");
                }
                else
                {
                    return StatusCode(500);
                }


            }
            catch (Exception)
            {
                return StatusCode(500, (new { msg = "no se pudo eliminar el registro" }));
            }
        }
    }
}
