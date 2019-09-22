using System;
using System.IO;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AnagramSolver.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            var appSettings = new AppSettings();
            configuration.GetSection("MyConfig").Bind(appSettings);
            var options = Options.Create<AppSettings>(appSettings);


            IEntryRepository entryRepository = new EntryRepository(options);
            var sortedList = entryRepository.LoadEntries();

            Console.ReadKey();
        }
    }
}
