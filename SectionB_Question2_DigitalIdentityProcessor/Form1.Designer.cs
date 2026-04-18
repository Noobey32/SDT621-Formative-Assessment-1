namespace SectionB_Question2_DigitalIdentityProcessor
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
            label1 = new Label();
            txtName = new TextBox();
            txtId = new TextBox();
            cmbCitizenship = new ComboBox();
            btnValidate = new Button();
            btnGenerateProfile = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lbxOutput = new ListBox();
            lblValidOutput = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(180, 50);
            label1.Name = "label1";
            label1.Size = new Size(463, 32);
            label1.TabIndex = 5;
            label1.Text = "Home Affairs Digital Identity Processor";
            // 
            // txtName
            // 
            txtName.Location = new Point(215, 170);
            txtName.Name = "txtName";
            txtName.Size = new Size(188, 23);
            txtName.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(215, 199);
            txtId.Name = "txtId";
            txtId.Size = new Size(188, 23);
            txtId.TabIndex = 1;
            txtId.TextChanged += textBox2_TextChanged;
            // 
            // cmbCitizenship
            // 
            cmbCitizenship.FormattingEnabled = true;
            cmbCitizenship.Location = new Point(215, 228);
            cmbCitizenship.Name = "cmbCitizenship";
            cmbCitizenship.Size = new Size(188, 23);
            cmbCitizenship.TabIndex = 2;
            // 
            // btnValidate
            // 
            btnValidate.Location = new Point(215, 277);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(76, 23);
            btnValidate.TabIndex = 3;
            btnValidate.Text = "Validate ID";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += btnValidate_Click;
            // 
            // btnGenerateProfile
            // 
            btnGenerateProfile.Location = new Point(297, 277);
            btnGenerateProfile.Name = "btnGenerateProfile";
            btnGenerateProfile.Size = new Size(106, 23);
            btnGenerateProfile.TabIndex = 4;
            btnGenerateProfile.Text = "Generate Profile";
            btnGenerateProfile.UseVisualStyleBackColor = true;
            btnGenerateProfile.Click += btnGenerateProfile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 173);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 6;
            label2.Text = "Full Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(141, 202);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 7;
            label3.Text = "ID Number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(141, 231);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 8;
            label4.Text = "Citizenship:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(141, 134);
            label5.Name = "label5";
            label5.Size = new Size(264, 19);
            label5.TabIndex = 9;
            label5.Text = "Complete this form with your information";
            // 
            // lbxOutput
            // 
            lbxOutput.FormattingEnabled = true;
            lbxOutput.Location = new Point(471, 134);
            lbxOutput.Name = "lbxOutput";
            lbxOutput.Size = new Size(220, 154);
            lbxOutput.TabIndex = 10;
            // 
            // lblValidOutput
            // 
            lblValidOutput.AutoSize = true;
            lblValidOutput.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblValidOutput.Location = new Point(215, 313);
            lblValidOutput.Name = "lblValidOutput";
            lblValidOutput.Size = new Size(61, 15);
            lblValidOutput.TabIndex = 11;
            lblValidOutput.Text = "ID validity";
            lblValidOutput.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 452);
            Controls.Add(lblValidOutput);
            Controls.Add(lbxOutput);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnGenerateProfile);
            Controls.Add(btnValidate);
            Controls.Add(cmbCitizenship);
            Controls.Add(txtId);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private TextBox txtId;
        private ComboBox cmbCitizenship;
        private Button btnValidate;
        private Button btnGenerateProfile;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListBox lbxOutput;
        private Label lblValidOutput;
    }
}
