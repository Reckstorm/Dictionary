namespace Classwork_29._10._2022
{
    internal class MyDict : IDisposable
    {
        public Dictionary<string, List<string>> dict { get; set; }

        private string path;
        public MyDict(string path = "dict.txt")
        {
            this.path = path;
            if (File.Exists(path))
            {
                dict = new Dictionary<string, List<string>>(ReadDict(path));
            }
            else
            {
                dict = new Dictionary<string, List<string>>();
            }
        }

        public string AddWord(string key, List<string> value)
        {
            string str = $"Word {key} already exists";
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
                str = $"Word {key} successfuly added";
            }
            return str;
        }

        public string AddTranslation(string key, string translation)
        {
            string str = $"Translation {translation} already exists";
            if (dict.ContainsKey(key))
            {
                if (!dict[key].Contains(translation))
                {
                    dict[key].Add($"{translation}");
                    str = "Translation successfuly added";
                }
            }
            else
            {
                AddWord(key, new List<string> { $"{translation}" });
                str = $"No relevant word. New word {key} has been added";
            }
            return str;
        }
        public string FindTranslationByKey(string key)
        {
            string str = "No relevant value";
            if (dict.ContainsKey(key))
            {
                str = $"Translation for {key} is: ";
                foreach (var item in dict[key])
                {
                    str += item;
                }
            }
            return str;
        }

        public string FindTranslationByValue(string value)
        {
            string str = "No relevant value";
            foreach (var item in dict)
            {
                if (item.Value.Contains(value))
                {
                    str = $"Translation for {value} is: {item.Key}";
                }
            }
            return str;
        }

        public string RemovePairByKey(string key)
        {
            string str = "No relevant value";
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
                str = $"Pair {key} removed";
            }
            return str;
        }

        public string RemovePairByValue(string value)
        {
            string str = "No relevant item";
            foreach (var item in dict)
            {
                if (item.Value.Contains(value))
                {
                    str = $"Translation {value} removed";
                    item.Value.Remove(value);
                }
            }
            return str;
        }

        private Dictionary<string, List<string>> ReadDict(string path)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (var item in File.ReadLines(path))
            {
                if (item != "")
                {
                    var tempStr = item.Split(':');
                    List<string> tempList = new List<string>(tempStr[1].Split(' '));
                    dict.Add(tempStr[0], tempList);
                }
            }
            return dict;
        }

        private void SaveDict()
        {
            File.WriteAllText(path, "");
            foreach (var item in dict)
            {
                File.AppendAllText(path, $"{item.Key}:");
                foreach (var innerItem in item.Value)
                {
                    if (item.Value.IndexOf(innerItem) != item.Value.Count-1)
                    {
                        File.AppendAllText(path, $"{innerItem} ");
                    }
                    else
                    {
                        File.AppendAllText(path, $"{innerItem}");
                    }
                }
                File.AppendAllText(path, "\n");
            }
        }

        public void Dispose()
        {
            SaveDict();
        }
    }
}
