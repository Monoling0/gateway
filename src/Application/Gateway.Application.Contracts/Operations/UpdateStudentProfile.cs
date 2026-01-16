using Microsoft.CodeAnalysis;

namespace Gateway.Application.Contracts.Operations;

public class UpdateStudentProfile
{
    public record Request(
        long AccountId,
        Optional<string> Nickname,
        Optional<string?> ProfilePhotoUrl);

    public record Response();
}