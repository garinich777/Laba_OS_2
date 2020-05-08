using System;

namespace Laba_OS_2
{
    enum Operation { No, Yes, Close }
    enum Menus { Start, About , Proceed, Exit, End }

    class Menu
    {
        public static int MainMenu()
        {
            for (int ChoosedMenuItem = (int)Menus.Start; ChoosedMenuItem < (int)Menus.End; ChoosedMenuItem++)
            {
               
                ShowInformation();
                ChoosedMenuItem = Check.GetInt();
                if (ChoosedMenuItem == (int)Menus.About)
                {
                    Console.Clear();
                    AboutProgram();
                    if (WhatsNext() == (int)Operation.No)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        ShowInformation();
                        MainMenu();
                    }
                }
                else if (ChoosedMenuItem == (int)Menus.Proceed)
                {
                    Console.Clear();
                    Proceed.ProceedFileSystemFunc();
                   
                    if (WhatsNext() == (int)Operation.No)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        ShowInformation();
                        MainMenu();
                    }
                }
                else if (ChoosedMenuItem == (int)Menus.Exit)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect choice, try again");
                    MainMenu();
                }
            }
            return (0);
        }
        public static void ShowInformation()
        {
            Console.WriteLine("-------------------Welcome---------------------");
            Console.WriteLine("-------To continue, select the menu item-------");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("--------------------1.About--------------------");
            Console.WriteLine("--------------------2.Proceed------------------");
            Console.WriteLine("--------------------3.Exit---------------------");
            Console.WriteLine("-----------------------------------------------");
        }
        public static void AboutProgram()
        {
            Console.WriteLine("This program analyze the state of file system and suggest ways to optimize it");
            Console.WriteLine("Bogdan Kluev, 484g, 2020");
            return;
        }
   

        static int WhatsNext()
        {
            Console.WriteLine("1. Back");
            Console.WriteLine("2. Exit");
            int UserChoice = 0;
            UserChoice = Check.GetInt();
            if (UserChoice == (int)Operation.Yes)
            {
                Console.Clear();
                MainMenu();
            }
            else if (UserChoice == (int)Operation.Close)
            {
                return (0);
            }
            else
            {
                Console.WriteLine("Incorrect choice, try again");
                WhatsNext();
            }
            return (0);
        }
    }
}

    
