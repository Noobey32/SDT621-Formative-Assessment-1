/*
============================================================
Project: SDT621 – Formative Assessment 1
Section : A
Question: 1 – Student Results Console Application

Overview:
This console application prompts the user to enter a student
name and three subject marks. It validates numeric input,
calculates the total and average marks, and determines whether
the student has passed or failed based on the average result.

Key Requirements Implemented:
- User input prompts for name and marks
- Numeric input validation for marks
- Total and average mark calculations
- PASS / FAIL decision logic (average >= 50)
- Structured console output formatting

Expected Outcomes:
- Correct handling of invalid inputs
- Accurate calculation logic
- Clear and readable console interaction

Notes:
- Entry point for the Student Results application
- Designed to match the assessment screenshot requirements
============================================================
*/

class Program
{
    static void Main(string[] args)
    {
        // gathering user inputs
        Console.Write("Enter student name: ");
        string studentName = Console.ReadLine();

        const int NUMBER_OF_SUBJECTS = 3; // constant for number of subjects
        int totalStudentMarks = 0; // used for averge later

        for (int i = 0; i < NUMBER_OF_SUBJECTS; i++)
        {
            Console.Write($"Enter mark for subject {i + 1}: ");
            string input = Console.ReadLine();
            int mark;

            // validation
            while (!int.TryParse(input, out mark) || mark < 0 || mark > 100)
            {
                Console.Write("Invalid input. Please enter a valid mark (0-100): ");
                input = Console.ReadLine();
            }
            totalStudentMarks += mark;
        }

        // calculations
        double averageMarks = (double)totalStudentMarks / NUMBER_OF_SUBJECTS;
        string result = averageMarks >= 50 ? "PASS" : "FAIL";

        // output
        Console.WriteLine("\n===== Student Results =====");
        Console.WriteLine($"Student Name: {studentName}");
        Console.WriteLine($"Total Marks: {totalStudentMarks}");
        Console.WriteLine($"Average Marks: {averageMarks:F2}");
        Console.WriteLine($"Result: {result}");
        Console.WriteLine("Result issued at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
