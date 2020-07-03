using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_array
{
    public partial class Form1 : Form
    {
        string kat;
        int jumlah;
        string[] kode;
        string[] nama;
        string[] kategori;
        string[] tanggal;
        string[] judul;
        string[] studio;
        string[] jam;
        double[] hargaAwal;


        int i = 0;
        
        double[] diskon;
        double hargaAkhir;

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPelajar.Checked)
            {
                kat = rbPelajar.Text;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            jumlah = Convert.ToInt32(txtJumlahTiket.Text);

            kode = new string[jumlah];
            nama = new string[jumlah];
            kategori = new string[jumlah];
            tanggal = new string[jumlah];
            judul = new string[jumlah];
            studio = new string[jumlah];
            jam = new string[jumlah];
            hargaAwal = new double[jumlah];
            diskon = new double[jumlah];
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (i <= jumlah - 1)
            {
                kode[i] = txtKode.Text;
                nama[i] = txtNama.Text;
                kategori[i] = kat;
                tanggal[i] = dtpTanggal.Text;
                judul[i] = txtJudul.Text;
                studio[i] = cmbStudio.Text;
                jam[i] = cmbJam.Text;

                hargaAwal[i] = Convert.ToDouble(txtHargaAwal.Text);

                i++;
            }
            else
            {
                MessageBox.Show("Data tidak boleh lebih dari " + jumlah);
            }

            txtKode.Clear();
            txtNama.Clear();
            //rbUmum.CheckedChanged
            //rbPelajar.ResetText();
            dtpTanggal.ResetText();
            txtJudul.Clear();
            txtKode.Focus();
            txtHargaAwal.Text = "";
            cmbStudio.ResetText();
            cmbJam.ResetText();
        }

        private void rbUmum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUmum.Checked)
            {
                kat = rbUmum.Text;
            }
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < jumlah; j++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = j + i;
                dataGridView1.Rows[j].Cells[1].Value = kode[j];
                dataGridView1.Rows[j].Cells[2].Value = nama[j];
                dataGridView1.Rows[j].Cells[3].Value = kategori[j];
                dataGridView1.Rows[j].Cells[4].Value = tanggal[j];
                dataGridView1.Rows[j].Cells[5].Value = judul[j];
                dataGridView1.Rows[j].Cells[6].Value = studio[j];
                dataGridView1.Rows[j].Cells[7].Value = jam[j];
                

                if(kategori[j] == "Pelajar")
                {
                    diskon[j] = hargaAwal[j] * 20/100;
                }

                dataGridView1.Rows[j].Cells[8].Value = diskon[j];

                hargaAkhir = hargaAwal[j] - diskon[j];

                dataGridView1.Rows[j].Cells[9].Value = hargaAkhir;
       
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            txtKode.Clear();
            txtNama.Clear();
            //rbUmum.ResetText();
            //rbPelajar.ResetText();
            dtpTanggal.ResetText();
            txtJudul.Clear();
            txtKode.Focus();
            txtHargaAwal.Text = "";
            cmbStudio.ResetText();
            cmbJam.ResetText();
        }

        private void cmbJam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hargaMalam = 50000;
            int hargaSiang = 35000;

            if(cmbJam.Text=="21.00" || cmbJam.Text == "19.00")
            {
                txtHargaAwal.Text = Convert.ToString(hargaMalam);
            } else
            {
                txtHargaAwal.Text = Convert.ToString(hargaSiang);
            }
        }
    }
}

