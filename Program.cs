using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp7 {
    class Program {
        static void Main(string[] args) {
            string[] nyers = File.ReadAllLines("alaprajz1.txt");

            string[] dimenziok = nyers[0].Split(' ');

            string[,] alaprajz = new string[int.Parse(dimenziok[0]), int.Parse(dimenziok[1])];

            for (int i = 0; i < int.Parse(dimenziok[0]); i++) {
                for (int j = 0; j < int.Parse(dimenziok[1]); j++) {
                    alaprajz[i, j] = Convert.ToString(nyers[i + 1][j]);
                }
            }

            string[,] uj_alap = new string[alaprajz.GetLength(0), alaprajz.GetLength(1)];

            //fal
            for (int i = 0; i < alaprajz.GetLength(0); i++) {
                for (int j = 0; j < alaprajz.GetLength(1); j++) {
                    if (alaprajz[i, j] == "1" && j == 0 ||
                        alaprajz[i, j] == "1" && j == alaprajz.GetLength(1) - 1 ||
                        alaprajz[i, j] == "1" && i == 0 ||
                        alaprajz[i, j] == "1" && i == alaprajz.GetLength(0) - 1) {

                        uj_alap[i, j] = "F";
                    }
                    else {
                        uj_alap[i, j] = alaprajz[i, j];
                    }
                }
            }

            string szomszed(int pos1, int pos2, char irany) {

                string elem = "";

                switch (irany) {
                    case 'j':
                        if (pos2 != uj_alap.GetLength(1)-1) {
                            elem = uj_alap[pos1, pos2 + 1];
                        }
                        break;
                    case 'b':
                        if (pos2 != 0) {
                            elem = uj_alap[pos1, pos2 - 1];
                        }
                        break;
                    case 'f':
                        if (pos1 != 0) {
                            elem = uj_alap[pos1 - 1, pos2];
                        }
                        break;
                    case 'l':
                        if (pos1 != uj_alap.GetLength(0) - 1) {
                            elem = uj_alap[pos1 + 1, pos2];
                        }
                        break;
                }

                return elem;
            }

            //fal 2
            for (int i = 0; i < uj_alap.GetLength(0); i++) {
                for (int j = 0; j < uj_alap.GetLength(1); j++) {
                    if (szomszed(i, j, 'f') == "F" && uj_alap[i,j] == "1") {
                        uj_alap[i, j] = "F";
                    } else if (szomszed(i, j,'l') == "F" && uj_alap[i, j] == "1") {
                        uj_alap[i, j] = "F";
                    } else if (szomszed(i, j,'b') == "F" && uj_alap[i, j] == "1") {
                        uj_alap[i, j] = "F";
                    } else if (szomszed(i, j, 'j') == "F" && uj_alap[i, j] == "1") {
                        uj_alap[i, j] = "F";
                    }
                }

            }

            //szek
            for (int i = 0; i < uj_alap.GetLength(0); i++) {
                for (int j = 0; j < uj_alap.GetLength(1); j++) {
                    if (uj_alap[i,j] == "1" && szomszed(i, j, 'f') == "0" && szomszed(i, j, 'l') == "0" && szomszed(i, j, 'j') == "0" && szomszed(i, j, 'b') == "0") {
                        uj_alap[i, j] = "S";
                    }
                }
            }

            //kanape
            for (int i = 0; i < uj_alap.GetLength(0); i++) {
                for (int j = 0; j < uj_alap.GetLength(1); j++) {
                    string akt = uj_alap[i, j];

                    if (akt == "1" && szomszed(i, j, 'b') == "0" && szomszed(i, j, 'j') == "0" && szomszed(i, j, 'l') == "1") {
                        uj_alap[i,j] = "K";
                    } else if (akt == "1" && szomszed(i, j, 'f') == "K" && szomszed(i,j,'l') == "0") {
                        uj_alap[i,j] = "K";
                    }


                    if (akt == "1" && szomszed(i,j,'j') == "1" && szomszed(i,j, 'l') == "1" && szomszed(i+1,j,'j') == "0") {
                        uj_alap[i, j] = "K";
                        uj_alap[i, j + 1] = "K";
                    }

                    if (akt == "1" && szomszed(i, j, 'b') == "1" && szomszed(i, j, 'l') == "1" && szomszed(i + 1, j, 'b') == "0") {
                        uj_alap[i, j] = "K";
                        uj_alap[i, j - 1] = "K";

                    }

                }
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
