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
            var logiciansCount = config.GetValue("LOGICIANS_COUNT", 3);
            await GenerateJokes(jokesCount, logiciansCount);
        }

        private static async Task GenerateJokes(int jokesCount, int logiciansCount)
        {
            for (var joke = 1; joke <= jokesCount; joke++)
            {
                await Console.Out.WriteLineAsync(
                    $"{Environment.NewLine}Joke #{joke}{Environment.NewLine}Do u all want a beer?");

                var logiciansInPub = new LogiciansInPub(logiciansCount);
                foreach (var answer in logiciansInPub.Answers)
                {
                    await Console.Out.WriteLineAsync($"- {answer}");
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}