using SLIRP.Common;
using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    public class TestDataBufferWrapper : IDisposable, IDataBuffer<byte[]>
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr createTestBuffer(int capacity);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroyTestBuffer(IntPtr prog);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInTestBuffer(IntPtr prog, byte[] data);

        IntPtr _nativeInstance;

        public IntPtr NativeInstance => _nativeInstance;

        public TestDataBufferWrapper(int size)
        {
            _nativeInstance = createTestBuffer(size);
        }

        public void DestroyProvider()
        {
            Dispose();
        }

        public void Dispose()
        {
            destroyTestBuffer(_nativeInstance);
        }

        public void BufferData(byte[] data)
        {
            bufferDataInTestBuffer(_nativeInstance, data);
        }

        public byte[] PeekLast()
        {
            return new byte[0];
        }

        public byte[] PeekLastData(int size)
        {
            return PeekLast();
        }
    }
}
