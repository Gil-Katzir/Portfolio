namespace Rabin_School
{
    partial class update_hoom_classes
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
            this.label3 = new System.Windows.Forms.Label();
            this.teacher_id_textbox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.classes_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.teacher_name_value = new System.Windows.Forms.Label();
            this.update_confirm_button = new System.Windows.Forms.Button();
            this.go_back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(89, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(654, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "עדכון שיבוץ כיתות למורה";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Narkisim", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(521, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "הזן ת\"ז מורה לחיפוש";
            // 
            // teacher_id_textbox
            // 
            this.teacher_id_textbox.Location = new System.Drawing.Point(253, 102);
            this.teacher_id_textbox.Name = "teacher_id_textbox";
            this.teacher_id_textbox.Size = new System.Drawing.Size(234, 20);
            this.teacher_id_textbox.TabIndex = 3;
            // 
            // search_button
            // 
            this.search_button.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.search_button.Location = new System.Drawing.Point(154, 101);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(64, 22);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "חפש";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(580, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = ":בחר כיתות חינוך למורה";
            // 
            // classes_checkedListBox
            // 
            this.classes_checkedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.classes_checkedListBox.CheckOnClick = true;
            this.classes_checkedListBox.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.classes_checkedListBox.FormattingEnabled = true;
            this.classes_checkedListBox.Location = new System.Drawing.Point(306, 197);
            this.classes_checkedListBox.Name = "classes_checkedListBox";
            this.classes_checkedListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.classes_checkedListBox.Size = new System.Drawing.Size(469, 172);
            this.classes_checkedListBox.TabIndex = 6;
            // 
            // teacher_name_value
            // 
            this.teacher_name_value.AutoSize = true;
            this.teacher_name_value.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.teacher_name_value.Location = new System.Drawing.Point(465, 149);
            this.teacher_name_value.Name = "teacher_name_value";
            this.teacher_name_value.Size = new System.Drawing.Size(0, 20);
            this.teacher_name_value.TabIndex = 7;
            // 
            // update_confirm_button
            // 
            this.update_confirm_button.BackgroundImage = global::Rabin_School.Properties.Resources.עדכן;
            this.update_confirm_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.update_confirm_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.update_confirm_button.Location = new System.Drawing.Point(140, 346);
            this.update_confirm_button.Name = "update_confirm_button";
            this.update_confirm_button.Size = new System.Drawing.Size(109, 53);
            this.update_confirm_button.TabIndex = 8;
            this.update_confirm_button.UseVisualStyleBackColor = true;
            this.update_confirm_button.Click += new System.EventHandler(this.update_confirm_button_Click);
            // 
            // go_back_button
            // 
            this.go_back_button.BackgroundImage = global::Rabin_School.Properties.Resources.חזור_חדש;
            this.go_back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.go_back_button.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.go_back_button.Location = new System.Drawing.Point(26, 346);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(105, 53);
            this.go_back_button.TabIndex = 9;
            this.go_back_button.UseVisualStyleBackColor = true;
            this.go_back_button.Click += new System.EventHandler(this.go_back_button_Click);
            // 
            // update_hoom_classes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.go_back_button);
            this.Controls.Add(this.update_confirm_button);
            this.Controls.Add(this.teacher_name_value);
            this.Controls.Add(this.classes_checkedListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.teacher_id_textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "update_hoom_classes";
            this.Text = "update_hoom_classes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox teacher_id_textbox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox classes_checkedListBox;
        private System.Windows.Forms.Label teacher_name_value;
        private System.Windows.Forms.Button update_confirm_button;
        private System.Windows.Forms.Button go_back_button;
    }
}