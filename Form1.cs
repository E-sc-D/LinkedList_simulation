using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using scorza.edoardo._4j.linked.listSimulation.mod;

namespace scorza.edoardo._4j.linked.listSimulation
{
    public partial class Form1 : Form
    {
        LinkedList lista;
        public Form1()
        {
            InitializeComponent();
             lista = new LinkedList();
            Refreshh();
        }
        public void Refreshh()
        {
            richTextBox1.Text = "";
            int posti = 0;
            string[,] photo = RManager.snap();
            for(int i = 0;i<photo.GetLength(0);i++)
            {
                for (int j = 0; j < photo.GetLength(1); j++)
                {
                    if(photo[i,j]==null|| photo[i, j] == "")
                    {
                        richTextBox1.AppendText( "□ ");
                    }
                    else
                    {
                        richTextBox1.AppendText("■ ");
                        posti++;
                    }
                }
            }
            textBox8.Text = "";
            for (int i = 0;i < lista.nofnode;i++)
            {
                textBox8.AppendText(" nodo " + (i + 1) + "   " + ((lista.listbus(i).current.x)+1) + ";" + ((lista.listbus(i).current.y)+1)+"--");
            }
            nofnode.Text = Convert.ToString(lista.nofnode)+" nodi totali";
            label4.Text = posti + " su " + (20 * 20) + " usati"; 
        }

        private void nadd_Click(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(inp_addnode.Text);
            if(lista.nofnode>input-1)
            {
                lista.addnde(input-1);
            }
            else
            {
                lista.addnde(-1);
            }
            Refreshh();
        }

        private void rmv_Click(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(inp_rmv.Text);
            if (lista.nofnode > input-1)
            {
                lista.rmNode(input-1);
            }
            Refreshh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = vall.Text;
            int loc = Convert.ToInt32(inp_edit.Text);
            if (lista.nofnode > loc-1)
            {
                lista.editnode(value, loc-1);
            }
            Refreshh();
        }
    }
}
