namespace TrainingPortal.Controllers;

using Microsoft.AspNetCore.Mvc;
using TrainingEntities;
using TrainingServices;
using System.Collections.Generic;

public class ProductsController : Controller
{
  private readonly ITrainingService trainingService;

  public ProductsController(ITrainingService trainingService)
  {
    this.trainingService = trainingService;
  }

  public IActionResult Index()
  {
    IEnumerable<Training>? trainings = trainingService.GetAllTrainings();
    return View(trainings);
  }

  public IActionResult Details(int id)
  {
    var training = trainingService.GetTrainingById(id);
    if (training == null)
    {
      return NotFound();
    }
    return View(training);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Create(Training training)
  {
    if (ModelState.IsValid)
    {
      trainingService.AddTraining(training);
      return RedirectToAction(nameof(Index));
    }
    return View(training);
  }

  public IActionResult Edit(int id)
  {
    var training = trainingService.GetTrainingById(id);
    if (training == null)
    {
      return NotFound();
    }
    return View(training);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(int id, Training training)
  {
    if (id != training.Id)
    {
      return BadRequest();
    }
    if (ModelState.IsValid)
    {
      trainingService.UpdateTraining(training);
      return RedirectToAction(nameof(Index));
    }
    return View(training);
  }

  public IActionResult Delete(int id)
  {
    var training = trainingService.GetTrainingById(id);
    if (training == null)
    {
      return NotFound();
    }
    return View(training);
  }

  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public IActionResult DeleteConfirmed(int id)
  {
    trainingService.DeleteTraining(id);
    return RedirectToAction(nameof(Index));
  }
}