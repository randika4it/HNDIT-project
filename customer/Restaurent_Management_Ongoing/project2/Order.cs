﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class Order : Form
    {
        frmKitchen kit = new frmKitchen();
        private String itemCode="";
        public String size = "";
        public String qty = "";
        public String ePrice = "";
        public String total = "";
        String orderNo = "";
        String tbleNo = "";
        public Order(String itemCode, String orderNo,String tbleNo)
        {
           
            InitializeComponent();
            this.itemCode = itemCode;
            this.orderNo = orderNo;
            this.tbleNo = tbleNo;
           
        }
       

        private void Order_Load(object sender, EventArgs e)
        {
            
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            qty = txtQty.Text;
            size = txtSize.SelectedItem.ToString();
            Console.WriteLine(size);
            ePrice=new OrderDb().searchItem(itemCode, size);
            Console.WriteLine("received"+size);
            total = (int.Parse(qty) * int.Parse(ePrice)).ToString();
            Console.WriteLine("received" + total);
            Console.WriteLine("in order tbNo " + tbleNo);
             new OrderDb().saveOrder(orderNo,itemCode, size, qty, ePrice, total, tbleNo);
            //Console.WriteLine(ePrice);
            
            sendToKitchen(itemCode,size,qty);
            this.Hide();
        }


        private void sendToKitchen(String name,String size,String qty)
        {
            kit.addItem(name,size,qty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
