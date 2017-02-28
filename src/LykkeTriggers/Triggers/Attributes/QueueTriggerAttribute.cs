﻿using System;
using LykkeTriggers.Implementations.QueueReader;

namespace LykkeTriggers.Triggers.Attributes
{
    public class QueueTriggerAttribute : Attribute
    {
        public string Queue { get; }
        public int MaxPollingIntervalMs { get; }
        public bool Notify { get; }

        public string Connection { get; set; }

        public QueueTriggerAttribute(string queue, int maxPollingIntervalMs = -1, bool notify = false, string connection = ConnectionPool.DefaultConnection)
        {
            Queue = queue;
            MaxPollingIntervalMs = maxPollingIntervalMs;
            Notify = notify;
            Connection = connection;
        }
    }
}
