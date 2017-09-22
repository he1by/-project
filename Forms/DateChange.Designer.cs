namespace Data_base
{
    partial class DateChange
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
            this.textBoxMounth = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxDay = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelMounth = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMounth
            // 
            this.textBoxMounth.Location = new System.Drawing.Point(179, 82);
            this.textBoxMounth.Name = "textBoxMounth";
            this.textBoxMounth.Size = new System.Drawing.Size(54, 20);
            this.textBoxMounth.TabIndex = 24;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(256, 82);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(69, 20);
            this.textBoxYear.TabIndex = 23;
            // 
            // textBoxDay
            // 
            this.textBoxDay.Location = new System.Drawing.Point(94, 82);
            this.textBoxDay.Name = "textBoxDay";
            this.textBoxDay.Size = new System.Drawing.Size(54, 20);
            this.textBoxDay.TabIndex = 22;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(267, 53);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(58, 13);
            this.labelYear.TabIndex = 21;
            this.labelYear.Text = "Год (2000)";
            // 
            // labelMounth
            // 
            this.labelMounth.AutoSize = true;
            this.labelMounth.Location = new System.Drawing.Point(176, 53);
            this.labelMounth.Name = "labelMounth";
            this.labelMounth.Size = new System.Drawing.Size(85, 13);
            this.labelMounth.TabIndex = 20;
            this.labelMounth.Text = "Месяц (01;02...)";
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(80, 53);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(90, 13);
            this.labelDay.TabIndex = 19;
            this.labelDay.Text = "Число (01;12;...) ";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(166, 140);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(67, 25);
            this.buttonNext.TabIndex = 25;
            this.buttonNext.Text = "Далее";
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // DateChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 187);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxMounth);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.textBoxDay);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelMounth);
            this.Controls.Add(this.labelDay);
            this.Name = "DateChange";
            this.Text = "DateChange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMounth;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxDay;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelMounth;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Button buttonNext;
    }
}