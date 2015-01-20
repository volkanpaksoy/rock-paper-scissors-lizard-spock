module Move

type Move = 
    | Rock
    | Paper
    | Scissors
    | Lizard
    | Spock

    static member (-) (x, y) =
        match x, y with
        | Move.Scissors, Move.Paper -> 1
        | Move.Scissors, Move.Lizard -> 1
        | Move.Scissors, Move.Rock -> 2
        | Move.Scissors, Move.Spock -> 2
        | Move.Lizard, Move.Paper -> 1
        | Move.Lizard, Move.Rock -> 2
        | Move.Lizard, Move.Scissors -> 2
        | Move.Lizard, Move.Spock -> 1
        | Move.Paper, Move.Lizard -> 1
        | Move.Paper, Move.Rock -> 2
        | Move.Paper, Move.Scissors -> 2
        | Move.Paper, Move.Spock -> 1
        | Move.Spock, Move.Paper -> 2
        | Move.Spock, Move.Rock -> 1
        | Move.Spock, Move.Scissors -> 1
        | Move.Spock, Move.Lizard -> 2
        | Move.Rock, Move.Paper -> 2
        | Move.Rock, Move.Spock -> 2
        | Move.Rock, Move.Scissors -> 1
        | Move.Rock, Move.Lizard -> 1
        | (x, y) when (x = y) -> 0