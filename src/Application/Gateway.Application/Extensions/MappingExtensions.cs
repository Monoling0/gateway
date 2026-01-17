using Gateway.Application.Models.Common;
using Gateway.Application.Models.Users;
using GrpcAccount = Accounts.UserService.Contracts.Account;
using GrpcPageToken = Accounts.UserService.Contracts.PageToken;
using GrpcRole = Accounts.UserService.Contracts.Role;
using GrpcStudentProfile = Accounts.UserService.Contracts.StudentProfile;

namespace Gateway.Application.Extensions;

public static class MappingExtensions
{
    public static Account ToModel(this GrpcAccount account)
    {
        return new Account(
            account.AccountId,
            account.Role.ToModel(),
            account.PasswordId,
            account.Email,
            account.AccountCreatedAt.ToDateTimeOffset(),
            account.AccountUpdatedAt.ToDateTimeOffset());
    }

    public static StudentProfile ToModel(this GrpcStudentProfile studentProfile)
    {
        return new StudentProfile(
            studentProfile.AccountId,
            studentProfile.Nickname,
            studentProfile.ProfilePhotoUrl);
    }

    public static GrpcPageToken? ToGrpc(this PageToken? pageToken)
    {
        return pageToken == null
            ? null
            : new GrpcPageToken
            {
                LastSeenId = pageToken.LastSeenId,
            };
    }

    public static Roles ToModel(this GrpcRole role)
    {
        return role switch
        {
            GrpcRole.Admin => Roles.Admin,
            GrpcRole.Creator => Roles.Creator,
            GrpcRole.Student => Roles.Student,
            GrpcRole.Unspecified or _ => throw new ArgumentOutOfRangeException(nameof(role), role, null),
        };
    }

    public static GrpcRole ToGrpc(this Roles role)
    {
        return role switch
        {
            Roles.Admin => GrpcRole.Admin,
            Roles.Creator => GrpcRole.Creator,
            Roles.Student => GrpcRole.Student,
            _ => GrpcRole.Unspecified,
        };
    }
}