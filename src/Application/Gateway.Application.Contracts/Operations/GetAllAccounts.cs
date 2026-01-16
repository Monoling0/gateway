using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Operations;

public class GetAllAccounts
{
    public record Request(
        int PageSize,
        long[]? Ids,
        Roles? Role,
        PageToken? PageToken);

    public record Response(
        IList<Account> Accounts,
        PageToken? PageToken);
}