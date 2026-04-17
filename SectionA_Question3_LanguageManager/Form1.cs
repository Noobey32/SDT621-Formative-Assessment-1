/*
============================================================
Project: SDT621 – Formative Assessment 1
Section : A
Question: 3 – Programming Language Manager (Windows Forms)

Overview:
This Windows Forms application allows users to manage a list
of programming languages. Users can add and remove items from
the list while preventing empty or duplicate entries. The
application also records the date and time of additions.

Key Requirements Implemented:
- Windows Forms GUI with input controls
- Validation for empty and duplicate values
- Dynamic list management (add/remove)
- Timestamp display for language additions

Expected Outcomes:
- Functional event-driven programming
- Clear user feedback through the GUI
- Stable and predictable form behavior

Notes:
- Main form contains all event-handling logic
- Designed to closely match the expected output layout
============================================================
*/

namespace SectionA_Question3_LanguageManager
{
    public partial class Form1 : Form
    {
        // used to determine is btnRemoveLanguage should be enabled or not
        int languageCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddLeanguage_Click(object sender, EventArgs e)
        {
            // user input + validation
            string userInput = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) { 
                ShowWarning("Please enter a programming language.", 2000);
                return;
            }

            // check for duplicates
            bool isDuplicate = lbxLanguageList.Items.Contains(userInput);
            if (isDuplicate)
            {
                ShowWarning("This programming language is already in the list.", 2000);
                return;
            }

            // add to list and update count
            lbxLanguageList.Items.Add(userInput);
            languageCount++;
            btnRemoveLanguage.Enabled = true;
            UpdateLabel($"Added: '{userInput}' at {DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")}");
        }

        private void UpdateLabel(string content)
        {
            lblUpdate.Text = content;

            // invert visibility of labels
            lblUpdate.Visible = true;
            lblWarning.Visible = false;
        }

        private void ShowWarning(string content, int delay = 0)
        {
            lblWarning.Text = content;

            // invert visibility of labels
            lblUpdate.Visible = false;
            lblWarning.Visible = true;

            if (delay > 0)
            {
                var timer = new System.Windows.Forms.Timer
                {
                    Interval = delay
                };
                timer.Tick += (s, e) =>
                {
                    lblWarning.Visible = false;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }
    }
}
