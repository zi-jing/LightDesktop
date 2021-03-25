using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.Windows;

namespace LightDesktop.Core
{
    public class Renderer
    {

        private static RenderForm renderForm;
        private static int width;
        private static int height;
        private static DeviceContext d3dDeviceContext;
        private static SharpDX.Direct3D11.Device d3dDevice;
        private static SwapChain swapChain;
        private static RenderTargetView renderTargetView;

        public static void DXInit(int _width, int _height)
        {
            width = _width;
            height = _height;
            if (renderForm != null)
            {
                DXDispose();
                DXInit(width, height);
            }
            renderForm = new RenderForm
            {
                ClientSize = new System.Drawing.Size(960, 540),
                Text = "LightDesktop 调试窗口"
            };
            ModeDescription modeDescription = new ModeDescription(width, height, new Rational(60, 1), Format.R8G8B8A8_UNorm);
            SwapChainDescription swapChainDescription = new SwapChainDescription()
            {
                ModeDescription = modeDescription,
                SampleDescription = new SampleDescription(1, 0),
                Usage = Usage.RenderTargetOutput,
                BufferCount = 1,
                OutputHandle = renderForm.Handle,
                IsWindowed = true
            };
            SharpDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, swapChainDescription, out d3dDevice, out swapChain);
            d3dDeviceContext = d3dDevice.ImmediateContext;
            renderTargetView = new RenderTargetView(d3dDevice, swapChain.GetBackBuffer<Texture2D>(0));
            RenderLoop.Run(renderForm, RenderCallback);
        }

        public static void DXDispose()
        {
            renderTargetView.Dispose();
            swapChain.Dispose();
            d3dDevice.Dispose();
            d3dDeviceContext.Dispose();
            renderForm.Dispose();
            renderForm = null;
        }

        private static void RenderCallback()
        {
            d3dDeviceContext.OutputMerger.SetRenderTargets(renderTargetView);
            d3dDeviceContext.ClearRenderTargetView(renderTargetView, new RawColor4(0.0f, 1.0f, 1.0f, 1.0f));

            swapChain.Present(1, PresentFlags.None);
        }
    }
}
