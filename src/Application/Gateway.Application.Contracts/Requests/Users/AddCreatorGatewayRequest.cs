namespace Gateway.Application.Contracts.Requests.Users;

public record AddCreatorGatewayRequest(
    string PasswordHash,
    string Email);