using Gateway.Application.Contracts.Courses;
using Gateway.Application.Contracts.Courses.Requests;
using Gateway.Application.Contracts.Courses.Responses;
using Gateway.Application.Mapping;
using GrpcContracts = Courses.CourseService.Contracts;

namespace Gateway.Application.Services;

public class CourseService : ICourseService
{
    private readonly GrpcContracts.CourseService.CourseServiceClient _client;

    public CourseService(GrpcContracts.CourseService.CourseServiceClient client)
    {
        _client = client;
    }

    public async Task<CheckAuthorshipResponse> CheckAuthorship(CheckAuthorshipRequest request, CancellationToken cancellationToken)
    {
        GrpcContracts.CheckAuthorshipResponse response = await _client.CheckAuthorshipAsync(request.MapToMessage(), cancellationToken: cancellationToken);
        return response.MapToModel();
    }

    public async Task<CourseDto> Create(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        GrpcContracts.CreateCourseResponse response = await _client.CreateCourseAsync(request.MapToMessage(), cancellationToken: cancellationToken);
        return response.MapToModel();
    }

    public async Task Publish(PublishCourseRequest request, CancellationToken cancellationToken)
    {
        await _client.PublishCourseAsync(request.MapToMessage(), cancellationToken: cancellationToken);
    }

    public async Task Unpublish(UnpublishCourseRequest request, CancellationToken cancellationToken)
    {
        await _client.UnpublishCourseAsync(request.MapToMessage(), cancellationToken: cancellationToken);
    }

    public async Task<IList<CourseDto>> GetCourses(GetCourseListRequest request, CancellationToken cancellationToken)
    {
        GrpcContracts.GetCourseListResponse response = await _client.GetCourseListAsync(request.MapToMessage(), cancellationToken: cancellationToken);
        return response.Courses.Select(c => c.MapToModel()).ToList();
    }
}