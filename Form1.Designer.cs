
namespace DadProgram
{
    partial class mainWindowFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createBtn = new System.Windows.Forms.Button();
            this.odlbl = new System.Windows.Forms.Label();
            this.odTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.thicknessTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.creatorTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.SystemColors.Control;
            this.createBtn.Location = new System.Drawing.Point(115, 183);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 0;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // odlbl
            // 
            this.odlbl.AutoSize = true;
            this.odlbl.Location = new System.Drawing.Point(38, 27);
            this.odlbl.Name = "odlbl";
            this.odlbl.Size = new System.Drawing.Size(24, 15);
            this.odlbl.TabIndex = 1;
            this.odlbl.Text = "OD";
            this.odlbl.Click += new System.EventHandler(this.odlbl_Click);
            // 
            // odTxtBox
            // 
            this.odTxtBox.Location = new System.Drawing.Point(115, 19);
            this.odTxtBox.Name = "odTxtBox";
            this.odTxtBox.Size = new System.Drawing.Size(100, 23);
            this.odTxtBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // idTxtBox
            // 
            this.idTxtBox.Location = new System.Drawing.Point(115, 60);
            this.idTxtBox.Name = "idTxtBox";
            this.idTxtBox.Size = new System.Drawing.Size(100, 23);
            this.idTxtBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thickness";
            // 
            // thicknessTxtBox
            // 
            this.thicknessTxtBox.Location = new System.Drawing.Point(115, 95);
            this.thicknessTxtBox.Name = "thicknessTxtBox";
            this.thicknessTxtBox.Size = new System.Drawing.Size(100, 23);
            this.thicknessTxtBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Creator";
            // 
            // creatorTxtBox
            // 
            this.creatorTxtBox.Location = new System.Drawing.Point(115, 132);
            this.creatorTxtBox.Name = "creatorTxtBox";
            this.creatorTxtBox.Size = new System.Drawing.Size(100, 23);
            this.creatorTxtBox.TabIndex = 8;
            // 
            // mainWindowFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 218);
            this.Controls.Add(this.creatorTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.thicknessTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.odTxtBox);
            this.Controls.Add(this.odlbl);
            this.Controls.Add(this.createBtn);
            this.Name = "mainWindowFrm";
            this.Text = "Sketch Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Label odlbl;
        private System.Windows.Forms.TextBox odTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox thicknessTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox creatorTxtBox;
    }
}

