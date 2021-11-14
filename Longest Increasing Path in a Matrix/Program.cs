using System;

namespace Longest_Increasing_Path_in_a_Matrix
{
  class Program
  {
    static void Main(string[] args)
    {
      var matrix = new int[][] { new int[] { 9, 9, 4 }, new int[] { 6, 6, 8 }, new int[] { 2, 1, 1 } };
      Program p = new Program();
      Console.WriteLine(p.LongestIncreasingPath(matrix));
    }
    readonly int[][] direction = new int[][] 
    { 
      new int[] { 1, 0 }, // down
      new int[] { -1, 0 }, // up
      new int[] { 0, 1 }, // right
      new int[] { 0, -1 } // left 
    };
    public int LongestIncreasingPath(int[][] matrix)
    {
      // base condition
      if (matrix == null || matrix.Length == 0) return 0;
      int maxPath = 0;
      int m = matrix.Length, n = matrix[0].Length;
      int[,] cache = new int[m, n];
      for(int i = 0; i < m; i++)
      {
        for(int j = 0; j < n; j++)
        {
          int result = DFS(matrix, i, j, m, n, cache);
          maxPath = Math.Max(maxPath, result);
        }
      }
      return maxPath;
    }

    private int DFS(int[][] matrix, int i, int j, int m, int n, int[,] cache)
    {
      if (cache[i,j] > 0) return cache[i,j];
      int max = 0;
      foreach (var dir in direction)
      {
        int newi = i + dir[0], newj = j + dir[1];
        // check the array boundary
        if ( newi >= 0 && newj >= 0 && newi < m && newj < n && matrix[newi][newj] > matrix[i][j])
        {
          int result = DFS(matrix, newi, newj, m, n, cache);
          max = Math.Max(max, result);
        }
      }
      cache[i, j] = max + 1;
      return max + 1;
    }
  }
}
