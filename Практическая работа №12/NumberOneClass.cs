using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__12
{
    public class NumberOneClass
    {
        /// <summary>
        /// Метод для рассчёта объёма куба
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ob"></param>
        /// <returns>Вывод объёма</returns>
        public int CalcOb(int value, out int ob)
        {
            ob = value * value * value;
            return ob;
        }

        /// <summary>
        /// Метод для рассчёта площади поверхности куба
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pl"></param>
        /// <returns>Вывод площади</returns>
        public int CalcPl(int value, out int pl)
        {
            pl = 6 * value * value;
            return pl;
        }
    }
}
