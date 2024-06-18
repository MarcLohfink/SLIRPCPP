using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    public class SharedTextureResource_t
    {
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedTexResource_t(GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedTexResourceByPtr_t(IntPtr anotherInstance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedTexResourceByTexId_t(uint glTexId, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedTexResourceByTexFBId_t(IntPtr glFBufferId, uint glTexId, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType);        
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroySharedTexResource_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getGlTextureId_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static GLenum getGlImgType_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getWidth_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getHeight_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getGlInternalFormat_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static GLenum getGlFormat_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static GLenum getGlType_t(IntPtr instance);

        //[DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        //public extern static bool checkSharedTexMapping_t(IntPtr instance);


        public IntPtr NativeInstance { get; private set; }

        public SharedTextureResource_t(GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType)
        {
            NativeInstance = factorySharedTexResource_t(glImgType, width, height, glInternalFormat, glFormat, glType);
        }

        public SharedTextureResource_t(IntPtr anotherInstance)
        {
            NativeInstance = factorySharedTexResourceByPtr_t(anotherInstance);
        }
        public SharedTextureResource_t(SharedTextureResource anotherInstance)
        {
            NativeInstance = factorySharedTexResourceByPtr_t(anotherInstance.NativeInstance);
        }

        public SharedTextureResource_t(uint glTexId, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType)
        {
            NativeInstance = factorySharedTexResourceByTexId_t(glTexId, glImgType, width, height, glInternalFormat, glFormat, glType);
        }
        public SharedTextureResource_t(int glFBufferId, uint glTexId, GLenum glImgType, int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType)
        {
            NativeInstance = factorySharedTexResourceByTexFBId_t(glFBufferId,glTexId, glImgType, width, height, glInternalFormat, glFormat, glType);
        }
        

        public void Dispose()
        {
            destroySharedTexResource_t(NativeInstance);
        }
        public int GetGlTextureId()
        {
            return getGlTextureId_t(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public GLenum GetGlImgType()
        {
            return getGlImgType_t(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public int GetWidth()
        {
            return getWidth_t(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public int GetHeight()
        {
            return getHeight_t(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public int GetGlInternalFormat()
        {
            return getGlInternalFormat_t(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public GLenum GetGlFormat()
        {
            return getGlFormat_t(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public GLenum GetGlType()
        {
            return getGlType_t(NativeInstance);
        }
        /// <returns>if resource could be mapped </returns>
        //public bool CheckSharedTexMapping()
        //{
        //    return checkSharedTexMapping_t(NativeInstance);
        //}
        
    }
}
