using Gateway.Application.Contracts.Courses.Requests;
using Gateway.Application.Contracts.Courses.Responses;
using GrpcContracts = Courses.CourseService.Contracts;

namespace Gateway.Application.Mapping;

public static class CourseMappingExtension
{
    public static GrpcContracts.CheckAuthorshipRequest MapToMessage(this CheckAuthorshipRequest request)
        => new GrpcContracts.CheckAuthorshipRequest
        {
            CourseId = request.CourseId,
            UserId = request.UserId,
        };

    public static CheckAuthorshipResponse MapToModel(this GrpcContracts.CheckAuthorshipResponse response)
        => new CheckAuthorshipResponse(response.CheckResult);

    public static GrpcContracts.CreateCourseRequest MapToMessage(this CreateCourseRequest request)
        => new GrpcContracts.CreateCourseRequest
        {
            UserId = request.CreatedBy,
            Name = request.Name,
            Description = request.Description,
            Language = request.Language,
            Level = request.Level.MapToMessage(),
        };

    public static CourseDto MapToModel(this GrpcContracts.CreateCourseResponse response)
        => new CourseDto(
            response.Course.Id,
            response.Course.Name,
            response.Course.Description,
            response.Course.Language,
            response.Course.Level.MapToModel(),
            response.Course.State.MapToModel());

    public static CourseDto MapToModel(this GrpcContracts.Course response)
        => new CourseDto(
            response.Id,
            response.Name,
            response.Description,
            response.Language,
            response.Level.MapToModel(),
            response.State.MapToModel());

    public static GrpcContracts.PublishCourseRequest MapToMessage(this PublishCourseRequest request)
        => new GrpcContracts.PublishCourseRequest
        {
            CourseId = request.CourseId,
            PublishedByUserId = request.UserId,
        };

    public static GrpcContracts.UnpublishCourseRequest MapToMessage(this UnpublishCourseRequest request)
        => new GrpcContracts.UnpublishCourseRequest
        {
            CourseId = request.CourseId,
            Reason = request.Reason,
            UnpublishedByUserId = request.UserId,
        };

    public static GrpcContracts.GetCourseListRequest MapToMessage(this GetCourseListRequest request)
    {
        var result = new GrpcContracts.GetCourseListRequest()
        {
            CourseIds = { request.CourseIds },
            Language = request.Language,
            Cursor = request.Cursor,
            PageSize = request.PageSize,
        };

        if (request.Level.HasValue)
        {
            result.Level = request.Level.Value.MapToMessage();
        }

        if (request.State.HasValue)
        {
            result.State = request.State.Value.MapToMessage();
        }

        return result;
    }
}