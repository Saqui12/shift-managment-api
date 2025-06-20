﻿namespace Application.Services.DTOs.Auth
{
    public class AuthenticatedUserDto
    {
        public bool IsAuthenticated { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<string> Roles { get; set; } = new();

    }
}
