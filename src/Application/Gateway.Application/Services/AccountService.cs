using Accounts.UserService.Contracts;
using Gateway.Application.Contracts;
using Gateway.Application.Contracts.Operations;
using Gateway.Application.Extensions;
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

    public async Task<RegisterStudent.Response> RegisterStudent(
        RegisterStudent.Request request,
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

        var response = new RegisterStudent.Response(grpcResponse.AccountId);

        return response;
    }

    public async Task<AddCreator.Response> AddCreator(AddCreator.Request request, CancellationToken cancellationToken)
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

        var response = new AddCreator.Response(grpcResponse.AccountId);

        return response;
    }

    public async Task CreateSubscription(CreateSubscription.Request request, CancellationToken cancellationToken)
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

    public async Task<GetAccount.Response> GetAccount(long accountId, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetAccountRequest
        {
            AccountId = accountId,
        };

        GetAccountResponse grpcResponse =
            await _userServiceClient.GetAccountAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetAccount.Response(grpcResponse.Account.ToModel());

        return response;
    }

    public async Task<GetStudentProfileData.Response> GetStudentProfileData(long accountId, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetStudentProfileDataRequest
        {
            AccountId = accountId,
        };

        GetStudentProfileDataResponse grpcResponse =
            await _userServiceClient.GetStudentProfileDataAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetStudentProfileData.Response(grpcResponse.StudentProfile.ToModel());

        return response;
    }

    public async Task<GetPasswordHash.Response> GetPasswordHash(long passwordId, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetPasswordHashRequest
        {
            PasswordId = passwordId,
        };

        GetPasswordHashResponse grpcResponse =
            await _userServiceClient.GetPasswordHashAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetPasswordHash.Response(grpcResponse.PasswordHash);

        return response;
    }

    public async Task<GetAllAccounts.Response> GetAllAccounts(GetAllAccounts.Request request, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetAllAccountsRequest
        {
            PageSize = request.PageSize,
            Ids = request.Ids.ToGrpc(),
            PageToken = request.PageToken.ToGrpc(),
        };

        GetAllAccountsResponse grpcResponse =
            await _userServiceClient.GetAllAccountsAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetAllAccounts.Response(
            grpcResponse.Accounts.Select(a => a.ToModel()).ToList(),
            new PageToken(grpcResponse.PageToken.LastSeenId));

        return response;
    }

    public async Task<GetAllStudentProfiles.Response> GetAllStudentProfiles(GetAllStudentProfiles.Request request, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetAllStudentProfilesRequest
        {
            PageSize = request.PageSize,
            Ids = request.Ids.ToGrpc(),
            PageToken = request.PageToken.ToGrpc(),
        };

        GetAllStudentProfilesResponse grpcResponse =
            await _userServiceClient.GetAllStudentProfilesAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new GetAllStudentProfiles.Response(
            grpcResponse.StudentProfiles.Select(a => a.ToModel()).ToList(),
            new PageToken(grpcResponse.PageToken.LastSeenId));

        return response;
    }

    public async Task<GetFollowers.Response> GetFollowers(GetFollowers.Request request, CancellationToken cancellationToken)
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

        var response = new GetFollowers.Response(
            grpcResponse.StudentProfiles.Select(a => a.ToModel()).ToList(),
            new PageToken(grpcResponse.PageToken.LastSeenId));

        return response;
    }

    public async Task<UpdateAccount.Response> UpdateAccount(UpdateAccount.Request request, CancellationToken cancellationToken)
    {
        var grpcRequest = new UpdateAccountRequest
        {
            AccountId = request.AccountId,
            IsSetPasswordHash = request.PasswordHash.HasValue,
            PasswordHash = request.PasswordHash.Value,
            IsSetEmail = request.Email.HasValue,
            Email = request.Email.Value,
        };

        UpdateAccountResponse grpcResponse =
            await _userServiceClient.UpdateAccountAsync(
                grpcRequest,
                cancellationToken: cancellationToken);

        var response = new UpdateAccount.Response();

        return response;
    }

    public async Task<UpdateStudentProfile.Response> UpdateStudentProfile(UpdateStudentProfile.Request request, CancellationToken cancellationToken)
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

        var response = new UpdateStudentProfile.Response();

        return response;
    }
}