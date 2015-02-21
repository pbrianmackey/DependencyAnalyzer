using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractReferences.Prolog
{
    public static class Rules
    {
        public static string DirectReference = "directReference(A,B) :- projectReferences(A,B).\n";
        public static string TransitiveReference = 
            "transitiveReference(A,C) :- directReference(A,B),directReference(B,C).\n";
        public static string TransitiveReferenceDepth1 =
            "transitiveReferenceD1(A,D) :- transitiveReference(A,C),directReference(C,D).\n";
        public static string TransitiveReferenceDepth2 =
            "transitiveReferenceD2(A,E) :- transitiveReferenceD1(A,D),directReference(D,E).\n";
    }
}
