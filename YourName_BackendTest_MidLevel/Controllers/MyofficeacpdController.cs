using Dapper;
using System.Data;
using Microsoft.AspNetCore.Mvc;

using BackendTest_MidLevel.Models;
using YourName_BackendTest_MidLevel;

namespace BackendTest_MidLevel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MyofficeacpdController(IDbConnection dbConnection) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<MyOfficeAcpd>> Get()
    {
        return await dbConnection.QueryAsync<MyOfficeAcpd>("select * from MyOffice_ACPD");
    }

    [HttpGet("{id}")]
    public async Task<IEnumerable<MyOfficeAcpd>> GetById(string id)
    {
        return await dbConnection.QueryAsync<MyOfficeAcpd>($"select * from MyOffice_ACPD where ACPD_NowID = {id}");
    }

    [HttpPost]
    public IEnumerable<MyOfficeAcpd> Add([FromBody] MyOfficeAcpd myOfficeAcpd)
    {        
        return default;
    }

    [HttpPut("{id}")]
    public IEnumerable<MyOfficeAcpd> Put(string id, [FromBody] MyOfficeAcpd myOfficeAcpd)
    {
        return default;
    }

    [HttpDelete("{id}")]
    public IEnumerable<MyOfficeAcpd> Delete(string id)
    {
        return default;
    }
}
