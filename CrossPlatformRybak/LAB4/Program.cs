using McMaster.Extensions.CommandLineUtils;
using LAB4_LIB;

namespace Lab4
{
    class Program
    {
        static int Main(string[] args)
            => CommandLineApplication.Execute<ConsoleApp>(args);
    }

    [Command(Description = "Cross platform console util")]
    [Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
    class ConsoleApp
    {
        private void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine("Use a command or --help for available options.");
        }
    }

    [Command(Name = "version", Description = "Display version information")]
    class VersionCommand
    {
        private void OnExecute()
        {
            Console.WriteLine("Author: Semen Rybak");
            Console.WriteLine("Version: 1.0");
        }
    }

    [Command(Name = "run", Description = "Run a specific lab")]
    class RunCommand
    {
        [Option("-I|--input", Description = "Input file path")]
        private string InputPath { get; } = null!;

        [Option("-o|--output", Description = "Output file path")]
        private string OutputPath { get; } = null!;

        [Argument(0, Description = "The lab to run (e.g., lab1, lab2)")]
        private string LabName { get; } = null!;

        private void OnExecute()
        {
            if (string.IsNullOrWhiteSpace(LabName))
            {
                Console.WriteLine("Specify a lab to run (e.g., lab1).");
                return;
            }

            var inputPath = Helpers.ResolvePath(InputPath, "input.txt");
            var outputPath = Helpers.ResolvePath(InputPath, "output.txt");

            switch (LabName)
            {
                case "lab1":
                    Lab1.Run(inputPath, outputPath);
                    break;
                case "lab2":
                    Lab2.Run(inputPath, outputPath);
                    break;
                case "lab3":
                    Lab3.Run(inputPath, outputPath);
                    break;
            }
        }
    }

    [Command(Name = "set-path", Description = "Set the path for input and output files")]
    class SetPathCommand
    {
        [Option("-p|--path", Description = "Path to the directory with input and output files")]
        private string Path { get; } = null!;

        private void OnExecute()
        {
            Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
            Console.WriteLine($"LAB_PATH set to: {Path}");
        }
    }

    static class Helpers
    {
        public static string ResolvePath(string providedPath, string defaultFileName)
        {
            if (!string.IsNullOrWhiteSpace(providedPath) && File.Exists(providedPath))
            {
                return providedPath;
            }

            var labPath = Environment.GetEnvironmentVariable("LAB_PATH",EnvironmentVariableTarget.User);

            if (!string.IsNullOrWhiteSpace(labPath))
            {
                var envFilePath = Path.Combine(labPath, defaultFileName);

                if (File.Exists(envFilePath))
                {
                    return envFilePath;
                }
            }
            
            var userHomeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var defaultFilePath = Path.Combine(userHomeDirectory, defaultFileName);
            
            if (File.Exists(defaultFilePath))
            {
                return defaultFilePath;
            }

            throw new FileNotFoundException();
        }
    }
}