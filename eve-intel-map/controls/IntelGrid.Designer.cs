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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CharacterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorporationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllianceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharacterKos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CorporationKos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllianceKos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolarsystemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolarsystemTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.eveShipsRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShipTypeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intelGridRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mapSolarSystemRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipsRowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelGridRowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSolarSystemRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterID,
            this.CharacterName,
            this.CorporationName,
            this.AllianceName,
            this.CharacterKos,
            this.CorporationKos,
            this.AllianceKos,
            this.SolarsystemID,
            this.SolarsystemTime,
            this.ShipTypeID,
            this.ShipTypeTime,
            this.ShipInfo,
            this.Notes});
            this.dataGridView1.DataSource = this.intelGridRowBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(900, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // CharacterID
            // 
            this.CharacterID.DataPropertyName = "CharacterID";
            this.CharacterID.HeaderText = "CharacterID";
            this.CharacterID.Name = "CharacterID";
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
            this.CharacterKos.Visible = false;
            // 
            // CorporationKos
            // 
            this.CorporationKos.DataPropertyName = "CorporationKos";
            this.CorporationKos.HeaderText = "CorporationKos";
            this.CorporationKos.Name = "CorporationKos";
            this.CorporationKos.Visible = false;
            // 
            // AllianceKos
            // 
            this.AllianceKos.DataPropertyName = "AllianceKos";
            this.AllianceKos.HeaderText = "AllianceKos";
            this.AllianceKos.Name = "AllianceKos";
            this.AllianceKos.Visible = false;
            // 
            // SolarsystemID
            // 
            this.SolarsystemID.DataPropertyName = "SolarsystemID";
            this.SolarsystemID.HeaderText = "solar system";
            this.SolarsystemID.Name = "SolarsystemID";
            this.SolarsystemID.ReadOnly = true;
            this.SolarsystemID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SolarsystemTime
            // 
            this.SolarsystemTime.DataPropertyName = "SolarsystemTime";
            this.SolarsystemTime.HeaderText = "solar system time";
            this.SolarsystemTime.Name = "SolarsystemTime";
            this.SolarsystemTime.ReadOnly = true;
            // 
            // ShipTypeID
            // 
            this.ShipTypeID.DataPropertyName = "ShipTypeID";
            this.ShipTypeID.DataSource = this.eveShipsRowBindingSource;
            this.ShipTypeID.DisplayMember = "TypeName";
            this.ShipTypeID.HeaderText = "ShipTypeID";
            this.ShipTypeID.Name = "ShipTypeID";
            this.ShipTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ShipTypeID.ValueMember = "TypeID";
            // 
            // eveShipsRowBindingSource
            // 
            this.eveShipsRowBindingSource.DataSource = typeof(eve_intel_map.Data.StaticData.EveShipsRow);
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
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            // 
            // intelGridRowBindingSource
            // 
            this.intelGridRowBindingSource.DataSource = typeof(eve_intel_map.Data.IntelData.IntelGridRow);
            // 
            // mapSolarSystemRowBindingSource
            // 
            this.mapSolarSystemRowBindingSource.DataSource = typeof(eve_intel_map.Data.StaticData.MapSolarSystemRow);
            // 
            // IntelGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "IntelGrid";
            this.Size = new System.Drawing.Size(900, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipsRowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelGridRowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSolarSystemRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorporationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllianceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CharacterKos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CorporationKos;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllianceKos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolarsystemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolarsystemTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShipTypeID;
        private System.Windows.Forms.BindingSource eveShipsRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipTypeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.BindingSource intelGridRowBindingSource;
        private System.Windows.Forms.BindingSource mapSolarSystemRowBindingSource;
    }
}
