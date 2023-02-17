
namespace Client.Menu.Forms
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
            this.components = new System.ComponentModel.Container();
            this.pMain = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pAuthorisation = new System.Windows.Forms.Panel();
            this.lblServerKey = new System.Windows.Forms.Label();
            this.txtServerKey = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pMain.SuspendLayout();
            this.pAuthorisation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.panel4);
            this.pMain.Controls.Add(this.panel3);
            this.pMain.Controls.Add(this.panel2);
            this.pMain.Controls.Add(this.panel1);
            this.pMain.Controls.Add(this.pAuthorisation);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(554, 454);
            this.pMain.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel4.Location = new System.Drawing.Point(152, 107);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 1);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Location = new System.Drawing.Point(152, 345);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 1);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel2.Location = new System.Drawing.Point(401, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 239);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Location = new System.Drawing.Point(152, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 239);
            this.panel1.TabIndex = 3;
            // 
            // pAuthorisation
            // 
            this.pAuthorisation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.pAuthorisation.Controls.Add(this.lblServerKey);
            this.pAuthorisation.Controls.Add(this.txtServerKey);
            this.pAuthorisation.Controls.Add(this.lblUsername);
            this.pAuthorisation.Controls.Add(this.lblKey);
            this.pAuthorisation.Controls.Add(this.lblHost);
            this.pAuthorisation.Controls.Add(this.btnLogin);
            this.pAuthorisation.Controls.Add(this.txtUsername);
            this.pAuthorisation.Controls.Add(this.txtKey);
            this.pAuthorisation.Controls.Add(this.txtHost);
            this.pAuthorisation.Location = new System.Drawing.Point(152, 107);
            this.pAuthorisation.Name = "pAuthorisation";
            this.pAuthorisation.Size = new System.Drawing.Size(250, 239);
            this.pAuthorisation.TabIndex = 2;
            // 
            // lblServerKey
            // 
            this.lblServerKey.AutoSize = true;
            this.lblServerKey.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblServerKey.Location = new System.Drawing.Point(9, 101);
            this.lblServerKey.Name = "lblServerKey";
            this.lblServerKey.Size = new System.Drawing.Size(67, 16);
            this.lblServerKey.TabIndex = 7;
            this.lblServerKey.Text = "ServerKey";
            this.toolTip1.SetToolTip(this.lblServerKey, "The key that the server side gives you.");
            // 
            // txtServerKey
            // 
            this.txtServerKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.txtServerKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServerKey.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtServerKey.Location = new System.Drawing.Point(12, 120);
            this.txtServerKey.Name = "txtServerKey";
            this.txtServerKey.Size = new System.Drawing.Size(225, 22);
            this.txtServerKey.TabIndex = 6;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblUsername.Location = new System.Drawing.Point(9, 145);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(67, 16);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblKey.Location = new System.Drawing.Point(9, 57);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(31, 16);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "Key";
            this.toolTip1.SetToolTip(this.lblKey, "Your own random key for text encryption. Remember that the key need to be the sam" +
        "e for all clients");
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblHost.Location = new System.Drawing.Point(9, 13);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(35, 16);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Host";
            this.toolTip1.SetToolTip(this.lblHost, "The website url");
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.btnLogin.Location = new System.Drawing.Point(12, 201);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(225, 28);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUsername.Location = new System.Drawing.Point(12, 164);
            this.txtUsername.MaxLength = 10;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(225, 22);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtKey.Location = new System.Drawing.Point(12, 76);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(225, 22);
            this.txtKey.TabIndex = 1;
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHost.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtHost.Location = new System.Drawing.Point(12, 32);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(225, 22);
            this.txtHost.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(554, 454);
            this.Controls.Add(this.pMain);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pMain.ResumeLayout(false);
            this.pAuthorisation.ResumeLayout(false);
            this.pAuthorisation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pAuthorisation;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblServerKey;
        private System.Windows.Forms.TextBox txtServerKey;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}