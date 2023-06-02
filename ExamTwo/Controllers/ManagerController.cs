using Examtwo.Core;
using Examtwo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examtwo.Controllers;

public class ManagerController : Controller
{
    private readonly Database _database;

    public ManagerController(Database database)
    {
        _database = database;
    }

    [HttpGet]
    public IActionResult ManagerExamtwo() // Renamed to avoid conflict
    {
        var exams = _database.Exams.ToList();
        return View(exams);
    }

    // Create method
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(ExamtwoClass product)
    {

        if (!ModelState.IsValid)
        {
            return View(product);
        }

        product.CreatedDate = DateTime.Now;

        _database.Exams.Add(product);
        _database.SaveChanges();

        return RedirectToAction("ManagerExamtwo");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
            
        var product = _database.Exams.SingleOrDefault(p => p.Id == id);
        return View(product);
    }
    [HttpPost]
    public IActionResult Edit(ExamtwoClass product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }   
        var dbproduct = _database.Exams.SingleOrDefault(p => p.Id == product.Id);
        if (dbproduct is null)
        {
            return RedirectToAction("ManagerExamtwo");
        }
        dbproduct.Name = product.Name;
        dbproduct.Description = product.Description;
        dbproduct.Price = product.Price;
        _database.SaveChanges();
        return RedirectToAction("ManagerExamtwo");

    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var dbproduct = _database.Exams.SingleOrDefault(p => p.Id == id);

        return View(dbproduct);

    }
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        // var dbproduct = _menuManagerDbContext.Products.SingleOrDefault(p => p.Id == id);
        var dbproduct = new ExamtwoClass { Id = id, Name = String.Empty };
        // if (dbproduct is null)
        // {
        //     return RedirectToAction("Index");
        // }
        _database.Exams.Attach(dbproduct);
        _database.Exams.Remove(dbproduct);
        _database.SaveChanges();
        return RedirectToAction("ManagerExamtwo");
    }
}