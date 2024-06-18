using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    public class SharedFramebufferResource_t
    {

        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedFramebufferResource_t(int width, int height, int channel);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedFramebufferResourceByCopy_t(IntPtr anotherInstance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr factorySharedFramebufferResourceInjectFB_t(IntPtr glGPUFramebufferId, int width, int height, int channel);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static void destroySharedFramebufferResource_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getGlFramebufferId_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getWidth_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getHeight_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getChannel_t(IntPtr instance);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl)]
        public extern static int getSize_t(IntPtr instance);


        public IntPtr NativeInstance { get; private set; }

        public SharedFramebufferResource_t(int width, int height, int channel)
        {
            NativeInstance = factorySharedFramebufferResource_t(width, height, channel);
        }
        public SharedFramebufferResource_t(IntPtr anotherInstance)
        {
            NativeInstance = factorySharedFramebufferResourceByCopy_t(anotherInstance);
        }
        public SharedFramebufferResource_t(SharedFramebufferResource_t anotherInstance)
        {
            NativeInstance = factorySharedFramebufferResourceByCopy_t(anotherInstance.NativeInstance);
        }
        public SharedFramebufferResource_t(int glFBufferId, int width, int height, int channel)
        {
            NativeInstance = factorySharedFramebufferResourceInjectFB_t(glFBufferId, width, height, channel);
        }


        public void Dispose()
        {
            destroySharedFramebufferResource_t(NativeInstance);
        }
        public int GetGlFramebufferId()
        {
            return getGlFramebufferId_t(NativeInstance);
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
        public int GetChannel()
        {
            return getChannel_t(NativeInstance);
        }
        /// <returns>-1 means it failed</returns>
        public int GetSize()
        {
            return getSize_t(NativeInstance);
        }

    }
}
