using Accounts.UserService.Contracts;
using Gateway.Application.Contracts;
using Gateway.Application.Contracts.Requests.Users;
using Gateway.Application.Contracts.Responses.Users;
using Gateway.Application.Extensions;
using GrpcIds = Accounts.UserService.Contracts.Ids;
using GrpcUserService = Accounts.UserService.Contracts.UserService;
using PageToken = Gateway.Application.Models.Common.PageToken;

namespace Gateway.Application.Services;

public class AccountService : IAccountService
{
    private readonly GrpcUserService.UserServiceClient _userServiceClient;

    public AccountService(GrpcUserService.UserServiceClient userServiceClient)
    {
        _userServiceClient = userServiceClient;
    }

    public async Task<RegisterStudentGatewayResponse> RegisterStudent(
        RegisterStudentGatewayRequest request,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new RegisterStudentRequest
        {
            PasswordHash = request.PasswordHash,
            Email = request.Email,
            Nickname = request.Nickname,
            ProfilePhotoUrl = request.ProfilePhotoUrl,
        };

        RegisterStudentResponse grpcResponse =
            await _userServiceClient.RegisterStudentAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new RegisterStudentGatewayResponse(grpcResponse.AccountId);

        return response;
    }

    public async Task<AddCreatorGatewayResponse> AddCreator(
        AddCreatorGatewayRequest request,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new AddCreatorRequest
        {
            PasswordHash = request.PasswordHash,
            Email = request.Email,
        };

        AddCreatorResponse grpcResponse =
            await _userServiceClient.AddCreatorAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new AddCreatorGatewayResponse(grpcResponse.AccountId);

        return response;
    }

    public async Task CreateSubscription(CreateSubscriptionGatewayRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new CreateSubscriptionRequest
        {
            FollowerId = request.FollowerId,
            FolloweeId = request.FolloweeId,
        };

        CreateSubscriptionResponse grpcResponse =
            await _userServiceClient.CreateSubscriptionAsync(
                grpcRequest,
                cancellationToken: cancellationToken);
    }

    public async Task<bool> ExistsAccount(long accountId, CancellationToken cancellationToken)
    {
        var grpcRequest = new ExistsAccountRequest
        {
            AccountId = accountId,
        };

        ExistsAccountResponse grpcResponse =
            await _userServiceClient.ExistsAccountAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        return grpcResponse.Exists;
    }

    public async Task<GetAccountGatewayResponse> GetAccount(long accountId, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetAccountRequest
        {
            AccountId = accountId,
        };

        GetAccountResponse grpcResponse =
            await _userServiceClient.GetAccountAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetAccountGatewayResponse(grpcResponse.Account.ToModel());

        return response;
    }

    public async Task<GetStudentProfileDataGatewayResponse> GetStudentProfileData(
        long accountId,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new GetStudentProfileDataRequest
        {
            AccountId = accountId,
        };

        GetStudentProfileDataResponse grpcResponse =
            await _userServiceClient.GetStudentProfileDataAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetStudentProfileDataGatewayResponse(grpcResponse.StudentProfile.ToModel());

        return response;
    }

    public async Task<GetPasswordHashGatewayResponse> GetPasswordHash(
        long passwordId,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new GetPasswordHashRequest
        {
            PasswordId = passwordId,
        };

        GetPasswordHashResponse grpcResponse =
            await _userServiceClient.GetPasswordHashAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetPasswordHashGatewayResponse(grpcResponse.PasswordHash);

        return response;
    }

    public async Task<GetAllAccountsGatewayResponse> GetAllAccounts(
        GetAllAccountsGatewayRequest request,
        CancellationToken cancellationToken)
    {
        var grpcIds = new GrpcIds
        {
            HasValue = false,
        };

        var grpcRequest = new GetAllAccountsRequest
        {
            PageSize = request.PageSize,
            Ids = grpcIds,
            HasRole = request.Role != null,
            Role = request.Role?.ToGrpc() ?? Role.Unspecified,
            PageToken = request.PageToken.ToGrpc(),
        };

        GetAllAccountsResponse grpcResponse =
            await _userServiceClient.GetAllAccountsAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetAllAccountsGatewayResponse(
            grpcResponse.Accounts.Select(a => a.ToModel()).ToList(),
            grpcResponse.PageToken != null ? new PageToken(grpcResponse.PageToken.LastSeenId) : null);

        return response;
    }

    public async Task<GetAllStudentProfilesGatewayResponse> GetAllStudentProfiles(
        GetAllStudentProfilesGatewayRequest request,
        CancellationToken cancellationToken)
    {
        var grpcIds = new GrpcIds
        {
            HasValue = false,
        };

        var grpcRequest = new GetAllStudentProfilesRequest
        {
            PageSize = request.PageSize,
            Ids = grpcIds,
            PageToken = request.PageToken.ToGrpc(),
        };

        GetAllStudentProfilesResponse grpcResponse =
            await _userServiceClient.GetAllStudentProfilesAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetAllStudentProfilesGatewayResponse(
            grpcResponse.StudentProfiles.Select(a => a.ToModel()).ToList(),
            grpcResponse.PageToken != null ? new PageToken(grpcResponse.PageToken.LastSeenId) : null);

        return response;
    }

    public async Task<GetFollowersGatewayResponse> GetFollowers(
        GetFollowersGatewayRequest request,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new GetFollowersRequest
        {
            PageSize = request.PageSize,
            StudentId = request.StudentId,
            PageToken = request.PageToken.ToGrpc(),
        };

        GetFollowersResponse grpcResponse =
            await _userServiceClient.GetFollowersAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetFollowersGatewayResponse(
            grpcResponse.StudentProfiles.Select(a => a.ToModel()).ToList(),
            grpcResponse.PageToken != null ? new PageToken(grpcResponse.PageToken.LastSeenId) : null);

        return response;
    }

    public async Task UpdateAccount(UpdateAccountGatewayRequest request, CancellationToken cancellationToken)
    {
        var grpcRequest = new UpdateAccountRequest
        {
            AccountId = request.AccountId,
            IsSetPasswordHash = request.PasswordHash != null,
            PasswordHash = request.PasswordHash,
            IsSetEmail = request.Email != null,
            Email = request.Email,
        };

        UpdateAccountResponse grpcResponse =
            await _userServiceClient.UpdateAccountAsync(
                grpcRequest,
                cancellationToken: cancellationToken);
    }

    public async Task UpdateStudentProfile(
        UpdateStudentProfileGatewayRequest request,
        CancellationToken cancellationToken)
    {
        var grpcRequest = new UpdateStudentProfileRequest
        {
            AccountId = request.AccountId,
            IsSetNickname = request.Nickname.HasValue,
            Nickname = request.Nickname.Value,
            IsSetProfilePhotoUrl = request.ProfilePhotoUrl.HasValue,
            ProfilePhotoUrl = request.ProfilePhotoUrl.Value,
        };

        UpdateStudentProfileResponse grpcResponse =
            await _userServiceClient.UpdateStudentProfileAsync(
                grpcRequest,
                cancellationToken: cancellationToken);
    }
}