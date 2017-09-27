#r "Microsoft.Graph"
using Microsoft.Graph;
using System.Net;

public static async Task Run(Message msg, TraceWriter log)  
{
    if (msg.Subject.Contains("Microsoft Ignite") && msg.From.EmailAddress.Name == "Matthew Henderson") {
        log.Info($"Processed email: {msg.BodyPreview}");
    }
}