using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__12
{
    public class NumberTwoClass
    {
        /// <summary>
        /// Метод рассчитывающий количество тонн во введенной массе
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tonni"></param>
        /// <returns>Вывод количества тонн</returns>
        public int CalcTonni(int value, out int tonni)
        {
            tonni = value / 1000;
            return tonni;
        }

        /// <summary>
        /// Метод рассчитывающий количество килограмм во введенной массе
        /// </summary>
        /// <param name="value"></param>
        /// <param name="kg"></param>
        /// <returns>Вывод количества килограмм</returns>
        public int CalcKg(int value, out int kg)
        {
            kg = value % 1000;
            return kg;
        }
    }
}
