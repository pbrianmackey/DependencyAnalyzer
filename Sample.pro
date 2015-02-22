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

projectReferences('myProject', 'system').

