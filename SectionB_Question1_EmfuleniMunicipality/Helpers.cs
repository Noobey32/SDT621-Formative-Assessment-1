using System;
using System.Collections.Generic;
using System.Text;

namespace SectionB_Question1_EmfuleniMunicipality
{
    internal class Helpers
    {
        public int GetValidInt(string prompt, int min = 1, int? max = null)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min)
                {
                    if (max == null || result <= max) return result;

                    Console.WriteLine($"Input must be between {min} and {max}. Please enter a valid integer.");
                    continue;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        public string GetStringValue(string prompt)
        {
            Console.WriteLine(prompt);
            string value = Console.ReadLine(); // do not call GetStringValue() here -- results in infinite loop

            if (String.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Input cannot be empty. Please enter a valid value.");
                return GetStringValue(prompt); // Recursively prompt until a valid input is received
            }
            return value;
        }
    }
}
