﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_RepositoryDLL.Services.Admin;
using ClassLibrary_RepositoryDLL.Entities;

namespace BookEccommerce_Admin
{
    public partial class CateAdmin : Form
    {
        private BookManagementService _bookManagement;
        public CateAdmin(BookManagementService bookManagement)
        {
            _bookManagement = bookManagement;
        }
        public CateAdmin()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int cateId = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
                Category cate =_bookManagement.viewCategory(cateId);
                if (cate != null)
                {
                    textBox2.Text = cate.Id.ToString();
                    textBox1.Text = cate.Categoryname;
                }
            }
        }

        private void CateAdmin_Load(object sender, EventArgs e)
        {
            List<Category> categories =_bookManagement.viewAllCategory();
            dataGridView2.DataSource = categories;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category newCate = new Category()
            {
                Categoryname = textBox1.Text.Trim(),
            };
           _bookManagement.addCate(newCate);
            List<Category> categories =_bookManagement.viewAllCategory();
            dataGridView2.DataSource = categories;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Category newCate = new Category()
            {
                Id = int.Parse(textBox2.Text.Trim()),
                Categoryname = textBox1.Text.Trim()
            };
            bool result =_bookManagement.updateCate(newCate);
            if (result)
            {
                List<Category> categories =_bookManagement.viewAllCategory();
                dataGridView2.DataSource = categories;
                MessageBox.Show("SUCCESS");
            }
            else { MessageBox.Show("SORRY BAE"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int Id = int.Parse(textBox2.Text);
                bool result =_bookManagement.delCate(Id);
                if (result)
                {
                    List<Category> categories =_bookManagement.viewAllCategory();
                    dataGridView2.DataSource = categories;
                }
                else { MessageBox.Show("SORRY BAE"); }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyword = textBox6.Text.Trim();
            List<Category> categories = _bookManagement.SearchCate(keyword);
            dataGridView2.DataSource = categories;
        }
    }
}
