namespace SortSpace
{
    public class KSort
    {
        public string[] items;
        public KSort()
        {
            int maxSize = 800;
            items = new string[maxSize];
        }

        public int Index(string s)
        {
            if (s == null || s == "" || s.Length > 3)
                return -1;

            string pattern = "abcdefgh";
            int bigDigit;

            if (pattern.Contains(s[0].ToString()))
                bigDigit = pattern.IndexOf(s[0]) * 100;
            else
                return -1;

            int midDigit;

            if (!int.TryParse(s[1].ToString(), out midDigit))
                return -1;

            midDigit *= 10;

            int smallDigit;

            if (!int.TryParse(s[2].ToString(), out smallDigit))
                return -1;

            return bigDigit + midDigit + smallDigit;
        }

        public bool Add(string s)
        {
            int index = Index(s);
            if (index == -1)
                return false;

            items[index] = s;

            return true;
        }
    }
}
