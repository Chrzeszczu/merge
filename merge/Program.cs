using System;
using Xunit;

namespace MergeTxt // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            String filewithnum = @"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rNumber.txt";
            String filewithletter = @"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rLetter.txt";
            File.Copy(@"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rNumber.txt", @"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rNumberCopy.txt", true);
            File.Copy(@"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rLetter.txt", @"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rLetterCopy.txt", true);

            string c = File.ReadAllText(@"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rNumberCopy.txt");
            string d = File.ReadAllText(@"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\rLetterCopy.txt");

            StreamReader dataStreamNum = new StreamReader(filewithnum);
            string datasamplenum;
            while ((datasamplenum = dataStreamNum.ReadLine())
                != null)
            {

                int a = int.Parse(datasamplenum);
                if (a % 3 == 0)
                {
                    Console.WriteLine(a + "" + c + " is dividable by 3");
                    StreamReader dataStreamLetter = new StreamReader(filewithletter);
                    string datasampleletter;
                    while ((datasampleletter = dataStreamLetter.ReadLine())
                        != null)
                    {

                        char b = Char.Parse(datasampleletter);
                        if (Char.IsUpper(b))
                        {
                            Console.WriteLine(b + "" + d + " are uppercase letters");
                            Console.WriteLine(a + "" + c + "" + b + "" + d);
                            File.WriteAllText(@"C:\Users\michal.chrzeszczyk\Desktop\Jenkins_Workspace\Merge.txt", a + "" + b);
                            Assert.True(true);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine(b + "" + d + " aren't uppercase letters");
                            Assert.True(false);
                            Environment.FailFast("failed");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(a + "" + c + " isn't dibidable by 3");
                    Assert.True(false);
                    Environment.FailFast("failed");
                }
                
            }
        }

            
    }
}