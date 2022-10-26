using System;
using System.IO;
using System.Linq;

namespace Lakas {
    class Program {
        static void Main(string[] args) {
            string[] nyers = File.ReadAllLines("alaprajz1.txt");

            string[] dimenziok = nyers[0].Split(' ');

            string[,] alaprajz = new string[int.Parse(dimenziok[0]), int.Parse(dimenziok[1])];

            for (int i = 0; i < int.Parse(dimenziok[0]); i++) {
                for (int j = 0; j < int.Parse(dimenziok[1]); j++) {
                    alaprajz[i, j] = Convert.ToString(nyers[i+1][j]);
                }
            }

            string[,] uj_alap = new string[alaprajz.GetLength(0), alaprajz.GetLength(1)];

            for (int i = 0; i < alaprajz.GetLength(0); i++) {
                for (int j = 0; j < alaprajz.GetLength(1); j++) {
                    if (alaprajz[i, j] == "1" && j == 0 || 
                        alaprajz[i, j] == "1" && j == alaprajz.GetLength(1)-1 ||
                        alaprajz[i, j] == "1" && i == 0 ||
                        alaprajz[i, j] == "1" && i == alaprajz.GetLength(0)-1) {

                        uj_alap[i, j] = "F";
                    }
                    else {
                        uj_alap[i, j] = alaprajz[i, j];
                    }
                }
            }

            bool van_szomszed(string elem) {
                bool valasz = false;

                for (int i = 0; i < uj_alap.GetLength(0); i++) {
                    for (int j = 0; j < uj_alap.GetLength(1); j++) {
                        if (uj_alap[i-1, j] != "0" || uj_alap[i + 1, j] != "0" || uj_alap[i, j-1] != "0" || uj_alap[i, j+1] != "0") {
                            valasz = true;
                        }
                    }
                }

                return valasz;
            }

            for (int i = 0; i < uj_alap.GetLength(0); i++) {
                for (int j = 0; j < uj_alap.GetLength(1); j++) {
                    Console.Write(uj_alap[i, j] + " ");
                }
                Console.WriteLine("");
            }

        }
    }
}
