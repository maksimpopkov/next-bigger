using System;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            
            if (number > 0)
            {
                char[] digits = number.ToString().ToCharArray();

                // Находим позицию, с которой начинается убывающая последовательность цифр
                int pivot = -1;
                for (int i = digits.Length - 1; i > 0; i--)
                {
                    if (digits[i - 1] < digits[i])
                    {
                        pivot = i - 1;
                        break;
                    }
                }

                // Если такой позиции нет, то число нельзя увеличить
                if (pivot == -1 || number == int.MaxValue)
                {
                    return null;
                }

                // Находим минимальную цифру справа от позиции pivot, но большую pivot
                for (int i = digits.Length - 1; i > pivot; i--)
                {
                    if (digits[i] > digits[pivot])
                    {
                        char temp = digits[i];
                        digits[i] = digits[pivot];
                        digits[pivot] = temp;
                        break;
                    }
                }

                // Переворачиваем часть числа справа от pivot
                Array.Reverse(digits, pivot + 1, digits.Length - pivot - 1);

                return int.Parse(new string(digits));
            }
            else
            {
               throw new ArgumentException($"Value of {nameof(number)} cannot be less zero.");
            }

        }
    }
}
