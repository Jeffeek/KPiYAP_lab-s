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
            Dictionary<char, string> coloursDictionary = new Dictionary<char, string>
            {
                {'Y', "Yellow"}, {'G', "Green"}, {'R', "Red"}, {'B', "Blue"}
            };
            string text = ReadFile();
            string pattern = "\\((u)\\)";
            Regex reg = new Regex(pattern);
            bool flag = true;
            while (reg.IsMatch(text))
            {
                //text = flag
                //    ? reg.Replace(text, "<u>", 1)
                //    : reg.Replace(text, "</u>", 1);

                //test
                text = reg.Replace(text, "<u>", 1);
                text = reg.Replace(text, "</u>", 1);

                flag = !flag;

                string[] mas = text.Split('\n');
                pattern = "Fc([YGRB])";
                reg = new Regex(pattern);
                for (int i = 0; i < mas.Length; i++)
                {
                    if (reg.IsMatch(mas[i]))
                    {
                        string color = reg.Match(mas[i]).Groups[1].Value;
                        string fontColor = $"<font color=\"{coloursDictionary[color.First()]}\"";
                        int indexOf = mas[i].IndexOf('>');
                        mas[i] = mas[i].Substring(3,  indexOf - 2) + " " + fontColor + mas[i].Substring(indexOf);
                    }
                }
                text = string.Join("<Br>", mas, 0, mas.Length);
            }
            CreateHtmlDoc(text);
        }

        private void CreateHtmlDoc(string textInBody)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            string meta = @"<meta charset=""UTF-8"">";
            sb.Append(meta);
            sb.Append("<title>");
            sb.Append("</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append(textInBody);
            sb.Append("</body>");
            sb.Append("</html>");
            using (StreamWriter sw = new StreamWriter($"{Directory.GetCurrentDirectory()}\\MyHtml.html"))
                sw.Write(sb.ToString());
            System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}\\MyHtml.html");
        }
    }
}
