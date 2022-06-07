using System.Windows.Forms;

namespace WinFormsUI
{
    partial class FormWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWelcome));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonRules = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::WinFormsUI.Properties.Resources.board;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonRules);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.PictureBoxLogo);
            this.panel1.Location = new System.Drawing.Point(193, 74);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(25);
            this.panel1.Size = new System.Drawing.Size(500, 400);
            this.panel1.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExit.BackColor = System.Drawing.Color.LightGray;
            this.buttonExit.BackgroundImage = global::WinFormsUI.Properties.Resources.white_wood_background;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonExit.FlatAppearance.BorderSize = 5;
            this.buttonExit.Font = new System.Drawing.Font("ARB-218 Big Blunt MAR-50", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.ForeColor = System.Drawing.Color.Maroon;
            this.buttonExit.Location = new System.Drawing.Point(86, 318);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(328, 60);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonRules
            // 
            this.buttonRules.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRules.BackColor = System.Drawing.Color.LightGray;
            this.buttonRules.BackgroundImage = global::WinFormsUI.Properties.Resources.white_wood_background;
            this.buttonRules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRules.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonRules.FlatAppearance.BorderSize = 5;
            this.buttonRules.Font = new System.Drawing.Font("ARB-218 Big Blunt MAR-50", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRules.ForeColor = System.Drawing.Color.Maroon;
            this.buttonRules.Location = new System.Drawing.Point(86, 252);
            this.buttonRules.Name = "buttonRules";
            this.buttonRules.Size = new System.Drawing.Size(328, 60);
            this.buttonRules.TabIndex = 2;
            this.buttonRules.Text = "Rules";
            this.buttonRules.UseVisualStyleBackColor = false;
            this.buttonRules.Click += new System.EventHandler(this.buttonRules_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStart.BackColor = System.Drawing.Color.LightGray;
            this.buttonStart.BackgroundImage = global::WinFormsUI.Properties.Resources.white_wood_background;
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonStart.FlatAppearance.BorderSize = 5;
            this.buttonStart.Font = new System.Drawing.Font("ARB-218 Big Blunt MAR-50", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStart.ForeColor = System.Drawing.Color.Maroon;
            this.buttonStart.Location = new System.Drawing.Point(86, 186);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(328, 60);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PictureBoxLogo.Image = global::WinFormsUI.Properties.Resources.logo;
            this.PictureBoxLogo.InitialImage = null;
            this.PictureBoxLogo.Location = new System.Drawing.Point(25, 25);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(450, 155);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxLogo.TabIndex = 0;
            this.PictureBoxLogo.TabStop = false;
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFormsUI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(510, 430);
            this.Name = "FormWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers Welcome page";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox PictureBoxLogo;
        private Button buttonStart;
        private Button buttonRules;
        private Button buttonExit;
    }
}