using System;
using System.IO;
using System.Linq;

namespace ConsoleApp3 {
    class Program {
        static void Main(string[] args) {

            string[] sorok = File.ReadAllLines("palyaX.txt");
            string[,] tabla = new string[sorok.Length, sorok[0].Length];

            for (int i = 0; i < sorok.Length; i++) {
                for (int j = 0; j < sorok[0].Length; j++) {
                    tabla[i, j] = Convert.ToString(sorok[i][j]);
                }
            }

            bool charSelect = true;
            int sor = 0;
            int oszlop = 0;
            string selected = "";

            while (charSelect) {
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                switch (key.Key) {
                    case ConsoleKey.UpArrow:
                        sor = sor - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        sor = sor + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        oszlop = oszlop - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        oszlop = oszlop + 1;
                        break;
                    case ConsoleKey.Enter:
                        charSelect = false;
                        break;
                }
                Console.WriteLine("---------");
                selected = tabla[sor, oszlop];

                int rowLength = tabla.GetLength(0);
                int colLength = tabla.GetLength(1);

                for (int i = 0; i < rowLength; i++) {
                    for (int j = 0; j < colLength; j++) {
                        if (i == sor && j == oszlop) {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(string.Format("{0}", tabla[i, j]));
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else {
                            Console.Write(string.Format("{0}", tabla[i, j]));
                        }
                    }
                    Console.Write(Environment.NewLine);
                }
            }

        }
    }
}
