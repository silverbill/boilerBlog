using Microsoft.AspNetCore.Mvc;

/// and home -> Home() - an HTML home page
//about -> About() - an HTML about page




[Route("/home")]
public class HomeController : Controller{
    private IBlogRepo blog;
    public HomeController(IBlogRepo b){
        blog = b;
    }

    [HttpGet]
    public IActionResult ReadAll(){
        return View(blog);
    }

    [HttpGet("home/About")]
    public IActionResult Index(string username = "you")
    {
        ViewData["Message"] = "Some extra info can be sent to the view";
        ViewData["Username"] = username;
        return View(); // View(new Student) method takes an optional object as a "model", typically called a ViewModel
    }
}