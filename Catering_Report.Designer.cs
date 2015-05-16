namespace ERS
{
    partial class Catering_Report
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.from_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.print_btn = new System.Windows.Forms.Button();
            this.reporttype_grp = new System.Windows.Forms.GroupBox();
            this.allitems_radio = new System.Windows.Forms.RadioButton();
            this.oneitem_radio = new System.Windows.Forms.RadioButton();
            this.items_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.reporttype_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.to_date);
            this.groupBox1.Controls.Add(this.from_date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(28, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 58);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // to_date
            // 
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(285, 24);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(99, 22);
            this.to_date.TabIndex = 9;
            this.to_date.Value = new System.DateTime(2015, 4, 13, 1, 39, 57, 0);
            // 
            // from_date
            // 
            this.from_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from_date.Location = new System.Drawing.Point(111, 24);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(99, 22);
            this.from_date.TabIndex = 8;
            this.from_date.Value = new System.DateTime(2015, 4, 13, 1, 39, 57, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(243, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(56, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "From";
            // 
            // print_btn
            // 
            this.print_btn.ForeColor = System.Drawing.Color.Black;
            this.print_btn.Location = new System.Drawing.Point(215, 200);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(75, 23);
            this.print_btn.TabIndex = 10;
            this.print_btn.Text = "Print";
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // reporttype_grp
            // 
            this.reporttype_grp.Controls.Add(this.allitems_radio);
            this.reporttype_grp.Controls.Add(this.oneitem_radio);
            this.reporttype_grp.Controls.Add(this.items_combo);
            this.reporttype_grp.Controls.Add(this.label1);
            this.reporttype_grp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.reporttype_grp.Location = new System.Drawing.Point(27, 88);
            this.reporttype_grp.Name = "reporttype_grp";
            this.reporttype_grp.Size = new System.Drawing.Size(449, 100);
            this.reporttype_grp.TabIndex = 11;
            this.reporttype_grp.TabStop = false;
            this.reporttype_grp.Text = "Report Type";
            // 
            // allitems_radio
            // 
            this.allitems_radio.AutoSize = true;
            this.allitems_radio.ForeColor = System.Drawing.Color.Black;
            this.allitems_radio.Location = new System.Drawing.Point(29, 61);
            this.allitems_radio.Name = "allitems_radio";
            this.allitems_radio.Size = new System.Drawing.Size(76, 20);
            this.allitems_radio.TabIndex = 1;
            this.allitems_radio.TabStop = true;
            this.allitems_radio.Text = "All Items";
            this.allitems_radio.UseVisualStyleBackColor = true;
            // 
            // oneitem_radio
            // 
            this.oneitem_radio.AutoSize = true;
            this.oneitem_radio.ForeColor = System.Drawing.Color.Black;
            this.oneitem_radio.Location = new System.Drawing.Point(29, 35);
            this.oneitem_radio.Name = "oneitem_radio";
            this.oneitem_radio.Size = new System.Drawing.Size(79, 20);
            this.oneitem_radio.TabIndex = 0;
            this.oneitem_radio.TabStop = true;
            this.oneitem_radio.Text = "One Item";
            this.oneitem_radio.UseVisualStyleBackColor = true;
            this.oneitem_radio.CheckedChanged += new System.EventHandler(this.oneitem_radio_CheckedChanged);
            // 
            // items_combo
            // 
            this.items_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.items_combo.ForeColor = System.Drawing.Color.Black;
            this.items_combo.FormattingEnabled = true;
            this.items_combo.Location = new System.Drawing.Point(285, 34);
            this.items_combo.Name = "items_combo";
            this.items_combo.Size = new System.Drawing.Size(121, 24);
            this.items_combo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(206, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item";
            // 
            // Catering_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 234);
            this.Controls.Add(this.reporttype_grp);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.groupBox1);
            this.Name = "Catering_Report";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catering Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.reporttype_grp.ResumeLayout(false);
            this.reporttype_grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker to_date;
        private System.Windows.Forms.DateTimePicker from_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.GroupBox reporttype_grp;
        private System.Windows.Forms.RadioButton allitems_radio;
        private System.Windows.Forms.RadioButton oneitem_radio;
        private System.Windows.Forms.ComboBox items_combo;
        private System.Windows.Forms.Label label1;
    }
}