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
    public partial class Form2 : Form
    {
        public List<Destination> lDest;

        public Form2(List<Destination> _lDest)
        {
            lDest = _lDest;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph g = new Graph();
            GraphNode N0 = new GraphNode(lDest[0]); //par défaut
            List<GraphNode> LPassage = new List<GraphNode>(); //liste des endroits par où il faut passer
            
            foreach (Destination dest in lDest) //compare toutes les entrées du form aux destinations
            {
                if (dest.Name.Equals(lb_destinationStart.SelectedItem))
                {
                    N0 = new GraphNode(dest);
                    LPassage.Add(N0); //noeud à la liste des endroits de passage
                }

                if (dest.Name.Equals(lb_destination1.SelectedItem) ||
                    dest.Name.Equals(lb_destination2.SelectedItem) ||
                    dest.Name.Equals(lb_destination3.SelectedItem) ||
                    dest.Name.Equals(lb_destination4.SelectedItem) ||
                    dest.Name.Equals(lb_destination5.SelectedItem)
                    )
                {
                    //N1 = new GraphNode(dest);
                    LPassage.Add(new GraphNode(dest));
                }
            }
            //Il faut calculer le cout de toutes les liaisons possibles dans les Lpassage
            Tuple<List<GenericNode>, double>[][] LTousChemins = g.retourneTousChemins(LPassage);

            Tuple<List<GenericNode>, double>[] mst = g.MST(LTousChemins);
            
            double heuristique = 0;
            for(int i=0; i<mst.Count(); i++)
            {
                heuristique += mst[i].Item2;
            }

            //Tuple<List<GenericNode>, double> parcoursMST = g.getParcoursMST(mst);
            
            //La distance minimale a parcourir pour passer par tous les points et revenir au point A
            //apparaitrait si tous les points a parcourir soient sur le même chemin
            //et donc cette distance serait égale à la distance entre le point de départ et le point le plus éloigné *2 (A/R)

            //Pour minimiser les calculs on peut regarder si on est dans ce cas là

            //Le point de départ est toujours placé à l'indice 0 car crée en premier!
            //on regarde donc la distance maximale possible depuis le point de départ
            //puis on récupère son index pour pouvoir avoir la liste de genericnode correspondant dans LTousChemins       
            //double heuristique = LTousCouts[0].Max();
            //int indexOfMax = FonctionsUtiles.IndexOfMaximumElement(LTousCouts[0]);
            //List<GenericNode> L_heuristique = LTousChemins[0][indexOfMax];

            
            //On peut vérifier si tous les points de collecte sont sur le chemin pour arriver au point le plus éloigné
            /*bool ilsSontTousLa = true;
            foreach (GenericNode pointCollecte in LPassage)
            {
                //Nous sommes obligés de comparer les noms car les objets ne sont pas les mêmes 
                string nomPointCollecte = pointCollecte.GetNom();
                bool trouve = false;
                foreach (GenericNode passageHeuristique in L_heuristique)
                {
                    if (trouve) break;
                    if ((passageHeuristique.GetNom().Equals(pointCollecte.GetNom())))
                    {
                        trouve=true;
                    }
                }
                if (!(trouve)) 
                { ilsSontTousLa = false; }
            }

            //LPropTournee contient dans l'ordre les elmts de LPassage dans l'ordre de passage proposé et optimisé
            //Ses elmts sont sous forme de tuple pour contenir le nom du point et le cout pour y aller par rapport au point précédent
            //il contient également l'index de sa position dans LtousChemins et LtousCouts
            //Sa premiere et dernière destination sont forcément le point de départ.

            Tuple<string, double, int>[] LPropTournee = new Tuple<string, double, int>[LPassage.Count+1];
            //LPropTournee[0] = Tuple.Create(N0.GetNom(), 0.0, 0);
            
            LPropTournee[0] = Tuple.Create(LPassage[0].GetNom(), 0.0, 0);
            int indexARemplir = 1;
            //si tous les points de collectes sont dans le chemin pour aller au point le plus éloigné
            //on propose de passer par les points de collectes dans l'ordre de L_heuristique
            if (ilsSontTousLa)
            {
                //Parcours dans l'ordre de L_heuristique IMPORTANT
                foreach (GenericNode passageHeuristique in L_heuristique)
                {
                    string nomPassageH = passageHeuristique.GetNom();
                    bool trouve = false;
                    int i;
                    int index = 1; //utilisé plus tard
                    for (i = 1; i < LPassage.Count; i++)
                    //foreach (GenericNode pointCollecte in LPassage)
                    {
                        if (trouve) break;
                        //quand on trouve le po

                        else if (LPassage[i].GetNom().Equals(nomPassageH))
                        {
                            trouve = true;
                            //il faut trouver le cout dans LTousCouts qui correspond à la distance entre le point
                            //LPAssage[i] et le dernier point de passage de LPropTournee[i-1]
                            //il faut donc retrouver le nom du passage de LPropTournee[i-1]
                            //Et trouver son index de ligne dans LToutsCouts 
                            for (int j = 1; j < LTousChemins[0].Length; j++)
                            {
                                if (LTousChemins[0][j][LTousChemins[0][j].Count - 1].GetNom().Equals(LPassage[i].GetNom()))
                                {
                                    index = j;
                                    break;
                                }
                            }

                            double cout = LTousCouts[index][LPropTournee[indexARemplir - 1].Item3];
                            LPropTournee[indexARemplir] = Tuple.Create(nomPassageH, cout, index);
                            indexARemplir += 1;
                        }
                    }
                }
                LPropTournee[indexARemplir] = Tuple.Create(N0.GetNom(), LTousCouts[0][LPropTournee[indexARemplir - 1].Item3], 0);
            }

            //si tous les points ne sont pas dans la liste de l'heuristique, on fait avec a etoile
            else
            {

            }


            //Tester toutes les combinaisons possibles
            //Dans tous les cas on part de N0 et on revient à N0

            //Tester d'abors si tout les points de LPassage sont dans 
            List<double> LToutesTournees = new List<double>();*/



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Destination d in lDest)
            {
                lb_destinationStart.Items.Add(d.Name);
                lb_destination1.Items.Add(d.Name);
                lb_destination2.Items.Add(d.Name);
                lb_destination3.Items.Add(d.Name);
                lb_destination4.Items.Add(d.Name);
                lb_destination5.Items.Add(d.Name);
            }
        }
    }

}
