using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;
using System.Threading;

namespace AimboosterAuto
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);


        AutoItX3 au3 = new AutoItX3();

        public Form1()
        {
            InitializeComponent();
        }

        void Aimbot()
        {
            while (true)
            {
                if ( GetAsyncKeyState(Keys.P) < 0 )
                {

                    try
                    {
                        object pix = au3.PixelSearch(660, 409, 1262, 831, 0xFFDBC3);
                        
                        if (pix.ToString() != "1" )
                        {
                            object[] pixCoord = (object[])pix;
                            au3.MouseClick("LEFT", (int)pixCoord[0], (int)pixCoord[1],1,1);
                        }

                    }
                    catch (Exception e)
                    {
                       // MessageBox.Show("Error: " + e.Message,"Error");
                    }
                }
                Thread.Sleep(1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Thread AB = new Thread(Aimbot) { IsBackground = true };
            AB.Start();



        }
    }
}
