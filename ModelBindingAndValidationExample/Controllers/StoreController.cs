using Microsoft.AspNetCore.Mvc;

namespace ModelBindingAndValidationExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>book store with id: {id}</h1>", "text/html");
        }
    }
}