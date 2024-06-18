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
        public extern static IntPtr provideTestBufferCompositionData(IntPtr intPtr);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] provideByCopyTestBufferCompositionData(IntPtr intPtr);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void setTestBufferCompositionVideoSettings(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr peekLastTestBufferComposition(IntPtr intPtre);

        IntPtr _nativeInstance;

        public IntPtr NativeProviderInstance => _nativeInstance;

        private int _bufferSize;

        public BufferCompositionWrapper(int size, int bufferSize)
        {
            _bufferSize = bufferSize;
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
            IntPtr unmanagedPointer = provideTestBufferCompositionData(_nativeInstance);
            byte[] managedArray = new byte[_bufferSize];
            Marshal.Copy(unmanagedPointer, managedArray, 0, _bufferSize);
            return managedArray;
        }

        public void BufferData(byte[] data)
        {
            bufferDataInTestBufferComposition(_nativeInstance, data);
        }
        public byte[] PeekLast()
        {
            return ProvideData();
        }

        public byte[] PeekLastData()
        {
            IntPtr unmanagedPointer = provideTestBufferCompositionData(_nativeInstance);
            byte[] managedArray = new byte[_bufferSize];

            Marshal.Copy(unmanagedPointer, managedArray, 0, _bufferSize);

            return managedArray;
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
