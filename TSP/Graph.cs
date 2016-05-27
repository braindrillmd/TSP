using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

enum CurrentDonor { FIRST, SECOND };

public class Chromosome : WUGraphPath
{
    //int pathWeight;

    public Chromosome(int length) : base(length){ }

    

    public Chromosome Crossingover(Chromosome that)
    {
        Chromosome chromosome = new Chromosome(length);
        for (int i = 0; i < length; i++)
        {
            chromosome.pathIndexes[i] = -1;
        }

        for (int i = 0; i < length; i++)
        {
            WUGraphPath donor1 = new WUGraphPath(length);
            WUGraphPath donor2 = new WUGraphPath(length);

            if (i % 2 == 0)
            {

                donor1 = this;
                donor2 = that;
            }
            else
            {
                donor2 = this;
                donor1 = that;
            }

            if (!_IsInPath(chromosome, donor1.pathIndexes[i]) && donor1.pathIndexes[i] != 0)
            {
                chromosome.pathIndexes[i] = donor1.pathIndexes[i];
            }
            else
            {
                if(!_IsInPath(chromosome, donor2.pathIndexes[i]) && donor2.pathIndexes[i] != 0)
                {
                    chromosome.pathIndexes[i] = donor2.pathIndexes[i] ;
                }
                else
                {
                    for(int j = 0; j < length; j++)
                    {
                        if (!_IsInPath(chromosome, j) && j != i)
                        {
                            chromosome.pathIndexes[i] = j;
                        }
                    }
                }
            }
        }
        for (int j = 0; j < length; j++)
        {
            if (pathIndexes[j] == -1)
            {
                pathIndexes[j] = 0;
            }
        }

        return chromosome;
    }

    private int _GetNextVerticeIndex(int vertice, WUGraphPath path)
    {
        for(int i = 0; i < length; i++)
        {
            if(path.AtIndex(i) == vertice && i < length - 1)
            {
                return i+1;
            }
        }

        return path.AtIndex(0);
    }

    private bool _IsInPath(WUGraphPath path, int what)
    {
        for(int i = 0; i < length; i++)
        {
            if (path.AtIndex(i) == what)
            {
                return true;
            }
        }

        return false;
    }

    public Chromosome Mutate()
    {
        Chromosome chromosome = new Chromosome(length);
        chromosome.CopyPath(this);

        if (length < 5)
        {
            return this;
        }
        else
        {
            ThreadSafeRandom r = new ThreadSafeRandom();

            int mutatingGeneIndex = r.Next(0, length - 2) + 1;

            int insertionIndex = r.Next(0, length - 2) + 1;
            while (insertionIndex <= mutatingGeneIndex + 1 && insertionIndex >= mutatingGeneIndex - 1)
            {
                insertionIndex = r.Next(0, length - 2) + 1;
            }

            int geneBeforeMutatedIndex = 0;
            for(int i = 0; i < length; i++)
            {
                if(chromosome.pathIndexes[i] == mutatingGeneIndex)
                {
                    geneBeforeMutatedIndex = i;
                }
            }

            chromosome.pathIndexes[geneBeforeMutatedIndex] = chromosome.pathIndexes[mutatingGeneIndex];

            chromosome.pathIndexes[mutatingGeneIndex] =  chromosome.pathIndexes[insertionIndex];
            chromosome.pathIndexes[insertionIndex] = mutatingGeneIndex;
        }

        return chromosome;
    }
}//class Chromosome

class Comparer : IComparer<Individual>
{
    public int Compare(Individual x, Individual y)
    {
        return x.GetWeight() - y.GetWeight();
    }
}

public class EdgeComparer : IComparer<WUGraphEdge>
{
    public int Compare(WUGraphEdge x, WUGraphEdge y)
    {
        return x.GetWeight() - y.GetWeight();
    }
}

