using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    //new entry
    public void AddEntry(string prompt, string response)
    {
        Entry newEntry = new Entry(prompt, response);
        _entries.Add(newEntry);
    }

    //display entry
    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to display.");
            return;
        }
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    //save entry to file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename, append: true))
        {
            foreach (Entry entry in _entries)
            {
                string date = entry._date.Replace("\"", "\"\"");
                string prompt = entry._prompt.Replace("\"", "\"\"");
                string response = entry._response.Replace("\"", "\"\"");

                writer.WriteLine($"\"{date}\",\"{prompt}\",\"{response}\"");
            }
        }
        Console.WriteLine("Journal saved successfully.");
        Console.WriteLine("");
    }

    //load entry from file
    // this is the command that allows the file to be loaded from the file system
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = ParseCsvLine(line);

                if (parts.Length == 3)
                {
                    string date = parts[0].Trim('"').Replace("\"\"", "\"");
                    string prompt = parts[1].Trim('"').Replace("\"\"", "\"");
                    string response = parts[2].Trim('"').Replace("\"\"", "\"");

                    Entry entry = new Entry(prompt, response);
                    entry._date = date;
                    _entries.Add(entry);
                }
            }
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("");
            Console.WriteLine("Journal loaded successfully.");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine($"File {filename} not found.");
        }
    }
    
    private string[] ParseCsvLine(string line)
    {
        var result = new List<string>();
        bool inQuotes = false;
        string current = "";
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    current += '\"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }
        result.Add(current);
        return result.ToArray();
    }
}