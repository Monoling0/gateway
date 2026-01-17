namespace Gateway.Application.Contracts.Requests.Users;

public record CreateSubscriptionGatewayRequest(
    long FollowerId,
    long FolloweeId);