using Microsoft.CodeAnalysis;

namespace Gateway.Application.Contracts.Operations;

public class UpdateAccount
{
    public record Request(
        long AccountId,
        Optional<string> PasswordHash,
        Optional<string> Email);

    public record Response();
}