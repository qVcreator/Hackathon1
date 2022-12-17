﻿namespace UwULearn.Bussines.Interfaces;

public interface ICatsSrvice
{
    public Task<string> Rename(int catId, string newName);
    public Task HealthUpdate(int catId, int newHealth);
    public Task<int> GetHealth(int catId);
}