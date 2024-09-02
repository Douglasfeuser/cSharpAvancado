using System.Text.Json;
using cSharpAvancado.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace cSharpAvancado.Controllers;

public class ClimaController : Controller
{
    private int contador;
    private object lockObject = new();
    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<PrevisaoClima> GetClima()
    {
        string cidade = "criciuma";
        string apiKey = "b89e2c009d5a5dbd86d4963d2284c930";
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                
                PrevisaoClima previsao = JsonSerializer.Deserialize<PrevisaoClima>(responseBody, options);
                
                return previsao;
            }
            catch (HttpRequestException)
            {
                return new PrevisaoClima();
            }
        }
    }

    public async void cancel()
    {
        CancellationTokenSource cts = new();
        CancellationToken token = cts.Token;

        Task task = Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine("TESTANDO...");
                Thread.Sleep(1000);
            }
        }, token);

        cts.Cancel();

        await task;
    }

    public void LockContador()
    {
        lock (lockObject)
        {
            contador++;
        }
    }
    
    public IEnumerable<int> GetEnumerable()
    {
        var listaDeNumeros = new List<int> { 1, 2, 3, 4, 5 };
        var numerosPares = listaDeNumeros.AsEnumerable().Where(n => n % 2 == 0);
        return numerosPares;
    }
    
    public IQueryable<DadoClima> GetQueryable()
    {
        var contexto = new PrevisaoClima();
        var dadosClima = contexto.Weather.AsQueryable().Where(p => p.Description != "");
        return dadosClima;
    }

    public void TestMutex()
    {
        Mutex mutex = new Mutex();

        for (int i = 0; i < 10; i++)
        {
            Task.Factory.StartNew(() =>
            {
                if (mutex.WaitOne(4000))
                {
                    try
                    {
                        Console.WriteLine(System.IO.File.ReadAllText(@"C:\mutex.txt"));
                        System.IO.File.AppendAllText(@"C:\mutex.txt", "TEST Mutex");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine("mutex não foi finalizado ainda.");
                }
            });
        }
    }
}