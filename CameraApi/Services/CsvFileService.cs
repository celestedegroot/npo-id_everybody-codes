using System.Windows.Markup;
using CameraApi.Models;

namespace CameraApi.Services;

public static class CsvFileService
{
    static List<Camera> Cameras { get; }
    
    static CsvFileService()
    {
        Cameras = new List<Camera>{};

        string filePath = "../data/cameras-defb.csv";

        using (StreamReader reader = new StreamReader(filePath))
        {
            string headerLine = reader.ReadLine(); // Skip the first line of the csv file before the loop
            while (reader.ReadLine() is string line)
            {
                string[] values = line.Split(';');
                if (values.Length == 3) Cameras.Add(new Camera { Name = values[0], latitude = float.Parse(values[1]), longitude = float.Parse(values[2]) });
            }
        }
    }

    public static List<Camera> GetAll() => Cameras;
}