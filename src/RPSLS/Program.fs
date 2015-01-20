open Game
open System

open RandomMoveGenerator

[<EntryPoint>]
let main argv = 

    let randGen = new RandomMoveGenerator()
    let x = randGen.GenerateMove(5)
    for i = 0 to x.Length - 1 do
        printfn "%A" (x.Item(i))
    Console.ReadKey()
    0

    (*
    try
        try
            let userInput = Console.ReadLine()
            let newGame = new RPSLS(userInput)
            newGame.RunGame()
        with
            _ -> printfn "An error occured"
    finally    
        printfn "Press any key to quit"
        Console.ReadKey()
        *)
        


    0

