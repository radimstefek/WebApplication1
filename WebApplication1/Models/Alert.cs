/*using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Alert : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
*/

namespace WebApplication1.Models
{
    public class Alert
    {
        public bool IsEnabled { get; set; }
        public string Text { get; set; }
    }
}
