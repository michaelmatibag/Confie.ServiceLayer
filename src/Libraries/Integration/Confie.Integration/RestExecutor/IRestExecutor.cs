﻿namespace Confie.Integration.RestExecutor
{
    public interface IRestExecutor
    {
        string Get(string resource);

        T Get<T>(string resource) where T : new();

        string Post(string resource, string request);

        T Post<T>(string resource, T request) where T : new();
    }
}