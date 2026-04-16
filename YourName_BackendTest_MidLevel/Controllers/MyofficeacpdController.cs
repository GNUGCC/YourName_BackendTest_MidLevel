using Dapper;
using System.Data;
using Microsoft.AspNetCore.Mvc;

using BackendTest_MidLevel.Models;
using YourName_BackendTest_MidLevel;
using BackendTest_MidLevel.Services;

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
    public async Task Add([FromBody] MyOfficeAcpd myOfficeAcpd)
    {
        var sid = await MyOfficeAcpdService.GetNewSid(dbConnection);
        await dbConnection.ExecuteAsync(@"
INSERT INTO MyOffice_ACPD (
    ACPD_SID,
    ACPD_Cname,
    ACPD_Ename,
    ACPD_Sname,
    ACPD_Email,
    ACPD_Status,
    ACPD_Stop,
    ACPD_StopMemo,
    ACPD_LoginID,
    ACPD_LoginPWD,
    ACPD_Memo,
    ACPD_NowDateTime,
    ACPD_NowID,
    ACPD_UPDDateTime,
    ACPD_UPDID
)
VALUES (
    @ACPD_SID,
    @ACPD_Cname,
    @ACPD_Ename,
    @ACPD_Sname,
    @ACPD_Email,
    @ACPD_Status,
    @ACPD_Stop,
    @ACPD_StopMemo,
    @ACPD_LoginID,
    @ACPD_LoginPWD,
    @ACPD_Memo,
    GETDATE(),
    @ACPD_NowID,
    GETDATE(),
    @ACPD_UPDID
);",
new
{
    ACPD_SID = sid,
    myOfficeAcpd.ACPD_Cname,
    myOfficeAcpd.ACPD_Ename,
    myOfficeAcpd.ACPD_Sname,
    myOfficeAcpd.ACPD_Email,
    myOfficeAcpd.ACPD_Status,
    myOfficeAcpd.ACPD_Stop,
    myOfficeAcpd.ACPD_StopMemo,
    myOfficeAcpd.ACPD_LoginID,
    myOfficeAcpd.ACPD_LoginPWD,    
    myOfficeAcpd.ACPD_Memo,
    myOfficeAcpd.ACPD_NowDateTime,
    myOfficeAcpd.ACPD_NowID,
    myOfficeAcpd.ACPD_UPDDateTime,
    myOfficeAcpd.ACPD_UPDID   
});
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
