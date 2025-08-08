using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sinuosity.Forms
{
    public partial class TextBlockInput : Form
    {

        public string ResultText { get; private set; }

        public TextBlockInput(string text, string title)
        {
            InitializeComponent();
            ResultText =  text;
            tb_Notes.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultText = tb_Notes.Text; // Update the reference with new text
            DialogResult = DialogResult.OK; // This will return true when checked
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // This will return false when checked
            Close();
        }

        private void tb_ProjectDescription_Leave(object sender, EventArgs e)
        {
            //_text = tb_ProjectDescription.Text;
        }
    }
}
