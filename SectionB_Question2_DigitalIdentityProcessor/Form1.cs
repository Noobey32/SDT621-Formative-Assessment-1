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
                return;
            }

            // Validation: Citizenship selection is valid
            if (!citizenships.Contains(citizenship))
            {
                UpdateLabel("Invalid citizenship selection. Please select a valid option.", true);
                return;
            }

            CitizenProfile profile = new(fullName, id, citizenship);

            // Validation: ID is valid
            if (profile.Age == -1)
            {
                UpdateLabel("Invalid ID. Validate your ID before generating a profile.", true);
                return;
            }

            await ListOutput(profile);
        }

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
