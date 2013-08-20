using System.Threading;

namespace platform
{
    public class Once
    {
        public bool _runRunnable(IRunnable nRunable)
        {
            bool result_ = false;
            lock (mLock)
            {
                if (false == mRunning)
                {
                    mRunnable = nRunable;
                    mRunning = true;
                    result_ = true;
                }
            }
            if (true == result_)
            {
                mThread.Interrupt();
            }
            return result_;
        }

        void _runOnce()
        {
            for ( ; ; )
            {
                if (null == mRunnable)
                {
                    lock (mLock)
                    {
                        mRunning = false;
                    }
                    try
                    {
                        Thread.Sleep(-1);
                    }
                    catch (ThreadInterruptedException)
                    {
                    }
                    finally
                    {
                    }
                    lock (mLock)
                    {
                        mRunning = true;
                    }
                }
                if (null != mRunnable)
                {
                    mRunnable._runRunnable();
                }
                mRunnable = mOncePool._popFront();
            }
        }

        public Once(OncePool nOncePool)
        {
            mLock = new object();
            mRunning = false;
            mOncePool = nOncePool;
            mRunnable = null;
            mThread = new Thread(new ThreadStart(_runOnce));
            mThread.Start();
        }

        object mLock;
        bool mRunning;
        Thread mThread;
        OncePool mOncePool;
        IRunnable mRunnable;
    }
}
