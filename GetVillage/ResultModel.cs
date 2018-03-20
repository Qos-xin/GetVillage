using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVillage
{
    public class Suggestion
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> keywords { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> cities { get; set; }
    }

    public class Indoor_data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> cpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> floor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> truefloor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> cmsid { get; set; }
    }

    public class Biz_ext
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> rating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cost { get; set; }
    }

    public class ChildrenItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        ///  六里桥北里(西2门) 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        ///  西2门 
        /// </summary>
        public string sname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string location { get; set; }
        /// <summary>
        ///  吴家村路6号六里桥北里 
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string distance { get; set; }
        /// <summary>
        /// 门
        /// </summary>
        public string subtype { get; set; }
    }

    public class PhotosItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
    }

    public class PoisItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 六里桥北里
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> tag { get; set; }
        /// <summary>
        /// 商务住宅;住宅区;住宅小区
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string typecode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> biz_type { get; set; }
        /// <summary>
        /// 西三环
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<string> tel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> postcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> website { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pcode { get; set; }
        /// <summary>
        /// 北京市
        /// </summary>
        public string pname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string citycode { get; set; }
        /// <summary>
        /// 北京市
        /// </summary>
        public string cityname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adcode { get; set; }
        /// <summary>
        /// 丰台区
        /// </summary>
        public string adname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> importance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> shopid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopinfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> poiweight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gridcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> distance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string navi_poiid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string entr_location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string business_area { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> exit_location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string match { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string recommend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string indoor_map { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public Indoor_data indoor_data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string groupbuy_num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string discount_num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public Biz_ext biz_ext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<string> event { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<ChildrenItem> children { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<PhotosItem> photos { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string infocode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Suggestion suggestion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PoisItem> pois { get; set; }
    }
}
