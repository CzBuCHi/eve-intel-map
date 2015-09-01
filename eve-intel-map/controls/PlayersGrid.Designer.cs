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
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.playerInfoEveShipNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playerInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new eve_intel_map.Data.DataSet();
            this.shipTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solarsystemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.playerInfoEveMapSolarsystemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.solarsystemTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerInfoTableAdapter = new eve_intel_map.Data.DataSetTableAdapters.PlayerInfoTableAdapter();
            this.eveMapSolarsystemsTableAdapter = new eve_intel_map.Data.DataSetTableAdapters.EveMapSolarsystemsTableAdapter();
            this.eveShipNamesTableAdapter = new eve_intel_map.Data.DataSetTableAdapters.EveShipNamesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoEveShipNamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoEveMapSolarsystemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.shipDataGridViewTextBoxColumn,
            this.shipTimeDataGridViewTextBoxColumn,
            this.solarsystemDataGridViewTextBoxColumn,
            this.solarsystemTimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.playerInfoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(450, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 22;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Charcter";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 72;
            // 
            // shipDataGridViewTextBoxColumn
            // 
            this.shipDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shipDataGridViewTextBoxColumn.DataPropertyName = "Ship";
            this.shipDataGridViewTextBoxColumn.DataSource = this.playerInfoEveShipNamesBindingSource;
            this.shipDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.shipDataGridViewTextBoxColumn.HeaderText = "Ship";
            this.shipDataGridViewTextBoxColumn.Name = "shipDataGridViewTextBoxColumn";
            this.shipDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shipDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.shipDataGridViewTextBoxColumn.ValueMember = "Id";
            // 
            // playerInfoEveShipNamesBindingSource
            // 
            this.playerInfoEveShipNamesBindingSource.DataMember = "PlayerInfo_EveShipNames";
            this.playerInfoEveShipNamesBindingSource.DataSource = this.playerInfoBindingSource;
            // 
            // playerInfoBindingSource
            // 
            this.playerInfoBindingSource.DataMember = "PlayerInfo";
            this.playerInfoBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shipTimeDataGridViewTextBoxColumn
            // 
            this.shipTimeDataGridViewTextBoxColumn.DataPropertyName = "ShipTime";
            this.shipTimeDataGridViewTextBoxColumn.HeaderText = "ShipTime";
            this.shipTimeDataGridViewTextBoxColumn.Name = "shipTimeDataGridViewTextBoxColumn";
            this.shipTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipTimeDataGridViewTextBoxColumn.Width = 76;
            // 
            // solarsystemDataGridViewTextBoxColumn
            // 
            this.solarsystemDataGridViewTextBoxColumn.DataPropertyName = "Solarsystem";
            this.solarsystemDataGridViewTextBoxColumn.DataSource = this.playerInfoEveMapSolarsystemsBindingSource;
            this.solarsystemDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.solarsystemDataGridViewTextBoxColumn.HeaderText = "Solarsystem";
            this.solarsystemDataGridViewTextBoxColumn.Name = "solarsystemDataGridViewTextBoxColumn";
            this.solarsystemDataGridViewTextBoxColumn.ReadOnly = true;
            this.solarsystemDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.solarsystemDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.solarsystemDataGridViewTextBoxColumn.ValueMember = "Id";
            this.solarsystemDataGridViewTextBoxColumn.Width = 88;
            // 
            // playerInfoEveMapSolarsystemsBindingSource
            // 
            this.playerInfoEveMapSolarsystemsBindingSource.DataMember = "PlayerInfo_EveMapSolarsystems";
            this.playerInfoEveMapSolarsystemsBindingSource.DataSource = this.playerInfoBindingSource;
            // 
            // solarsystemTimeDataGridViewTextBoxColumn
            // 
            this.solarsystemTimeDataGridViewTextBoxColumn.DataPropertyName = "SolarsystemTime";
            this.solarsystemTimeDataGridViewTextBoxColumn.HeaderText = "SolarsystemTime";
            this.solarsystemTimeDataGridViewTextBoxColumn.Name = "solarsystemTimeDataGridViewTextBoxColumn";
            this.solarsystemTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.solarsystemTimeDataGridViewTextBoxColumn.Width = 111;
            // 
            // playerInfoTableAdapter
            // 
            this.playerInfoTableAdapter.ClearBeforeFill = true;
            // 
            // eveMapSolarsystemsTableAdapter
            // 
            this.eveMapSolarsystemsTableAdapter.ClearBeforeFill = true;
            // 
            // eveShipNamesTableAdapter
            // 
            this.eveShipNamesTableAdapter.ClearBeforeFill = true;
            // 
            // PlayersGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "PlayersGrid";
            this.Size = new System.Drawing.Size(450, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoEveShipNamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerInfoEveMapSolarsystemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn shipNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipNameTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn shipNameConfirmedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn characterIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn characterNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn shipConfirmedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource playerInfoEveShipNamesBindingSource;
        private System.Windows.Forms.BindingSource playerInfoBindingSource;
        private Data.DataSet dataSet;
        private System.Windows.Forms.BindingSource playerInfoEveMapSolarsystemsBindingSource;
        private Data.DataSetTableAdapters.PlayerInfoTableAdapter playerInfoTableAdapter;
        private Data.DataSetTableAdapters.EveMapSolarsystemsTableAdapter eveMapSolarsystemsTableAdapter;
        private Data.DataSetTableAdapters.EveShipNamesTableAdapter eveShipNamesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn shipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn solarsystemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn solarsystemTimeDataGridViewTextBoxColumn;
    }
}
