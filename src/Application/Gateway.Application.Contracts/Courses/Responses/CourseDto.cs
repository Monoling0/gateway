using Gateway.Application.Models.Courses;

namespace Gateway.Application.Contracts.Courses.Responses;

public record CourseDto(long Id, string Name, string Description, string Language, CefrLevel Level, CourseState State);