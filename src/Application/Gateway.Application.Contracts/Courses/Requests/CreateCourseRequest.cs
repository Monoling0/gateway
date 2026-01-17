using Gateway.Application.Models.Courses;

namespace Gateway.Application.Contracts.Courses.Requests;

public record CreateCourseRequest(string Name, string Description, string Language, CefrLevel Level, long CreatedBy);