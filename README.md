# .NET Worker Service 作为 Windows Service 运行

<!-- [Read the related article](https://ittranslator.cn/dotnet/csharp/2021/05/31/worker-service-with-serilog.html). -->

基于 [WorkerServiceWithSerilog](https://github.com/ITTranslate/WorkerServiceWithSerilog) 项目修改。

```bash
git clone git@github.com:ITTranslate/WorkerServiceWithSerilog.git
```

## 添加必要的依赖库

Serilog 文档：<https://serilog.net/>

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
