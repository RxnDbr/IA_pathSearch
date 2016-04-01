using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IA_projet_p1
{
    public class Destination
    {
        private Dictionary<Destination, int> neighbors;
        public Dictionary<Destination, int> Neighbors { get { return neighbors; } set { neighbors = value; } }

        private string name;
        public string Name {get{return name;} set{name=value;}}
        //private Dictionary<Destination, int> heuristic;

        public Destination(string name) { Name = name; }
        public void maj(Dictionary<Destination, int> _neighbors/*, Dictionary<Destination, int> _heuristic*/)
        {
            neighbors = _neighbors;
          //  neighbors[this] = 0;
            //[name] = KeyValuePair(name, 0);
            //heuristic = _heuristic;
        }
        public bool isImpasse()
        {
            if (neighbors.Count == 1) { return true; }
            return false;
        }

        /*public Dictionary<Destination, Tuple<int, Destination>> findShortest(Destination destination)
        {
            //Dictionnary composed to verified shortest path
            Dictionary<Destination, Tuple<int, Destination>> shortestPath = new Dictionary<Destination, Tuple<int, Destination>>();
            //contains himslef with null distance at the beginning
            //shortestPath[this] = Tuple.Create(0, new Destination());
            //contains all the explored nodes
            Dictionary<Destination, Tuple<int, Destination>> possibilities = new Dictionary<Destination,Tuple<int, Destination>>();
            //At the beginning, "this" is the start point
            Destination parent = this;

            bool stop = false;
            while (!stop)
            {
                //Look at each neighbor of the parent 
                foreach (KeyValuePair<Destination, int> child in parent.neighbors)
                {
                    if (!shortestPath.ContainsKey(child.Key))
                    {
                        //the distance to reach a point is the distance to reach the parent + the distance from the parent to the child
                        int dist = child.Value + shortestPath[parent].Item1;
                        if (possibilities.ContainsKey(child.Key))
                        {
                            if (possibilities[child.Key].Item1 > dist)
                            {
                                possibilities[child.Key] = Tuple.Create(dist, parent);
                            }
                        }
                        else
                        {
                            possibilities[child.Key] = Tuple.Create(dist, parent);
                        }
                    }
                }

                Destination minValue = possibilities.Where(x => x.Value.Item1 == possibilities.Min(y => y.Value.Item1)).Select(kvp => kvp.Key).First();
                shortestPath.Add(minValue, Tuple.Create(possibilities[minValue].Item1, possibilities[minValue].Item2));
                //shortestPath.Add(possibilities[minValue], Tuple<possibilities
                parent = minValue;
                possibilities.Remove(minValue);
                parent = minValue;
                if (possibilities.Count == 0) { stop = true; }
                else { stop = false; }
            }

            
            //int minValue = possibilities.Min(x => x.Value.Item1);

            return shortestPath;
        }*/


    }
}
