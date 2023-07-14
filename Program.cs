var config = new AdditiveGenerationConfig();

config.blockLocation = "/Users/emmanueltran/Programmation/procedural_generation/resources/blocks/cour_blocks";

config.doorsPosition.Add(Tuple.Create(10,0));
config.doorsPosition.Add(Tuple.Create(20,0));
config.doorsPosition.Add(Tuple.Create(0,10));
config.doorsPosition.Add(Tuple.Create(0,20));
config.doorsPosition.Add(Tuple.Create(29,10));
config.doorsPosition.Add(Tuple.Create(29,20));
config.doorsPosition.Add(Tuple.Create(10,29));
config.doorsPosition.Add(Tuple.Create(20,29));

config.stopPredicate = (Board board, int iter) =>
{
    return board.getEltCount() > 200 || iter > 200000;
};

config.paddingDecayRate = 0.5;

var b = new AdditiveGenerationEngine(config);
b.run();

var a = b.getBoard();
var outputLocation = "/Users/emmanueltran/Programmation/procedural_generation/out";
a.writeToFile(outputLocation);
