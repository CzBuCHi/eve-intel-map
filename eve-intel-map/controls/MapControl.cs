using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using eve_intel_map.Data;
using JetBrains.Annotations;
using Microsoft.Msagl.Core.Routing;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Layout.MDS;

namespace eve_intel_map.controls
{
    public partial class MapControl : UserControl
    {
        private readonly Dictionary<long, Node> _Nodes = new Dictionary<long, Node>();
        private readonly ReadOnlyData _ReadOnlyData = new ReadOnlyData();
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
            Height = (int) (Width*gViewer.GraphHeight/gViewer.GraphWidth);
        }

        private void CreateNodesAndEdges([NotNull] Graph graph, [NotNull] IEnumerable<SystemInfo> systems) {
            Dictionary<long, HashSet<long>> dict = new Dictionary<long, HashSet<long>>();

            lock (_Nodes) {
                _Nodes.Clear();
                foreach (SystemInfo info in systems) {
                    if (!_Nodes.ContainsKey(info.System.SolarSystemID)) {
                        Node node = graph.AddNode(info.System.SolarSystemID.ToString());
                        node.LabelText = info.System.SolarSystemName;
                        _Nodes.Add(info.System.SolarSystemID, node);
                    }

                    if (info.Parent == null) {
                        continue;
                    }

                    HashSet<long> list;
                    if (!dict.TryGetValue(info.Parent.SolarSystemID, out list)) {
                        list = new HashSet<long>();
                        dict[info.Parent.SolarSystemID] = list;
                    }
                    if (!list.Contains(info.System.SolarSystemID)) {
                        list.Add(info.System.SolarSystemID);
                    }
                }
            }

            HashSet<string> edges = new HashSet<string>();
            foreach (KeyValuePair<long, HashSet<long>> pair in dict) {
                foreach (long item in pair.Value) {
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
            // find current system
            
            IEnumerable<SystemInfo> q = from system in _ReadOnlyData.MapSolarSystemTable
                                        where system.SolarSystemID == CurrentSystem
                                        select new SystemInfo {
                                            System = system
                                        };
            if (RegionId != null) {
                q = from system in q
                    where system.System.RegionID == RegionId.Value
                    select system;
            }

            SystemInfo[] current = q.ToArray();
            if (current.Length == 0) {
                // current system is not in specified region - pick first system in region as current
                if (RegionId != null) {
                    current = (from system in _ReadOnlyData.MapSolarSystemTable
                               where system.RegionID == RegionId
                               select new SystemInfo {
                                   System = system
                               }).Take(1).ToArray();
                } else {
                    return Enumerable.Empty<SystemInfo>();
                }
            }

            SystemInfo[] total = current.ToArray();
            while (RegionId != null || total.Length < MaxVisibleSystems) {
                SystemInfo[] next = GetConnected(current, total.Select(o => o.System.SolarSystemID).ToArray()).ToArray();
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
        private IEnumerable<SystemInfo> GetConnected([NotNull] IEnumerable<SystemInfo> prev, [NotNull] long[] prevIds) {
            foreach (SystemInfo o in prev) {
                IEnumerable<ReadOnlyData.MapSolarSystemRow> q = from jump in _ReadOnlyData.MapSolarSystemJumpTable
                                                               join system in _ReadOnlyData.MapSolarSystemTable on jump.ToSolarSystemID equals system.SolarSystemID
                                                               where jump.FromSolarSystemID == o.System.SolarSystemID
                                                              select system;
                if (RegionId != null) {
                    q = from system in q
                        where system.RegionID == RegionId.Value
                        select system;
                }

                foreach (ReadOnlyData.MapSolarSystemRow o2 in q) {
                    if (prevIds.Contains(o2.SolarSystemID)) {
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
            public ReadOnlyData.MapSolarSystemRow System { get; set; }
            public ReadOnlyData.MapSolarSystemRow Parent { get; set; }
        }
    }
}
