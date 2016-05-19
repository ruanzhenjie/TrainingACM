using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//using System.Windows.Forms;

namespace WFONE
{

    class CDataBase
    {

        //public static string sdatafilepath = environment.currentdirectory + "\\data";//xml文件存储的路径
        //public static string sdatafilename = "database.xml";//xml文件名字
        //public static string xmlfilepath = sdatafilepath + "\\" + sdatafilename;
        //private void SetDatabaseFilePathAndName()
        //{
        //}


        ////生成包含所有设备数据的XML文件
        //public static void GenerateXmlFile()
        //{
        //    try
        //    {

        //        //创建数据文件，并初始化
        //        XmlDocument myXmlDoc = new XmlDocument();
        //        //创建文件的根节点，即Device
        //        XmlElement rootElement = myXmlDoc.CreateElement("Devices");
        //        //将根节点“设备”加入到数据文件中
        //        myXmlDoc.AppendChild(rootElement);


        //        //初始化设备表
        //        XmlElement felem1 = myXmlDoc.CreateElement("Device");//felem1 = f-elem-1 = first-element-1
        //                                                             //记录第一个设备的名字（第一层的第一个子节点的属性值）      
        //        felem1.SetAttribute("Name", "磨床");
        //        //将设备磨床添加到“设备”（根节点）节点下
        //        rootElement.AppendChild(felem1);
        //        //初始化设备“磨床”（第二层的子节点）的第一个子节点（单面节点）
        //        XmlElement selem1 = myXmlDoc.CreateElement("Single");//s means second
        //                                                             //初始化设备的单面数据链的第一个子节点
        //        XmlElement telem1 = myXmlDoc.CreateElement("data");//t means third
        //                                                           //设置设备数据的属性
        //        telem1.SetAttribute("dataTime", "2016/2/24 20:18:18");
        //        telem1.SetAttribute("Rs", "1");
        //        telem1.SetAttribute("Rx", "2");
        //        telem1.SetAttribute("Gp", "3");
        //        telem1.SetAttribute("Rp", "4");
        //        telem1.SetAttribute("Angle", "5");
        //        telem1.InnerText = "qwe";
        //        selem1.AppendChild(telem1);
        //        felem1.AppendChild(selem1);


        //        //初始化设备的单面数据链的第二个子节点
        //        XmlElement telem2 = myXmlDoc.CreateElement("data");//t means third
        //                                                           //设置设备数据的属性
        //        telem2.SetAttribute("dataTime", "2000/2/24 20:18:18");//               
        //        telem2.SetAttribute("Rs", "1");
        //        telem2.SetAttribute("Rx", "2");
        //        telem2.SetAttribute("Gp", "3");
        //        telem2.SetAttribute("Rp", "4");
        //        telem2.SetAttribute("Angle", "5");
        //        selem1.AppendChild(telem2);
        //        felem1.AppendChild(selem1);

        //        //初始化设备“磨床”（第二层的子节点）的第二个子节点（单面节点）
        //        XmlElement selem2 = myXmlDoc.CreateElement("Double");//s means second

        //        //初始化设备的双面数据链的第一个子节点
        //        XmlElement telem21 = myXmlDoc.CreateElement("data");//t means third
        //                                                            //设置设备数据的属性
        //        telem21.SetAttribute("dataTime", "2016/2/24 20:18:18");
        //        telem21.SetAttribute("R1s", "1");
        //        telem21.SetAttribute("R1x", "2");
        //        telem21.SetAttribute("G1p", "3");
        //        telem21.SetAttribute("R1p", "4");
        //        telem21.SetAttribute("Angle1", "5");
        //        telem21.SetAttribute("R2s", "6");
        //        telem21.SetAttribute("R2x", "7");
        //        telem21.SetAttribute("G2p", "8");
        //        telem21.SetAttribute("R2p", "9");
        //        telem21.SetAttribute("Angle2", "9");

        //        selem2.AppendChild(telem21);
        //        felem1.AppendChild(selem2);

