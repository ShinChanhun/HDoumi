namespace Doumi.Types
{
    using Doumi.Nexon.IO;
    using Doumi.Nexon.Net;
    using Doumi.Pathfinding;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class Field
    {
        public ConcurrentDictionary<uint, Aisling> Aislings = new ConcurrentDictionary<uint, Aisling>();
        public NexonMapFile Area;
        public ushort Cols;
        public ushort File;
        public byte Flag;
        public ushort Hash;
        public ConcurrentDictionary<uint, MapItem> MapItems = new ConcurrentDictionary<uint, MapItem>();
        public ConcurrentDictionary<uint, Monster> Monsters = new ConcurrentDictionary<uint, Monster>();
        public ConcurrentDictionary<uint, Mundane> Mundanes = new ConcurrentDictionary<uint, Mundane>();
        public string Name;
        private PathFinder pathFinder;
        public ushort Rows;

        public Field(NexonPacket packet)
        {
            this.File = packet.ReadU2();
            this.Cols = (ushort)packet.ReadU1();
            this.Rows = (ushort)packet.ReadU1();
            this.Flag = packet.ReadU1();
            this.Cols |= (ushort)((uint)packet.ReadU1() << 8);
            this.Rows |= (ushort)((uint)packet.ReadU1() << 8);
            this.Hash = packet.ReadU2();
            this.Name = packet.ReadC1();

            FileInfo fileInfo = new FileInfo("C:/Nexon/LodTest/maps/lod" + this.File + ".map");
            if (fileInfo.Exists)
                this.Area = NexonFileFormat<NexonMapFile>.FromStream((Stream)fileInfo.OpenRead());
            this.pathFinder = new PathFinder(this);
        }
        public bool method_0(ushort ushort_4)
        {
            ushort[] numArray = new ushort[8]
            {
      (ushort) 16921,
      (ushort) 16922,
      (ushort) 16923,
      (ushort) 16924,
      (ushort) 16938,
      (ushort) 16939,
      (ushort) 17346,
      (ushort) 17347
            };
            foreach (int num in numArray)
            {
                if (num == (int)ushort_4)
                    return true;
            }
            return false;
        }

        public bool method_1(ushort ushort_4)
        {
            ushort[] numArray = new ushort[2]
            {
      (ushort) 16938,
      (ushort) 16939
            };
            foreach (int num in numArray)
            {
                if (num == (int)ushort_4)
                    return true;
            }
            return false;
        }

        public bool method_2(ushort ushort_4)
        {
            foreach (int num in new ushort[0])
            {
                if (num == (int)ushort_4)
                    return true;
            }
            return false;
        }

        public bool method_3(ushort ushort_4)
        {
            ushort[] numArray = new ushort[7]
            {
      (ushort) 16925,
      (ushort) 16876,
      (ushort) 17349,
      (ushort) 17348,
      (ushort) 16936,
      (ushort) 16937,
      (ushort) 16535
            };
            foreach (int num in numArray)
            {
                if (num == (int)ushort_4)
                    return true;
            }
            return false;
        }

        public static Direction GetDirection(int x1, int y1, int x2, int y2)
        {
            switch ((y2 - y1))
            {
                case -1:
                    return Direction.N;

                case 1:
                    return Direction.S;
            }
            switch ((x2 - x1))
            {
                case -1:
                    return Direction.W;

                case 1:
                    return Direction.E;
            }
            throw new InvalidDataException("Coordinates must share an edge.");
        }

        public bool GetPath(int x1, int y1, int x2, int y2, out List<PathFinder.Node> path)
        {
            path = this.pathFinder.Find(x1, y1, x2, y2);
            if (((path != null) && (path.Count <= 0xff)) && (path.Count >= 2))
            {
                return true;
            }
            path = null;
            return false;
        }

        public bool GetWalkePath(int x1, int y1, int x2, int y2, out List<PathFinder.Node> path)
        {
            path = this.pathFinder.FindWithAisling(x1, y1, x2, y2);
            if (((path != null) && (path.Count <= 0xff)) && (path.Count >= 2))
            {
                return true;
            }
            path = null;
            return false;
        }

        public bool IsAisling(int x, int y)
        {
            if (((x < 0) || (x >= this.Cols)) || ((y < 0) || (y >= this.Rows)))
            {
                return true;
            }
            foreach (KeyValuePair<uint, Aisling> pair in this.Aislings)
            {
                if ((pair.Value.X == x) && (pair.Value.Y == y))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMonster(int x, int y)
        {
            if (((x < 0) || (x >= this.Cols)) || ((y < 0) || (y >= this.Rows)))
            {
                return true;
            }
            foreach (KeyValuePair<uint, Monster> pair in this.Monsters)
            {
                if ((pair.Value.X == x) && (pair.Value.Y == y))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMundane(int x, int y)
        {
            if (((x < 0) || (x >= this.Cols)) || ((y < 0) || (y >= this.Rows)))
            {
                return true;
            }
            foreach (KeyValuePair<uint, Mundane> pair in this.Mundanes)
            {
                if ((pair.Value.X == x) && (pair.Value.Y == y))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSolid(int x, int y)
        {
            if (((x >= 0) && (x < this.Cols)) && ((y >= 0) && (y < this.Rows)))
            {
                return this.Area[(y * this.Cols) + x].Solid;
            }
            return true;
        }

        public bool TryTeleport(NexonPacket packet, int x1, int y1, int x2, int y2, out List<PathFinder.Node> path)
        {
            path = this.pathFinder.Find(x1, y1, x2, y2);
            if (((path == null) || (path.Count > 0xff)) || (path.Count < 2))
            {
                path = null;
                return false;
            }
            Direction face = GetDirection(path[0].X, path[0].Y, path[1].X, path[1].Y);
            int step = 1;
            List<TeleportBlock> list = new List<TeleportBlock>();
            for (int i = 2; i < path.Count; i++)
            {
                Direction direction2 = GetDirection(path[i - 1].X, path[i - 1].Y, path[i].X, path[i].Y);
                if (face != direction2)
                {
                    list.Add(new TeleportBlock(face, step));
                    face = direction2;
                    step = 1;
                }
                else
                {
                    step++;
                }
            }
            list.Add(new TeleportBlock(face, step));
            packet.WriteU1((byte) (path.Count - 1));
            packet.WriteU1((byte) list.Count);
            for (int j = 0; j < list.Count; j++)
            {
                packet.WriteU1((byte) list[j].Face);
                packet.WriteU1((byte) list[j].Step);
            }
            packet.WriteU1(0);
            return true;
        }

        public bool TryTeleport2(NexonPacket packet, int x1, int y1, int x2, int y2)
        {
            List<PathFinder.Node> list = new List<PathFinder.Node>();
            list = this.pathFinder.Find(x1, y1, x2, y2);
            if (((list == null) || (list.Count > 0xff)) || (list.Count < 2))
            {
                list = null;
                return false;
            }
            Direction face = GetDirection(list[0].X, list[0].Y, list[1].X, list[1].Y);
            int step = 1;
            List<TeleportBlock> list2 = new List<TeleportBlock>();
            for (int i = 2; i < list.Count; i++)
            {
                Direction direction2 = GetDirection(list[i - 1].X, list[i - 1].Y, list[i].X, list[i].Y);
                if (face != direction2)
                {
                    list2.Add(new TeleportBlock(face, step));
                    face = direction2;
                    step = 1;
                }
                else
                {
                    step++;
                }
            }
            list2.Add(new TeleportBlock(face, step));
            packet.WriteU1((byte) (list.Count - 1));
            packet.WriteU1((byte) list2.Count);
            for (int j = 0; j < list2.Count; j++)
            {
                packet.WriteU1((byte) list2[j].Face);
                packet.WriteU1((byte) list2[j].Step);
            }
            packet.WriteU1(0);
            return true;
        }

        public bool TryTeleport2(NexonPacket packet, int x1, int y1, int x2, int y2, List<PathFinder.Node> path)
        {
            path = this.pathFinder.Find(x1, y1, x2, y2);
            if (((path == null) || (path.Count > 0xff)) || (path.Count < 2))
            {
                path = null;
                return false;
            }
            Direction face = GetDirection(path[0].X, path[0].Y, path[1].X, path[1].Y);
            int step = 1;
            List<TeleportBlock> list = new List<TeleportBlock>();
            for (int i = 2; i < path.Count; i++)
            {
                Direction direction2 = GetDirection(path[i - 1].X, path[i - 1].Y, path[i].X, path[i].Y);
                if (face != direction2)
                {
                    list.Add(new TeleportBlock(face, step));
                    face = direction2;
                    step = 1;
                }
                else
                {
                    step++;
                }
            }
            list.Add(new TeleportBlock(face, step));
            packet.WriteU1((byte) (path.Count - 1));
            packet.WriteU1((byte) list.Count);
            for (int j = 0; j < list.Count; j++)
            {
                packet.WriteU1((byte) list[j].Face);
                packet.WriteU1((byte) list[j].Step);
            }
            packet.WriteU1(0);
            return true;
        }

        public NexonMapFile.Tile this[int x, int y] =>
            this.Area[(y * this.Cols) + x];

        public bool Loaded =>
            (this.Area != null);

        public class TeleportBlock
        {
            public Direction Face;
            public int Step;

            public TeleportBlock(Direction face, int step)
            {
                this.Face = face;
                this.Step = step;
            }
        }
    }
}

