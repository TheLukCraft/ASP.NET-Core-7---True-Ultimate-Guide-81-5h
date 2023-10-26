using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult()
            //{
            //    Content = "Hello from Index",
            //    ContentType = "text/html"
            //};

            ////Second way to return content
            //return Content("Hello from Index", "text/html");

            return Content("<h1>Welcome</h1><h2>Hello from Index</h2", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            ////first way
            //return "{\"key\":\"value\"}";
            PersonModel person = new PersonModel()
            {
                Id = Guid.NewGuid(),
                FirstName = "Luk",
                LastName = "Craft",
                Age = 26
            };
            //return new JsonResult(person);
            return Json(person);
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }

        [Route("file-download")]
        public IActionResult FileDownload()
        {
            ////first way
            //return new VirtualFileResult("/photo.jpg", "image/jpg");

            return File("/photo.jpg", "image/jpg");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            ////first way
            //return new VirtualFileResult(@"C:\Users\luk19\Documents\Lightshot\Screenshot_1.png", "image/png");

            return PhysicalFile(@"C:\Users\luk19\Documents\Lightshot\Screenshot_1.png", "image/png");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\luk19\Documents\Lightshot\Screenshot_1.png");
            ////first way
            //return new FileContentResult(bytes, "image/png");
            return File(bytes, "image/png");
        }
    }
}