
using Fusee.SLIRP.Common;
using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    /// <summary>
    /// API for the C++ SharedVideoTexBufComp class. 
    /// </summary>
    public class SharedTexCompWrapper : IVideoDataProvider<IntPtr>, IDataBuffer<IntPtr>
    {
        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedVideoTexBufferComposition(int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel);
        
        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedVideoTexBufferCompositionGLTexInjection(uint[] glTexIds, int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void deleteSharedVideoTexBufferComposition(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInSharedVideoTexBufComp(IntPtr intPtr, IntPtr dstGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInSharedVideoTexBufCompWithSize(IntPtr intPtr, IntPtr dstGPUAdress, int buffersize);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr provideDataOfSharedVideoTexBufComp(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void provideDataOfSharedTexBufCompByPtr(IntPtr intPtr, IntPtr srcGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr setSharedVideoTexBufCompVideoSettings(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        IntPtr _nativeInstance;
        public IntPtr NativeProviderInstance => _nativeInstance;

        public SharedTexCompWrapper(int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel)
        {
            _nativeInstance = factorySharedVideoTexBufferComposition(capacity, glImgType, width, height, glInternalFormat, glFormat, glType, channel);
        }

        public SharedTexCompWrapper(uint[] glTexIds, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel)
        {
            _nativeInstance = factorySharedVideoTexBufferCompositionGLTexInjection(glTexIds, glTexIds.Length, glImgType, width, height, glInternalFormat, glFormat, glType, channel);
        }
        public void InitProvider()
        {
            //ToDo --> link dll IDataProvider methods

        }

        public void DestroyProvider()
        {
            deleteSharedVideoTexBufferComposition(_nativeInstance);
        }

        public IntPtr ProvideData()
        {
            throw new NotImplementedException("Not supported.");
            //return provideDataOfSharedTexBufComp(_nativeInstance);
        }

        public void BufferData(IntPtr sharedTexPtr)
        {
            bufferDataInSharedVideoTexBufComp(_nativeInstance, sharedTexPtr);
        }

        public IntPtr PeekLast()
        {
            throw new NotImplementedException("Not supported.");
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            setSharedVideoTexBufCompVideoSettings(_nativeInstance, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);
        }
    }
}
