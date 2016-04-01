using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IA_projet_p1
{
    public partial class Form1 : Form
    {
        public List<Destination> lDest;

        public Form1(List<Destination> _lDest)
        {
            lDest = _lDest;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GraphNode A = 

            Graph g = new Graph();
            GraphNode N0 = new GraphNode(lDest[0]); //par défaut
            GraphNode.villeterminale =  lDest[lDest.Count-1]; //par défaut
            foreach (Destination dest in lDest)
            {
                if (dest.Name.Equals(lb_destinationStart.SelectedItem))
                {
                    N0 = new GraphNode(dest);
                }

                if (dest.Name.Equals(lb_destinationEnd.SelectedItem))
                {
                    //N1 = new GraphNode(dest);

                    GraphNode.villeterminale = dest;
                }
            }
            List<GenericNode> Lres = g.RechercheSolutionAEtoile(N0);


            if (Lres.Count == 0)
            {
                labelsolution.Text = "Pas de solution";
            }
            else
            {
                
                double totalValue = Lres[Lres.Count()-1].GetGCost();


                labelsolution.Text = "Une solution a été trouvée, d'une valeur de : " + totalValue + " KM";
                foreach (GenericNode N in Lres)
                {
                    lb_destinationStart.Items.Add(N);
                }

                labelcountopen.Text = "Nb noeuds des ouverts : " + g.L_Ouverts.Count().ToString();
                labelcountclosed.Text = "Nb noeuds des fermés : " + g.L_Fermes.Count().ToString();
                g.GetSearchTree(treeView1);
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Destination d in lDest)
            {
                lb_destinationStart.Items.Add(d.Name);
                lb_destinationEnd.Items.Add(d.Name);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
