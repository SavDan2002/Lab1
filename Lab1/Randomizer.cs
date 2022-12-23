namespace Lab1
{
    internal static class Randomizer
    {
        private const int _NameCount = 100;
        private const string _NamesFile = "names.txt";
        private static readonly string _pathFirstName = Path.GetFullPath(_NamesFile);
        private static readonly Random random = new Random();
        private static string[] _listNames = new string[_NameCount];
        private static List<int> _mark = new List<int>();

        private static void InitList(string[] list, int list_size, string path)
        {
            string line = "";
            int i = 0;

            var sr = new StreamReader(path);
            while ((line = sr.ReadLine()) != null)
            {
                list[i] = line;
                i++;
            }
        }

        static Randomizer()
        {
            InitList(_listNames, _NameCount, _pathFirstName);
        }

        public static string GetRandomName()
        {
            int randomName = random.Next(0, _NameCount);
            return _listNames[randomName];
        }

        public static int GetRandomWithoutRepeatMark()
        {
            int mark = random.Next();
            while (_mark.Exists(x => x.Equals(random)) == true)
            {
                mark = random.Next();
            }

            _mark.Add(mark);
            return mark;
        }
    }
}