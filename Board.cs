public class Board {
    int[,] board;
    int height;
    int width;

    public Board(int height, int width) {
        this.height = height;
        this.width = width;
        this.board = new int[height, width];
    }

    // add the block to the board if possible
    public bool addBlock(int[,] block, int[] pos) {
        if (!checkBlock(block, pos)) {
            return false;
        }

        var block_height = block.GetLength(0);
        var block_width = block.GetLength(1);
        var y = pos[0];
        var x = pos[1];
        for (int i = 0; i < block_height; i++) {
            for (int j = 0; j < block_width; j++) {
                set(y+i,x+j, block[i,j]);
            }
        }
        return true;
    }

    public int get(int y, int x) {
        return this.board[y,x];
    }

    public bool set(int y, int x, int value) {
        this.board[y,x] = value;
        return true;
    }

    // check if the block fits in the board
    public bool checkBlock(int[,] block, int[] pos) {
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
        for (int i = 0; i < block_height; i++) {
            for (int j = 0; j < block_width; j++) {
                if ((block[i,j] != 0) && (get(y+i, x+j) != 0)) {
                    return false;
                }
            }
        }

        return true;
    }
}
