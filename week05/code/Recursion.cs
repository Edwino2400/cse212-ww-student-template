using System.Collections;

public static class Recursion
{
    /// Problem 1 Solution
    public static int SumSquaresRecursive(int n)
    {
        
         if (n <= 0)
            return 0;

    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    ///PROBLEM 2 SOLUTION
{
    List<string> results = new List<string>();
    GeneratePermutations(letters, size, "", new bool[letters.Length], results);
    return results;
}

private static void GeneratePermutations(
    char[] letters,
    int size,
    string current,
    bool[] used,
    List<string> results)
{
    // when we reach the desired size, store result
    if (current.Length == size)
    {
        results.Add(current);
        return;
    }

    // try adding each unused letter
    for (int i = 0; i < letters.Length; i++)
    {
        if (!used[i])
        {
            used[i] = true;
            GeneratePermutations(letters, size, current + letters[i], used, results);
            used[i] = false;
        }
    }
}

    

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
{
    // If memo dictionary is null, create it (recursion-compatible)
    if (remember == null)
        remember = new Dictionary<int, decimal>();

    // Base cases required by assignment
    if (s == 0)
        return 0;
    if (s == 1)
        return 1;
    if (s == 2)
        return 2;
    if (s == 3)
        return 4;

    // PROBLEM 3 SOLUTION
    if (remember.ContainsKey(s))
        return remember[s];

    //
    decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

    // the result
    remember[s] = ways;

    //recursive result
    return ways;
}


    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
   public static void WildcardBinary(string pattern, List<string> results)
{
    //Problem 4 solution
    int index = pattern.IndexOf('*');

    // Base case: no wildcards left
    if (index == -1)
    {
        results.Add(pattern);
        return;
    }

    // Replace * with 0
    string withZero = pattern[..index] + "0" + pattern[(index + 1)..];
    WildcardBinary(withZero, results);

    // Replace * with 1
    string withOne = pattern[..index] + "1" + pattern[(index + 1)..];
    WildcardBinary(withOne, results);
}

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
   public static void SolveMaze(List<string> results, Maze maze,
                             int x = 0, int y = 0,
                             List<ValueTuple<int, int>>? currPath = null)
{
    // Initialize currPath on first call
    if (currPath == null)
        currPath = new List<ValueTuple<int, int>>();

    //Solution for Problem 5

    // Add current position to path
    currPath.Add((x, y));

    // If we reached end, save path
    if (maze.IsEnd(x, y))
    {
        results.Add(currPath.AsString());
    }
    else
    {
        // Try all directions
        if (maze.IsValidMove(x + 1, y, currPath))
            SolveMaze(results, maze, x + 1, y, currPath);

        if (maze.IsValidMove(x - 1, y, currPath))
            SolveMaze(results, maze, x - 1, y, currPath);

        if (maze.IsValidMove(x, y + 1, currPath))
            SolveMaze(results, maze, x, y + 1, currPath);

        if (maze.IsValidMove(x, y - 1, currPath))
            SolveMaze(results, maze, x, y - 1, currPath);
    }

    // tracking back
    currPath.RemoveAt(currPath.Count - 1);
}
}