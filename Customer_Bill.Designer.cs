namespace ERS
{
    partial class Customer_Bill
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
            this.custSearch_btn = new System.Windows.Forms.Button();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.number_txt = new System.Windows.Forms.TextBox();
            this.rooms_grp = new System.Windows.Forms.GroupBox();
            this.print_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.date_combo = new System.Windows.Forms.DateTimePicker();
            this.resSearch_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // custSearch_btn
            // 
            this.custSearch_btn.ForeColor = System.Drawing.Color.Black;
            this.custSearch_btn.Location = new System.Drawing.Point(223, 20);
            this.custSearch_btn.Name = "custSearch_btn";
            this.custSearch_btn.Size = new System.Drawing.Size(75, 23);
            this.custSearch_btn.TabIndex = 14;
            this.custSearch_btn.Text = "Search";
            this.custSearch_btn.UseVisualStyleBackColor = true;
            this.custSearch_btn.Click += new System.EventHandler(this.custSearch_btn_Click);
            // 
            // name_txt
            // 
            this.name_txt.Enabled = false;
            this.name_txt.Location = new System.Drawing.Point(317, 21);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(260, 20);
            this.name_txt.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Number";
            // 
            // number_txt
            // 
            this.number_txt.Location = new System.Drawing.Point(96, 21);
            this.number_txt.Name = "number_txt";
            this.number_txt.Size = new System.Drawing.Size(121, 20);
            this.number_txt.TabIndex = 12;
            this.number_txt.TextChanged += new System.EventHandler(this.number_txt_TextChanged);
            // 
            // rooms_grp
            // 
            this.rooms_grp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rooms_grp.Location = new System.Drawing.Point(37, 94);
            this.rooms_grp.Name = "rooms_grp";
            this.rooms_grp.Size = new System.Drawing.Size(282, 158);
            this.rooms_grp.TabIndex = 15;
            this.rooms_grp.TabStop = false;
            this.rooms_grp.Text = "Rooms";
            // 
            // print_btn
            // 
            this.print_btn.Enabled = false;
            this.print_btn.ForeColor = System.Drawing.Color.Black;
            this.print_btn.Location = new System.Drawing.Point(411, 164);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(75, 23);
            this.print_btn.TabIndex = 16;
            this.print_btn.Text = "Print";
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Reservation End Date";
            // 
            // date_combo
            // 
            this.date_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.date_combo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_combo.Location = new System.Drawing.Point(183, 59);
            this.date_combo.Name = "date_combo";
            this.date_combo.Size = new System.Drawing.Size(99, 22);
            this.date_combo.TabIndex = 18;
            this.date_combo.Value = new System.DateTime(2015, 4, 13, 1, 39, 57, 0);
            // 
            // resSearch_btn
            // 
            this.resSearch_btn.Enabled = false;
            this.resSearch_btn.ForeColor = System.Drawing.Color.Black;
            this.resSearch_btn.Location = new System.Drawing.Point(302, 59);
            this.resSearch_btn.Name = "resSearch_btn";
            this.resSearch_btn.Size = new System.Drawing.Size(75, 23);
            this.resSearch_btn.TabIndex = 19;
            this.resSearch_btn.Text = "Search";
            this.resSearch_btn.UseVisualStyleBackColor = true;
            this.resSearch_btn.Click += new System.EventHandler(this.resSearch_btn_Click);
            // 
            // Customer_Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 266);
            this.Controls.Add(this.resSearch_btn);
            this.Controls.Add(this.date_combo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.rooms_grp);
            this.Controls.Add(this.custSearch_btn);
            this.Controls.Add(this.name_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.number_txt);
            this.Name = "Customer_Bill";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Bill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button custSearch_btn;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox number_txt;
        private System.Windows.Forms.GroupBox rooms_grp;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date_combo;
        private System.Windows.Forms.Button resSearch_btn;
    }
}