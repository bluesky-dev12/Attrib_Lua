using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndergroundTools.Core;

namespace Attribulatorulator.Core
{
    public class Backup
    {
        public static void MakeBackupTestBranch()
        {
            // Source directory path
            string sourceDirectoryPath = FileSystem.TestBranchPath;

            string[] filesToBackup = new string[] {
                          sourceDirectoryPath + "/GAMEPLAY.bin",
                          sourceDirectoryPath + "/GAMEPLAY.lzc",
                          sourceDirectoryPath + "/FE_ATTRIB.bin",
                          sourceDirectoryPath + "/ATTRIBUTES.bin",
                        };

            // Create a zip archive
            string backupFilePath = FileSystem.TestBackupPath + $"Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.zip";
            using (ZipArchive zip = ZipFile.Open(backupFilePath, ZipArchiveMode.Create))
            {
                // Add each file to the zip archive
                foreach (string file in filesToBackup)
                {
                    string relativePath = Path.GetRelativePath(sourceDirectoryPath, file);
                    zip.CreateEntryFromFile(file, relativePath);
                }
            }
            LogWrite.WriteInfo($"Backup done called: {$"Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.zip"}");
        }

        public static void MakeBackupFinalBranch()
        {
            string sourceDirectoryPath = FileSystem.FinalBranchPath;

            string[] filesToBackup = new string[] {
                          sourceDirectoryPath + "/GAMEPLAY.bin",
                          sourceDirectoryPath + "/GAMEPLAY.lzc",
                          sourceDirectoryPath + "/FE_ATTRIB.bin",
                          sourceDirectoryPath + "/ATTRIBUTES.bin",
                        };

            // Create a zip archive
            string backupFilePath = FileSystem.TestBackupPath + $"Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.zip";
            using (ZipArchive zip = ZipFile.Open(backupFilePath, ZipArchiveMode.Create))
            {
                // Add each file to the zip archive
                foreach (string file in filesToBackup)
                {
                    string relativePath = Path.GetRelativePath(sourceDirectoryPath, file);
                    zip.CreateEntryFromFile(file, relativePath);
                }
            }
            LogWrite.WriteInfo($"Backup done called: {$"Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.zip"}");
        }
    }
}
