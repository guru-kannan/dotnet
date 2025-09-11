namespace TrainingServices;
using TrainingEntities;
using TrainingRepo;
using System.Collections.Generic;

public interface ITrainingService
{
  IEnumerable<Training>? GetAllTrainings();
  Training? GetTrainingById(int id);
  void AddTraining(TrainingEntities.Training training);
  void UpdateTraining(TrainingEntities.Training training);
  void DeleteTraining(int id);
}