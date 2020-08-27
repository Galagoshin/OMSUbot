using System;
using System.Collections.ObjectModel;
using System.Net.Mime;
using OMSUbot.Vk.Handler;

namespace OMSUbot
{
    internal class Program
    {
        public const string Version = "1.0.0-ALPHA1"; 
        
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Enter token in args!");
                Environment.Exit(1);
            }
            Bot bot = new Bot(args[0]);
            IHandler handler = new LongPoll(186227141);
            System.Console.WriteLine("OMSUbot v" + Version + " has been started!");
            handler.Start();
        }
    }
}