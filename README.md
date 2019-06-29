# AbpDemoJobs
Abp VNext BackgroundJobs 后台任务Demo

## 初始化数据库（mysql)
```
dotnet ef database update
```
## 运行
```
dotnet run .
```
## 新增一个后台jobs,往数据库写入一条记录，
```
insert into AbpBackgroundJobs (Id,JobName,JobArgs,Priority,CreationTime,NextTryTime) values ('56cde1a9-d46c-a144-03d9-39eeb5c4b6f6',"YellowJob",'{"value":"test 2 (yellow) tesddfa","time":"2019-06-29T22:16:07.6691957+08:00"}',25,sysdate(),sysdate());
```
