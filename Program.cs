using System;
using System.Device.Gpio;
using System.Threading;
using System.IO.Ports;
using System.Text;

//bool is_usb0 = false;
//string usb_serial = "";
SerialPort usb1 = new SerialPort(@"/dev/ttyUSB0");
usb1.Encoding = Encoding.UTF8;
usb1.BaudRate = 9600;
usb1.Handshake = Handshake.None;
usb1.ReadTimeout = 1;
usb1.Open();

while(true){
    
    try{
        
        int usb_read_byte = usb1.ReadByte();
        int[] DebugW = new int[10];
        if(usb_read_byte == 0x02){
            for(int counter=0;counter<10;counter++){
                usb_read_byte = usb1.ReadByte();
                if(usb_read_byte<=57){
                    DebugW[counter] = usb_read_byte - 48;
                }
                else{
                    DebugW[counter] = usb_read_byte - 55;
                }
                
            }
            

            int facility = DebugW[4]*16 + DebugW[5];
            
            int cardCode = DebugW[6]*16*16*16 + DebugW[7]*16*16 + DebugW[8]*16 + DebugW[9];
            
            string dadosTagSaida = facility.ToString() + cardCode.ToString();
            Console.WriteLine(dadosTagSaida);
            
        }
    }
    catch(TimeoutException){
    } 

}
    
