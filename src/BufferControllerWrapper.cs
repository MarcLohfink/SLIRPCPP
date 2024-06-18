using System;
using System.Runtime.InteropServices;
using SLIRP.Common;

namespace SLIRPWrapper
{
    public class BufferControllerWrapper : IVideoDataProvider<byte[]>, IDataBuffer<byte[]>, IDisposable
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr createBufferController(int size);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroyBufferController(IntPtr intPtr);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInBufferController(IntPtr intPtr, byte[] data);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] provideBufferControllerData(IntPtr intPtr);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void setBufferControllerVideoSettings(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, IntPtr srcPxlFmtName);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] peekLast(IntPtr intPtr);

        IntPtr _nativeInstance;

        public IntPtr NativeProviderInstance => _nativeInstance;

        public BufferControllerWrapper(int size)
        {
            _nativeInstance = createBufferController(size);
        }

        public void DestroyProvider()
        {
            Dispose();
        }

        public void InitProvider()
        {
           //ToDo --> link dll IDataProvider methods
        }

        public byte[] ProvideData()
        {
            return provideBufferControllerData(_nativeInstance);
        }

        public void BufferData(byte[] data)
        {
            bufferDataInBufferController(_nativeInstance, data);
        }
        public byte[] PeekLast()
        {
            return ProvideData();
        }

        public byte[] PeekLastData()
        {
            return peekLast(_nativeInstance);
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            //ToDo --> link dll IDataProvider methods
        }

        public void Dispose()
        {
            destroyBufferController(_nativeInstance);
        }


    }
}
