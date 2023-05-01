public class ProceduralGeneration {
    protected int board_size;
    protected int[,] board;

    public ProceduralGeneration(int size) {
        board_size = size;
        board = new int[size,size];
    }

    public void run() {
    }

    public void writeToFile() {
       using (StreamWriter writer = new StreamWriter("/Users/emmanueltran/Programmation/procedural_generation/out")){
            var i = 0;
            foreach (var item in board) {
                writer.Write(item);
                i = (i+1)%board_size;
                if (i == 0) {
                    writer.WriteLine("");
                }
            }
       }
    }
}
