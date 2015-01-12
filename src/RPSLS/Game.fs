module Game

type Move = 
    | Unknown
    | Rock
    | Paper 
    | Scissors
    | Lizard
    | Spock

let GetRandomMove n = 
    let rnd = System.Random();
    let output = [ for i in 1 .. n -> 
        let index = rnd.Next(0, 5)
        match index with
        | 0 -> Move.Rock
        | 1 -> Move.Paper
        | 2 -> Move.Scissors
        | 3 -> Move.Lizard
        | 4 -> Move.Spock
        | _ -> Move.Unknown
    ]
    output
    

let GetRoundOutputText moves =
    match moves with
    | (Move.Scissors, Move.Paper) | (Move.Paper, Move.Scissors) -> "Scissors cuts Paper"
    | (Move.Paper, Move.Rock) | (Move.Rock, Move.Paper) -> "Paper covers Rock"
    | (Move.Rock, Move.Lizard) | (Move.Lizard, Move.Rock) -> "Rock crushes Lizard"
    | (Move.Lizard, Move.Spock) | (Move.Spock, Move.Lizard) -> "Lizard poisons Spock"
    | (Move.Spock, Move.Scissors) | (Move.Scissors, Move.Spock) -> "Spock smashes Scissors"
    | (Move.Scissors, Move.Lizard) | (Move.Lizard, Move.Scissors) -> "Scissors decapitates Lizard"
    | (Move.Lizard, Move.Paper) | (Move.Paper, Move.Lizard) -> "Lizard eats Paper"
    | (Move.Paper, Move.Spock) | (Move.Spock, Move.Paper) -> "Paper disproves Spock"
    | (Move.Spock, Move.Rock) | (Move.Rock, Move.Spock) -> "Spock vaporizes Rock"
    | (Move.Rock, Move.Scissors) | (Move.Scissors, Move.Rock) -> "Rock crushes scissors"
    | (x, y) when (x = y) -> "Draw"
    | (_, _) -> "Unknown move pair"

    
let GetMovesFromInput (input : string) =
    let inputList = Array.toList (input.Split [|' '|])

    let moves = List.map (fun x -> 
        match x with
        | "R" -> Move.Rock
        | "P" -> Move.Paper
        | "S" -> Move.Scissors
        | "L" -> Move.Lizard
        | "M" -> Move.Spock
        | _ -> Move.Unknown) inputList
    moves

