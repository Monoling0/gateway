using Gateway.Application.Models.Common;

namespace Gateway.Application.Contracts.Requests.Users;

public record GetFollowersGatewayRequest(
    long StudentId,
    int PageSize,
    PageToken? PageToken);