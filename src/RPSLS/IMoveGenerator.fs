module IMoveGenerator
open Move

type IMoveGenerator =
    abstract member GenerateMove : int ->  List<Move>


