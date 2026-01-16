using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Operations;

public class GetFollowers
{
    public record Request(
        long StudentId,
        int PageSize,
        PageToken? PageToken);

    public record Response(
        IList<StudentProfile> StudentProfiles,
        PageToken? PageToken);
}