using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public struct Percent
    {
        readonly int percent;

        public Percent(int value)
        {
            if (value < 0)
                percent = 0;
            else if (value > 100)
                percent = 100;
            else
                percent = value;
        }

        public static implicit operator Percent(int value)
        {
            return new Percent(value);
        }

        public static implicit operator int(Percent value)
        {
            return value.percent;
        }
    }
}
