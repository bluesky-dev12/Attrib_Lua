using System;
using UndergroundTools.Core;
using Attribulatorulator.Utils;

namespace Attribulatorulator
{
	public class Program
	{

		static void Main(string[] args)
		{
            Console.Title = "Attribulatorator";
            LogWrite.WriteInfo("===============================================================================");
            LogWrite.WriteInfo("|                      Attribulatorator by BlueSky                            |");
            LogWrite.WriteInfo("|                 Created originally by rx - NFSCO Owner                      |");
            LogWrite.WriteInfo("===============================================================================");

            if (args.Length == 0)
			{
				Console.WriteLine("Please provide an option:");
				Console.WriteLine("  -CompileFinal: Compiles the final branch.");
				Console.WriteLine("  -DecompileFinalBranch: Create a new file");
				Console.WriteLine("  -CompileTestBranch: Compiles the test branch");
				Console.WriteLine("  -CompileLua: Compiles lua.");
                Console.WriteLine("  -CompileNFSMS: Compiles NFSMS.");
                return;
			}

			switch (args[0])
			{
                case "-DecompileTestBranch":
					DecompileVault.DecompileTestVault(args[1]);
                    break;
                case "-CompileTestBranch":
                    CompileBranchVault.CompileTestVault(args[1]);
                    break;
                case "-DecompileFinalBranch":
                    DecompileVault.DecompileFinalVault(args[1]);
                    break;
                case "-CompileFinalBranch":
                    CompileBranchVault.CompileFinalVault(args[1]);
                    break;
                case "-CompileNFSMS":
					BuildNFSMS.CompileNFSScript();
                    break;
				default:
					LogWrite.WriteError("Invalid option. Please use -h for help.");
					break;
			}
		}
	}
}
