using System.Text;

namespace Large_Factorial
{
    public class Kata
    {
        public static string Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return "1";
            }

            int[] result = new int[100000]; // массив для хранения результата (выберите нужный размер)
            int resultLength = 1; // длина результата
            result[0] = 1; // начальное значение

            // вычисление факториала
            for (int i = 2; i <= n; i++)
            {
                resultLength = Multiply(i, result, resultLength);
            }

            // преобразование результата в строку
            StringBuilder sb = new StringBuilder(resultLength);
            for (int i = resultLength - 1; i >= 0; i--)
            {
                sb.Append(result[i]);
            }
            return sb.ToString();
        }

        private static int Multiply(int x, int[] result, int resultLength)
        {
            int carry = 0;
            for (int i = 0; i < resultLength; i++)
            {
                int product = result[i] * x + carry;
                result[i] = product % 10;
                carry = product / 10;
            }
            while (carry != 0)
            {
                result[resultLength] = carry % 10;
                carry /= 10;
                resultLength++;
            }
            return resultLength;
        }
    }
}