
DateTime start = DateTime.Now;
        Console.WriteLine(DateTime.Now);

        List<int> dataSetU = new List<int>();
        List<int> dataSetV = new List<int>();

        using (StreamReader reader = new StreamReader("test.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 1)
                {
                    string[] parts = line.Split();
                    int u = int.Parse(parts[0]);
                    int v = int.Parse(parts[1]);
                    dataSetU.Add(u);
                    dataSetV.Add(v);
                }
            }
        }

        Console.WriteLine("Open file time: " + (DateTime.Now - start).TotalSeconds + "s");
        Console.WriteLine(DateTime.Now);

        int maxNode = dataSetU.Concat(dataSetV).Max() + dataSetU.Count;

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        Console.SetError(new StreamWriter(Console.OpenStandardError()));

        int recursionLimit = maxNode * 100;
        SetRecursionLimit(recursionLimit);

        DFSLoop(dataSetU, dataSetV, maxNode);

        Console.WriteLine("DFS_Loop time: " + (DateTime.Now - start).TotalSeconds + "s");

        List<int> revU = dataSetV;
        List<int> revV = dataSetU;
        List<int> newU = new List<int>(new int[revU.Count]);
        List<int> newV = new List<int>(new int[revV.Count]);

        for (int i = 0; i < dataSetU.Count; i++)
        {
            int val = dataSetU[i];
            int index = revV.IndexOf(val);
            newV[index] = dataSetV[i];
        }

        for (int i = 0; i < dataSetV.Count; i++)
        {
            int val = dataSetV[i];
            int index = revU.IndexOf(val);
            newU[index] = dataSetU[i];
        }

        dataSetU = newU;
        dataSetV = newV;

        Console.WriteLine("Reverse data time: " + (DateTime.Now - start).TotalSeconds + "s");

        DFSLoop(dataSetU, dataSetV, maxNode);

        Console.WriteLine("DFS_Loop time: " + (DateTime.Now - start).TotalSeconds + "s");

        List<int> leader = new List<int>(new int[maxNode]);
        List<int> f = new List<int>(new int[maxNode]);

        for (int i = 0; i < maxNode; i++)
        {
            leader[i] = 0;
            f[i] = 0;
        }

        List<int> countList = new List<int>(new int[leader.Count]);
        List<int> indices = new List<int>(new int[leader.Count]);

        while (leader.Count > 0)
        {
            countList[0] = leader.Count(x => x == leader[0]);
            indices = leader.Select((x, i) => new { x, i }).Where(item => item.x == leader[0]).Select(item => item.i).ToList();
            for (int i = 0; i < indices.Count; i++)
            {
                leader.RemoveAt(indices[i] - i);
            }
        }

        Console.WriteLine("Calc time: " + (DateTime.Now - start).TotalSeconds + "s");

        var sortedCountList = countList.OrderByDescending(x => x).Take(5);
        Console.WriteLine(string.Join(" ", sortedCountList));
        Console.WriteLine(DateTime.Now);
    

    static void DFSLoop(List<int> dataSetU, List<int> dataSetV, int num)
    {
        DateTime start = DateTime.Now;
        int t = 0;
        int s = 0;
        bool[] visited = new bool[num];
        int[] leader = new int[num];
        int[] f = new int[num];

        for (int i = num; i > 0; i--)
        {
            if (!visited[i - 1])
            {
                s = i;
                DFS(i, ref t, s, visited, leader, f, dataSetU, dataSetV);
            }
        }

        Console.WriteLine("End with func DFS_Loop() time: " + (DateTime.Now - start).TotalSeconds + "s");
        Console.WriteLine("End with func DFS_Loop() whole time: " + (DateTime.Now - start).TotalSeconds + "s");
    }

    static void DFS(int node, ref int t, int s, bool[] visited, int[] leader, int[] f, List<int> dataSetU, List<int> dataSetV)
    {
        DateTime start = DateTime.Now;
        visited[node - 1] = true;
        leader[node - 1] = s;
        List<int> arc = dataSetV.Where((x, i) => dataSetU[i] == node).ToList();

        foreach (int i in arc)
        {
            if (!visited[i - 1])
            {
                DFS(i, ref t, s, visited, leader, f, dataSetU, dataSetV);
            }
        }

        t++;
        f[node - 1] = t;

        Console.WriteLine("End with func DFS time: " + (DateTime.Now - start).TotalSeconds + "s");
        Console.WriteLine("End with func DFS whole time: " + (DateTime.Now - start).TotalSeconds + "s");
    }

    static void SetRecursionLimit(int limit)
    {
        for (int i = 0; i < limit; i++)
        {
            try
            {
                SetRecursionLimit(i);
            }
            catch (Exception)
            {
                break;
            }
        }
    }

