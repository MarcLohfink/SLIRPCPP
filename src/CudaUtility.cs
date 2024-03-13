using System.Runtime.InteropServices;

namespace SLIRPWrapper
{
    public class CudaUtility
    {
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "setCudaDevice")]
        public extern static bool SetCudaDevice(int gpuDevice);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "setFirstCudaDevice")]
        public extern static bool SetFirstCudaDevice();
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "resetCudaDevice")]
        public extern static bool ResetCudaDevice(int gpuDevice);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "syncCudaDevice")]
        public extern static void SyncCudaDevice();
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "copyFromCudaResource")]
        public extern static void CopyFromCudaResource(IntPtr cudaTexRes, IntPtr dst, int dataSize);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "copyToCudaResource")]
        public extern static void CopyToCudaResource(IntPtr src, IntPtr cudaTexRes, int dataSize);
        [DllImport("OpenGLCudaInterOp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "copyFromToCudaResource")]
        public extern static void CopyFromToCudaResource(IntPtr cudaSrc, IntPtr cudaDst, int dataSize);

    }
}
