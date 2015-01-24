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

[<Fact>]
let Move_Diff_Player_Rock_Computer_Paper_Computer_Wins() =
    let compMove = Move.Scissors
    let playerMove = Move.Rock
    let mutable playerScore = 0
    let mutable computerScore = 0
    let diff = Math.Abs( (int)(compMove - playerMove) % 5)
    if diff = 3 || diff = 4 then computerScore <- computerScore + 1
    elif diff = 1 || diff = 2 then playerScore <- playerScore + 1
    Assert.Equal(0, playerScore)
    Assert.Equal(1, computerScore)

