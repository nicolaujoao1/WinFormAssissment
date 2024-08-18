
using AssessmentApp.Services.DTOs;
using AssessmentApp.WinForm.Estilos;

namespace AssessmentApp.WinForm
{
    public partial class FormModelo : Form
    {
        private readonly IModeloService _modeloService;
        public FormModelo(IModeloService modeloService)
        {
            InitializeComponent();
            _modeloService = modeloService;
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (string.IsNullOrEmpty(txtPesquisar.Text))
                {
                    MessageBox.Show("O campo de pesquisa não pode estar vazio");
                    txtPesquisar.Clear();
                    return;
                }

                var marcas = await _modeloService.ListarMarcasAsync(Convert.ToInt64(txtPesquisar.Text));

                txtPesquisar.Clear();

                if (marcas.Any())
                {
                    dataGridView1.DataSource = marcas;

                    dataGridView1.Columns["Codigo"].HeaderText = "ID";
                    dataGridView1.Columns["Nome"].HeaderText = "Nome";
                    dataGridView1.Columns["Codigo"].Width = 100;
                    dataGridView1.Columns["Nome"].Width = 100;
                    Estilo.EstilizarDatagrid(dataGridView1);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira um número válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }

        private void FormModelo_Load(object sender, EventArgs e)
        {

        }
    }
}
