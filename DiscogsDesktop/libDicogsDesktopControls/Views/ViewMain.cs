using System;
using System.Data;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlSelector;
using libDicogsDesktopControls.Extensions;
using libDicogsDesktopControls.Viewmodels;

namespace libDicogsDesktopControls.Views
{
    public sealed partial class ViewMain : UserControl
    {
        private readonly ViewMainViewmodel viewmodel = new ViewMainViewmodel();

        public ViewMain()
        {
            this.InitializeComponent();
            SoundPlayerControlSelector.Player = this.soundPlayer1;
            this.textBox1.DataBindings.Add(new Binding(nameof(this.textBox1.Text), this.viewmodel, nameof(this.viewmodel.SearchPattern), true, DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridView1.DataSource = this.viewmodel.ResultsTable;
            this.viewmodel.SelectedEntityChanged += viewmodelOnSelectedEntityChanged;
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
            if (this.dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }
            this.viewmodel.SelectSearchResult(((DataRowView)this.dataGridView1.SelectedRows[0].DataBoundItem).Row);
        }
    }
}