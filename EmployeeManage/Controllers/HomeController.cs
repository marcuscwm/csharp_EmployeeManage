using EmployeeManage.Data;
using EmployeeManage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManage.Controllers;


public class HomeController : Controller
{
    private EMDBContext dbContext;

    public HomeController(EMDBContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        List<Employee> employees = dbContext.Employee.ToList();
        ViewBag.employees = employees;
        return View();
    }

    [HttpGet("addemployee")]
    public IActionResult AddEmployee()
    {
        return View();
    }

    [HttpPost("saveemployee")]
    public IActionResult SaveEmployee(Employee post)
    {
        dbContext.Add(post);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
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