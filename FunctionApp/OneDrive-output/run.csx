using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives; 

public static async Task<IActionResult> Run(HttpRequest req, IAsyncCollector<byte[]> myOneDriveFile, TraceWriter log)
{
    string data = req.Query
        .FirstOrDefault(q => string.Compare(q.Key, "text", true) == 0)
        .Value;
    await myOneDriveFile.AddAsync(Encoding.UTF8.GetBytes(data));
    return new OkObjectResult(data); 
}