using System;

namespace SLIRPWrapper
{
    internal class Run
    {
        static int srcWidth = 1920;
        static int srcHeight = 1080;
        static int frameRate = 30;
        static string pxtFmtName = "yuv420p";
        static int bitrate = 40000;
        static int gopSize = 1;
        static int maxBFrames = 0;
        static string codecID = "lib264";


        static string ipv4 = "127.0.0.1";
        static int port = 5004;
        static string protocolName = "tcp"; 

        public static void Main()
        {
            DataProviderWrapper dataProviderWrapper = new DataProviderWrapper();
            dataProviderWrapper.SetVideoSettings(srcWidth, srcHeight, frameRate, pxtFmtName);

            IntPtr DataProvider = dataProviderWrapper.NativeProvider;

            RTPServerSingleWrapper _rtpServer = new RTPServerSingleWrapper();

            _rtpServer.InitVideoDummy();

            _rtpServer.InitVideoSettings(srcWidth, srcHeight, frameRate, bitrate, gopSize, maxBFrames, pxtFmtName, codecID);

            _rtpServer.InitNetSettings(ipv4, port, protocolName);

            _rtpServer.InitDataProvider(DataProvider);

            _rtpServer.Run();
          
        }
    }
}
