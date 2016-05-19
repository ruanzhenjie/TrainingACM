using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WindowsFormsApplication1;

namespace OutportXml
{
    class Program
    {

        public static string sDataFilePath = Environment.CurrentDirectory + "\\Data";//XML文件存储的路径
        public static string sDataFileName = "database.clh";//XML文件名字,后缀没问题，用记事本打开就好。
        //public static string XmlFilePath = sDataFilePath + "\\" + sDataFileName;
        public static string XmlFilePath = sDataFileName;


        static void Main(string[] args)
        {
            List<Topic> mlist = new List<Topic>();

            Topic tp = new Topic();
            tp.Creater = "qqq";
            tp.Password = "111";
            tp.Title = "a+b";
            tp.Description = "was a+b";
            tp.InputExample = "1 2";
            tp.OutputExample = "3";
            tp.InputText = new String[3];
            tp.InputText[0] = "1 2";
            tp.InputText[1] = "2 3";
            tp.InputText[2] = "3 4";
            tp.OutputText = new String[3];
            tp.OutputText[0] = "3";
            tp.OutputText[1] = "5";
            tp.OutputText[2] = "7";

            mlist.Add(tp);
            tp = new Topic();
            tp.Creater = "qqq";
            tp.Password = "111";
            tp.Title = "a-b";
            tp.Description = "was a-b";
            tp.InputExample = "1 2";
            tp.OutputExample = "-1";
            tp.InputText = new String[3];
            tp.InputText[0] = "1 2";
            tp.InputText[1] = "2 3";
            tp.InputText[2] = "3 4";
            tp.OutputText = new String[3];
            tp.OutputText[0] = "-1";
            tp.OutputText[1] = "-1";
            tp.OutputText[2] = "-1";

            mlist.Add(tp);


            //outportXml(XmlFilePath, mlist, "qqq","222");

            mlist = new List<Topic>();

            importXml(XmlFilePath, mlist);

            foreach (Topic topic in mlist)
            {
                System.Console.Write(topic.ToString());
            }









            /*
            Topic topic = new Topic();
            topic.Title = "qwe";
            List<Topic> list = new List<Topic>();
            list.Add(topic);
            foreach(Topic t in list)
            {
                System.Console.WriteLine(t.Title);
            }
            */
            System.Console.ReadLine();
        }



        static void importXml(String XmlFilePath, List<Topic> listTopic) {
            // 判断文件是否存在，不存在则创建
            if (!File.Exists(XmlFilePath))
            {
                XmlDocument myXmlDoc1 = new XmlDocument();
                //创建文件的根节点，即Device
                XmlElement rootElement = myXmlDoc1.CreateElement("List");
                //将根节点“设备”加入到数据文件中
                myXmlDoc1.AppendChild(rootElement);
                myXmlDoc1.Save(XmlFilePath);
            }

            //初始化一个xml实例
            XmlDocument myXmlDoc = new XmlDocument();
            //加载xml文件（参数为xml文件的路径）
            myXmlDoc.Load(XmlFilePath);
            //获得此xml文件的根节点设备链
            XmlNode rootNode = myXmlDoc.SelectSingleNode("List");

            //获得设备链的子节点（即设备）
            XmlNodeList ndTopicList = rootNode.ChildNodes;
            XmlNodeList ndTextList;
            int i = 0;
            foreach (XmlNode ndTopic in ndTopicList)
            {
                Topic tp = new Topic();
                tp.Creater = ndTopic.SelectSingleNode("Creater").InnerText;
                tp.Password = ndTopic.SelectSingleNode("Password").InnerText;
                tp.Title = ndTopic.SelectSingleNode("Title").InnerText;
                tp.Description = ndTopic.SelectSingleNode("Description").InnerText;
                tp.InputExample = ndTopic.SelectSingleNode("InputExample").InnerText;
                tp.OutputExample = ndTopic.SelectSingleNode("OutputExample").InnerText;

                ndTextList = ndTopic.SelectNodes("InputText");
                tp.InputText = new String[ndTextList.Count];
                i = 0;
                foreach (XmlNode ndText in ndTextList)
                {
                    tp.InputText[i] = ndText.InnerText;
                    i++;
                }
                ndTextList = ndTopic.SelectNodes("OutputText");
                tp.OutputText = new String[ndTextList.Count];
                i = 0;
                foreach (XmlNode ndText in ndTextList)
                {
                    tp.OutputText[i] = ndText.InnerText;
                    i++;
                }

                listTopic.Add(tp);

            }
        }




