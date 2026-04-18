// todo
// DetermineAge method
//   > Move to CitizenProfile class and make it public static
//   > Use month and day to determine exact age and not just year

namespace SectionB_Question2_DigitalIdentityProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            string idNumber = txtId.Text;
            var validCheck = ValidateID(idNumber);

            lblValidOutput.Text = validCheck.message;
            lblValidOutput.Visible = true;

            // todo? check user's age using a method from CitizenProfile class
        }

        private void btnGenerateProfile_Click(object sender, EventArgs e)
        {

        }

        private static (string message, bool isValid) ValidateID(string id)
        {
            id = id.Trim();
            // check length
            if (id.Length != 13) return ("Invalid ID: ID must be 13 characters long.", false);

            // check if numeric
            if (!double.TryParse(id, out double numericId)) return ("Invalid ID: ID must contain only numeric characters.", false);

            int age = DetermineAge(id);
            return ($"ID is valid. Age: {age}", true);
        }

        private static int DetermineAge(string id)
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
