namespace Gateway.Options;

public class UserServiceOptions
{
    public static string SectionName { get; } = "Grpc:Clients:UserService";

    public string Address { get; set; } = string.Empty;
}