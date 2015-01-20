module Game

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


type RPSLS(userInput: string) = 
    let mutable playerScore = 0
    let mutable computerScore = 0

    member this.GetMovesFromInput (input : string) =
        let inputList = Array.toList (input.Trim().Split [|' '|])
        let moves = List.map (fun (x: string) -> 
            match x.ToUpper() with
            | "R" -> Move.Rock
            | "P" -> Move.Paper
            | "S" -> Move.Scissors
            | "L" -> Move.Lizard
            | "M" -> Move.Spock 
            | _ -> failwith "Invalid move. Please enter one of the following: R(Rock), P(Paper), S(Scissors), L(Lizard), M(Mr. Spock)") inputList
        moves

    member this.GetRandomMove(n) = 
        let rnd = System.Random()
        let output = [ for i in 1 .. n -> 
            let index = rnd.Next(0, 5)
            match index with
            | 0 -> Move.Rock
            | 1 -> Move.Paper
            | 2 -> Move.Scissors
            | 3 -> Move.Lizard
            | 4 -> Move.Spock
            | _ -> failwith "Unexpected move"
        ]
        output

    member this.GetRoundOutputText(moves) =
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

    member this.PlayerScore 
        with get () = playerScore
        and set (value) = playerScore <- value
    member this.ComputerScore 
        with get () = computerScore
        and set (value) = computerScore <- value
    member this.PlayerMoves = this.GetMovesFromInput(userInput)

    member this.RunGame() = 
        let n = this.PlayerMoves.Length
        let ComputerMoves = this.GetRandomMove n
        for i in 0 .. n - 1 do
            printfn  "Player played %A" (this.PlayerMoves.Item(i))
            printfn  "Computer played %A" (ComputerMoves.Item(i))
            printfn  "Result: %s" (this.GetRoundOutputText (this.PlayerMoves.Item(i), ComputerMoves.Item(i)))
            let diff = (int)(this.PlayerMoves.Item(i) - ComputerMoves.Item(i))
            if diff = 1 then this.PlayerScore <- playerScore + 1
            elif diff = 2 then this.ComputerScore <- computerScore + 1
            printfn "Player: %d \t Computer: %d" this.PlayerScore this.ComputerScore
            printfn ""
            
        printfn ""
        printfn "-------------------------"
        printfn "GAME RESULT:"
        printfn "-------------------------"
        printfn "Player: %d \t Computer: %d" this.PlayerScore this.ComputerScore
        printfn "-------------------------"