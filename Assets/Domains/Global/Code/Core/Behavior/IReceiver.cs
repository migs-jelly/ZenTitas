namespace Domains.Global.Code.Core.Behavior
{
    public interface IReceiver
    {
        void Execute();
    }

    public interface IReceiver<in T>
    {
        void Execute(T data);
    }
}