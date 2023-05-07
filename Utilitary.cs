public static class Utilitary {
    public static void multiplyInplace(double[,] a, double[,] b) {
        if (a.Length != b.Length) {
            Console.WriteLine("multiplyInplace : matrices lenght mismatched !");
            throw new IndexOutOfRangeException();
        }
        for (int i = 0; i < a.GetLength(0); i++) {
            for (int j = 0; j < a.GetLength(1); j++) {
                a[i,j] = a[i,j] * b[i,j];
            }
        }
    }

    public static List<int[,]> readBlocks(string path) {
        var res = new List<int[,]>();
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        // https://stackoverflow.com/questions/816566/how-do-you-get-the-current-project-directory-from-c-sharp-code-when-creating-a-c
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.WriteLine("Reading blocks from " + projectDirectory);
        try {
            using (StreamReader file = new StreamReader(projectDirectory+"/" + path))
            {

                string ln;
                int x,y;
                int nbBlocks = int.Parse(file.ReadLine());
                for (int i = 0; i < nbBlocks; i++) {
                    // skip the newline added for readability
                    _ = file.ReadLine();
                    ln = file.ReadLine();
                    if (ln == null) {
                        throw new IOException();
                    }
                    string[] dims =  ln.Split(" ");
                    y = int.Parse(dims[0]);
                    x = int.Parse(dims[1]);

                    int[,] board = new int[y,x];

                    for (int j = 0; j < y; j++) {
                        ln = file.ReadLine();
                        if (ln == null) {
                            throw new IOException();
                        }
                        string[] line = ln.Split(" ");
                        for (int k = 0; k < x; k++)
                        {
                            int v = 0;
                            if (line[k] == "x") {
                                v = -1;
                            } else {
                                v = int.Parse(line[k]);
                            }
                            board[j,k] = v;
                        }
                    }
                    res.Add(board);
                }
            }
        }
        catch (Exception e){
            Console.WriteLine("readBlocks exception thrown : ", e.ToString());
            throw e;
        }
        return res;

    }
}
