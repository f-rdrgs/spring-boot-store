using System.Text.Json.Serialization;

namespace dotnet_store_test.Models.Auth_DTO
{
    public record LoginData(
        [property: JsonPropertyName("email")] string? Email,
        [property: JsonPropertyName("username")] string? Username,
        [property: JsonPropertyName("password")] string? Password,
        [property: JsonPropertyName("token")] string? JWTToken,
        [property: JsonPropertyName("decoded_data")] string? DecodedData);
}
