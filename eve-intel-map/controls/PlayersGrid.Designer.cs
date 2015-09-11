namespace eve_intel_map.controls
{
    partial class PlayersGrid
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
            this.staticData = new eve_intel_map.Data.StaticData();
            this.intelPlayerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.intelPlayerTableAdapter = new eve_intel_map.Data.StaticDataTableAdapters.intelPlayerTableAdapter();
            this.mapSolarSystemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mapSolarSystemTableAdapter = new eve_intel_map.Data.StaticDataTableAdapters.mapSolarSystemTableAdapter();
            this.eveShipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eveShipTableAdapter = new eve_intel_map.Data.StaticDataTableAdapters.eveShipTableAdapter();
            this.characterIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.characterNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corporationNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allianceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.characterKosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.corporationKosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allianceKosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.solarsystemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.shipTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.shipTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelPlayerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSolarSystemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.characterIDDataGridViewTextBoxColumn,
            this.characterNameDataGridViewTextBoxColumn,
            this.corporationNameDataGridViewTextBoxColumn,
            this.allianceNameDataGridViewTextBoxColumn,
            this.characterKosDataGridViewCheckBoxColumn,
            this.corporationKosDataGridViewCheckBoxColumn,
            this.allianceKosDataGridViewCheckBoxColumn,
            this.solarsystemIDDataGridViewTextBoxColumn,
            this.shipTypeIDDataGridViewTextBoxColumn,
            this.shipTypeID,
            this.dataGridViewComboBoxColumn1,
            this.notesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.intelPlayerBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(900, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // staticData
            // 
            this.staticData.DataSetName = "StaticData";
            this.staticData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // intelPlayerBindingSource
            // 
            this.intelPlayerBindingSource.DataMember = "intelPlayer";
            this.intelPlayerBindingSource.DataSource = this.staticData;
            // 
            // intelPlayerTableAdapter
            // 
            this.intelPlayerTableAdapter.ClearBeforeFill = true;
            // 
            // mapSolarSystemBindingSource
            // 
            this.mapSolarSystemBindingSource.DataMember = "mapSolarSystem";
            this.mapSolarSystemBindingSource.DataSource = this.staticData;
            // 
            // mapSolarSystemTableAdapter
            // 
            this.mapSolarSystemTableAdapter.ClearBeforeFill = true;
            // 
            // eveShipBindingSource
            // 
            this.eveShipBindingSource.DataMember = "eveShip";
            this.eveShipBindingSource.DataSource = this.staticData;
            // 
            // eveShipTableAdapter
            // 
            this.eveShipTableAdapter.ClearBeforeFill = true;
            // 
            // characterIDDataGridViewTextBoxColumn
            // 
            this.characterIDDataGridViewTextBoxColumn.DataPropertyName = "characterID";
            this.characterIDDataGridViewTextBoxColumn.HeaderText = "characterID";
            this.characterIDDataGridViewTextBoxColumn.Name = "characterIDDataGridViewTextBoxColumn";
            this.characterIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // characterNameDataGridViewTextBoxColumn
            // 
            this.characterNameDataGridViewTextBoxColumn.DataPropertyName = "characterName";
            this.characterNameDataGridViewTextBoxColumn.HeaderText = "Character";
            this.characterNameDataGridViewTextBoxColumn.Name = "characterNameDataGridViewTextBoxColumn";
            // 
            // corporationNameDataGridViewTextBoxColumn
            // 
            this.corporationNameDataGridViewTextBoxColumn.DataPropertyName = "corporationName";
            this.corporationNameDataGridViewTextBoxColumn.HeaderText = "Corporation";
            this.corporationNameDataGridViewTextBoxColumn.Name = "corporationNameDataGridViewTextBoxColumn";
            // 
            // allianceNameDataGridViewTextBoxColumn
            // 
            this.allianceNameDataGridViewTextBoxColumn.DataPropertyName = "allianceName";
            this.allianceNameDataGridViewTextBoxColumn.HeaderText = "Alliance";
            this.allianceNameDataGridViewTextBoxColumn.Name = "allianceNameDataGridViewTextBoxColumn";
            // 
            // characterKosDataGridViewCheckBoxColumn
            // 
            this.characterKosDataGridViewCheckBoxColumn.DataPropertyName = "characterKos";
            this.characterKosDataGridViewCheckBoxColumn.HeaderText = "characterKos";
            this.characterKosDataGridViewCheckBoxColumn.Name = "characterKosDataGridViewCheckBoxColumn";
            this.characterKosDataGridViewCheckBoxColumn.Visible = false;
            // 
            // corporationKosDataGridViewCheckBoxColumn
            // 
            this.corporationKosDataGridViewCheckBoxColumn.DataPropertyName = "corporationKos";
            this.corporationKosDataGridViewCheckBoxColumn.HeaderText = "corporationKos";
            this.corporationKosDataGridViewCheckBoxColumn.Name = "corporationKosDataGridViewCheckBoxColumn";
            this.corporationKosDataGridViewCheckBoxColumn.Visible = false;
            // 
            // allianceKosDataGridViewCheckBoxColumn
            // 
            this.allianceKosDataGridViewCheckBoxColumn.DataPropertyName = "allianceKos";
            this.allianceKosDataGridViewCheckBoxColumn.HeaderText = "allianceKos";
            this.allianceKosDataGridViewCheckBoxColumn.Name = "allianceKosDataGridViewCheckBoxColumn";
            this.allianceKosDataGridViewCheckBoxColumn.Visible = false;
            // 
            // solarsystemIDDataGridViewTextBoxColumn
            // 
            this.solarsystemIDDataGridViewTextBoxColumn.DataPropertyName = "solarsystemID";
            this.solarsystemIDDataGridViewTextBoxColumn.DataSource = this.mapSolarSystemBindingSource;
            this.solarsystemIDDataGridViewTextBoxColumn.DisplayMember = "solarSystemName";
            this.solarsystemIDDataGridViewTextBoxColumn.HeaderText = "Solar System";
            this.solarsystemIDDataGridViewTextBoxColumn.Name = "solarsystemIDDataGridViewTextBoxColumn";
            this.solarsystemIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.solarsystemIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.solarsystemIDDataGridViewTextBoxColumn.ValueMember = "solarSystemID";
            // 
            // shipTypeIDDataGridViewTextBoxColumn
            // 
            this.shipTypeIDDataGridViewTextBoxColumn.DataPropertyName = "shipTypeID";
            this.shipTypeIDDataGridViewTextBoxColumn.DataSource = this.eveShipBindingSource;
            this.shipTypeIDDataGridViewTextBoxColumn.DisplayMember = "typeName";
            this.shipTypeIDDataGridViewTextBoxColumn.HeaderText = "Ship";
            this.shipTypeIDDataGridViewTextBoxColumn.Name = "shipTypeIDDataGridViewTextBoxColumn";
            this.shipTypeIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shipTypeIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.shipTypeIDDataGridViewTextBoxColumn.ValueMember = "typeID";
            // 
            // shipTypeID
            // 
            this.shipTypeID.DataPropertyName = "shipTypeID";
            this.shipTypeID.DataSource = this.eveShipBindingSource;
            this.shipTypeID.DisplayMember = "groupName";
            this.shipTypeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.shipTypeID.HeaderText = "Ship type";
            this.shipTypeID.Name = "shipTypeID";
            this.shipTypeID.ReadOnly = true;
            this.shipTypeID.ValueMember = "typeID";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "shipTypeID";
            this.dataGridViewComboBoxColumn1.DataSource = this.eveShipBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "raceName";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.HeaderText = "Ship race";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "typeID";
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            // 
            // PlayersGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "PlayersGrid";
            this.Size = new System.Drawing.Size(900, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelPlayerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapSolarSystemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eveShipBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource intelPlayerBindingSource;
        private Data.StaticData staticData;
        private Data.StaticDataTableAdapters.intelPlayerTableAdapter intelPlayerTableAdapter;
        private System.Windows.Forms.BindingSource mapSolarSystemBindingSource;
        private System.Windows.Forms.BindingSource eveShipBindingSource;
        private Data.StaticDataTableAdapters.mapSolarSystemTableAdapter mapSolarSystemTableAdapter;
        private Data.StaticDataTableAdapters.eveShipTableAdapter eveShipTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn characterIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn characterNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn corporationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allianceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn characterKosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn corporationKosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allianceKosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn solarsystemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn shipTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn shipTypeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
    }
}
