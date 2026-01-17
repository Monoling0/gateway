using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Responses.Users;

public record GetAllAccountsGatewayResponse(
    IList<Account> Accounts,
    PageToken? PageToken);