using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IA_projet_p1
{
    public class GraphNode : GenericNode
    {

        public static Destination villeterminale;
        private Destination destination;
        public Destination Destination { get { return destination; } }

        public GraphNode(Destination d) : base(d.Name)
        { 
            destination = d;
        }


        public override double GetArcCost(GenericNode N2) //donne cout pour aller de this a N2
        {
            return destination.Neighbors[(N2 as GraphNode).destination];
        }

        public override bool EndState() // determine si c'est noeud final, objectif de l'utilisateur
        {
            return destination.Equals(villeterminale);
        }

        public override List<GenericNode> GetListSucc() //donner ses liens
        {
           // retrouver ds destination le nd qui a ce name
            
            // new de liste genericnode
            List<GenericNode> neighbors = new List<GenericNode>();
            foreach (KeyValuePair<Destination, int> kvp in destination.Neighbors)
            {
                neighbors.Add(new GraphNode(kvp.Key));
            }
            return neighbors;
            //Enfants = 
            // pou chaque destination connecté
            // créer un graphnode avec le bon nom et ajouter à la liste
            // return liste
        }

        public override void CalculeHCost()
        {
            this.SetEstimation(0);
        }




    }
}
