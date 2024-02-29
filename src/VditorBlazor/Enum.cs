using System.ComponentModel;

namespace VditorBlazor;

public enum Theme
{
    [DefaultValue("ant-design")] AntDesign,
    [DefaultValue("light")] Light,
    [DefaultValue("dark")] Dark,
    [DefaultValue("wechat")] WeChat
}

/// <summary>
/// 编辑器渲染模式。
/// </summary>
public enum Mode
{
    /// <summary>
    /// 所见即所得。
    /// </summary>
    WYSIWYG,
    /// <summary>
    /// 即使渲染。
    /// </summary>
    IR,
    /// <summary>
    /// 分屏。
    /// </summary>
    SV
}