using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UndergroundTools.Core;

namespace Attribulatorulator.Utils
{
	public class CompileLua
    {
        public static void CompileLuaScript()
        {
            string luaDecompilePath = Path.Combine(FileSystem.LuaScriptsPath, "Decompiled");
            string luaCompilePath = Path.Combine(FileSystem.LuaScriptsPath, "Compiled");

            string compilerPath = FileSystem.luaCompilerPath;


            var luaFiles = Directory.GetFiles(luaDecompilePath, "*.*", SearchOption.AllDirectories)
                                    .Where(f => Path.GetExtension(f).Equals(".lua", StringComparison.OrdinalIgnoreCase))
                                    .ToList();

            foreach (var script in luaFiles)
            {
                string scriptName = Path.GetFileNameWithoutExtension(script);

                // Get relative path from the decompiled root
                string relativeDir = Path.GetDirectoryName(script)!
                                         .Replace(luaDecompilePath, "")
                                         .Trim(Path.DirectorySeparatorChar);

                string finalPath = Path.Combine(luaCompilePath, relativeDir);
                Directory.CreateDirectory(finalPath);

                string outputFile = Path.Combine(finalPath, scriptName + ".bin");

                var startInfo = new ProcessStartInfo
                {
                    FileName = compilerPath,
                    Arguments = $"-o \"{outputFile}\" \"{script}\"",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                try
                {
                    using (Process process = Process.Start(startInfo)!)
                    {
                        string stderr = process.StandardError.ReadToEnd();
                        string stdout = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();

                        if (!string.IsNullOrWhiteSpace(stderr))
                            LogWrite.WriteError($"Error compiling {scriptName}: {stderr}");

                        if (!string.IsNullOrWhiteSpace(stdout))
                            LogWrite.WriteInfo($"Compiler output for {scriptName}: {stdout}");

                        LogWrite.WriteInfo($"Successfully compiled {scriptName}.");
                    }
                }
                catch (Exception ex)
                {
                    LogWrite.WriteError($"Exception during compilation of {scriptName}: {ex.Message}");
                }
            }

            MoveLuaCompile();
        }

        public static void MoveLuaCompile()
        {
            string sourcePath = FileSystem.LuaScriptsPath + "\\Compiled\\";
            string destinationPath = FileSystem.OriginalVLTPath + "\\main\\gameplay";

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
        }
    }
}
