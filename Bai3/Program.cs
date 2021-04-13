using System;
using System.Threading;
using System.IO;
using System.Net;

using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "temp.jpg"; //tệp ảnh thay thế
            new WebClient().DownloadFile("https://https://wall.vn/wp-content/uploads/2020/03/hinh-nen-dep-may-tinh-1.jpg", filename); //tải ảnh từ internet
            string path = AppDomain.CurrentDomain.BaseDirectory;
            SetWallpaper(path + filename);
            Thread.Sleep(1000);
            File.Delete(path + filename);
        }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;
        private static void SetWallpaper(string file_name)
        {
            uint flags = 0;
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, file_name, flags))
            {
                Console.WriteLine("Error");
            }
        }
    }
}