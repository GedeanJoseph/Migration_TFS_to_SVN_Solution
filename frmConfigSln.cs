using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigracaoSVN
{
    public partial class frmConfigSln : Form
    {
        public frmConfigSln()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void defineCaminhoArquivo()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            folderBrowser.ShowDialog();
            
            txtPath.Text = folderBrowser.SelectedPath;
        }

        private void btnGetPath_Click(object sender, EventArgs e)
        {
            defineCaminhoArquivo();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
