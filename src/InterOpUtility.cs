using System.Runtime.InteropServices;

namespace SLIRPWrapper.src
{
    public static class InterOpUtility
    {
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "initOpenGL")]
        public extern static bool InitOpenGL();
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "printRendererAndVersion")]
        public extern static void PrintRendererAndVersion();
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "setGLDevice")]
        public extern static void SetGLDevice(int deviceId); 
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "isGlTexture")]
        public extern static bool IsGlTexture(uint glBufferId);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "createSharedCudaBuffer")]
        public extern static IntPtr CreateSharedCudaBuffer(uint glBufferId);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "createSharedFrameBuffer")]
        public extern static void CreateSharedFrameBuffer(out uint glFramebufferId, out IntPtr cudaFramebufferId); 
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "createSharedCudaTexture")]
        public extern static IntPtr CreateSharedCudaTexture(uint glImageId, GLenum glImgType); 
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "createSharedTextureAttachment")]
        public extern static void CreateSharedTextureAttachment(out uint glFramebufferId, out uint glTextureId, GLenum glImgType, out IntPtr cudaTextureId,
        int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType); 
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "createSharedTexture")]
        public extern static bool CreateSharedTexture(out uint glTextureId, GLenum glImgType, out IntPtr cudaTextureId,
        int width, int height, int glInternalFormat, GLenum glFormat, GLenum glType); 
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "cpyOpenGLToCUDA")]
        public extern static bool CpyOpenGLToCUDA(IntPtr regRes, IntPtr glDataPtr);
    }
}
