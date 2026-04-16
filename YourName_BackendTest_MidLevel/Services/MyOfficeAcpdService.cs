using Dapper;
using System.Data;

namespace BackendTest_MidLevel.Services;

public class MyOfficeAcpdService
{
    public static async Task<string> GetNewSid(IDbConnection dbConnection)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@TableName", "Test");
        parameters.Add("@ReturnSID", dbType: DbType.String, size: 20, direction: ParameterDirection.Output);

        await dbConnection.ExecuteAsync("NEWSID", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<string>("@ReturnSID");
    }
}
