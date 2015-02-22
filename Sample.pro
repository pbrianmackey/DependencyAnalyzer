:- initialization main.

query :-
        current_prolog_flag(argv, Argv),
        concat_atom(Argv, ' ', Atom),
        read_term_from_atom(Atom, Term, []),
        call(Term).

main :-
        catch(query, E, (print_message(error, E), fail)),
        writeln(true),
        halt.
main :-
        writeln(false),
        halt(1).

a(b).
a(b,c).


directReference(A,B) :- projectReferences(A,B).
transitiveReference(A,C) :- directReference(A,B),directReference(B,C).
transitiveReferenceD1(A,D) :- transitiveReference(A,C),directReference(C,D).
transitiveReferenceD2(A,E) :- transitiveReferenceD1(A,D),directReference(D,E).
transitiveReferenceD3(A,F) :- transitiveReferenceD2(A,E),directReference(E,F).
transitiveReferenceD4(A,G) :- transitiveReferenceD3(A,F),directReference(F,G).
transitiveReferenceD5(A,H) :- transitiveReferenceD4(A,G),directReference(G,H).
transitiveReferenceD6(A,I) :- transitiveReferenceD5(A,H),directReference(H,I).
transitiveReferenceD7(A,J) :- transitiveReferenceD6(A,I),directReference(I,J).
transitiveReferenceD8(A,K) :- transitiveReferenceD7(A,J),directReference(J,K).
transitiveReferenceD9(A,L) :- transitiveReferenceD8(A,K),directReference(K,L).
transitiveReferenceD10(A,M) :- transitiveReferenceD9(A,L),directReference(L,M).

transitiveReferenceDN(A,X) :- transitiveReferenceD10(A,E),transitiveReferenceDN(E,X).