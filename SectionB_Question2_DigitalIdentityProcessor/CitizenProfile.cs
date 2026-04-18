using System;
using System.Collections.Generic;
using System.Text;

namespace SectionB_Question2_DigitalIdentityProcessor
{
    internal class CitizenProfile
    {
        // { get; } allows the variable to be set only in the constructor and not modified later
        public string FullName { get; }
        public string ID { get; }
        public string Citizenship { get; }
        public int Age { get; }

        public CitizenProfile(string fullName, string id, string citizenship)
        {
            FullName = fullName;
            ID = id;
            Citizenship = citizenship;
            Age = DetermineAge(id);
        }

        public static int DetermineAge(string id)
        {
            int currentYear = DateTime.Now.Year;
            const int currentYearShortened = 26;
            // int currentYearShortened = int.Parse(currentYear.ToString().Substring(2, 2)); // dynamic version

            // this funtion is called after validating id; a check is not required
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