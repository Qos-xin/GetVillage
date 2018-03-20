using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;

namespace GetVillage
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();


        }
        private ConcurrentQueue<HouseInfo> houseInfos = new ConcurrentQueue<HouseInfo>();
        private async void MainFrom_Load(object sender, EventArgs e)
        {
            //BaiduVillage bv = new BaiduVillage();
            //bv.GetVillageList(110106);

        }
        public void Log(string str)
        {
            UI(() =>
            {
                listBox1.Items.Insert(0, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss ") + str);
            });
        }

        private void UI(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }
        bool flag = false;
        private async void button1_Click(object sender, EventArgs e)
        {
            var list = (await Village.GetHouseList("010")).Where(k => k.total != null);
            foreach (var item in list)
            {
                houseInfos.Enqueue(item);
            }
            Log($"成功加载{list.Count()}条信息!");
            flag = true;
        }
        List<Task> tasks = new List<Task>();
        static int ThreadQuantity = 10;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        private void button2_Click(object sender, EventArgs e)
        {
            if (!flag) return;
            if (button2.Text == "停止")
            {
                tokenSource.Cancel();
                Task.WhenAll(tasks).ContinueWith((t) =>
                {
                    UI(() =>
                    {
                        button2.Text = "开始";
                        tasks.Clear();
                    });
                });
                button2.Text = "停止中...";
            }
            else if (button2.Text == "开始")
            {
                ThreadHandle();
                button2.Text = "停止";
            }
        }
        private void ThreadHandle()
        {
            while (tasks.Count < ThreadQuantity)
            {
                tasks.Add(Task.Run(async () =>
                {
                    while (!tokenSource.IsCancellationRequested)
                    {
                        try
                        {
                            if (houseInfos.TryDequeue(out HouseInfo item))
                            {
                                var Url = await Village.Search(item.name);
                                if (Url == null) continue;
                                var Details = await Village.GetDetails(Url);
                                item.total = Details.Total;
                                item.maxLayer = Details.MaxLayer;
                                Log(string.Format("{0}/{1}小区        ,共{2}栋      ,最高{3}层     ", item.name, Details.Name, Details.Total, Details.MaxLayer));
                                Village.Update(item);
                            }
                            await Task.Delay(3000);
                        }
                        catch (Exception ex)
                        {
                            Log(string.Format("发生错误:{0}", ex.Message));
                            Log(ex.Message);
                            await Task.Delay(3000);
                        }
                    }

                }, tokenSource.Token));
            }

        }
    }
}
