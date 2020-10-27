﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cashier
{
    public partial class ItemOptions : UserControl
    {
        String activity, ItemCode;
        public ItemOptions(String activity,String itemCode)
        {
            this.activity = activity;
            this.ItemCode = itemCode;
            InitializeComponent();
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (activity == "add")
            {
                
                bool y=new Activities().addNewItem(txtItemCode.Text,txtName.Text,txtPrice.Text,txtSize.Text,"");
                if (y == true)
                {
                    txtItemCode.Text = (int.Parse(ItemCode) + 1).ToString();
                    MessageBox.Show("item added");
                }
                else
                {
                    MessageBox.Show("something wrong");


                }
            }
            else if (activity == "update")
            {
                bool y = new Activities().addNewItem(txtItemCode.Text, txtName.Text, txtPrice.Text, txtSize.Text, "");
                if (y == true)
                {
                    MessageBox.Show("item added");
                }
                else
                {
                    MessageBox.Show("something wrong");


                }

            }
            else
            {

            }

            if (activity == "delete")
              {
            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=indunil;pwd=123;";
            conn = new MySqlConnection(connetionString);
            conn.Open();
            try
            {
                MySqlCommand deletecmd = new MySqlCommand("delete from itemlist_tb WHERE itemCode='" + txtItemCode.Text + "'", conn);
                deletecmd.ExecuteNonQuery();
                MessageBox.Show("Deleted!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        }

        private void ItemOptions_Load(object sender, EventArgs e)
        {
            //txtItemCode.Text = (int.Parse(ItemCode)+1).ToString();
        }

        private void txtItemCode_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSize_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
