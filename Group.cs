using System;
using System.Collections.Generic;

namespace Repartidor
{
    public class Group
    {
        private int id;
        private Queue<string> students= new Queue<string>();
        private Queue<string> theme = new Queue<string>();

        public int Id{get => id; set => id = value;}
        public Queue<string> Students {get => students; set => students = value;}
        public Queue<string> Theme {get => theme; set=> theme = value;} 

    }
}
