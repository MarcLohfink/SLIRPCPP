using System;
using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    //[StructLayout(LayoutKind.Sequential)]
    public class RTPServerSingleWrapper
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factoryRTPServerSingle();

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroyRTPServerSingle(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr initStreamSettings(IntPtr prog, string ipv4, int port, string protocolShortName);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr initVideoSettings(IntPtr prog, int dstWidth, int dstHeight, int frameRate, int bitRate, int gopSize, int maxBFrames, string dstPxlFmt, string codecID);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr initDataProvider(IntPtr prog, IntPtr provider);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr runRTPServer(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr stopRTPServer(IntPtr prog);


        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr initVideoDummy();

        private IntPtr _nativeRTPServer;
        private IntPtr _nativeDataProvider;


        bool _isInitialized;

        public string InitVideoDummy()
        {
            IntPtr resultPtr = initVideoDummy();
            string result = Marshal.PtrToStringAnsi(resultPtr);
            return result;
        }

        public RTPServerSingleWrapper()
        {
            if (_isInitialized)
                destroyRTPServerSingle(_nativeRTPServer);

            _nativeRTPServer = factoryRTPServerSingle();
        
            _isInitialized = true;  
        }

        ~RTPServerSingleWrapper()
        {
            if (_isInitialized && _nativeRTPServer != IntPtr.Zero)
                destroyRTPServerSingle( _nativeRTPServer );
        
            _nativeRTPServer = IntPtr.Zero; 

            _isInitialized = false;
        }

        public void InitVideoSettings(int dstWidth, int dstHeight, int frameRate, int bitRate, int gopSize, int maxBFrames, string dstPxlFmt, string codecID)
        {
            if (!_isInitialized)
                return;

            IntPtr resultPtr = initVideoSettings(_nativeRTPServer, dstWidth, dstHeight, frameRate, bitRate, gopSize, maxBFrames, dstPxlFmt, codecID);
            string result = Marshal.PtrToStringAnsi(resultPtr);

            Console.WriteLine("[RTPServerWrapper] Init Video Settings finished with result: "+ result);
        }

        public void InitNetSettings(string ipv4, int port, string protocolShortName)
        {
            if (!_isInitialized)
                return;

            IntPtr resultPtr = initStreamSettings(_nativeRTPServer, ipv4,port,protocolShortName);
            string result = Marshal.PtrToStringAnsi(resultPtr);

            Console.WriteLine("[RTPServerWrapper] Init Net Settings finished with result: " + result);
        }

        public void InitDataProvider(IntPtr dataProvider)
        {
            if (!_isInitialized)
                return;

            IntPtr resultPtr = initDataProvider(_nativeRTPServer, dataProvider);
            string result = Marshal.PtrToStringAnsi(resultPtr);

            _nativeDataProvider = dataProvider;

            Console.WriteLine("[RTPServerWrapper] Init Data Provider finished with result: " + result);
        }

        public void Run()
        {
            if(!_isInitialized) 
                return;

            IntPtr resultPtr = runRTPServer(_nativeRTPServer);
            string result = Marshal.PtrToStringAnsi(resultPtr);

            Console.WriteLine("[RTPServerWrapper] Run finished with result: " + result);
        }


        public void Stop()
        {
            if (!_isInitialized)
                return;

            IntPtr resultPtr = stopRTPServer(_nativeRTPServer);
            string result = Marshal.PtrToStringAnsi(resultPtr);

            Console.WriteLine("[RTPServerWrapper] Stop finished with result: " + result);
        }
    }
}
