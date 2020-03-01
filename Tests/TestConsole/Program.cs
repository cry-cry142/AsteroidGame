using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer = new Gamer();
            gamer.Name = "Игрок 1";
            gamer.DayOfBirth = new DateTime(1983, 12, 4, 21, 2, 14);
        }
    }
    class Gamer
    {
        public string Name;
        public DateTime DayOfBirth;
    }
}
