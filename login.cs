using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace E_mail {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("1) Bejelentkezes" + Environment.NewLine + "2) Regisztracio");
            int input = int.Parse(Console.ReadLine());

            bool username_check(string uname) {
                string[] adatok = File.ReadAllLines("adatok.txt");
                bool elfogadott = true;

                for (int i = 0; i < adatok.Length; i++) {
                    string[] temp = adatok[i].Split(' ');

                    if (temp[0] == uname)
                    {
                        elfogadott = false;
                    }
                }

                return elfogadott;
            }

            bool password_check(string pass) {
                bool elfogadott = false;

                if (Regex.IsMatch(pass, @"^[a-zA-Z0-9]+$")) {
                    elfogadott = true;
                }

                return elfogadott;
            }

            int hash(string pass) {
                string jelszo = pass;

                if (pass.Length < 10) {
                    for (int i = 0; i < 10 - pass.Length; i++) {
                        jelszo = jelszo + "d";
                    }
                }

                byte[] asciiBytes = Encoding.ASCII.GetBytes(jelszo);

                int szam = 0;

                for (int i = 0; i < asciiBytes.Length; i++) {
                    szam = szam + asciiBytes[i];
                }
                return szam;
            }

           

            switch (input) {
                default:
                    break;
                case 1:
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("REGISZTRACIO");

                    Console.Write("Felhasznalonev: ");
                    string username = Console.ReadLine();

                    if (username_check(username)) {
                        if (username.Length <= 15) {
                            Console.Clear();
                            Console.Write("Jelszo: ");
                            string password = Console.ReadLine();
                            if (password.Length >= 8 && password.Length <= 10) {
                                if (password_check(password)) {
                                    File.AppendAllText("adatok.txt",Environment.NewLine + username + " " + hash(password));
                                }
                            }
                            else {
                                Console.WriteLine("A jelszo 8-10 karakter lehet!");
                            }
                        }
                        else {
                            Console.WriteLine("A felhasznalonev maximum 15 karakter legyen!");
                        }
                    }
                    else {
                        Console.WriteLine("Ez a felhasznalonev mar foglalt!");
                    }
                    break;
            }

        }
    }
}
