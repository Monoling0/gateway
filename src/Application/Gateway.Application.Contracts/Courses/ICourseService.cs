using Gateway.Application.Contracts.Courses.Requests;
using Gateway.Application.Contracts.Courses.Responses;

namespace Gateway.Application.Contracts.Courses;

public interface ICourseService
{
    Task<CheckAuthorshipResponse> CheckAuthorship(CheckAuthorshipRequest request, CancellationToken cancellationToken);

    Task<CourseDto> Create(CreateCourseRequest request, CancellationToken cancellationToken);

    Task Publish(PublishCourseRequest request, CancellationToken cancellationToken);

    Task Unpublish(UnpublishCourseRequest request, CancellationToken cancellationToken);

    Task<IList<CourseDto>> GetCourses(GetCourseListRequest request, CancellationToken cancellationToken);
}
