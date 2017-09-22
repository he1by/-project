namespace Data_base
{
    partial class FormChange
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
            this.labelEnterValue = new System.Windows.Forms.Label();
            this.richTextBoxValue = new System.Windows.Forms.RichTextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelEnterValue
            // 
            this.labelEnterValue.AutoSize = true;
            this.labelEnterValue.Location = new System.Drawing.Point(93, 75);
            this.labelEnterValue.Name = "labelEnterValue";
            this.labelEnterValue.Size = new System.Drawing.Size(125, 13);
            this.labelEnterValue.TabIndex = 0;
            this.labelEnterValue.Text = "Введите новые данные";
            // 
            // richTextBoxValue
            // 
            this.richTextBoxValue.Location = new System.Drawing.Point(23, 91);
            this.richTextBoxValue.Name = "richTextBoxValue";
            this.richTextBoxValue.Size = new System.Drawing.Size(260, 179);
            this.richTextBoxValue.TabIndex = 2;
            this.richTextBoxValue.Text = "";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(130, 289);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Далее";
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // FormChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 344);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.richTextBoxValue);
            this.Controls.Add(this.labelEnterValue);
            this.Name = "FormChange";
            this.Text = "База данных ЦКРОиР";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEnterValue;
        private System.Windows.Forms.RichTextBox richTextBoxValue;
        private System.Windows.Forms.Button buttonNext;
    }
}