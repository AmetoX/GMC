namespace Geometrie7._1
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonFinishUp = new System.Windows.Forms.Button();
            this.buttonTriang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonThreeColor = new System.Windows.Forms.Button();
            this.buttonArie = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 494);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // buttonFinishUp
            // 
            this.buttonFinishUp.Location = new System.Drawing.Point(1032, 286);
            this.buttonFinishUp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFinishUp.Name = "buttonFinishUp";
            this.buttonFinishUp.Size = new System.Drawing.Size(100, 31);
            this.buttonFinishUp.TabIndex = 2;
            this.buttonFinishUp.Text = "Inchidere";
            this.buttonFinishUp.UseVisualStyleBackColor = true;
            this.buttonFinishUp.Click += new System.EventHandler(this.buttonFinishUp_Click);
            // 
            // buttonTriang
            // 
            this.buttonTriang.Location = new System.Drawing.Point(1031, 325);
            this.buttonTriang.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTriang.Name = "buttonTriang";
            this.buttonTriang.Size = new System.Drawing.Size(100, 31);
            this.buttonTriang.TabIndex = 3;
            this.buttonTriang.Text = "Otectonie";
            this.buttonTriang.UseVisualStyleBackColor = true;
            this.buttonTriang.Click += new System.EventHandler(this.buttonTriang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(575, 478);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 4;
            // 
            // buttonThreeColor
            // 
            this.buttonThreeColor.Location = new System.Drawing.Point(1032, 439);
            this.buttonThreeColor.Margin = new System.Windows.Forms.Padding(4);
            this.buttonThreeColor.Name = "buttonThreeColor";
            this.buttonThreeColor.Size = new System.Drawing.Size(100, 31);
            this.buttonThreeColor.TabIndex = 6;
            this.buttonThreeColor.Text = "Colorare";
            this.buttonThreeColor.UseVisualStyleBackColor = true;
            this.buttonThreeColor.Click += new System.EventHandler(this.buttonThreeColor_Click);
            // 
            // buttonArie
            // 
            this.buttonArie.Location = new System.Drawing.Point(1032, 364);
            this.buttonArie.Margin = new System.Windows.Forms.Padding(4);
            this.buttonArie.Name = "buttonArie";
            this.buttonArie.Size = new System.Drawing.Size(100, 31);
            this.buttonArie.TabIndex = 7;
            this.buttonArie.Text = "Arie";
            this.buttonArie.UseVisualStyleBackColor = true;
            this.buttonArie.Click += new System.EventHandler(this.buttonArie_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1032, 478);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1031, 402);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 522);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonFinishUp);
            this.Controls.Add(this.buttonArie);
            this.Controls.Add(this.buttonThreeColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTriang);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1TriangOtectomie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFinishUp;
        private System.Windows.Forms.Button buttonTriang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonThreeColor;
        private System.Windows.Forms.Button buttonArie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

