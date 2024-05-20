using System.Linq.Expressions;
using ArtQuiz.Application;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using Hangfire;
using Hangfire.States;

namespace ArtQuiz.Infrastructure;

public class HangfireBackgroundJobScheduler : IBackgroundJobScheduler
{
    private readonly IBackgroundJobClient _backgroundJobClient;

    public HangfireBackgroundJobScheduler(IBackgroundJobClient backgroundJobClient) =>
        _backgroundJobClient = backgroundJobClient;

    public string Enqueue<T>(Expression<Func<T, Task>> methodCall) =>
        _backgroundJobClient.Create(methodCall, new EnqueuedState());

    public string Enqueue<T>(Expression<Func<T, Task>> methodCall, TimeSpan delay) =>
        _backgroundJobClient.Schedule(methodCall, delay);
}