using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    static class Alphabet
    {

        static Dictionary<char, int> dict32 = new Dictionary<char, int>()
        {
            { 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 }, { 'Е', 6 }, { 'Ж', 7 }, { 'З', 8 }, { 'И', 9 }, { 'Й', 10 }, { 'К', 11 },
            { 'Л', 12 }, { 'М', 13 }, { 'Н', 14 }, { 'О', 15 }, { 'П', 16 }, { 'Р', 17 }, { 'С', 18 }, { 'Т', 19 }, { 'У', 20 }, { 'Ф', 21 }, { 'Х', 22 },
            { 'Ц', 23 }, { 'Ч', 24 }, { 'Ш', 25 }, { 'Щ', 26 }, { 'Ъ', 27 }, { 'Ы', 28 }, { 'Ь', 29 }, { 'Э', 30 }, { 'Ю', 31 }, { 'Я', 32 }

        };


        static Dictionary<char, int> dict33 = new Dictionary<char, int>()
        {
            { 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 }, { 'Е', 6 }, { 'Ё', 7 }, { 'Ж', 8 }, { 'З', 9 }, { 'И', 10 }, { 'Й', 11 },
            { 'К', 12 }, { 'Л', 13 }, { 'М', 14 }, { 'Н', 15 }, { 'О', 16 }, { 'П', 17 }, { 'Р', 18 }, { 'С', 19 }, { 'Т', 20 }, { 'У', 21 }, { 'Ф', 22 },
            { 'Х', 23 }, { 'Ц', 24 }, { 'Ч', 25 }, { 'Ш', 26 }, { 'Щ', 27 }, { 'Ъ', 28 }, { 'Ы', 29 }, { 'Ь', 30 }, { 'Э', 31 }, { 'Ю', 32 }, { 'Я', 33 }


        };

        public static char GetChar32(int index) { return dict32.ElementAt(index - 1).Key; }
        public static int GetCharIndex32(char ch) { return dict32[ch]; }
        public static char GetChar33(int index) { return dict33.ElementAt(index - 1).Key; }
        public static int GetCharIndex33(char ch) { return dict33[ch]; }
    }
}
