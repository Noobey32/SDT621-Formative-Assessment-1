namespace SectionA_Question3_LanguageManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInput = new TextBox();
            btnAddLeanguage = new Button();
            lbxLanguageList = new ListBox();
            label1 = new Label();
            lblUpdate = new Label();
            btnRemoveLanguage = new Button();
            lblWarning = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Font = new Font("Segoe UI", 10F);
            txtInput.Location = new Point(166, 233);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Enter Programming Language";
            txtInput.Size = new Size(447, 25);
            txtInput.TabIndex = 0;
            // 
            // btnAddLeanguage
            // 
            btnAddLeanguage.Font = new Font("Segoe UI", 10F);
            btnAddLeanguage.ForeColor = SystemColors.WindowText;
            btnAddLeanguage.Location = new Point(166, 264);
            btnAddLeanguage.Name = "btnAddLeanguage";
            btnAddLeanguage.Size = new Size(109, 35);
            btnAddLeanguage.TabIndex = 1;
            btnAddLeanguage.Text = "Add Language";
            btnAddLeanguage.UseVisualStyleBackColor = true;
            btnAddLeanguage.Click += btnAddLeanguage_Click;
            // 
            // lbxLanguageList
            // 
            lbxLanguageList.Font = new Font("Segoe UI", 12F);
            lbxLanguageList.FormattingEnabled = true;
            lbxLanguageList.Location = new Point(166, 64);
            lbxLanguageList.Name = "lbxLanguageList";
            lbxLanguageList.Size = new Size(447, 151);
            lbxLanguageList.TabIndex = 5;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.Location = new Point(166, 24);
            label1.Name = "label1";
            label1.Size = new Size(447, 32);
            label1.TabIndex = 3;
            label1.Text = "My Favourite Programming Languages";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUpdate
            // 
            lblUpdate.AutoSize = true;
            lblUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblUpdate.Location = new Point(166, 314);
            lblUpdate.Name = "lblUpdate";
            lblUpdate.Size = new Size(129, 15);
            lblUpdate.TabIndex = 4;
            lblUpdate.Text = "Removed 'XXX' at 'YYY'";
            lblUpdate.Visible = false;
            // 
            // btnRemoveLanguage
            // 
            btnRemoveLanguage.Enabled = false;
            btnRemoveLanguage.Font = new Font("Segoe UI", 10F);
            btnRemoveLanguage.Location = new Point(281, 264);
            btnRemoveLanguage.Name = "btnRemoveLanguage";
            btnRemoveLanguage.Size = new Size(109, 35);
            btnRemoveLanguage.TabIndex = 2;
            btnRemoveLanguage.Text = "Remove";
            btnRemoveLanguage.UseVisualStyleBackColor = true;
            btnRemoveLanguage.Click += btnRemoveLanguage_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblWarning.Location = new Point(166, 314);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(53, 15);
            lblWarning.TabIndex = 6;
            lblWarning.Text = "Warning";
            lblWarning.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWarning);
            Controls.Add(btnRemoveLanguage);
            Controls.Add(lblUpdate);
            Controls.Add(label1);
            Controls.Add(lbxLanguageList);
            Controls.Add(btnAddLeanguage);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnAddLeanguage;
        private ListBox lbxLanguageList;
        private Label label1;
        private Label lblUpdate;
        private Button btnRemoveLanguage;
        private Label lblWarning;
    }
}
