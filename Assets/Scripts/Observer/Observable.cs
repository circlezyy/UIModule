using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.Core
{
    public class Observable : IObservable
    {
        static protected List<ObserverNode> cachedNode;
        protected ObserverNode Current;
        protected ObserverNode Start;

        public Observable()
        {
            if (cachedNode == null)
                cachedNode = new List<ObserverNode>();
        }

        public IObservable AddObserver(IObserver observer)
        {
            if (observer != null)
            {
                var node = GetNode(observer);
                if (Current == null)
                {
                    Start = Current = node;
                }
                else
                {
                    Current.next = node;
                    node.pre = Current;
                    Current = node;
                }
            }
            return this;
        }

        public IObservable RemoveObserver(IObserver observer)
        {
            if (Current == null || observer == null) return null;

            ObserverNode node = null;
            if (Start.source == observer)
            {
                node = Start;
                if (Start.next == null)
                {
                    Start = Current = null;
                }
                else
                {
                    Start = Start.next;
                }
            }
            else if (Current.source == observer)
            {
                node = Current;
                Current.pre.next = null;
                Current = Current.pre;
            }
            else
            {
                node = Start.next;
                while (node != null)
                {
                    if (node.source == observer)
                    {
                        node.pre.next = node.next;
                        node.next.pre = node.pre;
                        break;
                    }
                    node = node.next;
                }
            }


            if (node != null)
                ReturnNode(node);
            return this;
        }

        ObserverNode GetNode(IObserver observer)
        {
            ObserverNode node;
            if (cachedNode.Count > 0)
            {
                var tailIndex = cachedNode.Count - 1;
                node = cachedNode[tailIndex];
                cachedNode.RemoveAt(tailIndex);
            }
            else
            {
                node = new ObserverNode();
            }
            node.source = observer;
            return node;
        }

        void ReturnNode(ObserverNode node)
        {
            node.pre = node.next = null;
            node.source = null;
            cachedNode.Add(node);
        }

        public void Publish(string notification, object sender, object data = null)
        {
            if (Start == null) return;

            ObserverNode node = Start;
            List<IObserver> observerList = new List<IObserver>();

            while (node != null)
            {
                observerList.Add(node.source);
                node = node.next;
            }

            IObserver observer;
            for (int i = 0; i < observerList.Count; i++)
            {
                observer = observerList[i];
                observerList[i].OnNotification(notification, sender, data);
            }
        }

        public virtual void Clear()
        {
            while (Current != null)
            {
                var node = Current;
                Current = Current.pre;
                ReturnNode(node);
            }
            Start = Current = null;
        }
    }

    public class ObserverNode
    {
        public ObserverNode pre;
        public ObserverNode next;
        public IObserver source;
    }

}
