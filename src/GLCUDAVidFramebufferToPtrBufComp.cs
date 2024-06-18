using SLIRP.Common;
using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    /// <summary>
    /// API for the C++ SharedVidTexToPtrBufComp_t class. 
    /// </summary>
    public class GLCUDAVidFramebufferToPtrBufComp : IVideoDataProvider<IntPtr>, IDataBuffer<IntPtr>
    {
        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factoryGLCUDAVidFramebufferToPtrBufComp(int capacity, int width, int height, int channel);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void deleteGLCUDAVidFramebufferToPtrBufComp(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInGLCUDAVidFramebufferToPtrBufComp(IntPtr intPtr, IntPtr dstGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInGLCUDAVidFramebufferToPtrBufCompWithSize(IntPtr intPtr, IntPtr dstGPUAdress, int buffersize);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr provideDataOfGLCUDAVidFramebufferToPtrBufComp(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void provideDataOfGLCUDAVidFramebufferToPtrBufCompByPtr(IntPtr intPtr, IntPtr srcGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr setGLCUDAVidFramebufferToPtrBufCompVideoSettings(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static byte[] peekLastFrameBuffer(IntPtr intPtr);

        IntPtr _nativeInstance;
        public IntPtr NativeProviderInstance => _nativeInstance;

        public GLCUDAVidFramebufferToPtrBufComp(int capacity, int width, int height, int channel)
        {
            _nativeInstance = factoryGLCUDAVidFramebufferToPtrBufComp(capacity, width, height, channel);
        }

        public void InitProvider()
        {
            //ToDo --> link dll IDataProvider methods

        }

        public void DestroyProvider()
        {
            deleteGLCUDAVidFramebufferToPtrBufComp(_nativeInstance);
        }

        public IntPtr ProvideData()
        {
            throw new NotImplementedException("Not supported.");
            //return provideDataOfSharedTexBufComp(_nativeInstance);
        }

        public void BufferData(IntPtr sharedTexPtr)
        {
            bufferDataInGLCUDAVidFramebufferToPtrBufComp(_nativeInstance, sharedTexPtr);
        }

        public IntPtr PeekLast()
        {
            throw new NotImplementedException("Not supported.");
        }

        public byte[] PeekLastData()
        {
            return peekLastFrameBuffer(_nativeInstance);
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            setGLCUDAVidFramebufferToPtrBufCompVideoSettings(_nativeInstance, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);
        }
    }
}
