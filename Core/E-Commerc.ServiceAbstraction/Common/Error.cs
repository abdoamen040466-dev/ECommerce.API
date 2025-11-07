namespace E_Commerc.ServiceAbstraction.Common;
public class Error
{
    public string Code { get; set; }
    public string Description { get; set; }
    public ErrorType Type { get; set; }

    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public static Error Failure(string code = "General.Failure",
        string description = "A failure has occurred.")
        => new(code, description, ErrorType.Failure);

    public static Error Validation(string code = "General.Validation",
        string description = "A validation error has occurred.") =>
        new(code, description, ErrorType.Validation);

    public static Error NotFound(string code = "General.NotFound",
        string description = "A 'Not Found' error has occurred.") =>
        new(code, description, ErrorType.NotFound);

    public static Error Conflict(string code = "General.Conflict",
        string description = "A conflict error has occurred.") =>
        new(code, description, ErrorType.Conflict);

    public static Error Unauthorized(string code = "General.Unauthorized",
        string description = "An unauthorized error has occurred.") =>
        new(code, description, ErrorType.Unauthorized);

}
