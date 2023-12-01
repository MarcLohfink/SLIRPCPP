using Fusee.SLIRP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SLIRPWrapper.src
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
    }
}
