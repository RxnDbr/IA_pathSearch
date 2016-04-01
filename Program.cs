using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IA_projet_p1
{
    static class Program
    {
        /// <summary>

        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Destination A = new Destination("A");
            Destination B = new Destination("B");
            Destination C = new Destination("C");
            Destination D = new Destination("D");
            Destination E = new Destination("E");
            Destination F = new Destination("F");
            Destination G = new Destination("G");
            Destination H = new Destination("H");
            Destination I = new Destination("I");
            Destination J = new Destination("J");
            Destination K = new Destination("K");
            Destination L = new Destination("L");
            Destination M = new Destination("M");
            Destination N = new Destination("N");
            Destination O = new Destination("O");
            Destination P = new Destination("P");
            Destination Q = new Destination("Q");
            Destination R = new Destination("R");
            Destination S = new Destination("S");
            Destination T = new Destination("T");
            Destination U = new Destination("U");
            Destination V = new Destination("V");
            Destination W = new Destination("W");

            A.maj(new Dictionary<Destination, int> {
                {B, 4},
                {C, 5},
                {D, 6}
            });
            B.maj(new Dictionary<Destination, int> {
                {A, 4},
                {E, 5}
            });
            C.maj(new Dictionary<Destination, int>
            {
                {A, 5},
                {D, 4},
                {E, 6},
                {G, 8}
            });
            D.maj(new Dictionary<Destination, int> 
            {
                {A, 6},
                {C, 4},
                {F, 9}
            });
            E.maj(new Dictionary<Destination, int>
            {
                {B, 5}, 
                {C, 6},
                {H, 4}
            });
            F.maj(new Dictionary<Destination, int> 
            {
                {D, 9},
                {L, 9}
            });
            G.maj(new Dictionary<Destination, int> 
            {
                {C, 8},
                {H, 8},
                {K, 8} 
            });
            H.maj(new Dictionary<Destination, int> 
            {
                {E, 4},
                {G, 8},
                {I, 2}
            });
            I.maj(new Dictionary<Destination, int> 
            {
                {H, 2},
                {J, 3},
                {K, 4}
            });
            J.maj(new Dictionary<Destination, int> 
            {
                {I, 3 }
            });
            K.maj(new Dictionary<Destination, int> 
            {
                {G, 8},
                {I, 4},
                {W, 7}
            });
            L.maj(new Dictionary<Destination, int> 
            {
                {F, 9},
                {M, 2},
                {N, 4},
                {Q, 7},
                {W, 10}
            });
            M.maj(new Dictionary<Destination, int> {
                { L,2 }
            });
            N.maj(new Dictionary<Destination, int> 
            {
                {L, 4},
                {O, 7},
                {P, 3}
            });
            O.maj(new Dictionary<Destination, int> 
            {
                {N, 7},
                {P, 3},
                {S, 8}
            });
            P.maj(new Dictionary<Destination, int> 
            {
                {N, 3},
                {O, 3},
                {R, 5}
            });
            Q.maj(new Dictionary<Destination, int> 
            {
                {L, 7},
                {R, 3}
            });
            R.maj(new Dictionary<Destination, int> 
            {
                {P, 5},
                {Q, 3},
                {T, 6}
            });
            S.maj(new Dictionary<Destination, int> 
            {
                {O, 8},
                {U, 7}
            });
            T.maj(new Dictionary<Destination, int> 
            {
                {R, 6},
                {U, 5}
            });
            U.maj(new Dictionary<Destination, int> 
            {
                {S, 7},
                {T, 5},
                {V, 11}
            });
            V.maj(new Dictionary<Destination, int> 
            {
                {U, 11},
                {W, 6}
            });
            W.maj(new Dictionary<Destination, int> 
            {
                {K, 7},
                {L, 10},
                {V, 6}
            });
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Destination> lDest = new List<Destination>();
            lDest.Add(A);
            lDest.Add(B);
            lDest.Add(C);
            lDest.Add(D);
            lDest.Add(E);
            lDest.Add(F);
            lDest.Add(G);
            lDest.Add(H);
            lDest.Add(I);
            lDest.Add(J);
            lDest.Add(K);
            lDest.Add(L);
            lDest.Add(M);
            lDest.Add(N);
            lDest.Add(O);
            lDest.Add(P);
            lDest.Add(Q);
            lDest.Add(R);
            lDest.Add(S);
            lDest.Add(T);
            lDest.Add(U);
            lDest.Add(V);
            lDest.Add(W);

            Application.Run(new Form3(lDest));
            /*   This
  means
that in our search, having fixed
t
1
and
t
2
, the possibilities for
t
3
can be limited to those
cities that are closer to
t
2
than is
t
1
. */
        }
    }
}
