using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
class Point
{
    public uint DataIndex
    {
        get; set;
    }
    public double X
    {
        get; set;
    }
    public double Y
    {
        get; set;
    }
    public double Z
    {
        get; set;
    }
    public Point(uint dataIndex, double x, double y, double z)
    {
        DataIndex = dataIndex;
        X = x;
        Y = y;
        Z = z;
    }
}
class Operations
{
    public static List<Point> ReadData(uint fileNumber)
    {
        string path = fileNumber.ToString() + ".csv";
        List<Point> allPoints = new List<Point>();
        StreamReader reader = new StreamReader(path);
        uint i = 0;
        const double meterToFeetRatio = 3.2808399;
        while (!reader.EndOfStream)
        {
            var coordinates = reader.ReadLine().Split(",");
            Point currentPoint = new Point(i, Convert.ToDouble(coordinates[0]) * meterToFeetRatio, Convert.ToDouble(coordinates[1]) * meterToFeetRatio, Convert.ToDouble(coordinates[2]) * meterToFeetRatio);
            allPoints.Add(currentPoint);
            i += 1;
        }
        reader.Close();
        return allPoints;
    }
    public static string[][] ComputeGraph(List<Point> allPoints, string component, double zoom)
    {
        int[] axisX = new int[allPoints.Count];
        int[] axisY = new int[allPoints.Count];
        switch (component)
        {
            case "Front":
                {
                    for (int i = 0; i < allPoints.Count; i += 1)
                    {
                        axisX[i] = Convert.ToInt16(allPoints[i].X * zoom);
                        axisY[i] = Convert.ToInt16(allPoints[i].Z * zoom);
                    }
                    break;
                }
            case "Left":
                {
                    for (int i = 0; i < allPoints.Count; i += 1)
                    {
                        axisX[i] = Convert.ToInt16(allPoints[i].Y * zoom);
                        axisY[i] = Convert.ToInt16(allPoints[i].Z * zoom);
                    }
                    break;
                }
            case "Top":
                {
                    for (int i = 0; i < allPoints.Count; i += 1)
                    {
                        axisX[i] = Convert.ToInt16(allPoints[i].X * zoom);
                        axisY[i] = Convert.ToInt16(allPoints[i].Y * zoom);
                    }
                    break;
                }
        }
        for (int i = 0; i < allPoints.Count; i += 1)
        {
            axisX[i] = axisX[i] - axisX.Min();
            axisY[i] = axisY[i] - axisY.Min();
        }
        string[][] graph = new string[axisY.Max() + 2][];
        for (int i = 0; i < graph.Length; i += 1)
        {
            graph[i] = new string[axisX.Max() + 1];
            for (int j = 0; j < axisX.Max() + 1; j += 1)
            {
                graph[i][j] = " ";
            }
        }
        //draw point position
        for (int i = 0; i < allPoints.Count; i += 1)
        {
            if (graph[axisY[i]][axisX[i]].Equals(" "))
            {
                graph[axisY[i]][axisX[i]] = "+";
                graph[axisY[i] + 1][axisX[i]] = $"({allPoints[i].X.ToString("0.0")},{allPoints[i].Y.ToString("0.0")},{allPoints[i].Z.ToString("0.0")})";
            }
            else
            {
                graph[axisY[i] + 1][axisX[i]] += $"({allPoints[i].X.ToString("0.0")},{allPoints[i].Y.ToString("0.0")},{allPoints[i].Z.ToString("0.0")})";
            }
        }
        graph[axisY[0]][axisX[0]] = "=";
        graph[axisY[allPoints.Count - 1]][axisX[allPoints.Count - 1]] = "#";
        //draw line between conjunctive points
        for (int i = 0; i < allPoints.Count - 1; i += 1)
        {
            if (axisX[i] == axisX[i + 1])
            {
                if (axisY[i] != axisY[i + 1])
                {
                    for (int j = axisY[i] + 1; j < axisY[i + 1]; j += 1)
                    {
                        graph[j][axisX[i]] = "|";
                    }
                }
            }
            else if (axisX[i] < axisX[i + 1])
            {
                if (axisY[i] == axisY[i + 1])
                {
                    for (int j = axisX[i + 1] - 1; j > axisX[i]; j -= 1)
                    {
                        graph[axisY[i]][j] = "-";
                    }
                }
                else if (axisY[i] < axisY[i + 1])
                {
                    for (int j = axisY[i] + 1; j < axisY[i + 1]; j += 1)
                    {
                        graph[j][(int)axisX[i] + 1 + (j - axisY[i] - 1) * (axisX[i + 1] - axisX[i]) / (axisY[i + 1] - axisY[i])] = "\\";
                    }
                }
                else
                {
                    for (int j = axisY[i + 1] + 1; j < axisY[i]; j += 1)
                    {
                        graph[j][(int)axisX[i + 1] - 1 - (j - axisY[i + 1] - 1) * (axisX[i + 1] - axisX[i]) / (axisY[i] - axisY[i + 1])] = "/";
                    }
                }
            }
            else
            {
                if (axisY[i] == axisY[i + 1])
                {
                    for (int j = axisX[i + 1]; j > axisX[i]; j -= 1)
                    {
                        graph[axisY[i]][j] = "-";
                    }
                }
                else if (axisY[i] < axisY[i + 1])
                {
                    for (int j = axisY[i] + 1; j < axisY[i + 1]; j += 1)
                    {
                        graph[j][(int)axisX[i] - 1 + (j - axisY[i] - 1) * (axisX[i + 1] - axisX[i]) / (axisY[i + 1] - axisY[i])] = "/";
                    }
                }
                else
                {
                    for (int j = axisY[i + 1] + 1; j < axisY[i]; j += 1)
                    {
                        graph[j][(int)axisX[i + 1] + 1 - (j - axisY[i + 1] - 1) * (axisX[i + 1] - axisX[i]) / (axisY[i] - axisY[i + 1])] = "\\";
                    }
                }
            }
        }

        return graph;
    }
    public static void PrintGraph(uint fileNumber, string component, string[][] graph)
    {
        string path = fileNumber.ToString() + component + "view.txt";
        StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
        for (int i = 0; i < graph.Length; i += 1)
        {
            for (int j = 0; j < graph[i].Length; j += 1)
            {
                writer.Write(graph[i][j]);
                if (graph[i][j].Equals(" ") | graph[i][j].Equals("/") | graph[i][j].Equals("\\") | graph[i][j].Equals("-") | graph[i][j].Equals("+"))
                {
                    continue;
                }
                else
                {
                    j += graph[i][j].Length - 1;
                }
            }
            writer.WriteLine();
        }
        writer.Flush();
        writer.Close();
    }
}
class Program
{
    static void Main()
    {
        double zoom = 0.5;
        uint fileNumber = 1;
        for (fileNumber = 1; fileNumber <= 5; fileNumber += 1)
        {
            List<Point> allPoints = Operations.ReadData(fileNumber);
            string[] components = { "Front", "Left", "Top" };
            foreach (string component in components)
            {
                Operations.PrintGraph(fileNumber, component, Operations.ComputeGraph(allPoints, component, zoom));
            }
        }
    }
}