using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ConsoleApplication1;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Topic topic = new Topic();
            topic.Title = "标题：\ta+b";
            topic.Description = "题目描述：\t输入两个数，并计算他们的和。";
            topic.InputExample = "输入例子：\t1 2";
            topic.OutputExample = "输出例子：\t3";
            
            topic.InputText = new String[3];
            topic.OutputText = new String[3];
         
            /*
            t.InputText[0] = "Qwe";
            t.InputText[1] = "wer";
            t.InputText[2] = "ert";
            t.OutputText[0] = "qwe";
            t.OutputText[1] = "wer";
            t.OutputText[2] = "ert";
            */

            topic.InputText[0] = "1 2";
            topic.InputText[1] = "2 3";
            topic.InputText[2] = "3 4";
            topic.OutputText[0] = "3";
            topic.OutputText[1] = "5";
            topic.OutputText[2] = "7";
            Application.Run(new frmPracticePlat(topic));

        }
    }
}
