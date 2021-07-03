using System;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace Северо_запад
{
    class Program
    {
        static string[] Chtenie(string path)//Чтение данных из файла
        {
            string[] C = File.ReadAllLines(path);           
            return C;
        }
        static void Main(string[] args)
        {
            string path = "New.csv";
            //Class1 SZ = new Class1();  
            string[] SuperData = File.ReadAllLines(path);
            string[] Data = Chtenie(path); 
            foreach (var item in Data)
            {
                Console.WriteLine(item);
            }
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
            { }
            
            
        }
    }
}