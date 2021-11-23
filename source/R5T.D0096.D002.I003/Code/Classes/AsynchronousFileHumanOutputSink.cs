using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

using R5T.D0096.T001;


namespace R5T.D0096.D002.I003
{
    public class AsynchronousFileHumanOutputSink : IHumanOutputSink
    {
        private const int MaximumQueuedMessageCount = 1024;


        private BlockingCollection<string> MessageCollection { get; } = new BlockingCollection<string>(AsynchronousFileHumanOutputSink.MaximumQueuedMessageCount);
        private TextWriter TextWriter { get; }
        private Thread OutputThread { get; set; }


        public AsynchronousFileHumanOutputSink(
            TextWriter textWriter)
        {
            this.TextWriter = textWriter;

            this.OutputThread = new Thread(this.ProcessMessageQueue)
            {
                Name = "File human output queue proccessing thread",
                IsBackground = true,
            };
            this.OutputThread.Start();
        }

        public void Dispose()
        {
            this.MessageCollection.CompleteAdding();

            this.TextWriter.Dispose();

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
            this.ActuallyWriteLogMessage(text);
        }

        private void ProcessMessageQueue()
        {
            //try
            //{
            foreach (var message in this.MessageCollection.GetConsumingEnumerable())
            {
                this.ActuallyWriteLogMessage(message);
            }
            //}
        }

        private void ActuallyWriteLogMessage(string message)
        {
            this.TextWriter.Write(message);
        }
    }
}
