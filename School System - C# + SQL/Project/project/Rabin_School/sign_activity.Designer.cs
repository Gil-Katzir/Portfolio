namespace Rabin_School
{
    partial class sign_activity
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
            this.show_activity_details_button = new System.Windows.Forms.Button();
            this.show_activities_combobox = new System.Windows.Forms.ComboBox();
            this.startDate = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.Label();
            this.activityType = new System.Windows.Forms.Label();
            this.cost = new System.Windows.Forms.Label();
            this.startDateValue = new System.Windows.Forms.Label();
            this.endDateValue = new System.Windows.Forms.Label();
            this.activityTypeValue = new System.Windows.Forms.Label();
            this.costValue = new System.Windows.Forms.Label();
            this.consent_button = new System.Windows.Forms.Button();
            this.healthIssues = new System.Windows.Forms.Label();
            this.healthIssuesValue = new System.Windows.Forms.TextBox();
            this.go_back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(66, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "פעילויות הממתינות לחתימה";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(602, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "בחר פעילות לחתימה";
            // 
            // show_activity_details_button
            // 
            this.show_activity_details_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.show_activity_details_button.Location = new System.Drawing.Point(53, 140);
            this.show_activity_details_button.Name = "show_activity_details_button";
            this.show_activity_details_button.Size = new System.Drawing.Size(152, 30);
            this.show_activity_details_button.TabIndex = 2;
            this.show_activity_details_button.Text = "הצג פרטי פעילות";
            this.show_activity_details_button.UseVisualStyleBackColor = true;
            this.show_activity_details_button.Click += new System.EventHandler(this.show_activity_details_button_Click);
            // 
            // show_activities_combobox
            // 
            this.show_activities_combobox.FormattingEnabled = true;
            this.show_activities_combobox.Location = new System.Drawing.Point(291, 142);
            this.show_activities_combobox.Name = "show_activities_combobox";
            this.show_activities_combobox.Size = new System.Drawing.Size(293, 21);
            this.show_activities_combobox.TabIndex = 3;
            // 
            // startDate
            // 
            this.startDate.AutoSize = true;
            this.startDate.BackColor = System.Drawing.Color.Transparent;
            this.startDate.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.startDate.Location = new System.Drawing.Point(605, 208);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(165, 19);
            this.startDate.TabIndex = 4;
            this.startDate.Text = "תאריך תחילת הפעילות";
            // 
            // endDate
            // 
            this.endDate.AutoSize = true;
            this.endDate.BackColor = System.Drawing.Color.Transparent;
            this.endDate.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.endDate.Location = new System.Drawing.Point(618, 248);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(152, 19);
            this.endDate.TabIndex = 5;
            this.endDate.Text = "תאריך סיום הפעילות";
            // 
            // activityType
            // 
            this.activityType.AutoSize = true;
            this.activityType.BackColor = System.Drawing.Color.Transparent;
            this.activityType.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.activityType.Location = new System.Drawing.Point(675, 285);
            this.activityType.Name = "activityType";
            this.activityType.Size = new System.Drawing.Size(95, 19);
            this.activityType.TabIndex = 6;
            this.activityType.Text = "סוג הפעילות";
            this.activityType.Visible = false;
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.BackColor = System.Drawing.Color.Transparent;
            this.cost.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cost.Location = new System.Drawing.Point(664, 323);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(106, 19);
            this.cost.TabIndex = 7;
            this.cost.Text = "עלות הפעילות";
            this.cost.Visible = false;
            // 
            // startDateValue
            // 
            this.startDateValue.AutoSize = true;
            this.startDateValue.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.startDateValue.Location = new System.Drawing.Point(447, 208);
            this.startDateValue.Name = "startDateValue";
            this.startDateValue.Size = new System.Drawing.Size(0, 19);
            this.startDateValue.TabIndex = 8;
            // 
            // endDateValue
            // 
            this.endDateValue.AutoSize = true;
            this.endDateValue.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.endDateValue.Location = new System.Drawing.Point(447, 248);
            this.endDateValue.Name = "endDateValue";
            this.endDateValue.Size = new System.Drawing.Size(0, 19);
            this.endDateValue.TabIndex = 9;
            // 
            // activityTypeValue
            // 
            this.activityTypeValue.AutoSize = true;
            this.activityTypeValue.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.activityTypeValue.Location = new System.Drawing.Point(447, 285);
            this.activityTypeValue.Name = "activityTypeValue";
            this.activityTypeValue.Size = new System.Drawing.Size(0, 19);
            this.activityTypeValue.TabIndex = 10;
            // 
            // costValue
            // 
            this.costValue.AutoSize = true;
            this.costValue.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.costValue.Location = new System.Drawing.Point(447, 323);
            this.costValue.Name = "costValue";
            this.costValue.Size = new System.Drawing.Size(0, 19);
            this.costValue.TabIndex = 11;
            // 
            // consent_button
            // 
            this.consent_button.BackgroundImage = global::Rabin_School.Properties.Resources.לחץ_לאישור_יציאה;
            this.consent_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.consent_button.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.consent_button.Location = new System.Drawing.Point(127, 347);
            this.consent_button.Name = "consent_button";
            this.consent_button.Size = new System.Drawing.Size(107, 48);
            this.consent_button.TabIndex = 12;
            this.consent_button.UseVisualStyleBackColor = true;
            this.consent_button.Click += new System.EventHandler(this.consent_button_Click);
            // 
            // healthIssues
            // 
            this.healthIssues.AutoSize = true;
            this.healthIssues.BackColor = System.Drawing.Color.Transparent;
            this.healthIssues.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.healthIssues.Location = new System.Drawing.Point(590, 363);
            this.healthIssues.Name = "healthIssues";
            this.healthIssues.Size = new System.Drawing.Size(179, 19);
            this.healthIssues.TabIndex = 13;
            this.healthIssues.Text = "פירוט של בעיות רפואיות";
            // 
            // healthIssuesValue
            // 
            this.healthIssuesValue.Location = new System.Drawing.Point(275, 362);
            this.healthIssuesValue.Name = "healthIssuesValue";
            this.healthIssuesValue.Size = new System.Drawing.Size(305, 20);
            this.healthIssuesValue.TabIndex = 14;
            // 
            // go_back_button
            // 
            this.go_back_button.BackgroundImage = global::Rabin_School.Properties.Resources.חזור_חדש;
            this.go_back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.go_back_button.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.go_back_button.Location = new System.Drawing.Point(25, 347);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(99, 48);
            this.go_back_button.TabIndex = 15;
            this.go_back_button.UseVisualStyleBackColor = true;
            this.go_back_button.Click += new System.EventHandler(this.go_back_button_Click);
            // 
            // sign_activity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.go_back_button);
            this.Controls.Add(this.healthIssuesValue);
            this.Controls.Add(this.healthIssues);
            this.Controls.Add(this.consent_button);
            this.Controls.Add(this.costValue);
            this.Controls.Add(this.activityTypeValue);
            this.Controls.Add(this.endDateValue);
            this.Controls.Add(this.startDateValue);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.activityType);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.show_activities_combobox);
            this.Controls.Add(this.show_activity_details_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "sign_activity";
            this.Text = "sign_activity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button show_activity_details_button;
        private System.Windows.Forms.ComboBox show_activities_combobox;
        private System.Windows.Forms.Label startDate;
        private System.Windows.Forms.Label endDate;
        private System.Windows.Forms.Label activityType;
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Label startDateValue;
        private System.Windows.Forms.Label endDateValue;
        private System.Windows.Forms.Label activityTypeValue;
        private System.Windows.Forms.Label costValue;
        private System.Windows.Forms.Button consent_button;
        private System.Windows.Forms.Label healthIssues;
        private System.Windows.Forms.TextBox healthIssuesValue;
        private System.Windows.Forms.Button go_back_button;
    }
}