class Generation
{
    private int capacity;
    private int size;
    private Individual[] generation;
    private WUGraph graph;
    private ThreadSafeRandom random;

    private double crossingOverProbablity;
    private double mutationProbability; 

    public Generation(int capacity, WUGraph graph)
    {
        this.capacity = capacity;
        size = 0;
        generation = new Individual[capacity];
        this.graph = graph;
        random = new ThreadSafeRandom();

        crossingOverProbablity = 0.8;
        mutationProbability = 0.1;
    }

    public Chromosome GetBest()
    {
        return generation[0].GetChromosome();
    }
    
    public void Initialize()
    {
        for(int  i = 0; i < capacity; i++)
        {
            generation[i] = new Individual(graph.GetVerticesNumber());
            generation[i].SetChromosomeRandom();
            generation[i].SetWeight(graph.PathWeight(generation[i].GetChromosome()));
            size++;

        }

        _SortGeneration();
    }

    private void _IndividualAdd(Chromosome chromosome)
    {
        if(size <= capacity)
        {
            size++;
            generation[size - 1] = new Individual(graph.GetVerticesNumber());
            generation[size - 1].SetChromosome(chromosome);
            generation[size - 1].SetWeight(graph.PathWeight(chromosome));
        }
    }

    private bool _IsRoom()
    {
        if(capacity - size > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void NextGeneration()
    {
        Generation newGeneration = new Generation(capacity, graph);

        int operation = random.Next(0, 100);
        for (int i = 0; i < capacity- capacity*0.15 - 1 && newGeneration._IsRoom(); )
        {

            operation = random.Next(0, 100);

            if(operation <= mutationProbability * 100)
            {
                newGeneration._IndividualAdd(this.generation[i].GetChromosome().Mutate());
                i++;
                continue;
            }
            operation = random.Next(0, 100);
            if (operation <= crossingOverProbablity * 100)
            {
                newGeneration._IndividualAdd(this.generation[i].GetChromosome().Crossingover(this.generation[i + 1].GetChromosome()));
                newGeneration._IndividualAdd(this.generation[i + 1].GetChromosome().Crossingover(this.generation[i].GetChromosome()));
                i += 2;
                continue;
            }
        }

        for (int i = 0; i < capacity && newGeneration._IsRoom(); i++)
        {
            newGeneration._IndividualAdd(this.generation[i].GetChromosome());
        }

        

        for(int i = 0; i < capacity; i++)
        {
            this.generation[i].GetChromosome().CopyPath(newGeneration.generation[i].GetChromosome());
            this.generation[i].SetWeight(newGeneration.generation[i].GetWeight());
        }

        newGeneration._SortGeneration();
    }

    public void PutToFile(string filePath)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true);

        

        for (int i = 0; i < capacity; i++)
        {
            string output = "";

            for (int j = 0; j < generation[j].GetChromosome().GetLength(); j++)
            {
                output += j.ToString() + "-" + generation[i].GetChromosome().pathIndexes[j] + " ";
            }
            file.WriteLine(output);
        }


        
        file.Close();
    }

    void _SortGeneration()
    {
        Comparer comparer = new Comparer();
        Array.Sort(generation, comparer);
    }

}//class Generation

class Individual
{
    private Chromosome chromosome;
    int weight;

    public Individual(int length)
    {
        chromosome = new Chromosome(length);
        weight = 0;
    }

    public Individual(Chromosome chromosome, int weight)
    {
        this.chromosome = chromosome;
        this.weight = weight;
    }

    public Chromosome GetChromosome()
    {
        return chromosome;
    }

    public int GetWeight()
    {
        return weight;
    }

    public void SetChromosome(Chromosome chromosome)
    {
        this.chromosome = chromosome;
    }

    public void SetChromosomeRandom()
    {
        chromosome.GenerateRandomPath();
    }

    public void SetWeight(int weight)
    {
        this.weight = weight;
    }
    
}//class Individual

