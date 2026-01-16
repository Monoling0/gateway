namespace Gateway.Application.Contracts.Operations;

public class GetPasswordHash
{
    public record Response(string PasswordHash);
}