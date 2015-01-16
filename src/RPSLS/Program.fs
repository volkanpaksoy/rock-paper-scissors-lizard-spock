open Game
open System

[<EntryPoint>]
let main argv = 

    let userInput = Console.ReadLine()
    let newGame = RPSLS(userInput)
    newGame.RunGame()
    0        




(*
    try
        try
            let newGame = RPSLS(userInput)
            newGame.RunGame()
            
        with
            _ -> printfn "An error occured"
   
    finally    
        Console.ReadLine()
*)



    (*
    let playerMoves = GetMovesFromInput ()
    let n = playerMoves.Length
    printfn "You played: "
    for i in 0 .. n - 1 do
        printfn "%A" (playerMoves.Item(i))

    printfn ""
    printfn "Generating computer moves"
    let computerMoves = GetRandomMove n
    printfn "Computer played: "
    for i in 0 .. n - 1 do
        printfn "%A" (computerMoves.Item(i))

    printfn ""
    printfn "Results:"    

    for i in 0 .. n - 1 do
        printfn  "%s" (GetRoundOutputText (playerMoves.Item(i), computerMoves.Item(i)))
        let diff = (int)(playerMoves.Item(i) - computerMoves.Item(i))
        if diff = 1 then playerScore <- playerScore + 1
        elif diff = 2 then computerScore <- computerScore + 1
        printfn "Player: %d \t Computer: %d" playerScore computerScore
    *)


    




(*


*)