        static void outportXml(String XmlFilePath ,List<Topic> listTopic, String creater = null , String password=null) {
            //creater==null 不改creater和password
            //creater!=null passsword!=null 改creater和设置password
            //creater!=null passsword==null 改creater和不修改password

            //创建数据文件，并初始化
            XmlDocument myXmlDoc = new XmlDocument();
            XmlElement eleTopic;
            XmlElement eleCreater;
            XmlElement elePassword;
            XmlElement eleTitle;
            XmlElement eleDescription;
            XmlElement eleInputExample;
            XmlElement eleOutputExample;
            XmlElement eleInputText;
            XmlElement eleOutputText;

            XmlElement eleRoot = myXmlDoc.CreateElement("List");

            myXmlDoc.AppendChild(eleRoot);

            foreach (Topic tp in listTopic) {
                eleTopic = myXmlDoc.CreateElement("Topic");
                eleRoot.AppendChild(eleTopic);
                eleCreater = myXmlDoc.CreateElement("Creater");
                elePassword = myXmlDoc.CreateElement("Password");
                eleTitle = myXmlDoc.CreateElement("Title");
                eleDescription = myXmlDoc.CreateElement("Description");
                eleInputExample = myXmlDoc.CreateElement("InputExample");
                eleOutputExample = myXmlDoc.CreateElement("OutputExample");
                eleTopic.AppendChild(eleCreater);
                eleTopic.AppendChild(elePassword);
                eleTopic.AppendChild(eleTitle);
                eleTopic.AppendChild(eleDescription);
                eleTopic.AppendChild(eleInputExample);
                eleTopic.AppendChild(eleOutputExample);

                eleTitle.InnerText = tp.Title;
                eleDescription.InnerText = tp.Description;
                eleInputExample.InnerText = tp.InputExample;
                eleOutputExample.InnerText = tp.OutputExample;


                if (creater != null)
                {
                    if (String.Compare(creater, tp.Creater) != 0)
                    {
                        eleCreater.InnerText = tp.Creater;
                        elePassword.InnerText = tp.Password;
                    }
                    else
                    {
                        eleCreater.InnerText = creater;
                        if (password != null)
                            elePassword.InnerText = password;
                        else
                            elePassword.InnerText = tp.Password;
                    }
                }
                else {
                    eleCreater.InnerText = tp.Creater;
                    elePassword.InnerText = tp.Password;
                }


                foreach (String input in tp.InputText)
                {
                    eleInputText = myXmlDoc.CreateElement("InputText");
                    eleInputText.InnerText = input;
                    eleTopic.AppendChild(eleInputText);
                }

                foreach (String output in tp.OutputText)
                {
                    eleOutputText = myXmlDoc.CreateElement("OutputText");
                    eleOutputText.InnerText = output;
                    eleTopic.AppendChild(eleOutputText);
                }

            }



            /*
            //创建文件的根节点，即Device
            XmlElement rootElement = myXmlDoc.CreateElement("Devices");
            //将根节点“设备”加入到数据文件中
            myXmlDoc.AppendChild(rootElement);

            //初始化设备表
            XmlElement felem1 = myXmlDoc.CreateElement("Device");//felem1 = f-elem-1 = first-element-1
                                                                 //记录第一个设备的名字（第一层的第一个子节点的属性值）      
            felem1.SetAttribute("Name", "磨床");
            //将设备磨床添加到“设备”（根节点）节点下
            rootElement.AppendChild(felem1);
            //初始化设备“磨床”（第二层的子节点）的第一个子节点（单面节点）
            XmlElement selem1 = myXmlDoc.CreateElement("Single");//s means second
                                                                 //初始化设备的单面数据链的第一个子节点
            XmlElement telem1 = myXmlDoc.CreateElement("data");//t means third
                                                               //设置设备数据的属性
            telem1.SetAttribute("dataTime", "2016/2/24 20:18:18");
            telem1.SetAttribute("Rs", "1");
            telem1.SetAttribute("Rx", "2");
            telem1.SetAttribute("Gp", "3");
            telem1.SetAttribute("Rp", "4");
            telem1.SetAttribute("Angle", "5");
            telem1.InnerText = "qwe";
            selem1.AppendChild(telem1);
            felem1.AppendChild(selem1);


            //初始化设备的单面数据链的第二个子节点
            XmlElement telem2 = myXmlDoc.CreateElement("data");//t means third
                                                               //设置设备数据的属性
            telem2.SetAttribute("dataTime", "2000/2/24 20:18:18");//               
            telem2.SetAttribute("Rs", "1");
            telem2.SetAttribute("Rx", "2");
            telem2.SetAttribute("Gp", "3");
            telem2.SetAttribute("Rp", "4");
            telem2.SetAttribute("Angle", "5");
            selem1.AppendChild(telem2);
            felem1.AppendChild(selem1);

            //初始化设备“磨床”（第二层的子节点）的第二个子节点（单面节点）
            XmlElement selem2 = myXmlDoc.CreateElement("Double");//s means second

            //初始化设备的双面数据链的第一个子节点
            XmlElement telem21 = myXmlDoc.CreateElement("data");//t means third
                                                                //设置设备数据的属性
            telem21.SetAttribute("dataTime", "2016/2/24 20:18:18");
            telem21.SetAttribute("R1s", "1");
            telem21.SetAttribute("R1x", "2");
            telem21.SetAttribute("G1p", "3");
            telem21.SetAttribute("R1p", "4");
            telem21.SetAttribute("Angle1", "5");
            telem21.SetAttribute("R2s", "6");
            telem21.SetAttribute("R2x", "7");
            telem21.SetAttribute("G2p", "8");
            telem21.SetAttribute("R2p", "9");
            telem21.SetAttribute("Angle2", "9");

            selem2.AppendChild(telem21);
            felem1.AppendChild(selem2);*/

            //将数据文件保存在指定的路径下
            myXmlDoc.Save(XmlFilePath);

        }
    }
}
