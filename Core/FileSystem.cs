using System;
using System.IO;
using UndergroundTools.Core;

namespace Attribulatorulator
{
	public static class FileSystem
	{
        public static readonly string AttribulatorPath = @"..\Attribulator\Attribulator.CLI.exe";
        public static readonly string LuaDecompilerPath = @"..\Lua\unluac.jar";
        public static readonly string luaCompilerPath = @"..\Lua\LuaCompiler.exe";
        public static readonly string TestBranchPath = @"..\..\TestBranch\Game\Global";
        public static readonly string TestBranchBackupsPath = @"..\..\TestBranch\Backups";
        public static readonly string FinalBranchPath = @"..\..\FinalBranch\Game\Global";
        public static readonly string FinalBranchBackupsPath = @"..\..\FinalBranch\Backups";
        public static readonly string LuaScriptsPath = @"..\..\Files\UnpackVLT\Lua";
        public static readonly string OriginalVLTPath = @"..\..\Files\UnpackVLT\Vault";
        public static readonly string ScriptPath = @"..\..\Files\UnpackVLT\Scripts";
        public static readonly string TestBackupPath = @"..\..\TestBranch\Backups\";
        public static readonly string TestCompilePath = @"..\..\TestBranch\Compile\";
        
		public static FileInfo CopyFile(FileInfo info, string dstPath)
		{
			try
			{
				return info.CopyTo(dstPath, true);
			}
			catch (Exception e)
			{
				LogWrite.WriteError($"An exception occurred while attempting to copy file {info.Name}.");
				LogWrite.WriteError(e.Message);
			}

			return null;
		}

		public static bool DirectoryExists(string path) => Directory.Exists(path);


        public static bool SetCurrentDirectory(string path)
		{
			try
			{
				Directory.SetCurrentDirectory(path);

				return true;
			}
			catch (Exception e)
			{
				LogWrite.WriteError($"An exception occurred while attempting to change the current directory to {path}.");
				LogWrite.WriteError(e.Message);
			}

			return false;
		}

		public static DirectoryInfo CreateDirectory(string path)
		{
			try
			{
				return Directory.CreateDirectory(path);
			}
			catch (Exception e)
			{
				LogWrite.WriteError($"An exception occurred while attempting to create directory {path}.");
				LogWrite.WriteError(e.Message);
			}

			return null;
		}

		public static bool DeleteDirectory(string path, bool isRecursive)
		{
			if (DirectoryExists(path))
			{
				try
				{
					Directory.Delete(path, isRecursive);

					return true;
				}
				catch (Exception e)
				{
					LogWrite.WriteError($"An exception occurred while attempting to delete directory {path}.");
					LogWrite.WriteError(e.Message);
				}
			}
			else
			{
				LogWrite.WriteInfo($"Directory {path} does not exist.");

				return true;
			}

			return false;
		}

		public static bool CopyDirectory(string srcPath, string dstPath, bool copySubDirectories)
		{
			try
			{
				var srcDirectory = new DirectoryInfo(srcPath);

				if (srcDirectory.Exists)
				{
					var dstDirectory = CreateDirectory(dstPath);

					if (dstDirectory is not null)
					{
						foreach (var file in srcDirectory.GetFiles())
						{
							if (CopyFile(file, Path.Combine(dstPath, file.Name)) is null)
							{
								return false;
							}
						}

						if (copySubDirectories)
						{
							foreach (var subDirectory in srcDirectory.GetDirectories())
							{
								if (!CopyDirectory(subDirectory.FullName, Path.Combine(dstPath, subDirectory.Name), copySubDirectories))
								{
									return false;
								}
							}
						}

						return true;
					}
				}
				else
				{
					LogWrite.WriteInfo($"Directory {srcPath} does not exist.");
				}
			}
			catch (Exception e)
			{
				LogWrite.WriteError($"An exception occurred while attempting to copy directory {srcPath} to directory {dstPath}.");
				LogWrite.WriteError(e.Message);
			}

			return false;
		}
	}
}
