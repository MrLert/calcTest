﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ClassLibrary;

namespace SuperCalc
{
    public partial class Form1 : Form
    {
        private class OperationB
        {
            public OperationB(IOperation operation)
            {
                Operation = operation;

                var type = operation.GetType();
                var Name = $"{type.Name}.{operation.Name}";
            }
            public IOperation Operation { get; set; }
            public string Name { get; set; }
        }
        private Calc Calc { get; }
        public Form1()
        {
            InitializeComponent();
            Calc = new Calc();
            //comboBoxOper.DataSource = Calc.operations.Select(o => new OperationB(o)).ToList();
            comboBoxOper.DataSource = Calc.DictionaryOperations.ToList();
            comboBoxOper.ValueMember = "Value";
            comboBoxOper.DisplayMember = "Key";
        }

        private void BTCALC_Click(object sender, EventArgs e)
        {
            object res = null;
            var operB = comboBoxOper.SelectedItem as OperationB;
            //var moreArgs = operB.Operation is IOperationArgs;
            var moreArgs = comboBoxOper.SelectedValue is IOperationArgs;
            var args = new List<object>();
            if (moreArgs)
            {
                args.AddRange(richTextBox1.Text.Split(' '));
            }
            else
            {
                var x = TBX.Text;
                var y = TBY.Text;
                args.Add(x);
                args.Add(y);
            }
            try
            {
                res = Calc.Execute(comboBoxOper.SelectedValue as IOperation, args.ToArray());
            }
            catch (Exception exception)
            {
                result.Text = $@"Error: {exception.Message}";
            }
            if (res!=null)
                result.Text = $@"{res}";
        }

        private void comboBoxOper_SelectedIndexChanged(object sender, EventArgs e)
        {
            var moreArgs = comboBoxOper.SelectedValue is IOperationArgs;
            panMoreArgs.Visible = moreArgs;
            panTwoAgrs.Visible = !moreArgs;
        }
    }
}
