
using System.Runtime.InteropServices;

namespace SLIRPWrapper.src
{
    /// <summary>
    /// API class for C++ SharedTextureResource class
    /// </summary>
    public class SharedTextureResource : IDisposable
    {
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedTexResource(GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedTexResourceByPtr(IntPtr anotherInstance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedTexResourceByTexId(IntPtr glTexId, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroySharedTexResource(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getGlTextureId(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static GLenum getGlImgType(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getWidth(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getHeight(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getGlInternalFormat(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static GLenum getGlFormat(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static GLenum getGlType(IntPtr instance);

        public IntPtr NativeInstance { get; private set; }

        public SharedTextureResource(GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType)
        {
            NativeInstance = factorySharedTexResource(glImgType, width, height, glInternalFormat,glFormat, glType);
        }

        public SharedTextureResource(IntPtr anotherInstance)
        {
            NativeInstance = factorySharedTexResourceByPtr(anotherInstance);
        }
        public SharedTextureResource(SharedTextureResource anotherInstance)
        {
            NativeInstance = factorySharedTexResourceByPtr(anotherInstance.NativeInstance);
        }

        public SharedTextureResource(int glTexId, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType)
        {
            NativeInstance = factorySharedTexResourceByTexId(glTexId, glImgType, width, height, glInternalFormat, glFormat, glType);
        }

        public void Dispose()
        {
            destroySharedTexResource(NativeInstance);
        }
        public int GetGlTextureId()
        {
            return getGlTextureId(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public GLenum GetGlImgType()
        {
            return getGlImgType(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public int GetWidth()
        {
            return getWidth(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public int GetHeight()
        {
            return getHeight(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public int GetGlInternalFormat()
        {
            return getGlInternalFormat(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public GLenum GetGlFormat()
        {
            return getGlFormat(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public GLenum GetGlType()
        {
            return getGlType(NativeInstance);
        }
    }
}
