﻿
namespace FINAL
{
    partial class UserControlDays
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDays = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbDays
            // 
            this.lbDays.AutoSize = true;
            this.lbDays.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDays.Location = new System.Drawing.Point(27, 32);
            this.lbDays.Name = "lbDays";
            this.lbDays.Size = new System.Drawing.Size(65, 24);
            this.lbDays.TabIndex = 0;
            this.lbDays.Text = "label1";
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.lbDays);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(164, 98);
            this.Click += new System.EventHandler(this.UserControlDays_Click_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDays;
    }
}
