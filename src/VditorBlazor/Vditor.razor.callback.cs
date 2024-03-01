using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace VditorBlazor;

partial class Vditor
{

    [Inject] IJSRuntime JS { get; set; }


    ElementReference? _refEditor;
    IJSObjectReference _vditor;

    /// <summary>
    /// 初始化编辑器。
    /// </summary>
    public async ValueTask InitializeAsync()
    {
        if (!_isInitialized)
        {
            _vditor = await JS.InvokeAsync<IJSObjectReference>("vditorBlazor.createVditor", _refEditor, DotNetObjectReference.Create(this), AdjectOptions());
        }

        IEnumerable<KeyValuePair<string, object>>? AdjectOptions()
        {
            Dictionary<string, object> result = [];

            var options = new
            {
                value = Value,
                theme = Options.Theme.GetDefaultValueAsString(),
                mode = Options.Mode.GetDefaultValueAsString(),
                width = Options.Width,
                height = Options.Height,
                minHeight = Options.MinHeight,
                placeholder = Options.Placeholder,
                lang = Options.Language.GetDefaultValueAsString(),
                tab = Options.Tab,
                undoDelay = Options.UndoDelay,
                cdn = Options.CDN,
                debugger = Options.Debug,
                icon = Options.IconStyle.GetDefaultValueAsString()
            };

            foreach (var property in options.GetType().GetProperties())
            {
                var name = property.Name;
                var value = property.GetValue(options);
                if (value is null)
                {
                    continue;
                }

                result[name] = value;
            }
            return result;
        }
    }

    /// <summary>
    /// 设置编辑器内容且选中清空历史栈。
    /// </summary>
    /// <param name="value">Markdown 字符串。</param>
    /// <param name="clearStack">是否清空历史栈。</param>
    /// <returns></returns>
    public ValueTask SetValueAsync(string? value, bool clearStack = true) => _vditor.InvokeVoidAsync("setValue", value, clearStack);

    /// <summary>
    /// 在焦点处插入内容，并默认进行 Markdown 渲染。
    /// </summary>
    /// <param name="value">要插入的 markdown 值。</param>
    /// <param name="render">是否渲染。</param>
    public ValueTask InsertValueAsync(string? value, bool render = true) => _vditor.InvokeVoidAsync("insertValue", value, render);

    /// <summary>
    /// 获取编辑器的 markdown 内容。
    /// </summary>
    public ValueTask<string?> GetValueAsync() => _vditor.InvokeAsync<string?>("getValue");

    /// <summary>
    /// 获取 markdown 渲染后的 HTML。
    /// </summary>
    public ValueTask<string?> GetHtmlAsync() => _vditor.InvokeAsync<string?>("getHTML");
    /// <summary>
    /// 返回选中的字符串。
    /// </summary>
    public ValueTask<string?> GetSelectAsync() => _vditor.InvokeAsync<string?>("getSelection");

    /// <summary>
    /// 解除编辑器禁用
    /// </summary>
    public ValueTask EnableAsync() => _vditor.InvokeVoidAsync("enable");
    /// <summary>
    /// 禁用编辑器
    /// </summary>
    public ValueTask DisableAsync() => _vditor.InvokeVoidAsync("disable");

    /// <summary>
    /// 聚焦编辑器。
    /// </summary>
    public ValueTask FocusAsync() => _vditor.InvokeVoidAsync("focus");
    /// <summary>
    /// 让编辑器失去焦点。
    /// </summary>
    public ValueTask BlurAsync() => _vditor.InvokeVoidAsync("blur");
    /// <summary>
    /// 销毁编辑器。
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_vditor is not null)
        {
          await  _vditor.InvokeVoidAsync("dispose");
        }
    }


    #region JS Callback
    [JSInvokable("invokeRendered")]
    public Task JSInvokeRenderedAsync()
    {
        _isInitialized = true;
        Options.OnRendered?.Invoke();
        return Task.CompletedTask;
    }

    [JSInvokable("invokeInput")]
    public async Task JSInvokeInputAsync(string? value)
    {
        Value = value;
        Options.OnInput?.Invoke(value);
        await ValueChanged.InvokeAsync(value);
    }

    [JSInvokable("invokeFocus")]
    public Task JSInvokeFocusAsync()
    {
        Options.OnFocus?.Invoke(Value);
        return Task.CompletedTask;
    }


    [JSInvokable("invokeBlur")]
    public Task JSInvokeBlurAsync()
    {
        Options.OnBlur?.Invoke(Value);
        return Task.CompletedTask;
    }


    [JSInvokable("invokeSelect")]
    public Task JSInvokeSelectAsync()
    {
        Options.OnSelect?.Invoke(Value);
        return Task.CompletedTask;
    }


    [JSInvokable("invokeEscape")]
    public Task JSInvokeEscapeAsync()
    {
        Options.OnEscape?.Invoke(Value);
        return Task.CompletedTask;
    }


    [JSInvokable("invokeCtrlEnter")]
    public Task JSInvokeCtrlEnterAsync()
    {
        Options.OnCtrlEnter?.Invoke(Value);
        return Task.CompletedTask;
    }

    #endregion
}
