using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

namespace platform
{
    public class MissionPool
    {
        void _runMission()
        {
            for ( ; ; )
            {
                Mission mission_ = this._getMission();
                if (null != mission_)
                {
                    mission_._runMission();
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }

        Mission _getMission()
        {
            Mission result_ = null;
            IEnumerator<KeyValuePair<int, Mission>> enumerator_ = mUnFinish.GetEnumerator();
            while (enumerator_.MoveNext())
            {
                result_ = enumerator_.Current.Value;
                if (!result_._isRunning())
                {
                    break;
                }
                result_ = null;
            }
            if (null == result_)
            {
                lock (mLock)
                {
                    while (null == result_)
                    {
                        if (mRunIndex >= mMissions.Count)
                        {
                            mRunIndex = 0;
                        }
                        if (mMissions.Count > 0)
                        {
                            result_ = mMissions[mRunIndex];
                        }
                        else
                        {
                            break;
                        }
                        if (!result_._isRunning())
                        {
                            break;
                        }
                        result_ = null;
                    }
                }
            }
            return result_;
        }

        public void _pushBack(IRunnable nRunnable)
        {
            if (false == mInit)
            {
                throw new Exception();
            }
            Mission mission_ = new Mission(nRunnable);
            lock (mLock)
            {
                mMissions.Add(mission_);
            }
            LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
            logSingleton_._logError(@"MissionPool mMissions size: " + Convert.ToString(mMissions.Count));
        }

        public void _runInit(int nSize = 5)
        {
            mInit = true;
            mSize = nSize;
            mLock = new object();
            mThreads = new List<Thread>(nSize);
            for (int i = 0; i < nSize; ++i)
            {
                Thread thread_ = new Thread(new ThreadStart(_runMission));
                thread_.Start();
                mThreads.Add(thread_);
            }
            mUnFinish = new ConcurrentDictionary<int, Mission>();
            mMissions = new List<Mission>();
        }

        public MissionPool()
        {
            mUnFinish = null;
            mMissions = null;
            mThreads = null;
            mRunIndex = 0;
            mInit = false;
            mLock = null;
            mSize = -1;
        }
        ConcurrentDictionary<int, Mission> mUnFinish;
        List<Mission> mMissions;
        List<Thread> mThreads;
        int mRunIndex;
        object mLock;
        bool mInit;
        int mSize;
    }
}
