using Gateway.Application.Contracts.Requests.Users;
using Gateway.Application.Contracts.Responses.Users;

namespace Gateway.Application.Contracts;

public interface IAccountService
{
    Task<RegisterStudentGatewayResponse> RegisterStudent(
        RegisterStudentGatewayRequest request,
        CancellationToken cancellationToken);

    Task<AddCreatorGatewayResponse> AddCreator(
        AddCreatorGatewayRequest request,
        CancellationToken cancellationToken);

    Task CreateSubscription(
        CreateSubscriptionGatewayRequest request,
        CancellationToken cancellationToken);

    Task<bool> ExistsAccount(
        long accountId,
        CancellationToken cancellationToken);

    Task<GetAccountGatewayResponse> GetAccount(
        long accountId,
        CancellationToken cancellationToken);

    Task<GetStudentProfileDataGatewayResponse> GetStudentProfileData(
        long accountId,
        CancellationToken cancellationToken);

    Task<GetPasswordHashGatewayResponse> GetPasswordHash(
        long passwordId,
        CancellationToken cancellationToken);

    Task<GetAllAccountsGatewayResponse> GetAllAccounts(
        GetAllAccountsGatewayRequest request,
        CancellationToken cancellationToken);

    Task<GetAllStudentProfilesGatewayResponse> GetAllStudentProfiles(
        GetAllStudentProfilesGatewayRequest request,
        CancellationToken cancellationToken);

    Task<GetFollowersGatewayResponse> GetFollowers(
        GetFollowersGatewayRequest request,
        CancellationToken cancellationToken);

    Task UpdateAccount(
        UpdateAccountGatewayRequest request,
        CancellationToken cancellationToken);

    Task UpdateStudentProfile(
        UpdateStudentProfileGatewayRequest request,
        CancellationToken cancellationToken);
}