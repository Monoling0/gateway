namespace Gateway.Application.Contracts.Operations;

public class RegisterStudent
{
    public record Request(
        string PasswordHash,
        string Email,
        string Nickname,
        string? ProfilePhotoUrl);

    public record Response(
        long AccountId);
}