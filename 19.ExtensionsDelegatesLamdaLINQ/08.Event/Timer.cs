﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _07.Delegates
{
    public delegate void MyDelegate();
    class Timer
    {
        private int delay; //delay in milliseconds
        private int count; //the count of executions of the method
        private MyDelegate target;

        public delegate void CustomEventHandler(object sender, CustomEventArgs a);
        public event EventHandler RaiseCustomEvent;

        public Timer(int delay, int count)
        {
            this.delay = delay;
            this.count = count;
        }

        protected virtual void OnRaiseCustomEvent(int countLeft)
        {
            EventHandler handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                CustomEventArgs e = new CustomEventArgs(countLeft);

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        public void Repeat(MyDelegate target)
        {
            int i = 0;
            this.target = target;
            while (i<count)
            {
                this.target();
                Thread.Sleep(delay);
                OnRaiseCustomEvent(count - i);
                i++;
            }
        }
    }
}
