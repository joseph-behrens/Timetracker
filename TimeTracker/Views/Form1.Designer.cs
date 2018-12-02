namespace TimeTracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonOpenAnother = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ProjectDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClientDropDown = new System.Windows.Forms.ComboBox();
            this.buttonMdown = new System.Windows.Forms.Button();
            this.buttonMup = new System.Windows.Forms.Button();
            this.buttonHdown = new System.Windows.Forms.Button();
            this.buttonHup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(424, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxTime.Location = new System.Drawing.Point(366, 14);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(53, 20);
            this.textBoxTime.TabIndex = 1;
            this.textBoxTime.Text = "00:00:00";
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Project";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.Location = new System.Drawing.Point(53, 70);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(301, 52);
            this.textBoxNotes.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Notes";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(365, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReport.Location = new System.Drawing.Point(366, 70);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(94, 23);
            this.buttonReport.TabIndex = 8;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonOpenAnother
            // 
            this.buttonOpenAnother.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenAnother.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOpenAnother.Location = new System.Drawing.Point(15, 92);
            this.buttonOpenAnother.Name = "buttonOpenAnother";
            this.buttonOpenAnother.Size = new System.Drawing.Size(29, 29);
            this.buttonOpenAnother.TabIndex = 13;
            this.buttonOpenAnother.Text = "+";
            this.buttonOpenAnother.UseVisualStyleBackColor = true;
            this.buttonOpenAnother.Click += new System.EventHandler(this.buttonOpenAnother_Click);
            // 
            // ProjectDropDown
            // 
            this.ProjectDropDown.FormattingEnabled = true;
            this.ProjectDropDown.Location = new System.Drawing.Point(53, 41);
            this.ProjectDropDown.Name = "ProjectDropDown";
            this.ProjectDropDown.Size = new System.Drawing.Size(301, 21);
            this.ProjectDropDown.TabIndex = 14;
            this.ProjectDropDown.SelectedIndexChanged += new System.EventHandler(this.ProjectDropDown_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Client";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ClientDropDown
            // 
            this.ClientDropDown.FormattingEnabled = true;
            this.ClientDropDown.Location = new System.Drawing.Point(53, 14);
            this.ClientDropDown.Name = "ClientDropDown";
            this.ClientDropDown.Size = new System.Drawing.Size(301, 21);
            this.ClientDropDown.TabIndex = 16;
            this.ClientDropDown.SelectedIndexChanged += new System.EventHandler(this.ClientDropDown_SelectedIndexChanged);
            // 
            // buttonMdown
            // 
            this.buttonMdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMdown.Image = global::TimeTracker.Properties.Resources.go_down;
            this.buttonMdown.Location = new System.Drawing.Point(441, 41);
            this.buttonMdown.Name = "buttonMdown";
            this.buttonMdown.Size = new System.Drawing.Size(19, 23);
            this.buttonMdown.TabIndex = 12;
            this.buttonMdown.UseVisualStyleBackColor = true;
            this.buttonMdown.Click += new System.EventHandler(this.buttonMdown_Click);
            // 
            // buttonMup
            // 
            this.buttonMup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMup.Image = global::TimeTracker.Properties.Resources.go_up;
            this.buttonMup.Location = new System.Drawing.Point(416, 41);
            this.buttonMup.Name = "buttonMup";
            this.buttonMup.Size = new System.Drawing.Size(19, 23);
            this.buttonMup.TabIndex = 11;
            this.buttonMup.UseVisualStyleBackColor = true;
            this.buttonMup.Click += new System.EventHandler(this.buttonMup_Click);
            // 
            // buttonHdown
            // 
            this.buttonHdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHdown.Image = global::TimeTracker.Properties.Resources.go_down;
            this.buttonHdown.Location = new System.Drawing.Point(391, 41);
            this.buttonHdown.Name = "buttonHdown";
            this.buttonHdown.Size = new System.Drawing.Size(19, 23);
            this.buttonHdown.TabIndex = 10;
            this.buttonHdown.UseVisualStyleBackColor = true;
            this.buttonHdown.Click += new System.EventHandler(this.buttonHdown_Click);
            // 
            // buttonHup
            // 
            this.buttonHup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHup.Image = global::TimeTracker.Properties.Resources.go_up;
            this.buttonHup.Location = new System.Drawing.Point(366, 41);
            this.buttonHup.Name = "buttonHup";
            this.buttonHup.Size = new System.Drawing.Size(19, 23);
            this.buttonHup.TabIndex = 9;
            this.buttonHup.UseVisualStyleBackColor = true;
            this.buttonHup.Click += new System.EventHandler(this.buttonHup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 132);
            this.Controls.Add(this.ClientDropDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProjectDropDown);
            this.Controls.Add(this.buttonOpenAnother);
            this.Controls.Add(this.buttonMdown);
            this.Controls.Add(this.buttonMup);
            this.Controls.Add(this.buttonHdown);
            this.Controls.Add(this.buttonHup);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time Tracker";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonHup;
        private System.Windows.Forms.Button buttonHdown;
        private System.Windows.Forms.Button buttonMup;
        private System.Windows.Forms.Button buttonMdown;
        private System.Windows.Forms.Button buttonOpenAnother;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox ProjectDropDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ClientDropDown;
    }
}

