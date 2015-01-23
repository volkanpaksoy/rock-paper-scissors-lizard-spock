module RPSLSTests

open Xunit
open FakeMoveGenerator
open Game
open Move

[<Fact>]
let Game_Ends_With_Correct_Output_3_Moves_0_to_1() =
    let fakeGen = new FakeMoveGenerator([Move.Rock; Move.Rock; Move.Paper])
    let newGame = new RPSLS("r r r", fakeGen)
    newGame.RunGame()
    Assert.Equal(0, newGame.PlayerScore)
    Assert.Equal(1, newGame.ComputerScore)

[<Fact>]
let Game_Ends_With_Correct_Output_1_Moves_0_to_0() =
    let fakeGen = new FakeMoveGenerator([Move.Spock])
    let newGame = new RPSLS("m", fakeGen)
    newGame.RunGame()
    Assert.Equal(0, newGame.PlayerScore)
    Assert.Equal(0, newGame.ComputerScore)

[<Fact>]
let Game_Ends_With_Correct_Output_3_Moves_3_to_0() =
    let fakeGen = new FakeMoveGenerator([Move.Spock; Move.Lizard; Move.Paper])
    let newGame = new RPSLS("p s s", fakeGen)
    newGame.RunGame()
    Assert.Equal(3, newGame.PlayerScore)
    Assert.Equal(0, newGame.ComputerScore)

