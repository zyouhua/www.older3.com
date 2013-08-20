using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace platform
{
    public class OncePool
    {
        public IRunnable _popFront()
        {
            if (false == mInit)
            {
                throw new Exception();
            }
            IRunnable result_ = null;
            mRunnables.TryDequeue(out result_);
            return result_;
        }

        public void _pushBack(IRunnable nRunnable)
        {
            if (false == mInit)
            {
                throw new Exception();
            }
            bool status_ = false;
            foreach (Once once_ in mOnces)
            {
                status_ = once_._runRunnable(nRunnable);
                if (true == status_)
                {
                    break;
                }
            }
            if (true == status_)
            {
                return;
            }
            if (mOnces.Count < mSize)
            {
                Once once_ = new Once(this);
                once_._runRunnable(nRunnable);
                mOnces.Add(once_);
                status_ = true;
            }
            if (true == status_)
            {
                return;
            }
            mRunnables.Enqueue(nRunnable);
        }

        public void _runInit(int nSize = 5)
        {
            mInit = true;
            mSize = nSize;
            mOnces = new ConcurrentBag<Once>();
            mRunnables = new ConcurrentQueue<IRunnable>();
        }

        public OncePool()
        {
            mInit = false;
            mSize = -1;
            mOnces = null;
            mRunnables = null;
        }

        bool mInit;
        int mSize;
        ConcurrentBag<Once> mOnces;
        ConcurrentQueue<IRunnable> mRunnables;
    }
}
