namespace Gateway.Application.Contracts.Operations;

public class CreateSubscription
{
    public record Request(
        long FollowerId,
        long FolloweeId);
}