using System;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace Зкз2021
{
    class Program
    {
        static string[] Chtenie(string path)//Чтение данных из файла
        {
            string[] C = File.ReadAllLines(path);   
            return C;
        }
        static void InfoVectora(int[] vector)// метод выводящий отладочные данные
        {
            Debug.WriteLine("Вектор " + vector);
            foreach (var n in vector)
            {
                Debug.WriteLine(n);
            }
        }
        static void Main(string[] args)
        {
            string path = "New.csv";
            Class1 SZ = new Class1();
            string[] SuperData = File.ReadAllLines(path);
            
            string[] Data = Chtenie(path);
            string[] Nlenght = Data[0].Split(';');
            int razN = Nlenght.Length;
            Nlenght = Data[1].Split(';');
            int razVM = Nlenght.Length;
            Nlenght = Data[2].Split(';');
            int razVN = Nlenght.Length;
            int sumM = 0;
            int sumN = 0;
            int k = 0;
            for (int i = 0; i < Data.Length; i++)//Проверка файла
            {
                Nlenght = Data[i].Split(';');
                for (int j = 0; j < Nlenght.Length; j++)
                {
                    if (i == 0)
                        sumN = sumN + Convert.ToInt32(Nlenght[j]);
                    if (i == 1)
                        sumM = sumM + Convert.ToInt32(Nlenght[j]);
                    if (Convert.ToInt32(Nlenght[j]) == 0)
                        k++;
                }
            }
            if (razN == razVN && razVM == (Data.Length - 2) && sumM == sumN && k == 0)
            {
                Nlenght = Data[2].Split(';');
                int M, N;
                M = Data.Length - 2;
                N = Nlenght.Length;

                Debug.WriteLine("Значение N = " + N + " Значение M = " + M);
                int[] VectorN = new int[N]; // Создание векторов
                int[] VectorM = new int[M];

                VectorN = SZ.ZapolnVectora(VectorN, Data[0]);//Заполнение векторов
                VectorM = SZ.ZapolnVectora(VectorM, Data[1]);
                InfoVectora(VectorN);
                InfoVectora(VectorM);

                int[,] MatrixA = new int[M, N];// оздвние матриц
                int[,] MatrixB = new int[M, N];
                string[,] MatrixS = new string[M, N];
                for (int i = 0; i < M; i++) // Заполнение матрицы
                {
                    Nlenght = Data[i + 2].Split(';');
                    for (int j = 0; j < N; j++)
                    {
                        MatrixA[i, j] = Convert.ToInt32(Nlenght[j]);
                    }
                }

                MatrixB = SZ.Severo_Zapad(VectorM, VectorN, M, N, MatrixB);

                path = "Ответ.csv";
                int F = 0;
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        MatrixS[i, j] = Convert.ToString(MatrixA[i, j]);
                    }
                }
                for (int i = 0; i < M; i++) // Подсчёт F и создание 
                {
                    for (int j = 0; j < N; j++)
                    {                       
                        if (MatrixB[i, j] != 0)
                        {
                            F = F + MatrixB[i, j] * MatrixA[i, j];
                            MatrixS[i, j] = MatrixS[i, j] + "|"+Convert.ToString(MatrixB[i, j]);
                        }
                    }
                }
                string s = "F = " + F;
                File.WriteAllText(path, s+ "\n");
                Debug.WriteLine(s);
                for (int i = 0; i < M; i++) // Запись в файл
                {
                    string s2 = "";
                    for (int j = 0; j < N; j++)
                    {
                        s2 = s2 +  MatrixS[i, j]+";";                       
                    }   
                    File.AppendAllText(path, s2+"\n");
                }                               
            }
            else
            {
                Console.WriteLine("Данные в файле не верны");
            }

        }

            

    }


}
    
