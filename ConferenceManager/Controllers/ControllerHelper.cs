namespace ConferenceManager.Controllers;
using System.IdentityModel.Tokens.Jwt;
public static class ControllerHelper
{
    public static int GetUserIdFromContext(HttpContext context)
    {
        string? userIdString = context.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        if (userIdString == null) return int.MinValue;
        if (int.TryParse(userIdString, out int userId)) return userId;
        else return int.MinValue;
    }
}
