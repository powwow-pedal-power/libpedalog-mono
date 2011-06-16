namespace Pedalog
{
    public class NoDeviceFoundException : PedalogException
    {
        public NoDeviceFoundException()
            : base(Result.NoDeviceFound)
        {
        }
    }
}
