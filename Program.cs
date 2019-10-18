using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace sandbox
{
    class Program
    {
        static void Main(string[] args)
        {            
            System.Diagnostics.Process.Start("CMD.exe", "/C cls");
            Thread.Sleep(300);
            
            string number = "";
            Program p = new Program();

            do{
                Console.Write("Phone number to trace #: > ");
                number = Console.ReadLine();

                if (!(number.Length >= 10)) {
                    var errorColor = Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to enter a phone number", errorColor);
                    Console.ResetColor();
                }
            }while(number.Length < 10);
          
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.Write($"Triangulating phone: {number}\n");
            
            p.ProgressBar(20);          

            int[] numberArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Random _random = new Random();
            int randomNumber = _random.Next(9);

            System.Console.WriteLine("");

            // Console.WriteLine($"\nPhone #: {number}\n\nPhone Status: ON\nNumber of Tower used: {numberArr[randomNumber]}\nLatitude: 455\nLogitude: -12\n\nNumber Owner: xxxxx\nCurrent Address: Xxxxxxxxx");
            Console.Write($"\nPhone #: {number}\n");
            Console.Write($"\nPhone Status:");
            Console.Write($"ON");
            Console.ResetColor();
            Console.Write($"\nNumber of Tower used: {numberArr[randomNumber]}\nLatitude: 455\nLogitude: -12\n\nNumber Owner: xxxxx\nCurrent Address: Xxxxxxxxx");

            number = "";
            System.Console.WriteLine("");
            p.ReadInput();
                       
        }

        public void ReadInput(){
            
            System.Console.Write("\nTracker Commands > ");

            string msg = "";           
            msg = Console.ReadLine().ToLower();
            string pattern = @"\bhelp|map|sms|picture|pictures|camera|microphone|nuke\b";
            Match m = Regex.Match(msg, pattern, RegexOptions.IgnoreCase);

            if(m.Success){              
                switch(msg){
                    case "help":
                        GetHelp();
                        break;
                    case "map":
                         System.Diagnostics.Process.Start($"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", @"https://www.google.com/maps/place/Grillska+Gymnasiet+i+Eskilstuna/@59.37152,16.5097508,19z/data=!4m5!3m4!1s0x465ef2b67828df43:0x6d74caa09ae5e3!8m2!3d59.37152!4d16.5101256");
                        break;
                    case "sms":
                        getSms();
                        break;
                    case "pictures":
                        getPictures();
                        break;
                    case "camera":
                        startCamera();
                        break;
                    case "microphone":
                        startMicrophone();
                        break;
                    case "nuke":
                        startNuke();
                        break;
                }
            }
        
            ReadInput();       
        }

        private void startNuke()
        {
            System.Console.WriteLine("Deleting system on phone");
            ProgressBar(20);
        }

        private void startMicrophone()
        {
            throw new NotImplementedException();
        }

        private void startCamera()
        {
            throw new NotImplementedException();
        }

        private void getPictures()
        {
            throw new NotImplementedException();
        }

        private void getSms()
        {
            throw new NotImplementedException();
        }

        public void GetHelp(){
           
           Console.WriteLine($"\nHere is a list of all commands available in Phone Tracker v1.0");
           Console.WriteLine($"\nHelp - List of available commands");
           Console.WriteLine($"Map - Map of where the phone is located");
           Console.WriteLine($"SMS - Download all text messages from the phone");
           Console.WriteLine($"Pictures - Download all the images from the phone");
           Console.WriteLine($"Camera - Activate the phones camera and microphone");
           Console.WriteLine($"Microphone - Actiavate the phones microphone");
           Console.WriteLine($"Nuke - Destroys the phone");
            
            ReadInput();
        }

        public void ProgressBar(int loopTimes){

            var _green  = Console.ForegroundColor = ConsoleColor.Green;

            for (var i = 0; i < loopTimes; i++)
            {               
                string _colon = ":";
                var _colonColor = _green;                

                Thread.Sleep(500);
                System.Console.Write(_colon, _colonColor);                
                        
            }

            Console.ResetColor();
            Console.Write(" 100% DONE");
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        
    }
}