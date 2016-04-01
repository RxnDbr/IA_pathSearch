using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IA_projet_p1
{
    class Chemin
    {
        private GraphNode dest1;
        public GraphNode Dest1 {get{return dest1;}}
        private GraphNode dest2;
        public GraphNode Dest2 {get{return dest2;}}

        public Chemin(GraphNode _dest1, GraphNode _dest2)
        {
            dest1 = _dest1;
            dest2 = _dest2;
        }

        public double getCost()
        {
            Graph g = new Graph();
            GraphNode.villeterminale = dest2.Destination;
            List<GenericNode> Lchemin = g.RechercheSolutionAEtoile(dest1);
            return Lchemin[Lchemin.Count()-1].GetGCost();
        }
    }
}
