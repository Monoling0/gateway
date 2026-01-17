using Gateway.Application.Contracts.Courses;
using Gateway.Application.Contracts.Courses.Requests;
using Gateway.Application.Contracts.Courses.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[ApiController]
[Route("courses")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost("authorship-checking")]
    public async Task<ActionResult<CheckAuthorshipResponse>> CheckAuthorship(
        CheckAuthorshipRequest request,
        CancellationToken cancellationToken)
    {
        return Ok(await _courseService.CheckAuthorship(request, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> Create(
        CreateCourseRequest createCourseRequest,
        CancellationToken cancellationToken)
    {
        return Ok(await _courseService.Create(createCourseRequest, cancellationToken));
    }

    [HttpPost("publishing")]
    public async Task<ActionResult> Publish(
        PublishCourseRequest publishCourseRequest,
        CancellationToken cancellationToken)
    {
        await _courseService.Publish(publishCourseRequest, cancellationToken);
        return Ok();
    }

    [HttpPost("unpublishing")]
    public async Task<ActionResult> Unpublish(
        UnpublishCourseRequest unpublishCourseRequest,
        CancellationToken cancellationToken)
    {
        await _courseService.Unpublish(unpublishCourseRequest, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IList<CourseDto>>> GetCourses(
        GetCourseListRequest request,
        CancellationToken cancellationToken)
    {
        return Ok(await _courseService.GetCourses(request, cancellationToken));
    }
}