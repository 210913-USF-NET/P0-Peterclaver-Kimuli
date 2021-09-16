using System;
using Models;
using BL;
using DL;

namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start(){
            bool exit = false;
            string input = "";

            do{
                Console.WriteLine("Welcome to the Shopping App!");
                Console.WriteLine("Have an account? Type 0 to Login.");
                Console.WriteLine("No account? Type 1 to Sign up.");
                Console.WriteLine("Or you can type x to Sign up.\n");

                input = Console.ReadLine();

                switch(input){
                    case "0":
                        Console.WriteLine("Login");
                        break;
                    case "1":
                        new SignupMenu(new CBL(new FileRepo())).Start();
                        break;
                    case "x":
                        Console.WriteLine("Exiting...\n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please type the right input");
                        break;
                }

            }while (!exit);

        }
        
    }
}