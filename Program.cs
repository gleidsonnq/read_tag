using System;
using System.Device.Gpio;
using System.Threading;
using System.IO.Ports;
using System.Text;

//bool is_usb0 = false;
//string usb_serial = "";
string DebugHex="";
SerialPort usb1 = new SerialPort(@"/dev/ttyUSB1");
usb1.Encoding = Encoding.UTF8;
usb1.BaudRate = 9600;
usb1.Handshake = Handshake.None;
usb1.ReadTimeout = 1;
usb1.Open();
SerialPort usb0 = new SerialPort(@"/dev/ttyUSB0");
usb0.Encoding = Encoding.UTF8;
usb0.BaudRate = 9600;
usb0.Handshake = Handshake.None;
usb0.ReadTimeout = 1;
usb0.Open();
SerialPort uart = new SerialPort(@"/dev/ttyS0");
uart.Encoding = Encoding.UTF8;
uart.BaudRate = 9600;
uart.Handshake = Handshake.None;
uart.ReadTimeout = 1;
uart.Open();



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
        int valor = usb0.ReadByte();
        int valor1 = usb1.ReadByte();
        int valor2 = uart.ReadByte();
        if(valor == '\x02'){
            for(int counter=0;counter<12;counter++){
                valor = usb0.ReadByte();
                DebugHex = DebugHex + valor.ToString() + " ";
            }
        }
        if(valor1 == '\x02'){
            for(int counter=0;counter<12;counter++){
                valor1 = usb1.ReadByte();
                DebugHex = DebugHex + valor1.ToString() + " ";
            }
        }
        if(valor2 == '\x02'){
            for(int counter=0;counter<12;counter++){
                valor2 = uart.ReadByte();
                DebugHex = DebugHex + valor2.ToString() + " ";
            }
        }
    }
    catch(TimeoutException){

    }



    // See https://aka.ms/new-console-template for more information
    Console.WriteLine(DebugHex);
    

}
    
