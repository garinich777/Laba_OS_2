using System;
using System.IO;

namespace Laba_OS_2
{
    class Proceed
    {
        public static void ProceedFileSystemFunc()
        {
            string file_system;
            string[] fields = new string[100];
            bool[] check_arr = new bool[100];
            string A = " ", B = " ", C = " ", D = " ";
            string[] search_value = new string[10];

            string file_name = "FileSystem.txt";
            if (File.Exists(file_name))
            {
                using (StreamReader reader = new StreamReader(file_name))
                    file_system = reader.ReadToEnd();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"File not exist{Environment.NewLine}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                return;
            }
                
            string[] fils = file_system.Split(' ');

            for (int i = 0; fils[i] != "EndOfFile"; i++)
            {
                if (i < 50)
                {
                    fields[i] = fils[i];
                    check_arr[i] = false;
                }
                else
                {
                    switch (fils[i])
                    {
                        case "A":
                            A = fils[i + 1];
                            break;
                        case "B":
                            B = fils[i + 1];
                            break;
                        case "C":
                            C = fils[i + 1];
                            break;
                        case "D":
                            D = fils[i + 1];
                            break;
                    }
                }
            }

            for (int j = 0; j < 4; j++)
            {
                if (j == 0)
                {
                    int TempValue = Convert.ToInt32(A);
                    do
                    {
                        A = A + ' ' + fields[TempValue];
                        check_arr[TempValue] = true;
                        TempValue = Convert.ToInt32(fields[TempValue]);
                    }
                    while (fields[TempValue] != "eof");
                    check_arr[TempValue] = true;
                    A = A + ' ' + "eof";
                    Console.WriteLine("A: " + A);
                }
                else if (j == 1)
                {
                    int temp = 0;
                    temp = Convert.ToInt32(B);
                    do
                    {
                        B = B + ' ' + fields[temp];
                        check_arr[temp] = true;
                        temp = Convert.ToInt32(fields[temp]);
                    }
                    while (fields[temp] != "eof");
                    check_arr[temp] = true;
                    B = B + ' ' + "eof";
                    Console.WriteLine("B: " + B);
                }
                if (j == 2)
                {
                    int temp = 0;
                    temp = Convert.ToInt32(C);
                    do
                    {
                        C = C + ' ' + fields[temp];
                        check_arr[temp] = true;
                        temp = Convert.ToInt32(fields[temp]);
                    }
                    while (fields[temp] != "eof");
                    check_arr[temp] = true;
                    C = C + ' ' + "eof";
                    Console.WriteLine("C: " + C);
                }
                if (j == 3)
                {
                    int temp = 0;
                    temp = Convert.ToInt32(D);
                    do
                    {
                        D = D + ' ' + fields[temp];
                        check_arr[temp] = true;
                        temp = Convert.ToInt32(fields[temp]);
                    }
                    while (fields[temp] != "eof");
                    check_arr[temp] = true;
                    D = D + ' ' + "eof";
                    Console.WriteLine("D: " + D);
                }
            }
            for (int j = 0; j < 50; j++)
            {
                if (fields[j] == "bad")
                    check_arr[j] = true;
            }
            search_value = NotEmpty(check_arr, fields);
            string[] Splited = new string[3];
            for (int j = 0; j < 5; j++)
            {
                if (search_value[j] != "eof")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An unnamed part of the data was found. Written under the names E, F, G");
                    Console.WriteLine("E: " + search_value[j]);
                    Console.WriteLine("F: " + search_value[j + 2]);
                    Console.WriteLine("G: " + search_value[j + 3]);
                    break;
                }
            }
            IsEqual(A, B, C, D, fields);    
        }

        public static string IsEqual(string A, string B, string C, string D, string[] Fields)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Overlapping files were found. Fixed file system: ");
            string Temp = "";
            int k = 0;
            string[] TempA = A.Split(' ');
            string[] TempB = B.Split(' ');
            string[] TempC = C.Split(' ');
            string[] TempD = D.Split(' ');
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        for (int j = 0; j < 6; j++)
                        {
                            if (TempB[j] == TempC[j])
                            {
                                if (j < 5)
                                {
                                    for (k = Convert.ToInt32(TempC[j]); k < 50; k++)
                                    {
                                        if (Fields[k] == "0" && j < 5)
                                        {
                                            Fields[k] = "Taken";
                                            TempC[j] = k.ToString();
                                            Fields[Convert.ToInt32((TempC[j - 1]))] = k.ToString();
                                            break;
                                        }
                                    }
                                }
                                else if (Fields[k] == "1" && j > 5)
                                {
                                    TempC[j] = "eof";
                                }
                            }
                        }
                        break;
                    case 2:
                        for (int j = 0; j < 6; j++)
                        {
                            if (TempB[j] == TempD[j])
                            {
                                if (j < 5)
                                {
                                    for (k = Convert.ToInt32(TempD[j]); k < 50; k++)
                                    {
                                        if (Fields[k] == "0" && j < 5)
                                        {
                                            Fields[k] = "1";
                                            TempD[j] = k.ToString();
                                            Fields[Convert.ToInt32((TempD[j - 1]))] = k.ToString();
                                            break;
                                        }
                                    }
                                }
                                else if (Fields[k] == "1" && j > 5)
                                {
                                    TempD[j] = "eof";
                                }
                            }
                        }
                        break;
                }

            };
            Temp = "";
            for (int i = 0; i < 6; i++)
            {
                Temp = Temp + TempA[i] + ' ';
            }
            Console.WriteLine("A: " + Temp);
            Temp = "";
            for (int i = 0; i < 6; i++)
            {
                Temp = Temp + TempB[i] + ' ';
            }
            Console.WriteLine("B: " + Temp);
            Temp = "";
            for (int i = 0; i < 6; i++)
            {
                Temp = Temp + TempC[i] + ' ';
            }
            Console.WriteLine("C: " + Temp);
            Temp = "";
            for (int i = 0; i < 6; i++)
            {
                Temp = Temp + TempD[i] + ' ';
            }
            Console.WriteLine("D: " + Temp);
            return Temp;
        }

        public static string[] NotEmpty(bool[] Checked, string[] Fields)
        {
            int Temp = 0, i = 0, j = 0;
            string[] NewFile = new string[5];
            do
            {
                Temp = i;
                if ((Checked[i] == false) && (Fields[i] != "0"))
                {
                    if (j < 4)
                        NewFile[j] = NewFile[j] + i;
                    while ((Fields[Temp] != "eof") && Checked[Temp] == false)
                    {
                        NewFile[j] = NewFile[j] + ' ' + Fields[Temp];
                        Checked[Temp] = true;
                        Temp = Convert.ToInt32(Fields[Temp]);
                    }
                    if (Fields[Temp] == "eof")
                    {
                        NewFile[j] = NewFile[j] + ' ' + "eof";
                        j++;
                    }
                }
                i++;
            }
            while (i < 50);
            return NewFile;
        }
    }

}
