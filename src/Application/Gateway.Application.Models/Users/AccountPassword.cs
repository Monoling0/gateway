namespace Gateway.Application.Models.Users;

public record AccountPassword(
    long PasswordId,
    string PasswordHash);