module FakeMoveGenerator

open IMoveGenerator
open Move

type FakeMoveGenerator(moves : List<Move>) = 
    let mutable moveList = moves
    
    member this.MoveList 
        with get () = moveList
        and set (value) = (moveList <- value)

    member this.GenerateMove(n) = (this :> IMoveGenerator).GenerateMove(n)
    
    interface IMoveGenerator with
        member this.GenerateMove(n) = 
            let output = [ for i in 1 .. n -> 
                moveList.Item(i-1)
            ]
            output