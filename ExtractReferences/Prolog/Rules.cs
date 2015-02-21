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
            "transitiveReference(A,D) :- directReference(A,B),directReference(B,C),directReference(C,D).\n";
    }
}
