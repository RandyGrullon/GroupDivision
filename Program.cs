using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Repartidor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue<string> Student = new Queue<string>();
            Queue<Group> Groups = new Queue<Group>();
            Queue<string> Theme = new Queue<string>();


            FillTail(Theme, args[1]);
            FillTail(Student, args[0]);
                for (int i = 0; i < int.Parse(args[2]); i++)
                {
                    Gruop group1 = new Gruop();
                    group1.Id = 1 + i;
                    Groups.Enqueue(group1);
                }
        
                    Student = Shuffle(Student);
                    Theme = Shuffle(Theme);

            string x=IsPosible(Student.Count, Theme.Count, Groups.Count);
            if(x=="s")
            {
                Groups = Shuffle(Groups);
                while(Student.Count != 0)
                {
                    foreach (var item in Groups)
                    {
                        if(Student.Count != 0){
                        string s = Student.Dequeue();
                        item.Student.Enqueue(s);
                        }
                    }
                }
                Groups = Shuffle(Groups);
                while(Theme.Count != 0)
                {
                    foreach (var item in Groups)
                    {
                        if(Theme.Count !=0){
                        string s = Theme.Dequeue();
                        item.Theme.Enqueue(s);
                        }
                    
                    }
                }
                Groups = new Queue<Grupo>(Groups.OrderBy(x=> x.Id));


                foreach (var item in Groups)
                {
                    int i = 0;
                    Console.WriteLine($"Groups {item.Id}, members({item.Student.Count}): ");
                    foreach (var studen in item.Student)
                    {
                        i++;
                        Console.WriteLine($"{i}. {studen}");
                    }
                    foreach (var tem in item.Theme)
                    {
                        Console.Write($"{tem}|");
                    }
                    Console.WriteLine("\n----------------------------------------------\n");
                }
            }
            else
            Console.WriteLine(x);
        }

        public static void FillTail(Queue<string> Tail, string Direction)
        {
            using(StreamReader Reader = new StreamReader(Direction)){
                string line;
                while((line = Reader.ReadLine())!= null)
                {
                    Tail.Enqueue(line);
                }
            }
        }
        public static string IsPosible(int Student, int Theme, int Groups){
            if(Groups > Student)
            return "Fallo, Hay mas grupos que studenudiantes";
            if (Groups > Theme)
            return "Fallo, Hay mas grupos que temas";
            return "s";
        }
        public static Queue<T> Shuffle<T>(Queue<T> Tail)
        {
            var Ramdon = new Random();
            return new Queue<T>(Tail.OrderBy(x => Ramdon.Next()));
        }
    }
}
