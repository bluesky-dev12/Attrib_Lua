using Attribulatorulator.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using UndergroundTools.Core;

namespace Attribulatorulator.Utils
{
    public class BuildNFSMS
    {
        public static void CompileNFSScript()
        {
            if (FileSystem.DirectoryExists(FileSystem.ScriptPath))
            {
                string DecompilerPath = FileSystem.LuaDecompilerPath;

                if (File.Exists(DecompilerPath))
                {
                    foreach (var script in Directory.GetFiles(FileSystem.ScriptPath, "*.nfsms", SearchOption.AllDirectories))
                    {
                        string scriptName = Path.GetFileNameWithoutExtension(script);
                        LogWrite.WriteData($"Aplying script: {scriptName}.nfsms");

                        ProcessStartInfo startInfo = new ProcessStartInfo(FileSystem.AttribulatorPath, $"apply-script-bin -i {FileSystem.TestBranchPath} -o {FileSystem.TestCompilePath} -p MW -s {script}");
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;

                        Process process = Process.Start(startInfo);

                        string output = string.Empty;
                        while ((output = process.StandardOutput.ReadLine()) != null)
                        {
                            Console.WriteLine(output);
                        }

                        process.WaitForExit();

                        Backup.MakeBackupTestBranch();
                        MoveFiles();
                    }
                }
            }
        }
        public static void MoveFiles()
        {
            LogWrite.WriteInfo("Moving files...");
            string sourcePath = FileSystem.TestCompilePath + "/Main";
            string targetPath = FileSystem.TestBranchPath;

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string fileName = Path.GetFileName(file);
                string targetFile = Path.Combine(targetPath, fileName);
                File.Move(file, targetFile, true);
            }
            LogWrite.WriteInfo("Done.");
        }

    }
}
