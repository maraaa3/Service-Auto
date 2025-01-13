namespace DefaultNamespace;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;


public class FileManager
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileManager(string filePath)
    {
        _filePath = filePath;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers =
                    {
                        p =>
                        {
                            if(p.Type == typeof(Utilizator))
                            {
                                p.PolymorphismOptions = new JsonPolymorphismOptions
                                {
                                    TypeDiscriminatorPropertyName = "$type",
                                    DerivedTypes =
                                    {
                                        new JsonDerivedType(typeof(Administrator), "administrator"),
                                        new JsonDerivedType(typeof(Mecanic), "mecanic")
                                    }
                                };
                            }
                        }
                        }
            }
        };
    }

    
    public void SaveToFile<T>(List<T> data)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(data, _jsonSerializerOptions);
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
           return JsonSerializer.Deserialize<List<T>>(jsonString, _jsonSerializerOptions) ?? new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea fisierului: {ex.Message}");
            return new List<T>();
        }
    }

}
