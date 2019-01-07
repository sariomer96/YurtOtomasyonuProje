using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Web;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mGirisCikis;

namespace YurtOtomasyonu.App_Start
{
    public class kartGetirr
    {
      
        static SerialPort port;
        
        static void Main(string[] args)
        {
           
            //port = new SerialPort("COM4", 9600);

            port = new SerialPort("COM3");

            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.Handshake = Handshake.None;
            port.RtsEnable = true;

            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            try
            {
                port.Open();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
        
        public static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
           
        string kartString = "";
            try
            {
                kartString = port.ReadExisting();
                Console.Write(kartString);
                Console.ReadLine();
                kartString = "onur";
                sqleYaz(kartString);

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }

            
            
        }

        public static void sqleYaz(String s)
        {
            DatabaseContext db = new DatabaseContext();
            GirisCikis giris = new GirisCikis();
            if (db.Ogrenciler.Any(x => x.KartID == s))
            {
                giris.YurtGiris = DateTime.Now;
                db.GirisCikislar.Add(giris);
            }

        }

    }
}