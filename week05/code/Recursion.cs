using System;
using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    // #############
    // # Solution 1 #
    // #############
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    // #############
    // # Solution 2 #
    // #############
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            if (!word.Contains(c))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    // #############
    // # Solution 3 #
    // #############
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // #############
    // # Solution 4#
    // #############
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    // #############
    // # Solution 5#
    // #############
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Add current position
        currPath.Add((x, y));

        // Base case: reached end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Move right
            if (maze.IsValidMove(x + 1, y, currPath))
                SolveMaze(results, maze, x + 1, y, currPath);

            // Move left
            if (maze.IsValidMove(x - 1, y, currPath))
                SolveMaze(results, maze, x - 1, y, currPath);

            // Move down
            if (maze.IsValidMove(x, y + 1, currPath))
                SolveMaze(results, maze, x, y + 1, currPath);

            // Move up
            if (maze.IsValidMove(x, y - 1, currPath))
                SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
