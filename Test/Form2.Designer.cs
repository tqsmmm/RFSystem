namespace Test
{
    partial class Form2
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
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_ywtm = new System.Windows.Forms.TextBox();
            this.btn_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(8, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "R2000450000531020003612110282";
            // 
            // txt_ywtm
            // 
            this.txt_ywtm.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_ywtm.Location = new System.Drawing.Point(8, 57);
            this.txt_ywtm.Name = "txt_ywtm";
            this.txt_ywtm.Size = new System.Drawing.Size(268, 26);
            this.txt_ywtm.TabIndex = 5;
            this.txt_ywtm.Text = "R2000450000531020000401030814";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(56, 182);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 4;
            this.btn_print.Text = "print";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_ywtm);
            this.Controls.Add(this.btn_print);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_ywtm;
        private System.Windows.Forms.Button btn_print;
    }
}