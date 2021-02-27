using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scorza.edoardo._4j.linked.listSimulation.mod
{
    class Node
    {
        public Indexes current;
        public Indexes previus;
        public Indexes next;
        public string value;
        public Node(Indexes _current, Indexes _previus)
        {
            current = _current;
            previus = _previus;
            value = "";
            next = new Indexes();
        }
        public Node()
        {
            current = new Indexes();
            previus = new Indexes();
            value = "";
            next = new Indexes();
        }
        public Node(Indexes _current)
        {
            current = _current;
            previus = new Indexes();
            value = "";
            next = new Indexes();
        }
    }
}
    
