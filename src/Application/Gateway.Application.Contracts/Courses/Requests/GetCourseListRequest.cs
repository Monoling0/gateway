using Gateway.Application.Models.Courses;

namespace Gateway.Application.Contracts.Courses.Requests;

public record GetCourseListRequest(
    long[] CourseIds,
    string? Language,
    CefrLevel? Level,
    CourseState? State,
    long Cursor,
    long PageSize);
