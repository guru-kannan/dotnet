namespace TrainingRepo;

using TrainingEntities;
using System.Collections.Generic;

public class TrainingRepo : ITrainingRepo
{
  private readonly List<Training> trainings = new();

  public IEnumerable<Training>? GetAllTrainings()
  {
    return JSONTrainingManager.LoadTrainings();
  }

  public Training GetTrainingById(int id)
  {
    IEnumerable<Training> allTrainings = GetAllTrainings();
    return allTrainings.FirstOrDefault(t => t.Id == id);
  }

  public void AddTraining(Training training)
  {
    List<Training> allTrainings = GetAllTrainings().ToList();
    allTrainings.Add(training);
    JSONTrainingManager.SaveTrainings(allTrainings);
  }

  public void UpdateTraining(Training training)
  {
    List<Training> allTrainings = GetAllTrainings().ToList();
    var existingTraining = allTrainings.FirstOrDefault(t => t.Id == training.Id);
    if (existingTraining != null)
    {
      existingTraining.Name = training.Name;
      existingTraining.Description = training.Description;
      existingTraining.StartDate = training.StartDate;
      existingTraining.EndDate = training.EndDate;
      existingTraining.Price = training.Price;
      JSONTrainingManager.SaveTrainings(allTrainings);
    }
  }

  public void DeleteTraining(int id)
  {
    List<Training> allTrainings = GetAllTrainings().ToList();
    var training = allTrainings.FirstOrDefault(t => t.Id == id);
    if (training != null)
    {
      trainings.Remove(training);
      JSONTrainingManager.SaveTrainings(allTrainings);
    }
  }
}