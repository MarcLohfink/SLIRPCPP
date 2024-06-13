using SLIRP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SLIRPWrapper.src
{
    /// <summary>
    /// API for the C++ GLCUDAVidTexToPtrBufComp class. 
    /// </summary>
    public class GLCUDAVidTexToPtrBufComp : IVideoDataProvider<IntPtr>, IDataBuffer<IntPtr>
    {
        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factoryGLCUDAVidTexToPtrBufComp(int capacity, int width, int height, int channel);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void deleteGLCUDAVidTexToPtrBufComp(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInGLCUDAVidTexToPtrBufComp(IntPtr intPtr, IntPtr dstGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInGLCUDAVidTexToPtrBufCompWithSize(IntPtr intPtr, IntPtr dstGPUAdress, int buffersize);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr provideDataOfGLCUDAVidTexToPtrBufComp(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void provideDataOfGLCUDAVidTexToPtrBufCompByPtr(IntPtr intPtr, IntPtr srcGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr setGLCUDAVidTexToPtrBufCompVideoSettings(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        IntPtr _nativeInstance;
        public IntPtr NativeProviderInstance => _nativeInstance;

        public GLCUDAVidTexToPtrBufComp(int capacity, int width, int height, int channel)
        {
            _nativeInstance = factoryGLCUDAVidTexToPtrBufComp(capacity, width, height, channel);
        }

        public void InitProvider()
        {
            //ToDo --> link dll IDataProvider methods

        }

        public void DestroyProvider()
        {
            deleteGLCUDAVidTexToPtrBufComp(_nativeInstance);
        }

        public IntPtr ProvideData()
        {
            throw new NotImplementedException("Not supported.");
            //return provideDataOfSharedTexBufComp(_nativeInstance);
        }

        public void BufferData(IntPtr sharedTexPtr)
        {
            bufferDataInGLCUDAVidTexToPtrBufComp(_nativeInstance, sharedTexPtr);
        }

        public IntPtr PeekLast()
        {
            throw new NotImplementedException("Not supported.");
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            setGLCUDAVidTexToPtrBufCompVideoSettings(_nativeInstance, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);
        }
    }
}