public static class Randomizer
{
    static Random r;
    static int previous;

    static public void Initialize()
    {
        r = new Random();
        previous = 666;
    }

    static public int  GetNext(int from, int to)
    {

       
        int next = r.Next(from, to);

        if (next == previous && previous == 0)
        {
            r = new Random(Environment.TickCount/3);
            next = r.Next(from, to);
        }

        previous = next;
        return next;
    }
}

public class ThreadSafeRandom
{
    private static readonly Meisui.Random.MersenneTwister _global = new Meisui.Random.MersenneTwister();
    [ThreadStatic]
    private static Meisui.Random.MersenneTwister _local;

    public ThreadSafeRandom()
    {
        if (_local == null)
        {
            //int seed;
            lock (_global)
            {
                //seed = (int)_global.genrand_int32();
            }
            _local = new Meisui.Random.MersenneTwister();
        }
    }
    public int Next()
    {
        return Math.Abs((int)_local.genrand_Int32());
    }
    public int Next(int from, int to)
    {
        return  Math.Abs((int)_local.genrand_Int32()) % to;
    }
}

public class WUGraph
{
    string[] vertices;
    int[,] edges;
    Point[] coordinates;
    ThreadSafeRandom random;
    

    class ExperimentSequence
    {
        public WUGraphPath path;
        public int pathWeight;
    }

    long GASequenceRepetitions;
    long MCESequencRepetitions;

    int GACapacity;

    ExperimentSequence[] MCESequence;
    ExperimentSequence[] GASequence;

    public WUGraph(int verticesNumber)
    {
        vertices = new string[verticesNumber];
        edges = new int[verticesNumber, verticesNumber];
        coordinates = new Point[verticesNumber];
        random = new ThreadSafeRandom();
    }


