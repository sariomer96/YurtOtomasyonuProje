﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mOgrenci;

namespace YurtOtomasyonu
{
    public class Kart
    {
        Ogrenciler ogr = new Ogrenciler();
        DatabaseContext db = new DatabaseContext();
        SerialPort port;
        public void KartGetir()
        {
            port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write("ver"); // arduinodan kart verisi ister
            System.Threading.Thread.Sleep(300);
            string kart = " ";

            kart = port.ReadLine();
            port.Close();

            ogr.KartID = kart;

            

        }


    }
       



    }

