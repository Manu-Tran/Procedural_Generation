namespace Tests;

public class BoardTest
{
    [Fact]
    public void shouldValidateCorrectBoard()
    {
        var b = new Board(5, 5);
        int[,] d = new int[2, 2];
        int[] pos = new int[2];
        pos[0] = 0;
        pos[1] = 2;
        d[1, 1] = 10;
        Assert.True(b.checkBlock(d, pos));
    }

    [Fact]
    public void shouldCheckForEmptiness()
    {
        var b = new Board(5, 5);
        int[,] d = new int[2, 2];
        int[] pos = new int[2];
        pos[0] = 0;
        pos[1] = 2;
        d[1, 1] = 10;
        b.set(1, 3, 1);
        Assert.False(b.checkBlock(d, pos));
    }

    [Fact]
    public void shouldCheckForDimension()
    {
        var b = new Board(5, 5);
        int[,] d = new int[2, 2];
        int[] pos = new int[2];
        pos[0] = 4;
        pos[1] = 4;
        Assert.False(b.checkBlock(d, pos));
    }
}
