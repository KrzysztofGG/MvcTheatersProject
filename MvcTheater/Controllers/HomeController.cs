using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcActor.Data;
using MvcTheater.Models;


namespace MvcTheater.Controllers;

public class HomeController : Controller
{

    public static bool admin=false;
    public static bool logged_in=false;
    private readonly MvcActorContext _context;

    public HomeController(MvcActorContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Stats(){
        return View();
    }

    [HttpPost]
    public IActionResult LoginForm(IFormCollection form){
        
        Console.WriteLine(form["login"]);
        if(form["login"]=="admin"&&form["password"]=="admin"){
            Console.WriteLine("XD");
            HttpContext.Session.SetString("logged_in", "True");
            HttpContext.Session.SetString("admin", "True");
            admin=true;
            logged_in=true;
            return RedirectToAction("Index");
        }


        String userId=form["login"];
        String password=form["password"];
        Console.WriteLine("---------------------------------------");
        // var user=!_context.User.(u=>u.Login==userId).FirstOrDefault()
        
        var user = _context.User.Where(u => u.Login == userId).FirstOrDefault();
        if (user != null) {
            Console.WriteLine(user.Login);
            Console.WriteLine(user.Password);
            Console.WriteLine(password+"@@@@");
            if(user.Password==form["password"]){
                HttpContext.Session.SetString("logged_in", "True");
                HttpContext.Session.SetString("admin", "False");
                logged_in=true;
                return RedirectToAction("Index");

            }
        }
        return RedirectToAction("Login");
        
        
    }

    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Logout(){
        HttpContext.Session.SetString("logged_in", "False");
        HttpContext.Session.SetString("admin", "False");
        admin=false;
        logged_in=false;
        return RedirectToAction("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
