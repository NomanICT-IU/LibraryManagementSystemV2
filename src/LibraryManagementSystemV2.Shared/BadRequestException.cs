namespace LibraryManagementSystemV2.Shared;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }
}
