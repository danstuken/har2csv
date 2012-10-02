namespace Har2Csv
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = GetConfiguration(args);
            var reader = GetInputReader(config);
            var writer = GetOutputWriter(config);
            var webData = ReadInputData(reader);

            DumpWebData(webData, writer);

            if(config.IsInputFileSet)
                reader.Dispose();

            if(config.IsOutputFileSet)
                writer.Dispose();
        }

        private static Configuration GetConfiguration(string[] args)
        {
            var conf = new Configuration();
            for (int x = 0; x < args.Length; x++)
            {
                bool consumedOption = false;

                if (args[x] == "-i")
                {
                    conf.InputFile = args[x + 1];
                    consumedOption = true;
                }

                if (args[x] == "-o")
                {
                    conf.OutputFile = args[x + 1];
                    consumedOption = true;
                }

                if (consumedOption)
                    x++;
            }
            return conf;
        }

        private static dynamic ReadInputData(TextReader reader)
        {
            var json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        private static TextReader GetInputReader(Configuration config)
        {
            if (!config.IsInputFileSet)
                return Console.In;
            return new StreamReader(new FileStream(config.InputFile, FileMode.Open, FileAccess.Read, FileShare.Read));
        }

        private static TextWriter GetOutputWriter(Configuration config)
        {
            if (!config.IsOutputFileSet)
                return Console.Out;
            return new StreamWriter(new FileStream(config.OutputFile, FileMode.Create, FileAccess.Write, FileShare.None));
        }

        private static void DumpWebData(dynamic webData, TextWriter writer)
        {
            var outputWriter = new OutputWriter(writer);
            outputWriter.SendWebData(webData);
        }
    }
}
