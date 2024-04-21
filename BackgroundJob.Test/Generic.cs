using System.Reflection;
using NSubstitute.Extensions;

namespace BackgroundJob.Test;

public static class Generic
{
  public static async Task InvokeMethodAsync<T>(T instance, string methodName) where T : class
  {
    var methodInfo = typeof(T)
      .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance)
       ?? throw new ArgumentException($"Method {methodName} not found in type {typeof(T).Name}");
    var resultTask = methodInfo.Invoke(instance, [CancellationToken.None]) as Task ?? Task.CompletedTask;
    await resultTask!.ConfigureAwait(false);
  }

  public static void InvokeMethod<T>(T instance, string methodName) where T : class
  {
    var methodInfo = typeof(T)
        .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance)
        ?? throw new ArgumentException($"Method {methodName} not found in type {typeof(T).Name}");

    methodInfo.Invoke(instance, null);
  }

}
