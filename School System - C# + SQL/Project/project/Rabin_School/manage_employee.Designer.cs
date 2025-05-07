namespace Rabin_School
{
    partial class manage_employee
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
            this.read_employee_button = new System.Windows.Forms.Button();
            this.create_employee_button = new System.Windows.Forms.Button();
            this.go_back_button = new System.Windows.Forms.Button();
            this.update_hoom_classes_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 51.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(144, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "ניהול פרטי עובדים";
            // 
            // read_employee_button
            // 
            this.read_employee_button.BackgroundImage = global::Rabin_School.Properties.Resources.צפייה_בעובד_קיים;
            this.read_employee_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.read_employee_button.Font = new System.Drawing.Font("Narkisim", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.read_employee_button.Location = new System.Drawing.Point(542, 139);
            this.read_employee_button.Name = "read_employee_button";
            this.read_employee_button.Size = new System.Drawing.Size(200, 181);
            this.read_employee_button.TabIndex = 1;
            this.read_employee_button.UseVisualStyleBackColor = true;
            this.read_employee_button.Click += new System.EventHandler(this.read_employee_button_Click);
            // 
            // create_employee_button
            // 
            this.create_employee_button.BackgroundImage = global::Rabin_School.Properties.Resources.יצירת_עובד_חדש;
            this.create_employee_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.create_employee_button.Font = new System.Drawing.Font("Narkisim", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.create_employee_button.Location = new System.Drawing.Point(307, 139);
            this.create_employee_button.Name = "create_employee_button";
            this.create_employee_button.Size = new System.Drawing.Size(197, 181);
            this.create_employee_button.TabIndex = 2;
            this.create_employee_button.UseVisualStyleBackColor = true;
            this.create_employee_button.Click += new System.EventHandler(this.create_employee_button_Click);
            // 
            // go_back_button
            // 
            this.go_back_button.BackgroundImage = global::Rabin_School.Properties.Resources.חזור_חדש;
            this.go_back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.go_back_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.go_back_button.Location = new System.Drawing.Point(12, 365);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(140, 73);
            this.go_back_button.TabIndex = 3;
            this.go_back_button.UseVisualStyleBackColor = true;
            this.go_back_button.Click += new System.EventHandler(this.go_back_button_Click);
            // 
            // update_hoom_classes_button
            // 
            this.update_hoom_classes_button.BackgroundImage = global::Rabin_School.Properties.Resources.עדכון_שיבוץ_כיתות_למורה;
            this.update_hoom_classes_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.update_hoom_classes_button.Font = new System.Drawing.Font("Narkisim", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.update_hoom_classes_button.Location = new System.Drawing.Point(71, 139);
            this.update_hoom_classes_button.Name = "update_hoom_classes_button";
            this.update_hoom_classes_button.Size = new System.Drawing.Size(196, 181);
            this.update_hoom_classes_button.TabIndex = 4;
            this.update_hoom_classes_button.UseVisualStyleBackColor = true;
            this.update_hoom_classes_button.Click += new System.EventHandler(this.update_hoom_classes_button_Click);
            // 
            // manage_employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.update_hoom_classes_button);
            this.Controls.Add(this.go_back_button);
            this.Controls.Add(this.create_employee_button);
            this.Controls.Add(this.read_employee_button);
            this.Controls.Add(this.label1);
            this.Name = "manage_employee";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button read_employee_button;
        private System.Windows.Forms.Button create_employee_button;
        private System.Windows.Forms.Button go_back_button;
        private System.Windows.Forms.Button update_hoom_classes_button;
    }
}