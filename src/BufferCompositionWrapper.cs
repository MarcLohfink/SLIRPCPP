using Fusee.SLIRP.Common;
using SLIRP.Common;
using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    /// <summary>
    /// API for the C++ BufferComposition class. 
    /// </summary>
    public class BufferCompositionWrapper : IVideoDataProvider<byte[]>, IDataBuffer<byte[]>
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr createTestBufferComposition(int size, int bufferSize);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroyTestBufferComposition(IntPtr intPtr);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInTestBufferComposition(IntPtr intPtr, byte[] data);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] provideTestBufferCompositionData(IntPtr intPtr);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] provideByCopyTestBufferCompositionData(IntPtr intPtr);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void setTestBufferCompositionVideoSettings(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        IntPtr _nativeInstance;

        public IntPtr NativeProviderInstance => _nativeInstance;

        public BufferCompositionWrapper(int size, int bufferSize)
        {
            _nativeInstance = createTestBufferComposition(size, bufferSize);
        }

        public void DestroyProvider()
        {
            Dispose();
        }

        public void InitProvider()
        {
            //ToDo --> link dll IDataProvider methods
        }

        public byte[] ProvideDataByCopy()
        {
            return provideByCopyTestBufferCompositionData(_nativeInstance);
        }

        public byte[] ProvideData()
        {
            return provideTestBufferCompositionData(_nativeInstance);
        }

        public void BufferData(byte[] data)
        {
            bufferDataInTestBufferComposition(_nativeInstance, data);
        }
        public byte[] PeekLast()
        {
            return ProvideData();
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            setTestBufferCompositionVideoSettings(_nativeInstance, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);
        }

        public void Dispose()
        {
            destroyTestBufferComposition(_nativeInstance);
        }
    }
}
