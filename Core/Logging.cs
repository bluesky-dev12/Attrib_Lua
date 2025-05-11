using System;
using System.Diagnostics;

namespace UndergroundTools.Core
{
	/// <summary>
	/// Writes the log to the console and to the file.
	/// </summary>
	public class LogWrite
	{
		private static void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
		{
			try
			{
				string timestamp = $"[{DateTime.Now.ToLongTimeString()}] ";
				string timestampedMessage = $"{timestamp}{message}";

				// Set the color before printing the message
				Console.ForegroundColor = color;
				Console.WriteLine(timestampedMessage);
				Console.ResetColor();

				Debug.WriteLine(timestampedMessage);
			}
			catch (FormatException ex)
			{
				// Log the error and provide additional context
				Console.WriteLine($"Error formatting log message: {ex.Message}");
				Console.WriteLine($"Message: {message}");
			}
		}

		public static void WriteStringDataArray(string name, string[] message)
		{
			WriteLine($"{name}:", ConsoleColor.Blue);
			for (int i = 0; i < message.Length; i++)
			{
				WriteLine($"{name}[{i}]: {message[i]}", ConsoleColor.Blue);
			}
		}

		public static void WriteByteDataArray(string name, byte[] message)
		{
			WriteLine($"{name}:", ConsoleColor.Blue);
			for (int i = 0; i < message.Length; i++)
			{
				WriteLine($"{name}[{i}]: {message[i]}", ConsoleColor.Blue);
			}
		}

		public static void WriteIntDataArray(string name, int[] message)
		{
			WriteLine($"{name}:", ConsoleColor.Blue);
			for (int i = 0; i < message.Length; i++)
			{
				WriteLine($"{name}[{i}]: {message[i]}", ConsoleColor.Blue);
			}
		}

		public static void WriteFloatDataArray(string name, float[] message)
		{
			WriteLine($"{name}:", ConsoleColor.Blue);
			for (int i = 0; i < message.Length; i++)
			{
				WriteLine($"{name}[{i}]: {message[i]}", ConsoleColor.Blue);
			}
		}

		public static void WriteError(string message)
		{
			WriteLine(message, ConsoleColor.Red);
		}

		public static void WriteSuccess(string message)
		{
			WriteLine(message, ConsoleColor.Green);
		}

		public static void WriteInfo(string message)
		{
			WriteLine(message);
		}

		public static void WriteData(string message)
		{
			WriteLine(message, ConsoleColor.Blue);
		}
	}
}
