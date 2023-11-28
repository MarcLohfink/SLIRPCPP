using Fusee.SLIRP.Common;
using System.Runtime.InteropServices;


namespace SLIRPWrapper
{
    public class DataProviderWrapper : IDataProvider<byte[]>
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factoryTestFrameGenerator();

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destoryTestFrameGenerator(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] provideTestFrameData(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void generateTestFrameVideoSettings(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr setTestFrameVideoSettings2(IntPtr prog,int srcWidth, int srcHeight, int srcFrameRate, IntPtr srcPxlFmtName);


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
            generateTestFrameVideoSettings(_nativeProvider);

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

            return provideTestFrameData(_nativeProvider);
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            if(!_isInitialized) 
                return;

            IntPtr stringPtr = Marshal.StringToHGlobalAnsi(srcPxlFmtName);

            IntPtr rPtr = setTestFrameVideoSettings2(_nativeProvider, srcWidth, srcHeight, srcFrameRate, stringPtr);
            string result = Marshal.PtrToStringAnsi(rPtr);

            Console.WriteLine("[DataProviderWrapper] SetVideoSettings result: "+ result);
        }
    }
    
}
