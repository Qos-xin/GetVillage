using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetVillage
{
    public class Village
    {
        static string BaseUrl = "http://automate/api/";
        static HttpClient httpClient = new HttpClient();
        /// <summary>
        /// 获取小区列表
        /// </summary>
        /// <param name="Citycode"></param>
        /// <returns></returns>
        public static async Task<List<HouseInfo>> GetHouseList(string Citycode)
        {
            var txt = await httpClient.GetStringAsync(BaseUrl + $"HouseInfo/getHouseListByCity?CityCode={Citycode}");
            var HouseList = JsonConvert.DeserializeObject<ApiResult<List<HouseInfo>>>(txt);
            return HouseList.data;
        }
        /// <summary>
        /// 获取小区信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HouseInfo> GetHouse(string id)
        {
            var houseInfoText = await httpClient.GetStringAsync(BaseUrl + "/HouseInfo/getHouseListByCity");
            var houseInfo = JsonConvert.DeserializeObject<ApiResult<HouseInfo>>(houseInfoText);
            return houseInfo.data;
        }
        /// <summary>
        /// 搜索小区
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task<string> Search(string name)
        {
            var url = $"https://bj.lianjia.com/xiaoqu/rs{name}/";
            HtmlAgilityPack.HtmlWeb htmlWeb = new HtmlAgilityPack.HtmlWeb();
            var htmlSource = await htmlWeb.LoadFromWebAsync(url);
            var html = htmlSource.DocumentNode;
            var totalNode = html.SelectSingleNode("//h2[@class='total fl']/span");
            if (totalNode != null && int.TryParse(totalNode.InnerText, out int Total) && Total > 0)
            {
                var first = html.SelectSingleNode("//div[@class='content']/div/ul/li/div/div/a");
                if (first != null && Handle(name).Intersect(Handle(first.InnerText)).Count() > 2)
                {
                    return first.GetAttributeValue("href", "");
                }
            }
            return null;
        }
        /// <summary>
        /// 获取小区详细信息
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static async Task<LouInfo> GetDetails(string Url)
        {
            var louInfo = new LouInfo();
            HtmlAgilityPack.HtmlWeb htmlWeb = new HtmlAgilityPack.HtmlWeb();
            var htmlSource = await htmlWeb.LoadFromWebAsync(Url);
            var html = htmlSource.DocumentNode;
            var txt = html.SelectSingleNode("//div[@class='xiaoquDescribe fr']/div[@class='xiaoquInfo']")?.InnerText;
            if (int.TryParse(Regex.Match(txt, "\\d+(?=栋)").Value, out int Total))
            {
                louInfo.Total = Total;
            }
            louInfo.Name = html.SelectSingleNode("//div[@class='xiaoquDetailHeader']/div/div/h1")?.InnerText;

            var list = new List<int>();
            foreach (Match t in Regex.Matches(html.InnerText, "\\d+(?=层)"))
            {
                list.Add(Convert.ToInt16(t.Value));
            }
            if (list.Count > 0)
                louInfo.MaxLayer = list.Max();
            return louInfo;
        }
        /// <summary>
        /// 更新小区信息
        /// </summary>
        public static async void Update(HouseInfo houseInfo)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(houseInfo));
            httpContent.Headers.ContentType.MediaType = "application/json";
            var result = await httpClient.PostAsync(BaseUrl + "HouseInfo/update", httpContent);
            var data = await result.Content.ReadAsStringAsync();
            var status = JsonConvert.DeserializeObject<ApiResult<bool>>(data);
        }

        public static string Handle(string Name)
        {
            Name = Regex.Replace(Name, "\\d+", "");
            var str = new string[] { "号", "小", "区", "院" };
            foreach (var item in str)
            {
                Name = Name.Replace(item, "");
            }
            return Name;
        }
    }
    public class LouInfo
    {
        public string Name { get; set; }
        public int Total { get; set; }
        public int MaxLayer { get; set; }
    }
    public class HouseInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string adcode { get; set; }
        public string cityCode { get; set; }
        public string location { get; set; }
        public int? total { get; set; }
        public int? maxLayer { get; set; }
    }
    public class ApiResult<T>
    {
        public int code { get; set; }
        public string msg { get; set; }
        public DateTime time { get; set; }
        public T data { get; set; }
    }
}
