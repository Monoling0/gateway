using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Requests.Users;

public record GetAllAccountsGatewayRequest(
    int PageSize,
    Roles? Role,
    PageToken? PageToken);