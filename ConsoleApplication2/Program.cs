using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    internal class Program
    {
        private static void ExcuteOption(Option option)
        {
            option.DoThat?.Invoke();
        }


        private static Option GetValidOption(IEnumerable<Option> options)
        {
            while (true)
            {
                var input = Console.ReadLine();
                int idx;
                var success = int.TryParse(input, out idx);
                if (success && idx >= 1 && idx <= options.Count())
                {
                    var option = options.ToList()[idx - 1];
                    return option;
                }
                Console.WriteLine("Not valid option");
            }
        }

        private static void ShowSummaryOptions(IEnumerable<Option> options)
        {
            var summaryOptions = options.Select(x => x.Text);

            var i = 1;
            foreach (var text in summaryOptions)
            {
                Console.WriteLine($"{i}. {text}");
                i++;
            }
        }

        public static void DisplayMenu(IEnumerable<Option> options)
        {
            ShowSummaryOptions(options);
            var option = GetValidOption(options);
            ExcuteOption(option);
        }

        private static void PrintHalloWelt()
        {
            Console.WriteLine("Hello Welt");
        }

        public static void DisplayMenu(params Option[] options)
        {
            ShowSummaryOptions(options);
            var option = GetValidOption(options);
            ExcuteOption(option);
        }





        private static void Main(string[] args)
        {
            DisplayMenu(
                new Option("Print Hello Welt", PrintHalloWelt),
                new Option("Print Hello Fritz", () => Console.WriteLine("Hello Fritz")),
                new Option("Print Hello Franz", () => Console.WriteLine("Hello Franz")),
                new Option("Print Test", null));

                
            Console.ReadLine(); // keeps cmd open
        }


    }

    internal class Option
    {
        public string Text { get; set; }
        public Action DoThat { get; set; }

        public Option(string text, Action doThat)
        {
            Text = text;
            DoThat = doThat;
        }
    }
}