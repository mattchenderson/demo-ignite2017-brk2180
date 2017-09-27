using System.Net;
using System.Text;

public static async Task Run(HttpRequest req, IAsyncCollector<byte[]> myOneDriveFile, TraceWriter log)
{
    string data = req.Query
        .FirstOrDefault(q => string.Compare(q.Key, "text", true) == 0)
        .Value;
    await myOneDriveFile.AddAsync(Encoding.UTF8.GetBytes(data));
    return;
}