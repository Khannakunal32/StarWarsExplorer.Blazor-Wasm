namespace StarWars.Explorer.Infrastructure
{
    public interface IExceptionInterceptor
    {
        T Execute<T>(Func<T> action, string context = null);
        void Execute(Action action, string context = null);
        Task<T> ExecuteAsync<T>(Func<Task<T>> action, string context = null);
        Task ExecuteAsync(Func<Task> action, string context = null);
    }

    public class GlobalExceptionInterceptor : IExceptionInterceptor
    {
        private readonly ILogger<GlobalExceptionInterceptor> _logger;

        public GlobalExceptionInterceptor(ILogger<GlobalExceptionInterceptor> logger)
        {
            _logger = logger;
        }

        public T Execute<T>(Func<T> action, string context = null)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                LogException(ex, context);
                throw;
            }
        }

        public void Execute(Action action, string context = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                LogException(ex, context);
                throw;
            }
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action, string context = null)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                LogException(ex, context);
                throw;
            }
        }

        public async Task ExecuteAsync(Func<Task> action, string context = null)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                LogException(ex, context);
                throw;
            }
        }

        private void LogException(Exception ex, string context)
        {
            if (string.IsNullOrEmpty(context))
            {
                _logger.LogError(ex, "An unhandled exception occurred");
            }
            else
            {
                _logger.LogError(ex, "An unhandled exception occurred in context: {Context}", context);
            }
        }
    }
}