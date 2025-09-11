namespace TrainingServices;

using TrainingEntities;
using TrainingRepo;
using System.Collections.Generic;

public class TrainingServices : ITrainingService
{

  private readonly ITrainingRepo trainingRepo;

  public TrainingServices(ITrainingRepo trainingRepo)
  {
    this.trainingRepo = trainingRepo;
  }

  public IEnumerable<Training>? GetAllTrainings()
  {
    return trainingRepo.GetAllTrainings();
  }

  public Training? GetTrainingById(int id)
  {
    return trainingRepo.GetTrainingById(id);
  }

  public void AddTraining(Training training)
  {
    trainingRepo.AddTraining(training);
  }

  public void UpdateTraining(Training training)
  {
    trainingRepo.UpdateTraining(training);
  }

  public void DeleteTraining(int id)
  {
    trainingRepo.DeleteTraining(id);
  }
}
