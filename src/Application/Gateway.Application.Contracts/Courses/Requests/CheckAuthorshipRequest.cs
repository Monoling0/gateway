namespace Gateway.Application.Contracts.Courses.Requests;

public record CheckAuthorshipRequest(long CourseId, long UserId);