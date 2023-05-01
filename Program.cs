var a = new ProceduralGeneration(30);
double[,] c = new double[2,2];
double[,] d = new double[2,2];
d[1,1] = 10;
Utilitary.multiplyInplace(d, c);
a.run();
a.writeToFile();
Console.WriteLine("Done !");
