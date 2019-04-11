namespace Doumi.Pathfinding
{
    using Doumi.Types;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class PathFinder
    {
        private static int[] directionx;
        private static int[] directiony;
        private Field field;
        private PriorityQueue open = new PriorityQueue();
        private List<Node> shut = new List<Node>();

        static PathFinder()
        {
            int[] numArray = new int[4];
            numArray[1] = 1;
            numArray[3] = -1;
            directionx = numArray;
            int[] numArray2 = new int[4];
            numArray2[0] = -1;
            numArray2[2] = 1;
            directiony = numArray2;
        }

        public PathFinder(Field field)
        {
            this.field = field;
        }

        public List<Node> Find(int x1, int y1, int x2, int y2)
        {
            if (this.field[x2, y2].Solid)
            {
                return null;
            }
            bool flag = false;
            this.open.Clear();
            this.shut.Clear();
            Node node3 = new Node {
                G = 0
            };
            Node a = node3;
            a.H = this.GetHeuristic(a, x2, y2);
            a.F = a.G + a.H;
            a.X = x1;
            a.Y = y1;
            a.ParentX = a.X;
            a.ParentY = a.Y;
            this.open.Push(a);
            while (this.open.Count > 0)
            {
                a = this.open.Pop();
                if ((a.X == x2) && (a.Y == y2))
                {
                    this.shut.Add(a);
                    flag = true;
                    break;
                }
                for (int j = 0; j < 4; j++)
                {
                    node3 = new Node {
                        X = a.X + directionx[j],
                        Y = a.Y + directiony[j]
                    };
                    Node node4 = node3;
                    if ((((node4.X >= 0) && (node4.X < this.field.Cols)) && ((node4.Y >= 0) && (node4.Y < this.field.Rows))) && !this.field[node4.X, node4.Y].Solid)
                    {
                        node4.G = a.G + 10;
                        int num2 = -1;
                        if (((a.X - a.ParentX) + a.X) != node4.X)
                        {
                            node4.G += 10;
                        }
                        if (((a.Y - a.ParentY) + a.Y) != node4.Y)
                        {
                            node4.G += 10;
                        }
                        for (int k = 0; k < this.open.Count; k++)
                        {
                            if ((this.open[k].X == node4.X) && (this.open[k].Y == node4.Y))
                            {
                                num2 = k;
                                break;
                            }
                        }
                        if ((num2 == -1) || (this.open[num2].G > node4.G))
                        {
                            int num4 = -1;
                            for (int m = 0; m < this.shut.Count; m++)
                            {
                                if ((this.shut[m].X == node4.X) && (this.shut[m].Y == node4.Y))
                                {
                                    num4 = m;
                                    break;
                                }
                            }
                            if ((num4 == -1) || (this.shut[num4].G > node4.G))
                            {
                                node4.ParentX = a.X;
                                node4.ParentY = a.Y;
                                node4.H = this.GetHeuristic(node4, x2, y2);
                                node4.F = node4.G + node4.H;
                                this.open.Push(node4);
                            }
                        }
                    }
                }
                this.shut.Add(a);
            }
            if (!flag)
            {
                return null;
            }
            Node node2 = this.shut[this.shut.Count - 1];
            for (int i = this.shut.Count - 1; i >= 0; i--)
            {
                if (((node2.ParentX == this.shut[i].X) && (node2.ParentY == this.shut[i].Y)) || (i == (this.shut.Count - 1)))
                {
                    node2 = this.shut[i];
                }
                else
                {
                    this.shut.RemoveAt(i);
                }
            }
            return this.shut;
        }

        public List<Node> FindWithAisling(int x1, int y1, int x2, int y2)
        {
            if (((this.field[x2, y2].Solid || this.field.IsMonster(x2, y2)) || this.field.IsAisling(x2, y2)) || this.field.IsMundane(x2, y2))
            {
                return null;
            }
            bool flag = false;
            this.open.Clear();
            this.shut.Clear();
            Node node3 = new Node {
                G = 0
            };
            Node a = node3;
            a.H = this.GetHeuristic(a, x2, y2);
            a.F = a.G + a.H;
            a.X = x1;
            a.Y = y1;
            a.ParentX = a.X;
            a.ParentY = a.Y;
            this.open.Push(a);
            while (this.open.Count > 0)
            {
                a = this.open.Pop();
                if ((a.X == x2) && (a.Y == y2))
                {
                    this.shut.Add(a);
                    flag = true;
                    break;
                }
                for (int j = 0; j < 4; j++)
                {
                    node3 = new Node {
                        X = a.X + directionx[j],
                        Y = a.Y + directiony[j]
                    };
                    Node node4 = node3;
                    if ((((node4.X >= 0) && (node4.X < this.field.Cols)) && ((node4.Y >= 0) && (node4.Y < this.field.Rows))) && (((!this.field[node4.X, node4.Y].Solid && !this.field.IsMonster(node4.X, node4.Y)) && !this.field.IsMundane(node4.X, node4.Y)) && !this.field.IsAisling(node4.X, node4.Y)))
                    {
                        node4.G = a.G + 10;
                        int num2 = -1;
                        if (((a.X - a.ParentX) + a.X) != node4.X)
                        {
                            node4.G += 10;
                        }
                        if (((a.Y - a.ParentY) + a.Y) != node4.Y)
                        {
                            node4.G += 10;
                        }
                        for (int k = 0; k < this.open.Count; k++)
                        {
                            if ((this.open[k].X == node4.X) && (this.open[k].Y == node4.Y))
                            {
                                num2 = k;
                                break;
                            }
                        }
                        if ((num2 == -1) || (this.open[num2].G > node4.G))
                        {
                            int num4 = -1;
                            for (int m = 0; m < this.shut.Count; m++)
                            {
                                if ((this.shut[m].X == node4.X) && (this.shut[m].Y == node4.Y))
                                {
                                    num4 = m;
                                    break;
                                }
                            }
                            if ((num4 == -1) || (this.shut[num4].G > node4.G))
                            {
                                node4.ParentX = a.X;
                                node4.ParentY = a.Y;
                                node4.H = this.GetHeuristic(node4, x2, y2);
                                node4.F = node4.G + node4.H;
                                this.open.Push(node4);
                            }
                        }
                    }
                }
                this.shut.Add(a);
            }
            if (!flag)
            {
                return null;
            }
            Node node2 = this.shut[this.shut.Count - 1];
            for (int i = this.shut.Count - 1; i >= 0; i--)
            {
                if (((node2.ParentX == this.shut[i].X) && (node2.ParentY == this.shut[i].Y)) || (i == (this.shut.Count - 1)))
                {
                    node2 = this.shut[i];
                }
                else
                {
                    this.shut.RemoveAt(i);
                }
            }
            return this.shut;
        }

        public List<Node> FindWithMonster(int x1, int y1, int x2, int y2)
        {
            if ((this.field[x2, y2].Solid || this.field.IsMonster(x2, y2)) || this.field.IsAisling(x2, y2))
            {
                return null;
            }
            bool flag = false;
            this.open.Clear();
            this.shut.Clear();
            Node node3 = new Node {
                G = 0
            };
            Node a = node3;
            a.H = this.GetHeuristic(a, x2, y2);
            a.F = a.G + a.H;
            a.X = x1;
            a.Y = y1;
            a.ParentX = a.X;
            a.ParentY = a.Y;
            this.open.Push(a);
            while (this.open.Count > 0)
            {
                a = this.open.Pop();
                if ((a.X == x2) && (a.Y == y2))
                {
                    this.shut.Add(a);
                    flag = true;
                    break;
                }
                for (int j = 0; j < 4; j++)
                {
                    node3 = new Node {
                        X = a.X + directionx[j],
                        Y = a.Y + directiony[j]
                    };
                    Node node4 = node3;
                    if ((((node4.X >= 0) && (node4.X < this.field.Cols)) && ((node4.Y >= 0) && (node4.Y < this.field.Rows))) && ((!this.field[node4.X, node4.Y].Solid && !this.field.IsMonster(node4.X, node4.Y)) && !this.field.IsAisling(node4.X, node4.Y)))
                    {
                        node4.G = a.G + 10;
                        int num2 = -1;
                        if (((a.X - a.ParentX) + a.X) != node4.X)
                        {
                            node4.G += 10;
                        }
                        if (((a.Y - a.ParentY) + a.Y) != node4.Y)
                        {
                            node4.G += 10;
                        }
                        for (int k = 0; k < this.open.Count; k++)
                        {
                            if ((this.open[k].X == node4.X) && (this.open[k].Y == node4.Y))
                            {
                                num2 = k;
                                break;
                            }
                        }
                        if ((num2 == -1) || (this.open[num2].G > node4.G))
                        {
                            int num4 = -1;
                            for (int m = 0; m < this.shut.Count; m++)
                            {
                                if ((this.shut[m].X == node4.X) && (this.shut[m].Y == node4.Y))
                                {
                                    num4 = m;
                                    break;
                                }
                            }
                            if ((num4 == -1) || (this.shut[num4].G > node4.G))
                            {
                                node4.ParentX = a.X;
                                node4.ParentY = a.Y;
                                node4.H = this.GetHeuristic(node4, x2, y2);
                                node4.F = node4.G + node4.H;
                                this.open.Push(node4);
                            }
                        }
                    }
                }
                this.shut.Add(a);
            }
            if (!flag)
            {
                return null;
            }
            Node node2 = this.shut[this.shut.Count - 1];
            for (int i = this.shut.Count - 1; i >= 0; i--)
            {
                if (((node2.ParentX == this.shut[i].X) && (node2.ParentY == this.shut[i].Y)) || (i == (this.shut.Count - 1)))
                {
                    node2 = this.shut[i];
                }
                else
                {
                    this.shut.RemoveAt(i);
                }
            }
            return this.shut;
        }

        private int GetHeuristic(Node a, int goalx, int goaly) => 
            ((Math.Abs((int) (a.X - goalx)) + Math.Abs((int) (a.Y - goaly))) * 10);

        [StructLayout(LayoutKind.Sequential)]
        public struct Node
        {
            public int F;
            public int G;
            public int H;
            public int X;
            public int Y;
            public int ParentX;
            public int ParentY;
        }
    }
}

