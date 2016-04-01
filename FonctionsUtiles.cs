using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IA_projet_p1
{
    public static class FonctionsUtiles
    {
        public static int IndexOfMaximumElement(double[] doubleTab)
        {
            int MaxIDX = -1;
            double Max = -1;

            for (int i = 0; i < doubleTab.Length; i++)
            {
                if (i == 0)
                {
                    Max = doubleTab[0];
                    MaxIDX = 0;
                }
                else
                {
                    if (doubleTab[i] > Max)
                    {
                        Max = doubleTab[i];
                        MaxIDX = i;
                    }
                }
            }

            return MaxIDX;
        }
    }
}
