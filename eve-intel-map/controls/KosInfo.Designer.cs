namespace eve_intel_map.controls
{
    partial class KosInfo
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.kosInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kosInfoDataSet = new eve_intel_map.KosInfo();
            this.playerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastKnownLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastKnownLocationTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipTypeTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kosInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kosInfoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerNameDataGridViewTextBoxColumn,
            this.lastKnownLocationDataGridViewTextBoxColumn,
            this.lastKnownLocationTimeDataGridViewTextBoxColumn,
            this.shipTypeDataGridViewTextBoxColumn,
            this.shipTypeTimeDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.kosInfoBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(784, 388);
            this.dataGridView.TabIndex = 0;
            // 
            // kosInfoBindingSource
            // 
            this.kosInfoBindingSource.DataMember = "KosInfo";
            this.kosInfoBindingSource.DataSource = this.kosInfoDataSet;
            // 
            // kosInfoDataSet
            // 
            this.kosInfoDataSet.DataSetName = "KosInfo";
            this.kosInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // playerNameDataGridViewTextBoxColumn
            // 
            this.playerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.playerNameDataGridViewTextBoxColumn.DataPropertyName = "PlayerName";
            this.playerNameDataGridViewTextBoxColumn.HeaderText = "Player Name";
            this.playerNameDataGridViewTextBoxColumn.Name = "playerNameDataGridViewTextBoxColumn";
            this.playerNameDataGridViewTextBoxColumn.Width = 85;
            // 
            // lastKnownLocationDataGridViewTextBoxColumn
            // 
            this.lastKnownLocationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lastKnownLocationDataGridViewTextBoxColumn.DataPropertyName = "LastKnownLocation";
            this.lastKnownLocationDataGridViewTextBoxColumn.HeaderText = "Last Known Location";
            this.lastKnownLocationDataGridViewTextBoxColumn.Name = "lastKnownLocationDataGridViewTextBoxColumn";
            this.lastKnownLocationDataGridViewTextBoxColumn.Width = 121;
            // 
            // lastKnownLocationTimeDataGridViewTextBoxColumn
            // 
            this.lastKnownLocationTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lastKnownLocationTimeDataGridViewTextBoxColumn.DataPropertyName = "LastKnownLocationTime";
            this.lastKnownLocationTimeDataGridViewTextBoxColumn.HeaderText = "Last Known Location Time";
            this.lastKnownLocationTimeDataGridViewTextBoxColumn.Name = "lastKnownLocationTimeDataGridViewTextBoxColumn";
            this.lastKnownLocationTimeDataGridViewTextBoxColumn.Width = 123;
            // 
            // shipTypeDataGridViewTextBoxColumn
            // 
            this.shipTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.shipTypeDataGridViewTextBoxColumn.DataPropertyName = "ShipType";
            this.shipTypeDataGridViewTextBoxColumn.HeaderText = "Ship Type";
            this.shipTypeDataGridViewTextBoxColumn.Name = "shipTypeDataGridViewTextBoxColumn";
            this.shipTypeDataGridViewTextBoxColumn.Width = 74;
            // 
            // shipTypeTimeDataGridViewTextBoxColumn
            // 
            this.shipTypeTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.shipTypeTimeDataGridViewTextBoxColumn.DataPropertyName = "ShipTypeTime";
            this.shipTypeTimeDataGridViewTextBoxColumn.HeaderText = "Ship Type Time";
            this.shipTypeTimeDataGridViewTextBoxColumn.Name = "shipTypeTimeDataGridViewTextBoxColumn";
            this.shipTypeTimeDataGridViewTextBoxColumn.Width = 97;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            // 
            // KosInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Name = "KosInfo";
            this.Size = new System.Drawing.Size(784, 388);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kosInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kosInfoDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastKnownLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastKnownLocationTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipTypeTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource kosInfoBindingSource;
        private eve_intel_map.KosInfo kosInfoDataSet;
    }
}
