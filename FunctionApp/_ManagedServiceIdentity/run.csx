using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives; 

public static HttpResponseMessage Run(HttpRequest req, TraceWriter log)
{
    string resource = req.Query
        .FirstOrDefault(q => string.Compare(q.Key, "resource", true) == 0)
        .Value;
    string apiversion = req.Query
        .FirstOrDefault(q => string.Compare(q.Key, "apiversion", true) == 0)
        .Value;
    return GetToken(resource, apiversion);
}

public static async Task<HttpResponseMessage> GetToken(string resource, string apiversion)  {
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("Secret", Environment.GetEnvironmentVariable("MSI_SECRET"));
    return await client.GetAsync(String.Format("{0}/?resource={1}&api-version={2}", Environment.GetEnvironmentVariable("MSI_ENDPOINT"), resource, apiversion));
}