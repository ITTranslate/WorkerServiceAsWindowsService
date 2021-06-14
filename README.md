# Worker Service 添加 Serilog 日志

[Read the related article](https://ittranslator.cn/dotnet/csharp/2021/05/31/worker-service-with-serilog.html).

基于 [WorkerServiceGracefullyShutdown](https://github.com/ITTranslate/WorkerServiceGracefullyShutdown) 项目修改。

```bash
git clone git@github.com:ITTranslate/WorkerServiceGracefullyShutdown.git
```

## 添加必要的依赖库

Serilog 文档：<https://serilog.net/>

```bash
dotnet add package Serilog
dotnet add package Serilog.Settings.Configuration
dotnet add package Serilog.Extensions.Hosting
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.RollingFile
```

```bash
dotnet add package Serilog.Enrichers.Thread
dotnet add package Serilog.Enrichers.Environment
dotnet add package Serilog.Enrichers.Process
```

```bash
dotnet add package Serilog.Sinks.SQLite
```

## 修改文件

修改的文件包含： *appsettings.json*, *Program.cs*

## 运行

```bash
dotnet build
dotnet run
```
