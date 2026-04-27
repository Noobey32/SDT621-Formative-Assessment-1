using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public int Age { get; } = ValidateID(id) ? DetermineAge(id) : -1;

        
        private static bool ValidateID(string id)
        {
            id = id.Trim();

            // Check length
            if (id.Length != 13) 
                return false;

            // Check if numeric
            foreach (char c in id)
                if (!char.IsDigit(c))
                    return false;

            // Validate month and day using the 3rd to 6th numbers of the ID
            int idMonth = int.Parse(id.Substring(2, 2));
            int idDay = int.Parse(id.Substring(4, 2));

            if (idMonth > 12 || idMonth < 1) 
                return false;
            else if (idDay > 31 || idDay < 1) 
                return false;

            switch (idMonth)
            {
                case 2 when idDay > 29:
                    return false;
                case 4 or 6 or 9 or 11 when idDay > 30:
                    return false;
            }

            // Validation passed; ID is valid
            return true;
        }

        // This function is called is ValidateID() is true; a check is not required
        // Determines the user's age using the first 6 numbers of the ID
        private static int DetermineAge(string id)
        {
            id = id.Trim();

            // YEAR

            int currentYear = DateTime.Now.Year;
            const int currentYearShortened = 26;

            // This funtion is called after validating id; a check is not required
            int birthYearShortened = int.Parse(id.Substring(0, 2));

            int birthYear = birthYearShortened switch
            {
                <= currentYearShortened => 2000 + birthYearShortened,
                _ => 1900 + birthYearShortened
            };

            int age = currentYear - birthYear;

            // MONTH + DAY

            int currentMonthDay = int.Parse(DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2"));
            int userMonthDay = int.Parse(id.Substring(2, 4));

            // If the user's month and day have not yet occurred this year, subtract 1 from the age
            if (userMonthDay > currentMonthDay)
                age--;

            if (age < 0)
                return 99; // Edge-case
            
            return age;
        }
    }
}