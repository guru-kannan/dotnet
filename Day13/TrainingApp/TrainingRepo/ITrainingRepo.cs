namespace TrainingRepo;

using TrainingEntities;
using System.Collections.Generic;
public interface ITrainingRepo
{
  IEnumerable<Training>? GetAllTrainings();
  Training? GetTrainingById(int id);
  void AddTraining(TrainingEntities.Training training);
  void UpdateTraining(TrainingEntities.Training training);
  void DeleteTraining(int id);
}
