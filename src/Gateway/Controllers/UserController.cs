using Gateway.Application.Contracts;
using Gateway.Application.Contracts.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Gateway.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IAccountService _accountService;

    public UserController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("students")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(RegisterStudent.Response))]
    public async Task<ActionResult<RegisterStudent.Response>> RegisterStudent(
        [FromBody] RegisterStudent.Request request,
        CancellationToken cancellationToken)
    {
        RegisterStudent.Response response = await _accountService.RegisterStudent(request, cancellationToken);

        return Ok(response);
    }

    // [HttpPost("creators")]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AddCreator.Response))]
    // public async Task<ActionResult<AddCreator.Response>> AddCreator(
    //     [FromBody] AddCreator.Request request,
    //     CancellationToken cancellationToken)
    // {
    //     AddCreator.Response response = await _accountService.AddCreator(request, cancellationToken);
    //
    //     return Ok(response);
    // }
    [HttpPost("students/{followerId}/follow/{followeeId}")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RegisterStudent(
        [FromRoute] long followerId,
        [FromRoute] long followeeId,
        CancellationToken cancellationToken)
    {
        var request = new CreateSubscription.Request(followerId, followeeId);
        await _accountService.CreateSubscription(request, cancellationToken);

        return NoContent();
    }

    // [HttpGet("{accountId}")]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
    // public async Task<ActionResult<RegisterStudent>> ExistsAccount(
    //     [FromRoute] long accountId,
    //     CancellationToken cancellationToken)
    // {
    //     bool response = await _accountService.ExistsAccount(accountId, cancellationToken);
    //
    //     return Ok(response);
    // }
    // [HttpGet("{accountId}")]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAccount.Response))]
    // public async Task<ActionResult<GetAccount.Response>> GetAccount(
    //     [FromRoute] long accountId,
    //     CancellationToken cancellationToken)
    // {
    //     GetAccount.Response response = await _accountService.GetAccount(accountId, cancellationToken);
    //
    //     return Ok(response);
    // }
    // [HttpGet("/students/{accountId}")]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetStudentProfileData.Response))]
    // public async Task<ActionResult<GetStudentProfileData.Response>> GetStudentProfileData(
    //     [FromRoute] long accountId,
    //     CancellationToken cancellationToken)
    // {
    //     GetStudentProfileData.Response
    //         response = await _accountService.GetStudentProfileData(accountId, cancellationToken);
    //
    //     return Ok(response);
    // }
    // [HttpGet("/students/passwords/{passwordId}")]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetStudentProfileData.Response))]
    // public async Task<ActionResult<GetStudentProfileData.Response>> GetPasswordHash(
    //     [FromRoute] long passwordId,
    //     CancellationToken cancellationToken)
    // {
    //     GetPasswordHash.Response response = await _accountService.GetPasswordHash(passwordId, cancellationToken);
    //
    //     return Ok(response);
    // }
    // [HttpGet]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAllAccounts.Response))]
    // public async Task<ActionResult<GetAllAccounts.Response>> GetAllAccounts(
    //     [FromBody] GetAllAccounts.Request request,
    //     CancellationToken cancellationToken)
    // {
    //     GetAllAccounts.Response response = await _accountService.GetAllAccounts(request, cancellationToken);
    //
    //     return Ok(response);
    // }
    // [HttpGet("/students")]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAllStudentProfiles.Response))]
    // public async Task<ActionResult<GetAllStudentProfiles.Response>> GetAllStudentProfiles(
    //     [FromBody] GetAllStudentProfiles.Request request,
    //     CancellationToken cancellationToken)
    // {
    //     GetAllStudentProfiles.Response response = await _accountService.GetAllStudentProfiles(request, cancellationToken);
    //
    //     return Ok(response);
    // }
    // [HttpGet("/students/followers")]
    // [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetFollowers.Response))]
    // public async Task<ActionResult<GetFollowers.Response>> GetFollowers(
    //     [FromBody] GetFollowers.Request request,
    //     CancellationToken cancellationToken)
    // {
    //     GetFollowers.Response response = await _accountService.GetFollowers(request, cancellationToken);
    //
    //     return Ok(response);
    // }
    // [HttpPut]
    // [SwaggerResponse(StatusCodes.Status204NoContent)]
    // public async Task<IActionResult> UpdateAccount(
    //     [FromBody] UpdateAccount.Request request,
    //     CancellationToken cancellationToken)
    // {
    //     await _accountService.UpdateAccount(request, cancellationToken);
    //
    //     return NoContent();
    // }
    // [HttpPut("/students")]
    // [SwaggerResponse(StatusCodes.Status204NoContent)]
    // public async Task<IActionResult> UpdateStudentProfile(
    //     [FromBody] UpdateStudentProfile.Request request,
    //     CancellationToken cancellationToken)
    // {
    //     await _accountService.UpdateStudentProfile(request, cancellationToken);
    //
    //     return NoContent();
    // }
}