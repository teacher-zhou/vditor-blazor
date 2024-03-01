
using Microsoft.AspNetCore.Components;

namespace VditorBlazor.Demo.Client.Pages;

partial class Home
{
    [Inject] HttpClient Client { get; set; }

    string? Content { get; set; } = "Hello World!!!";

    string? Html { get; set; }





    Vditor? _refVditor;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Content = await Client.GetStringAsync("demo.md");

            if (_refVditor.HasRenderCompleted)
            {
                await _refVditor!.SetValueAsync(Content);
            }
        }
    }


    async Task Click()
    {
        Html = await _refVditor!.GetHtmlAsync();
    }


    async Task Set()
    {
        await _refVditor!.SetValueAsync("`Blazor` is the best");
    }
}
