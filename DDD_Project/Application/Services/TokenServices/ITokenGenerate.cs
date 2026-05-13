namespace Application.Services.TokenServices
{
    public interface ITokenGenerate
    {
        string GenerateToken(string role, int userId,string userName);
    }
}
