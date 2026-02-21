//  CONVERT OLD SHITTY PYTHON BOOTSTRAPPER TO C#!!!!
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    private static readonly string VERSION_URL = "https://raw.githubusercontent.com/FXSploit/PhotonExecutor/refs/heads/main/version.txt";

    private static readonly string APP_URL = "https://raw.githubusercontent.com/FXSploit/PhotonExecutor/refs/heads/main/PhotonExecutor.zip";

    private static readonly string APP_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PhotonExc");

    private static readonly string EXE_PATH = Path.Combine(APP_FOLDER, "PhotonExecutor.exe");

    private static readonly string VERSION_FILE = Path.Combine(APP_FOLDER, "version.txt");

    static async Task Main()
    {
        Console.WriteLine("[ BOOTSTRAPPER ] Start...");

        if (!IsInstalled())
        {
            Console.WriteLine("[ BOOTSTRAPPER ] Installing...");
            await Install();
        }
        else
        {
            if (!await CheckUpdate())
            {
                await Install(update: true);
            }
        }

        RunApp();
    }

    static bool IsInstalled()
    {
        if (File.Exists(EXE_PATH))
        {
            Console.WriteLine("[ SET ] Installed");
            return true;
        }
        return false;
    }

    static async Task<bool> CheckUpdate()
    {
        Console.WriteLine("[ BOOTSTRAPPER ] Checking update...");

        if (!File.Exists(VERSION_FILE))
            return false;

        string installedVersion = File.ReadAllText(VERSION_FILE);

        using HttpClient client = new HttpClient();
        string cloudVersion = (await client.GetStringAsync(VERSION_URL)).Trim();

        installedVersion = installedVersion.Trim();

        Console.WriteLine($"[ BOOTSTRAPPER ] CloudVer: {cloudVersion} | InstalledVer: {installedVersion}");

        if (cloudVersion == installedVersion)
        {
            Console.WriteLine("[ BOOTSTRAPPER ] Up-to-Date!");
            return true;
        }

        Console.WriteLine("[ BOOTSTRAPPER ] Outdated!");
        return false;
    }

    static async Task Install(bool update = false)
    {
        if (update && Directory.Exists(APP_FOLDER))
        {
            Console.WriteLine("[ BOOTSTRAPPER ] Removing old version...");
            Directory.Delete(APP_FOLDER, true);
        }

        Console.WriteLine("[ BOOTSTRAPPER ] Creating folder...");
        Directory.CreateDirectory(APP_FOLDER);

        Console.WriteLine("[ BOOTSTRAPPER ] Downloading ZIP...");

        using HttpClient client = new HttpClient();
        byte[] zipBytes = await client.GetByteArrayAsync(APP_URL);

        string zipPath = Path.Combine(APP_FOLDER, "temp.zip");
        File.WriteAllBytes(zipPath, zipBytes);

        Console.WriteLine("[ BOOTSTRAPPER ] Extracting ZIP...");
        ZipFile.ExtractToDirectory(zipPath, APP_FOLDER);

        File.Delete(zipPath);

        string cloudVersion = (await client.GetStringAsync(VERSION_URL)).Trim();
        File.WriteAllText(VERSION_FILE, cloudVersion);

        Console.WriteLine("[ DONE ] Installed / Updated.");
    }

    static void RunApp()
    {
        Console.WriteLine("[ BOOTSTRAPPER ] Run app...");

        Process.Start(new ProcessStartInfo
        {
            FileName = EXE_PATH,
            UseShellExecute = true
        });
    }
}