        //        //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}
        ////遍历数据XML文件的信息
        //public static void GetXmlInformation()
        //{
        //    try
        //    {
        //        if (!Directory.Exists(sDataFilePath))
        //        {
        //            Directory.CreateDirectory(sDataFilePath);
        //        }
        //        // 判断文件是否存在，不存在则创建
        //        if (!File.Exists(XmlFilePath))
        //        {
        //            XmlDocument myXmlDoc1 = new XmlDocument();
        //            //创建文件的根节点，即Device
        //            XmlElement rootElement = myXmlDoc1.CreateElement("Devices");
        //            //将根节点“设备”加入到数据文件中
        //            myXmlDoc1.AppendChild(rootElement);
        //            myXmlDoc1.Save(XmlFilePath);
                    
        //        }
             
        //        //初始化一个xml实例
        //        XmlDocument myXmlDoc = new XmlDocument(); 
        //        //加载xml文件（参数为xml文件的路径）
        //        myXmlDoc.Load(XmlFilePath);
        //        //获得此xml文件的根节点设备链
        //        XmlNode rootNode = myXmlDoc.SelectSingleNode("Devices");
           
        //        //获得设备链的子节点（即设备）
        //        XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
        //        foreach (XmlNode device in firstLevelNodeList)
        //        {
        //            //获取设备的名称,设备只有“name”这一属性
        //            XmlAttributeCollection attribute = device.Attributes;  //属性的集合                    
        //            CDevice cdevice = CDeviceList.AddDevice(attribute[0].Value);

        //            //判断此节点是否单面数据集合节点和双面数据集合节点
        //            if (device.HasChildNodes)
        //            {
        //                //获取该节点的单面数据集合节点
        //                XmlNode single = device.FirstChild;
        //                foreach (XmlNode data in single)
        //                {
        //                    //将Xml文件中的所有单面设备数据逐一加载到单面数据链表中
        //                    XmlAttributeCollection a = data.Attributes;
        //                    CDeDataSl cdedataSl = new CDeDataSl();
        //                    //下面的转换是，整数转 字符串类型再转DataTime类型（有预感这种转换有问题）
        //                    cdedataSl.datetime = DateTime.Parse(a["dataTime"].Value);
        //                    cdedataSl.dRs = double.Parse(a["Rs"].Value);
        //                    cdedataSl.dRx = double.Parse(a["Rx"].Value);
        //                    cdedataSl.dGp = double.Parse(a["Gp"].Value);
        //                    cdedataSl.dRp = double.Parse(a["Rp"].Value);
        //                    cdedataSl.dA1 = double.Parse(a["A1"].Value);
        //                    cdedataSl.dA2 = double.Parse(a["A2"].Value);
        //                    cdedataSl.dPAngle = double.Parse(a["Angle"].Value);
        //                    cdevice.AddDeData(cdedataSl);
        //                }
        //                XmlNode double1 = device.ChildNodes[1];
        //                foreach (XmlNode data in double1)
        //                {

        //                    XmlAttributeCollection a = data.Attributes;
        //                    CDeDataDl cdedataDl = new CDeDataDl();
                           
        //                    cdedataDl.datetime = DateTime.Parse(a["dataTime"].Value);
        //                    cdedataDl.dR1s = double.Parse(a["R1s"].Value);
        //                    cdedataDl.dR1x = double.Parse(a["R1x"].Value);
        //                    cdedataDl.dG1p = double.Parse(a["G1p"].Value);
        //                    cdedataDl.dR1p = double.Parse(a["R1p"].Value);
        //                    cdedataDl.dA11 = double.Parse(a["A21"].Value);
        //                    cdedataDl.dA12 = double.Parse(a["A22"].Value);
        //                    cdedataDl.dPAngle1 = double.Parse(a["Angle1"].Value);
        //                    cdedataDl.dR2s = double.Parse(a["R2s"].Value);
        //                    cdedataDl.dR2x = double.Parse(a["R2x"].Value);
        //                    cdedataDl.dG2p = double.Parse(a["G2p"].Value);
        //                    cdedataDl.dR2p = double.Parse(a["R2p"].Value);
        //                    cdedataDl.dA11 = double.Parse(a["A21"].Value);
        //                    cdedataDl.dA12 = double.Parse(a["A22"].Value);
        //                    cdedataDl.dPAngle2 = double.Parse(a["Angle2"].Value);
        //                    cdevice.AddDeData(cdedataDl);
        //                }
        //            }
        //        }

