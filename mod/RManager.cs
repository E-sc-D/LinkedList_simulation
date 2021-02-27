using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace scorza.edoardo._4j.linked.listSimulation.mod
{
    
    static class RManager
    {
        static string[,] ram = new string[20,20];
        public static Indexes getfreespace()
        {
            Indexes lx = new Indexes();
            Random rnd = new Random();
            for (int i = 0; i < 700; i++)
            {
                lx.x = rnd.Next(0, 9);
                lx.y = rnd.Next(0, 9);
                if (ram[lx.x, lx.y] == null)
                {
                    return lx;
                }
            }
            return null;
        }
        public static void save(object saver, Indexes location)
        {
            string serializable = JsonConvert.SerializeObject(saver, Formatting.Indented);
            ram[location.x, location.y] = serializable;
        }
        public static object get(Indexes location,Type type)
        {
            return JsonConvert.DeserializeObject(ram[location.x, location.y],type);
        }
        public static void clear(Indexes location)
        {
            ram[location.x, location.y] = null;
        }
        public static string[,] snap()
        {
            return ram;
        }
        

    }

}
