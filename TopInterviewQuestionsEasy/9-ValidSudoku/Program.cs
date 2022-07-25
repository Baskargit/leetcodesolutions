using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        var board = new char[][] 
        {
            new char[] {'.','.','.','.','5','.','.','1','.'},
            new char[] {'.','4','.','3','.','.','.','.','.'},
            new char[] {'.','.','.','.','.','3','.','.','1'},
            new char[] {'8','.','.','.','.','.','.','2','.'},
            new char[] {'.','.','2','.','7','.','.','.','.'},
            new char[] {'.','1','5','.','.','.','.','.','.'},
            new char[] {'.','.','.','.','.','2','.','.','.'},
            new char[] {'.','2','.','9','.','.','.','.','.'},
            new char[] {'.','.','4','.','.','.','.','.','.'}
        };
        Console.WriteLine(IsValidSudoku(board));

        board = new char[][]
        {
            new char[]{'5','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
        };
        Console.WriteLine(IsValidSudoku(board));
    }

    public static bool IsValidSudoku(char[][] board)
    {
        // Row(9) + Column(9) + SubBoxes(9) in dictionary
        var dic = new Dictionary<string,List<char>>();
        
        // O(n*n)
        for (int i = 0; i < 9; i++)
        {
            string rowKey = $"Row_{i}";
            dic.Add(rowKey, new List<char>());

            string subBoxPrefix = $"SubBox_{i/3}";

            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.')
                {
                    // Add row data
                    if (dic[rowKey].Contains(board[i][j]))
                    {
                        return false;
                    }

                    dic[rowKey].Add(board[i][j]);

                    // Add Column data
                    string colKey = $"Col_{j}";
                    if (dic.ContainsKey(colKey))
                    {
                        if (dic[colKey].Contains(board[i][j]))
                        {
                            return false;
                        }

                        dic[colKey].Add(board[i][j]);
                    }
                    else
                    {
                        dic[colKey] = new List<char> { board[i][j] };
                    }
                    
                    // Add SubBoxData
                    string subBoxKey = $"{subBoxPrefix}_{j/3}";
                    if (dic.ContainsKey(subBoxKey))
                    {
                        if (dic[subBoxKey].Contains(board[i][j]))
                        {
                            return false;
                        }

                        dic[subBoxKey].Add(board[i][j]);
                    }
                    else
                    {
                        dic[subBoxKey] = new List<char> { board[i][j] };
                    }
                }
            }
        }

        return true;
    }

    // Bruteforce
    public static bool IsValidSudokuBruteforce(char[][] board)
    {
        var dic = new Dictionary<char,char>();

        // Row
        for (int i = 0; i < 9; i++)
        {
            dic.Clear();
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.' && dic.ContainsKey(board[i][j]))
                {
                    return false;
                }
                
                dic[board[i][j]] = Char.MinValue;
            }
        }

        // Column
        for (int i = 0; i < 9; i++)
        {
            dic.Clear();
            for (int j = 0; j < 9; j++)
            {
                if (board[j][i] != '.' && dic.ContainsKey(board[j][i]))
                {
                    return false;
                }
                
                dic[board[j][i]] = Char.MinValue;
            }
        }

        // Sub-Boxes
        for (int i = 0; i < 9; i = i+3)
        {
            for (int j = 0; j < 9; j = j+3)
            {
                if (!IsSubBoxValid(board, i, j, dic))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool IsSubBoxValid(char[][] board, int i, int j, Dictionary<char,char> dic)
    {
        dic.Clear();
        int imax = i + 3, jmax = j + 3;
        
        for (; i < imax; i++)
        {
            for (int tempJ = j; tempJ < jmax; tempJ++)
            {
                if (board[i][tempJ] != '.' && dic.ContainsKey(board[i][tempJ]))
                {
                    return false;
                }
                
                dic[board[i][tempJ]] = Char.MinValue;
            }
        }

        return true;
    }
}