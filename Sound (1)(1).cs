using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Hunt_the_Wumpus
{
    class Sound : IDisposable
    {
        public readonly string FilePath; //The filename of the file to play
        private string Name; //The name of the sound
        private static long c = 0; //This gives it a unique name in the mcioutput

        public Sound(string FilePath)
        {
            c++;
            this.FilePath = FilePath;
            Name = "MediaFile" + c; //Open the file
            SendCommand("open \"" + "Assets\\" + FilePath + "\" type mpegvideo alias " + Name);
        }

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        public void Play() //To play it, just send the command
        {
            Name += c;
            SendCommand("open \"" + "Assets\\" + FilePath + "\" type mpegvideo alias " + Name);
            SendCommand("play " + Name);
        }

        private static void SendCommand(string Command)
        {
            mciSendString(Command, null, 0, IntPtr.Zero);
        }

        public void Dispose()
        {
            SendCommand("close " + Name);
        }
    }
}
