namespace Rabin_School
{
    partial class voucher_secretary
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
            this.student_voucher = new System.Windows.Forms.Button();
            this.all_students_voucher = new System.Windows.Forms.Button();
            this.go_back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 51.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(217, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "הפקת שוברים";
            // 
            // student_voucher
            // 
            this.student_voucher.BackgroundImage = global::Rabin_School.Properties.Resources.הפקת_שובר_לתלמיד_יחיד;
            this.student_voucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.student_voucher.Font = new System.Drawing.Font("Narkisim", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.student_voucher.Location = new System.Drawing.Point(464, 126);
            this.student_voucher.Name = "student_voucher";
            this.student_voucher.Size = new System.Drawing.Size(228, 219);
            this.student_voucher.TabIndex = 1;
            this.student_voucher.UseVisualStyleBackColor = true;
            this.student_voucher.Click += new System.EventHandler(this.student_voucher_Click);
            // 
            // all_students_voucher
            // 
            this.all_students_voucher.BackgroundImage = global::Rabin_School.Properties.Resources.הפקת_שובר_לכלל_התלמידים;
            this.all_students_voucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.all_students_voucher.Font = new System.Drawing.Font("Narkisim", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.all_students_voucher.Location = new System.Drawing.Point(84, 126);
            this.all_students_voucher.Name = "all_students_voucher";
            this.all_students_voucher.Size = new System.Drawing.Size(228, 219);
            this.all_students_voucher.TabIndex = 2;
            this.all_students_voucher.UseVisualStyleBackColor = true;
            this.all_students_voucher.Click += new System.EventHandler(this.all_students_voucher_Click);
            // 
            // go_back_button
            // 
            this.go_back_button.BackgroundImage = global::Rabin_School.Properties.Resources.חזור_חדש;
            this.go_back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.go_back_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.go_back_button.Location = new System.Drawing.Point(27, 384);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(104, 54);
            this.go_back_button.TabIndex = 3;
            this.go_back_button.UseVisualStyleBackColor = true;
            this.go_back_button.Click += new System.EventHandler(this.go_back_button_Click);
            // 
            // voucher_secretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.go_back_button);
            this.Controls.Add(this.all_students_voucher);
            this.Controls.Add(this.student_voucher);
            this.Controls.Add(this.label1);
            this.Name = "voucher_secretary";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button student_voucher;
        private System.Windows.Forms.Button all_students_voucher;
        private System.Windows.Forms.Button go_back_button;
    }
}