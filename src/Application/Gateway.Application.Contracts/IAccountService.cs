using Gateway.Application.Contracts.Operations;

namespace Gateway.Application.Contracts;

public interface IAccountService
{
    Task<RegisterStudent.Response> RegisterStudent(
        RegisterStudent.Request request,
        CancellationToken cancellationToken);

    Task<AddCreator.Response> AddCreator(
        AddCreator.Request request,
        CancellationToken cancellationToken);

    Task CreateSubscription(
        CreateSubscription.Request request,
        CancellationToken cancellationToken);

    Task<bool> ExistsAccount(
        long accountId,
        CancellationToken cancellationToken);

    Task<GetAccount.Response> GetAccount(
        long accountId,
        CancellationToken cancellationToken);

    Task<GetStudentProfileData.Response> GetStudentProfileData(
        long accountId,
        CancellationToken cancellationToken);

    Task<GetPasswordHash.Response> GetPasswordHash(
        long passwordId,
        CancellationToken cancellationToken);

    Task<GetAllAccounts.Response> GetAllAccounts(
        GetAllAccounts.Request request,
        CancellationToken cancellationToken);

    Task<GetAllStudentProfiles.Response> GetAllStudentProfiles(
        GetAllStudentProfiles.Request request,
        CancellationToken cancellationToken);

    Task<GetFollowers.Response> GetFollowers(
        GetFollowers.Request request,
        CancellationToken cancellationToken);

    Task<UpdateAccount.Response> UpdateAccount(
        UpdateAccount.Request request,
        CancellationToken cancellationToken);

    Task<UpdateStudentProfile.Response> UpdateStudentProfile(
        UpdateStudentProfile.Request request,
        CancellationToken cancellationToken);
}