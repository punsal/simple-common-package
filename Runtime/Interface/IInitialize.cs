using Common.Runtime.Args.Interface;

namespace Common.Runtime.Interface
{
    public interface IInitialize
    {
        void Initialize();
    }

    public interface IInitialize<in T> where T : IInitializeArgs
    {
        void Initialize(T args);
    }
}