using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

public static class Randomizer
{
    static Random r;

    static Randomizer()
    {
        r = new Random();
    }
    static public int  GetNext(int from, int to)
    {
        //Thread.Sleep(1);
        return r.Next(from, to);
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

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
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

    public int GetWeight()
    {
        return weight;
    }

    public int GetVertice1Index()
    {
        return vertice1Index;
    }

    public int GetVertice2Index()
    {
        return vertice2Index;
    }
}

public class WUGraphPath
{
    int[] pathIndexes;
    int length;

    public int GetLength()
    {
        return length;
    }

    public int AtIndex(int n)
    {
        return pathIndexes[n];
    }

    public WUGraphPath(int pathLength)
    {
        length = pathLength;
        pathIndexes = new int[length];
    }

    ~WUGraphPath()
    {
        Array.Clear(pathIndexes, 0, length);
    }

    public void CopyPath(WUGraphPath path)
    {
        for(int i = 0; i < length; i++)
        {
            pathIndexes[i] = path.AtIndex(i);
        }
    }

    public void GenerateRandomPath()
    {
        List<int> list = new List<int>();

        for (int i = 0; i < length; i++)
        {
            list.Add(i);
        }

        for (int i = 0; i < length; i++)
        {
            int d = Randomizer.GetNext(0, list.Count);
            pathIndexes[i] = list.ElementAt(d);
            list.RemoveAt(d);
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

    public int[] GetPath()
    {
        return pathIndexes;
    }
}



public class WUGraph
{
    List<WUGraphVertice> vertices;
    List<WUGraphEdge> edges;

    class MCESequence
    {
        public WUGraphPath path;
        public int pathWeight;
    }

    int MCESequencRepetitions;
    int MCEStartingPoint;

    MCESequence[] sequence;

    public WUGraph()
    {
        vertices = new List<WUGraphVertice>();
        edges = new List<WUGraphEdge>();
    }

    public WUGraphEdge FindEdge(int edgeIndex1, int edgeIndex2)
    {
        for (int i = 0; i < edges.Count; i++)
        {
            if (edges.ElementAt(i).GetVertice1Index() == edgeIndex1 && edges.ElementAt(i).GetVertice2Index() == edgeIndex2)
            {
                return edges.ElementAt(i);
            }
        }

        return null;
    }
    public void GenerateRandom(int size)
    {
        vertices.Clear();
        edges.Clear();

        for (int i = 0; i < size; i++)
        {
            vertices.Add(new WUGraphVertice(Randomizer.GetNext(0, 1200), Randomizer.GetNext(0, 500), i.ToString()));
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                int xI = vertices.ElementAt(i).GetX();
                int xJ = vertices.ElementAt(j).GetX();
                int yI = vertices.ElementAt(i).GetY();
                int yJ = vertices.ElementAt(j).GetY();

                edges.Add(new WUGraphEdge(i, j, (int)Math.Round(Math.Sqrt((xI - xJ) * (xI - xJ) + (yI - yJ) * (yI - yJ)))));
            }
        }
    }

    public void Draw(Graphics canvas)
    {

        canvas.Clear(SystemColors.Control);

        int x1 = 0;
        int x2 = 0;
        int y1 = 0;
        int y2 = 0;

        for (int i = 0; i < edges.Count; i++)
        {
            x1 = vertices.ElementAt(edges.ElementAt(i).GetVertice1Index()).GetX();
            y1 = vertices.ElementAt(edges.ElementAt(i).GetVertice1Index()).GetY();
            x2 = vertices.ElementAt(edges.ElementAt(i).GetVertice2Index()).GetX();
            y2 = vertices.ElementAt(edges.ElementAt(i).GetVertice2Index()).GetY();

            canvas.DrawLine(Pens.Black, new Point(x1, y1), new Point(x2, y2));
        }




        for (int i = 0; i < vertices.Count; i++)
        {
            int x = vertices.ElementAt(i).GetX();
            int y = vertices.ElementAt(i).GetY();

            canvas.FillEllipse(Brushes.Red, x - 5, y - 5, 10, 10);
        }
    }

    public void Draw(Bitmap bitmapCanvas, PictureBox output)
    {
        Graphics canvas = Graphics.FromImage(bitmapCanvas);
        Draw(canvas);
        output.Image = bitmapCanvas;
    }

    /*private void _drawArrowhead(int x0, int y0, int x, int y, Graphics canvas)
    {
        double angle = 0.25;
        int length = 15;
        double lineAngle = Math.Atan2(y - y0, x - x0);
        double precision = 0.02;

        double k1 = Math.Tan(Math.Atan2(y - y0, x - x0) + angle);
        double k2 = Math.Tan(Math.Atan2(y - y0, x - x0) - angle);

        int xA11 = (int)(x - length / (Math.Sqrt(1 + k1 * k1)));
        int xA12 = (int)(x + length / (Math.Sqrt(1 + k1 * k1)));
        int xA21 = (int)(x - length / (Math.Sqrt(1 + k2 * k2)));
        int xA22 = (int)(x + length / (Math.Sqrt(1 + k2 * k2)));

        int yA11 = (int)(y + k1 * (xA11 - x));
        int yA12 = (int)(y + k1 * (xA12 - x));
        int yA21 = (int)(y + k2 * (xA21 - x));
        int yA22 = (int)(y + k2 * (xA22 - x));

        double d11 = ((y - y0) * xA11 + (x - x0) * yA11 + (x0 * y - x * y0)) / (Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0)));
        double d12 = ((y - y0) * xA12 + (x - x0) * yA12 + (x0 * y - x * y0)) / (Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0)));
        double d21 = ((y - y0) * xA21 + (x - x0) * yA21 + (x0 * y - x * y0)) / (Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0)));
        double d22 = ((y - y0) * xA22 + (x - x0) * yA22 + (x0 * y - x * y0)) / (Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0)));

        double k11 = Math.Atan2(yA11 - y, xA11 - x);
        double k12 = Math.Atan2(yA12 - y, xA12 - x);
        double k21 = Math.Atan2(yA21 - y, xA21 - x);
        double k22 = Math.Atan2(yA22 - y, xA22 - x);

        canvas.DrawLine(Pens.Blue, x, y, xA11, yA11);
        canvas.DrawLine(Pens.Blue, x, y, xA12, yA12);
        canvas.DrawLine(Pens.Blue, x, y, xA21, yA21);
        canvas.DrawLine(Pens.Blue, x, y, xA22, yA22);
    }*/

    public int DrawPath(WUGraphPath path, Graphics canvas)
    {
        
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;
        int pathWeight = 0;
        int i = 0;

        int penWidth = 2;
        double arrowCapWidth = 4.5;
        AdjustableArrowCap cap = new AdjustableArrowCap((float)arrowCapWidth, (float)arrowCapWidth);
        Pen pen = new Pen(Color.Red, penWidth);
        pen.CustomEndCap = cap;

        canvas.Clear(SystemColors.Control);

        int x = vertices.ElementAt(path.GetPath()[0]).GetX();
        int y = vertices.ElementAt(path.GetPath()[0]).GetY();
        canvas.FillEllipse(Brushes.Blue, x - 5, y - 5, 10, 10);

        for (i = 0; i < path.GetLength() - 1; i++)
        {
            

            x1 = vertices.ElementAt(path.GetPath()[i]).GetX();
            y1 = vertices.ElementAt(path.GetPath()[i]).GetY();
            x2 = vertices.ElementAt(path.GetPath()[i+1]).GetX();
            y2 = vertices.ElementAt(path.GetPath()[i+1]).GetY();

            canvas.FillEllipse(Brushes.Black, x2 - 5, y2 - 5, 10, 10);



            canvas.DrawLine(pen, x1, y1, x2, y2);
            pathWeight += FindEdge(path.GetPath()[i], path.GetPath()[i +1]).GetWeight();

        }

       

        canvas.DrawLine(pen, x2, y2, x, y);
        pathWeight += FindEdge(path.GetPath()[i], path.GetPath()[0]).GetWeight();

        return pathWeight;
    }

    public int DrawPath(WUGraphPath path, Bitmap bitmapCanvas, PictureBox output)
    {
        Graphics canvas = Graphics.FromImage(bitmapCanvas);
        int pathWeight = DrawPath(path, canvas);
        output.Image = bitmapCanvas;
        return pathWeight;
    }

    public int PathWeight(WUGraphPath path)
    {
        int pathWeight = 0;
        int i;

        for (i = 0; i < path.GetLength() - 1; i++)
        {
            pathWeight += FindEdge(path.GetPath()[i], path.GetPath()[i + 1]).GetWeight();
        }

        pathWeight += FindEdge(path.GetPath()[i], path.GetPath()[0]).GetWeight();

        return pathWeight;
    }

    private void MCESingle(object n)
    {
        WUGraphPath minPath = new WUGraphPath(vertices.Count);
        minPath.GenerateRandomPathFrom(MCEStartingPoint);
        int minPathWeight = PathWeight(minPath);
        sequence[(int)n].path.CopyPath(minPath);
        sequence[(int)n].pathWeight = minPathWeight;

        for (int i = 1; i < MCESequencRepetitions; i++)
        {
            WUGraphPath currentPath = new WUGraphPath(vertices.Count);
            currentPath.GenerateRandomPathFrom(MCEStartingPoint);
            int currentPathWeight = PathWeight(currentPath);

            if (minPathWeight > currentPathWeight)
            { 
                sequence[(int)n].path.CopyPath(currentPath);
                sequence[(int)n].pathWeight = currentPathWeight;
                minPathWeight = currentPathWeight;
            }
        }

        //Thread.Sleep(0);
    }
    
    public WUGraphPath MCE(int threadsNumber, int repitations, int from)
    {
        if (sequence != null)
        {
            Array.Clear(sequence, 0, sequence.Length);
        }
        sequence = new MCESequence[threadsNumber];
        for (int i = 0; i < threadsNumber; i++)
        {
            sequence[i] = new MCESequence();
            sequence[i].path = new WUGraphPath(vertices.Count);
        }
        Thread[] threads = new Thread[threadsNumber]; 
        MCESequencRepetitions = repitations;
        MCEStartingPoint = from;

        for (int i = 0; i < threadsNumber; i++)
        {
            threads[i] = new Thread(new ParameterizedThreadStart(MCESingle));
            threads[i].Start(i);
        }

        for (int i = 0; i < threadsNumber; i++)
        {
            threads[i].Join();
        }
        Array.Clear(threads, 0, threadsNumber);

        int minWeight = sequence[0].pathWeight;
        int minPathIndex = 0;
        for(int i = 1; i < threadsNumber; i++)
        {
            if(sequence[i].pathWeight < minWeight)
            {
                minWeight = sequence[i].pathWeight;
                minPathIndex = i;
            }
        }

        WUGraphPath result = new WUGraphPath(vertices.Count);
        result.CopyPath(sequence[minPathIndex].path);
        return result;
    }
}