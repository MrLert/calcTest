using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ClassLibrary;

namespace SuperCalc
{
    public partial class Form1 : Form
    {
        private Calc Calc { get; }
        public Form1()
        {
            InitializeComponent();
            Calc = new Calc();
            comboBoxOper.Items.AddRange(Calc.operations.Select(x=>x.Name).ToArray());
            comboBoxOper.DataSource = Calc.operations;
        }

        private void BTCALC_Click(object sender, EventArgs e)
        {
            object res = null;
            var moreArgs = comboBoxOper.SelectedItem is IOperationArgs;
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
                res = Calc.Execute(comboBoxOper.SelectedItem as IOperation, args.ToArray());
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
            var moreArgs = comboBoxOper.SelectedItem is IOperationArgs;
            panMoreArgs.Visible = moreArgs;
            panTwoAgrs.Visible = !moreArgs;
        }
    }
}
