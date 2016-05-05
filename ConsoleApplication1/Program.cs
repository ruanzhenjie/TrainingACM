using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using ConsoleApplication1;

namespace CSharpIOTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Topic t = new Topic();
            t.InputText = new String[3];
            t.OutputText = new String[3];
            /*
            t.InputText[0] = "Qwe";
            t.InputText[1] = "wer";
            t.InputText[2] = "ert";
            t.OutputText[0] = "qwe";
            t.OutputText[1] = "wer";
            t.OutputText[2] = "ert";
            */

            t.InputText[0] = "1 2";
            t.InputText[1] = "2 3";
            t.InputText[2] = "3 4";
            t.OutputText[0] = "3";
            t.OutputText[1] = "5";
            t.OutputText[2] = "7";

            t.Answer = "#include<stdio.h>\r\nint main(){\r\nint a, b;\r\nscanf(\"%d%d\", &a, &b);\r\nprintf(\"%d\", a+b);\r\nreturn 0;\r\n}";
            
            //System.Console.Write(t.InputText.Length);

            System.Console.Write(RunCmd(t));
            System.Console.ReadLine();
        }

        private static string RunCmd(Topic t)
        {
            System.IO.File.WriteAllText("temp.c", t.Answer);

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.FileName = @"gcc";
            //p.StartInfo.FileName = @"C:\Program Files\Microsoft Visual Studio\VC98\Bin\CL.exe";
            //p.StartInfo.Arguments = @" f:\CodeInput.c -o f:\win.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();




            //p.StandardInput.WriteLine("gcc c.c -o c");
            p.StandardInput.WriteLine("cl temp.c");
            Thread.Sleep(5000);

            //p.StandardInput.WriteLine("c.exe <in.txt >myout.txt");
            //p.StandardInput.WriteLine("c.exe");
            //p.StandardInput.WriteLine("asd");
            // 检查生成的myout.txt 和 指定的out.txt的数据对比
            //p.StandardInput.WriteLine("FC myout.txt out.txt");

            p.StandardInput.WriteLine("exit");


            Process p2 = new Process();
            p2.StartInfo.FileName = "temp.exe";
            p2.StartInfo.UseShellExecute = false;
            p2.StartInfo.RedirectStandardError = true;
            p2.StartInfo.RedirectStandardInput = true;
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.CreateNoWindow = true;

            int l = t.InputText.Length;
            int i;
            String res = "Accept!";
            for (i = 0; i < l; i++) {
                p2.Start();
                p2.StandardInput.WriteLine(t.InputText[i]);
                if (!String.Equals(p2.StandardOutput.ReadToEnd(), t.OutputText[i])) {
                    res = "Wrong Answer!";
                    break;
                }
            }


            /*
            String str = "";
            p2.Start();
            p2.StandardInput.WriteLine(t.InputText[0]);
            str+= p2.StandardOutput.ReadToEnd();

            p2.Start();
            p2.StandardInput.WriteLine(t.InputText[1]);
            str += p2.StandardOutput.ReadToEnd();

            p2.Start();
            p2.StandardInput.WriteLine(t.InputText[2]);
            str += p2.StandardOutput.ReadToEnd();


            //p.StandardInput.WriteLine("exit");

            //return p2.StandardOutput.ReadToEnd();
            */
            return res;
        }

        private static void DisplayVersion()
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Cosmos Copyright 2010 Project");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("test ");
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("2013.10.19");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine();
        }
    }
}