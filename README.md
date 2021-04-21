# C# Threading - Initiate tasks on another thread in .NET

# **`UNDER CONTRUCTION`**
# **:construction: :construction: :construction: :construction: :construction:**


## Asyncromous Delegates - sincce the beginning of .NET

```s
Action<string> d = BackgroundTask;
d.BeginInvoke("BeginInvoke", null, null);
```

## Thread Class 

> Since the beginning of .NET

> Use this approach if need a dedicated thread for a single task that is running for the lifetime 

> of the application

```s
var t = new Thread(BackgroundTask);
t.Name = "My Thread";
t.Priority = ThreadPriority.AboveNormal;
t.Start("Thread");
```

## ThreadPool - Since .NET 1.1

> The method run on a thread from the thread pool just call `QueueUserWorkItem`

> If there are free threads it will start immediately, otherwise it will be queued up

> The disadvantage of this approach compared to the previous two is that it provides no mechanism for notification of when your task has finished. It’s up to you to report completion and catch exceptions.

```s
ThreadPool.QueueUserWorkItem(BackgroundTask, "ThreadPool");
```

## BackgroundWorker Component - Since .NET 2

> It covers all the basics of `reporting progress`, `cancellation`, `catching exceptions`, and `getting back onto the UI thread` so can update the user interface

```s
backgroundWorker1.DoWork += BackgroundWorker1OnDoWork;
```
and within that function you are able to report progress:
backgroundWorker1.ReportProgress(30, progressMessage);




## Task Parallel Library (TPL) - introduced in .NET 4


> same way that  kicked off a thread with the `ThreadPool`

```s
Task.Run(() => BackgroundTask("TPL"));
```

## C# 5 async await - introduced with C# 5 and .NET 4.5

> 
```s
await Task.Run(() => xdoc.Load(""));
```



## reference:

https://markheath.net/post/starting-threads-in-dotnet

https://www.c-sharpcorner.com/article/task-parallel-library-101-using-c-sharp/

https://www.c-sharpcorner.com/article/parallel-programming-using-tpl-in-net/