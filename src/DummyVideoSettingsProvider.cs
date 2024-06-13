using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SLIRP.Common;

namespace SLIRPWrapper.src
{
    /// <summary>
    /// A dummy to provide video settings BUT no video data.
    /// For the framework there has to be a video provider which offers frame data.
    /// For the HW accelerated implementations this is completely done on the GPU.
    /// The render engine writes its frame data into a framebuffer on the GPU while
    /// FFmpeg in the SLIRP framework reads the frame data directly from the framebuffer
    /// without coping it to the CPU memory.
    /// </summary>
    public class DummyVideoSettingsProvider : IVideoDataProvider<nint>, IDisposable
    {
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr createDummyVideoSettingsProvider();
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl, EntryPoint = "destroyDummyVideoSettingsProvider")]
        public static extern IntPtr DestroyDummyVideoSettingsProvider();
        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte[] provideDummyVideoSettingsProviderData(IntPtr intPtr);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte[] provideByCopyDummyVideoSettingsProviderData(IntPtr intPtr);

        [DllImport("FFmpegNetwork", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setDummyVideoSettingsProvider(IntPtr intPtr, int srcWidth, int srcHeight, int srcFramerate, string srcPxlFmtName);

        public IntPtr NativeProviderInstance { get; }

        public DummyVideoSettingsProvider()
        {
            NativeProviderInstance = createDummyVideoSettingsProvider();
        }
        
        public void Dispose() 
        {
            DestroyDummyVideoSettingsProvider();
        }

        public void InitProvider()
        {
            throw new NotImplementedException();
        }

        public void DestroyProvider()
        {
            Dispose();
        }

        public nint ProvideData()
        {
            provideDummyVideoSettingsProviderData(NativeProviderInstance);
            return nint.MaxValue;
        }

        public void SetVideoSettings(int srcWidth, int srcHeight, int srcFrameRate, string srcPxlFmtName)
        {
            setDummyVideoSettingsProvider(NativeProviderInstance, srcWidth, srcHeight, srcFrameRate, srcPxlFmtName);
        }
    }
}
