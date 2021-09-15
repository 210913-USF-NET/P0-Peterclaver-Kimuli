using System;
using Models;

namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start(){
            Console.WriteLine("Welcome to the Shopping App!");
            Console.WriteLine("If you have an account, Type 0 to Login.");
            Console.WriteLine("If you have no account, Type 1 to Sign up.");
        }
        
    }
}