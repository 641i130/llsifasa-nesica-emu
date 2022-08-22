using System.Net.Mime;
using System.Text;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Swan.Logging;

namespace GCLocalServerRewrite.controllers;

public class IncomServiceController : WebApiController
{
    [Route(HttpVerbs.Post, "/incom.php")]
    // ReSharper disable once UnusedMember.Global
    public string IncomService()
    {
        HttpContext.Response.ContentType = MediaTypeNames.Text.Plain;
        HttpContext.Response.ContentEncoding = new UTF8Encoding(false);
        HttpContext.Response.KeepAlive = true;

        return "1+1";
    }

    [Route(HttpVerbs.Post, "/incomALL.php")]
    // ReSharper disable once UnusedMember.Global
    public async Task<string> IncomAllService()
    {
        string data = await HttpContext.GetRequestBodyAsStringAsync();
        
        $"IncomAllService received data: {data}".Info();
        
        HttpContext.Response.ContentType = MediaTypeNames.Text.Plain;
        HttpContext.Response.ContentEncoding = new UTF8Encoding(false);
        HttpContext.Response.KeepAlive = true;

        return "1+1";
    }
}