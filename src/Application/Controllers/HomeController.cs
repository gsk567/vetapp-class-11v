using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Data;
using Service;

namespace Application.Controllers;

public class HomeController : Controller
{
    private readonly IDogService dogService;

    public HomeController(IDogService dogService)
    {
        this.dogService = dogService;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        this.dogService.CreateRandomDog();
        var obj = new HomeViewModel { FirstName = "Pesho", LastName = "Ivanov" };
        return View(obj);
    }

    [HttpGet("/dogs")]
    public IActionResult Dogs()
    {
        return Ok(this.dogService.FetchDogs());
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}