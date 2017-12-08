using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

class Program
{
    private DiscordSocketClient _client;

    static void Main(string[] args)
    {
        new Program().StartAsync(args[0]).GetAwaiter().GetResult();
    }

    public async Task StartAsync(string token)
    {
        _client = new DiscordSocketClient();

        _client.Log += m =>
        {
            Console.WriteLine(m);
            return Task.CompletedTask;
        };

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }
}
