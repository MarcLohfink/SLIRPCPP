﻿using SLIRPWrapper;

public static class Program
{
    static int srcWidth = 1920;
    static int srcHeight = 1080;
    static int frameRate = 30;
    static string srcPixFormat = "rgb24";
    static string dstPxtFmtName = "yuv420p";
    static string codecID = "libx264";
    static int bitrate = 40000;
    static int gopSize = 10;
    static int maxBFrames = 0;


    static string ipv4 = "127.0.0.1";
    static int port = 5004;
    static string protocolName = "rtp";

    public static void Main()
    {
        DataProviderWrapper dataProviderWrapper = new DataProviderWrapper();
        dataProviderWrapper.SetVideoSettings(srcWidth, srcHeight, frameRate, srcPixFormat);

        IntPtr DataProvider = dataProviderWrapper.NativeProviderInstance;

        RTPServerSingleWrapper _rtpServer = new RTPServerSingleWrapper();

        _rtpServer.InitVideoSettings(srcWidth, srcHeight, frameRate, bitrate, gopSize, maxBFrames, dstPxtFmtName, codecID);

        _rtpServer.InitNetSettings(ipv4, port, protocolName);

        _rtpServer.InitDataProvider(DataProvider);

        _rtpServer.Run();

    }
}