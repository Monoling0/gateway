namespace Gateway.Application.Contracts.Requests.Users;

public record UpdateStudentProfileGatewayRequest(
    long AccountId,
    string? Nickname,
    string? ProfilePhotoUrl);