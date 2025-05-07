namespace Rabin_School
{
    partial class main_teacher
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
            this.publish_button = new System.Windows.Forms.Button();
            this.reutrn_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(141, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "!מורה, ברוכים הבאים";
            // 
            // publish_button
            // 
            this.publish_button.BackgroundImage = global::Rabin_School.Properties.Resources.פרסום_מטלה_חדשה;
            this.publish_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.publish_button.Font = new System.Drawing.Font("Narkisim", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.publish_button.Location = new System.Drawing.Point(282, 113);
            this.publish_button.Name = "publish_button";
            this.publish_button.Size = new System.Drawing.Size(258, 264);
            this.publish_button.TabIndex = 1;
            this.publish_button.UseVisualStyleBackColor = true;
            this.publish_button.Click += new System.EventHandler(this.publish_button_Click);
            // 
            // reutrn_button
            // 
            this.reutrn_button.BackgroundImage = global::Rabin_School.Properties.Resources.חזור_חדש;
            this.reutrn_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reutrn_button.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.reutrn_button.Location = new System.Drawing.Point(12, 373);
            this.reutrn_button.Name = "reutrn_button";
            this.reutrn_button.Size = new System.Drawing.Size(130, 65);
            this.reutrn_button.TabIndex = 2;
            this.reutrn_button.UseVisualStyleBackColor = true;
            this.reutrn_button.Click += new System.EventHandler(this.reutrn_button_Click);
            // 
            // main_teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reutrn_button);
            this.Controls.Add(this.publish_button);
            this.Controls.Add(this.label1);
            this.Name = "main_teacher";
            this.Text = "main_teacher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button publish_button;
        private System.Windows.Forms.Button reutrn_button;
    }
}