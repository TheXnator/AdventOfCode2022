static void Run() {
    Console.WriteLine(String.Format("Day 1 part 1: {0}", GetMostCalories()));
    Console.WriteLine(String.Format("Day 1 part 2: {0}", GetMostCalories(true)));
}

static int GetMostCalories(bool top3=false)
{
    string filename = "day1inputs.txt";
    int curval = 0;
    List<int> allvals = new List<int>();

    string[] contents = File.ReadAllLines(filename);
    foreach (string line in contents)
    {
        try {
            int lineval = Convert.ToInt32(line);
            curval = curval + lineval;
        } catch (Exception e) {
            allvals.Add(curval);
            curval = 0;
        }
    }

    allvals = allvals.OrderByDescending(c => c).ToList();

    return top3 ? (allvals[0] + allvals[1] + allvals[2]) : allvals[0];
}

Run();