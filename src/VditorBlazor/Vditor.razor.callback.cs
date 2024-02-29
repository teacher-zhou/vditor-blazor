using System.Text.Json;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace VditorBlazor;

partial class Vditor
{

    [Inject] IJSRuntime JS { get; set; }

    async ValueTask CreateVditorAsync()
    {
        if (!_isRendered)
        {
            await JS.InvokeVoidAsync("vditorBlazor.createVditor", _refEditor, DotNetObjectReference.Create(this), new
            {
                value = Value,
                theme = ContentTheme.GetDefaultValueAsString(),
                mode = Mode.GetDefaultValueAsString(),
            });
            _isRendered = true;
        }
    }

    [JSInvokable("invokeInput")]
    public async Task JSInvokeInputAsync(string? value)
    {
        await ValueChanged.InvokeAsync(value);
    }

    [JSInvokable("invokeAfter")]
    public Task JSInvokeAfterAsync()
    {
        _isRendered = true;
        return OnRendered.InvokeAsync(_isRendered);
    }
}
