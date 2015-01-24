module MoveTests

open System
open Xunit
open Move

[<Fact>]
let Move_Diff_Lizard_Lizard_Returns_0() =
    let compMove = Move.Lizard
    let playerMove = Move.Lizard
    let diff = Math.Abs( (int)(compMove - playerMove) % 5)
    Assert.Equal(0, diff)

[<Fact>]
let Move_Diff_Rock_Scissors_Returns_4() =
    let compMove = Move.Rock
    let playerMove = Move.Scissors
    let diff = Math.Abs( (int)(compMove - playerMove) % 5)
    Assert.Equal(4, diff)

[<Fact>]
let Move_Diff_Scissors_Rock_Returns_4() =
    let compMove = Move.Scissors
    let playerMove = Move.Rock
    let diff = Math.Abs( (int)(compMove - playerMove) % 5)
    Assert.Equal(4, diff)
