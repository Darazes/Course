using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    class Object
    {
        string nameobject; //Имя объекта

        public Object() { }
        public Object(string[] elements)
        {
            setnameobject(elements[7]);
        }
        public string getnameobject()
        {
            return nameobject;
        }

        public void setnameobject(string nameobject)
        {
            this.nameobject = nameobject;
        }
    }
}
