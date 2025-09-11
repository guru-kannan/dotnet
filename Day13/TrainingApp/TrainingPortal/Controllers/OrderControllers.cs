namespace TrainingPortal.Controllers;
using Microsoft.AspNetCore.Mvc;
using TrainingEntities;
using TrainingServices;
using System.Collections.Generic;

public class OrderControllers : Controller
{
  private readonly ITrainingService trainingService;

  public OrderControllers(ITrainingService trainingService)
  {
    this.trainingService = trainingService;
  }

  public IActionResult Index()
  {
    IEnumerable<Training>? trainings = trainingService.GetAllTrainings();
    return View(trainings);
  }
}