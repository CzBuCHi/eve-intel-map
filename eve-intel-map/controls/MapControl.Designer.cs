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
            this.dataSet = new eve_intel_map.Data.DataSet();
            this.eveMapSolarsystemsTableAdapter = new eve_intel_map.Data.DataSetTableAdapters.EveMapSolarsystemsTableAdapter();
            this.eveMapSolarsystemJumpsTableAdapter = new eve_intel_map.Data.DataSetTableAdapters.EveMapSolarsystemJumpsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
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
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eveMapSolarsystemsTableAdapter
            // 
            this.eveMapSolarsystemsTableAdapter.ClearBeforeFill = true;
            // 
            // eveMapSolarsystemJumpsTableAdapter
            // 
            this.eveMapSolarsystemJumpsTableAdapter.ClearBeforeFill = true;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gViewer);
            this.Name = "MapControl";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
        private Data.DataSet dataSet;
        private Data.DataSetTableAdapters.EveMapSolarsystemsTableAdapter eveMapSolarsystemsTableAdapter;
        private Data.DataSetTableAdapters.EveMapSolarsystemJumpsTableAdapter eveMapSolarsystemJumpsTableAdapter;
    }
}
