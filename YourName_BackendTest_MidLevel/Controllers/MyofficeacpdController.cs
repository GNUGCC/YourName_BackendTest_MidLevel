using Microsoft.AspNetCore.Mvc;
using BackendTest_MidLevel.Models;
using YourName_BackendTest_MidLevel;

namespace BackendTest_MidLevel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MyofficeacpdController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return default;
    }

    [HttpGet("{id}")]
    public IEnumerable<WeatherForecast> GetById(string id)
    {
        return default;
    }

    [HttpPost]
    public IEnumerable<WeatherForecast> Post([FromBody] MyOfficeAcpd myOfficeAcpd)
    {
        return default;
    }

    [HttpPut("{id}")]
    public IEnumerable<WeatherForecast> Put(string id, [FromBody] MyOfficeAcpd myOfficeAcpd)
    {
        return default;
    }

    [HttpDelete("{id}")]
    public IEnumerable<WeatherForecast> Delete(string id)
    {
        return default;
    }
}