        //        //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }


        //}


        ////修改XML文件的信息      
        //public static void ModifyXmlInformation()
        //{

        //}
        //#region 向Xml文件添加节点信息
        ////添加设备
        //public static void AddXmlInformation(CDevice cdevice )
        //{
        //    try
        //    {
        //        XmlDocument myXmlDoc = new XmlDocument();
        //        myXmlDoc.Load(XmlFilePath);
        //        XmlNode rootNode = myXmlDoc.SelectSingleNode("Devices");
        //        XmlElement device = myXmlDoc.CreateElement("Device");
        //        //初始化设备节点
        //        device.SetAttribute("Name", cdevice.name);
        //        //（初始化）添加单面设备数据集合节点
        //        XmlElement single1 = myXmlDoc.CreateElement("Single");
        //        device.AppendChild(single1);
        //        //（初始化）添加双面面设备数据集合节点
        //        XmlElement double1 = myXmlDoc.CreateElement("Double");
        //        device.AppendChild(double1);
        //        //添加设备节点
        //        rootNode.AppendChild(device);

        //          //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}
        ////添加单面设备数据
        //public static void AddXmlInformation(CDevice cdevice, CDeDataSl cdedata)
        //{
        //    try
        //    {
        //        XmlDocument myXmlDoc = new XmlDocument();
        //        myXmlDoc.Load(XmlFilePath);
        //        XmlNode rootNode = myXmlDoc.SelectSingleNode("Devices");//获取设备链节点
        //        XmlNode device = null;
        //        //获取设备节点
        //       foreach(XmlElement t in rootNode.ChildNodes )
        //        {
        //            if (t.GetAttribute("Name") == cdevice.name)
        //            {
        //                device = t;
        //                break;
        //            }

        //        }
        //        XmlNode single1 = device.SelectSingleNode("Single");//获取设备的单面设备数据集合的节点
        //        XmlElement data = myXmlDoc.CreateElement("data");
        //        data.SetAttribute("dataTime", cdedata.datetime.ToString());
        //        data.SetAttribute("Rs", cdedata.dRs.ToString());
        //        data.SetAttribute("Rx", cdedata.dRx.ToString());
        //        data.SetAttribute("Gp", cdedata.dGp.ToString());
        //        data.SetAttribute("Rp", cdedata.dRp.ToString());
        //        data.SetAttribute("A1", cdedata.dA1.ToString());
        //        data.SetAttribute("A2", cdedata.dA2.ToString());
        //        data.SetAttribute("Angle", cdedata.dPAngle.ToString());
        //        single1.AppendChild(data);

        //        //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        ////添加双面设备数据
        //public static void AddXmlInformation(CDevice cdevice, CDeDataDl cdedata)
        //{
        //    try
        //    {

        //        XmlDocument myXmlDoc = new XmlDocument();
        //        myXmlDoc.Load(XmlFilePath);
        //        XmlNode rootNode = myXmlDoc.SelectSingleNode("Devices");//获取设备链节点
        //        XmlNode device = null ;
        //        //获取设备节点
        //        foreach (XmlElement t in rootNode.ChildNodes)
        //        {
        //            if (t.GetAttribute("Name") == cdevice.name)
        //            {
        //                device = t;
        //                break;
        //            }

        //        }
               
