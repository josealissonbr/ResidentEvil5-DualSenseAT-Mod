using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using System.Threading;
using Memory;

namespace ETS2_DualSenseAT_Mod
{
    public partial class Form1 : Form
    {

        static UdpClient client;
        static IPEndPoint endPoint;
        static bool Connect()
        {
           
                client = new UdpClient();
                var portNumber = File.ReadAllText(@"C:\Temp\DualSenseX\DualSenseX_PortNumber.txt");
                endPoint = new IPEndPoint(Triggers.localhost, Convert.ToInt32(portNumber));
                return true;
            
        }

        static void Send(Packet data)
        {
            var RequestData = Encoding.ASCII.GetBytes(Triggers.PacketToJson(data));
            client.Send(RequestData, RequestData.Length, endPoint);
        }

        public Form1()
        {
            InitializeComponent();

            statusLbl.Text = "Status: Ready!";
        }

        private int processID;
        private bool processOpen = false;
        private Mem memLib = new Mem();

        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("re5dx9");
            if (pname.Length == 0)
            {
               MessageBox.Show("Resident Evil 5 is not running, please open game first!", "DualSense AT Mod");
                Application.Exit();
            }

            //if (!File.Exists(Application.StartupPath + "\\DualSenseX_CommandLineArgs.bat"))
            //{
            //    MessageBox.Show("DualSenseX Command Line not found.", "DualSense AT Mod");
            //    Application.Exit();
            //}

            if (!Connect())
            {
                MessageBox.Show("Failed to connect to the DSX UDP Server ("+ Triggers.localhost, Convert.ToInt32(File.ReadAllText(@"C:\Temp\DualSenseX\DualSenseX_PortNumber.txt")) + ")");
            }

            findProcessID("re5dx9");

            timer1.Enabled = true;

           // processID = memLib.GetProcIdFromName("re5dx9"); //Gets process ID
           // processOpen = memLib.OpenProcess(processID);

            //Call static triggers values;
            //gameStaticTriggerValues();

        }

        private void findProcessID(string procname)
        {
            processID = memLib.GetProcIdFromName(procname); //Gets process ID
            processOpen = memLib.OpenProcess(processID);
            if (processID > 0)
            {
                ammoLbl.Invoke((MethodInvoker)delegate
                {
                   // ammoLbl.Text = processID.ToString();
                   //mmoLbl.ForeColor = Color.Lime;
                });
                ammoLbl.Invoke((MethodInvoker)delegate {
                   // gameProcessNameLabel.Text = procname + ".exe";
                   // gameProcessNameLabel.ForeColor = Color.Lime;
                });
            }
            else
            {
                ammoLbl.Invoke((MethodInvoker)delegate
                {
                   // procIdLabel.Text = "Process ID Not Found";
                  //  procIdLabel.ForeColor = Color.Red;
                });
                ammoLbl.Invoke((MethodInvoker)delegate {
                    //gameProcessNameLabel.Text = "N/A";
                    //gameProcessNameLabel.ForeColor = Color.Red;
                });
            }
            if (processOpen)
            {
                ammoLbl.Invoke((MethodInvoker)delegate
                {
                   // procOpenLabel.Text = "GAME FOUND!";
                   // procOpenLabel.ForeColor = Color.Lime;
                });
            }
            else
            {
                ammoLbl.Invoke((MethodInvoker)delegate
                {
                   // procOpenLabel.Text = "N/A";
                    //procOpenLabel.ForeColor = Color.Red;
                });
            }
        }

