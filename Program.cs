using System;
using System.IO;
 

namespace ConsoleApp
{
    class Program
    {
        struct State
        {
            public string capital;
            public string name;
            public int adge;
            public State(string n, string c, int a)
            {
                capital = c;
                name = n;
                adge = a;
            }
        }
        static void Main(string[] args)
        {
            State[] states = new State[2];
            states[0] = new State("Финляндия","Харри Сятери",32);
            states[1] = new State("Россия", "Вадим Шипачев",34);
            string path = @"F:\ПП";
            try
            { // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(@"F:\ПП", FileMode.OpenOrCreate)))
                {// записываем в файл значение каждого поля структуры
                    foreach (State s in states)
                    {
                        writer.Write(s.capital);
                        writer.Write(s.name);
                        writer.Write(s.adge);
                    }
                }
                // создаем объект BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(@"F:\ПП", FileMode.Open)))
                { //пока не достигнут конец файла считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        string capital = reader.ReadString();
                        string name = reader.ReadString();
                        int adge = reader.ReadInt32();
                        Console.WriteLine("Страна: {0}, Игрок: {1} {2} года ", name,  capital, adge);
                    }
                } 
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            Console.ReadLine();
        }

    }
}
