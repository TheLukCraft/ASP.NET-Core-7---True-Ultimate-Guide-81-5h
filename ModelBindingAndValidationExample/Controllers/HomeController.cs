using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidationExample.Models;

namespace ModelBindingAndValidationExample.Controllers
{
    public class HomeController : Controller
    {
        //Priority: Form fields > Request body > Route data > query string parameters
        //Route data: /bookstore/1/false
        //Query string: /bookstore?bookid=10&isloggedin=true
        //You can, of course, combine the two, but this route date will take precedence. Router data and query string will read correctly
        //Example: /bookstore/1/false?bookid=10&isloggedin=true
        //It does not matter how much unnecessary information the query contains. The object will assign itself such values as the keys it finds.
        //It also doesn't matter the case of the letters next to the key.
        //Example: /bookstore/1/false?bookid=10&isloggedin=true&Author=Lol
        //Id in the case will be taken as route data, not query string, because route data has priority.
        //bookstore/1/false?bookid=10&isloggedin=true&Author=Lol
        //On the other hand, if we clearly give the attribute [FromQuery], [FromRoute], then even though we have,
        //for example, repeated id in the query, it will take those of the corresponding attribute.
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index(int? bookid, [FromRoute] bool? isloggedin, Book book)
        {
            //Book id should be applied
            if (bookid.HasValue == false)
            {
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied or empty");
            }
            //Book id can't be less than or equal to 0
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less than or equal to 0");
            }
            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than 1000.");
            }
            //isLoggedIn should be true
            if (isloggedin == false)
            {
                //return Unauthorized("User must be authenticated");
                return StatusCode(401);
            }

            return Content($"Book id: {bookid}, Book: {book}", "text/plain");
        }
    }
}