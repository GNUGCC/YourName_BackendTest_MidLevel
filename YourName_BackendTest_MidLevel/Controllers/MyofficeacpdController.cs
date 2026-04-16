using Dapper;
using System.Data;
using Microsoft.AspNetCore.Mvc;

using BackendTest_MidLevel.Models;
using YourName_BackendTest_MidLevel;
using BackendTest_MidLevel.Services;
using System.Reflection;

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
        return await dbConnection.QueryAsync<MyOfficeAcpd>($"select * from MyOffice_ACPD where ACPD_SID = '{id}'");
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] MyOfficeAcpd myOfficeAcpd)
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

        return CreatedAtAction(nameof(Add), new { sid });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] MyOfficeAcpd myOfficeAcpd)
    {
        myOfficeAcpd.ACPD_SID = id;
        var rows = await dbConnection.ExecuteAsync(@"
UPDATE MyOffice_ACPD
SET
    ACPD_Cname = @ACPD_Cname,
    ACPD_Ename = @ACPD_Ename,
    ACPD_Sname = @ACPD_Sname,
    ACPD_Email = @ACPD_Email,
    ACPD_Status = @ACPD_Status,
    ACPD_Stop = @ACPD_Stop,
    ACPD_StopMemo = @ACPD_StopMemo,
    ACPD_LoginID = @ACPD_LoginID,
    ACPD_LoginPWD = @ACPD_LoginPWD,
    ACPD_Memo = @ACPD_Memo,
    ACPD_UPDDateTime = GETDATE(),
    ACPD_UPDID = @ACPD_UPDID
WHERE ACPD_SID = @ACPD_SID
", myOfficeAcpd);

        if (rows == 0) return NotFound();
        return Ok(new { success = true });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var rows = await dbConnection.ExecuteAsync($"DELETE MyOffice_ACPD WHERE ACPD_SID = {id}");
        if (rows == 0) return NotFound();
        return Ok(new { success = true });
    }
}
