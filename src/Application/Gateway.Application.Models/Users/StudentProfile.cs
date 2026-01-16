namespace Gateway.Application.Models.Users;

public record StudentProfile(
    long AccountId,
    string Nickname,
    string? ProfilePhotoUrl);