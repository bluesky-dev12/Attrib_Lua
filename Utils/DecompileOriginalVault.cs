using System;
using System.Diagnostics;
using System.IO;
using UndergroundTools.Core;

namespace Attribulatorulator.Utils
{
    public class DecompileVault
    {
        public static void DecompileTestVault(string Game)
        {
            if (FileSystem.DirectoryExists(FileSystem.TestBranchPath))
            {
                string CompilerPath = FileSystem.AttribulatorPath;

                if (File.Exists(CompilerPath))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(FileSystem.AttribulatorPath, $"unpack -i {FileSystem.TestBranchPath} -o {FileSystem.OriginalVLTPath} -p {Game} -f yml");
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;

                    Process process = Process.Start(startInfo);
                   
                    string output = string.Empty;

                    while ((output = process.StandardOutput.ReadLine()) != null)
                    {
                        Console.WriteLine(output);
                    }

                    process.WaitForExit();

                    MoveLuaForDecompile();
                }
            }
        }

        public static void DecompileFinalVault(string Game)
        {
            if (FileSystem.DirectoryExists(FileSystem.FinalBranchPath))
            {
                string CompilerPath = FileSystem.AttribulatorPath;

                if (File.Exists(CompilerPath))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(FileSystem.AttribulatorPath, $"unpack -i {FileSystem.FinalBranchPath} -o {FileSystem.OriginalVLTPath} -p {Game} -f yml");
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;

                    Process process = Process.Start(startInfo);

                    string output = string.Empty;

                    while ((output = process.StandardOutput.ReadLine()) != null)
                    {
                        Console.WriteLine(output);
                    }

                    process.WaitForExit();

                    MoveLuaForDecompile();
                }
            }
        }

        public static void MoveLuaForDecompile()
        {
            string sourcePath = FileSystem.OriginalVLTPath + "\\main\\gameplay";
            string destinationPath = FileSystem.LuaScriptsPath + "\\Original\\";

            foreach (string directory in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                string blobsPath = Path.Combine(directory, "_blobs");
                if (Directory.Exists(blobsPath))
                {
                    string destinationBlobsPath = Path.Combine(destinationPath, Path.GetFileName(directory) + "\\_blobs");
                    Directory.CreateDirectory(destinationBlobsPath);
                    foreach (string file in Directory.GetFiles(blobsPath, "*.bin"))
                    {
                        string destinationFile = Path.Combine(destinationBlobsPath, Path.GetFileName(file));
                        File.Copy(file, destinationFile, true);
                       
                    }
                }
            }

            DecompileLua.DecompileLuaScript();

            LogWrite.WriteSuccess($"Finished unpacking the vault.");
        }
    }
}
