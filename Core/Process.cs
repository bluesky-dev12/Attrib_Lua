using System;
using UndergroundTools.Core;
using static System.Diagnostics.Process;

namespace Attribulatorulator
{
	public static class _Process
	{
		public static bool Create(string path, string arguments)
		{
			try
			{
				var process = Start(path, arguments);

				process.WaitForExit();

				var exitCode = process.ExitCode;
				var result = exitCode == 0;

                if (!result)
				{
					LogWrite.WriteError($"Process {path} exited with code {exitCode}.");
				}

				return result;
			}
			catch (Exception e)
			{
                LogWrite.WriteError($"An exception occurred while attempting to create process {path}.");
                LogWrite.WriteError(e.Message);
			}

			return false;
		}
	}
}
