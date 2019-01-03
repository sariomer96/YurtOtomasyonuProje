using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;

namespace YurtOtomasyonu
{
    public class Kart
    {
        SerialPort port;
        public Kart()
        {


       
        
        
       port = new SerialPort("COM3",9600, Parity.None,8, StopBits.One);
        port.Open();
            port.Write("ver"); // arduinodan kart verisi ister
            port.Close();

            port.DataReceived += new SerialDataReceivedEventHandler(ReceivedSerialHandler);
        port.Open();
        }
        private void ReceivedSerialHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            
             string a = "";
               a = sp.ReadExisting();
            

            port.Close();
        }



    }

}