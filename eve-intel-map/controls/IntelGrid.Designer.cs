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
            this.CharacterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorporationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllianceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharacterKos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CorporationKos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllianceKos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolarSystemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConstellationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolarsystemTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.eveShipsRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShipTypeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intelGridRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipsRowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelGridRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterID,
            this.CharacterName,
            this.CorporationName,
            this.AllianceName,
            this.CharacterKos,
            this.CorporationKos,
            this.AllianceKos,
            this.SolarSystemName,
            this.ConstellationName,
            this.RegionName,
            this.SolarsystemTime,
            this.ShipTypeID,
            this.ShipTypeTime,
            this.ShipInfo,
            this.Notes});
            this.dataGridView.DataSource = this.intelGridRowBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(900, 150);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellLeave);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            // 
            // CharacterID
            // 
            this.CharacterID.DataPropertyName = "CharacterID";
            this.CharacterID.HeaderText = "CharacterID";
            this.CharacterID.Name = "CharacterID";
            this.CharacterID.ReadOnly = true;
            this.CharacterID.Visible = false;
            // 
            // CharacterName
            // 
            this.CharacterName.DataPropertyName = "CharacterName";
            this.CharacterName.HeaderText = "Character";
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.ReadOnly = true;
            // 
            // CorporationName
            // 
            this.CorporationName.DataPropertyName = "CorporationName";
            this.CorporationName.HeaderText = "Corporation";
            this.CorporationName.Name = "CorporationName";
            this.CorporationName.ReadOnly = true;
            // 
            // AllianceName
            // 
            this.AllianceName.DataPropertyName = "AllianceName";
            this.AllianceName.HeaderText = "Alliance";
            this.AllianceName.Name = "AllianceName";
            this.AllianceName.ReadOnly = true;
            // 
            // CharacterKos
            // 
            this.CharacterKos.DataPropertyName = "CharacterKos";
            this.CharacterKos.HeaderText = "CharacterKos";
            this.CharacterKos.Name = "CharacterKos";
            this.CharacterKos.ReadOnly = true;
            this.CharacterKos.Visible = false;
            // 
            // CorporationKos
            // 
            this.CorporationKos.DataPropertyName = "CorporationKos";
            this.CorporationKos.HeaderText = "CorporationKos";
            this.CorporationKos.Name = "CorporationKos";
            this.CorporationKos.ReadOnly = true;
            this.CorporationKos.Visible = false;
            // 
            // AllianceKos
            // 
            this.AllianceKos.DataPropertyName = "AllianceKos";
            this.AllianceKos.HeaderText = "AllianceKos";
            this.AllianceKos.Name = "AllianceKos";
            this.AllianceKos.ReadOnly = true;
            this.AllianceKos.Visible = false;
            // 
            // SolarSystemName
            // 
            this.SolarSystemName.DataPropertyName = "SolarSystemName";
            this.SolarSystemName.HeaderText = "SolarSystem";
            this.SolarSystemName.Name = "SolarSystemName";
            this.SolarSystemName.ReadOnly = true;
            // 
            // ConstellationName
            // 
            this.ConstellationName.DataPropertyName = "ConstellationName";
            this.ConstellationName.HeaderText = "Constellation";
            this.ConstellationName.Name = "ConstellationName";
            this.ConstellationName.ReadOnly = true;
            // 
            // RegionName
            // 
            this.RegionName.DataPropertyName = "RegionName";
            this.RegionName.HeaderText = "Region";
            this.RegionName.Name = "RegionName";
            this.RegionName.ReadOnly = true;
            // 
            // SolarsystemTime
            // 
            this.SolarsystemTime.DataPropertyName = "SolarsystemTime";
            this.SolarsystemTime.HeaderText = "SolarsystemTime";
            this.SolarsystemTime.Name = "SolarsystemTime";
            this.SolarsystemTime.ReadOnly = true;
            // 
            // ShipTypeID
            // 
            this.ShipTypeID.DataPropertyName = "ShipTypeID";
            this.ShipTypeID.DataSource = this.eveShipsRowBindingSource;
            this.ShipTypeID.DisplayMember = "TypeName";
            this.ShipTypeID.HeaderText = "Ship";
            this.ShipTypeID.Name = "ShipTypeID";
            this.ShipTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ShipTypeID.ValueMember = "TypeID";
            // 
            // eveShipsRowBindingSource
            // 
            this.eveShipsRowBindingSource.DataSource = typeof(eve_intel_map.Data.ReadOnlyData.EveShipsRow);
            this.eveShipsRowBindingSource.Sort = "TypeName";
            // 
            // ShipTypeTime
            // 
            this.ShipTypeTime.DataPropertyName = "ShipTypeTime";
            this.ShipTypeTime.HeaderText = "ShipTypeTime";
            this.ShipTypeTime.Name = "ShipTypeTime";
            this.ShipTypeTime.ReadOnly = true;
            // 
            // ShipInfo
            // 
            this.ShipInfo.DataPropertyName = "ShipInfo";
            this.ShipInfo.HeaderText = "ShipInfo";
            this.ShipInfo.Name = "ShipInfo";
            this.ShipInfo.ReadOnly = true;
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            // 
            // intelGridRowBindingSource
            // 
            this.intelGridRowBindingSource.DataSource = typeof(eve_intel_map.Data.ReadOnlyData.IntelGridRow);
            // 
            // IntelGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Name = "IntelGrid";
            this.Size = new System.Drawing.Size(900, 150);
            this.Load += new System.EventHandler(this.IntelGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipsRowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelGridRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource eveShipsRowBindingSource;
        private System.Windows.Forms.BindingSource intelGridRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorporationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllianceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CharacterKos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CorporationKos;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllianceKos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolarSystemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConstellationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolarsystemTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShipTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipTypeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}
