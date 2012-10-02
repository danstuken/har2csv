namespace Har2Csv
{
    public class Configuration
    {
        public string InputFile { get; set; }
        public string OutputFile { get; set; }

        public bool IsInputFileSet
        {
            get { return !string.IsNullOrEmpty(InputFile); }
        }

        public bool IsOutputFileSet
        {
            get { return !string.IsNullOrEmpty(OutputFile); }
        }
    }
}