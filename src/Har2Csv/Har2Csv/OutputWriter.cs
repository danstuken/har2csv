namespace Har2Csv
{
    using System.IO;

    public class OutputWriter
    {
        private readonly TextWriter _outputWriter;

        public OutputWriter(TextWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        public void SendWebData(dynamic webData)
        {
            _outputWriter.WriteLine("Method,Url,Status,Time - Blocked,Time - DNS,Time - Connect,Time - Send,Time - Wait,Time - Receive,Time - SSL,Size (Bytes)");
            foreach (var entry in webData.log.entries)
            {
                _outputWriter.WriteLine("{0},\"{1}\",{2},{3},{4},{5},{6},{7},{8},{9},{10}", 
                    entry.request.method,
                    entry.request.url,
                    entry.response.status,
                    entry.timings.blocked,
                    entry.timings.dns,
                    entry.timings.connect,
                    entry.timings.send,
                    entry.timings.wait,
                    entry.timings.receive,
                    entry.timings.ssl,
                    entry.response.content.size
                    );
            }
        }
    }
}