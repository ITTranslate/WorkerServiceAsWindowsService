# .NET Worker Service 作为 Windows Service 运行

<!-- [Read the related article](https://ittranslator.cn/dotnet/csharp/2021/05/31/worker-service-with-serilog.html). -->

基于 [WorkerServiceWithSerilog](https://github.com/ITTranslate/WorkerServiceWithSerilog) 项目修改。

```bash
git clone git@github.com:ITTranslate/WorkerServiceWithSerilog.git
```

## 添加必要的依赖库

```bash
dotnet add package Microsoft.Extensions.Hosting.WindowsServices
```

## 修改文件

修改的文件包含： *Program.cs*, *Worker.cs*

## 构建

```bash
dotnet build
```

## 安装服务

使用 sc.exe 实用工具安装和管理服务。

```bash
sc create MyService binPath= C:\test\workerpub\MyService.exe start= auto displayname= "技术译站的测试服务"

sc description MyService "这是一个由 Worker Service 实现的测试服务。"

sc start MyService

sc stop MyService

sc delete MyService
```
