using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class NbaApiClient
{
    private readonly HttpClient client;

    public NbaApiClient()
    {
        client = new HttpClient();
    }

    public async Task<string> MakeRequestAsync(string requestUri, string apiKey, string apiHost, Dictionary<string, string> additionalHeaders = null)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(requestUri),
        };

        request.Headers.Add("X-RapidAPI-Key", apiKey);
        request.Headers.Add("X-RapidAPI-Host", apiHost);

        if (additionalHeaders != null)
        {
            foreach (var header in additionalHeaders)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        Console.WriteLine($"Making request to: {request.RequestUri}");
        Console.WriteLine($"Using API Key: {apiKey}");

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

}















//api key (live games): NBA_API_KEY=93f5d3e4c7mshc799da1042ebeafp1e7772jsna70799c0134a
//GET_ALL_PLAYERS_KEY=93f5d3e4c7mshc799da1042ebeafp1e7772jsna70799c0134a