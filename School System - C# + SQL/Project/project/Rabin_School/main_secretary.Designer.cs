namespace Rabin_School
{
    partial class main_secretary
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
            this.vouchers_button = new System.Windows.Forms.Button();
            this.manage_employees_button = new System.Windows.Forms.Button();
            this.logOut_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(108, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "!מזכירות, ברוכים הבאים";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // vouchers_button
            // 
            this.vouchers_button.BackgroundImage = global::Rabin_School.Properties.Resources.כפתור_הפקת_שוברים;
            this.vouchers_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vouchers_button.Font = new System.Drawing.Font("Narkisim", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.vouchers_button.Location = new System.Drawing.Point(455, 111);
            this.vouchers_button.Name = "vouchers_button";
            this.vouchers_button.Size = new System.Drawing.Size(228, 229);
            this.vouchers_button.TabIndex = 1;
            this.vouchers_button.UseVisualStyleBackColor = true;
            this.vouchers_button.Click += new System.EventHandler(this.vouchers_button_Click);
            // 
            // manage_employees_button
            // 
            this.manage_employees_button.BackgroundImage = global::Rabin_School.Properties.Resources.כפתור_ניהול_עובדים;
            this.manage_employees_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.manage_employees_button.Font = new System.Drawing.Font("Narkisim", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.manage_employees_button.Location = new System.Drawing.Point(162, 111);
            this.manage_employees_button.Name = "manage_employees_button";
            this.manage_employees_button.Size = new System.Drawing.Size(245, 229);
            this.manage_employees_button.TabIndex = 2;
            this.manage_employees_button.UseVisualStyleBackColor = true;
            this.manage_employees_button.Click += new System.EventHandler(this.manage_employees_button_Click);
            // 
            // logOut_button
            // 
            this.logOut_button.BackgroundImage = global::Rabin_School.Properties.Resources.התנתק;
            this.logOut_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logOut_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.logOut_button.Location = new System.Drawing.Point(24, 356);
            this.logOut_button.Name = "logOut_button";
            this.logOut_button.Size = new System.Drawing.Size(131, 66);
            this.logOut_button.TabIndex = 3;
            this.logOut_button.UseVisualStyleBackColor = true;
            this.logOut_button.Click += new System.EventHandler(this.logOut_button_Click);
            // 
            // main_secretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logOut_button);
            this.Controls.Add(this.manage_employees_button);
            this.Controls.Add(this.vouchers_button);
            this.Controls.Add(this.label1);
            this.Name = "main_secretary";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button vouchers_button;
        private System.Windows.Forms.Button manage_employees_button;
        private System.Windows.Forms.Button logOut_button;
    }
}