using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Models;
using AnagramSolver.Contracts.Repositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace AnagramSolver.BusinessLogic
{
    public class EntryRepository : IEntryRepository
    {
        private readonly AppSettings _config;

        public EntryRepository(IOptions<AppSettings> config)
        {
            _config = config.Value;
        }

        public List<EntryModel> LoadEntries()
        {
            string path = GetPath();
            XmlDocument doc = new XmlDocument();

            using (StreamReader reader = new StreamReader(path))
            {
                string xml = reader.ReadToEnd();
                doc.LoadXml(xml);
            }

            var json = JsonConvert.SerializeXmlNode(doc.DocumentElement, Newtonsoft.Json.Formatting.None, true);
            var dictionary = JsonConvert.DeserializeObject<DictionaryModel>(json);

            return dictionary.Entry.OrderBy(o => o.Date).ToList();
        }

        private string GetPath()
        {
            string path = Path.Combine(Environment.CurrentDirectory, _config.FileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            return path;
        }
    }
}
