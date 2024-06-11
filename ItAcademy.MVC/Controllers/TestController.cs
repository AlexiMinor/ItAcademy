using ItAcademy.MVC.Models;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.MVC.Controllers;

//[NonController]
public class TestController : Controller
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    public IActionResult Index(TestModel model)
    {
        return Ok($"Hello {model.Name}-{model.Age}");
    }

    public IActionResult TestServices()
    {
        var data = _testService.Do();

        return Ok(new
        {
            T1 = data[0], 
            T2 = data[1],
            S1 = data[2],
            S2 = data[3],
            Single = data[4],
        });
    }

    public IActionResult Private()
    {
        if (HttpContext.Request.Query["secret"] == "123")
        {
            return Ok("Hello secret world");
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login([FromForm]LoginModel model)
    {
        return Ok(new {
            model.Email, 
            model.Password
        });
    }

    //[Route("hello")]
    [HttpGet]
    public IActionResult Test([FromRoute]int? id, int? age)
    {
        return Ok(new {id, age});
    }

    [HttpGet]
    public IActionResult Test([FromQuery]int? id)
    {
        return Ok(new { id});
    }

    //public IActionResult ViewDataTest()
    //{

    //    ViewData["test"] = "abababa"; 
    //    return View();
    //}

    //public IActionResult ViewBagTest()
    //{

    //    ViewBag.T1 = "abababa";
    //    ViewBag.Test1 = 123123;
    //    ViewBag.Hello = new {A=42};

    //    return View();
    //}

}