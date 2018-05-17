using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//namespace untuk zedGrpah
using ZedGraph;
//namespace untuk class serial
using System.IO.Ports;
//namespace untuk melihat setting global komputer
using System.Globalization;
//using ZedGraph.PointPairList;
namespace Monitoring_Suhu
{
    public partial class Form1 : Form
    {
        SerialPort arduino = new SerialPort("COM4", 9600);
        double waktuStart = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
             try
            {
                btn_start.Enabled = false;
                btn_stop.Enabled = true;
                arduino.ReadTimeout = 1000;
                arduino.WriteTimeout = 1000;
                detak.Enabled = true;
                //mulai detak
                detak.Start();
            }
            catch (Exception gagal)
            {
                //error handling
                //MessageBox.Show(gagal.ToString());
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            try
            {
                //nyalakan kembali tombol start
                btn_start.Enabled = true;
                //matikan tombol stop
                btn_stop.Enabled = false;
                //stop detak
                detak.Stop();
                //matikan detak
                detak.Enabled = false;
                //jika komunikasi masih terbuka, tutup komunikasi
                if (arduino.IsOpen)
                {
                    arduino.Close();
                }
            }
            catch (Exception gagal)
            {
                //error handling
                //MessageBox.Show(gagal.ToString());
            }
        
        }

        private void detak_Tick(object sender, EventArgs e)
        {
            try
            {
                //Mulai komunikasi dengan arduino
                arduino.Open();

                //get item kurva pertama pada grafik
                LineItem kurvaSuhu = zedGraphSuhu.GraphPane.CurveList[0] as LineItem;

                //get PointPairList
                IPointListEdit listSuhu = kurvaSuhu.Points as IPointListEdit;

                //waktu yang terlewati
                double waktu = (Environment.TickCount - waktuStart) / 1000.0;

                //baca data suhu yang dikirim arduino,
                //konversi data tersebut (string) ke double,
                //dan tambahkan ke listSuhu
                float dataSuhu = float.Parse(arduino.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
                listSuhu.Add(waktu, Convert.ToDouble(dataSuhu));

                //Tutup komunikasi dengan arduino
                arduino.Close();

                //Buat scale X tetap rolling dalam interval 30 detik, dengan satu
                //langkah besar antara nilai X maksimal dan akhir dari axis
                Scale xScale = zedGraphSuhu.GraphPane.XAxis.Scale;
                if (waktu > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = waktu + xScale.MajorStep;
                    xScale.Min = xScale.Max - 30.0;
                }

                // Pastikan Y axis di scale ulang untuk mengakomodir data aktual
                zedGraphSuhu.AxisChange();

                // Redraw paksa
                zedGraphSuhu.Invalidate();

            }
            catch (Exception gagal)
            {
                //error handling
                //tutup komunikasi dengan arduino jika masih terhubung
                if (arduino.IsOpen)
                {
                    arduino.Close();
                }
                //MessageBox.Show(gagal.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //catat waktu pertama sebagai referensi
                waktuStart = Environment.TickCount;

                //Inisialisasi ZedGraph
                GraphPane grafikSuhu = zedGraphSuhu.GraphPane;
                grafikSuhu.Title.Text = "Grafik Suhu";
                grafikSuhu.XAxis.Title.Text = "Waktu (Detik)";
                grafikSuhu.YAxis.Title.Text = "Suhu (Celcius)";

                //Simpan 120 point. Pada 500 ms sampel rate.
                //RollingPointPairList adalah class penyimpanan yang efisien 
                //dengan tetap merolling kumpulan point data tanpa perlu
                //men-shift nilai data apapun
                RollingPointPairList listSuhu = new RollingPointPairList(120);

                //Inisialisasi kurva
                LineItem kurvaSuhu = grafikSuhu.AddCurve("Suhu", listSuhu, Color.Red, SymbolType.None);
                
            }
            catch (Exception gagal)
            {
                //error handling
                //MessageBox.Show(gagal.ToString());
            }
        }
        
    }
}
