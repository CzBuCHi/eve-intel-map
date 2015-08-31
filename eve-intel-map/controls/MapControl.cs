﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using eve_intel_map.Model;
using JetBrains.Annotations;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Layout.MDS;

namespace eve_intel_map.controls
{
    public partial class MapControl : UserControl
    {
        private long _CurrentSystem;
        private long? _RegionId;

        public MapControl() {
            InitializeComponent();
        }

        public int MaxVisibleSystems { get; set; } = 20;

        public long? RegionId {
            get { return _RegionId; }
            set {
                if (_RegionId == value) {
                    return;
                }
                _RegionId = value;
                UpdateGraph();
            }
        }

        public long CurrentSystem {
            get { return _CurrentSystem; }
            set {
                if (_CurrentSystem == value) {
                    return;
                }
                _CurrentSystem = value;
                UpdateGraph();
            }
        }

        private readonly Dictionary<int, Node> _Nodes = new Dictionary<int, Node>();

        private void UpdateGraph() {
            gViewer.Graph = null;
            Graph graph = new Graph("graph") {
                LayoutAlgorithmSettings = new MdsLayoutSettings {
                    EdgeRoutingSettings = new EdgeRoutingSettings {
                        EdgeRoutingMode = EdgeRoutingMode.Spline,
                        RouteMultiEdgesAsBundles = false
                    },
                    AdjustScale = true
                }
            };
            IEnumerable<SystemInfo> systems = GetSystems();
            CreateNodesAndEdges(graph, systems);
            gViewer.Graph = graph;
            Height = (int)(Width * gViewer.GraphHeight / gViewer.GraphWidth);
        }

        private void CreateNodesAndEdges([NotNull] Graph graph, [NotNull] IEnumerable<SystemInfo> systems) {
            Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();

            lock (_Nodes) {
                _Nodes.Clear();
                foreach (SystemInfo info in systems) {
                    if (!_Nodes.ContainsKey(info.System.Id)) {
                        Node node = graph.AddNode(info.System.Id.ToString());
                        node.LabelText = info.System.Name;
                        _Nodes.Add(info.System.Id, node);
                    }

                    if (info.Parent == null) {
                        continue;
                    }

                    HashSet<int> list;
                    if (!dict.TryGetValue(info.Parent.Id, out list)) {
                        list = new HashSet<int>();
                        dict[info.Parent.Id] = list;
                    }
                    if (!list.Contains(info.System.Id)) {
                        list.Add(info.System.Id);
                    }
                }
            }

            HashSet<string> edges = new HashSet<string>();
            foreach (KeyValuePair<int, HashSet<int>> pair in dict) {
                foreach (int item in pair.Value) {
                    if (edges.Contains(item + "-" + pair.Key)) {
                        continue;
                    }

                    edges.Add(pair.Key + "-" + item);

                    Edge edge = graph.AddEdge(pair.Key.ToString(), item.ToString());
                    edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
                }
            }
        }

        private IEnumerable<SystemInfo> GetSystems() {

            IEnumerable<SystemInfo> current = from system in DbHelper.DataContext.SolarSystems
                                              where system.Id == CurrentSystem
                                              select new SystemInfo {
                                                  System = system
                                              };

            if (RegionId != null) {
                current = from system in current
                          where system.System.RegionId == RegionId.Value
                          select system;

                current = current.ToArray();
                if (!current.Any()) {
                    current = (from system in DbHelper.DataContext.SolarSystems
                               where system.RegionId == RegionId
                               select new SystemInfo {
                                   System = system
                               }).Take(1);

                }
            }
            current = current.ToArray();


            SystemInfo[] total = current.ToArray();
            while (RegionId != null || total.Length < MaxVisibleSystems) {
                SystemInfo[] next = GetConnected(current, total.Select(o => o.System.Id).ToArray()).ToArray();
                if (RegionId == null && total.Length + next.Length > 20) {
                    int count = MaxVisibleSystems - total.Length;
                    if (count < next.Length) {
                        SystemInfo[] array = new SystemInfo[count];
                        Array.Copy(next, array, count);
                        next = array;
                    }
                }
                total = total.Union(next).ToArray();

                if (next.Length == 0) {
                    break;
                }
                current = next;
            }

            return total;
        }

        [NotNull]
        private IEnumerable<SystemInfo> GetConnected([NotNull] IEnumerable<SystemInfo> prev, [NotNull] int[] prevIds) {
            foreach (SystemInfo o in prev) {
                IQueryable<EveMapSolarsystem> q = from jump in DbHelper.DataContext.SolarSystemJumps
                                                  join system in DbHelper.DataContext.SolarSystems on jump.ToSolarsystem equals system.Id
                                                  where jump.FromSolarsystem == o.System.Id
                                                  select system;
                if (RegionId != null) {
                    q = from system in q
                        where system.RegionId == RegionId.Value
                        select system;
                }

                foreach (EveMapSolarsystem o2 in q) {
                    if (prevIds.Contains(o2.Id)) {
                        continue;
                    }

                    yield return new SystemInfo {
                        System = o2,
                        Parent = o.System
                    };
                }
            }
        }

        public class SystemInfo
        {
            public EveMapSolarsystem System { get; set; }
            public EveMapSolarsystem Parent { get; set; }
        }
    }
}