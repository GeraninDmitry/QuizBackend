using System.Linq.Expressions;

namespace ArtQuiz.Application.Services.Interface;

public interface IBackgroundJobScheduler
{
    string Enqueue<T>(Expression<Func<T, Task>> methodCall);
    string Enqueue<T>(Expression<Func<T, Task>> methodCall, TimeSpan delay);
}