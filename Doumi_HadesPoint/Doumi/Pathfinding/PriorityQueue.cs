namespace Doumi.Pathfinding
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class PriorityQueue
    {
        protected List<PathFinder.Node> list = new List<PathFinder.Node>(0x1000);

        public void Clear()
        {
            this.list.Clear();
        }

        protected int Compare(PathFinder.Node x, PathFinder.Node y)
        {
            if (x.F > y.F)
            {
                return 1;
            }
            if (x.F >= y.F)
            {
                return 0;
            }
            return -1;
        }

        public PathFinder.Node Peek()
        {
            if (this.list.Count > 0)
            {
                return this.list[0];
            }
            return new PathFinder.Node();
        }

        public PathFinder.Node Pop()
        {
            PathFinder.Node node = this.list[0];
            int i = 0;
            this.list[0] = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            while (true)
            {
                int j = i;
                int num3 = (2 * i) + 1;
                int num4 = (2 * i) + 2;
                if ((this.list.Count > num3) && (this.Compare(this.list[i], this.list[num3]) > 0))
                {
                    i = num3;
                }
                if ((this.list.Count > num4) && (this.Compare(this.list[i], this.list[num4]) > 0))
                {
                    i = num4;
                }
                if (i == j)
                {
                    return node;
                }
                this.SwitchElements(i, j);
            }
        }

        public int Push(PathFinder.Node item)
        {
            int count = this.list.Count;
            this.list.Add(item);
            while (count != 0)
            {
                int j = (count - 1) / 2;
                if (this.Compare(this.list[count], this.list[j]) >= 0)
                {
                    return count;
                }
                this.SwitchElements(count, j);
                count = j;
            }
            return count;
        }

        public void Remove(PathFinder.Node item)
        {
            int index = -1;
            for (int i = 0; i < this.list.Count; i++)
            {
                if (this.Compare(this.list[i], item) == 0)
                {
                    index = i;
                }
            }
            if (index != -1)
            {
                this.list.RemoveAt(index);
            }
        }

        protected void SwitchElements(int i, int j)
        {
            PathFinder.Node node = this.list[i];
            this.list[i] = this.list[j];
            this.list[j] = node;
        }

        private void Update(int i)
        {
            int num = i;
            while (num != 0)
            {
                int j = (num - 1) / 2;
                if (this.Compare(this.list[num], this.list[j]) >= 0)
                {
                    break;
                }
                this.SwitchElements(num, j);
                num = j;
            }
            if (num < i)
            {
                return;
            }
            while (true)
            {
                int j = num;
                int num4 = (2 * num) + 1;
                int num5 = (2 * num) + 2;
                if ((this.list.Count > num4) && (this.Compare(this.list[num], this.list[num4]) > 0))
                {
                    num = num4;
                }
                if ((this.list.Count > num5) && (this.Compare(this.list[num], this.list[num5]) > 0))
                {
                    num = num5;
                }
                if (num == j)
                {
                    return;
                }
                this.SwitchElements(num, j);
            }
        }

        public int Count =>
            this.list.Count;

        public PathFinder.Node this[int index]
        {
            get
            {
                return this.list[index];
            }
            set
            {
                this.list[index] = value;
                this.Update(index);
            }
        }
    }
}

