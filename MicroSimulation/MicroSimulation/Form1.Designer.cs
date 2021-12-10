
namespace MicroSimulation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.PopulationFileNameTextBox = new System.Windows.Forms.TextBox();
            this.DisplayData_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Záróév";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(296, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Népesség fájl";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(616, 12);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(83, 20);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(705, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(83, 20);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PopulationFileNameTextBox
            // 
            this.PopulationFileNameTextBox.Location = new System.Drawing.Point(409, 12);
            this.PopulationFileNameTextBox.Name = "PopulationFileNameTextBox";
            this.PopulationFileNameTextBox.Size = new System.Drawing.Size(201, 20);
            this.PopulationFileNameTextBox.TabIndex = 6;
            // 
            // DisplayData_RichTextBox
            // 
            this.DisplayData_RichTextBox.Location = new System.Drawing.Point(12, 38);
            this.DisplayData_RichTextBox.Name = "DisplayData_RichTextBox";
            this.DisplayData_RichTextBox.Size = new System.Drawing.Size(776, 400);
            this.DisplayData_RichTextBox.TabIndex = 7;
            this.DisplayData_RichTextBox.Text = "";
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(78, 13);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(100, 20);
            this.YearTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.DisplayData_RichTextBox);
            this.Controls.Add(this.PopulationFileNameTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox PopulationFileNameTextBox;
        private System.Windows.Forms.RichTextBox DisplayData_RichTextBox;
        private System.Windows.Forms.TextBox YearTextBox;
    }
}

