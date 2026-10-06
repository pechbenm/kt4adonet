using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace кт4.Controllers;

public class EchoController : Controller
{
    [HttpGet]
    public async Task Get()
    {
        Response.ContentType = "text/plain";
        await Response.WriteAsync("GET request received");
    }

    [HttpPost]
    public async Task Post()
    {
        Response.ContentType = "text/plain";
        await Response.WriteAsync("POST request received");
    }

    public async Task Headers()
    {
        var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

        Response.ContentType = "application/json";
        await Response.WriteAsJsonAsync(headers);
    }

    public async Task Query()
    {
        var query = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());

        Response.ContentType = "application/json";
        await Response.WriteAsJsonAsync(query);
    }

    public async Task Body()
    {
        using var reader = new StreamReader(Request.Body, Encoding.UTF8);
        var body = await reader.ReadToEndAsync();

        Response.ContentType = "text/plain";
        await Response.WriteAsync(body);
    }
}