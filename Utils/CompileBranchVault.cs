using Attribulatorulator.Core;
using System;
using System.Diagnostics;
using System.IO;
namespace Attribulatorulator.Utils
{
    public class CompileBranchVault
    {
        public static void CompileTestVault(string Game)
        {
            Backup.MakeBackupTestBranch();

            CompileLua.CompileLuaScript();

            if (FileSystem.DirectoryExists(FileSystem.TestBranchPath))
            {
                string CompilerPath = FileSystem.AttribulatorPath;

                if (File.Exists(CompilerPath))
                {

                    ProcessStartInfo startInfo = new ProcessStartInfo(FileSystem.AttribulatorPath, $"pack -i {FileSystem.OriginalVLTPath} -o {FileSystem.TestBranchPath} -p {Game}");
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true; 

                    // Generate a timestamp for the log file (Seconds-Hour-Date)
                    string timestamp = DateTime.Now.ToString("ss-HH-ddMMyyyy");
                    string logFilePath = $"log_{timestamp}.txt"; // The log file will be named like log_30-14-11092023.txt

                    // Open a StreamWriter to write the log to a file
                    using (StreamWriter writer = new StreamWriter(logFilePath))
                    {
                        Process process = Process.Start(startInfo);

                        string output = string.Empty;

                        while ((output = process.StandardOutput.ReadLine()) != null)
                        {
                            // Write output to the console
                            Console.WriteLine(output);

                            // Write the same output to the log file
                            writer.WriteLine(output);
                        }

                        process.WaitForExit();
                    }
                }
            }
        }

        public static void CompileFinalVault(string Game)
        {
            Backup.MakeBackupFinalBranch();

            CompileLua.CompileLuaScript();

            if (FileSystem.DirectoryExists(FileSystem.FinalBranchPath))
            {
                string CompilerPath = FileSystem.AttribulatorPath;

                if (File.Exists(CompilerPath))
                {

                    ProcessStartInfo startInfo = new ProcessStartInfo(FileSystem.AttribulatorPath, $"pack -i {FileSystem.OriginalVLTPath} -o {FileSystem.FinalBranchPath} -p {Game}");
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;

                    // Generate a timestamp for the log file (Seconds-Hour-Date)
                    string timestamp = DateTime.Now.ToString("ss-HH-ddMMyyyy");
                    string logFilePath = $"log_{timestamp}.txt"; // The log file will be named like log_30-14-11092023.txt

                    // Open a StreamWriter to write the log to a file
                    using (StreamWriter writer = new StreamWriter(logFilePath))
                    {
                        Process process = Process.Start(startInfo);

                        string output = string.Empty;

                        while ((output = process.StandardOutput.ReadLine()) != null)
                        {
                            // Write output to the console
                            Console.WriteLine(output);

                            // Write the same output to the log file
                            writer.WriteLine(output);
                        }

                        process.WaitForExit();
                    }
                }
            }
        }
    }
}
