using Microsoft.AspNetCore.Mvc;
using Practica01.Data.DataApi;
using Practica01.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFacturation01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private IDataApi dataApi;


        public ProductController()
        {
            dataApi = new DataApiImp();
        }




        // GET: ProductController
        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> lst = null;
            try
            {
                lst = dataApi.GetProducts();
                return Ok(lst);

            }
            catch (Exception)
            {
                return StatusCode(500, (new { mesage = "error a la hora de mostrar" }));
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetProductsByID(int id)
        {
            
            try
            {
                var p = dataApi.GetProductById(id);
                if (p == null)
                {
                    return NotFound($"no se encontro el producto con el id {id}");
                }
                else
                {
                    return Ok(p);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, (new { mesage = "error a la hora de mostrar" }));
            }
        }
        // POST: ProductController/Create
        [HttpPost]
        public IActionResult Post(Product p)
        {
            try
            {
                if (p == null)
                {
                    return BadRequest("Datos erroneos de producto");
                }
                int result = dataApi.SaveProduct(p);
                if (result >= 0)
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

        // GET: ProductController/Delete/5

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {   
                int rowaff = dataApi.DeleteProduct(id);
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
