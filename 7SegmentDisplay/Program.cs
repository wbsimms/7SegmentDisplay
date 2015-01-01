using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;
using Gadgeteer.SocketInterfaces;

namespace _7SegmentDisplay
{
    public partial class Program
    {
        private GT.SocketInterfaces.DigitalOutput nine, eight, seven, six, five, four, three;
        private ArrayList pins = new ArrayList();

        void ProgramStarted()
        {
            Debug.Print("Program Started");
            button.ButtonPressed += button_ButtonPressed;
            nine = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Nine, false);
            eight = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Eight, false);
            seven = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Seven, false);
            six = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Six, false);
            five = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Five, false);
            four = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Four, false);
            three = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Three, false);
            pins.Add(three);
            pins.Add(four);
            pins.Add(five);
            pins.Add(six);
            pins.Add(seven);
            pins.Add(eight);
            pins.Add(nine);
        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            for (int i = 0; i <= 9; i++)
            {
                ClearPins();
                int[] pinsToLight = GetNumberPins(i);
                foreach (int p in pinsToLight)
                {
                    ((DigitalOutput)pins[p]).Write(true);
                }
                Thread.Sleep(1000);
            }
        }

        public void ClearPins()
        {
            foreach (DigitalOutput o in pins)
            {
                o.Write(false);
            }
        }

        public int[] GetNumberPins(int number)
        {
            switch (number)
            {
                case 0:
                    return new int[] { 6,2,1,0,3,4 };
                case 1:
                    return new int[] {1,0};
                case 2:
                    return new int[] { 2,1,5,4,3 };
                case 3:
                    return new int[] { 2,1,5,0,3 };
                case 4:
                    return new int[] { 6,1,5,0};
                case 5:
                    return new int[] { 2,6,5,0,3 };
                case 6:
                    return new int[] { 6,5,4,3,0 };
                case 7:
                    return new int[] { 2,1,0 };
                case 8:
                    return new int[] { 0,1,2,3,4,5,6 };
                case 9:
                    return new int[] { 5,6,2,1,0 };
                default:
                    return new int[0];
            }
        }
    }
}
