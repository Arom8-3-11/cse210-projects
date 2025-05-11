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
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    //save entry to file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    //load entry from file
    // this is the command that allows the file to be loaded from the file system
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[1], parts[2]);
                    entry._date = parts[0];
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}