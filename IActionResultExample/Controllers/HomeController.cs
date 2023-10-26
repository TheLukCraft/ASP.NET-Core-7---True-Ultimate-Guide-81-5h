using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index()
        {
            //Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied");
            }
            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("Book id can't be null or empty");
            }

            //Book id should be between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                return BadRequest("Book id cant be less than 0 equal to zero.");
            }
            if (bookId > 1000)
            {
                return NotFound("Book id can't be greater than 1000.");
            }
            //isLoggedIn should be true
            if (!Convert.ToBoolean(Request.Query["isloggedin"]))
            {
                //return Unauthorized("User must be authenticated");
                return StatusCode(401);
            }
            ////302 - Found
            //return new RedirectToActionResult("Books", "Store", new { });
            ////second way
            //return RedirectToAction("Books", "Store", new { id = bookId });

            ////301 - Moved permanently
            //return new RedirectToActionResult("Books", "Store", new { }, permanent: true);
            ////second way
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });

            ////worse than RedirectToAction, but more simple
            ////301 - Moved permanently
            // return new LocalRedirectResult($"store/books/{bookId}");

            ////shorter notation
            ////302 - Found
            //return LocalRedirect($"store/books/{bookId}");

            ////shorter notation
            ////301 - Moved Permanently
            return LocalRedirectPermanent($"store/books/{bookId}");

            ////to be transferred between other domains
            ////302 - Found
            //return Redirect($"www.google.pl");

            ////301 - Moved Permanently
            //return RedirectPermanent($"www.google.pl");
        }
    }
}