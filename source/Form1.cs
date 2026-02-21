using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using XenoUI;
// Xeno is safe but not the ones that you find on internet ...
// i mean API's safe but others not 
namespace PhotonFinalFr
{
    public partial class Form1 : Form
    {

        [DllImport("Xeno.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern IntPtr GetClients();

        [DllImport("Xeno.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private static extern void Execute(byte[] script, int[] PIDs, int count);

        [DllImport("Xeno.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Attach();

        [DllImport("Xeno.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void is_attached();

        private List<int> GetReadyClientPIDs()
        {
            var pids = new List<int>();

            try
            {
                IntPtr clientsPtr = GetClients();
                statusDot.BackColor = Color.FromArgb(255, 255, 0, 0);
                if (clientsPtr == IntPtr.Zero) return pids;

                string clientsJson = Marshal.PtrToStringAnsi(clientsPtr);
                var clientsList = JsonConvert.DeserializeObject<List<List<object>>>(clientsJson);
                statusDot.BackColor = Color.FromArgb(255, 0, 255, 0);
                if (clientsList != null)
                {
                    foreach (var client in clientsList)
                    {
                        if (client.Count >= 4)
                        {
                            int pid = Convert.ToInt32(client[0]);
                            int state = Convert.ToInt32(client[3]);

                            if (state == 3) // Ready state
                            {
                                pids.Add(pid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return pids;
        }
        private void ExecuteScriptOnClients(string script)
        {
            if (string.IsNullOrWhiteSpace(script))
            {
                MessageBox.Show("Script is empty.", "Empty Script", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clientPIDs = GetReadyClientPIDs();

            if (clientPIDs.Count == 0)
            {
                MessageBox.Show("No ready clients found.\n\nMake sure you've pressed Attach and waited for injection to complete.",
                    "No Ready Clients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Execute(Encoding.UTF8.GetBytes(script + "\0"), clientPIDs.ToArray(), clientPIDs.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Script execution failed:\n{ex.Message}", "Execution Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public Form1()
        {
            InitializeComponent();
            ClientsWindow.Initialize(false);
            onload();
        }

        private async void onload()
        {
            try
            {
                await webView21.EnsureCoreWebView2Async(null);
                webView21.Source = new Uri("https://dark-modz.github.io/Monaco/Editor/index.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void executebtn_Click(object sender, EventArgs e)
        {
            string script = "editor.getValue();";
            string result = await webView21.CoreWebView2.ExecuteScriptAsync(script);
            string finalize = Regex.Unescape(result.Trim('"'));
            ExecuteScriptOnClients(finalize);
        }

        private async void attachbtn_Click(object sender, EventArgs e)
        {
            Attach();
            Thread.Sleep(200);
            Attach();
            Thread.Sleep(200);
            Attach();
            ExecuteScriptOnClients("loadstring(game:HttpGet(\"https://raw.githubusercontent.com/FXSploit/PhotonExecutor/refs/heads/main/notification.lua\"))()");
        }
    }
}
