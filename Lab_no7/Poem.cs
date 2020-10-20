using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_no7
{
    class Poem
    {
        public static string text = "У лукоморья дуб зелёный;\n" +
                                    "Златая цепь на дубе том:\n" +
                                    "И днём и ночью кот учёный\n" +
                                    "Всё ходит по цепи кругом;\n" +
                                    "Идёт направо — песнь заводит,\n" +
                                    "Налево — сказку говорит.\n" +
                                    "Там чудеса: там леший бродит,\n" +
                                    "Русалка на ветвях сидит;\n" +
                                    "Там на неведомых дорожках\n" +
                                    "Следы невиданных зверей;\n" +
                                    "Избушка там на курьих ножках\n" +
                                    "Стоит без окон, без дверей;\n" +
                                    "Там лес и дол видений полны;\n" +
                                    "Там о заре прихлынут волны\n" +
                                    "На брег песчаный и пустой,\n" +
                                    "И тридцать витязей прекрасных\n" +
                                    "Чредой из вод выходят ясных,\n" +
                                    "И с ними дядька их морской;\n" +
                                    "Там королевич мимоходом\n" +
                                    "Пленяет грозного царя;\n" +
                                    "Там в облаках перед народом\n" +
                                    "Через леса, через моря\n" +
                                    "Колдун несёт богатыря;\n" +
                                    "В темнице там царевна тужит,\n" +
                                    "А бурый волк ей верно служит;\n" +
                                    "Там ступа с Бабою Ягой\n" +
                                    "Идёт, бредёт сама собой,\n" +
                                    "Там царь Кащей над златом чахнет;\n" +
                                    "Там русский дух… там Русью пахнет!\n" +
                                    "И там я был, и мёд я пил;\n" +
                                    "У моря видел дуб зелёный;\n" +
                                    "Под ним сидел, и кот учёный\n" +
                                    "Свои мне сказки говорил.";

        public void StartTask()
        {
            text = First();
            Second();
            Third();
        }

        private string First()
        {
            Console.WriteLine("Первое задание: ");
            var words = text.Split();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < 4)
                    continue;
                if (words[i].Length >= 4 && words[i].Length < 7)
                {
                    words[i] = words[i].Substring(0, 3) + "#" + words[i].Substring(4);
                }
                else
                {
                    words[i] = words[i].Substring(0, 3) + "#" + words[i].Substring(4,3) + "#" + words[i].Substring(7);
                }
            }

            return string.Join(" ", words);
        }

        private void Second()
        {
            Console.WriteLine("Второе задание: ");
            var words = text.Split().ToHashSet();
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine($"{words.ElementAt(i)}:{text.Split().Count(x => x == words.ElementAt(i))}");
            }
        }


        private void Third()
        {
            Console.WriteLine("Третье задание: ");
            char[] vowels = { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };
            char[] nvowels =
            {
                'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'
            };
            var words = text.Split();
            for (int i = 0; i < words.Length; i++)
            {
                string remove = string.Concat(words[i].Where(x => x != ';'));
                if (nvowels.Contains(remove[0]) && vowels.Contains(remove[remove.Length - 1]))
                {
                    Console.WriteLine(remove);
                }
            }
        }

        public string Slow(string slowtext)
        {
            while (slowtext.Length < 100000)
                slowtext += $" {slowtext}";
            return slowtext;
        }

        public string Fast(string slowtext)
        {
            var sb = new StringBuilder();
            while (sb.Length < 100000)
                sb.Append($" {slowtext}");
            return sb.ToString();
        }
    }
}
