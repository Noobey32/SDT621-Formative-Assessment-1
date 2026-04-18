using System;
using System.Collections.Generic;
using System.Text;

namespace SectionB_Question2_DigitalIdentityProcessor
{
    internal class CitizenProfile(string fullName, string id, string citizenship)
    {
        // { get; } Allows the variable to be set only in the constructor and not modified later
        public string FullName { get; } = fullName;
        public string ID { get; } = id;
        public string Citizenship { get; } = citizenship;

        // -1 indicates invalid ID; age is determined only if the ID is valid
        public int Age { get; } = ValidateID(id).isValid ? DetermineAge(id) : -1;

        private static (string message, bool isValid) ValidateID(string id)
        {
            id = id.Trim();
            // Check length
            if (id.Length != 13) return ("Invalid ID: ID number must be 13 characters long.", false);

            // Check if numeric
            if (!double.TryParse(id, out double numericId)) return ("Invalid ID: ID number must contain only numeric characters.", false);

            int age = DetermineAge(id);
            return ($"ID is valid. Age: {age}", true);
        }

        private static int DetermineAge(string id)
        {
            int currentYear = DateTime.Now.Year;
            const int currentYearShortened = 26;
            // int currentYearShortened = int.Parse(currentYear.ToString().Substring(2, 2)); // Dynamic version

            // This funtion is called after validating id; a check is not required
            int birthYearShortened = int.Parse(id.Substring(0, 2));

            int birthYear = birthYearShortened switch
            {
                <= currentYearShortened => 2000 + birthYearShortened,
                _ => 1900 + birthYearShortened
            };

            return currentYear - birthYear;
        }
    }
}