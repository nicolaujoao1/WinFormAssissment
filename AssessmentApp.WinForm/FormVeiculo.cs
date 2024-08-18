using AssessmentApp.Services.DTOs;
using AssessmentApp.Services.Services;

namespace AssessmentApp.WinForm
{
    public partial class FormVeiculo : Form
    {
        private readonly IVeiculoService _veiculoService;
        public FormVeiculo(IVeiculoService veiculoService)
        {
            InitializeComponent();
            _veiculoService = veiculoService;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await _veiculoService.Adicionar(new VeiculoDTO
            {
                Placa = txtPlaca.Text,
                Chassi = txtChassi.Text,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                AnoFabricacao = int.Parse(txtAnoFabricacao.Text),
                AnoModelo = int.Parse(txtAnoModelo.Text),
                ValorTabelaFipe = decimal.Parse(txtValorFIPE.Text),
                ValorVenda = decimal.Parse(txtValorVenda.Text),
                Observacoes = txtObervacao.Text,

            });

            if (result)
            {
                MessageBox.Show("Dados cadastrado com sucesso");
                var veiculos = await _veiculoService.ListarVeiculos();
                PreencherDataGridView(veiculos);
                LimparCampos();
            }
        }

        private async void FormVeiculo_Load(object sender, EventArgs e)
        {
            var veiculos= await _veiculoService.ListarVeiculos();
            PreencherDataGridView(veiculos);    
        }

        private void PreencherDataGridView(IEnumerable<VeiculoDTO> veiculos) {
            dataGridView1.Refresh();

            dataGridView1.ReadOnly=true;   
            dataGridView1.AllowUserToAddRows = false;  
            dataGridView1.RowHeadersVisible = false;   
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = veiculos;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Columns["Chassi"].Visible = false;
            dataGridView1.Columns["Observacoes"].Visible = false;
            dataGridView1.RowTemplate.Height = 30;
        }
        private void LimparCampos()
        {
            txtPlaca.Text = string.Empty;
            txtChassi.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtAnoFabricacao.Text = string.Empty;
            txtAnoModelo.Text = string.Empty;
            txtValorFIPE.Text = string.Empty;
            txtValorVenda.Text = string.Empty;
            txtObervacao.Text = string.Empty;
        }


        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminado = await _veiculoService.Deletar(Convert.ToInt64(txtId.Text));

            if (eliminado)
            {
                MessageBox.Show("dados eliminado com sucesso!");
                var veiculos = await _veiculoService.ListarVeiculos();
                PreencherDataGridView(veiculos);
                btnEliminar.Enabled = false;
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var result = await _veiculoService.Editar(new VeiculoDTO
            {
                Id = Convert.ToInt64(txtId.Text),
                Chassi = txtChassi.Text,
                Placa = txtPlaca.Text,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                AnoFabricacao = int.Parse(txtAnoFabricacao.Text),
                AnoModelo = int.Parse(txtAnoModelo.Text),
                ValorTabelaFipe = decimal.Parse(txtValorFIPE.Text),
                ValorVenda = decimal.Parse(txtValorVenda.Text),
                Observacoes = txtObervacao.Text

            });

            if (result)
            {
                MessageBox.Show("Dados Editado com sucesso!");
                var veiculos = await _veiculoService.ListarVeiculos();
                PreencherDataGridView(veiculos);
                LimparCampos();
                btnEditar.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                btnEliminar.Enabled = true;

            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Acessa a linha selecionada
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Preenche os TextBox com os valores da linha selecionada
                txtPlaca.Text = row.Cells["Placa"].Value.ToString();
                //txtChassi.Text = row.Cells["Chassi"].Value.ToString();
                txtMarca.Text = row.Cells["Marca"].Value.ToString();
                txtModelo.Text = row.Cells["Modelo"].Value.ToString();
                txtAnoFabricacao.Text = row.Cells["AnoFabricacao"].Value.ToString();
                txtAnoModelo.Text = row.Cells["AnoModelo"].Value.ToString();
                txtValorFIPE.Text = row.Cells["ValorTabelaFipe"].Value.ToString();
                txtValorVenda.Text = row.Cells["ValorVenda"].Value.ToString();
                button1.Enabled = false;
                btnEliminar.Enabled = false;
                btnEditar.Enabled = true;
                //txtObservacao.Text = row.Cells["Observacoes"].Value.ToString();
            }

        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtValorFIPE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAnoModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAnoFabricacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

}
