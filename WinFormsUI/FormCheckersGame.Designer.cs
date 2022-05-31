namespace WinFormsUI
{
    partial class FormCheckersGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckersGame));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelScorePlayer2 = new System.Windows.Forms.Panel();
            this.labelScorePlayer2 = new System.Windows.Forms.Label();
            this.labelNamePlayer2 = new System.Windows.Forms.Label();
            this.PanelScorePlayer1 = new System.Windows.Forms.Panel();
            this.labelScorePlayer1 = new System.Windows.Forms.Label();
            this.labelNamePlayer1 = new System.Windows.Forms.Label();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.PanelScorePlayer2.SuspendLayout();
            this.PanelScorePlayer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PanelScorePlayer2);
            this.panel1.Controls.Add(this.PanelScorePlayer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 90);
            this.panel1.TabIndex = 0;
            // 
            // PanelScorePlayer2
            // 
            this.PanelScorePlayer2.BackColor = System.Drawing.Color.Transparent;
            this.PanelScorePlayer2.BackgroundImage = global::WinFormsUI.Properties.Resources.wood_deep;
            this.PanelScorePlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelScorePlayer2.Controls.Add(this.labelScorePlayer2);
            this.PanelScorePlayer2.Controls.Add(this.labelNamePlayer2);
            this.PanelScorePlayer2.Location = new System.Drawing.Point(276, 10);
            this.PanelScorePlayer2.Margin = new System.Windows.Forms.Padding(0);
            this.PanelScorePlayer2.Name = "PanelScorePlayer2";
            this.PanelScorePlayer2.Size = new System.Drawing.Size(246, 73);
            this.PanelScorePlayer2.TabIndex = 2;
            // 
            // labelScorePlayer2
            // 
            this.labelScorePlayer2.AutoSize = true;
            this.labelScorePlayer2.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScorePlayer2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelScorePlayer2.Location = new System.Drawing.Point(140, 14);
            this.labelScorePlayer2.Name = "labelScorePlayer2";
            this.labelScorePlayer2.Size = new System.Drawing.Size(37, 38);
            this.labelScorePlayer2.TabIndex = 2;
            this.labelScorePlayer2.Text = "0";
            // 
            // labelNamePlayer2
            // 
            this.labelNamePlayer2.AutoSize = true;
            this.labelNamePlayer2.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNamePlayer2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNamePlayer2.Location = new System.Drawing.Point(20, 19);
            this.labelNamePlayer2.Name = "labelNamePlayer2";
            this.labelNamePlayer2.Size = new System.Drawing.Size(124, 32);
            this.labelNamePlayer2.TabIndex = 2;
            this.labelNamePlayer2.Text = "Second:";
            // 
            // PanelScorePlayer1
            // 
            this.PanelScorePlayer1.BackColor = System.Drawing.Color.Transparent;
            this.PanelScorePlayer1.BackgroundImage = global::WinFormsUI.Properties.Resources.wood_deep;
            this.PanelScorePlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelScorePlayer1.Controls.Add(this.labelScorePlayer1);
            this.PanelScorePlayer1.Controls.Add(this.labelNamePlayer1);
            this.PanelScorePlayer1.Location = new System.Drawing.Point(10, 10);
            this.PanelScorePlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.PanelScorePlayer1.Name = "PanelScorePlayer1";
            this.PanelScorePlayer1.Size = new System.Drawing.Size(246, 73);
            this.PanelScorePlayer1.TabIndex = 1;
            // 
            // labelScorePlayer1
            // 
            this.labelScorePlayer1.AutoSize = true;
            this.labelScorePlayer1.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScorePlayer1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelScorePlayer1.Location = new System.Drawing.Point(108, 14);
            this.labelScorePlayer1.Name = "labelScorePlayer1";
            this.labelScorePlayer1.Size = new System.Drawing.Size(37, 38);
            this.labelScorePlayer1.TabIndex = 1;
            this.labelScorePlayer1.Text = "0";
            // 
            // labelNamePlayer1
            // 
            this.labelNamePlayer1.AutoSize = true;
            this.labelNamePlayer1.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNamePlayer1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNamePlayer1.Location = new System.Drawing.Point(19, 16);
            this.labelNamePlayer1.Name = "labelNamePlayer1";
            this.labelNamePlayer1.Size = new System.Drawing.Size(92, 32);
            this.labelNamePlayer1.TabIndex = 0;
            this.labelNamePlayer1.Text = "First:";
            // 
            // panelBoard
            // 
            this.panelBoard.BackgroundImage = global::WinFormsUI.Properties.Resources.white_tile;
            this.panelBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBoard.Location = new System.Drawing.Point(63, 96);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Padding = new System.Windows.Forms.Padding(40);
            this.panelBoard.Size = new System.Drawing.Size(400, 400);
            this.panelBoard.TabIndex = 1;
            // 
            // FormCheckersGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFormsUI.Properties.Resources.floor;
            this.ClientSize = new System.Drawing.Size(532, 503);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCheckersGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCheckersGame";
            this.panel1.ResumeLayout(false);
            this.PanelScorePlayer2.ResumeLayout(false);
            this.PanelScorePlayer2.PerformLayout();
            this.PanelScorePlayer1.ResumeLayout(false);
            this.PanelScorePlayer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label labelNamePlayer1;
        private Panel PanelScorePlayer2;
        private Panel PanelScorePlayer1;
        private Label labelScorePlayer1;
        private Label labelScorePlayer2;
        private Label labelNamePlayer2;
        private Panel panelBoard;
    }
}