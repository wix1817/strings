using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace strings
{
    class ConsoleMenu
    {
        public static void Run()
        {
            DataProvider provider = new DataProvider();
            TextProcessor data = new TextProcessor(provider.GetData(FileListMenu()));

            var isTryAgain = false;

            do
            {

                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select[green]option[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal option)[/]")
                        .AddChoices(new[]
                        {
                            "1: Print biggest words with digits",
                            "2: Print longest word",
                            "3: Print text with replaced digits",
                            "4: Print interrogative and exclamation sentences",
                            "5: Print text with commas",
                            "6: Print words with the same first and last letters",
                            "7: Try all functions",
                            "0: Exit"
                        }));

                switch (option.First())
                {
                    case '1':
                    {
                        AnsiConsole.WriteLine(data.GetWordsWithDigits());
                        break;
                    }
                    case '2':
                    {
                        AnsiConsole.WriteLine(data.GetLongestWord());
                        break;
                    }
                    case '3':
                    {
                        AnsiConsole.WriteLine(data.GetTextWithReplacedDigits());
                        break;
                    }
                    case '4':
                    {
                        AnsiConsole.WriteLine(data.GetInterrogativeSentences());
                        AnsiConsole.WriteLine(data.GetExclamationSentences());
                        break;
                    }
                    case '5':
                    {
                        AnsiConsole.WriteLine(data.GetTextWithCommas());
                        break;
                    }
                    case '6':
                    {
                        AnsiConsole.WriteLine(data.GetWordsWithSameFirstAndLastLetters());
                        break;
                    }
                    case '7':
                    {
                        TryAllFunction(data);
                        break;
                    }
                    case '0':
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
                if (!AnsiConsole.Confirm("[green]Want to do something else? [/]"))
                {
                    AnsiConsole.MarkupLine("Ok... :(");
                    isTryAgain = false;
                }
                else isTryAgain = true;
            } while (isTryAgain);
        }

        static string FileListMenu()
        {
            var filePath = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [green]txt file[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to select file)[/]")
                    .AddChoices(DataProvider.OutputOfExistingFiles()));

            return filePath;
        }

        static void TryAllFunction(TextProcessor data)
        {
            AnsiConsole.WriteLine(data.GetWordsWithDigits());
            AnsiConsole.WriteLine(data.GetLongestWord());
            AnsiConsole.WriteLine(data.GetTextWithReplacedDigits());
            AnsiConsole.WriteLine(data.GetInterrogativeSentences());
            AnsiConsole.WriteLine(data.GetExclamationSentences());
            AnsiConsole.WriteLine(data.GetTextWithCommas());
            AnsiConsole.WriteLine(data.GetWordsWithSameFirstAndLastLetters());
        }

    }
}
