namespace Rabin_School
{
    partial class choose_students
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
            this.students_checkbox = new System.Windows.Forms.CheckedListBox();
            this.confirm_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "בחירת התלמידים להגשת המטלה";
            // 
            // students_checkbox
            // 
            this.students_checkbox.FormattingEnabled = true;
            this.students_checkbox.Location = new System.Drawing.Point(241, 92);
            this.students_checkbox.Name = "students_checkbox";
            this.students_checkbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.students_checkbox.Size = new System.Drawing.Size(519, 319);
            this.students_checkbox.TabIndex = 1;
            // 
            // confirm_button
            // 
            this.confirm_button.BackgroundImage = global::Rabin_School.Properties.Resources.אשר;
            this.confirm_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.confirm_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.confirm_button.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.confirm_button.Location = new System.Drawing.Point(122, 379);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(99, 46);
            this.confirm_button.TabIndex = 2;
            this.confirm_button.UseVisualStyleBackColor = true;
            this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
            // 
            // back_button
            // 
            this.back_button.BackgroundImage = global::Rabin_School.Properties.Resources.חזור_חדש;
            this.back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back_button.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.back_button.Location = new System.Drawing.Point(12, 379);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(104, 46);
            this.back_button.TabIndex = 3;
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // choose_students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.confirm_button);
            this.Controls.Add(this.students_checkbox);
            this.Controls.Add(this.label1);
            this.Name = "choose_students";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox students_checkbox;
        private System.Windows.Forms.Button confirm_button;
        private System.Windows.Forms.Button back_button;
    }
}