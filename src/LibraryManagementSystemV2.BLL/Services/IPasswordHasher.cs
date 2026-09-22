using Konscious.Security.Cryptography;
using System.Security.Cryptography;

namespace LibraryManagementSystemV2.BLL.Services;

public interface IPasswordHasher
{
    PasswordHash Hash(RawPassword raw);
    bool Verify(RawPassword raw, PasswordHash stored);
}


public sealed class RawPassword
{
    public string Value { get; }
    public RawPassword(string value)
    {
        Value = value;
    }

    public static RawPassword Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Password cannot be null or whitespace.", nameof(value));
        }
        return new RawPassword(value);
    }
}

public sealed class PasswordHash
{
    public const string Argon2Id = "argon2id";
    public string Algorithm { get; }
    public string Value { get; }
    public PasswordHash(string algorithm, string value)
    {
        Algorithm = algorithm;
        Value = value;
    }

    public static PasswordHash Create(string algorithm, string value)
    {
        if (string.IsNullOrWhiteSpace(algorithm))
        {
            throw new ArgumentException("Algorithm cannot be null or whitespace.", nameof(algorithm));
        }
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }
        return new PasswordHash(algorithm, value);
    }
}

public sealed class Argon2idPasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int DefaultIterations = 4;
    private const int DefaultMemoryKb = 65536; // 64 MB
    private const int DefaultParallelism = 2;

    public PasswordHash Hash(RawPassword raw)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = ComputeHash(raw.Value, salt, DefaultIterations, DefaultMemoryKb, DefaultParallelism);

        var encoded = $"{DefaultIterations}.{DefaultMemoryKb}.{DefaultParallelism}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";

        return PasswordHash.Create(PasswordHash.Argon2Id, encoded);
    }

    public bool Verify(RawPassword raw, PasswordHash stored)
    {
        if (stored.Algorithm != PasswordHash.Argon2Id)
        {
            return false;
        }

        var parts = stored.Value.Split('.');

        if (parts.Length != 5
            || !int.TryParse(parts[0], out var iterations)
            || !int.TryParse(parts[1], out var memoryKb)
            || !int.TryParse(parts[2], out var parallelism))
        {
            return false;
        }

        var salt = Convert.FromBase64String(parts[3]);
        var expectedHash = Convert.FromBase64String(parts[4]);

        var actualHash = ComputeHash(raw.Value, salt, iterations, memoryKb, parallelism);

        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }

    private static byte[] ComputeHash(string password, byte[] salt, int iterations, int memoryKb, int parallelism)
    {
        using var argon2 = new Argon2id(System.Text.Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = parallelism,
            Iterations = iterations,
            MemorySize = memoryKb,
        };

        return argon2.GetBytes(HashSize);
    }
}