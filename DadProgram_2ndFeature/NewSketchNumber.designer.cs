
namespace DadProgram
{
    partial class NewSketchNumber
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
            this.enterNewSketchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sketchNumberTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // enterNewSketchBtn
            // 
            this.enterNewSketchBtn.Location = new System.Drawing.Point(14, 44);
            this.enterNewSketchBtn.Name = "enterNewSketchBtn";
            this.enterNewSketchBtn.Size = new System.Drawing.Size(247, 25);
            this.enterNewSketchBtn.TabIndex = 0;
            this.enterNewSketchBtn.Text = "Submit";
            this.enterNewSketchBtn.UseVisualStyleBackColor = true;
            this.enterNewSketchBtn.Click += new System.EventHandler(this.enterNewSketchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Sketch Number";
            // 
            // sketchNumberTxtBox
            // 
            this.sketchNumberTxtBox.Location = new System.Drawing.Point(146, 13);
            this.sketchNumberTxtBox.Name = "sketchNumberTxtBox";
            this.sketchNumberTxtBox.Size = new System.Drawing.Size(114, 22);
            this.sketchNumberTxtBox.TabIndex = 2;
            // 
            // NewSketchNumber
            // 
            this.AcceptButton = this.enterNewSketchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 78);
            this.Controls.Add(this.sketchNumberTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterNewSketchBtn);
            this.Name = "NewSketchNumber";
            this.Text = "New Sketch Number";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterNewSketchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sketchNumberTxtBox;
    }
}