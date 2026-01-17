namespace Gateway.Application.Contracts.Requests.Users;

public record UpdateAccountGatewayRequest(
    long AccountId,
    string? PasswordHash,
    string? Email);