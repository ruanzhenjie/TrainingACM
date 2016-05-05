using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using ConsoleApplication1;
using System.Threading;


namespace WindowsFormsApplication1
{   

    
    //using ClassLibrary;
    public partial class frmPracticePlat : Form
    {
        SynchronizationContext m_SyncContext = null;
        private Topic topic;

        public frmPracticePlat(Topic mtopic)
        {
            topic = mtopic;
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            label1.Text = topic.Title;
            label2.Text = topic.Description;
            label3.Text = topic.InputExample;
            label4.Text = topic.OutputExample;

        }

        private void ThreadProcSafePost()
        {
            topic.Answer = txtCodeInput.Text;
            String t = Panti.RunCmd(topic);
          //  lblPrompt.Text = t;
            
            //...执行线程任务

            //在线程中更新UI（通过UI线程同步上下文m_SyncContext）
            m_SyncContext.Post(SetTextSafePost, t);

            //...执行线程其他任务
        }
        private void SetTextSafePost(object text)
        {
            //this..Text = text.ToString();
            DialogResult dr;
            dr = MessageBox.Show(text.ToString(), "提交结果", MessageBoxButtons.OK,
                     MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            btnSubmit.Enabled = true;

        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
          //=  Practics.PanTi(txtCodeInput.Text);
       
            Thread demoThread = new Thread(new ThreadStart(this.ThreadProcSafePost));
            demoThread.Start();
          
        }

        //private void 

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtCodeInput_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
