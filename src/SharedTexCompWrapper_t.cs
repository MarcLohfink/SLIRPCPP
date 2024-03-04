
using Fusee.SLIRP.Common;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SLIRPWrapper.src
{
    /// <summary>
    /// API for the C++ SharedTexCompWrapper_t class. 
    /// </summary>
    public class SharedTexCompWrapper_t : IVideoDataProvider<IntPtr>, IDataBuffer<IntPtr>
    {
        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedVideoTexBufferComposition_t(int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedVideoTexBufferCompositionGLTexInjection_t(uint[] glTexIds, int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void deleteSharedVideoTexBufferComposition_t(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInSharedVideoTexBufComp_t(IntPtr intPtr, IntPtr dstGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInSharedVideoTexBufCompWithSize_t(IntPtr intPtr, IntPtr dstGPUAdress, int buffersize);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr provideDataOfSharedVideoTexBufComp_t(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void provideDataOfSharedTexBufCompByPtr_t(IntPtr intPtr, IntPtr srcGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr setSharedVideoTexBufCompVideoSettings_t(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        IntPtr _nativeInstance;
        public IntPtr NativeProviderInstance => _nativeInstance;

        public SharedTexCompWrapper_t(int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel)
        {
            _nativeInstance = factorySharedVideoTexBufferComposition_t(capacity, glImgType, width, height, glInternalFormat, glFormat, glType, channel);
        }

        public SharedTexCompWrapper_t(uint[] glTexIds, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel)
        {
            _nativeInstance = factorySharedVideoTexBufferCompositionGLTexInjection_t(glTexIds, glTexIds.Length, glImgType, width, height, glInternalFormat, glFormat, glType, channel);
        }
        public void InitProvider()
        {
            //ToDo --> link dll IDataProvider methods

        }

        public void DestroyProvider()
        {
            deleteSharedVideoTexBufferComposition_t(_nativeInstance);
        }

        public IntPtr ProvideData()
        {
            throw new NotImplementedException("Not supported.");
            //return provideDataOfSharedTexBufComp(_nativeInstance);
        }

        public void BufferData(IntPtr sharedTexPtr)
        {
            bufferDataInSharedVideoTexBufComp_t(_nativeInstance, sharedTexPtr);
        }

        public IntPtr PeekLast()
        {
            throw new NotImplementedException("Not supported.");
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            setSharedVideoTexBufCompVideoSettings_t(_nativeInstance, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);
        }
    }
}
