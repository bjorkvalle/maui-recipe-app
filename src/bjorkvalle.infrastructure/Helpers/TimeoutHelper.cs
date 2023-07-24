namespace bjorkvalle.infrastructure.Helpers
{
    public static class TimeoutHelper
    {
        public static CancellationTokenSource SetTimeout(Action action, int timeout)
        {
            var cts = new CancellationTokenSource();
            var ct = cts.Token;
            Task.Delay(timeout).ContinueWith((Task task) =>
            {
                if (!ct.IsCancellationRequested)
                    action();
            }, ct);
            return cts;
        }

        public static void ClearTimeout(CancellationTokenSource cts) => cts.Cancel();
    }
}
