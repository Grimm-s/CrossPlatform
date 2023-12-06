using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB13.Controllers;

[ApiController]
[Route("lab")]
[Authorize]
public class LabController : ControllerBase
{
    [HttpPost("lab1")]
    public async Task<IActionResult> Lab1()
    {
        using var reader = new StreamReader(Request.Body);
        var input = await reader.ReadToEndAsync();
        return Ok(LAB5_LIB.Lab1.Run(input));
    }


    [HttpPost("lab2")]
    public async Task<IActionResult> Lab2()
    {
        using var reader = new StreamReader(Request.Body);
        var input = await reader.ReadToEndAsync();
        return Ok(LAB5_LIB.Lab2.Run(input));
    }

    [HttpPost("lab3")]
    public async Task<IActionResult> Lab3()
    {
        using var reader = new StreamReader(Request.Body);
        var input = await reader.ReadToEndAsync();
        return Ok(LAB5_LIB.Lab3.Run(input));
    }
}