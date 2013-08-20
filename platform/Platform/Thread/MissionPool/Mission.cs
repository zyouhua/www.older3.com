using System;

namespace platform
{
    public class Mission
    {
        public void _runMission()
        {
            lock (mLock)
            {
                if (true == mRunning)
                {
                    return;
                }
                mRunning = true;
            }
            mDateTime = DateTime.Now;
            mRunnable._runRunnable();
            mDateTime = DateTime.Now;
            lock (mLock)
            {
                mRunning = false;
            }
        }

        public bool _isRunning()
        {
            bool result_ = false;
            lock (mLock)
            {
                result_ = mRunning;
            }
            return result_;
        }

        public double _getTimeSpan()
        {
            return (DateTime.Now - mDateTime).TotalMilliseconds;
        }

        public Mission(IRunnable nRunnable)
        {
            mRunnable = nRunnable;
            mDateTime = DateTime.Now;
            mLock = new object();
            mRunning = false;
        }

        IRunnable mRunnable;
        DateTime mDateTime;
        bool mRunning;
        object mLock;
    }
}
