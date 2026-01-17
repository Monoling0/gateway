using Gateway.Application.Models.Common;

namespace Gateway.Application.Contracts.Requests.Users;

public record GetAllStudentProfilesGatewayRequest(
    int PageSize,
    PageToken? PageToken);