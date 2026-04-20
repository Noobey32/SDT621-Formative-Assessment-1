using System;
using System.Collections.Generic;
using System.Text;

namespace SectionB_Question1_EmfuleniMunicipality
{
    internal class Resident(string fullName, string addess, string accountNumber, int montlyUtilityUsage)
    {
        public string FullName { get; } = fullName;
        public string Address { get; } = addess;
        public string AccountNumber { get; } = accountNumber;
        public int MonthlyUtilityUsage { get; } = montlyUtilityUsage;
    }
}
