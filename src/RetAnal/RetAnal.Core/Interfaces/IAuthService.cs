﻿namespace RetAnal.Core.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(string username, string password);
}