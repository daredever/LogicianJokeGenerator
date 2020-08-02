using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LogicianJokeGenerator
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var jokesCount = config.GetValue("JOKES_COUNT", 10);
            var logiciansPerJoke = config.GetValue("LOGICIANS_COUNT", 3);

            var jokesGenerator = new JokesGenerator(jokesCount, logiciansPerJoke);
            foreach (var joke in jokesGenerator.Jokes)
            {
                await Console.Out.WriteLineAsync(joke.Text);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}