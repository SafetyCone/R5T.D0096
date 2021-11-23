using System;
using System.Collections.Concurrent;
using System.Threading;

using R5T.D0096.T001;


namespace R5T.D0096.D002.I002
{
    public class AsynchronousConsoleHumanOutputSink : IHumanOutputSink
    {
        private const int MaximumQueuedMessageCount = 1024;


        #region Static

        private static void ActuallyWriteLogMessage(string message)
        {
            // Use the thread-safe exclusive usage context.
            Instances.Console.Write(message);
        }

        #endregion


        private BlockingCollection<string> MessageCollection { get; } = new BlockingCollection<string>(AsynchronousConsoleHumanOutputSink.MaximumQueuedMessageCount);
        private Thread OutputThread { get; set; }

        public AsynchronousConsoleHumanOutputSink()
        {
            this.OutputThread = new Thread(this.ProcessMessageQueue)
            {
                Name = "Console human output queue proccessing thread",
                IsBackground = true,
            };
            this.OutputThread.Start();
        }

        public void Dispose()
        {
            this.MessageCollection.CompleteAdding();

            GC.SuppressFinalize(this);
        }

        public void Write(string text)
        {
            // Adds a message to the queue rather than actually writing.

            // Check if the blocking collection is actually usable.
            if (!this.MessageCollection.IsAddingCompleted)
            {
                var added = this.MessageCollection.TryAdd(text);
                if (added)
                {
                    return;
                }
            }

            // If the blocking collection is unusable (the adding phase of its lifetime is completed, or it is full) then just spend the time to actually write the message.
            AsynchronousConsoleHumanOutputSink.ActuallyWriteLogMessage(text);
        }

        private void ProcessMessageQueue()
        {
            //try
            //{
            foreach (var message in this.MessageCollection.GetConsumingEnumerable())
            {
                AsynchronousConsoleHumanOutputSink.ActuallyWriteLogMessage(message);
            }
            //}
        }
    }
}
