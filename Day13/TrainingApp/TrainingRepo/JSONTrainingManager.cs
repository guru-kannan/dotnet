namespace TrainingRepo;

using TrainingEntities;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

public class JSONTrainingManager
{
  // private static string GetFilePath() => Path.Combine(Directory.GetCurrentDirectory(), "Trainings.json");
  private static string GetFilePath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Trainings.json");
  public static List<Training> LoadTrainings()
  {
    var filePath = GetFilePath();
    if (!File.Exists(filePath))
    {
      return new List<Training>();
    }
    var json = File.ReadAllText(filePath);
    return JsonSerializer.Deserialize<List<Training>>(json) ?? new List<Training>();
  }
  public static void SaveTrainings(List<Training> trainings)
  {
    var filePath = GetFilePath();
    var json = JsonSerializer.Serialize(trainings, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, json);
  }
}