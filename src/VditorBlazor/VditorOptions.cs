namespace VditorBlazor;

/// <summary>
/// Vditor 的配置。
/// </summary>
public class VditorOptions
{
    /// <summary>
    /// 自动渲染编辑器。
    /// </summary>
    public bool AutoInitialize { get; set; } = true;
    /// <summary>
    /// 编辑器主题。默认 <see cref="Theme.Classic"/>。
    /// </summary>
    public Theme Theme { get; set; } = Theme.Classic;
    /// <summary>
    /// 编辑器模式。默认 <see cref="Mode.IR"/>。
    /// </summary>
    public Mode Mode { get; set; } = Mode.IR;
    /// <summary>
    /// 显示的语言。默认 <see cref="Language.SimplifiedChinese"/>。
    /// </summary>
    public Language Language { get; set; } = Language.SimplifiedChinese;

    /// <summary>
    /// 图标风格。
    /// </summary>
    public IconStyle IconStyle { get; set; } = IconStyle.Ant;

    /// <summary>
    /// 是否输出日志。
    /// </summary>
    public bool Debug { get; set; }

    /// <summary>
    /// 输入区域为空时的提示。
    /// </summary>
    public string? Placeholder { get; set; }

    /// <summary>
    /// 编辑器总宽度。
    /// </summary>
    public string? Width { get; set; } = "auto";
    /// <summary>
    /// 编辑器总高度。
    /// </summary>
    public string? Height { get; set; } = "auto";
    /// <summary>
    /// 编辑区域最小高度。
    /// </summary>
    public string? MinHeight { get; set; }
    /// <summary>
    /// 配置自建 CDN 地址。
    /// </summary>
    public string? CDN { get; set; }

    /// <summary>
    /// 按下 <c>tab</c> 键操作的字符串。
    /// </summary>
    public string? Tab { get; set; }

    /// <summary>
    /// 回撤的延迟时间。
    /// </summary>
    public int? UndoDelay { get; set; }

    /// <summary>
    /// 是否启用打字机模式。
    /// </summary>
    public bool TypeWriterMode { get; set; }

    /// <summary>
    /// 编辑器异步渲染完成后的回调方法。
    /// </summary>
    public Action? OnRendered { get; set; }

    /// <summary>
    /// 当文本输入后触发的委托。
    /// </summary>
    public Action<string?>? OnInput { get; set; }

    /// <summary>
    /// 当编辑器聚焦后触发的委托。
    /// </summary>
    public Action<string?>? OnFocus { get; set; }
    /// <summary>
    /// 当编辑器失去焦点后触发的委托。
    /// </summary>
    public Action<string?>? OnBlur { get; set; }

    /// <summary>
    /// 当按下 <c>Esc</c> 键后触发的委托。
    /// </summary>
    public Action<string?>? OnEscape { get; set; }
    /// <summary>
    /// 当按下 <c>ctrl</c> 和 <c>Enter</c> 键后触发的委托。
    /// </summary>
    public Action<string?>? OnCtrlEnter { get; set; }
    /// <summary>
    /// 当编辑器中选中文字后触发的委托。
    /// </summary>
    public Action<string?>? OnSelect { get; set; }
}
