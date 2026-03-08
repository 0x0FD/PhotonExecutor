namespace PhotonFinalFr
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            namelbl = new Label();
            attachbtn = new Button();
            executebtn = new Button();
            topBar = new Panel();
            logoIcon = new Label();
            versionlbl = new Label();
            accentLine = new Panel();
            bottomBar = new Panel();
            statusDot = new Panel();
            statuslbl = new Label();
            divider = new Panel();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            topBar.SuspendLayout();
            bottomBar.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.FromArgb(15, 15, 15);
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 51);
            webView21.Margin = new Padding(3, 0, 3, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(880, 430);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // namelbl
            // 
            namelbl.Dock = DockStyle.Fill;
            namelbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            namelbl.ForeColor = Color.FromArgb(255, 255, 128);
            namelbl.Location = new Point(0, 0);
            namelbl.Margin = new Padding(3, 0, 80, 0);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(880, 50);
            namelbl.TabIndex = 0;
            namelbl.Text = "Photon Executor";
            namelbl.TextAlign = ContentAlignment.MiddleLeft;
            namelbl.Click += namelbl_Click;
            // 
            // attachbtn
            // 
            attachbtn.BackColor = Color.Transparent;
            attachbtn.Cursor = Cursors.Hand;
            attachbtn.FlatAppearance.BorderColor = Color.FromArgb(255, 253, 120);
            attachbtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 255, 214, 0);
            attachbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 255, 214, 0);
            attachbtn.FlatStyle = FlatStyle.Flat;
            attachbtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            attachbtn.ForeColor = Color.FromArgb(255, 255, 128);
            attachbtn.Location = new Point(146, 13);
            attachbtn.Name = "attachbtn";
            attachbtn.Size = new Size(118, 36);
            attachbtn.TabIndex = 1;
            attachbtn.Text = "⚙  Attach";
            attachbtn.UseVisualStyleBackColor = false;
            attachbtn.Click += attachbtn_Click;
            // 
            // executebtn
            // 
            executebtn.BackColor = Color.FromArgb(255, 255, 128);
            executebtn.Cursor = Cursors.Hand;
            executebtn.FlatAppearance.BorderSize = 0;
            executebtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 175, 0);
            executebtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 235, 100);
            executebtn.FlatStyle = FlatStyle.Flat;
            executebtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            executebtn.ForeColor = Color.FromArgb(15, 15, 15);
            executebtn.Location = new Point(16, 13);
            executebtn.Name = "executebtn";
            executebtn.Size = new Size(118, 36);
            executebtn.TabIndex = 0;
            executebtn.Text = "▶  Execute";
            executebtn.UseVisualStyleBackColor = false;
            executebtn.Click += executebtn_Click;
            // 
            // topBar
            // 
            topBar.BackColor = Color.FromArgb(22, 22, 22);
            topBar.Controls.Add(namelbl);
            topBar.Controls.Add(logoIcon);
            topBar.Controls.Add(versionlbl);
            topBar.Controls.Add(accentLine);
            topBar.Dock = DockStyle.Top;
            topBar.Location = new Point(0, 0);
            topBar.Name = "topBar";
            topBar.Size = new Size(880, 50);
            topBar.TabIndex = 2;
            // 
            // logoIcon
            // 
            logoIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            logoIcon.ForeColor = Color.FromArgb(255, 253, 120);
            logoIcon.Location = new Point(18, 0);
            logoIcon.Name = "logoIcon";
            logoIcon.Size = new Size(38, 50);
            logoIcon.TabIndex = 2;
            logoIcon.Text = "⚡";
            logoIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // versionlbl
            // 
            versionlbl.Font = new Font("Segoe UI", 7.5F);
            versionlbl.ForeColor = Color.FromArgb(180, 148, 0);
            versionlbl.Location = new Point(810, 0);
            versionlbl.Name = "versionlbl";
            versionlbl.Size = new Size(58, 50);
            versionlbl.TabIndex = 3;
            versionlbl.Text = "v1.0";
            versionlbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accentLine
            // 
            accentLine.BackColor = Color.FromArgb(255, 253, 120);
            accentLine.Location = new Point(0, 47);
            accentLine.Name = "accentLine";
            accentLine.Size = new Size(880, 10);
            accentLine.TabIndex = 5;
            // 
            // bottomBar
            // 
            bottomBar.BackColor = Color.FromArgb(22, 22, 22);
            bottomBar.Controls.Add(executebtn);
            bottomBar.Controls.Add(attachbtn);
            bottomBar.Controls.Add(statusDot);
            bottomBar.Controls.Add(statuslbl);
            bottomBar.Dock = DockStyle.Bottom;
            bottomBar.Location = new Point(0, 481);
            bottomBar.Name = "bottomBar";
            bottomBar.Size = new Size(880, 62);
            bottomBar.TabIndex = 3;
            // 
            // statusDot
            // 
            statusDot.BackColor = Color.FromArgb(255, 35, 35);
            statusDot.Location = new Point(831, 26);
            statusDot.Name = "statusDot";
            statusDot.Size = new Size(8, 8);
            statusDot.TabIndex = 2;
            // 
            // statuslbl
            // 
            statuslbl.AutoSize = true;
            statuslbl.Font = new Font("Segoe UI", 8F);
            statuslbl.ForeColor = Color.FromArgb(110, 110, 110);
            statuslbl.Location = new Point(810, 21);
            statuslbl.Name = "statuslbl";
            statuslbl.Size = new Size(15, 13);
            statuslbl.TabIndex = 3;
            statuslbl.Text = "~";
            // 
            // divider
            // 
            divider.BackColor = Color.FromArgb(45, 45, 45);
            divider.Dock = DockStyle.Top;
            divider.Location = new Point(0, 50);
            divider.Name = "divider";
            divider.Size = new Size(880, 1);
            divider.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(880, 543);
            Controls.Add(webView21);
            Controls.Add(divider);
            Controls.Add(topBar);
            Controls.Add(bottomBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Photon";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            topBar.ResumeLayout(false);
            bottomBar.ResumeLayout(false);
            bottomBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Label namelbl;
        private Label logoIcon;
        private Label versionlbl;
        private Button attachbtn;
        private Button executebtn;
        private Panel topBar;
        private Panel bottomBar;
        private Panel statusDot;
        private Panel divider;
        private Label statuslbl;
        private Panel accentLine;
    }
}