using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetVillage
{
    public class BaiduVillage
    {
        private readonly string key = "cedad1d352560ac825c52823046d2f63";
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        HttpClient httpClient;
        string url = @"https://map.baidu.com/?newmap=1&reqflag=pcmap&biz=1&from=webmap&da_par=baidu&pcevaname=pc4.1&qt=s&da_src=searchBox.button&wd=%E5%9B%9B%E5%B7%9D%E5%8D%97%E5%85%85%E9%A1%BA%E5%BA%86%E5%8C%BA%20%E5%B0%8F%E5%8C%BA&c=291&src=0&wd2=&pn=1&sug=0&l=14&b=(11795842.460001448,3578828.1899997997;11826562.460001448,3593916.1899997997)&from=webmap&biz_forward={%22scaler%22:1,%22styles%22:%22pl%22}&sug_forward=&tn=B_NORMAL_MAP&nn=0&u_loc=12942012,4815509&ie=utf-8&t=1521477941230";

        public BaiduVillage()
        {
            httpClientHandler.CookieContainer = new CookieContainer();
            httpClient = new HttpClient(httpClientHandler);
            httpClient.BaseAddress = new Uri("http://restapi.amap.com");
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            //httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh-CN"));
            //httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh"));
            //httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("zh-HK", 0.5));
            //httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US", 0.3));
            //httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en", 0.2));
            //httpClient.DefaultRequestHeaders.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:59.0) Gecko/20100101 Firefox/59.0");
            //httpClient.DefaultRequestHeaders.Referrer = new Uri("https://map.baidu.com/");


        }
        List<PoisItem> All = new List<PoisItem>();
        public async void GetVillageList(int adcode, int PageNo = 0)
        {
            string url1 = $"/v3/place/text?key={key}&keywords=小区&types=120302&city={adcode}&children=1&offset=1&page={PageNo}&extensions=all";
            //var txt = await httpClient.GetStringAsync("https://map.baidu.com");

            var json = await httpClient.GetStringAsync(url1);
            var root = JsonConvert.DeserializeObject<Root>(json);
            All.AddRange(root.pois);
            if (PageNo > 20) return;
            GetVillageList(adcode, ++PageNo);
        }
    }
}
