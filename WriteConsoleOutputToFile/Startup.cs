//  -------------------------------------------------------------------------
//  <copyright file="Startup.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2022 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       Startup class responsible for all the operations
//  </summary>
//  -------------------------------------------------------------------------

using System;

namespace WriteConsoleOutputToFile
{
    class Startup
    {
        public static void Invoker()
        {
            Console.WriteLine("This will be printed on Console but won't be Written on File - Before WriteTheConsoleDateToExternalFile() Invoke");
            WriteTheConsoleDateToExternalFile();
            Console.WriteLine("This will be printed on Console but won't be Written on File - After WriteTheConsoleDateToExternalFile() Invoke");
        }

        public static void WriteTheConsoleDateToExternalFile()
        {
            //ExtractConsoleOutputToFile extractConsoleOutputToFile = new ExtractConsoleOutputToFile();

            //This is sample for passing the params instead of default values
            ExtractConsoleOutputToFile extractConsoleOutputToFile = new ExtractConsoleOutputToFile("Result.txt");

            Console.SetOut(extractConsoleOutputToFile);

            Console.WriteLine("Hello World - 1");
            Console.WriteLine("Hello World - 2");
            Console.WriteLine("Hello World - 3");
            Console.WriteLine("Hello World - 4");
            Console.WriteLine("Hello World - 5");
            Console.WriteLine("Hello World - 6");
            Console.WriteLine("Hello World - 7");
            Console.WriteLine("Hello World - 8");
            Console.WriteLine("Hello World - 9");
            Console.WriteLine("Hello World - 10");
            Console.WriteLine("Hello World - 11");
            Console.WriteLine("..");
            Console.WriteLine("..");
            Console.WriteLine("..");
            Console.WriteLine("..");
            Console.WriteLine("..");
            Console.WriteLine("..");
            Console.WriteLine("Hello World - 100");
            Console.WriteLine("Hello World - 101");

            extractConsoleOutputToFile.Close();
        }
    }
}
