module IMoveGenerator
open Game

type IMoveGenerator =
    abstract member GenerateMove : int ->  List<Move>


