using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace IA_projet_p1
{
    class Graph
    {
        public List<GenericNode> L_Ouverts;
        public List<GenericNode> L_Fermes;

        private GenericNode ChercheNodeDansFermes(string NodeName)
        {
            int i = 0;

            while (i < L_Fermes.Count)
            {
                if (L_Fermes[i].GetNom() == NodeName)
                    return L_Fermes[i];
                i++;
            }
            return null;
        }

        private GenericNode ChercheNodeDansOuverts(string NodeName)
        {
            int i = 0;

            while (i < L_Ouverts.Count)
            {
                if (L_Ouverts[i].GetNom() == NodeName)
                    return L_Ouverts[i];
                i++;
            }
            return null;
        }

        public List<GenericNode> RechercheSolutionAEtoile(GenericNode N0)
        {
            L_Ouverts = new List<GenericNode>();
            L_Fermes = new List<GenericNode>();
            // Le noeud passé en paramètre est supposé être le noeud initial
            GenericNode N = N0;
            L_Ouverts.Add(N0);

            // tant que le noeud n'est pas terminal et que ouverts n'est pas vide
            while (L_Ouverts.Count != 0 && N.EndState() == false)
            {
                // Le meilleur noeud des ouverts est supposé placé en tête de liste
                // On le place dans les fermés
                L_Ouverts.Remove(N);
                L_Fermes.Add(N);

                // Il faut trouver les noeuds successeurs de N
                this.MAJSuccesseurs(N);
                // Inutile de retrier car les insertions ont été faites en respectant l'ordre

                // On prend le meilleur, donc celui en position 0, pour continuer à explorer les états
                // A condition qu'il existe bien sûr
                if (L_Ouverts.Count > 0)
                {
                    N = L_Ouverts[0];
                }
                else
                {
                    N = null;
                }
            }

            // A* terminé
            // On retourne le chemin qui va du noeud initial au noeud final sous forme de liste
            // Le chemin est retrouvé en partant du noeud final et en accédant aux parents de manière
            // itérative jusqu'à ce qu'on tombe sur le noeud initial
            List<GenericNode> _LN = new List<GenericNode>();
            if (N != null) // si N = endstate
            {
                _LN.Add(N); //on ajoute le endstate à la liste des noeuds

                //tant qu'on est pas remonté jusqu'au noeud initial, on prend parent.
                while (N != N0) 
                {
                    N = N.GetNoeud_Parent();
                    _LN.Insert(0, N);  // On insère en position 1 le noeud
                }
            }
            return _LN; //retourne la liste des noeuds pour atteindre N state
        }

        private void MAJSuccesseurs(GenericNode N)
        {
            // On fait appel à GetListSucc, méthode abstraite qu'on doit réécrire pour chaque
            // problème. Elle doit retourner la liste complète des noeuds successeurs de N.
            List<GenericNode> listsucc = N.GetListSucc();
            foreach (GenericNode N2 in listsucc)
            {
                // N2 est-il une copie d'un nœud déjà vu et placé dans la liste des fermés ?
                GenericNode N2bis = ChercheNodeDansFermes(N2.GetNom());
                if (N2bis == null)
                {
                    // Rien dans les fermés. Est-il dans les ouverts ?
                    N2bis = ChercheNodeDansOuverts(N2.GetNom());
                    if (N2bis != null)
                    {
                        // Il existe, donc on l'a déjà vu, N2 n'est qu'une copie de N2Bis
                        // Le nouveau chemin passant par N est-il meilleur ?
                        if (N.GetGCost() + N.GetArcCost(N2) < N2bis.GetGCost())
                        {
                            // Mise à jour de N2bis
                            N2bis.SetGCost(N.GetGCost() + N.GetArcCost(N2));
                            // HCost pas recalculé car toujours bon
                            N2bis.calculCoutTotal(); // somme de GCost et HCost
                            // Mise à jour de la famille ....
                            N2bis.Supprime_Liens_Parent ();
                            N2bis.SetNoeud_Parent(N);
                            // Mise à jour des ouverts
                            L_Ouverts.Remove(N2bis);
                            this.InsertNewNodeInOpenList(N2bis);
                        }
                        // else on ne fait rien, car le nouveau chemin est moins bon
                    }
                    else
                    {
                        // N2 est nouveau, MAJ et insertion dans les ouverts
                        N2.SetGCost(N.GetGCost() + N.GetArcCost(N2));
                        N2.CalculeHCost();
                        N2.SetNoeud_Parent(N);
                        N2.calculCoutTotal(); // somme de GCost et HCost
                        this.InsertNewNodeInOpenList(N2);
                    }
                }
                // else il est dans les fermés donc on ne fait rien,
                // car on a déjà trouvé le plus court chemin pour aller en N2
            }
        }

        public void InsertNewNodeInOpenList(GenericNode NewNode)
        {
            // Insertion pour respecter l'ordre du cout total le plus petit au plus grand
            if (this.L_Ouverts.Count == 0)
            { L_Ouverts.Add(NewNode); }
            else
            {
                GenericNode N = L_Ouverts[0];
                bool trouve = false;
                int i = 0;
                do
                    if (NewNode.Cout_Total < N.Cout_Total)
                    {
                        L_Ouverts.Insert(i, NewNode);
                        trouve = true;
                    }
                    else
                    {
                        i++;
                        if (L_Ouverts.Count == i)
                        {
                            N = null;
                            L_Ouverts.Insert(i, NewNode);
                        }
                        else
                        { N = L_Ouverts[i]; }
                    }
                while ((N != null) && (trouve == false));
            }
        }

        // Si on veut afficher l'arbre de recherche, il suffit de passer un treeview en paramètres
        // Celui-ci est mis à jour avec les noeuds de la liste des fermés, on ne tient pas compte des ouverts
        public void GetSearchTree( TreeView TV )
        {
            if (L_Fermes == null) return;
            if (L_Fermes.Count == 0) return;
            
            // On suppose le TreeView préexistant
            TV.Nodes.Clear();

            TreeNode TN = new TreeNode ( L_Fermes[0].GetNom() );
            TV.Nodes.Add(TN);

            AjouteBranche ( L_Fermes[0], TN );
        }

        // AjouteBranche est exclusivement appelée par GetSearchTree; les noeuds sont ajoutés de manière récursive
        private void AjouteBranche( GenericNode GN, TreeNode TN)
        {
            foreach (GenericNode GNfils in GN.GetEnfants())
            {
                TreeNode TNfils = new TreeNode(GNfils.GetNom());
                TN.Nodes.Add(TNfils);
                if (GNfils.GetEnfants().Count > 0) AjouteBranche(GNfils, TNfils); 
            }
        }

        
        public Tuple<List<GenericNode>, double>[][] retourneTousChemins(List<GraphNode> LPassage)
        {
            //Retourne une matrice symétrique avec tous les chemins possibles entre une liste de point fournie en entrée
            Tuple<List<GenericNode>, double>[][] LToutesPos = new Tuple<List<GenericNode>,double>[LPassage.Count()][]; 
            //contient toutes les liasons entre 2 chemins et le cout pour les réunir
            for (int i = 0; i < LPassage.Count(); i++) 
            {
                LToutesPos[i] = new Tuple<List<GenericNode>, double>[LPassage.Count()];
            }
            for (int i = 0; i < LPassage.Count(); i++)
            {
                for (int j = i; j< LPassage.Count(); j++) //pour ne pas faire plusieurs fois les calculs
                {
                    double cout = 0;
                    if (j == i) { 
                        LToutesPos[i][i] = Tuple.Create(new List<GenericNode> {LPassage[i]}, cout);
                    }
                    else
                    {
                        GraphNode.villeterminale = LPassage[j].Destination;
                        List<GenericNode> chemin = this.RechercheSolutionAEtoile(LPassage[i]);
                        GraphNode.villeterminale = LPassage[i].Destination;
                        List<GenericNode> nimehc = this.RechercheSolutionAEtoile(LPassage[j]);
                        for(int k=0; k<chemin.Count()-1; k++) 
                        {
                            cout += chemin[k].GetArcCost(chemin[k+1]);
                        }

                        LToutesPos[i][j] = Tuple.Create(chemin, cout);
                        LToutesPos[j][i] = Tuple.Create(nimehc, cout);
                    }
                }
            }
            return LToutesPos;
        }

        public Tuple<List<GenericNode>, double>[] MST(Tuple<List<GenericNode>, double>[][] LToutesPos)
        {
            Tuple<List<GenericNode>, double>[] mst = new Tuple<List<GenericNode>, double>[LToutesPos.GetLength(0)];
            for(int i=0; i<LToutesPos.GetLength(0); i++)
            //foreach (Tuple<List<GenericNode>, double>[] ligne in LToutesPos)
            {
                double[] listeCout = new double[LToutesPos.GetLength(0)];
                for (int j=0; j<LToutesPos.GetLength(0); j++)
                {
                    if (!(i == j)) listeCout[j] = -LToutesPos[i][j].Item2;
                    else listeCout[j] = - double.MaxValue; 
                }
                int index = FonctionsUtiles.IndexOfMaximumElement(listeCout);
                mst[i] = LToutesPos[i][index];
            }
            return mst;
        }

        public List<Tuple<List<GenericNode>, double>> BFG(Tuple<List<GenericNode>, double>[][] LtoutesPos)
        {
            //algo glouton du meilleur d'abord
            //Retourne la liste des points de passage dans l'ordre à emprunter avec le cout de chaque branche
            //initiatialisation
            List<Tuple<List<GenericNode>, double>> L_explores = new List<Tuple<List<GenericNode>, double>> ();
            List<Tuple<List<GenericNode>, double>> L_succ = new List<Tuple<List<GenericNode>, double>>() ;

            List<int> L_indexExpl = new List<int> {0};
            List<int> L_indexSucc = new List<int>();

            for (int i = 1; i < LtoutesPos[0].Count(); i++)
            {
                L_succ.Add(LtoutesPos[0][i]);
                L_indexSucc.Add(i);
            }

            while (L_succ.Count != 0)
            {
                L_succ.Clear();
                List<double> L_couts = new List<double>();

                //trouver dans Ltoutespos la ligne où il y a le point de départ


                //calculer le minimum de cout sur cette ligne entre les différents succésseurs
                for (int j = 0; j<LtoutesPos[0].Count(); j++)
                {
                    if (L_indexSucc.Contains(j))
                    {
                        L_couts.Add(LtoutesPos[L_indexExpl[L_indexExpl.Count - 1]][j].Item2);
                    }
                    else L_couts.Add(double.MaxValue);
                }

                //prendre le meilleur et l'ajouter à L_explores
                int minIndex = L_couts.IndexOf(L_couts.Min());
                L_explores.Add(LtoutesPos[L_indexExpl[L_indexExpl.Count - 1]][minIndex]);
                L_indexExpl.Add(minIndex);
                //Le supprimer de L_succ
                L_indexSucc.Remove(minIndex);
                foreach (int index in L_indexSucc)
                {
                    L_succ.Add(LtoutesPos[L_indexExpl[L_indexExpl.Count - 1]][index]);
                }
            }
            //retourne a la ferme à la fin
            L_explores.Add(LtoutesPos[L_indexExpl[L_indexExpl.Count - 1]][0]);
            return L_explores;
        }

        public Tuple<List<GenericNode>, double> deuxOpt(Tuple<List<GenericNode>, double> cheminInitial,Tuple<List<GenericNode>, double>[][] LtoutesPos )
        {
            
            //init
            int ind_t1_ch = 0;
            int ind_t2_ch = ind_t1_ch+1;

            GenericNode t1 = cheminInitial.Item1[ind_t1_ch];
            GenericNode t2 = cheminInitial.Item1[ind_t2_ch];

            List<GenericNode> echanges_possibles = a_echanger(t1, t2, cheminInitial.Item1, LtoutesPos);

            GenericNode ta = echanges_possibles[0];
            int ind_ta_ch = cheminInitial.Item1.IndexOf(ta);
            int ind_tb_ch = ind_ta_ch+1;
            GenericNode tb = cheminInitial.Item1[ind_tb_ch];

            int ind_t1_mat;
            int ind_t2_mat;
            int ind_ta_mat;
            int ind_tb_mat;

            double cout1;
            double cout2;

            double prop_cout;


            Tuple<List<GenericNode>, double> nxChemin = Tuple.Create(new List<GenericNode>(cheminInitial.Item1), cheminInitial.Item2);

            while (echanges_possibles.Count() > 0 && ind_t1_ch< nxChemin.Item1.Count - 4)
            {

                //place dans la matrice de couts totaux
                ind_t1_mat = trouverIndice(t1, LtoutesPos);
                ind_t2_mat = trouverIndice(t2, LtoutesPos);
                ind_ta_mat = trouverIndice(ta, LtoutesPos);
                ind_tb_mat = trouverIndice(tb, LtoutesPos);

                //calcule la différence de cout avec et sans intersection 
                cout1 = LtoutesPos[ind_t1_mat][ind_t2_mat].Item2 + LtoutesPos[ind_ta_mat][ind_tb_mat].Item2;
                cout2 = LtoutesPos[ind_t1_mat][ind_ta_mat].Item2 + LtoutesPos[ind_t2_mat][ind_tb_mat].Item2;

                //si le cout1 est plus élevé, c'est que l'intersection est là et donc que le chemin n'est pas optimal
                //il faut alors inverser t2 et ta
                if (cout1 > cout2)
                {
                    List<GenericNode> prop_chemin = new List<GenericNode>();

                    int i;
                    for (i = 0; i <= ind_t1_ch; i++) //le chemin et le cout restent les memes
                    {
                        prop_chemin.Add(cheminInitial.Item1[i]);
                    }
                    for (i = ind_ta_ch; i >= ind_t2_ch; i--) //inverse chemin et calc nouveau cout
                    {
                        prop_chemin.Add(cheminInitial.Item1[i]);
                    }
                    for (i = ind_tb_ch; i < cheminInitial.Item1.Count(); i++) //chemins et couts restent les mêmes
                    {
                        prop_chemin.Add(cheminInitial.Item1[i]);
                    }

                    prop_cout = cheminInitial.Item2 + (cout1 - cout2);

                    nxChemin = Tuple.Create(prop_chemin, prop_cout);
                    //il faut reconstruire les nouvelles possibilités
                    echanges_possibles = a_echanger(t1, ta, prop_chemin, LtoutesPos);
                }

                else
                {
                    echanges_possibles.Remove(ta);
                }

                //ne regarde solutions suivante que si au moins 4 noeuds suivant 
                while (echanges_possibles.Count() == 0 && ind_t1_ch < nxChemin.Item1.Count - 4)
                {
                    t1 = nxChemin.Item1[ind_t1_ch + 1];
                    t2 = nxChemin.Item1[ind_t1_ch + 2];
                    echanges_possibles = a_echanger(t1, t2, nxChemin.Item1, LtoutesPos);
                }

                //prend le premier élmt, au hasard, de 
                ta = echanges_possibles[0];
                //trouver place de ta dans le chemin initial

                //place dans le chemin
                ind_t1_ch = nxChemin.Item1.IndexOf(t1);
                ind_t2_ch = ind_t1_ch + 1;
                ind_ta_ch = nxChemin.Item1.IndexOf(ta);
                ind_tb_ch = ind_ta_ch + 1;
                tb = nxChemin.Item1[ind_tb_ch];
            }
            return nxChemin;

        }

        public Tuple<List<GenericNode>, double> concateneChemins(List<Tuple<List<GenericNode>, double>> bfg)
        {
            double coutTot = 0.0;
            List<GenericNode> pointsParcours = new List<GenericNode>();
            foreach (Tuple<List<GenericNode>, double> bout in bfg)
            {
                List<GenericNode> boutSans1er = new List<GenericNode> (bout.Item1);
                if (!(bout.Equals(bfg.First())))
                {
                    boutSans1er.Remove(bout.Item1.First());
                }
                pointsParcours.AddRange(boutSans1er as IEnumerable<GenericNode>);
                
                coutTot += bout.Item2;
            }
            Tuple<List<GenericNode>, double> cheminFinal = Tuple.Create(pointsParcours, coutTot);
            return cheminFinal; 
        }



        public List<GenericNode> a_echanger(GenericNode t1, GenericNode t2,List<GenericNode> routeActuelle, 
            Tuple<List<GenericNode>, double>[][] LtoutesPos)
        {
            //retourne la liste de toutes les permutations susceptibles d'être intéressantes

            List<GenericNode> L_echangesPossibles = new List<GenericNode>();
            //trouver les indices
            int ind_t1_mat = trouverIndice(t1, LtoutesPos);
            int ind_t2_mat = trouverIndice(t2, LtoutesPos);

            //chercher tous les noeuds plus proches de t1 que de t2
            for (int i = 0; i < routeActuelle.Count(); i++)
            {
                if (i > ind_t2_ch) //ECRIRE TROUVER INDICE PLUS EFFICACE QUE INDEXOF POUR TROUVER LE PREMIER ELMT ???
                {
                    int indiceI = trouverIndice(routeActuelle[i], LtoutesPos);
                    //on va essayer d'échanger les routes qui sont plus proches de t1 que de t2
                    if (LtoutesPos[ind_t1_mat][indiceI].Item2 < LtoutesPos[ind_t2_mat][indiceI].Item2 &&
                        !(routeActuelle[i].Equals(t1)) &&
                        !(routeActuelle[i].Equals(t2)))
                    {
                        L_echangesPossibles.Add(routeActuelle[i]);
                    }
                }
            }
            return L_echangesPossibles;
        }

        public int trouverIndice(GenericNode a_trouver, Tuple<List<GenericNode>, double>[][] LtoutesPos)
        {
            for (int i = 0; i < LtoutesPos[0].Count() ; i++)
            {
                if (LtoutesPos[i][0].Item1[0].GetNom().Equals(a_trouver.GetNom()))
                {
                    return i;
                }
            }
            return -1; //if error
        }

    
    }
}
