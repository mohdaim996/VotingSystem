using System;
using System.Security.Cryptography;
using System.Text;

public static class PasswordHasher
{
	public static (string hash, string salt) HashPassword(string password)
	{
		using (var rng = new RNGCryptoServiceProvider())
		{
			byte[] saltBytes = new byte[16];
			rng.GetBytes(saltBytes);

			string salt = Convert.ToBase64String(saltBytes);
			string hashedPassword = HashPasswordWithSalt(password, salt);

			return (hashedPassword, salt);
		}
	}

	public static string HashPasswordWithSalt(string password, string salt)
	{
		using (var sha256 = SHA256.Create())
		{
			byte[] saltBytes = Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(salt)));
			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

			byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
			Array.Copy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
			Array.Copy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

			byte[] hashBytes = sha256.ComputeHash(combinedBytes);

			return Convert.ToBase64String(hashBytes);
		}
	}
    public static string GenerateSalt(int byteSize = 16)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] saltBytes = new byte[byteSize];
            rng.GetBytes(saltBytes);

            // Convert the salt to a base64-encoded string
            string salt = Convert.ToBase64String(saltBytes);

            return salt;
        }
    }
}
