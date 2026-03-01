using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using XenoUI;

namespace PhotonFinalFr
{
    public partial class Form1 : Form
    {


        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


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
        private void ExecuteScriptOnClients(string script, bool warns)
        {
            if (string.IsNullOrWhiteSpace(script))
            {
                if (!warns)
                {
                    MessageBox.Show("Script is empty.", "Empty Script", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var clientPIDs = GetReadyClientPIDs();

            if (clientPIDs.Count == 0)
            {
                if (!warns )
                {
                    MessageBox.Show("No ready clients found.\n\nMake sure you've pressed Attach and waited for injection to complete.",
                    "No Ready Clients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return;
            }

            try
            {
                Execute(Encoding.UTF8.GetBytes(script + "\0"), clientPIDs.ToArray(), clientPIDs.Count);
            }
            catch (Exception ex)
            {
                if (!warns)
                {
                    MessageBox.Show($"Script execution failed:\n{ex.Message}", "Execution Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
            ExecuteScriptOnClients(finalize, false);
        }

        private async void attachbtn_Click(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, "Roblox");
            ShowWindow(hwnd, SW_MINIMIZE);
            Attach();
            ShowWindow(hwnd, SW_MINIMIZE);
            Thread.Sleep(20);
            ShowWindow(hwnd, SW_MAXIMIZE);
            Attach();
            ShowWindow(hwnd, SW_MAXIMIZE);
            Thread.Sleep(20);
            ExecuteScriptOnClients("loadstring(game:HttpGet(\"https://raw.githubusercontent.com/FXSploit/PhotonExecutor/refs/heads/main/notification.lua\"))()", true);
        }

        private void namelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
