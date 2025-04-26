using StarWars.Explorer.Infrastructure;

namespace StarWars.Explorer.Services
{
    public abstract class BaseService
    {
        private readonly IExceptionInterceptor _exceptionInterceptor;

        protected BaseService(IExceptionInterceptor exceptionInterceptor)
        {
            _exceptionInterceptor = exceptionInterceptor;
        }

        protected T Execute<T>(Func<T> action, string context = null)
        {
            return _exceptionInterceptor.Execute(action, context);
        }

        protected void Execute(Action action, string context = null)
        {
            _exceptionInterceptor.Execute(action, context);
        }

        protected Task<T> ExecuteAsync<T>(Func<Task<T>> action, string context = null)
        {
            return _exceptionInterceptor.ExecuteAsync(action, context);
        }

        protected Task ExecuteAsync(Func<Task> action, string context = null)
        {
            return _exceptionInterceptor.ExecuteAsync(action, context);
        }
    }
}