using System;
using System.IO;

namespace Laba_OS_2
{
    class Proceed
    {
        private delegate string SearchBlock(string block);
        const int MAX_FILE_SYS_SIZE = 100;

        public static void ProceedFileSystemFunc()
        {
            string file_system;            
            string[] fields = new string[MAX_FILE_SYS_SIZE];
            bool[] check_arr = new bool[MAX_FILE_SYS_SIZE];
            string A, B, C, D;
            A = B = C = D = string.Empty;
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

            int index = 0;
            for (int i = 0; fils[i] != "A"; i++)
            {
                fields[i] = fils[i];
                check_arr[i] = false;
                index = i;
            }

            for (int i = index; fils[i] != "EndOfFile"; i++)
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

            SearchBlock sb = (string block) =>
            {
                int temp = int.Parse(block);
                do
                {
                    block = block + ' ' + fields[temp];
                    check_arr[temp] = true;
                    temp = int.Parse(fields[temp]);
                }
                while (fields[temp] != "eof");

                check_arr[temp] = true;
                block = block + ' ' + "eof";
                Console.WriteLine("A: " + block);
                return block;
            };

            A = sb(A);
            B = sb(B);
            C = sb(C);
            D = sb(D);

            for (int i = 0; i < fields.Length; i++)
                if (fields[i] == "bad")
                    check_arr[i] = true;
            
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
                                    for (k = int.Parse(TempC[j]); k < 50; k++)
                                    {
                                        if (Fields[k] == "0" && j < 5)
                                        {
                                            Fields[k] = "Taken";
                                            TempC[j] = k.ToString();
                                            Fields[int.Parse((TempC[j - 1]))] = k.ToString();
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
                                    for (k = int.Parse(TempD[j]); k < 50; k++)
                                    {
                                        if (Fields[k] == "0" && j < 5)
                                        {
                                            Fields[k] = "1";
                                            TempD[j] = k.ToString();
                                            Fields[int.Parse((TempD[j - 1]))] = k.ToString();
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

        public static string[] NotEmpty(bool[] check_arr, string[] fields)
        {
            int temp = 0, i = 0, j = 0;
            string[] new_file = new string[5];
            do
            {
                temp = i;
                if ((check_arr[i] == false) && (fields[i] != "0"))
                {
                    if (j < 4)
                        new_file[j] = new_file[j] + i;
                    while ((fields[temp] != "eof") && check_arr[temp] == false)
                    {
                        new_file[j] = new_file[j] + ' ' + fields[temp];
                        check_arr[temp] = true;
                        temp = int.Parse(fields[temp]);
                    }
                    if (fields[temp] == "eof")
                    {
                        new_file[j] = new_file[j] + ' ' + "eof";
                        j++;
                    }
                }
                i++;
            }
            while (i < 50);
            return new_file;
        }
    }

}
