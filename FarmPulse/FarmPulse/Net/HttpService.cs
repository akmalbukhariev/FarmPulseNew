using System;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;

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
        public static String URL_LOGIN = SERVER_URL;
        public static String URL_GET_DEMO_VIDEO = SERVER_URL;
        public static String URL_GET_INFO_ABOUT_APP = SERVER_URL;
        public static String URL_GET_FIELD_LIST = SERVER_URL;
        public static String URL_GET_GRAPH_VIEW_INFO = SERVER_URL;
        public static String URL_GET_CROP_LIST = SERVER_URL;
        public static String URL_GET_CROP_YIELD_DATA = SERVER_URL;
        public static String URL_SAVE_CROP_YIELD_DATA = SERVER_URL;
        public static String URL_GET_AREA_TON_HA = SERVER_URL;
        public static String URL_SAVE_SUBMIT_CLAIM = SERVER_URL;
        public static String URL_GET_HISTORY_OF_CLAIM = SERVER_URL;
        public static String URL_GET_HISTORY_OF_CROP_YIELD = SERVER_URL;
        public static String URL_GET_INSURANCE_INFO = SERVER_URL;
        public static String URL_BUY_INSURANCE = SERVER_URL;  
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
    #endregion

    #region Response
    public interface IResponse
    {
        void Check();
    }

    public class Response
    {
        public String result { get; set; }
        public String message { get; set; }
        public String error_code { get; set; }

        public virtual void Check()
        {
            if (result == null)
                result = "";
            if (message == null)
                message = "";
            if (error_code == null)
                error_code = "";
        }
    }

    public class ResponseLogin : Response
    {
        public UserInfo userInfo { get; set; }
    }

    public class ResponseDemo : Response
    {
        public string demoVideoUrl { get; set; }
    }

    public class ResponseGetAboutInfo : Response
    {
        public string strInfoText { get; set; }
    }

    public class ResponseGetField : Response
    {
        public List<FieldInfo> fields;
    }

    public class ResponseGetGraphView : Response, IResponse
    {
        public List<GraphViewInfo> chlorophylleList { get; set; }
        public List<GraphViewInfo> ndviList { get; set; }  
    }

    public class ResponseGetCropYieldData : Response
    {
        public string selectedField { get; set; }
        public string selectedCrop { get; set; }
        public List<string> fieldList { get; set; }
        public List<string> cropList { get; set; }
        public List<CropYieldDataYearInfo> yearInfoList { get; set; }
    }

    public class ResponseGetSubmitClaimHistory : Response, IResponse
    {
        
    }

    public class ResponseGetCropYieldDataHistory : Response, IResponse
    {
        
    }

    public class ResponseBuyInsurance : Response, IResponse
    {
        
    }
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
    #endregion
}
