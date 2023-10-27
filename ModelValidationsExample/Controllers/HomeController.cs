using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))] Person person)
        public IActionResult Index([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorsList = new List<string>();
                ////First way - longer way without LINQ
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                //string errors = string.Join("\n", errorsList);
                return BadRequest(errors);
            }

            return Content($"{person}");
        }
    }
}