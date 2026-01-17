using Microsoft.CodeAnalysis;

namespace Gateway.Application.Contracts.Requests.Users;

public record UpdateStudentProfileGatewayRequest(
    long AccountId,
    Optional<string> Nickname,
    Optional<string?> ProfilePhotoUrl);