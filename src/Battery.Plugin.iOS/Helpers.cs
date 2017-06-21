using Foundation;
using System;

namespace Plugin.Battery
{
    static class Helpers
    {
        static NSObject Invoker;
        /// <summary>
        /// Ensures the invoked on main thread.
        /// </summary>
        /// <param name="action">Action to run on main thread.</param>
        public static void EnsureInvokedOnMainThread(Action action)
        {
            if (NSThread.Current.IsMainThread)
            {
                action();
                return;
            }
            if (Invoker == null)
                Invoker = new NSObject();

            Invoker.BeginInvokeOnMainThread(() => action());
        }
    }
}
