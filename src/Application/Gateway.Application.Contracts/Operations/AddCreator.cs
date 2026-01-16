namespace Gateway.Application.Contracts.Operations;

public class AddCreator
{
    public record Request(
        string PasswordHash,
        string Email);

    public record Response(
        long AccountId);
}