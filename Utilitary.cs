using Microsoft.Extensions.Configuration;

public static class Utilitary
{
    public static void multiplyInplace(double[,] a, double[,] b)
    {
        if (a.Length != b.Length)
        {
            Console.WriteLine("multiplyInplace : matrices lenght mismatched !");
            throw new IndexOutOfRangeException();
        }
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                a[i, j] = a[i, j] * b[i, j];
            }
        }
    }

    // TODO rotate matrices
    // public static void rotate(double[,] a) {
    //     if (a.Length != b.Length) {
    //         Console.WriteLine("rotate : matrices lenght mismatched !");
    //         throw new IndexOutOfRangeException();
    //     }
    //     for (int i = 0; i < a.GetLength(0); i++) {
    //         for (int j = 0; j < a.GetLength(1); j++) {
    //             a[i,j] = a[i,j] * b[i,j];
    //         }
    //     }
    // }

    public static List<int[,]> readBlocks(string path, bool absolutePath = true)
    {
        var res = new List<int[,]>();
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        // https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.WriteLine("Reading blocks from " + workingDirectory);
        Console.WriteLine("Reading blocks from " + projectDirectory);
        // Console.WriteLine("Reading blocks from " + path);
        try
        {
            // using (StreamReader file = new StreamReader(projectDirectory+"/" + path))
            using (StreamReader file = new StreamReader(path))
            {

                string ln;
                int x, y;
                int nbBlocks = int.Parse(file.ReadLine());
                for (int i = 0; i < nbBlocks; i++)
                {
                    // skip the newline added for readability
                    _ = file.ReadLine();
                    ln = file.ReadLine();
                    if (ln == null)
                    {
                        throw new IOException();
                    }
                    string[] dims = ln.Split(" ");
                    y = int.Parse(dims[0]);
                    x = int.Parse(dims[1]);

                    int[,] board = new int[y, x];

                    for (int j = 0; j < y; j++)
                    {
                        ln = file.ReadLine();
                        if (ln == null)
                        {
                            throw new IOException();
                        }
                        string[] line = ln.Split(" ");
                        for (int k = 0; k < x; k++)
                        {
                            int v = 0;
                            if (line[k] == "x")
                            {
                                v = 0;
                            }
                            else
                            {
                                v = int.Parse(line[k]);
                            }
                            board[j, k] = v;
                        }
                    }
                    res.Add(board);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("readBlocks exception thrown : ", e.ToString());
            throw;
        }
        Console.WriteLine("Read " + res.Count + " blocks !");
        return res;
    }



   public static AdditiveGenerationConfig loadConfig(){
        // Build a config object, using env vars and JSON providers.
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("generation-settings.json")
            .AddEnvironmentVariables()
            .Build();

        // Get values from the config given their key and their target type.
        AdditiveGenerationConfig settings = config.GetRequiredSection("AdditiveGeneration").Get<AdditiveGenerationConfig>();
        return settings;
   }
}
