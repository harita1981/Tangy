using Microsoft.JSInterop;

namespace TangyWeb_Server.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsruntime, string message)
        {
            await jsruntime.InvokeVoidAsync("ShowToastr", "success", message );
        }
        public static async ValueTask ToastrError(this IJSRuntime jsruntime, string message)
        {
            await jsruntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
