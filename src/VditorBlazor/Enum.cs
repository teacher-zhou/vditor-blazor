using System.ComponentModel;

namespace VditorBlazor;

/// <summary>
/// 编辑器主题。
/// </summary>
public enum Theme
{
    /// <summary>
    /// 经典。
    /// </summary>
    Classic,
    /// <summary>
    /// 黑暗。
    /// </summary>
    Dark
}

/// <summary>
/// 渲染的主题。
/// </summary>
public enum ContentTheme
{
    /// <summary>
    /// Ant design 风格。
    /// </summary>
    [DefaultValue("ant-design")] AntDesign,
    /// <summary>
    /// 亮色风格。
    /// </summary>
    [DefaultValue("light")] Light,
    /// <summary>
    /// 暗色风格。
    /// </summary>
    [DefaultValue("dark")] Dark,
    /// <summary>
    /// 微信风格。
    /// </summary>
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
    /// 左右分屏。
    /// </summary>
    SV
}

/// <summary>
/// 语言种类。
/// </summary>
public enum Language
{
    /// <summary>
    /// 英文。
    /// </summary>
    [DefaultValue("en_US")] English,
    /// <summary>
    /// 日语。
    /// </summary>
    [DefaultValue("ja_JP")] Japanese,
    /// <summary>
    /// 韩语。
    /// </summary>
    [DefaultValue("ko_KR")] Korean,
    /// <summary>
    /// 俄语。
    /// </summary>
    [DefaultValue("ru_RU")] Russian,
    /// <summary>
    /// 简体中文。
    /// </summary>
    [DefaultValue("zh_CN")] SimplifiedChinese,
    /// <summary>
    /// 繁体中文。
    /// </summary>
    [DefaultValue("zh_TW")] TraditionalChinese
}

/// <summary>
/// 图标风格。
/// </summary>
public enum IconStyle
{
    /// <summary>
    /// ant。
    /// </summary>
    Ant,
    /// <summary>
    /// material。
    /// </summary>
    Material
}