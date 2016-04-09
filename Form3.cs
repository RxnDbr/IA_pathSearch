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
        public List<GraphNode> lNoeuds;
        public Tuple<List<GenericNode>, double>[][] lTousChemins;
        Graph g;

        public Form3(List<Destination> _lDest)
        {
            lDest = _lDest;
            g = new Graph();
            InitializeComponent();
            lCheckBox = new List<CheckBox> {
                cb_a,cb_b,cb_c,cb_d,cb_e,
                cb_f,cb_g,cb_h,cb_i,cb_j,
                cb_k,cb_l,cb_m,cb_n,cb_o,
                cb_p,cb_q,cb_r,cb_s,cb_t,
                cb_u,cb_v,cb_w};
            lNoeuds = new List<GraphNode>();
            foreach (Destination d in lDest)
            {
                lNoeuds.Add(new GraphNode(d));
            }
            lTousChemins = g.retourneTousChemins(lNoeuds);
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
            //LTousChemins est une matrice carrée et symétrique contenant toutes les possibilités de liaisons possibles
            //C'est un tupe ayant pour item 1 la manière la plus rapide d'arriver d'aller du point de départ au point d'arrivé
            //Et ayant pour deuxieme item le cout de ce trajet
            Tuple<List<GenericNode>, double>[][] LTousPassages = g.retourneTousChemins(LPassage);

            //Le minimum spanning tree
            Tuple<List<GenericNode>, double>[] mst = g.MST(LTousPassages);

            double heuristique = 0;
            for (int i = 0; i < mst.Count(); i++)
            {
                heuristique += mst[i].Item2;
            }

            //On génère un premier chemin grace au best first search qui servira de base 
            //Le chemin généré va du plus proche au plus proche
            //Cet algo a l'avantage d'etre extrement rapide car il n'explore qu'une toute petite partie de l'arbre
            //et n'est pas trop mauvais dans l'ensemble, surtout dans où le chemin fait une boucle

            Tuple<List<GenericNode>, double> chemin_alpha = g.genereCheminAlpha(LTousPassages);
            
            //bestFirst_segmente donne la liste des différents noeuds à parcourir séparement
            List<Tuple<List<GenericNode>, double>> best_first_segmente = g.BFS(LTousPassages);
            //best_first_ensemble assemble les différents segments pour ne donner plus qu'une liste avec tous les points où passer
            Tuple<List<GenericNode>, double> best_first_ensemble = g.concateneChemins(best_first_segmente);

            //chemin_ordonne assemble les différents segments pour ne donner plus qu'une liste des points de collecte ordonnée où passer
            Tuple<List<GenericNode>, double> chemin_ordonne = g.ordrePointsPassage(best_first_segmente);

            //2 opt va prendre en entrée le chemin déjà ordonné et teste toutes les permutations qui semblent pertinentes

            Tuple<List<GenericNode>, double> chemin_par2opt = g.deuxOpt(chemin_ordonne, LTousPassages);

            Tuple<List<GenericNode>, double> chemin2_par2opt = g.deuxOpt(chemin_alpha, LTousPassages);

            Tuple<List<GenericNode>, double> chemin3_par2opt = g.deuxOpt(best_first_ensemble, lTousChemins);



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
