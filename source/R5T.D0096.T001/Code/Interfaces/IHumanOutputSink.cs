using System;


namespace R5T.D0096.T001
{
    public interface IHumanOutputSink : IDisposable
    {
        void Write(string text);
    }
}
