using System;
using System.Diagnostics;
using System.IO;
using UndergroundTools.Core;


namespace Attribulatorulator.Utils
{
    public class DecompileLua
    {
        public static void DecompileLuaScript()
        {
            string BinLuaCompilerFilePath = FileSystem.LuaScriptsPath + "/Original/";
            string BinLuaDecompilerFilePath = FileSystem.LuaScriptsPath + "/Decompiled/";

            if (FileSystem.DirectoryExists(BinLuaCompilerFilePath))
            {
                string DecompilerPath = FileSystem.LuaDecompilerPath;

                if (File.Exists(DecompilerPath))
                {
                    foreach (var script in Directory.GetFiles(BinLuaCompilerFilePath, "*.bin", SearchOption.AllDirectories))
                    {
                        string scriptName = Path.GetFileNameWithoutExtension(script);
                        string finalPath = BinLuaDecompilerFilePath + Path.GetDirectoryName(script).Replace("..\\..\\Files\\UnpackVLT\\Lua\\Original", string.Empty) + "\\";

                        Directory.CreateDirectory(finalPath);

                        ProcessStartInfo startInfo = new ProcessStartInfo("../java/Java.exe", $"-jar {DecompilerPath} {script} --output {finalPath}{scriptName}.lua");
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;

                        Process process = Process.Start(startInfo);
                        process.WaitForExit();

                        LogWrite.WriteInfo($"Decompiled {scriptName}");
                    }
                }
            }
        }
    }
}
