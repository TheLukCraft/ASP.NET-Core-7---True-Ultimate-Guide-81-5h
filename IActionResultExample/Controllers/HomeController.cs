using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            //Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied");
            }
            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book id can't be null or empty");
            }

            //Book id should be between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                Response.StatusCode = 400;
                return Content("Book id cant be less than 0 equal to zero.");
            }
            if (bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id can't be greater than 1000.");
            }
            //isLoggedIn should be true
            if (!Convert.ToBoolean(Request.Query["isloggedin"]))
            {
                return Content("User must be authenticated");
            }
            return File("/photo.jpg", "image/jpg");
        }
    }
}