
using Microsoft.AspNetCore.Components;

namespace VditorBlazor.Demo.Client.Pages;

partial class Home
{
    [Inject] HttpClient Client { get; set; }

    string? Content { get; set; } = "Hello World!!!";

    protected override async Task OnInitializedAsync()
    {
        Content = await Client.GetStringAsync("demo.md");
    }

}
