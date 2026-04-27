using String = System.String;

namespace SectionB_Question2_DigitalIdentityProcessor
{
    public partial class Form1 : Form
    {
        string[] citizenships = { "Citizen", "Permanent Resident", "Visitor" };

        public Form1()
        {
            InitializeComponent();
            cmbCitizenship.Items.AddRange(citizenships);
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            string idNumber = txtId.Text;
            UpdateLabel(ValidateID(idNumber).message, true);
        }

        private async void btnGenerateProfile_Click(object sender, EventArgs e)
        {
            string fullName = txtName.Text, id = txtId.Text, citizenship = cmbCitizenship.Text;

            // Validation: All fields are filled
            if (String.IsNullOrWhiteSpace(fullName) || String.IsNullOrWhiteSpace(id) || String.IsNullOrWhiteSpace(citizenship)) {
                UpdateLabel("Please fill in all fields.", true);
                txtName.Focus();
                return;
            }

            // Validation: Citizenship selection is valid
            if (!citizenships.Contains(citizenship))
            {
                UpdateLabel("Invalid citizenship selection. Please select a valid option.", true);
                cmbCitizenship.Focus();
                return;
            }

            CitizenProfile profile = new(fullName, id, citizenship);

            // Validation: ID is valid
            if (profile.Age == -1)
            {
                UpdateLabel("Invalid ID. Validate your ID before generating a profile.", true);
                txtId.Focus();
                return;
            }

            await ListOutput(profile);
        }

        // used when button 'Validate ID' is clicked
        private static (string message, bool isValid) ValidateID(string userId)
        {
            string id = userId.Trim();

            // Check length
            if (id.Length != 13)
                return ("Invalid ID: ID number must be 13 characters long.", false);

            // Check if numeric
            foreach (char c in id)
                if (!char.IsDigit(c))
                    return ("Invalid ID: ID number must contain only numeric characters.", false);

            // Validate month and day using the 3rd to 6th numbers of the ID
            int idMonth = int.Parse(id.Substring(2, 2));
            int idDay = int.Parse(id.Substring(4, 2));

            if (idMonth > 12 || idMonth < 1)
                return ("Invalid ID: Month value (3rd and 4th digit) is invalid.", false);
            else if (idDay > 31 || idDay < 1)
                return ("Invalid ID: Day value (5th and 6th digit) is invalid.", false);

            switch (idMonth)
            {
                case 2 when idDay > 29:
                case 4 or 6 or 9 or 11 when idDay > 30:
                    return ("Invalid ID: Day value (5th and 6th digit) is invalid for the specified month.", false);
            }

            // Validation passed; ID is valid
            // Determine age and return valid message
            int age = DetermineAge(id);
            return ($"ID is valid. Age: {age}", true);
        }

        // Determines the user's age using the first 6 numbers of a valid ID
        private static int DetermineAge(string validId)
        {
            // YEAR

            int currentYear = DateTime.Now.Year;
            const int currentYearShortened = 26;

            // This funtion is called after validating id; a check is not required
            int birthYearShortened = int.Parse(validId.Substring(0, 2));

            int birthYear = birthYearShortened switch
            {
                <= currentYearShortened => 2000 + birthYearShortened,
                _ => 1900 + birthYearShortened
            };

            int age = currentYear - birthYear;

            // MONTH + DAY

            int currentMonthDay = int.Parse(DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2"));
            int userMonthDay = int.Parse(validId.Substring(2, 4));

            // If the user's month and day have not yet occurred this year, subtract 1 from the age
            if (userMonthDay > currentMonthDay)
                age--;

            if (age < 0)
                return 99; // Edge-case

            return age;
        }

        private async Task ListOutput(CitizenProfile profile)
        {
            DisableButtons();
            UpdateLabel("Generating profile...", true);
            string[] outputs = {
                "=== DIGITAL CITIZEN SUMMARY ===",
                $"Full name: {profile.FullName}",
                $"ID Number: {profile.ID}",
                $"Age: {profile.Age}",
                $"Citizenship: {profile.Citizenship}",
                "Validation: ID is valid",
                "Processed at: Home Affairs Digital Desk",
                $"Timestamp: {DateTime.Now}"
            };

            lbxOutput.Items.Clear(); // Clear previous outputs before adding new ones
            foreach (string output in outputs)
            {
                // Wait for 0.3 seconds before adding the next output for better UX
                lbxOutput.Items.Add(output);
                await Task.Delay(300);
            }

            // Clean up after output is generated
            ClearFocusInputs();
            EnableButtons();
        }

        private void UpdateLabel(string message, bool isVisible)
        {
            lblValidOutput.Text = message;
            lblValidOutput.Visible = isVisible; // Allows for more dynamic uses
        }

        private void EnableButtons()
        {
            btnValidate.Enabled = true;
            btnGenerateProfile.Enabled = true;
        }

        private void DisableButtons()
        {
            btnValidate.Enabled = false;
            btnGenerateProfile.Enabled = false;
        }

        private void ClearFocusInputs()
        {
            UpdateLabel("", false);
            txtId.Clear();
            txtName.Clear();
            txtName.Focus();
            cmbCitizenship.SelectedIndex = -1;
        }
    }
}
