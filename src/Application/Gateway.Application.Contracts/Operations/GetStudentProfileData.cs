using Gateway.Application.Models.Users;

namespace Gateway.Application.Contracts.Operations;

public class GetStudentProfileData
{
    public record Response(StudentProfile StudentProfile);
}