using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelperClasses
{
    public static class FunctionHelpers
    {

        public static void RetryAction(Action action, int maxTries, int retryDelay)
        {
            if (action == null)
                throw new ArgumentNullException("action"); // slightly safer...

            for (int i = 0; i < maxTries; i++)
            {
                try { action(); return; }
                catch { if (i == maxTries - 1) throw; }
                Debug.WriteLine("Retry " + i);
                Thread.Sleep(retryDelay);
            }
        }

        public static T RetryOnFault<T>(Func<T> function, int maxTries)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { return function(); }
                catch { if (i == maxTries - 1) throw; }
            }
            return default(T);
        }

        #region VOID

        public static async Task RetryIndefinatelyOnFaultAsync(Func<Task> function, int retryDelay)
        {
            for (; ; )
            {
                try { await function().ConfigureAwait(false); return; }
                catch { if (false) throw; }
                await Task.Delay(retryDelay).ConfigureAwait(false);
            }
        }

        public static async Task RetryOnFaultAsync(Func<Task> function, int maxTries)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { await function().ConfigureAwait(false); return; }
                catch { if (i == maxTries - 1) throw; }
            }
        }

        public static async Task RetryOnFaultAsync(Func<Task> function, int maxTries, Func<Task> retryWhen)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { await function().ConfigureAwait(false); return; }
                catch { if (i == maxTries - 1) throw; }
                await retryWhen().ConfigureAwait(false);
            }
        }

        public static async Task RetryOnFaultAsync(Func<Task> function, int maxTries, int retryDelay)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { await function().ConfigureAwait(false); return; }
                catch { if (i == maxTries - 1) throw; }
                await Task.Delay(retryDelay).ConfigureAwait(false);
            }
        }

        #endregion

        #region Typed

        public static async Task<T> RetryOnFaultAsync<T>(Func<Task<T>> function, int maxTries)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { return await function().ConfigureAwait(false); }
                catch { if (i == maxTries - 1) throw; }
            }
            return default(T);
        }

        public static async Task<T> RetryOnFaultAsync<T>(Func<Task<T>> function, int maxTries, Func<Task> retryWhen)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { return await function().ConfigureAwait(false); }
                catch { if (i == maxTries - 1) throw; }
                await retryWhen().ConfigureAwait(false);
            }
            return default(T);
        }

        public static async Task<T> RetryOnFaultAsync<T>(Func<Task<T>> function, int maxTries, int retryDelay)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { return await function().ConfigureAwait(false); }
                catch { if (i == maxTries - 1) throw; }
                await Task.Delay(retryDelay).ConfigureAwait(false);
            }
            return default(T);
        }

        #endregion

    }
}
