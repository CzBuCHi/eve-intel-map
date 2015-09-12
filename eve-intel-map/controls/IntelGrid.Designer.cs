namespace eve_intel_map.controls
{
    partial class IntelGrid
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
            this.characterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.characterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corporationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allianceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.characterKos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.corporationKos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allianceKos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.solarsystemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solarsystemTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.eveShipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.staticData = new eve_intel_map.Data.StaticData();
            this.shipTypeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intelGridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.intelData = new eve_intel_map.Data.IntelData();
            this.intelGridTableAdapter = new eve_intel_map.Data.IntelDataTableAdapters.intelGridTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelGridBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.characterID,
            this.characterName,
            this.corporationName,
            this.allianceName,
            this.characterKos,
            this.corporationKos,
            this.allianceKos,
            this.solarsystemID,
            this.solarsystemTime,
            this.shipID,
            this.shipTypeTime,
            this.shipInfo,
            this.notes});
            this.dataGridView.DataSource = this.intelGridBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(900, 150);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnDisplayIndexChanged);
            // 
            // characterID
            // 
            this.characterID.DataPropertyName = "characterID";
            this.characterID.HeaderText = "characterID";
            this.characterID.Name = "characterID";
            this.characterID.Visible = false;
            // 
            // characterName
            // 
            this.characterName.DataPropertyName = "characterName";
            this.characterName.HeaderText = "character";
            this.characterName.Name = "characterName";
            this.characterName.ReadOnly = true;
            // 
            // corporationName
            // 
            this.corporationName.DataPropertyName = "corporationName";
            this.corporationName.HeaderText = "corporation";
            this.corporationName.Name = "corporationName";
            this.corporationName.ReadOnly = true;
            // 
            // allianceName
            // 
            this.allianceName.DataPropertyName = "allianceName";
            this.allianceName.HeaderText = "alliance";
            this.allianceName.Name = "allianceName";
            this.allianceName.ReadOnly = true;
            // 
            // characterKos
            // 
            this.characterKos.DataPropertyName = "characterKos";
            this.characterKos.HeaderText = "characterKos";
            this.characterKos.Name = "characterKos";
            this.characterKos.Visible = false;
            // 
            // corporationKos
            // 
            this.corporationKos.DataPropertyName = "corporationKos";
            this.corporationKos.HeaderText = "corporationKos";
            this.corporationKos.Name = "corporationKos";
            this.corporationKos.Visible = false;
            // 
            // allianceKos
            // 
            this.allianceKos.DataPropertyName = "allianceKos";
            this.allianceKos.HeaderText = "allianceKos";
            this.allianceKos.Name = "allianceKos";
            this.allianceKos.Visible = false;
            // 
            // solarsystemID
            // 
            this.solarsystemID.DataPropertyName = "solarsystemID";
            this.solarsystemID.HeaderText = "solar system";
            this.solarsystemID.Name = "solarsystemID";
            this.solarsystemID.ReadOnly = true;
            // 
            // solarsystemTime
            // 
            this.solarsystemTime.DataPropertyName = "solarsystemTime";
            this.solarsystemTime.HeaderText = "solar system time";
            this.solarsystemTime.Name = "solarsystemTime";
            this.solarsystemTime.ReadOnly = true;
            // 
            // shipID
            // 
            this.shipID.DataPropertyName = "shipTypeID";
            this.shipID.DataSource = this.eveShipBindingSource;
            this.shipID.DisplayMember = "typeName";
            this.shipID.HeaderText = "ship";
            this.shipID.Name = "shipID";
            this.shipID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shipID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.shipID.ValueMember = "typeID";
            // 
            // eveShipBindingSource
            // 
            this.eveShipBindingSource.DataMember = "eveShips";
            this.eveShipBindingSource.DataSource = this.staticData;
            // 
            // staticData
            // 
            this.staticData.DataSetName = "StaticData";
            this.staticData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shipTypeTime
            // 
            this.shipTypeTime.DataPropertyName = "shipTypeTime";
            this.shipTypeTime.HeaderText = "ship time";
            this.shipTypeTime.Name = "shipTypeTime";
            this.shipTypeTime.ReadOnly = true;
            // 
            // shipInfo
            // 
            this.shipInfo.DataPropertyName = "shipInfo";
            this.shipInfo.HeaderText = "ship info";
            this.shipInfo.Name = "shipInfo";
            this.shipInfo.ReadOnly = true;
            // 
            // notes
            // 
            this.notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.notes.DataPropertyName = "notes";
            this.notes.HeaderText = "notes";
            this.notes.Name = "notes";
            // 
            // intelGridBindingSource
            // 
            this.intelGridBindingSource.DataMember = "intelGrid";
            this.intelGridBindingSource.DataSource = this.intelData;
            // 
            // intelData
            // 
            this.intelData.DataSetName = "IntelData";
            this.intelData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // intelGridTableAdapter
            // 
            this.intelGridTableAdapter.ClearBeforeFill = true;
            // 
            // IntelGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Name = "IntelGrid";
            this.Size = new System.Drawing.Size(900, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelGridBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource eveShipBindingSource;
        private Data.StaticData staticData;
        private System.Windows.Forms.BindingSource intelGridBindingSource;
        private Data.IntelData intelData;
        private Data.IntelDataTableAdapters.intelGridTableAdapter intelGridTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn characterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn characterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn corporationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn allianceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn characterKos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn corporationKos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allianceKos;
        private System.Windows.Forms.DataGridViewTextBoxColumn solarsystemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn solarsystemTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn shipID;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipTypeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
    }
}
