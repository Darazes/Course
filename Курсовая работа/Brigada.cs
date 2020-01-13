using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    class Brigada
    {
        int Numberbrigada;
        string FIO;
        float Zp;
        List<Work> works;
        public Brigada() { }
        ~Brigada() { }

        public int getNumberbrigada()
        {
            return Numberbrigada;
        }
        public string getFIO()
        {
            return FIO;
        }
        public float getZp()
        {
            return Zp;
        }

        public List<Work> getworks(List<Work> works)
        {
            return works;
        }

        public void setNumberbrigada(int Numberbrigada)
        {
            this.Numberbrigada = Numberbrigada;
        }
        public void setworks(List<Work> works)
        {
            foreach (Work w in works) this.works = works;
        }

        public void setFIO(string FIO)
        {
            this.FIO = FIO;
        }
        public void setZp(List<Work> works)
        {
            foreach (Work w in works) this.Zp = w.Accounting();
        }

        
        public void Print()
        {
            Console.WriteLine("Номер бригады: " + Numberbrigada);
            Console.WriteLine("ФИО бригадира: " + FIO);
            Console.WriteLine("Зарплата за месяц работника бригады: " + Zp);
            Console.WriteLine("Зарплата за месяц бриадира: " + Zp*1.2);
            foreach (Work w in works) w.Print();
        }
        public void PrintFile(StreamWriter file)
        {
            file.WriteLine("Номер бригады: " + Numberbrigada);
            file.WriteLine("ФИО бригадира:  " + FIO);
            file.WriteLine("Зарплата за месяц каждого работника бригады: " + Zp);
            file.WriteLine("Зарплата за месяц бриадира: " + Zp * 1.2);
            foreach (Work w in works) w.Printf(file);
        }
    }

}
