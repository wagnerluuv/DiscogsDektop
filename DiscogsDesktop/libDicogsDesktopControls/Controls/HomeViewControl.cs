﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlModels;
using libDicogsDesktopControls.ControlSelector;
using libDicogsDesktopControls.Extensions;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class HomeViewControl : UserControl
    {
        private readonly HomeViewControlModel viewmodel = new HomeViewControlModel();

        public HomeViewControl()
        {
            this.InitializeComponent();
            GlobalControls.DiscogsEntityControlPanel = this.panelSelected;
            GlobalControls.SoundPlayerControl = this.soundPlayer1;
            this.textBoxSearchPattern.DataBindings.Add(new Binding(nameof(this.textBoxSearchPattern.Text), this.viewmodel, nameof(this.viewmodel.SearchPattern), true,
                DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridView1.DataSource = this.viewmodel.ResultsTable;
            this.viewmodel.SelectedEntityChanged += this.viewmodelOnSelectedEntityChanged;
        }

        private void viewmodelOnSelectedEntityChanged()
        {
            this.panelSelected.InvokeIfRequired(() =>
            {
                this.panelSelected.Controls.Clear();
                Control control = DiscogsEntityControlSelector.GetControl(this.viewmodel.SelectedEntity);
                this.panelSelected.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            });
        }

        private void button1Click(object sender, EventArgs e)
        {
            this.viewmodel.Search();
        }

        private void dataGridView1SelectionChanged(object sender, EventArgs e)
        {
            this.panelSelected.Controls.Cast<Control>().FirstOrDefault()?.Dispose();

            if (this.dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }

            this.viewmodel.SelectSearchResult(((DataRowView)this.dataGridView1.SelectedRows[0].DataBoundItem).Row);
        }

        private void textBoxSearchPatternKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            this.viewmodel.Search();
        }
    }
}