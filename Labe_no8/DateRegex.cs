#region Using namespaces

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace Labe_no8
{
    public class DateRegex
    {
        private readonly Regex _regex;
        private string _path;

        public DateRegex(string path)
        {
            Path = path;
            _regex = new Regex("\\d{2}\\.\\d{2}\\.\\d{4}");
        }

        public string Path
        {
            get => _path;
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
                if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
                _path = value;
            }
        }

        public List<DateTime> GetResult()
        {
            var dateTimes = new List<DateTime>();
            var @string = ReadFile();
            var collection = _regex.Matches(@string);
            for (var i = 0; i < collection.Count; i++) dateTimes.Add(DateTime.Parse(collection[i].Value));

            return dateTimes;
        }

        private string ReadFile()
        {
            if (!File.Exists(Path)) throw new FileNotFoundException();
            string result;
            using (var stream = new StreamReader(Path))
            {
                result = stream.ReadToEnd();
            }

            return result;
        }
    }
}