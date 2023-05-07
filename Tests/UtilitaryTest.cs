namespace Tests;

public class UtilitaryTest
{
    [Fact]
    public void shouldReadBlocksCorrectly()
    {
        var res = Utilitary.readBlocks("./resources/test_blocks");
        Assert.Equal(res.Count, 2);
        var b1 = new int[4,5];
        b1[0,1] = 1;
        b1[0,2] = 1;
        b1[0,3] = 1;
        b1[1,1] = 1;
        b1[1,2] = 1;
        b1[1,3] = 1;
        b1[2,1] = 1;
        b1[2,2] = 1;
        b1[2,3] = 1;
        b1[3,0] = -1;
        b1[3,4] = -1;
        Assert.Equal(res[0].GetLength(0), 4);
        Assert.Equal(res[0].GetLength(1), 5);
        Assert.Equal(res[0], b1);
    }
}
