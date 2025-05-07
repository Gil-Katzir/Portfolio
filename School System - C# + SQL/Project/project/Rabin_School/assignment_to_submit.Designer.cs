namespace Rabin_School
{
    partial class assignment_to_submit
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
            this.show_details_button = new System.Windows.Forms.Button();
            this.submit_assignment_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.assignments_to_sub_combobox = new System.Windows.Forms.ComboBox();
            this.assignment_name = new System.Windows.Forms.Label();
            this.teacher_name = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.last_date = new System.Windows.Forms.Label();
            this.assignment_name_value = new System.Windows.Forms.Label();
            this.last_date_value = new System.Windows.Forms.Label();
            this.description_value = new System.Windows.Forms.Label();
            this.teacher_name_value = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.Label();
            this.url_textbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.update_url_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(114, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "מטלות פתוחות להגשה";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // show_details_button
            // 
            this.show_details_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.show_details_button.Location = new System.Drawing.Point(87, 119);
            this.show_details_button.Name = "show_details_button";
            this.show_details_button.Size = new System.Drawing.Size(75, 23);
            this.show_details_button.TabIndex = 1;
            this.show_details_button.Text = "הצג";
            this.show_details_button.UseVisualStyleBackColor = true;
            this.show_details_button.Click += new System.EventHandler(this.show_details_button_Click);
            // 
            // submit_assignment_button
            // 
            this.submit_assignment_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.submit_assignment_button.Location = new System.Drawing.Point(144, 369);
            this.submit_assignment_button.Name = "submit_assignment_button";
            this.submit_assignment_button.Size = new System.Drawing.Size(75, 23);
            this.submit_assignment_button.TabIndex = 2;
            this.submit_assignment_button.Text = "הגש";
            this.submit_assignment_button.UseVisualStyleBackColor = true;
            this.submit_assignment_button.Click += new System.EventHandler(this.submit_assignment_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(632, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "בחר מטלה להגשה";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // assignments_to_sub_combobox
            // 
            this.assignments_to_sub_combobox.FormattingEnabled = true;
            this.assignments_to_sub_combobox.Location = new System.Drawing.Point(177, 120);
            this.assignments_to_sub_combobox.Name = "assignments_to_sub_combobox";
            this.assignments_to_sub_combobox.Size = new System.Drawing.Size(449, 21);
            this.assignments_to_sub_combobox.TabIndex = 4;
            // 
            // assignment_name
            // 
            this.assignment_name.AutoSize = true;
            this.assignment_name.BackColor = System.Drawing.Color.Transparent;
            this.assignment_name.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.assignment_name.Location = new System.Drawing.Point(702, 182);
            this.assignment_name.Name = "assignment_name";
            this.assignment_name.Size = new System.Drawing.Size(71, 16);
            this.assignment_name.TabIndex = 5;
            this.assignment_name.Text = "שם המטלה";
            this.assignment_name.Click += new System.EventHandler(this.assignment_name_Click);
            // 
            // teacher_name
            // 
            this.teacher_name.AutoSize = true;
            this.teacher_name.BackColor = System.Drawing.Color.Transparent;
            this.teacher_name.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.teacher_name.Location = new System.Drawing.Point(679, 322);
            this.teacher_name.Name = "teacher_name";
            this.teacher_name.Size = new System.Drawing.Size(94, 16);
            this.teacher_name.TabIndex = 6;
            this.teacher_name.Text = "מפרסם המטלה";
            this.teacher_name.Click += new System.EventHandler(this.teacher_name_Click);
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.description.Location = new System.Drawing.Point(687, 277);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(86, 16);
            this.description.TabIndex = 7;
            this.description.Text = "תיאור המטלה";
            this.description.Click += new System.EventHandler(this.description_Click);
            // 
            // last_date
            // 
            this.last_date.AutoSize = true;
            this.last_date.BackColor = System.Drawing.Color.Transparent;
            this.last_date.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.last_date.Location = new System.Drawing.Point(651, 229);
            this.last_date.Name = "last_date";
            this.last_date.Size = new System.Drawing.Size(122, 16);
            this.last_date.TabIndex = 8;
            this.last_date.Text = "תאריך אחרון להגשה";
            this.last_date.Click += new System.EventHandler(this.last_date_Click);
            // 
            // assignment_name_value
            // 
            this.assignment_name_value.AutoSize = true;
            this.assignment_name_value.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.assignment_name_value.Location = new System.Drawing.Point(506, 182);
            this.assignment_name_value.Name = "assignment_name_value";
            this.assignment_name_value.Size = new System.Drawing.Size(0, 16);
            this.assignment_name_value.TabIndex = 9;
            // 
            // last_date_value
            // 
            this.last_date_value.AutoSize = true;
            this.last_date_value.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.last_date_value.Location = new System.Drawing.Point(506, 229);
            this.last_date_value.Name = "last_date_value";
            this.last_date_value.Size = new System.Drawing.Size(0, 16);
            this.last_date_value.TabIndex = 10;
            // 
            // description_value
            // 
            this.description_value.AutoSize = true;
            this.description_value.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.description_value.Location = new System.Drawing.Point(506, 277);
            this.description_value.Name = "description_value";
            this.description_value.Size = new System.Drawing.Size(0, 16);
            this.description_value.TabIndex = 11;
            // 
            // teacher_name_value
            // 
            this.teacher_name_value.AutoSize = true;
            this.teacher_name_value.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.teacher_name_value.Location = new System.Drawing.Point(506, 322);
            this.teacher_name_value.Name = "teacher_name_value";
            this.teacher_name_value.Size = new System.Drawing.Size(0, 16);
            this.teacher_name_value.TabIndex = 12;
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.BackColor = System.Drawing.Color.Transparent;
            this.url.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.url.Location = new System.Drawing.Point(619, 371);
            this.url.Name = "url";
            this.url.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.url.Size = new System.Drawing.Size(157, 16);
            this.url.TabIndex = 13;
            this.url.Text = "צרף את קובץ הפתרון (url)";
            this.url.Click += new System.EventHandler(this.url_Click);
            // 
            // url_textbox
            // 
            this.url_textbox.Location = new System.Drawing.Point(231, 371);
            this.url_textbox.Name = "url_textbox";
            this.url_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.url_textbox.Size = new System.Drawing.Size(377, 20);
            this.url_textbox.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Rabin_School.Properties.Resources.חזור_חדש;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button3.Location = new System.Drawing.Point(12, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 51);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.return_button_Click);
            // 
            // update_url_button
            // 
            this.update_url_button.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.update_url_button.Location = new System.Drawing.Point(144, 367);
            this.update_url_button.Name = "update_url_button";
            this.update_url_button.Size = new System.Drawing.Size(75, 23);
            this.update_url_button.TabIndex = 16;
            this.update_url_button.Text = "עדכן";
            this.update_url_button.UseVisualStyleBackColor = true;
            this.update_url_button.Click += new System.EventHandler(this.update_url_button_Click);
            // 
            // assignment_to_submit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.update_url_button);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.url_textbox);
            this.Controls.Add(this.url);
            this.Controls.Add(this.teacher_name_value);
            this.Controls.Add(this.description_value);
            this.Controls.Add(this.last_date_value);
            this.Controls.Add(this.assignment_name_value);
            this.Controls.Add(this.last_date);
            this.Controls.Add(this.description);
            this.Controls.Add(this.teacher_name);
            this.Controls.Add(this.assignment_name);
            this.Controls.Add(this.assignments_to_sub_combobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submit_assignment_button);
            this.Controls.Add(this.show_details_button);
            this.Controls.Add(this.label1);
            this.Name = "assignment_to_submit";
            this.Text = "assignment_to_submit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button show_details_button;
        private System.Windows.Forms.Button submit_assignment_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox assignments_to_sub_combobox;
        private System.Windows.Forms.Label assignment_name;
        private System.Windows.Forms.Label teacher_name;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label last_date;
        private System.Windows.Forms.Label assignment_name_value;
        private System.Windows.Forms.Label last_date_value;
        private System.Windows.Forms.Label description_value;
        private System.Windows.Forms.Label teacher_name_value;
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.TextBox url_textbox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button update_url_button;
    }
}