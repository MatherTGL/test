namespace Time_Control
{
    public interface ITimeControl
    {
        void Initialization();
        void RecalculateTime(in byte month, in short Year);
    }
}