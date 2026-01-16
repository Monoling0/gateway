using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Operations;

public class GetAllStudentProfiles
{
    public record Request(
        int PageSize,
        long[]? Ids,
        PageToken? PageToken);

    public record Response(
        IList<StudentProfile> StudentProfiles,
        PageToken? PageToken);
}