using Player;

namespace Time_Control
{
    public interface ITimeControl
    {
        void Initialization(in IConfigDataPlayer configDataPlayer);
        void RecalculateTime(in byte month, in short Year);
    }
}