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
    private readonly IDogRepository dogRepository;

    public HomeController(IDogService dogService, IDogRepository dogRepository)
    {
        this.dogService = dogService;
        this.dogRepository = dogRepository;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        var obj = new HomeViewModel { FirstName = "Pesho", LastName = "Ivanov" };
        return View(obj);
    }

    [HttpGet("/dogs")]
    public IActionResult Dogs()
    {
        var dogsNames = new List<string>();
        var dogsFromRepository = this.dogRepository.FetchDogs();
        var dogsFromService = this.dogService.FetchDogs();
        
        dogsNames.AddRange(dogsFromRepository.Select(x => x.Name));
        dogsNames.AddRange(dogsFromService.Select(x => x.Name));
        
        return Ok(dogsNames);
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