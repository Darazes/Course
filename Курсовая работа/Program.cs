using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Курсовая_работа
{
    class Program
    {
        static void Main(/*string[] args*/)
        {

            int Numberbrigada;
            string FIO;
            int[] size = new int[10];
            int[] plan = new int[10];
            int countunit;
            string unit;
            float costunit;
            string namedeat;
            string operationdeat;
            string tg;
            int i = 0;
            bool flag = false;

            //Создание или перезапись файла для последующей записи.
            Console.WriteLine("БАЗА ДАННЫХ СТРОИТЕЛЬНОЙ ФИРМЫ");
            

            Console.WriteLine("Выберите параметр записи(1-Добавление;2-Перезапись):");
            int parametr = int.Parse(Console.ReadLine());
            if (parametr == 2) flag = true;
            StreamWriter file = new StreamWriter(("Result.txt"), true);
            if (flag == true)
            {
                file.Close();
                file = new StreamWriter(File.Create("Result.txt"));
                file.WriteLine("БАЗА ДАННЫХ СТРОИТЕЛЬНОЙ ФИРМЫ");
            }
   
                while (true)
                        {
                        Console.WriteLine("БАЗА ДАННЫХ СТРОИТЕЛЬНОЙ ФИРМЫ");
                        Console.WriteLine("==============================");
                        Console.WriteLine("======Меню======");
                        Console.WriteLine("0-Ввод из файла");
                        Console.WriteLine("1-Ввод из консоли");
                        Console.WriteLine("2-Очистить базу данных");
                        Console.WriteLine("3-Завершить редактирование");
                        Console.WriteLine("4-Выход из программы");
                        int sp = int.Parse(Console.ReadLine());
                        switch (sp)
                        {
                            case 0:  //Считывание массива объектов и действий с ними
                                i = 0;
                                Brigada[] brigf = new Brigada[30];
                                Work[] workf = new Work[30];
                                List<Work>[] worksf = new List<Work>[30];
                                Viddeat[] viddeatf = new Viddeat[30];
                                Object[] targetf = new Object[30];
                                StreamReader sr = File.OpenText("Brigada.txt");
                                while (true)
                                {
                                    string str = sr.ReadLine();
                                    if (str == null)
                                        break;
                                    string[] elements = str.Split(';');


                                    //Бригада(считывание значений)
                                    brigf[i] = new Brigada();
                                    brigf[i].setFIO(elements[0]);
                                    brigf[i].setNumberbrigada(int.Parse(elements[1]));

                                    viddeatf[i] = new Viddeat(); //Считывание видов деятельности бригад
                                    viddeatf[i].setnamedeat(elements[2]);
                                    viddeatf[i].setoperationdeat(elements[3]);

                                    targetf[i] = new Object(); //Считывание объектов бригад
                                    targetf[i].setnameobject(elements[7]);

                                    worksf[i] = new List<Work>(); //Инициализация листа работ бригады
                                    
                                    workf[i] = new Work();
                                    workf[i].setunit(elements[4]);
                                    workf[i].setcountunit(int.Parse(elements[5]));
                                    workf[i].setcostunit(float.Parse(elements[6]));
                                    plan[i] = int.Parse(elements[8]);
                                    workf[i].setObject(targetf[i]);
                                    workf[i].setvdeat(viddeatf[i]);
                                    worksf[i].Add(workf[i]); //Добавление работы в лист работ бригады

                                    brigf[i].setZp(worksf[i]); // Пересчёт з.п
                                    brigf[i].setworks(worksf[i]); //Передача работ
                                    i++;

                                }
                                sr.Close();

                                i = 0;
                                while (true)
                                {
                                    if (brigf[i] == null) break;
                                    brigf[i].Print();
                                    brigf[i].PrintFile(file);
                                if (workf[i].getcountunit() >= plan[i])
                                {
                                    Console.WriteLine("Бригада премирована на: " + (brigf[i].getZp() * 0.2));
                                    file.WriteLine("Бригада премирована на: " + (brigf[i].getZp() * 0.2));
                                }
                                else
                                {
                                    Console.WriteLine("Бригада не премирована.");
                                    file.WriteLine("Бригада не премирована.");
                                }
                                    file.WriteLine("===============");
                                    Console.WriteLine("===============");
                                    i++;

                                }
                                break;

                                case 1: //Ввод с консоли значений

                                Console.Write("Enter count brigada= "); //Задание числа бригад
                                int n = int.Parse(Console.ReadLine());

                                Brigada[] brig = new Brigada[n];
                                Work[] work = new Work[n];
                                Viddeat[] viddeat = new Viddeat[n];
                                Object[] target = new Object[n];
                                List<Work>[] works = new List<Work>[n];

                        for (i = 0; i < n; i++)
                        {
                            
                            Console.Write("Введите ФИО бригадира[" + (i + 1) + "]= ");
                            FIO = Console.ReadLine();
                            


                            Console.Write("Введите номер бригады[" + (i + 1) + "]= ");
                            Numberbrigada = int.Parse(Console.ReadLine());
                            if (Numberbrigada < 0)
                            {
                                Console.WriteLine("Введено неверное значение,введите заново");
                                Numberbrigada = int.Parse(Console.ReadLine());
                            }

                            Console.WriteLine("Введите количество работ бригады");
                            size[i]= int.Parse(Console.ReadLine());
                            if (size[i] < 1)
                            {
                                Console.WriteLine("Введено неверное значение,введите заново");
                                size[i] = int.Parse(Console.ReadLine());
                            }

                            for (int j = 0; j < size[i]; j++)
                            {

                                Console.Write("Введите еденицу измерения[" + (j + 1) + "] ");
                                unit = Console.ReadLine();

                                Console.Write("Введите название объекта с которым работают[" + (j + 1) + "] ");
                                namedeat = Console.ReadLine();

                                Console.Write("Введите действие с объектом[" + (j + 1) + "]");
                                operationdeat = Console.ReadLine();

                                Console.Write("Введите объект на котором производится работа[" + (j + 1) + "] ");
                                tg = Console.ReadLine();

                                Console.Write("Введите цену за еденицу измерения[" + (j + 1) + "] ");
                                costunit = float.Parse(Console.ReadLine());

                                if (costunit < 0)
                                {
                                    Console.WriteLine("Введено неверное значение,введите заново");
                                    costunit = float.Parse(Console.ReadLine());
                                }

                                Console.Write("Введите количество сделанной бригадиром работы[" + (j + 1) + "] ");
                                countunit = int.Parse(Console.ReadLine());

                                if (countunit < 0)
                                {
                                    Console.WriteLine("Введено неверное значение,введите заново");
                                    countunit = int.Parse(Console.ReadLine());
                                }

                                Console.Write("Введите план сделанной бригадиром работы[" + (j + 1) + "] ");
                                plan[j] = int.Parse(Console.ReadLine());

                                if (plan[j] < 0)
                                {
                                    Console.WriteLine("Введено неверное значение,введите заново");
                                    plan[j] = int.Parse(Console.ReadLine());
                                }
                                

                                viddeat[j] = new Viddeat();
                                viddeat[j].setnamedeat(namedeat);
                                viddeat[j].setoperationdeat(operationdeat);

                                target[j] = new Object();
                                target[j].setnameobject(tg);

                                works[j] = new List<Work>(); //Инициализация листа работ бригады

                                work[j] = new Work();
                                work[j].setunit(unit);
                                work[j].setcountunit(countunit);
                                work[j].setcostunit(costunit);
                                work[j].setObject(target[j]);
                                work[j].setvdeat(viddeat[j]);
                                works[j].Add(work[j]); //Добавление работы в лист работ бригады

                                brig[j] = new Brigada();
                                brig[j].setZp(works[j]); // Пересчёт з.п
                                brig[j].setworks(works[j]); //Передача работ
                                brig[j].setFIO(FIO);
                                brig[j].setNumberbrigada(Numberbrigada);


                            }

                            for (int a = i; a < n; a++)
                                for (int j = 0; j < size[a]; j++)
                                {
                                    brig[j].Print();
                                    brig[j].PrintFile(file);
                                    if (work[j].getcountunit() >= plan[j])
                                    {
                                        Console.WriteLine("Бригада премирована на: " + (brig[j].getZp() * 0.2));
                                        Console.WriteLine("=============================");
                                        file.WriteLine("Бригада премирована на: " + (brig[j].getZp() * 0.2));
                                        file.WriteLine("=============================");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Бригада не премирована.");
                                        Console.WriteLine("=============================");
                                        file.WriteLine("Бригада не премирована.");
                                        file.WriteLine("=============================");
                                    }

                                }



                        }
                                        //brig[i] = null;
                                    break;
                            case 2: file.WriteLine(""); break;
                            case 3: file.Close(); return;
                            case 4: Environment.Exit(0); break;
                            default:
                                Console.WriteLine("Введено неверное значение");
                                Console.ReadKey();
                                break;
                        };
                    
                
            }
            
        }
    }
}
