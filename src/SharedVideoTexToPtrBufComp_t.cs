
using SLIRP.Common;
using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    /// <summary>
    /// API for the C++ SharedVidTexToPtrBufComp_t class. 
    /// </summary>
    public class SharedVidTexToPtrBufComp_t : IVideoDataProvider<IntPtr>, IDataBuffer<IntPtr>
    {
        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedVidTexToPtrBufComp_t(int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedVidTexToPtrBufCompGLTexInjection_t(uint[] glTexIds, int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void deleteSharedVidTexToPtrBufComp_t(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInSharedVidTexToPtrBufComp_t(IntPtr intPtr, IntPtr dstGPUAdress);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void bufferDataInSharedVidTexToPtrBufCompWithSize_t(IntPtr intPtr, IntPtr dstGPUAdress, int buffersize);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr provideDataOfSharedVidTexToPtrBufComp_t(IntPtr intPtr);

        [DllImport("FFmpegNetwork.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr setSharedVidTexToPtrBufComp_t(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        public extern static byte[] peekLastData(IntPtr intPtr);

        IntPtr _nativeInstance;
        public IntPtr NativeProviderInstance => _nativeInstance;

        public SharedVidTexToPtrBufComp_t(int capacity, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel)
        {
            _nativeInstance = factorySharedVidTexToPtrBufComp_t(capacity, glImgType, width, height, glInternalFormat, glFormat, glType, channel);
        }

        public SharedVidTexToPtrBufComp_t(uint[] glTexIds, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType, int channel)
        {
            _nativeInstance = factorySharedVidTexToPtrBufCompGLTexInjection_t(glTexIds, glTexIds.Length, glImgType, width, height, glInternalFormat, glFormat, glType, channel);
        }
        public void InitProvider()
        {
            //ToDo --> link dll IDataProvider methods

        }

        public void DestroyProvider()
        {
            deleteSharedVidTexToPtrBufComp_t(_nativeInstance);
        }

        public IntPtr ProvideData()
        {
            return provideDataOfSharedVidTexToPtrBufComp_t(_nativeInstance);
        }

        public void BufferData(IntPtr sharedTexPtr)
        {
            bufferDataInSharedVidTexToPtrBufComp_t(_nativeInstance, sharedTexPtr);
        }

        public IntPtr PeekLast()
        {
            throw new NotImplementedException("Not supported.");
        }

        public byte[] PeekLastData(int size)
        {
            return peekLastData(_nativeInstance);
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            setSharedVidTexToPtrBufComp_t(_nativeInstance, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);
        }
    }
}
