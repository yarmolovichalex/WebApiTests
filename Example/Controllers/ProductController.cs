using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Example.Infrastructure;
using Example.Models;

namespace Example.Controllers
{
    public class ProductsController : ApiController
    {
        IRepository repo;

        public ProductsController(IRepository repoImpl)
        {
            repo = repoImpl;
        }

        public IHttpActionResult GetAll()
        {
            return Ok(repo.Products);
        }

        public IHttpActionResult Delete(int id)
        {
            repo.DeleteProduct(id);
            return new NoContentResult();
        }

        [HttpGet]
        [Route("api/products/noop")]
        public IHttpActionResult NoOp()
        {
            return Ok();
        }
    }
}
