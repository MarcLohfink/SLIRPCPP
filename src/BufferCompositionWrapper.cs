using Fusee.SLIRP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SLIRPWrapper.src
{
    public class BufferCompositionWrapper : IDataProvider<byte[]>, IDataBuffer<byte[]>
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr createTestBufferComposition(int size);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroyTestBufferComposition(IntPtr intPtr);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInTestBufferComposition(IntPtr intPtr, byte[] data);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] provideTestBufferCompositionData(IntPtr intPtr);
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public extern static void setTestBufferCompositionVideoSettings(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        IntPtr _nativeInstance;

        public IntPtr NativeProviderInstance => _nativeInstance;

        public BufferCompositionWrapper(int size)
        {
            _nativeInstance = createTestBufferComposition(size);
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
