module Game

open Move
open IMoveGenerator

type RPSLS(userInput: string, moveGenerator: IMoveGenerator) = 
    let mutable playerScore = 0
    let mutable computerScore = 0
    let moveGen = moveGenerator

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
        | (_, _) -> failwith "Unknown move pair"

    member this.PlayerScore 
        with get () = playerScore
        and set (value) = playerScore <- value
    
    member this.ComputerScore 
        with get () = computerScore
        and set (value) = computerScore <- value
    
    member this.PlayerMoves = this.GetMovesFromInput(userInput)

    member this.RunGame() = 
        let n = this.PlayerMoves.Length
        let ComputerMoves = moveGen.GenerateMove n
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