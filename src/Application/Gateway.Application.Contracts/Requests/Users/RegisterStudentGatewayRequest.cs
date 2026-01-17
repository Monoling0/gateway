namespace Gateway.Application.Contracts.Requests.Users;

public record RegisterStudentGatewayRequest(
    string PasswordHash,
    string Email,
    string Nickname,
    string? ProfilePhotoUrl);