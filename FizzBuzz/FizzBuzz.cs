namespace FizzBuzzLibrary
{
    public class FizzBuzz
    {
        public static string FizzBuzzPrint(int num)
        {
            string s = "";
            if (num < 1 || num > 100) return s;
            if (num % 3 == 0) s += "Fizz";
            if (num % 5 == 0) s += "Buzz";
            if (s == "") s = num.ToString();
            return s;
        }
    }
}
