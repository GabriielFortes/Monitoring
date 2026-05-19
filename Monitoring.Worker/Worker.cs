using Monitoring.Core.Models;
using Monitoring.Core.Services;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;
using Monitoring.Worker.Models;


namespace Monitoring.Worker;

public class Worker : BackgroundService
{
    private readonly HttpClient _httpClient = new();
    private PositionDto? _lastPostion;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested) 
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    "http://localhost:5058/positions",
                    stoppingToken
                );

                var content = await response.Content.ReadAsStringAsync();
                var current = JsonSerializer.Deserialize<PositionDto>(content);

                
                if (current != null)
                {
                    if (_lastPostion != null)
                    {
                        var deltaValue = current.Speed - _lastPostion.Speed;
                        var deltaTime = (current.Timestamp - _lastPostion.Timestamp).TotalSeconds;

                        var variation = deltaTime == 0 ? 0 : deltaValue / deltaTime;

                        Console.WriteLine($"Vehicle: {current.VehicleId}");
                        Console.WriteLine($"Speed: {current.Speed}");
                        Console.WriteLine($"Variation per Second: {variation:f4}");
                        Console.WriteLine($"Timestamp: {current.Timestamp}");
                        
                        Console.WriteLine("----------------------------------");
                    }
                }

                _lastPostion = current;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}


