using Gateway.Application.Contracts;
using Gateway.Application.Contracts.Requests.Users;
using Gateway.Application.Contracts.Responses.Users;
using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Grpc.Controllers;

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
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(RegisterStudentGatewayResponse))]
    public async Task<ActionResult<RegisterStudentGatewayResponse>> RegisterStudent(
        [FromBody] RegisterStudentGatewayRequest request,
        CancellationToken cancellationToken)
    {
        RegisterStudentGatewayResponse response = await _accountService.RegisterStudent(request, cancellationToken);

        return Ok(response);
    }

    [HttpPost("creators")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AddCreatorGatewayResponse))]
    public async Task<ActionResult<RegisterStudentGatewayResponse>> AddCreator(
        [FromBody] AddCreatorGatewayRequest request,
        CancellationToken cancellationToken)
    {
        AddCreatorGatewayResponse response = await _accountService.AddCreator(request, cancellationToken);

        return Ok(response);
    }

    [HttpPost("students/{followerId}/follow/{followeeId}")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RegisterStudent(
        [FromRoute] long followerId,
        [FromRoute] long followeeId,
        CancellationToken cancellationToken)
    {
        var request = new CreateSubscriptionGatewayRequest(followerId, followeeId);
        await _accountService.CreateSubscription(request, cancellationToken);

        return NoContent();
    }

    [HttpGet("{accountId}/exists")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
    public async Task<ActionResult<bool>> ExistsAccount(
        [FromRoute] long accountId,
        CancellationToken cancellationToken)
    {
        bool response = await _accountService.ExistsAccount(accountId, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{accountId}/data")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAccountGatewayResponse))]
    public async Task<ActionResult<GetAccountGatewayResponse>> GetAccount(
        [FromRoute] long accountId,
        CancellationToken cancellationToken)
    {
        GetAccountGatewayResponse response = await _accountService.GetAccount(accountId, cancellationToken);

        return Ok(response);
    }

    [HttpGet("/students/{accountId}")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetStudentProfileDataGatewayResponse))]
    public async Task<ActionResult<GetStudentProfileDataGatewayResponse>> GetStudentProfileData(
        [FromRoute] long accountId,
        CancellationToken cancellationToken)
    {
        GetStudentProfileDataGatewayResponse
            response = await _accountService.GetStudentProfileData(accountId, cancellationToken);

        return Ok(response);
    }

    [HttpGet("/students/passwords/{passwordId}")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetStudentProfileDataGatewayResponse))]
    public async Task<ActionResult<GetStudentProfileDataGatewayResponse>> GetPasswordHash(
        [FromRoute] long passwordId,
        CancellationToken cancellationToken)
    {
        GetPasswordHashGatewayResponse response = await _accountService.GetPasswordHash(passwordId, cancellationToken);

        return Ok(response);
    }

    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAllAccountsGatewayResponse))]
    public async Task<ActionResult<GetAllAccountsGatewayResponse>> GetAllAccounts(
        [FromQuery] int pageSize,
        [FromQuery] Roles? role,
        [FromQuery] PageToken? pageToken,
        CancellationToken cancellationToken)
    {
        var request = new GetAllAccountsGatewayRequest(
            pageSize,
            role,
            pageToken);
        GetAllAccountsGatewayResponse response = await _accountService.GetAllAccounts(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("/students")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAllStudentProfilesGatewayResponse))]
    public async Task<ActionResult<GetAllStudentProfilesGatewayResponse>> GetAllStudentProfiles(
        [FromQuery] int pageSize,
        [FromQuery] PageToken? pageToken,
        CancellationToken cancellationToken)
    {
        var request = new GetAllStudentProfilesGatewayRequest(
            pageSize,
            pageToken);
        GetAllStudentProfilesGatewayResponse response =
            await _accountService.GetAllStudentProfiles(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("/students/followers/{studentId}")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetFollowersGatewayResponse))]
    public async Task<ActionResult<GetFollowersGatewayResponse>> GetFollowers(
        [FromRoute] long studentId,
        [FromQuery] int pageSize,
        [FromQuery] PageToken? pageToken,
        CancellationToken cancellationToken)
    {
        var request = new GetFollowersGatewayRequest(
            studentId,
            pageSize,
            pageToken);
        GetFollowersGatewayResponse response = await _accountService.GetFollowers(request, cancellationToken);

        return Ok(response);
    }

    [HttpPut]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAccount(
        [FromBody] UpdateAccountGatewayRequest request,
        CancellationToken cancellationToken)
    {
        await _accountService.UpdateAccount(request, cancellationToken);

        return NoContent();
    }

    [HttpPut("/students")]
    [SwaggerResponse(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateStudentProfile(
        [FromBody] UpdateStudentProfileGatewayRequest request,
        CancellationToken cancellationToken)
    {
        await _accountService.UpdateStudentProfile(request, cancellationToken);

        return NoContent();
    }
}