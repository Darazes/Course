using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    

        class Work
    {
        Viddeat vdeat;
        string unit;
        float costunit;
        int countunit;
        Object target;

        public Work() { }
        ~Work() { }

        public Viddeat getvdeat()
        {
            return vdeat;
        }

        public string getunit()
        {
            return unit;
        }

        public float getcostunit()
        {
            return costunit;
        }

        public int getcountunit()
        {
            return countunit;
        }

        public void setvdeat(Viddeat vdeat)
        {
            this.vdeat = vdeat;
        }

        public void setunit(string unit) //Задание названия еденицы измерения
        {
            this.unit = unit;
        }

        public void setcostunit(float costunit) //Задание цены еденицы выполненной работы
        {
            this.costunit = costunit;
        }
        public void setcountunit(int countunit) //Задание кол-ва едениц выполненной работы
        {
            this.countunit = countunit;
        }
        public void setObject(Object target)
        {
            this.target = target;
        }


        public float Accounting() //Расчёт з/п
        {
            return (costunit * countunit);
        }

        public void Print()
        {
            Console.WriteLine("Еденица измерения: " + unit);
            Console.WriteLine("Цена еденицы измерения: " + costunit);
            Console.WriteLine("Количество выполненной работы: " + countunit);
            Console.WriteLine($"Вид деятельности: " + vdeat.getviddeat()); 
            Console.WriteLine($"Работа на объекте: " + target.getnameobject());
        }
        public void Printf(SaveManager file)
        {
            file.WriteLine("Еденица измерения: " + unit);
            file.WriteLine("Цена еденицы измерения: " + costunit);
            file.WriteLine("Количество выполненной работы: " + countunit);
            file.WriteLine($"Вид деятельности: " + vdeat.getviddeat());
            file.WriteLine($"Работа на объекте: " + target.getnameobject());
        }

    }
}