    public void Draw(Graphics canvas)
    {

        canvas.Clear(SystemColors.Control);

        int x1 = 0;
        int x2 = 0;
        int y1 = 0;
        int y2 = 0;

        for (int i = 0; i < vertices.Count(); i++)
        {
            for (int j = 0; j < vertices.Count(); j++)
            {
                x1 = coordinates[i].X;
                y1 = coordinates[i].Y;
                x2 = coordinates[j].X;
                y2 = coordinates[j].Y;

                canvas.DrawLine(Pens.Black, new Point(x1, y1), new Point(x2, y2));
            }
        }

        for (int i = 0; i < vertices.Count(); i++)
        {
            int x = coordinates[i].X;
            int y = coordinates[i].Y;

            canvas.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);
        }
    }

    public void DrawOnMap(Graphics canvas, Bitmap map, PictureBox output)
    {
        int x1 = 0;
        int x2 = 0;
        int y1 = 0;
        int y2 = 0;

        canvas = Graphics.FromImage(map);

        for (int i = 0; i < vertices.Count(); i++)
        {
            for (int j = 0; j < vertices.Count(); j++)
            {
                x1 = coordinates[i].X;
                y1 = coordinates[i].Y;
                x2 = coordinates[j].X;
                y2 = coordinates[j].Y;

                canvas.DrawLine(Pens.Black, new Point(x1, y1), new Point(x2, y2));
            }
        }

        for (int i = 0; i < vertices.Count(); i++)
        {
            int x = coordinates[i].X;
            int y = coordinates[i].Y;

            canvas.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);
        }

        output.Image = map;
    }

    //Previous function wrap
    public void Draw(Bitmap bitmapCanvas, PictureBox output)
    {


        Graphics canvas = Graphics.FromImage(bitmapCanvas);
        Draw(canvas);
        output.Image = bitmapCanvas;
    }

    public int DrawPath(WUGraphPath path, Graphics canvas)
    {

        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        int i = 0;

        int penWidth = 2;
        double arrowCapWidth = 4.5;
        AdjustableArrowCap cap = new AdjustableArrowCap((float)arrowCapWidth, (float)arrowCapWidth);
        System.Drawing.Font font;
        font = new Font("Arial", 12);
        System.Drawing.SolidBrush brush = new SolidBrush(Color.Blue);
        Pen pen = new Pen(Color.Red, penWidth);
        pen.CustomEndCap = cap;

        canvas.Clear(SystemColors.Control);


        int x = coordinates[path.GetPath()[0]].X;
        int y = coordinates[path.GetPath()[0]].Y;
        canvas.FillEllipse(Brushes.Black, x - 5, y - 5, 10, 10);
        canvas.DrawString(path.AtIndex(0).ToString(), font, brush, x + 10, y - 10);

        for (i = 0; i < path.GetLength() - 1; i++)
        {


            x1 = coordinates[path.GetPath()[i]].X;
            y1 = coordinates[path.GetPath()[i]].Y;
            x2 = coordinates[path.GetPath()[i + 1]].X;
            y2 = coordinates[path.GetPath()[i + 1]].Y;

            canvas.FillEllipse(Brushes.Black, x2 - 5, y2 - 5, 10, 10);
            canvas.DrawString(path.AtIndex(i + 1).ToString(), font, brush, x2 + 10, y2 - 10);

            canvas.DrawLine(pen, x1, y1, x2, y2);

        }

        canvas.DrawLine(pen, x2, y2, x, y);


        return PathWeight(path);
    }

    //DrawPath Wrap
    public int DrawPath(WUGraphPath path, Bitmap bitmapCanvas, PictureBox output)
    {

        Graphics canvas = Graphics.FromImage(bitmapCanvas);
        int pathWeight = DrawPath(path, canvas);
        output.Image = bitmapCanvas;
        return pathWeight;
    }

    //TODO: use one instead of two
    public int DrawPathOnMap(WUGraphPath path, Graphics canvas, Bitmap map, PictureBox output)
    {
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        int i = 0;

        int penWidth = 2;
        double arrowCapWidth = 4.5;
        AdjustableArrowCap cap = new AdjustableArrowCap((float)arrowCapWidth, (float)arrowCapWidth);
        System.Drawing.Font font;
        font = new Font("Arial", 12);
        System.Drawing.SolidBrush brush = new SolidBrush(Color.Blue);
        Pen pen = new Pen(Color.Red, penWidth);
        pen.CustomEndCap = cap;

        canvas.Clear(SystemColors.Control);
        canvas = Graphics.FromImage(map);

        int x = coordinates[path.GetPath()[0]].X;
        int y = coordinates[path.GetPath()[0]].Y;
        canvas.FillEllipse(Brushes.Black, x - 5, y - 5, 10, 10);
        canvas.DrawString(path.AtIndex(0).ToString(), font, brush, x + 10, y - 10);

        for (i = 0; i < path.GetLength() - 1; i++)
        {
            x1 = coordinates[path.GetPath()[i]].X;
            y1 = coordinates[path.GetPath()[i]].Y;
            x2 = coordinates[path.GetPath()[i + 1]].X;
            y2 = coordinates[path.GetPath()[i + 1]].Y;

            canvas.FillEllipse(Brushes.Black, x2 - 5, y2 - 5, 10, 10);
            canvas.DrawString(path.AtIndex(i + 1).ToString(), font, brush, x2 + 10, y2 - 10);

            canvas.DrawLine(pen, x1, y1, x2, y2);
        }

        canvas.DrawLine(pen, x2, y2, x, y);

        output.Image = map;


        return PathWeight(path);
    }

    public void EdgeAdd(int vertice1Index, int vertice2Index, int weight)
    {
        edges[vertice1Index, vertice2Index] = weight;
    }
    public int IndexOfVertice(string name)
    {
        return Array.IndexOf(vertices, name);
    }
    public int EdgeWeight(int x, int y)
    {
        return edges[x, y];
    }

    public WUGraphPath GA(int threadsNum, int generationCap, long iterations)
    {
        GASequenceRepetitions = iterations;
        GACapacity = generationCap;
        GASequence = new ExperimentSequence[generationCap];
        for (int i = 0; i < threadsNum; i++)
        {
            GASequence[i] = new ExperimentSequence();
            GASequence[i].path = new WUGraphPath(vertices.Count());
        }

        Thread[] threads = new Thread[threadsNum];

        for (int i = 0; i < threadsNum; i++)
        {
            threads[i] = new Thread(new ParameterizedThreadStart(_GARoutine));
            threads[i].Start(i);
        }

        for (int i = 0; i < threadsNum; i++)
        {
            threads[i].Join();
        }

        int minWeight = GASequence[0].pathWeight;
        int minPathIndex = 0;
        for (int i = 1; i < threadsNum; i++)
        {
            if (GASequence[i].pathWeight < minWeight && GASequence[i].pathWeight >= 0)
            {
                minWeight = GASequence[i].pathWeight;
                minPathIndex = i;
            }
        }

        return GASequence[minPathIndex].path;
    }

    private void _GARoutine(object n)
    {
        Generation generation = new Generation(GACapacity, this);
        generation.Initialize();

        for (int i = 1; i < GASequenceRepetitions; i++)
        {
            generation.NextGeneration();
            //generation.PutToFile("ga_gen" + i.ToString() + "thread" + n.ToString() + ".log");
        }

        GASequence[(int)n].path.CopyPath(generation.GetBest());
        GASequence[(int)n].pathWeight = PathWeight(generation.GetBest());
    }

    public int GetVerticeIndex(string name)
    { 
        return Array.IndexOf(vertices, name);
    }

    public string GetVerticeName(int index)
    {
        return vertices[index];
    }

    public int GetVerticesNumber()
    {
        return vertices.Count();
    }

    public void GenerateEdges()
    {
        edges = new int[vertices.Count(), vertices.Count()];

        for (int i = 0; i < vertices.Count(); i++)
        {
            for (int j = 0; j < vertices.Count(); j++)
            {
                int xI = coordinates[i].X;
                int xJ = coordinates[j].X;
                int yI = coordinates[i].Y;
                int yJ = coordinates[j].Y;

                edges[i,j] = (int)Math.Round(Math.Sqrt((xI - xJ) * (xI - xJ) + (yI - yJ) * (yI - yJ)));
            }
        }
    }

    public void GenerateRandom(int size)
    {

        for (int i = 0; i < size; i++)
        {
            vertices[i] = i.ToString();
            coordinates[i].X = random.Next(0, 1000);
            coordinates[i].Y = random.Next(0, 500);
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                int xI = coordinates[i].X;
                int xJ = coordinates[j].X;
                int yI = coordinates[i].Y;
                int yJ = coordinates[j].Y;

                edges[i, j] = (int)Math.Round(Math.Sqrt((xI - xJ) * (xI - xJ) + (yI - yJ) * (yI - yJ)));
            }
        }
        
    }

    

    public WUGraphPath MCE(int threadsNumber, long repitations)
    {  
        MCESequence = new ExperimentSequence[threadsNumber];
        for (int i = 0; i < threadsNumber; i++)
        {
            MCESequence[i] = new ExperimentSequence();
            MCESequence[i].path = new WUGraphPath(vertices.Count());
        }
        Thread[] threads = new Thread[threadsNumber];
        MCESequencRepetitions = repitations;

        for (int i = 0; i < threadsNumber; i++)
        {
            threads[i] = new Thread(new ParameterizedThreadStart(MCESingle));
            threads[i].Start(i);
        }

        for (int i = 0; i < threadsNumber; i++)
        {
            threads[i].Join();
        }

        int minWeight = MCESequence[0].pathWeight;
        int minPathIndex = 0;
        for (int i = 0; i < threadsNumber; i++)
        {
            if (MCESequence[i].pathWeight < minWeight && MCESequence[i].pathWeight >= 0)
            {
                minWeight = MCESequence[i].pathWeight;
                minPathIndex = i;
            }
        }

        return MCESequence[minPathIndex].path;
        
    }

    private void MCESingle(object n) //MCE routine
    {
        WUGraphPath minPath = new WUGraphPath(vertices.Count());
        minPath.GenerateRandomPath();
        int minPathWeight = PathWeight(minPath);
        MCESequence[(int)n].path.CopyPath(minPath);
        //MCESequence[(int)n].pathWeight = minPathWeight;
        MCESequence[(int)n].path = minPath;
        MCESequence[(int)n].pathWeight = minPathWeight;

        for (int i = 0; i < MCESequencRepetitions; i++)
        {
            WUGraphPath currentPath = new WUGraphPath(vertices.Count());
            currentPath.GenerateRandomPath();
            //DEBUG
            //currentPath.PutToFile("mce_thread" + n.ToString()+ ".log");
            int currentPathWeight = PathWeight(currentPath);

            if (minPathWeight > currentPathWeight)
            {
                MCESequence[(int)n].path.CopyPath(currentPath);
                //MCESequence[(int)n].path = currentPath;
                MCESequence[(int)n].pathWeight = currentPathWeight;
                minPathWeight = currentPathWeight;
            }
        }
    }

    public int 
    PathWeight(WUGraphPath path)
    {
        int pathWeight = 0;
        int i;

        for (i = 0; i < path.GetLength(); i++)
        {
            pathWeight += edges[i, path.pathIndexes[i]];
        }

        //pathWeight += edges[path.GetPath()[i], path.GetPath()[0]];

        return pathWeight;
    }

    public void SafeToFile(string filePath)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);

        string buffer = "";

        file.WriteLine(vertices.Count());

        for(int i = 0; i < vertices.Count(); i++)
        {
            buffer = vertices[i] + " " + coordinates[i].X + " " + coordinates[i].Y + " ";
            file.WriteLine(buffer);
        }

        for(int i = 0; i < vertices.Count(); i++)
        {
            buffer = "";
            for (int j = 0; j < vertices.Count(); j++)
            {
                buffer += edges[i, j].ToString() + " ";
            }
            file.WriteLine(buffer);
        }

        file.Close();
    }

    public void Symmetry()
    {
        for(int i = 0; i < vertices.Count(); i++)
        {
            for (int j = 0; j < i; j++)
            {
                edges[i, j] = edges[j, i];
            }
        }
    }

    public void ReadFromFile(string filePath)
    {
        System.IO.StreamReader file = new System.IO.StreamReader(filePath);

        string buffer = "";
        string[] arrayBuffer;

        int verticesNumber = Convert.ToInt32(file.ReadLine());

        vertices = new string[verticesNumber];
        edges = new int[verticesNumber, verticesNumber];
        coordinates = new Point[verticesNumber];

        for(int i = 0; i < verticesNumber; i++)
        {
            buffer = file.ReadLine();
            arrayBuffer = buffer.Split(' ');

            vertices[i] = arrayBuffer[0];
            coordinates[i].X = Convert.ToInt32(arrayBuffer[1]);
            coordinates[i].Y = Convert.ToInt32(arrayBuffer[2]);
        }

        for (int i = 0; i < verticesNumber; i++)
        {
            buffer = file.ReadLine();
            arrayBuffer = buffer.Split(' ');

            for(int j = 0; j < verticesNumber; j++)
            {
                edges[i, j] = Convert.ToInt32(arrayBuffer[j]);
            }
        }
    }

    public void VerticeAdd(int x, int y, string name)
    {
        string[] newVerticesArray = new string[vertices.Count()+1];
        Point[] newCoordinatesArray = new Point[vertices.Count()+1];

        for (int i = 0; i < vertices.Count(); i++)
        {
            newVerticesArray[i] = vertices[i];
            newCoordinatesArray[i].X = coordinates[i].X;
            newCoordinatesArray[i].Y = coordinates[i].Y;
        }
        newVerticesArray[vertices.Count()] = name;
        newCoordinatesArray[vertices.Count()].X = x;
        newCoordinatesArray[vertices.Count()].Y = y;

        vertices = newVerticesArray;
        coordinates = newCoordinatesArray;
    }
}

