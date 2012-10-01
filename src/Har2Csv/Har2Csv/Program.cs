namespace Har2Csv
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var sampleJson = new StreamReader(new FileStream(@"samples\www.xkcd.com.har", FileMode.Open, FileAccess.Read, FileShare.Read)).ReadToEnd();
            //var webData = JsonConvert.DeserializeObject<dynamic>(sampleJson);
            var webData = JObject.Parse(sampleJson);
            DumpWebData(webData);
        }

        //private static void DumpWebData(dynamic webData)
        private static void DumpWebData(JObject webData)
        {
            foreach (var entry in webData["entries"])
            {
                Console.WriteLine("{0}", entry["request"]["method"] );
            }
        }
    }
}
