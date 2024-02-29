using System.Linq.Expressions;

using Microsoft.AspNetCore.Components;

namespace VditorBlazor;

partial class Vditor
{
    ElementReference? _refEditor;

    bool _isRendered;

    [Parameter] public string? Value { get; set; }
    [Parameter] public EventCallback<string?> ValueChanged { get; set; }
    [Parameter] public Expression<Func<string?>>? ValueExpression { get; set; }
    [Parameter] public EventCallback<bool> OnRendered { get; set; }
    /// <summary>
    /// 内容主题。
    /// </summary>
    [Parameter] public Theme ContentTheme { get; set; } = Theme.Light;
    /// <summary>
    /// 编辑器模式。
    /// </summary>
    [Parameter] public Mode Mode { get; set; } = Mode.IR;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await CreateVditorAsync();
        }
    }
}
