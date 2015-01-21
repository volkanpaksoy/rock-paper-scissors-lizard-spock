module RPSLS.Tests

open Xunit
open FakeMoveGenerator

[<Fact>]
let FakeMoveGenerator_Returns_The_Given_Move_List() = 
    let fakeGen = new FakeMoveGenerator([Move.Lizard; Move.Paper])
    Assert.Equal(2, fakeGen.MoveList.Length)
    Assert.Equal(Move.Lizard, fakeGen.MoveList.Item(0))
    Assert.Equal(Move.Paper, fakeGen.MoveList.Item(1))
    