        //        XmlNode double1 = device.SelectSingleNode("Double");////获取设备的双面设备数据集合的节点
        //        XmlElement data = myXmlDoc.CreateElement("data");
        //        data.SetAttribute("dataTime", cdedata.datetime.ToString());
        //        data.SetAttribute("R1s", cdedata.dR1s.ToString());
        //        data.SetAttribute("R1x", cdedata.dR1x.ToString());
        //        data.SetAttribute("G1p", cdedata.dG1p.ToString());
        //        data.SetAttribute("R1p", cdedata.dR1p.ToString());
        //        data.SetAttribute("A11", cdedata.dA21.ToString());
        //        data.SetAttribute("RA12", cdedata.dA22.ToString());
        //        data.SetAttribute("Angle1", cdedata.dPAngle1.ToString());
        //        data.SetAttribute("R2s", cdedata.dR2s.ToString());
        //        data.SetAttribute("R2x", cdedata.dR2x.ToString());
        //        data.SetAttribute("G2p", cdedata.dG2p.ToString());
        //        data.SetAttribute("R2p", cdedata.dR2p.ToString());
        //        data.SetAttribute("A11", cdedata.dA21.ToString());
        //        data.SetAttribute("A12", cdedata.dA22.ToString());
        //        data.SetAttribute("Angle2", cdedata.dPAngle2.ToString());
        //        double1.AppendChild(data);

        //        //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //#endregion

        //#region 删除指定节点的信息
        ////删除设备
        //public static void DeleteXmlInformation(CDevice cdevice)
        //{
        //    try
        //    {
        //        XmlDocument myXmlDoc = new XmlDocument();
        //        myXmlDoc.Load(XmlFilePath);
        //        XmlNode rootNode = myXmlDoc.SelectSingleNode("Devices");//获取设备链节点
        //                                                                //获取设备节点
        //        XmlNode device = null;
        //        //获取设备节点
        //        foreach (XmlElement t in myXmlDoc.FirstChild.ChildNodes)
        //        {
        //            if (t.GetAttribute("Name") == cdevice.name)
        //            {
        //                device = t;
        //                break;
        //            }

        //        }
        //        rootNode.RemoveChild(device);
        //        //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        ////删除指定设备的指定单面设备数据
        //public static void DeleteXmlInformation(CDevice cdevice, CDeDataSl cdedata)
        //{
        //    try
        //    {
        //        XmlDocument myXmlDoc = new XmlDocument();
        //        myXmlDoc.Load(XmlFilePath);
        //        XmlNode device = null;
        //        //获取设备节点
        //        foreach (XmlElement t in myXmlDoc.FirstChild.ChildNodes)
        //        {
        //            if (t.GetAttribute("Name") == cdevice.name)
        //            {
        //                device = t;
        //                break;
        //            }

        //        }
        //        foreach (XmlElement data in device.ChildNodes[0].ChildNodes)
        //        {
        //            if (data.Attributes["dataTime"].Value == cdedata.datetime.ToString())
        //            {
        //                device.ChildNodes[0].RemoveChild(data);
        //                break;
        //            }
        //        }

        //        //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        ////删除指定设备的指定双面数据信息
        //public static void DeleteXmlInformation(CDevice cdevice, CDeDataDl cdedata)
        //{
        //    try
        //    {
        //        XmlDocument myXmlDoc = new XmlDocument();
        //        myXmlDoc.Load(XmlFilePath);
        //        XmlNode device = null;
        //        //获取设备节点
        //        foreach (XmlElement t in myXmlDoc.FirstChild.ChildNodes)
        //        {
        //            if (t.GetAttribute("Name") == cdevice.name)
        //            {
        //                device = t;
        //                break;
        //            }

        //        }
        //        //获取双面设备数据链
        //        foreach (XmlElement data in device.ChildNodes[1].ChildNodes)
        //        {
        //            if (data.Attributes["dataTime"].Value == cdedata.datetime.ToString())
        //            {
        //                device.ChildNodes[1].RemoveChild(data);
        //                break;
        //            }
        //        }

        //        //将数据文件保存在指定的路径下
        //        myXmlDoc.Save(XmlFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //#endregion
    }

}
