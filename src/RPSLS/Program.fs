open Game
open System

[<EntryPoint>]
let main argv = 
    
    // let x = GetRandomMove 5
    // for i in 0 .. 4 do
    //    printfn "%A" (x.Item(i))
    
    // let r = GetRoundOutputText (Move.Scissors, Move.Paper)
    

    let m = GetMovesFromInput (Console.ReadLine())
    for i in 0 .. m.Length - 1 do
        printfn "%A" (m.Item(i))


    let s = Console.ReadLine()
    printfn "%s" s
    
    0 
