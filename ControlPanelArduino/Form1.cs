using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace ControlPanelArduino
{
    public partial class Form1 : Form
    {
        public TcpClient client;
        const int PORT = 2000; // порт для прослушивания подключений
        String Address;
        StreamWriter writer;
        StreamReader reader;
        NetworkStream stream;
        public static String Message;
        public int Hu = 0; public int Il = 0; public int Te = 0;
        public static String sHu = ""; public static String sIl = ""; public static String sTe = "";
        public static int TE = 0; public static int HU = 0; public static int IL = 0;
        public static int hu_max = 0; public static int te_max = 0; public static int il_max = 0;
        public static int hu_min = 0; public static int te_min = 0; public static int il_min = 0;
        public static String sHuMin = ""; public static String sHuMax = ""; public static String sTeMin = "";
        public static String sTeMax = ""; public static String sIlMin = ""; public static String sIlMax = "";
        public Bitmap  bmpOn = new Bitmap(ControlPanelArduino.Properties.Resources.LEDOn);
        public Bitmap bmpOff = new Bitmap(ControlPanelArduino.Properties.Resources.LEDOff);
        public Bitmap bmpDim = new Bitmap(ControlPanelArduino.Properties.Resources.LEDDim);
        public static bool FlagChecked1 = false; public static bool FlagChecked2 = false; public static bool FlagChecked3 = false;
        public static int FlagSwitch1 = 1; public static int FlagSwitch2 = 0; public static int FlagSwitch3 = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog(this);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                reader.Close();
                writer.Close();
                stream.Close();
                client.Close();
            }
            RxTxTimer.Enabled = false;
            DrawTimer.Enabled = false;
            Maintimer.Enabled = false;
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            try
            {
                DataForm report = new DataForm();
                report.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           
        }

        private void On_Click(object sender, EventArgs e)
        {
            On.Text = "Подключение...";
            if (client == null)
            {
                try
                {
                    
                    Address = textBox2.Text;
                    client = new TcpClient(Address, PORT);
                    stream = client.GetStream();
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);
                  
                    textBox1.Text = Convert.ToString(PORT);
                    textBox1.BackColor = Color.FromArgb(64, 64, 64);
                    textBox1.ForeColor = Color.FromArgb(255, 255, 192);
                    textBox2.BackColor = Color.FromArgb(64, 64, 64);
                    textBox2.ForeColor = Color.FromArgb(255, 255, 192);

                    labelOn.ForeColor = Color.FromArgb(255, 255, 192);
                    label1.ForeColor = Color.FromArgb(255, 255, 192);
                    label13.ForeColor = Color.FromArgb(255, 255, 192);
                    label14.ForeColor = Color.FromArgb(255, 255, 192);
                    label15.ForeColor = Color.FromArgb(255, 255, 192);
                    label16.ForeColor = Color.FromArgb(255, 255, 192);
                    label17.ForeColor = Color.FromArgb(255, 255, 192);
                    label18.ForeColor = Color.FromArgb(255, 255, 192);
                    label3.ForeColor = Color.FromArgb(255, 255, 192);
                    label4.ForeColor = Color.FromArgb(255, 255, 192);
                    label5.ForeColor = Color.FromArgb(255, 255, 192);

                    radialGauge1.BackgroundGradientStartColor = Color.FromArgb(255, 255, 192);
                    radialGauge2.BackgroundGradientStartColor = Color.FromArgb(255, 255, 192);
                    radialGauge3.BackgroundGradientStartColor = Color.FromArgb(255, 255, 192);
                    radialGauge1.ScaleLabelColor = Color.FromArgb(255, 255, 192);
                    radialGauge2.ScaleLabelColor = Color.FromArgb(255, 255, 192);
                    radialGauge3.ScaleLabelColor = Color.FromArgb(255, 255, 192);

                    chart1.BackColor = Color.FromArgb(255, 255, 192);

                    pictureBoxOnHu.Image = (Image)bmpOff;
                    pictureBoxOffHu.Image = (Image)bmpOff;
                    pictureBoxOnTe.Image = (Image)bmpOff;
                    pictureBoxOffTe.Image = (Image)bmpOff;
                    pictureBoxOnIl.Image = (Image)bmpOff;
                    pictureBoxOffIl.Image = (Image)bmpOff;

                    groupBox1.ForeColor = Color.FromArgb(255, 255, 192);
                    groupBox2.ForeColor = Color.FromArgb(255, 255, 192);
                    groupBox3.ForeColor = Color.FromArgb(255, 255, 192);
                    groupBox4.ForeColor = Color.FromArgb(255, 255, 192);
                    groupBox6.ForeColor = Color.FromArgb(255, 255, 192);

                    chart1.BackColor = Color.FromArgb(255, 255, 192);
                    chart1.ChartAreas[0].BackColor = Color.FromArgb(255, 255, 192);
                    chart1.Legends[0].BackColor = Color.FromArgb(255, 255, 192);

                    if (FlagSwitch1 == 1)
                    {
                        radioButtonHu.Checked = true;
                        groupBox1.ForeColor = Color.FromArgb(0, 255, 0);
                    }
                    else
                    if (FlagSwitch2 == 1)
                    {
                        radioButtonTe.Checked = true;
                        groupBox2.ForeColor = Color.FromArgb(0, 255, 0);
                    }
                    else
                    if (FlagSwitch3 == 1)
                    {
                        radioButtonIl.Checked = true;
                        groupBox3.ForeColor = Color.FromArgb(0, 255, 0);
                    }

                    RxTxTimer.Enabled = true;
                    DrawTimer.Enabled = true;
                    Maintimer.Enabled = true;
                }
                catch (Exception ex)
                {
                    On.Text = "Повторить";
                    On.BackColor = Color.OrangeRed;
                    RxTxTimer.Enabled = false;
                    DrawTimer.Enabled = false;
                    Maintimer.Enabled = true;
                    client = null;
                    MessageBox.Show(ex.Message);

                }

            }
        }

        private void Off_Click(object sender, EventArgs e)
        {
            RxTxTimer.Enabled = false;
            DrawTimer.Enabled = false;
            Maintimer.Enabled = false;

            if (client != null)
            {
                reader.Close();
                writer.Close();
                stream.Close();
                client.Close();
                client = null;
            }

            labelOn.Text = "Нет подключения";
            labelOn.FlatStyle = FlatStyle.Standard;
            labelOn.BackColor = Color.FromArgb(64, 64, 64);
            labelOn.ForeColor = Color.FromArgb(255, 255, 192);

            textBox2.Text = "192.168.1.68";
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.Black;

            On.Text = "Подключить";
            //On.FlatStyle = FlatStyle.Standard;
            On.BackColor = Color.LightGray;
            On.ForeColor = Color.Black;
            On.Enabled = true;

            textBox1.Text = "2000";
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;

            Off.Text = "Откдючить";
            //Off.FlatStyle = FlatStyle.Standard;
            Off.BackColor = Color.LightGray;
            Off.ForeColor = Color.Black;
            Off.Enabled = true;

            labelOn.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            label16.ForeColor = Color.Black;
            label17.ForeColor = Color.Black;
            label18.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;

            radialGauge1.ScaleLabelColor = Color.Black;
            radialGauge2.ScaleLabelColor = Color.Black;
            radialGauge3.ScaleLabelColor = Color.Black;

            radialGauge1.NeedleCollection[0].Value = 0;
            radialGauge1.Value = 0;
            radialGauge2.NeedleCollection[0].Value = 0;
            radialGauge2.Value = 0;
            radialGauge3.NeedleCollection[0].Value = 0;
            radialGauge3.Value = 0;

            radialGauge1.BackgroundGradientStartColor = Color.LightGray;
            radialGauge2.BackgroundGradientStartColor = Color.LightGray;
            radialGauge3.BackgroundGradientStartColor = Color.LightGray;

            chart1.BackColor = Color.LightGray;
          
            pictureBoxOnHu.Image = (Image)bmpDim;
            pictureBoxOffHu.Image = (Image)bmpDim;
            pictureBoxOnTe.Image = (Image)bmpDim;
            pictureBoxOffTe.Image = (Image)bmpDim;
            pictureBoxOnIl.Image = (Image)bmpDim;
            pictureBoxOffIl.Image = (Image)bmpDim;

            groupBox1.ForeColor = Color.Black;
            groupBox2.ForeColor = Color.Black;
            groupBox3.ForeColor = Color.Black;
            groupBox4.ForeColor = Color.Black;
            groupBox6.ForeColor = Color.Black;

            chart1.BackColor = Color.Gray;
            chart1.ChartAreas[0].BackColor = Color.Gray;
            chart1.Legends[0].BackColor = Color.Gray;
        }

        private void RxTxTimer_Tick(object sender, EventArgs e)
        {
            RxTxTimer.Enabled = false;
            On.Text = "Подключение...";
            try
            {
                if (client == null)
                {
                    client = new TcpClient(Address, PORT);
                    stream = client.GetStream();
                    writer = new StreamWriter(stream); //BinaryWriter StreamWriter
                    reader = new StreamReader(stream);

                    labelOn.BackColor = Color.FromArgb(64, 64, 64);
                    labelOn.ForeColor = Color.FromArgb(255, 255, 192);
                    labelOn.Text = "Подключено";
                    
                    On.FlatStyle = FlatStyle.Standard;
                    On.BackColor = Color.LightGreen;
                    On.Text = "Работа";
                    On.Enabled = false;
                }

                writer.Write(Convert.ToString(hu_min) + " " + Convert.ToString(hu_max) + 
                    " " + Convert.ToString(te_min) + " " + Convert.ToString(te_max) + " " +
                    Convert.ToString(il_min) +  " " + Convert.ToString(il_max));
                writer.Flush();

                Message = "";
                Message = reader.ReadLine();
                char separator = ';';
                string[] val = Message.Split(separator);
                HU = Convert.ToInt32(val[0]);
                TE = Convert.ToInt32(val[1]);
                IL = Convert.ToInt32(val[2]);

                reader.Close();
                writer.Close();
                stream.Close();
                client.Close();
                client = null;

            }
            catch (Exception ex)
            {
                RxTxTimer.Enabled = false;
                client = null;
                On.Text = "Повторить";
                On.BackColor = Color.OrangeRed;
                On.Enabled = true;
                MessageBox.Show(ex.Message);
            }
            RxTxTimer.Enabled = true;
            DrawTimer.Enabled = true;
        }

        int x = 0;
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            radialGauge1.NeedleCollection[0].Value = HU;
            radialGauge1.Value = HU;
            radialGauge2.NeedleCollection[0].Value = TE;
            radialGauge2.Value = TE;
            radialGauge3.NeedleCollection[0].Value = IL;
            radialGauge3.Value = IL;

            radialGauge1.Ranges[0].StartValue = 0;
            radialGauge1.Ranges[0].EndValue = hu_min;
            radialGauge1.Ranges[1].StartValue = hu_min;
            radialGauge1.Ranges[1].EndValue = hu_max;
            radialGauge1.Ranges[2].StartValue = hu_max;

            radialGauge2.Ranges[0].StartValue = 0;
            radialGauge2.Ranges[0].EndValue = te_min;
            radialGauge2.Ranges[1].StartValue = te_min;
            radialGauge2.Ranges[1].EndValue = te_max;
            radialGauge2.Ranges[2].StartValue = te_max;

            radialGauge3.Ranges[0].StartValue = 10;  //Внимание
            radialGauge3.Ranges[0].EndValue = il_min;
            radialGauge3.Ranges[1].StartValue = il_min;
            radialGauge3.Ranges[1].EndValue = il_max;
            radialGauge3.Ranges[2].StartValue = il_max;

            if (chart1.Series[0].Points.Count > 20)
            {
                chart1.Series[0].Points.RemoveAt(0);
                chart1.Update();
            }
            chart1.Series[0].Points.AddXY(x, HU);

            if (chart1.Series[1].Points.Count > 20)
            {
                chart1.Series[1].Points.RemoveAt(0);
                chart1.Update();
            }
            chart1.Series[1].Points.AddXY(x, TE);

            if (chart1.Series[2].Points.Count > 20)
            {
                chart1.Series[2].Points.RemoveAt(0);
                chart1.Update();
            }
            chart1.Series[2].Points.AddXY(x++, IL);
            //Вода
            if (radialGauge1.NeedleCollection[0].Value <= radialGauge1.Ranges[0].EndValue) //Включить воду
            {
                pictureBoxOnHu.Image = (Image)bmpOn; 
            }
            else
            {
                pictureBoxOnHu.Image = (Image)bmpOff;
            }
               
            if (radialGauge1.NeedleCollection[0].Value >= radialGauge1.Ranges[2].StartValue) //Выключить воду
            {
                pictureBoxOffHu.Image = (Image)bmpOn;
            }
            else
            {
                pictureBoxOffHu.Image = (Image)bmpOff;
            }
            //Температура
            if (radialGauge2.NeedleCollection[0].Value <= radialGauge2.Ranges[0].EndValue) //Включить подогрев
            {
                pictureBoxOnTe.Image = (Image)bmpOn;
            }
            else
                pictureBoxOnTe.Image = (Image)bmpOff;

            if (radialGauge2.NeedleCollection[0].Value >= radialGauge2.Ranges[2].StartValue) //Включить охлаждение
            {
                pictureBoxOffTe.Image = (Image)bmpOn;
            }
            else
                pictureBoxOffTe.Image = (Image)bmpOff;
            //Освещение
            if (radialGauge3.NeedleCollection[0].Value <= radialGauge3.Ranges[0].EndValue && //Включить освещение
                 radialGauge3.NeedleCollection[0].Value >= radialGauge3.Ranges[0].StartValue)
            {
                pictureBoxOnIl.Image = (Image)bmpOn;
            }
            else
                pictureBoxOnIl.Image = (Image)bmpOff;

            if (radialGauge3.NeedleCollection[0].Value >= radialGauge3.Ranges[2].StartValue) //Включить затемнение
            {
                pictureBoxOffIl.Image = (Image)bmpOn;
            }
            else
                pictureBoxOffIl.Image = (Image)bmpOff;

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("Config.txt"))
                {
                    String line = sr.ReadToEnd();
                    char separator = '\n';
                    string[] val = line.Split(separator);
                    hu_min = Convert.ToInt32(val[1]);
                    hu_max = Convert.ToInt32(val[3]);
                    te_min = Convert.ToInt32(val[5]);
                    te_max = Convert.ToInt32(val[7]);
                    il_min = Convert.ToInt32(val[9]);
                    il_max = Convert.ToInt32(val[11]);

                    labelOn.Text = "Нет подключения";
                    labelOn.FlatStyle = FlatStyle.Popup;
                    labelOn.BackColor = Color.FromArgb(64, 64, 64);
                    labelOn.ForeColor = Color.FromArgb(255, 255, 192);

                    On.Text = "Подключить";
                    On.ForeColor = Color.Black;
                    On.Enabled = true;

                    labelOn.ForeColor = Color.Black;
                    label1.ForeColor = Color.Black;
                    label13.ForeColor = Color.Black;
                    label14.ForeColor = Color.Black;
                    label15.ForeColor = Color.Black;
                    label16.ForeColor = Color.Black;
                    label17.ForeColor = Color.Black;
                    label18.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    label5.ForeColor = Color.Black;

                    pictureBoxOnHu.Image = (Image)bmpDim;
                    pictureBoxOffHu.Image = (Image)bmpDim;
                    pictureBoxOnTe.Image = (Image)bmpDim;
                    pictureBoxOffTe.Image = (Image)bmpDim;
                    pictureBoxOnIl.Image = (Image)bmpDim;
                    pictureBoxOffIl.Image = (Image)bmpDim;

                    groupBox1.ForeColor = Color.Black;
                    groupBox2.ForeColor = Color.Black;
                    groupBox3.ForeColor = Color.Black;

                    radialGauge1.ScaleLabelColor = Color.Black;
                    radialGauge2.ScaleLabelColor = Color.Black;
                    radialGauge3.ScaleLabelColor = Color.Black;

                    chart1.BackColor = Color.Gray;
                    chart1.ChartAreas[0].BackColor = Color.Gray;
                    chart1.Legends[0].BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RxTxTimer.Enabled = false;
            RxTxTimer.Interval = 1000;
            DrawTimer.Enabled = false;
            DrawTimer.Interval = 1000;
            Maintimer.Enabled = false;

            radialGauge1.BackgroundGradientStartColor = Color.LightGray;
            radialGauge2.BackgroundGradientStartColor = Color.LightGray;
            radialGauge3.BackgroundGradientStartColor = Color.LightGray;
            chart1.BackColor = Color.LightGray;

            radialGauge1.EnableCustomNeedles = false;
            radialGauge2.EnableCustomNeedles = false;
            radialGauge3.EnableCustomNeedles = false;

            radialGauge1.Ranges[0].StartValue = 0;
            radialGauge1.Ranges[0].EndValue = hu_min;
            radialGauge1.Ranges[1].StartValue = hu_min;
            radialGauge1.Ranges[1].EndValue = hu_max;
            radialGauge1.Ranges[2].StartValue = hu_max;

            radialGauge2.Ranges[0].StartValue = 0;
            radialGauge2.Ranges[0].EndValue = te_min;
            radialGauge2.Ranges[1].StartValue = te_min;
            radialGauge2.Ranges[1].EndValue = te_max;
            radialGauge2.Ranges[2].StartValue = te_max;

            radialGauge3.Ranges[0].StartValue = 10;  //Внимание
            radialGauge3.Ranges[0].EndValue = il_min;
            radialGauge3.Ranges[1].StartValue = il_min;
            radialGauge3.Ranges[1].EndValue = il_max;
            radialGauge3.Ranges[2].StartValue = il_max;
            
        }

        private void редактироватьКонфигурациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditConfig Edconfig = new EditConfig();
            Edconfig.Show();
        }


        //private void загрузитьКонфигурациюToolStripMenuItem_Click(object sender, EventArgs e)
        public async void загрузитьКонфигурациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //using (StreamReader sr = new StreamReader("Config.txt"))
                using (StreamReader reader = File.OpenText("Config.txt"))
                {
                    //String line = sr.ReadToEnd(); sr.ReadToEndAsync
                    String line = await reader.ReadToEndAsync();
                    char separator = '\n';
                    string[] val = line.Split(separator);
                    hu_min = Convert.ToInt32(val[1]);
                    hu_max = Convert.ToInt32(val[3]);
                    te_min = Convert.ToInt32(val[5]);
                    te_max = Convert.ToInt32(val[7]);
                    il_min = Convert.ToInt32(val[9]);
                    il_max = Convert.ToInt32(val[11]);

                    radialGauge1.Ranges[0].StartValue = 0;
                    radialGauge1.Ranges[0].EndValue = hu_min;
                    radialGauge1.Ranges[1].StartValue = hu_min;
                    radialGauge1.Ranges[1].EndValue = hu_max;
                    radialGauge1.Ranges[2].StartValue = hu_max;

                    radialGauge2.Ranges[0].StartValue = 0;
                    radialGauge2.Ranges[0].EndValue = te_min;
                    radialGauge2.Ranges[1].StartValue = te_min;
                    radialGauge2.Ranges[1].EndValue = te_max;
                    radialGauge2.Ranges[2].StartValue = te_max;

                    radialGauge3.Ranges[0].StartValue = 10;  //Внимание
                    radialGauge3.Ranges[0].EndValue = il_min;
                    radialGauge3.Ranges[1].StartValue = il_min;
                    radialGauge3.Ranges[1].EndValue = il_max;
                    radialGauge3.Ranges[2].StartValue = il_max;
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void сохранитьКонфигурациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/ru-ru/dotnet/api/system.io.file.createtext?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DRU-RU%26k%3Dk(System.IO.File.CreateText);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.8);k(DevLang-csharp)%26rd%3Dtrue%26f%3D255%26MSPPError%3D-2147217396&view=netframework-4.8
            //https://docs.microsoft.com/ru-ru/dotnet/api/system.io.streamwriter.writeasync?view=netframework-4.8
            using (StreamWriter outputFile = File.CreateText("Config.txt"))
            {
                await outputFile.WriteAsync(
                    "hu_min Минимальная точка влажности"+'\n'+Convert.ToString(hu_min)+'\n'+
                    "hu_max Максимальная точка влажности"+'\n'+Convert.ToString(hu_max)+'\n'+
                    "te_min Минимальная точка температуры"+'\n'+Convert.ToString(te_min)+'\n'+
                    "te_max Максимальная точка температуры"+'\n'+Convert.ToString(te_max)+'\n'+
                    "il_min Минимальная точка освещения"+'\n'+Convert.ToString(il_min)+'\n'+
                    "il_max Максимальная точка освещения"+'\n'+Convert.ToString(il_max)
                    );
            }
        }

        private void checkBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnable.Checked == true)
            {
                trackBarM1.Enabled = true;
                trackBarM2.Enabled = true;
                
                if (FlagSwitch1 == 1)
                {
                    radialGauge1.EnableCustomNeedles = true;
                    FlagChecked1 = true;
                }
                else
                if (FlagSwitch2 == 1)
                {
                    radialGauge2.EnableCustomNeedles = true;
                    FlagChecked2 = true;
                }
                    
                else
                if (FlagSwitch3 == 1)
                {
                    radialGauge3.EnableCustomNeedles = true;
                    FlagChecked3 = true;
                    
                }
            }
            else
            if (checkBoxEnable.Checked == false)
            {
                trackBarM1.Enabled = false;
                trackBarM2.Enabled = false;
                
                if (FlagSwitch1 == 1)
                {
                    radialGauge1.EnableCustomNeedles = false;
                    FlagChecked1 = false;
                }
                else
                if (FlagSwitch2 == 1)
                {
                    radialGauge2.EnableCustomNeedles = false;
                    FlagChecked2 = false;
                }

                else
                if (FlagSwitch3 == 1)
                {
                    radialGauge3.EnableCustomNeedles = false;
                    FlagChecked3 = false;
                    
                }
            }
        }

        private void radioButtonHu_Click(object sender, EventArgs e)
        {
            FlagSwitch1 = 1;
            FlagSwitch2 = 0;
            FlagSwitch3 = 0;
            groupBox1.ForeColor = Color.FromArgb(0, 255, 0);
            groupBox2.ForeColor = Color.FromArgb(255, 255, 192);
            groupBox3.ForeColor = Color.FromArgb(255, 255, 192);
            trackBarNight.Enabled = false;
            if (FlagChecked1 == true)
            {
                checkBoxEnable.Checked = true;
                radialGauge1.EnableCustomNeedles = true;
                
            }
            else
                checkBoxEnable.Checked = false;
        
        }

        private void radioButtonTe_Click(object sender, EventArgs e)
        {
            FlagSwitch1 = 0;
            FlagSwitch2 = 1;
            FlagSwitch3 = 0;
            trackBarNight.Enabled = false;
            groupBox1.ForeColor = Color.FromArgb(255, 255, 192);
            groupBox2.ForeColor = Color.FromArgb(0, 255, 0);
            groupBox3.ForeColor = Color.FromArgb(255, 255, 192);
            if (FlagChecked2 == true)
            {
                checkBoxEnable.Checked = true;
                radialGauge2.EnableCustomNeedles = true;
                
            }
            else
                checkBoxEnable.Checked = false;
            
        }

        private void radioButtonIl_Click(object sender, EventArgs e)
        {
            FlagSwitch1 = 0;
            FlagSwitch2 = 0;
            FlagSwitch3 = 1;
            groupBox1.ForeColor = Color.FromArgb(255, 255, 192);
            groupBox2.ForeColor = Color.FromArgb(255, 255, 192);
            groupBox3.ForeColor = Color.FromArgb(0, 255, 0);
            trackBarNight.Enabled = true;
            if (FlagChecked3 == true)
            {
                checkBoxEnable.Checked = true;
                radialGauge3.EnableCustomNeedles = true;
                
            }
            else
                checkBoxEnable.Checked = false;
            
        }

        private void radioButtonHu_CheckedChanged(object sender, EventArgs e) //радиокнопка "Влажность" включена
        {

        }

        private void radioButtonTe_CheckedChanged(object sender, EventArgs e) //радиокнопка "Температура" включена
        {

        }

        private void radioButtonIl_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Maintimer_Tick(object sender, EventArgs e)
        {
            /////////////////////////////////////////
            if (radioButtonHu.Checked)
            {
                trackBarMin.Value = Convert.ToInt32(radialGauge1.Ranges[0].EndValue);
                labelVarMin.Text = Convert.ToString(trackBarMin.Value);

                trackBarMax.Value = Convert.ToInt32(radialGauge1.Ranges[1].EndValue);
                labelVarMax.Text = Convert.ToString(trackBarMax.Value);

                trackBarM1.Value = Convert.ToInt32(radialGauge1.NeedleCollection[1].Value);
                labelVarM1.Text = Convert.ToString(trackBarM1.Value);

                trackBarM2.Value = Convert.ToInt32(radialGauge1.NeedleCollection[2].Value);
                labelVarM2.Text = Convert.ToString(trackBarM2.Value);
            }
            else
            if (radioButtonTe.Checked)
            {
                trackBarNight.Enabled = false;
                trackBarMin.Value = Convert.ToInt32(radialGauge2.Ranges[0].EndValue);
                labelVarMin.Text = Convert.ToString(trackBarMin.Value);

                trackBarMax.Value = Convert.ToInt32(radialGauge2.Ranges[1].EndValue);
                labelVarMax.Text = Convert.ToString(trackBarMax.Value);

                trackBarM1.Value = Convert.ToInt32(radialGauge2.NeedleCollection[1].Value);
                labelVarM1.Text = Convert.ToString(trackBarM1.Value);

                trackBarM2.Value = Convert.ToInt32(radialGauge2.NeedleCollection[2].Value);
                labelVarM2.Text = Convert.ToString(trackBarM2.Value);
            }
            else
            if (radioButtonIl.Checked)
            {
                trackBarNight.Enabled = true;
                trackBarMin.Value = Convert.ToInt32(radialGauge3.Ranges[0].EndValue);
                labelVarMin.Text = Convert.ToString(trackBarMin.Value);

                trackBarMax.Value = Convert.ToInt32(radialGauge3.Ranges[1].EndValue);
                labelVarMax.Text = Convert.ToString(trackBarMax.Value);

                trackBarM1.Value = Convert.ToInt32(radialGauge3.NeedleCollection[1].Value);
                labelVarM1.Text = Convert.ToString(trackBarM1.Value);

                trackBarM2.Value = Convert.ToInt32(radialGauge3.NeedleCollection[2].Value);
                labelVarM2.Text = Convert.ToString(trackBarM2.Value);

                trackBarNight.Value = 10; //Convert.ToInt32(Form1.radialGaugeIl.NeedleCollection[1].Value);
                labelNight.Text = Convert.ToString(trackBarNight.Value);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void trackBarMin_Scroll(object sender, EventArgs e)
        {
            if(FlagSwitch1 == 1)
            {
                labelVarMin.Text = Convert.ToString(trackBarMin.Value);
                radialGauge1.Ranges[0].EndValue = trackBarMin.Value;
                radialGauge1.Ranges[1].StartValue = radialGauge1.Ranges[0].EndValue;
            }
            else
            if(FlagSwitch2 == 1)
            {
                labelVarMin.Text = Convert.ToString(trackBarMin.Value);
                radialGauge2.Ranges[0].EndValue = trackBarMin.Value;
                radialGauge2.Ranges[1].StartValue = radialGauge2.Ranges[0].EndValue;
            }
            else
            if(FlagSwitch3 == 1)
            {
                labelVarMin.Text = Convert.ToString(trackBarMin.Value);
                radialGauge3.Ranges[0].EndValue = trackBarMin.Value;
                radialGauge3.Ranges[1].StartValue = radialGauge3.Ranges[0].EndValue;
            }
            
        }

        private void trackBarMax_Scroll(object sender, EventArgs e)
        {
            if(FlagSwitch1 == 1)
            {
                labelVarMax.Text = Convert.ToString(trackBarMax.Value);
                radialGauge1.Ranges[1].EndValue = trackBarMax.Value;
                radialGauge1.Ranges[2].StartValue = radialGauge1.Ranges[1].EndValue;
            }
            else
            if(FlagSwitch2 == 1)
            {
                labelVarMax.Text = Convert.ToString(trackBarMax.Value);
                radialGauge2.Ranges[1].EndValue = trackBarMax.Value;
                radialGauge2.Ranges[2].StartValue = radialGauge2.Ranges[1].EndValue;
            }
            else
            if (FlagSwitch3 == 1)
            {
                labelVarMax.Text = Convert.ToString(trackBarMax.Value);
                radialGauge3.Ranges[1].EndValue = trackBarMax.Value;
                radialGauge3.Ranges[2].StartValue = radialGauge3.Ranges[1].EndValue;
            }

        }

        private void trackBarNight_Scroll(object sender, EventArgs e)
        {
            labelNight.Text = Convert.ToString(trackBarNight.Value);
            radialGauge3.Ranges[0].StartValue = trackBarNight.Value;
        }

        private void trackBarM1_Scroll(object sender, EventArgs e)
        {
            if(FlagSwitch1 == 1)
            {
                labelVarM1.Text = Convert.ToString(trackBarM1.Value);
                radialGauge1.NeedleCollection[1].Value = trackBarM1.Value;
            }
            else
            if (FlagSwitch2 == 1)
            {
                labelVarM1.Text = Convert.ToString(trackBarM1.Value);
                radialGauge2.NeedleCollection[1].Value = trackBarM1.Value;
            }
            else
            if (FlagSwitch3 == 1)
            {
                labelVarM1.Text = Convert.ToString(trackBarM1.Value);
                radialGauge3.NeedleCollection[1].Value = trackBarM1.Value;
            }

        }

        private void trackBarM2_Scroll(object sender, EventArgs e)
        {
            if(FlagSwitch1 == 1)
            {
                labelVarM2.Text = Convert.ToString(trackBarM2.Value);
                radialGauge1.NeedleCollection[2].Value = trackBarM2.Value;
            }
            else
            if (FlagSwitch2 == 1)
            {
                labelVarM2.Text = Convert.ToString(trackBarM2.Value);
                radialGauge2.NeedleCollection[2].Value = trackBarM2.Value;
            }
            else
            if (FlagSwitch3 == 1)
            {
                labelVarM2.Text = Convert.ToString(trackBarM2.Value);
                radialGauge3.NeedleCollection[2].Value = trackBarM2.Value;
            }

        }

        private void checkBoxWrite_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
