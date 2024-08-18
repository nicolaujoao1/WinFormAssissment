using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessmentApp.WinForm
{
    public partial class FormPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public FormPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
 

       

        private void marcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var marcas = _serviceProvider.GetRequiredService<FormMarca>();
            marcas.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modelos = _serviceProvider.GetRequiredService<FormModelo>();
            modelos.Show();
        }

        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var veiculos = _serviceProvider.GetRequiredService<FormVeiculo>();
            veiculos.Show();
        }
    }
}
