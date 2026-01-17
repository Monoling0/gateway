using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Responses.Users;

public record GetFollowersGatewayResponse(
    IList<StudentProfile> StudentProfiles,
    PageToken? PageToken);