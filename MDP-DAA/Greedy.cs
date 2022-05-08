using System;
using System.Collections.Generic;
using System.Text;

namespace MDP_DAA
{
    public class Greedy
    {
        /**
         * Contructive Greedy Algorithm for maximum diversity problem
         * given the gravity center gc, 
         * 1: Elem = gc;
         * 2: S = ∅;
         * 3: sc = center(Elem);
         * 4: repeat
         * 5: Obtener el elemento s∗ ∈ Elem más alejado de sc;
         * 6: S = S ∪ {s∗};
         * 7: Elem = Elem − {s∗};
         * 8: Obtener sc = centro(S);
         * 9: until (|S| = m)
         * 10: Devolver S;
         */
}
