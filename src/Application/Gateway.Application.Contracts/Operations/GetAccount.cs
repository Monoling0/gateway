using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Operations;

public static class GetAccount
{
    public record Response(Account Account);
}