namespace Rabin_School
{
    partial class student_voucher
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.student_id_text = new System.Windows.Forms.TextBox();
            this.voucher_name_text = new System.Windows.Forms.TextBox();
            this.due_date_text = new System.Windows.Forms.TextBox();
            this.cost_text = new System.Windows.Forms.TextBox();
            this.voucher_type_combobox = new System.Windows.Forms.ComboBox();
            this.produce1_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(75, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(658, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "הפקת שובר לסטודנט יחיד";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(667, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "תעודת זהות";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(679, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "שם השובר";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(677, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "סוג השובר";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(584, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "תאריך אחרון לתשלום";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(651, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "עלות לתשלום";
            // 
            // student_id_text
            // 
            this.student_id_text.Location = new System.Drawing.Point(453, 134);
            this.student_id_text.Name = "student_id_text";
            this.student_id_text.Size = new System.Drawing.Size(208, 20);
            this.student_id_text.TabIndex = 6;
            // 
            // voucher_name_text
            // 
            this.voucher_name_text.Location = new System.Drawing.Point(453, 172);
            this.voucher_name_text.Name = "voucher_name_text";
            this.voucher_name_text.Size = new System.Drawing.Size(208, 20);
            this.voucher_name_text.TabIndex = 7;
            // 
            // due_date_text
            // 
            this.due_date_text.Location = new System.Drawing.Point(370, 242);
            this.due_date_text.Name = "due_date_text";
            this.due_date_text.Size = new System.Drawing.Size(208, 20);
            this.due_date_text.TabIndex = 9;
            // 
            // cost_text
            // 
            this.cost_text.Location = new System.Drawing.Point(437, 276);
            this.cost_text.Name = "cost_text";
            this.cost_text.Size = new System.Drawing.Size(208, 20);
            this.cost_text.TabIndex = 10;
            // 
            // voucher_type_combobox
            // 
            this.voucher_type_combobox.FormattingEnabled = true;
            this.voucher_type_combobox.Location = new System.Drawing.Point(453, 207);
            this.voucher_type_combobox.Name = "voucher_type_combobox";
            this.voucher_type_combobox.Size = new System.Drawing.Size(207, 21);
            this.voucher_type_combobox.TabIndex = 11;
            // 
            // produce1_button
            // 
            this.produce1_button.BackgroundImage = global::Rabin_School.Properties.Resources.הפק_שובר_כפתור;
            this.produce1_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.produce1_button.Font = new System.Drawing.Font("Narkisim", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.produce1_button.Location = new System.Drawing.Point(32, 326);
            this.produce1_button.Name = "produce1_button";
            this.produce1_button.Size = new System.Drawing.Size(201, 96);
            this.produce1_button.TabIndex = 12;
            this.produce1_button.UseVisualStyleBackColor = true;
            this.produce1_button.Click += new System.EventHandler(this.produce1_button_Click);
            // 
            // student_voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.produce1_button);
            this.Controls.Add(this.voucher_type_combobox);
            this.Controls.Add(this.cost_text);
            this.Controls.Add(this.due_date_text);
            this.Controls.Add(this.voucher_name_text);
            this.Controls.Add(this.student_id_text);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "student_voucher";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox student_id_text;
        private System.Windows.Forms.TextBox voucher_name_text;
        private System.Windows.Forms.TextBox due_date_text;
        private System.Windows.Forms.TextBox cost_text;
        private System.Windows.Forms.ComboBox voucher_type_combobox;
        private System.Windows.Forms.Button produce1_button;
    }
}