module RandomMoveGenerator

open IMoveGenerator
open Move

type RandomMoveGenerator() = 
    member this.GenerateMove(n) = (this :> IMoveGenerator).GenerateMove(n)
    interface IMoveGenerator with
        member this.GenerateMove(n) = 
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