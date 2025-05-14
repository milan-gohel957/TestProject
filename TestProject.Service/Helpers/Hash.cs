using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace TestProject.Service.Helpers;
public class Hash
{
    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32
        ));
        return $"{Convert.ToBase64String(salt)}:{hashedPassword}";
    }

    public static bool VerifyPassword(string storedHash, string inputPassword)
    {
        var parts = storedHash.Split(':');
        if (parts.Length != 2)
            return false;

        byte[] salt = Convert.FromBase64String(parts[0]);
        string originalHash = parts[1];

        string hashedInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: inputPassword,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return originalHash == hashedInput;
    }
}