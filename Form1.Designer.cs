namespace PhotonExecutor
{
    partial class Form1

    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MyHeartIsEditor = new Microsoft.Web.WebView2.WinForms.WebView2();
            ExecuteButton = new Button();
            AttachButton = new Button();
            editorFrame = new Panel();
            bottomBar = new Panel();
            link = new LinkLabel();
            label1 = new Label();
            statusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)MyHeartIsEditor).BeginInit();
            bottomBar.SuspendLayout();
            SuspendLayout();

            MyHeartIsEditor.AllowExternalDrop = true;
            MyHeartIsEditor.CreationProperties = null;
            MyHeartIsEditor.DefaultBackgroundColor = Color.White;
            MyHeartIsEditor.Dock = DockStyle.Fill;
            MyHeartIsEditor.Location = new Point(0, 0);
            MyHeartIsEditor.Name = "MyHeartIsEditor";
            MyHeartIsEditor.Size = new Size(893, 428);
            MyHeartIsEditor.TabIndex = 0;
            MyHeartIsEditor.ZoomFactor = 1D;

            ExecuteButton.BackColor = Color.FromArgb(40, 40, 40);
            ExecuteButton.Enabled = false;
            ExecuteButton.FlatAppearance.BorderSize = 0;
            ExecuteButton.FlatStyle = FlatStyle.Flat;
            ExecuteButton.Font = new Font("Segoe UI Semibold", 14F);
            ExecuteButton.ForeColor = Color.FromArgb(120, 120, 120);
            ExecuteButton.Location = new Point(12, 437);
            ExecuteButton.Name = "ExecuteButton";
            ExecuteButton.Size = new Size(141, 39);
            ExecuteButton.TabIndex = 1;
            ExecuteButton.Text = "Execute";
            ExecuteButton.UseVisualStyleBackColor = false;
            ExecuteButton.Click += ExecuteButton_Click;

            AttachButton.BackColor = Color.FromArgb(30, 30, 30);
            AttachButton.FlatAppearance.BorderColor = Color.FromArgb(138, 43, 226);
            AttachButton.FlatStyle = FlatStyle.Flat;
            AttachButton.Font = new Font("Segoe UI", 14F);
            AttachButton.ForeColor = Color.White;
            AttachButton.Location = new Point(159, 437);
            AttachButton.Name = "AttachButton";
            AttachButton.Size = new Size(141, 39);
            AttachButton.TabIndex = 2;
            AttachButton.Text = "Attach";
            AttachButton.UseVisualStyleBackColor = false;
            AttachButton.Click += AttachButton_Click;

            editorFrame.BackColor = Color.FromArgb(138, 43, 226);
            editorFrame.Dock = DockStyle.Fill;
            editorFrame.Location = new Point(0, 0);
            editorFrame.Name = "editorFrame";
            editorFrame.Padding = new Padding(1);
            editorFrame.Size = new Size(200, 100);
            editorFrame.TabIndex = 0;

            bottomBar.BackColor = Color.FromArgb(20, 20, 20);
            bottomBar.Controls.Add(link);
            bottomBar.Controls.Add(label1);
            bottomBar.Controls.Add(statusLabel);
            bottomBar.Dock = DockStyle.Bottom;
            bottomBar.Location = new Point(0, 428);
            bottomBar.Name = "bottomBar";
            bottomBar.Size = new Size(893, 55);
            bottomBar.TabIndex = 4;

            link.ActiveLinkColor = Color.FromArgb(94, 28, 149);
            link.AutoSize = true;
            link.DisabledLinkColor = Color.FromArgb(94, 28, 149);
            link.ForeColor = Color.FromArgb(94, 28, 149);
            link.LinkColor = Color.FromArgb(94, 28, 149);
            link.Location = new Point(440, 33);
            link.Name = "link";
            link.Size = new Size(157, 15);
            link.TabIndex = 1;
            link.TabStop = true;
            link.Text = "https://github.com/FXSploit";

            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.BlueViolet;
            label1.Location = new Point(306, 33);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Photon Executor V0.1";

            statusLabel.Font = new Font("Segoe UI", 10F);
            statusLabel.ForeColor = Color.Red;
            statusLabel.Location = new Point(12, 18);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(100, 23);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "● Not Attached";

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(893, 483);
            Controls.Add(AttachButton);
            Controls.Add(ExecuteButton);
            Controls.Add(MyHeartIsEditor);
            Controls.Add(bottomBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "γhoton Executor";
            ((System.ComponentModel.ISupportInitialize)MyHeartIsEditor).EndInit();
            bottomBar.ResumeLayout(false);
            bottomBar.PerformLayout();
            ResumeLayout(false);






        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 MyHeartIsEditor;
        private Button ExecuteButton;
        private Button AttachButton;
        private Panel editorFrame;
        private Panel bottomBar;
        private Label statusLabel;
        private Label label1;
        private LinkLabel link;
    }
}