public class WUGraphEdge
{
    int vertice1Index;
    int vertice2Index;
    int weight;

    public WUGraphEdge(int argVertice1Index, int argVertice2Index, int argWeight)
    {
        vertice1Index = argVertice1Index;
        vertice2Index = argVertice2Index;
        weight = argWeight;
    }

    public int GetVertice1Index()
    {
        return vertice1Index;
    }

    public int GetVertice2Index()
    {
        return vertice2Index;
    }

    public int GetWeight()
    {
        return weight;
    }

    public void SetWeight(int weight)
    {
        this.weight = weight;
    }

}

public class WUGraphPath
{
    public int[] pathIndexes;
    protected int length;
    ThreadSafeRandom random;

    public WUGraphPath(int pathLength)
    {
        length = pathLength;
        pathIndexes = new int[length];
        random = new ThreadSafeRandom();
    }

    ~WUGraphPath()
    {
        Array.Clear(pathIndexes, 0, length);
    }

    //TODO: try to get rid of this kinda strage function
    public int AtIndex(int n)
    {
        return pathIndexes[n];
    }

    public void CopyPath(WUGraphPath path)
    {
        for (int i = 0; i < length; i++)
        {
            pathIndexes[i] = path.AtIndex(i);
        }
    }

    public int GetLength()
    {
        return length;
    }

