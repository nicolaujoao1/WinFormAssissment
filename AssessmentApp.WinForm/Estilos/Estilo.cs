using AssessmentApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.WinForm.Estilos
{
    public  class Estilo
    {
        public static void EstilizarDatagrid(DataGridView dataGridView1) {
            
            dataGridView1.Columns["Codigo"].HeaderText = "ID";
            dataGridView1.Columns["Nome"].HeaderText = "Nome";
            dataGridView1.Columns["Codigo"].Width = 100;
            dataGridView1.Columns["Nome"].Width = 100;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false; 
            dataGridView1.RowHeadersVisible = false; 

            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; 

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.RowTemplate.Height = 30;

        }

    }
}
