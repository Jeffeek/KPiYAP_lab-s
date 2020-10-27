using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labe_no8
{
    public class HtmlRegex
    {
        private string _path;
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

        public HtmlRegex(string path)
        {
            Path = path;
        }

        private string ReadFile()
        {
            if (!File.Exists(Path)) throw new FileNotFoundException();
            string result;
            using (var stream = new StreamReader(Path))
                result = stream.ReadToEnd();
            return result;
        }

        public void Parse()
        {
            string text = ReadFile();
            text = ParseUnderLine(text);
            var colorParsedArray = ParseFontColor(text);
            text = string.Join("<Br>", colorParsedArray);
            CreateHtmlDoc(text);
        }

        private string ParseUnderLine(string text)
        {
            string pattern = "\\(u\\)";
            Regex reg = new Regex(pattern);
            while (reg.IsMatch(text))
            {
                text = reg.Replace(text, "<u>", 1);
                text = reg.Replace(text, "</u>", 1);
            }

            return text;
        }

        private string[] ParseFontColor(string text)
        {
            Dictionary<char, string> coloursDictionary = new Dictionary<char, string>
            {
                {'Y', "Yellow"}, {'G', "Green"}, {'R', "Red"}, {'B', "Blue"}
            };
            Regex pattern = new Regex("Fc([YGRB])");
            string[] mas = text.Split('\n');
            for (int i = 0; i < mas.Length; i++)
            {
                if (pattern.IsMatch(mas[i]))
                {
                    string color = pattern.Match(mas[i]).Groups[1].Value;
                    string fontColor = $@"<font color=""{coloursDictionary[color.First()]}""";
                    int indexOf = mas[i].IndexOf('>');
                    mas[i] = mas[i].Substring(3, indexOf - 2) + fontColor + mas[i].Substring(indexOf);
                }
            }

            return mas;
        }

        private void CreateHtmlDoc(string textInBody)
        {
            StringBuilder sb = new StringBuilder();
            string meta = @"<meta charset=""UTF-8"">";
            sb.Append("<html>")
                .Append("<head>")
                .Append(meta)
                .Append("<title>")
                .Append("</title>")
                .Append("</head>")
                .Append("<body>")
                .Append(textInBody)
                .Append("</body>")
                .Append("</html>");
            using (StreamWriter sw = new StreamWriter($"{Directory.GetCurrentDirectory()}\\MyHtml.html"))
                sw.Write(sb.ToString());
            System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}\\MyHtml.html");
        }
    }
}
