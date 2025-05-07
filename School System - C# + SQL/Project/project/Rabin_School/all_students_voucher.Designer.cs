namespace Rabin_School
{
    partial class all_students_voucher
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
            this.voucher_type_combobox = new System.Windows.Forms.ComboBox();
            this.cost_text = new System.Windows.Forms.TextBox();
            this.due_date_text = new System.Windows.Forms.TextBox();
            this.voucher_name_text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.produce2_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // voucher_type_combobox
            // 
            this.voucher_type_combobox.FormattingEnabled = true;
            this.voucher_type_combobox.Location = new System.Drawing.Point(427, 186);
            this.voucher_type_combobox.Name = "voucher_type_combobox";
            this.voucher_type_combobox.Size = new System.Drawing.Size(207, 21);
            this.voucher_type_combobox.TabIndex = 23;
            this.voucher_type_combobox.SelectedIndexChanged += new System.EventHandler(this.voucher_type_combobox_SelectedIndexChanged);
            // 
            // cost_text
            // 
            this.cost_text.Location = new System.Drawing.Point(412, 282);
            this.cost_text.Name = "cost_text";
            this.cost_text.Size = new System.Drawing.Size(208, 20);
            this.cost_text.TabIndex = 22;
            this.cost_text.TextChanged += new System.EventHandler(this.cost_text_TextChanged);
            // 
            // due_date_text
            // 
            this.due_date_text.Location = new System.Drawing.Point(337, 234);
            this.due_date_text.Name = "due_date_text";
            this.due_date_text.Size = new System.Drawing.Size(208, 20);
            this.due_date_text.TabIndex = 21;
            this.due_date_text.TextChanged += new System.EventHandler(this.due_date_text_TextChanged);
            // 
            // voucher_name_text
            // 
            this.voucher_name_text.Location = new System.Drawing.Point(427, 137);
            this.voucher_name_text.Name = "voucher_name_text";
            this.voucher_name_text.Size = new System.Drawing.Size(208, 20);
            this.voucher_name_text.TabIndex = 20;
            this.voucher_name_text.TextChanged += new System.EventHandler(this.voucher_name_text_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Narkisim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(626, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 24);
            this.label6.TabIndex = 18;
            this.label6.Text = "עלות לתשלום";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Narkisim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(551, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "תאריך אחרון לתשלום";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Narkisim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(659, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "סוג השובר";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Narkisim", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(659, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "שם השובר";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Narkisim", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(55, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(667, 63);
            this.label1.TabIndex = 24;
            this.label1.Text = "הפק שובר לכלל התלמידים";
            // 
            // produce2_button
            // 
            this.produce2_button.BackgroundImage = global::Rabin_School.Properties.Resources.הפק_שובר_כפתור;
            this.produce2_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.produce2_button.Font = new System.Drawing.Font("Narkisim", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.produce2_button.Location = new System.Drawing.Point(33, 322);
            this.produce2_button.Name = "produce2_button";
            this.produce2_button.Size = new System.Drawing.Size(200, 101);
            this.produce2_button.TabIndex = 25;
            this.produce2_button.UseVisualStyleBackColor = true;
            this.produce2_button.Click += new System.EventHandler(this.produce2_button_Click);
            // 
            // all_students_voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rabin_School.Properties.Resources.רקע_בית_ספר;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.produce2_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.voucher_type_combobox);
            this.Controls.Add(this.cost_text);
            this.Controls.Add(this.due_date_text);
            this.Controls.Add(this.voucher_name_text);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "all_students_voucher";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox voucher_type_combobox;
        private System.Windows.Forms.TextBox cost_text;
        private System.Windows.Forms.TextBox due_date_text;
        private System.Windows.Forms.TextBox voucher_name_text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button produce2_button;
    }
}