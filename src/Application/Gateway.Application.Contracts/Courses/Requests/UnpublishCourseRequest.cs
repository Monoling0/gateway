namespace Gateway.Application.Contracts.Courses.Requests;

public record UnpublishCourseRequest(long CourseId, string Reason, long UserId);