using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;




    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
            _words.Add(new Word(word));
    }

    public void HideRandomWords(int numberToHide) //void
    {
        Random rand = new Random();
        // Get a list of indexes of words that are not hidden
        var visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                visibleIndexes.Add(i);
        }

        // Shuffle and hide up to numberToHide visible words
        int hideCount = Math.Min(numberToHide, visibleIndexes.Count);
        for (int i = 0; i < hideCount; i++)
        {
            int idx = rand.Next(visibleIndexes.Count);
            _words[visibleIndexes[idx]].Hide();
            visibleIndexes.RemoveAt(idx); // Remove so we don't pick the same word again
        }
        // Random rand = new Random();
        // var visibleIndexes = new List<int>();
        // for (int i = 0; i < numberToHide; i++)
        // {
        //     int idx = rand.Next(_words.Count);
        //     _words[idx].Hide();
        // }
    }


    public string GetDisplayText() //String
    {
        string referenceText = _reference.GetDisplayText();
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
            displayWords.Add(word.GetDisplayText());
        return $"{referenceText} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden() //Boolean
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }

    // to get the reference scripture to display at the end of the program
    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }

}