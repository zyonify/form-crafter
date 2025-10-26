using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace FormMaker.Client.Services;

/// <summary>
/// Service for making authenticated API calls to the backend
/// </summary>
public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly LocalStorageService _localStorage;
    private const string TokenKey = "authToken";

    public ApiService(HttpClient httpClient, LocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    /// <summary>
    /// Gets the stored authentication token
    /// </summary>
    public async Task<string?> GetTokenAsync()
    {
        return await _localStorage.GetItemAsync<string>(TokenKey);
    }

    /// <summary>
    /// Stores the authentication token
    /// </summary>
    public async Task SetTokenAsync(string token)
    {
        await _localStorage.SetItemAsync(TokenKey, token);
    }

    /// <summary>
    /// Removes the authentication token (logout)
    /// </summary>
    public async Task RemoveTokenAsync()
    {
        await _localStorage.RemoveItemAsync(TokenKey);
    }

    /// <summary>
    /// Makes an authenticated GET request
    /// </summary>
    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        await AddAuthHeaderAsync(request);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }

    /// <summary>
    /// Makes an authenticated POST request
    /// </summary>
    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = JsonContent.Create(data)
        };
        await AddAuthHeaderAsync(request);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    /// <summary>
    /// Makes an authenticated PUT request
    /// </summary>
    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
        {
            Content = JsonContent.Create(data)
        };
        await AddAuthHeaderAsync(request);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    /// <summary>
    /// Makes an authenticated DELETE request
    /// </summary>
    public async Task<bool> DeleteAsync(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
        await AddAuthHeaderAsync(request);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    /// <summary>
    /// Makes a POST request without authentication (for login/register)
    /// </summary>
    public async Task<TResponse?> PostUnauthenticatedAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, data);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    /// <summary>
    /// Makes a GET request without authentication (for public forms)
    /// </summary>
    public async Task<T?> GetUnauthenticatedAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }

    /// <summary>
    /// Adds the authentication header to the request
    /// </summary>
    private async Task AddAuthHeaderAsync(HttpRequestMessage request)
    {
        var token = await GetTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    // Form Sharing API Methods

    /// <summary>
    /// Create a shareable form from a template
    /// </summary>
    public async Task<FormResponse?> CreateFormAsync(CreateFormRequest request)
    {
        return await PostAsync<CreateFormRequest, FormResponse>("forms", request);
    }

    /// <summary>
    /// Get a public form by share link (no auth required)
    /// </summary>
    public async Task<PublicFormResponse?> GetFormByShareLinkAsync(string shareLink)
    {
        return await GetUnauthenticatedAsync<PublicFormResponse>($"forms/public/{shareLink}");
    }

    /// <summary>
    /// Get all forms for a specific template
    /// </summary>
    public async Task<FormListResponse?> GetFormsByTemplateAsync(Guid templateId)
    {
        return await GetAsync<FormListResponse>($"forms/template/{templateId}");
    }

    /// <summary>
    /// Get a specific form by ID
    /// </summary>
    public async Task<FormResponse?> GetFormByIdAsync(Guid formId)
    {
        return await GetAsync<FormResponse>($"forms/{formId}");
    }

    /// <summary>
    /// Update form settings
    /// </summary>
    public async Task<FormResponse?> UpdateFormAsync(Guid formId, UpdateFormRequest request)
    {
        return await PutAsync<UpdateFormRequest, FormResponse>($"forms/{formId}", request);
    }

    /// <summary>
    /// Delete a form (soft delete)
    /// </summary>
    public async Task<bool> DeleteFormAsync(Guid formId)
    {
        return await DeleteAsync($"forms/{formId}");
    }
}

/// <summary>
/// Request/Response models for API calls
/// </summary>
public class RegisterRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? DisplayName { get; set; }
}

public class LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class AuthResponse
{
    public required string Token { get; set; }
    public required UserDto User { get; set; }
}

public class UserDto
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public string? DisplayName { get; set; }
    public bool EmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CreateTemplateRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string JsonData { get; set; }
    public string? Category { get; set; }
    public string? Tags { get; set; }
    public bool IsPublic { get; set; } = false;
}

public class UpdateTemplateRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? JsonData { get; set; }
    public string? Category { get; set; }
    public string? Tags { get; set; }
    public bool? IsPublic { get; set; }
}

public class TemplateResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string JsonData { get; set; }
    public string? Category { get; set; }
    public string? Tags { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Version { get; set; }
    public int UsageCount { get; set; }
}

public class TemplateListResponse
{
    public required List<TemplateResponse> Templates { get; set; }
    public int TotalCount { get; set; }
}

public class ErrorResponse
{
    public required string Error { get; set; }
    public string? Details { get; set; }
}

// Form Sharing Models

public class CreateFormRequest
{
    public required Guid TemplateId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool RequireAuth { get; set; } = false;
    public int? MaxSubmissions { get; set; }
    public DateTime? ExpiresAt { get; set; }
}

public class UpdateFormRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsPublic { get; set; }
    public int? MaxSubmissions { get; set; }
    public DateTime? ExpiresAt { get; set; }
}

public class FormResponse
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public required string ShareLink { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsPublic { get; set; }
    public bool IsActive { get; set; }
    public int? MaxSubmissions { get; set; }
    public int SubmissionCount { get; set; }
    public bool RequireAuth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public int ViewCount { get; set; }
    public DateTime? LastAccessedAt { get; set; }
}

public class PublicFormResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string TemplateJsonData { get; set; }
    public bool RequireAuth { get; set; }
}

public class FormListResponse
{
    public required List<FormResponse> Forms { get; set; }
    public int TotalCount { get; set; }
}
