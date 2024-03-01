using System.Linq.Expressions;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace VditorBlazor;

partial class Vditor
{

    private bool _isInitialized;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Inject] IOptions<VditorOptions> GlobalOptions { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// 自定义配置当前编辑器。
    /// </summary>
    [Parameter] public Action<VditorOptions>? Configure { get; set; }


    /// <summary>
    /// 要绑定的 markdown 字符串。
    /// </summary>
    [Parameter]
    public string? Value { get; set; }
    /// <summary>
    /// 当绑定值文本改变时触发的事件。
    /// </summary>
    [Parameter] public EventCallback<string?> ValueChanged { get; set; }
    /// <summary>
    /// 编辑器表达式。
    /// </summary>
    [Parameter] public Expression<Func<string?>>? ValueExpression { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    VditorOptions Options { get; set; } = new();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected override void OnInitialized()
    {
        Options ??= GlobalOptions.Value;
        Configure?.Invoke(Options);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (Options.AutoInitialize)
            {
                await InitializeAsync();
            }
        }
    }
}
