using System;
using System.Device.Gpio;
using System.Threading;
using System.IO.Ports;
using System.Text;

//bool is_usb0 = false;
//string usb_serial = "";
string DebugHex="";
//SerialPort sp = new SerialPort(@"/dev/ttyUSB1");
SerialPort sp = new SerialPort(@"/dev/ttyUSB0");
//SerialPort sp = new SerialPort(@"/dev/ttyS0");
sp.Encoding = Encoding.UTF8;
sp.BaudRate = 9600;
sp.Handshake = Handshake.None;
sp.ReadTimeout = 1;
sp.Open();

while(true){
    
    /*
    try{
        if(is_usb0){
            is_usb0 = false;
            SerialPort sp = new SerialPort(@"/dev/ttyUSB1");
            sp.Encoding = Encoding.UTF8;
            sp.BaudRate = 9600;
            sp.Handshake = Handshake.None;
            sp.ReadTimeout = 1000;
            sp.WriteTimeout = 1000;
            sp.Open();
        }
        else{
            is_usb0 = true;
            SerialPort sp = new SerialPort(@"/dev/ttyUSB0");
            sp.Encoding = Encoding.UTF8;
            sp.BaudRate = 9600;
            sp.Handshake = Handshake.None;
            sp.ReadTimeout = 1000;
            sp.WriteTimeout = 1000;
            sp.Open();
        }
    }
    catch(TimeoutException){

    }
    */

    try{
        int valor = sp.ReadByte();
        if(valor == '\x02'){
            for(int counter=0;counter<12;counter++){
                valor = sp.ReadByte();
                DebugHex = DebugHex + valor.ToString() + " ";
            }
        }
    }
    catch(TimeoutException){

    }



    // See https://aka.ms/new-console-template for more information
    Console.WriteLine(DebugHex);
    

}
    
