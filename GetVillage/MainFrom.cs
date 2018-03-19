using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetVillage
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
            

        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            BaiduVillage bv = new BaiduVillage();
            bv.GetVillageList("广东广州河西区");

        }
    }
}
