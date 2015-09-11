namespace eve_intel_map.controls
{
    partial class MapControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.staticData = new eve_intel_map.Data.StaticData();
            this.mapSolarSystemTableAdapter = new eve_intel_map.Data.StaticDataTableAdapters.mapSolarSystemTableAdapter();
            this.mapSolarSystemJumpTableAdapter = new eve_intel_map.Data.StaticDataTableAdapters.mapSolarSystemJumpTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.staticData)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewer
            // 
            this.gViewer.ArrowheadLength = 10D;
            this.gViewer.AsyncLayout = false;
            this.gViewer.AutoScroll = true;
            this.gViewer.BackColor = System.Drawing.Color.White;
            this.gViewer.BackwardEnabled = false;
            this.gViewer.BuildHitTree = false;
            this.gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.MDS;
            this.gViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViewer.FileName = "";
            this.gViewer.ForwardEnabled = false;
            this.gViewer.Graph = null;
            this.gViewer.InsertingEdge = false;
            this.gViewer.LayoutAlgorithmSettingsButtonVisible = false;
            this.gViewer.LayoutEditingEnabled = false;
            this.gViewer.Location = new System.Drawing.Point(0, 0);
            this.gViewer.LooseOffsetForRouting = 0.25D;
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = false;
            this.gViewer.NeedToCalculateLayout = true;
            this.gViewer.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer.PaddingForEdgeRouting = 8D;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveAsImageEnabled = false;
            this.gViewer.SaveAsMsaglEnabled = false;
            this.gViewer.SaveButtonVisible = false;
            this.gViewer.SaveGraphButtonVisible = false;
            this.gViewer.SaveInVectorFormatEnabled = false;
            this.gViewer.Size = new System.Drawing.Size(150, 150);
            this.gViewer.TabIndex = 1;
            this.gViewer.TightOffsetForRouting = 0.125D;
            this.gViewer.ToolBarIsVisible = false;
            this.gViewer.WindowZoomButtonPressed = false;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomFraction = 0.5D;
            this.gViewer.ZoomWhenMouseWheelScroll = false;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            // 
            // staticData
            // 
            this.staticData.DataSetName = "ClientData";
            this.staticData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mapSolarSystemTableAdapter
            // 
            this.mapSolarSystemTableAdapter.ClearBeforeFill = true;
            // 
            // mapSolarSystemJumpTableAdapter
            // 
            this.mapSolarSystemJumpTableAdapter.ClearBeforeFill = true;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gViewer);
            this.Name = "MapControl";
            ((System.ComponentModel.ISupportInitialize)(this.staticData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
        private Data.StaticData staticData;
        private Data.StaticDataTableAdapters.mapSolarSystemTableAdapter mapSolarSystemTableAdapter;
        private Data.StaticDataTableAdapters.mapSolarSystemJumpTableAdapter mapSolarSystemJumpTableAdapter;
    }
}
