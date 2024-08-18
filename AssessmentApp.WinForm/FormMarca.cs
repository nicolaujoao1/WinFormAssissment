using AssessmentApp.Services.DTOs;
using AssessmentApp.WinForm.Estilos;

namespace AssessmentApp.WinForm
{
    public partial class FormMarca : Form
    {
        private readonly IMarcaService _marcaService;
        public FormMarca(IMarcaService marcaService)
        {
            InitializeComponent();
            _marcaService = marcaService;
        }

        private async void FormMarca_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            label2.Visible = true;
            var marcas = await _marcaService.ListarMarcasAsync();

            label2.Visible = false;
            dataGridView1.DataSource = marcas;

            dataGridView1.Columns["Codigo"].HeaderText = "ID";
            dataGridView1.Columns["Nome"].HeaderText = "Nome";
            dataGridView1.Columns["Codigo"].Width = 100;
            dataGridView1.Columns["Nome"].Width = 100;
            Estilo.EstilizarDatagrid(dataGridView1);

            dataGridView1.Visible = true;
        }




    }
}
