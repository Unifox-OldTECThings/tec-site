﻿namespace tec_site
{
    using System;
    using System.IO;

    public static class DotEnv
    {
        public static void Load(string filePath)
        {
            Console.WriteLine(".env exists? " + File.Exists(filePath));

            if (!File.Exists(filePath))
            {
                Console.WriteLine("error, no .env");
                return;
            }

            Console.WriteLine(".env exists");

            foreach (var line in File.ReadAllLines(filePath))
            {
                Console.WriteLine(line);
                var parts = line.Split(
                    " = ",
                    StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(parts.Length);
                if (parts.Length != 2)
                    continue;
                Console.WriteLine("'"+parts[0]+"'" +"'"+parts[1]+"'");
                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }

        public static void Write(string filePath, string variables)
        {
            string[] filecont = File.ReadAllLines(filePath);
            filecont = filecont.SkipLast(1).ToArray();
            filecont = filecont.Append(variables).ToArray();
            File.WriteAllLines(filePath, filecont);
        }
    }
}
