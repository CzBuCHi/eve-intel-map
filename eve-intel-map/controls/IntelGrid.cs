using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using eve_intel_map.Data;

namespace eve_intel_map.controls
{
    public partial class IntelGrid : UserControl
    {
        private readonly IntelData _IntelData = new IntelData();
        private readonly ReadOnlyData _ReadOnlyData = new ReadOnlyData();

        public IntelGrid() {
            InitializeComponent();
        }

        public void UpdateData() {
            intelGridRowBindingSource.ResetBindings(true);
        }

        private async void IntelGrid_Load(object sender, EventArgs e) {
            await _ReadOnlyData.IntelGridTable.LoadAsync();
            intelGridRowBindingSource.DataSource = _ReadOnlyData.IntelGridTable.Local.ToBindingList();
            await _ReadOnlyData.EveShipsTable.LoadAsync();
            eveShipsRowBindingSource.DataSource = _ReadOnlyData.EveShipsTable.Local.ToBindingList();
        }

        private ComboBox _ShipCombo;
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            _ShipCombo = e.Control as ComboBox;
            if (_ShipCombo != null) {
                _ShipCombo.DropDownStyle = ComboBoxStyle.DropDown;
                _ShipCombo.AutoCompleteMode  = AutoCompleteMode.SuggestAppend;
                _ShipCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void dataGridView_CellLeave(object sender, DataGridViewCellEventArgs e) {
            //if (_ShipCombo != null) {
            //    _ShipCombo.SelectedIndex = _ShipCombo.FindStringExact(_ShipCombo.Text);
            //    if (_ShipCombo.SelectedIndex != -1) {                    
            //        long charactedID = (long) dataGridView[CharacterID.Index, e.RowIndex].Value;
            //        IntelData.IntelDataRow row = _IntelData.IntelDataTable.Single(o => o.CharacterID == charactedID);
            //        row.ShipTypeID = (int?) _ShipCombo.SelectedValue;
            //        row.ShipTypeTime = DateTime.UtcNow;
            //        _IntelData.IntelDataTable.AddOrUpdate(row);
            //        _IntelData.SaveChanges();
            //        _ReadOnlyData.IntelGridTable.Load();
            //        dataGridView.InvalidateRow(e.RowIndex);
            //    }
            //}
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (_ShipCombo != null) {
                _ShipCombo.SelectedIndex = _ShipCombo.FindStringExact(_ShipCombo.Text);
                if (_ShipCombo.SelectedIndex != -1) {
                    long charactedID = (long)dataGridView[CharacterID.Index, e.RowIndex].Value;
                    IntelData.IntelDataRow row = _IntelData.IntelDataTable.Single(o => o.CharacterID == charactedID);
                    row.ShipTypeID = (int?)_ShipCombo.SelectedValue;
                    row.ShipTypeTime = DateTime.UtcNow;
                    _IntelData.IntelDataTable.AddOrUpdate(row);
                    _IntelData.SaveChanges();
                    _ReadOnlyData.IntelGridTable.Load();
                    dataGridView.InvalidateRow(e.RowIndex);
                }
            }


        }
    }
}
