using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    class Viddeat
    {
        string namedeat;
        string operationdeat;

        public Viddeat() { }
        public Viddeat(string[] elements)
        {
            setnamedeat(elements[2]);
            setoperationdeat(elements[3]);
        }
        ~Viddeat() { }

        public string getnamedeat()
        {
            return namedeat;
        }

        public string getoperationdeat()
        {
            return operationdeat;
        }
        public string getviddeat()
        {
            return namedeat + "_" + operationdeat;
        }

        public void setnamedeat(string namedeat)
        {
            this.namedeat = namedeat;
        }

        public void setoperationdeat(string operationdeat)
        {
            this.operationdeat = operationdeat;
        }
    }
}
