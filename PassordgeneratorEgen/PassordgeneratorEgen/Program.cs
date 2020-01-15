using System;

namespace PassordgeneratorEgen
{
    class Program
    {
        static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
                args = Console.ReadLine().Split(' ');

                if (args.Length != 2 || !IsNumber(args[0]) || !IsValid(args[1]))
                {
                    helpText();

                }
                else if (args.Length >= 2 && IsNumber(args[0]))
                {
                    if (IsValid(args[1]))
                    {
                    Console.WriteLine("characters is valid");

                    }
                }

               

            var length = Convert.ToInt32(args[0]);
            var options = args[1];
            var pattern = options.PadRight(length, 'l');
            var password = string.Empty;

            while (pattern.Length > 0) {
                    var lastCharOfPattern = Random.Next(0, pattern.Length - 1);
                    var category = pattern[lastCharOfPattern];
                    pattern = pattern.Substring(0, lastCharOfPattern)
                       + pattern.Substring(lastCharOfPattern + 1, pattern.Length - lastCharOfPattern - 1);
                    if (category == 'l') password += GetRandomLowerCaseLetter();
                    else if (category == 'L') password += GetRandomUpperCaseLetter();
                    else if (category == 's') password += WriteRandomSpecialCharacter();
                    else if (category == 'd') password += WriteRandomDigit();
                }
                Console.WriteLine(password);
            }

        }

        private static char GetRandomLowerCaseLetter()
            {
               return GetRandomLetter('a','z');
            }
        
        private static char GetRandomUpperCaseLetter()
        {
            return GetRandomLetter('A', 'Z');
        }

        private static char WriteRandomSpecialCharacter()
        {
            var allSpecialCharacters = "!\"#¤%/()[]{}";
            var index = Random.Next(0, allSpecialCharacters.Length - 1);
            return allSpecialCharacters[index];
        }

        private static char WriteRandomDigit()
        {
            return Random.Next(0,9).ToString()[0];
        }
        static char GetRandomLetter(char min, char max)
        {
            return (char)Random.Next(min, max);
        }
        private static bool IsNumber(string arg)
        {
            foreach (var c in arg)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                };
            }
            return true;
        }
        private static bool IsValid(string arg)
        {
            var status = true;
            foreach (var c in arg)
            {
                if (c == 'l' || c == 'L' || c == 's' || c == 'd')
                {
                    continue;
                }
                status = false;
            }
            return status;

        }

        private static void helpText()
        {
            Console.WriteLine("PassordgeneratorEgen");
            Console.WriteLine("Options:");
            Console.WriteLine("-l = lower case letter");
            Console.WriteLine("-L = upper case letter");
            Console.WriteLine("-d = digit");
            Console.WriteLine("-s = special character(!\"#¤%&/(){}[]");
            Console.WriteLine("Example: PasswordGenerator 14 llLLssdd");
            Console.WriteLine("Min. 1 lower case");
            Console.WriteLine(" Min. 1 upper case");
            Console.WriteLine("Min. 2 special characters");
            Console.WriteLine(" Min. 2 digits");
        }
    }
}
