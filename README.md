## `VditorBlazor` 基于 Vditor 封装的支持 Markdown 编辑器

1. 安装包
 
`> Install-Package VditorBlazor`

2. 添加服务

```cs
builder.Services.AddVditor(options => {
 //... 全局配置
})
```

3. 引用命名空间

`@using VditorBlazor`

4. 使用控件

```html
<!--全局配置-->
<Vditor @bind-Value="Content" />

<!--局部配置-->
<Vditor @bind-Value="Content" Configure="@(options => options.Theme = Dark)" />

@code{
	[Inject] HttpClient Client { get; set; }

	string? Content { get; set; } = "Hello World!!!";

	protected override async Task OnInitializedAsync()
	{
		Content = await Client.GetStringAsync("demo.md");
	}
}
```

