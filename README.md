<p align="center"><img src="https://raw.githubusercontent.com/DouchChunFeng/CFServerMonitor/main/README_form.png" width="1024" alt="图片预览"></p>

# CF Server Monitor
- [功能](#gn)
- [用法](#yf)
- [依赖](#yl)
- [常见问题](#cjwt)

<a name="gn"></a>
## 功能

- 用于替代不支持挑战包的HLSM服务器监视器
- 通过进程判断和A2s判断服务器是否正常

<a name="yf"></a>
## 用法

1. 下载RELEASE中的 `cfmanager.exe` 即可运行.
2. 右键添加服务器.

<a name="yl"></a>
## 依赖

* [.Net FrameWork 4.0](https://referencesource.microsoft.com)
* [VS2013](https://learn.microsoft.com/zh-cn/visualstudio/releasenotes/vs2013-update5-vs)或更高版本编译

<a name="cjwt"></a>
## 常见问题

1. `为什么会产生二个txt文本`
- options_data.txt -> 用于保存配置信息
- servers_data.txt -> 用于保存服务器信息

---