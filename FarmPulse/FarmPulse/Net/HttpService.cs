﻿using System;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace FarmPulse.Net
{
    public class HttpService
    {
        #region Url

        #region Agro Monitoring
        public static String APIKey = "";//"b5efce714742cc3aba8062b29f8c86f1";//"604b73c1fe1e170ab03912a578e1f522";
        public static String URL_AGRO_SERVER = "http://api.agromonitoring.com/agro/1.0";
        public static String URL_CREATE_POLYGON = URL_AGRO_SERVER + "/polygons?appid=" + APIKey;
        public static String URL_POLYGON_INFO = URL_AGRO_SERVER + "/polygons";
        public static String URL_POLYGON_LIST_INFO = URL_AGRO_SERVER + "/polygons?appid=" + APIKey;
        public static String URL_GET_SATELLITE_IMAGES = URL_AGRO_SERVER + "/image/search?start";
        #endregion

        #region User Info
        public static String SERVER_URL = "http://206.81.29.167/api";
        public static String URL_LOGIN = SERVER_URL + "";
        public static String URL_GET_DEMO_VIDEO = SERVER_URL + "";
        public static String URL_GET_INFO_ABOUT_APP = SERVER_URL + "";
        public static String URL_GET_FIELD_LIST = SERVER_URL + "";
        public static String URL_GET_GRAPH_VIEW_INFO = SERVER_URL + "";
        public static String URL_GET_CROP_LIST = SERVER_URL + "";
        public static String URL_GET_CROP_YIELD_DATA = SERVER_URL + "";
        public static String URL_SAVE_CROP_YIELD_DATA = SERVER_URL + "";
        public static String URL_GET_AREA_TON_HA = SERVER_URL + "";
        public static String URL_SAVE_SUBMIT_CLAIM = SERVER_URL + "";
        public static String URL_GET_HISTORY_OF_CLAIM = SERVER_URL + "";
        public static String URL_GET_HISTORY_OF_CROP_YIELD = SERVER_URL + "";
        public static String URL_GET_INSURANCE_INFO = SERVER_URL + "";
        public static String URL_BUY_INSURANCE = SERVER_URL + "";  
        #endregion

        #endregion

        private static HttpStatusCode StatusCode;
        private static readonly HttpClient Client = new HttpClient();
        private static readonly WebClient webClient = new WebClient();
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public HttpService()
        {

        }

        public async static Task<ResponseLogin> Login(RequestLogin data)
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestPostMethod(URL_LOGIN, data);
                response = JsonConvert.DeserializeObject<ResponseLogin>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseLogin>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseLogin>(); }

            ResponseLogin responseLogin = ConvertResponseObj<ResponseLogin>(response);

            if (responseLogin.result == true)
            {
                APIKey = responseLogin.agromon;
                URL_CREATE_POLYGON = URL_AGRO_SERVER + "/polygons?appid=" + APIKey;
                URL_POLYGON_LIST_INFO = URL_AGRO_SERVER + "/polygons?appid=" + APIKey;
            }

            return responseLogin;
        }

        public async static Task<ResponseDemo> GetDemoVidieoUrl()
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestGetMethod(URL_GET_DEMO_VIDEO);
                response = JsonConvert.DeserializeObject<ResponseDemo>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseDemo>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseDemo>(); }
             
            return ConvertResponseObj<ResponseDemo>(response); ;
        }

        public async static Task<ResponseAboutInfo> GetInfoAboutApp()
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestGetMethod(URL_GET_INFO_ABOUT_APP);
                response = JsonConvert.DeserializeObject<ResponseAboutInfo>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseAboutInfo>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseAboutInfo>(); }

            return ConvertResponseObj<ResponseAboutInfo>(response); ;
        }

        public async static Task<ResponseField> GetInfoList(RequestField data)
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestGetMethod(URL_GET_FIELD_LIST, data);
                response = JsonConvert.DeserializeObject<ResponseField>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseField>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseField>(); }

            return ConvertResponseObj<ResponseField>(response); ;
        }

        public async static Task<ResponseGraphView> GetGraphyViewInfo(RequestGraphViewInfo data)
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestGetMethod(URL_GET_GRAPH_VIEW_INFO, data);
                response = JsonConvert.DeserializeObject<ResponseGraphView>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseGraphView>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseGraphView>(); }

            return ConvertResponseObj<ResponseGraphView>(response); ;
        }

        public async static Task<ResponseCropYieldData> GetCropYieldData(RequestCropYieldData data)
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestGetMethod(URL_GET_CROP_YIELD_DATA, data);
                response = JsonConvert.DeserializeObject<ResponseCropYieldData>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseCropYieldData>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseCropYieldData>(); }

            return ConvertResponseObj<ResponseCropYieldData>(response); ;
        }

        public async static Task<ResponseCropYieldDataSave> SaveCropYieldData(RequestCropYieldDataSave data)
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestPostMethod(URL_SAVE_CROP_YIELD_DATA, data);
                response = JsonConvert.DeserializeObject<ResponseCropYieldDataSave>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseCropYieldDataSave>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseCropYieldDataSave>(); }

            return ConvertResponseObj<ResponseCropYieldDataSave>(response); ;
        }

        public async static Task<ResponseSubmitClaim> SubmitClaim(RequestSubmitClaim data)
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestPostMethod(URL_SAVE_SUBMIT_CLAIM, data);
                response = JsonConvert.DeserializeObject<ResponseSubmitClaim>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseSubmitClaim>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseSubmitClaim>(); }

            return ConvertResponseObj<ResponseSubmitClaim>(response); ;
        }

        public async static Task<ResponseBuyInsurance> PurchaseInsurance(RequestBuyInsurance data)
        {
            Response response = new Response();
            try
            {
                var receivedData = await RequestPostMethod(URL_BUY_INSURANCE, data);
                response = JsonConvert.DeserializeObject<ResponseBuyInsurance>(receivedData, settings);
            }
            catch (JsonReaderException) { return CreateResponseObj<ResponseBuyInsurance>(); }
            catch (HttpRequestException) { return CreateResponseObj<ResponseBuyInsurance>(); }

            return ConvertResponseObj<ResponseBuyInsurance>(response); ;
        }

        public async static Task<List<ResponseSatelliteImagesInfo>> GetSatelliteImagesInfo(RequestGetSatelliteImagesInfo data)
        {
            List<ResponseSatelliteImagesInfo> responseAlldata = new List<ResponseSatelliteImagesInfo>();
            try
            {
                string strRequest = string.Format("{0}={1}&end={2}&polyid={3}&appid={4}", URL_GET_SATELLITE_IMAGES, data.start, data.end, data.polyid, APIKey);
                var receivedData = await Client.GetAsync(strRequest);
                string result = await receivedData.Content.ReadAsStringAsync();

                if (receivedData.StatusCode == HttpStatusCode.OK)
                {
                    responseAlldata = (List<ResponseSatelliteImagesInfo>)JsonConvert.DeserializeObject(result, typeof(List<ResponseSatelliteImagesInfo>));
                    for (int i = 0; i < responseAlldata.Count; i++)
                    {
                        responseAlldata[i].StatusCode = receivedData.StatusCode;
                        responseAlldata[i].Check();
                    }
                }
                else
                {
                    ResponseSatelliteImagesInfo errorData = JsonConvert.DeserializeObject<ResponseSatelliteImagesInfo>(result);
                    errorData.StatusCode = receivedData.StatusCode;
                    errorData.Check();
                    responseAlldata.Add(errorData);
                }

            }
            catch (JsonReaderException) { return new List<ResponseSatelliteImagesInfo>(); }
            catch (HttpRequestException) { return new List<ResponseSatelliteImagesInfo>(); }

            return responseAlldata;
        }

        /// <summary>
        /// Download the satellite image.
        /// </summary>
        /// <param name="imUrl"></param>
        /// <returns></returns>
        public static Task<byte[]> GetSatelliteImagery(string imUrl)
        {
            return webClient.DownloadDataTaskAsync(imUrl);
        }

        /// <summary>
        /// Save data to the server.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static async Task<string> RequestPostMethod(string url, Object obj)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(obj), ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            return response.Content;
        }

        /// <summary>
        /// Get data from server.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static async Task<string> RequestGetMethod(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            return response.Content;
        }

        private static async Task<string> RequestGetMethod(string url, Object data)
        {
            //string sss = JsonConvert.SerializeObject(data).ToString();

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
             
            request.AlwaysMultipartFormData = true;

            request.AddParameter("data", JsonConvert.SerializeObject(data));
             
            IRestResponse response = await client.ExecuteAsync(request);
            return response.Content;
        }

        private static T CreateResponseObj<T>() where T : IResponse, new()
        {
            T t = new T();
            t.Check();
            return t;
        }

        private static T ConvertResponseObj<T>(Response response) where T : IResponse, new()
        {
            T t = (T)Convert.ChangeType(response, typeof(T));
            if (t == null)
                t = new T();
            t.Check();

            return t;
        } 
    }

    #region Request
    public class IRequest
    {
        public string username { get; set; }
        public string languageCode { get; set; }
    }

    public class RequestLogin : IRequest
    { 
        public string password { get; set; }
    }

    public class RequestField : IRequest
    {   

    }

    public class RequestGraphViewInfo : IRequest
    {
        
    }

    public class RequestCropYieldData : IRequest
    {
        
    }

    public class RequestCropYieldDataSave : IRequest
    {
        public string fieldName { get; set; }
        public string cropName { get; set; }
        public List<CropYieldDataYearInfo> yearInfoList { get; set; }
    }

    public class RequestSubmitClaim : IRequest
    { 

    }

    public class RequestSubmitClaimHistory : IRequest
    {
        
    }

    public class RequestCropYieldDataHistory : IRequest
    {

    }

    public class RequestBuyInsurance : IRequest
    {
        public string fieldName { get; set; }
        public string cropName { get; set; }
        public string hectars { get; set; }
        public string farmerName { get; set; }
        public string phoneNumber { get; set; }
    }

    public class RequestGetSatelliteImagesInfo
    {
        /// <summary>
        /// Start date
        /// </summary>
        public string start { get; set; }
        /// <summary>
        /// End date
        /// </summary>
        public string end { get; set; }
        public string polyid { get; set; }
    }
    #endregion

    #region Response
    public interface IResponse
    {
        void Check();
    }

    public class Response
    {
        public bool result { get; set; }
        public String message { get; set; }
        public String error_code { get; set; }

        public virtual void Check()
        { 
            if (message == null)
                message = "";
            if (error_code == null)
                error_code = "";
        }
    }

    public class ResponseAgro
    {
        public int cod { get; set; }
        public string title { get; set; }
        public String message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public virtual void Check()
        {
        }
    }
     
    public class ResponseLogin : Response, IResponse
    {
        public string agromon { get; set; }
        public UserInfo userInfo { get; set; }
    }

    public class ResponseDemo : Response, IResponse
    {
        public string demoVideoUrl { get; set; }
    }

    public class ResponseAboutInfo : Response, IResponse
    {
        public string strInfoText { get; set; }
    }

    public class ResponseField : Response, IResponse
    {
        public List<FieldInfo> fields;
    }

    public class ResponseGraphView : Response, IResponse
    {
        public List<GraphViewInfo> chlorophylleList { get; set; }
        public List<GraphViewInfo> ndviList { get; set; }  
    }

    public class ResponseCropYieldData : Response, IResponse
    {
        public string selectedField { get; set; }
        public string selectedCrop { get; set; }
        public List<string> fieldList { get; set; }
        public List<string> cropList { get; set; }
        public List<CropYieldDataYearInfo> yearInfoList { get; set; }
    }

    public class ResponseSubmitClaim : Response, IResponse
    {
        
    }

    public class ResponseSubmitClaimHistory : Response, IResponse
    {
        
    }

    public class ResponseCropYieldDataHistory : Response, IResponse
    {
        
    }

    public class ResponseCropYieldDataSave : Response, IResponse
    {
        
    }

    public class ResponseBuyInsurance : Response, IResponse
    {
        
    }

    #region For Agro Monitoring
    public class ReponsePolyognList : ResponseAgro, IResponse
    {
        public List<ResponsePolygon> ResponsePolygon { get; set; }

        public override void Check()
        {
            base.Check();

            if (ResponsePolygon == null)
                ResponsePolygon = new List<ResponsePolygon>();
            else
            {
                for (int i = 0; i < ResponsePolygon.Count; i++)
                {
                    if (ResponsePolygon[i] == null)
                        ResponsePolygon[i] = new ResponsePolygon();
                    else
                        ResponsePolygon[i].Check();
                }
            }
        }
    }

    public class ResponsePolygon : ResponseAgro, IResponse
    {
        public string id { get; set; }
        public GeoJson geo_json { get; set; }
        public string name { get; set; }
        public List<double> center { get; set; }
        public double area { get; set; }
        public string user_id { get; set; }

        public override void Check()
        {
            base.Check();

            if (id == null)
                id = "";
            if (geo_json == null)
                geo_json = new GeoJson();
            else
                geo_json.Check();

            if (name == null)
                name = "";
            if (center == null)
                center = new List<double>();
            if (user_id == null)
                user_id = "";
        }
    }

    public class ResponseDeletePolygon : ResponseAgro, IResponse
    {
        public override void Check()
        {
            base.Check();
        }
    }

    public class ResponseSatelliteImagesInfo : ResponseAgro, IResponse
    {
        public int dt { get; set; }
        public string type { get; set; }
        public int dc { get; set; }
        public double cl { get; set; }
        public Sun sun { get; set; }
        public Image image { get; set; }
        public Tile tile { get; set; }
        public Stats stats { get; set; }
        public Data data { get; set; }

        public override void Check()
        {
            base.Check();

            if (type == null)
                type = "";
            if (sun == null)
                sun = new Sun();
            if (image == null)
                image = new Image();
            else image.Check();
            if (tile == null)
                tile = new Tile();
            else tile.Check();
            if (stats == null)
                stats = new Stats();
            else stats.Check();
            if (data == null)
                data = new Data();
            else data.Check();
        }
    }
    #endregion

    #endregion
     
    #region Helper classes
    public class UserInfo
    {
        //User info here
    }
    public class FieldInfo
    {
        public string district_code { get; set; }
        public string field_id { get; set; }
        public string name { get; set; }
        public string polygon { get; set; }
        public string pol_api_key { get; set; }
        public string center { get; set; }
        public string suiv_name { get; set; }
        public string user_id { get; set; }

        public List<double> GetCenter()
        {
            List<double> centerList = new List<double>();

            if (center == null) return centerList;
            string[] strList = center.Split(',');

            if (strList.Length == 2)
            {
                centerList.Add(double.Parse(strList[0], CultureInfo.InvariantCulture));
                centerList.Add(double.Parse(strList[1], CultureInfo.InvariantCulture));
            }

            return centerList;
        }

        public FieldInfo()
        {
            Check();
        }

        public void Check()
        {
            if (district_code == null)
                district_code = "";
            if (field_id == null)
                field_id = "";
            if (name == null)
                name = "";
            if (polygon == null)
                polygon = "";
            if (pol_api_key == null)
                pol_api_key = "";
            if (center == null)
                center = "";
            if (suiv_name == null)
                suiv_name = "";
            if (user_id == null)
                user_id = "";
        }
    }
    public class GraphViewInfo
    {
        public string cropName { get; set; }
        public List<GraphViewData> dataList { get; set; }
    } 
    public class GraphViewData
    {
        public string year { get; set; }
        public string value { get; set; }
         
        public void Check()
        {
            if (year == null)
                year = "";
            if (value == null)
                value = "";
        }
    } 
    public class CropYieldDataYearInfo
    {
        public string year { get; set; }
        public string value { get; set; }
    }
    public class CropYieldDataHistoryInfo
    {
        public string fieldName { get; set; }
        public string cropName { get; set; }
        public List<CropYieldDataYearInfo> yearInfoList { get; set; }
    }
    public class SubmitClaimHistoryInfo
    {
        public string fieldName { get; set; }
        public string cropName { get; set; }
        public string area_ton_ha { get; set; }
        public string farmerName { get; set; }
        public string phoneNumber { get; set; }
        public string description { get; set; }
    }

    #region For Agro Monitoring
    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }

        public Geometry()
        {
            Check();
        }

        public void Check()
        {
            if (type == null)
                type = "";
            if (coordinates == null)
                coordinates = new List<List<List<double>>>();
        }
    }

    public class GeoJson
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }

        public GeoJson()
        {
            Check();
        }

        public void Check()
        {
            if (type == null)
                type = "";
            if (properties == null)
                properties = new Properties();
            if (geometry == null)
                geometry = new Geometry();
        }
    }

    public class Properties
    {
        public Properties()
        {
            Check();
        }

        public void Check()
        {

        }
    }

    public class Sun
    {
        public double elevation { get; set; }
        public double azimuth { get; set; }
    }

    public class Image
    {
        public string truecolor { get; set; }
        public string falsecolor { get; set; }
        public string ndvi { get; set; }
        public string evi { get; set; }
        public string evi2 { get; set; }
        public string nri { get; set; }
        public string dswi { get; set; }
        public string ndwi { get; set; }

        public Image()
        {
            Check();
        }

        public void Check()
        {
            if (truecolor == null)
                truecolor = "";
            if (falsecolor == null)
                falsecolor = "";
            if (ndvi == null)
                ndvi = "";
            if (evi == null)
                evi = "";
            if (evi2 == null)
                evi2 = "";
            if (nri == null)
                nri = "";
            if (dswi == null)
                dswi = "";
            if (ndwi == null)
                ndwi = "";
        }
    }

    public class Tile
    {
        public string truecolor { get; set; }
        public string falsecolor { get; set; }
        public string ndvi { get; set; }
        public string evi { get; set; }
        public string evi2 { get; set; }
        public string nri { get; set; }
        public string dswi { get; set; }
        public string ndwi { get; set; }

        public Tile()
        {
            Check();
        }

        public void Check()
        {
            if (truecolor == null)
                truecolor = "";
            if (falsecolor == null)
                falsecolor = "";
            if (ndvi == null)
                ndvi = "";
            if (evi == null)
                evi = "";
            if (evi2 == null)
                evi2 = "";
            if (nri == null)
                nri = "";
            if (dswi == null)
                dswi = "";
            if (ndwi == null)
                ndwi = "";
        }
    }

    public class Stats
    {
        public string ndvi { get; set; }
        public string evi { get; set; }
        public string evi2 { get; set; }
        public string nri { get; set; }
        public string dswi { get; set; }
        public string ndwi { get; set; }

        public Stats()
        {
            Check();
        }

        public void Check()
        {
            if (ndvi == null)
                ndvi = "";
            if (evi == null)
                evi = "";
            if (evi2 == null)
                evi2 = "";
            if (nri == null)
                nri = "";
            if (dswi == null)
                dswi = "";
            if (ndwi == null)
                ndwi = "";
        }
    }

    public class Data
    {
        public string truecolor { get; set; }
        public string falsecolor { get; set; }
        public string ndvi { get; set; }
        public string evi { get; set; }
        public string evi2 { get; set; }
        public string nri { get; set; }
        public string dswi { get; set; }
        public string ndwi { get; set; }

        public Data()
        {
            Check();
        }

        public void Check()
        {
            if (truecolor == null)
                truecolor = "";
            if (falsecolor == null)
                falsecolor = "";
            if (ndvi == null)
                ndvi = "";
            if (evi == null)
                evi = "";
            if (evi2 == null)
                evi2 = "";
            if (nri == null)
                nri = "";
            if (dswi == null)
                dswi = "";
            if (ndwi == null)
                ndwi = "";
        }
    }
    #endregion

    #endregion 
}