using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace strings;

public class TextProcessor
{
    string Value;

    public TextProcessor(string text)
    {
        Value = text;
    }

    public string GetWordsWithDigits()
    {
        char[] sentenceEndings = { '.', '!', '?' };
        string[] sentences = Value.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries);
        var wordWithMaxDigitsCount = "";
        var maxDigitCount = 0;


        Dictionary<int, string> wordsWithDigitsDictionary = new Dictionary<int, string>();

        Regex regex = new Regex(@"\w*\d\w*");
        var sb = new StringBuilder();
        var io = 0;
        foreach (string sentence in sentences)
        {
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                if (regex.IsMatch(word))
                {
                    if (word.Contains(','))
                    {
                        wordsWithDigitsDictionary.Add(io, word.Remove(word.Length - 1));
                    }
                    else
                    {
                        wordsWithDigitsDictionary.Add(io, word);
                    }
                    io++;
                }
            }
        }
        IllegalDictionary[] ololo = new IllegalDictionary[wordsWithDigitsDictionary.Count - 1];

        for (int i = 0; i < wordsWithDigitsDictionary.Count-1; i++)
        {
            var word = wordsWithDigitsDictionary[i];
            var digitsCount = 0;
            foreach (var x in word)
            {
                if (Char.IsDigit(x))
                {
                    digitsCount++;
                }
            }
            ololo[i] = new IllegalDictionary(i, digitsCount, word);
        }

        foreach (var x in ololo)
        {
            if (x.DigitsCount > maxDigitCount)
            {
                maxDigitCount = x.DigitsCount;
                wordWithMaxDigitsCount = x.Value;
            }
            else if (x.DigitsCount == maxDigitCount)
            {
                sb.Append(x.Value + "\n");
            }
        }

        return sb.Append(wordWithMaxDigitsCount + "\n").ToString();
    }

    public string GetLongestWord()
    {
        char[] sentenceEndings = { '.', '!', '?' };
        string[] sentences = Value.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries);
        string longestWord = "";

        foreach (string sentence in sentences)
        {
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
        }

        if (longestWord.Contains(','))
        {
            longestWord = longestWord.Remove(longestWord.Length - 1);
        }

        return longestWord;
    }

    public string GetTextWithReplacedDigits()
    {
        var sb = new StringBuilder();
        var numbers = new[] { "ZERO", "ONE", "TWO", "THREE", "FORE", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };

        for (int i = 0; i < Value.Length; i++)
            if (char.IsDigit(Value[i]))
                sb.Append(numbers[Value[i] - '0']);
            else
                sb.Append(Value[i]);

        return sb.ToString();
    }

    public string GetInterrogativeSentences()
    {
        var sb = new StringBuilder();
        var pattern = @"[^\.\?\!][\w + \,]+\?";
        var matches = Regex.Matches(Value, pattern);
        foreach (Match item in matches)
        {
            sb.Append(item.ToString().TrimStart() + "\n");
        }

        return sb.ToString();
    }

    public string GetExclamationSentences()
    {
        var sb = new StringBuilder();
        var pattern = @"[^\.\?\!][\w + \,]+\!";
        var matches = Regex.Matches(Value, pattern);
        foreach (Match item in matches)
        {
            sb.Append(item.ToString().TrimStart() + "\n");
        }

        return sb.ToString();
    }

    public string GetTextWithCommas()
    {
        var sb = new StringBuilder();
        var pattern = @"[^.!?]+,[^.!?\n]*[.!?]";
        var matches = Regex.Matches(Value, pattern);
        foreach (Match item in matches)
        {
            sb.Append(item.ToString().TrimStart() + "\n");
        }

        return sb.ToString();
    }

    public string GetWordsWithSameFirstAndLastLetters()
    {
        var sb = new StringBuilder();
        foreach (Match match in Regex.Matches(Value, @"\b([A-zА-яЁё])[A-zА-яЁё]+?\1\b"))
            sb.Append(match.Value + "\n");
        return sb.ToString();
    }

}