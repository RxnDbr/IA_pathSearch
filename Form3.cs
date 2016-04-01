using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IA_projet_p1
{
    public partial class Form3 : Form
    {
        public List<Destination> lDest;
        public List<CheckBox> lCheckBox;

        public Form3(List<Destination> _lDest)
        {
            lDest = _lDest;
            InitializeComponent();
            lCheckBox = new List<CheckBox> {
                cb_a,cb_b,cb_c,cb_d,cb_e,
                cb_f,cb_g,cb_h,cb_i,cb_j,
                cb_k,cb_l,cb_m,cb_n,cb_o,
                cb_p,cb_q,cb_r,cb_s,cb_t,
                cb_u,cb_v,cb_w};
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (Destination d in lDest)
            {
                lb_destinationStart.Items.Add(d.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph g = new Graph();
            GraphNode N0 = new GraphNode(lDest[0]);

            List<string> lChecked = new List<string>();
            foreach (CheckBox cb in lCheckBox)
            {
                if (cb.Checked) lChecked.Add(cb.Text);
            }

            List<GraphNode> LPassage = new List<GraphNode>(); //liste des endroits par où il faut passer
            foreach (Destination dest in lDest) //compare toutes les entrées du form aux destinations
            {
                if (dest.Name.Equals(lb_destinationStart.SelectedItem))
                {
                    N0 = new GraphNode(dest);
                }

                if (lChecked.Contains(dest.Name))
                {
                    LPassage.Add(new GraphNode(dest));
                }
            }
            //Il faut calculer le cout de toutes les liaisons possibles dans les Lpassage

            Tuple<List<GenericNode>, double>[][] LTousChemins = g.retourneTousChemins(LPassage);

            Tuple<List<GenericNode>, double>[] mst = g.MST(LTousChemins);

            double heuristique = 0;
            for (int i = 0; i < mst.Count(); i++)
            {
                heuristique += mst[i].Item2;
            }

            List<Tuple<List<GenericNode>, double>> bfg = g.BFG(LTousChemins);
            Tuple<List<GenericNode>, double> sommeChemins = g.concateneChemins(bfg);
        }


        private void lb_destinationStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (CheckBox cb in lCheckBox)
            {
                if (cb.Text.Equals(lb_destinationStart.SelectedItem))
                {
                    cb.Checked = true;
                    cb.Enabled = false;

                }
                else
                {
                    cb.Enabled = true;
                }
            }
        }
    }
}
