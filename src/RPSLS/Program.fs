open Game
open RandomMoveGenerator
open System


[<EntryPoint>]
let main argv = 

    try
        try
            let userInput = Console.ReadLine()
            let newGame = new RPSLS(userInput, new RandomMoveGenerator())
            newGame.RunGame()
        with
            _ -> printfn "An error occured"
    finally
        printfn "Press any key to quit"
        Console.ReadKey()

    0

