using System;
using System.Runtime.InteropServices;


namespace SLIRPWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public class DataProviderWrapper : IDataProvider<byte[]>
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factoryTestFrameGenerator();

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destoryTestFrameGenerator(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] provideByteArrayData(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void generateVideoSettings(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static string setVideoSettings2(IntPtr prog,int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName);


        private IntPtr _nativeProvider;
        private bool _isInitialized;

        public IntPtr NativeProvider => _nativeProvider;

        public DataProviderWrapper()
        {
            InitProvider();
        }

        public void InitProvider()
        {
            if (_isInitialized)
                destoryTestFrameGenerator(_nativeProvider);

            _nativeProvider = factoryTestFrameGenerator();
            generateVideoSettings(_nativeProvider);

            _isInitialized = true;
        }

        public void DestroyProvider()
        {
            if (!_isInitialized)
                return;

            destoryTestFrameGenerator(_nativeProvider);

            _isInitialized = false;
        }

        public byte[] ProvideData()
        {
            if (!_isInitialized)
                return new byte[0];

            return provideByteArrayData(_nativeProvider);
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            if(!_isInitialized) 
                return;

            string result = setVideoSettings2(_nativeProvider, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);

            Console.WriteLine("[DataProviderWrapper] SetVideoSettings result: "+ result);
        }
    }
}
