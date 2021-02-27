using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scorza.edoardo._4j.linked.listSimulation.mod
{
    
    class LinkedList
    {
        int max_iterable = 600;
        Indexes head;
        public int nofnode;
        public LinkedList()
        {
            head = RManager.getfreespace();
            Node node = new Node(head);
            RManager.save(node, head);
            nofnode = 1;
        }
         public void editnode(string val, int location)
        {
            Node edit = listbus(location-1);
            edit.value = val;
            RManager.save(edit, listbus(location-1).current);
        }
        public void addnde(int location)
        {
            Node nnode = new Node();
            Node lastn=new Node();
            Node next = new Node();
            Indexes spaceAv = RManager.getfreespace();

                if (location == -1)
                {
                    lastn = (Node)RManager.get(listbus(location).current, typeof(Node));
                    lastn.next = spaceAv;
                    nnode.previus = lastn.current;
                    nnode.current = spaceAv;
                }
                if (location == 0)
                {
                    lastn = (Node)RManager.get(head, typeof(Node));
                    nnode.current = spaceAv;
                    nnode.next = lastn.current;
                    lastn.previus = nnode.current;              
                    head = nnode.current;
                }
                else if(location>0)
                {
                    lastn = (Node)RManager.get(listbus(location - 1).current, typeof(Node));
                    next = (Node)RManager.get(listbus(location).current, typeof(Node));
                    nnode.current = spaceAv;
                    nnode.next = lastn.next;
                    nnode.previus = lastn.current;
                    lastn.next = nnode.current;
                    next.previus = nnode.current;
                    RManager.save(next, next.current);
                }

            RManager.save(lastn, lastn.current);
            RManager.save(nnode, nnode.current);
            nofnode++;

        }
        public void rmNode(int location)
        {
            if(location>0)
            {
                Node prev = (Node)RManager.get(listbus(location).previus, typeof(Node));
                Node next;
                if(listbus(location).next.x==-1)
                {
                    prev.next = new Indexes();
                    RManager.save(prev, prev.current);
                }
                else
                {
                    next = (Node)RManager.get(listbus(location).next, typeof(Node));
                    next.previus = prev.current;
                    prev.next = next.current;
                    RManager.save(prev, prev.current);
                    RManager.save(next, next.current);
                }
            }

            
            nofnode--;
        }

        public Node listbus(int location)
        {
            Node curentN = (Node)RManager.get(head,typeof(Node));
            if (location == -1)
            {
                for (int i = 0; i < max_iterable; i++)
                {
                    if (curentN.next.y == -1)
                    {
                        return curentN;
                    }
                    curentN = (Node)RManager.get(curentN.next, typeof(Node));
                }
            }
            if (location >= 0)
            {
                for (int i = 0; i < location; i++)
                {
                    curentN = (Node)RManager.get(curentN.next, typeof(Node));
                }
                return curentN;
            }
            return null;

        }
    }
    
}
