using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XenoUI;

namespace PhotonExecutor
{
    public partial class Form1 : Form
    {
        private bool _isAttached;

        public Form1()
        {
            ClientsWindow.Initialize(false);
            InitializeComponent();

            SetAttachState(false);
        }

        #region Xeno Imports

        [DllImport("Xeno.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetClients();

        [DllImport("Xeno.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern void Execute(byte[] script, int[] pids, int count);

        [DllImport("Xeno.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void Attach();

        #endregion

        #region Lifecycle

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await MyHeartIsEditor.EnsureCoreWebView2Async();
            MyHeartIsEditor.Source =
                new Uri("https://dark-modz.github.io/Monaco/Editor/index.html");
        }

        #endregion

        #region UI Events

        private async void AttachButton_Click(object sender, EventArgs e)
        {
            AttachButton.Enabled = false;
            AttachButton.Text = "Attaching...";

            try
            {
                await Task.Run(() => Attach());

                _isAttached = GetReadyClientPIDs().Count > 0;
                SetAttachState(_isAttached);

                if (!_isAttached)
                    MessageBox.Show("Attached, but no ready clients.", "Xeno",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                _isAttached = false;
                SetAttachState(false);

                MessageBox.Show($"Attach failed:\n{ex.Message}", "Xeno",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                AttachButton.Enabled = true;
            }
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            await ExecuteScriptAsync();
        }

        #endregion

        #region Core Logic

        private async Task ExecuteScriptAsync()
        {
            if (!_isAttached) return;

            var core = MyHeartIsEditor.CoreWebView2;
            if (core == null) return;



            string raw = await MyHeartIsEditor.CoreWebView2
                .ExecuteScriptAsync("editor.getValue();");

            string script = Regex.Unescape(raw.Trim('"'));

            if (string.IsNullOrWhiteSpace(script))
                return;

            await Task.Run(() => ExecuteOnClients(script));
        }

        private void ExecuteOnClients(string script)
        {
            var pids = GetReadyClientPIDs();

            if (pids.Count == 0)
            {
                Invoke(() =>
                    MessageBox.Show("No ready clients.", "Xeno",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning));
                return;
            }

            try
            {
                byte[] payload = Encoding.UTF8.GetBytes(script + "\0");
                Execute(payload, pids.ToArray(), pids.Count);
            }
            catch (Exception ex)
            {
                Invoke(() =>
                    MessageBox.Show(ex.Message, "Execution Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        private List<int> GetReadyClientPIDs()
        {
            var result = new List<int>();

            try
            {
                IntPtr ptr = GetClients();
                if (ptr == IntPtr.Zero) return result;

                string json = Marshal.PtrToStringAnsi(ptr);
                if (string.IsNullOrWhiteSpace(json)) return result;

                var clients = JsonConvert.DeserializeObject<List<List<object>>>(json);
                if (clients == null) return result;

                foreach (var c in clients)
                {
                    if (c.Count < 4) continue;

                    int pid = Convert.ToInt32(c[0]);
                    int state = Convert.ToInt32(c[3]);

                    if (state == 3)
                        result.Add(pid);
                }
            }
#if DEBUG
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Client Parse Error");
            }
#else
            catch { }
#endif

            return result;
        }

        #endregion

        #region UI State

        private void SetAttachState(bool attached)
        {
            _isAttached = attached;

            if (attached)
            {
                statusLabel.Text = "● Attached";
                statusLabel.ForeColor = Color.LimeGreen;

                ExecuteButton.Enabled = true;
                ExecuteButton.BackColor = Color.FromArgb(138, 43, 226);
                ExecuteButton.ForeColor = Color.White;

                AttachButton.Text = "Attached";
            }
            else
            {
                statusLabel.Text = "● Not Attached";
                statusLabel.ForeColor = Color.Red;

                ExecuteButton.Enabled = false;
                ExecuteButton.BackColor = Color.FromArgb(40, 40, 40);
                ExecuteButton.ForeColor = Color.FromArgb(120, 120, 120);

                AttachButton.Text = "Attach";
            }
        }

        #endregion

    }
}