    //Name kinda lame
    public int[] GetPath()
    {
        return pathIndexes;
    }

    public void GenerateRandomPath()
    {
        List<int> list = new List<int>();

        //ThreadSafeRandom random = new ThreadSafeRandom();

        int currentVertice = 0;

        for (int j = 0; j < length; j++)
        {
            if (j != 0)
            {
                list.Add(j);
            }
            pathIndexes[j] = -1;
        }

        int i = 0;
        for(i = 0;  list.Count > 0; i++)
        {
            int d = random.Next(1, list.Count);////////////////////////////////////////
            if (random.Next() % 2 == 0 && currentVertice != list.ElementAt(d))
            {
                pathIndexes[currentVertice] = list.ElementAt(d);
                currentVertice = list.ElementAt(d);
                list.RemoveAt(d);
            }
        }
        for (int j = 0; j < length; j++)
        {
            if(pathIndexes[j] == -1)
            {
                pathIndexes[j] = 0;
            }
        }
    }

    public void GenerateRandomPathFrom(int from)
    {
        List<int> list = new List<int>();

        for (int i = 0; i < length; i++)
        {
            list.Add(i);
        }

        pathIndexes[0] = from;
        list.RemoveAt(from);

        for (int i = 1; i < length; i++)
        {
            int d = Randomizer.GetNext(0, list.Count);
            pathIndexes[i] = list.ElementAt(d);
            list.RemoveAt(d);
        }
    }
    
    public void PutToFile(string filePath)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true);

        string output = "{";

        for(int i = 0; i < length; i++)
        {
            output += "(" + i.ToString() + "," + pathIndexes[i] + ")";
            if(i != length - 1)
            {
                output += ", ";
            }
        }

        output += "}";

        file.WriteLine(output);
        file.Close();
    }  
}

public class WUGraphVertice
{
    int x;
    int y;
    string name;

    public WUGraphVertice(int argX, int argY, string argName)
    {
        x = argX;
        y = argY;
        name = argName;
    }

    //Some of these set-functions are useless
    public string GetName()
    {
        return name;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public void SetY(int y)
    {
        this.y = y;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
}




