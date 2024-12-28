namespace DefaultNamespace;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileManager
{
    private readonly string _filePath;

    public FileManager(string filePath)
    {
        _filePath = filePath;
    }

    
    public void SaveToFile<T>(List<T> data)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonString);
            Console.WriteLine("Datele au fost salvate cu succes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la salvarea fisierului: {ex.Message}");
        }
    }

    public List<T> LoadFromFile<T>()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Fisierul nu exista. Se va returna o lista goala.");
                return new List<T>();
            }

            string jsonString = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea fisierului: {ex.Message}");
            return new List<T>();
        }
    }
    
    //SA FAC IN PROGRAM FISIERE PT FIECARE
}
