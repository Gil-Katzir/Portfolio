namespace Rabin_School
{
    partial class main_student
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
            this.show_activities_to_sign_button = new System.Windows.Forms.Button();
            this.logOut_button = new System.Windows.Forms.Button();
            this.show_assignments_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(152, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "!תלמיד ברוכים הבאים";
            // 
            // show_activities_to_sign_button
            // 
            this.show_activities_to_sign_button.BackgroundImage = global::Rabin_School.Properties.Resources.הצג_פעילויות_לחתימה;
            this.show_activities_to_sign_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show_activities_to_sign_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.show_activities_to_sign_button.Location = new System.Drawing.Point(471, 126);
            this.show_activities_to_sign_button.Name = "show_activities_to_sign_button";
            this.show_activities_to_sign_button.Size = new System.Drawing.Size(222, 220);
            this.show_activities_to_sign_button.TabIndex = 1;
            this.show_activities_to_sign_button.UseVisualStyleBackColor = true;
            this.show_activities_to_sign_button.Click += new System.EventHandler(this.show_activities_to_sign_button_Click);
            // 
            // logOut_button
            // 
            this.logOut_button.BackgroundImage = global::Rabin_School.Properties.Resources.התנתק;
            this.logOut_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logOut_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.logOut_button.Location = new System.Drawing.Point(12, 367);
            this.logOut_button.Name = "logOut_button";
            this.logOut_button.Size = new System.Drawing.Size(143, 71);
            this.logOut_button.TabIndex = 2;
            this.logOut_button.UseVisualStyleBackColor = true;
            this.logOut_button.Click += new System.EventHandler(this.logOut_button_Click);
            // 
            // show_assignments_button
            // 
            this.show_assignments_button.BackgroundImage = global::Rabin_School.Properties.Resources.הצג_מטלות_להגשה;
            this.show_assignments_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show_assignments_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.show_assignments_button.Location = new System.Drawing.Point(185, 126);
            this.show_assignments_button.Name = "show_assignments_button";
            this.show_assignments_button.Size = new System.Drawing.Size(222, 220);
            this.show_assignments_button.TabIndex = 3;
            this.show_assignments_button.UseVisualStyleBackColor = true;
            this.show_assignments_button.Click += new System.EventHandler(this.show_assignments_button_Click);
            // 
            // main_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.show_assignments_button);
            this.Controls.Add(this.logOut_button);
            this.Controls.Add(this.show_activities_to_sign_button);
            this.Controls.Add(this.label1);
            this.Name = "main_student";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button show_activities_to_sign_button;
        private System.Windows.Forms.Button logOut_button;
        private System.Windows.Forms.Button show_assignments_button;
    }
}