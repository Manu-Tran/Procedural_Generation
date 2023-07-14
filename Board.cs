public class Board
{
    int[,] board;
    int[,] traps;
    int height;
    int width;
    private int eltCount;
    private int blockCount;

    public Board(int height, int width)
    {
        this.height = height;
        this.width = width;
        this.board = new int[height, width];
        this.traps = new int[height, width];
        this.eltCount = 0;
    }

    // add the block to the board if possible
    public bool addBlock(int[,] block, int[] pos)
    {
        if (!checkBlock(block, pos))
        {
            return false;
        }

        var block_height = block.GetLength(0);
        var block_width = block.GetLength(1);
        var y = pos[0];
        var x = pos[1];
        for (int i = 0; i < block_height; i++)
        {
            for (int j = 0; j < block_width; j++)
            {
                set(y + i, x + j, block[i, j]);
            }
        }
        this.blockCount += 1;
        return true;
    }

    public bool addBlock(int[,] block, int y, int x)
    {
        var pos = new int[2];
        pos[0] = y;
        pos[1] = x;
        return addBlock(block, pos);
    }

    public int get(int y, int x)
    {
        return this.board[y, x];
    }

    public int getTrap(int y, int x)
    {
        return this.traps[y, x];
    }

    public bool set(int y, int x, int value)
    {

        var tile = this.board[y,x];
        if (tile == Tile.Empty.toInt() && value != Tile.Empty.toInt()) {
           this.eltCount += 1;
        }

        if (tile != Tile.Empty.toInt() && value == Tile.Empty.toInt()) {
           this.eltCount -= 1;
        }

        if (tile.isTrap()) {
            this.traps[y, x] = value;
        } else {
            this.board[y, x] = value;
        }
        return true;
    }

    // check if the block fits in the board
    public bool checkBlock(int[,] block, int[] pos)
    {
        var block_height = block.GetLength(0);
        var block_width = block.GetLength(1);
        var y = pos[0];
        var x = pos[1];

        // invalidate if the block does not fit
        if (((block_height + y) >= this.height)
            || ((block_width + x) >= this.width))
        {
            return false;
        }

        // Check that every spot is free
        // TODO add specific conditions
        for (int i = 0; i < block_height; i++)
        {
            for (int j = 0; j < block_width; j++)
            {
                if ((block[i, j] != 0) && (get(y + i, x + j) != 0) && (traps[i, j] != 0))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void writeToFile(string path)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    writer.Write(board[i, j]);
                }
                writer.WriteLine("");
            }
        }
    }

    public int getEltCount() {
       return eltCount;
    }
}
