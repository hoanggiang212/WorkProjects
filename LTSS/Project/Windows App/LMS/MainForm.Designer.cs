﻿namespace LMS
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tạoMớiKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viesCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kháchHàngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tạoMớiKháchHàngToolStripMenuItem,
            this.viesCustomersToolStripMenuItem});
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.kháchHàngToolStripMenuItem.Text = "Customer";
            // 
            // tạoMớiKháchHàngToolStripMenuItem
            // 
            this.tạoMớiKháchHàngToolStripMenuItem.Name = "tạoMớiKháchHàngToolStripMenuItem";
            this.tạoMớiKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tạoMớiKháchHàngToolStripMenuItem.Text = "Create Customer";
            this.tạoMớiKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.tạoMớiKháchHàngToolStripMenuItem_Click);
            // 
            // viesCustomersToolStripMenuItem
            // 
            this.viesCustomersToolStripMenuItem.Name = "viesCustomersToolStripMenuItem";
            this.viesCustomersToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.viesCustomersToolStripMenuItem.Text = "View Customers";
            this.viesCustomersToolStripMenuItem.Click += new System.EventHandler(this.viesCustomersToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 697);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Logistic Management System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tạoMớiKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viesCustomersToolStripMenuItem;
    }
}

