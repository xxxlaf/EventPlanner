using System.Net.Http.Json;
using EventPlanner.Models;

namespace EventPlanner.Client.Services
{
    public class EventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Event>>("api/events");
        }
    }
}