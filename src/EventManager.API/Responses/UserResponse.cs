namespace EventManager.API.Responses
{
    public record UserResponse(
    string FirstName,
    string LastName,
    string Position,
    string Company,
    float YearsOfExperience,
    string Role);
}
