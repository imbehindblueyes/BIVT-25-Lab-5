using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null) return new int[0];

            answer = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int count = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0) count++;
                }
                answer[j] = count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int jmin = 0;
            int minim = int.MaxValue;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] array = new int[m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minim)
                    {
                        jmin = j;
                        minim = matrix[i, j];
                    }
                }

                array[0] = minim;

                int k = 1;
                for (int j = 0; j < jmin; j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }
                for (int j = jmin + 1; j < m; j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = array[j];
                }

                jmin = 0;
                minim = int.MaxValue;
                array = new int[m];
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null) return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[,] array = new int[n, m + 1];
            int maxim = int.MinValue;
            int jmax = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxim)
                    {
                        jmax = j;
                        maxim = matrix[i, j];
                    }
                }

                int k = 0;
                for (int j = 0; j <= jmax; j++)
                {
                    array[i, k] = matrix[i, j];
                    k++;
                }
                for (int j = jmax; j < m; j++)
                {
                    array[i, k] = matrix[i, j];
                    k++;
                }

                maxim = int.MinValue;
                jmax = 0;
            }

            answer = array;
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int jmax = 0;
            int maxim = int.MinValue;
            int sum = 0;
            int count = 0;
            int sr = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxim)
                    {
                        jmax = j;
                        maxim = matrix[i, j];
                    }
                }

                for (int j = jmax + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count > 0)
                {
                    sr = sum / count;

                    for (int j = 0; j < jmax; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = sr;
                        }
                    }
                }

                maxim = int.MinValue;
                jmax = 0;
                sum = 0;
                count = 0;
                sr = 0;
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (matrix == null || k < 0 || k >= matrix.GetLength(1)) return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int jmax = 0;
            int maxim = int.MinValue;
            int[] array = new int[n];
            int a = n - 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxim)
                    {
                        jmax = j;
                        maxim = matrix[i, j];
                    }
                }

                array[a] = matrix[i, jmax];
                a--;

                maxim = int.MinValue;
                jmax = 0;
            }

            int b = 0;
            for (int i = 0; i < n; i++)
            {
                matrix[i, k] = array[b];
                b++;
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {
            // code here
            if (matrix == null) return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (m == array.Length)
            {
                for (int j = 0; j < m; j++)
                {
                    int max = matrix[0, j];
                    int iMax = 0;

                    for (int i = 1; i < n; i++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            iMax = i;
                        }
                    }

                    if (array[j] > max)
                    {
                        matrix[iMax, j] = array[j];
                    }
                }
            }
            
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            if (matrix == null) return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] mins = new int[n];

            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
                mins[i] = min;
            }

            int[] ind = new int[n];
            for (int i = 0; i < n; i++)
            {
                ind[i] = i;
            }

            bool f = true;
            while (f)
            {
                f = false;
                for (int i = 0; i < n - 1; i++)
                {
                    int r1 = ind[i];
                    int r2 = ind[i + 1];

                    if (mins[r1] < mins[r2])
                    {
                        int t = ind[i];
                        ind[i] = ind[i + 1];
                        ind[i + 1] = t;

                        f = true;
                    }
                }
            }

            int[,] sorted = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                int c = ind[i];
                for (int j = 0; j < m; j++)
                {
                    sorted[i, j] = matrix[c, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = sorted[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(1) != matrix.GetLength(0)) return null;

            int n = matrix.GetLength(0);

            answer = new int[2 * n - 1];

            for (int d = 0; d < answer.Length; d++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    int j = i + (d - (n - 1));
                    if (j >= 0 && j < n)
                    {
                        sum += matrix[i, j];
                    }
                }
                answer[d] = sum;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m || matrix == null) return;

            int imax = 0;
            int jmax = 0;
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                    {
                        max = matrix[i, j];
                        imax = i;
                        jmax = j;
                    }
                }
            }

            int a = k - imax;
            int b = k - jmax;


            if (a < 0)
            {
                for (int i = imax; i > k; i--)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                }
            }

            else
            {
                for (int i = imax; i < k; i++)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                }
            }

            if (b < 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = jmax; j > k; j--)
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                }
            }

            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = jmax; j < k; j++)
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A == null || B == null) return null;

            int a = A.GetLength(0);
            int b = A.GetLength(1);
            int c = B.GetLength(0);
            int d = B.GetLength(1);

            if (b == c)
            {
                answer = new int[a, d];
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < d; j++)
                    {
                        int summa = 0;
                        for (int x = 0; x < b; x++)
                        {
                            summa += A[i, x] * B[x, j];
                        }
                        answer[i, j] = summa;
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            if (matrix == null) return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int colvo = m;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        colvo--;
                    }
                }

                answer[i] = new int[colvo];
                int c = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][c] = matrix[i, j];
                        c++;
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                max += array[i].Length;
            }

            int n = (int)Math.Ceiling(Math.Sqrt(max));

            answer = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[i, j] = 0;
                }
            }

            int a = 0, b = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[a, b] = array[i][j];
                    b++;
                    if (b >= n)
                    {
                        b = 0;
                        a++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}