        private void RE5DynamicTriggers()
        {
            Packet p = new Packet();

            int controllerIndex = 0;
            p.instructions = new Instruction[4];

            int ammo = memLib.ReadInt("re5dx9.exe+00E243B4,38C,110");
            ammoLbl.Text = "iAmmo: " + ammo;
            // MyIni.Write("RightTrigger", "Resistance");
            //MyIni.Write("LeftTrigger", "Resistance");
            // MyIni.Write("ForceLeftTrigger", "(4)(2)");

            p.instructions[0].type = InstructionType.TriggerUpdate;
            p.instructions[0].parameters = new object[] { controllerIndex, Trigger.Left, TriggerMode.CustomTriggerValue, CustomTriggerValueMode.Rigid, 50, 76, 93, 125, 150, 174, 199 }; //(50)(76)(93)(125)(150)(174)(199)

            if (ammo > 0)
            {
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, Trigger.Right, TriggerMode.AutomaticGun, 0, 6, 4 };

              // p.instructions[1].type = InstructionType.TriggerUpdate;
               // p.instructions[1].parameters = new object[] { controllerIndex, Trigger.Left, TriggerMode.Resistance, 0, 3 }; //(50)(76)(93)(125)(150)(174)(199)



            }
            else
            {
                p.instructions[1].type = InstructionType.TriggerUpdate;
                p.instructions[1].parameters = new object[] { controllerIndex, Trigger.Right, TriggerMode.Normal };
            }

            // Controller.WriteController.SetRightTrigger(Controller.Types.Normal);

            Console.WriteLine("Ammo: " + ammo);
            ammoLbl.Text = "Ammo: " + ammo;

            Send(p);
        }

        static int iStep = 0;
        static int iMaxSteps = 0;
        private void InitializationEffect()
        {

            if (iMaxSteps < 5){
                Packet p = new Packet();

                int controllerIndex = 0;
                p.instructions = new Instruction[4];

                if (iStep == 0)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 237, 61, 7 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, true, false, false, false, false };
                    
                    iStep = 1;
                }
                else if (iStep == 1)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 252, 0, 0 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, true, false, false, false };
                    
                    iStep = 2;
                }
                else if (iStep == 2)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 148, 22, 0 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, false, true, false, false };
                    
                    iStep = 3;
                }
                else if (iStep == 3)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 237, 61, 7 };
                   
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, false, false, true, false };
                    

                    iStep = 4;
                }
                else if (iStep == 4)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 148, 22, 0 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, false, false, false, true };
                    

                    iStep = 0;
                    iMaxSteps += +1;
                }

                

                Send(p);
            }
            else
            {
                Packet p = new Packet();

                int controllerIndex = 0;
                p.instructions = new Instruction[4];

                p.instructions[0].type = InstructionType.RGBUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, 119, 3, 252 };

                // PLAYER LED 1-5 true/false state
                p.instructions[1].type = InstructionType.PlayerLED;
                p.instructions[1].parameters = new object[] { controllerIndex, true, false, false, false, false };

                Send(p);

                timer1.Enabled = false;

                //Start RE5 Tracker
                everytick.Enabled = true;
            }

        }

        private void gameStaticTriggerValues()
        {

            Packet p = new Packet();

            int controllerIndex = 0;
            p.instructions = new Instruction[4];

            p.instructions[0].type = InstructionType.TriggerUpdate;
            p.instructions[0].parameters = new object[] { controllerIndex, Trigger.Right, TriggerMode.AutomaticGun, 0, 6 ,4 };

            p.instructions[1].type = InstructionType.TriggerUpdate;
            p.instructions[1].parameters = new object[] { controllerIndex, Trigger.Left, TriggerMode.Resistance, 0, 3 }; //(50)(76)(93)(125)(150)(174)(199)



            Send(p);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Packet p = new Packet();

            int controllerIndex = 0;

            p.instructions = new Instruction[4];

            p.instructions[0].type = InstructionType.TriggerUpdate;
            p.instructions[0].parameters = new object[] { controllerIndex, Trigger.Right, TriggerMode.Normal };


            p.instructions[1].type = InstructionType.TriggerUpdate;
            p.instructions[1].parameters = new object[] { controllerIndex, Trigger.Left, TriggerMode.Normal };


            p.instructions[2].type = InstructionType.RGBUpdate;
            p.instructions[2].parameters = new object[] { controllerIndex, 66, 135, 245 };

            Send(p);
            statusLbl.Text = "Status: Closing";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InitializationEffect();
        }

        private void everytick_Tick(object sender, EventArgs e)
        {
            if (!processOpen)
                return;

            RE5DynamicTriggers();
        }
    }
}
