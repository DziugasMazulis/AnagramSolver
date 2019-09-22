using System;
using System.Collections.Generic;
using System.IO;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Models;
using AnagramSolver.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AnagramSolver.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            AppSettings appSettings = new AppSettings();
            configuration.GetSection("MyConfig").Bind(appSettings);
            IOptions<AppSettings> options = Options.Create<AppSettings>(appSettings);


            IEntryRepository entryRepository = new EntryRepository(options);
            List<EntryModel> sortedList = entryRepository.LoadEntries();

            ConsoleUI consoleUI = new ConsoleUI();
            DateTime[] dates = consoleUI.Initialize();

            IIntersectionFinder intersectionFinder = new IntersectionFinder(sortedList);
            int[] intersectedIndexes = intersectionFinder.FindEntries(dates[0], dates[1]);

            Console.ReadKey();
        }
    }
}
