using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FarmPulse.Model
{
    public class FieldInfo : ModelView.BaseModel
    {
        public string district_code { get; set; }
        public string field_id { get; set; }
        public string name { get => GetValue<string>(); set => SetValue(value); }
        public string polygon { get; set; }
        public string pol_api_key { get; set; }
        public string center { get; set; }
        public string suiv_name { get => GetValue<string>(); set => SetValue(value); }
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

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public FieldInfo(FieldInfo other)
        {
            Copy(other);
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

        //public string FieldNameText { get => GetValue<string>(); set => SetValue(value); }
        //public string WUA_VillageText { get => GetValue<string>(); set => SetValue(value); }

        /// <summary>
        /// Deep copy
        /// </summary>
        /// <param name="other"></param>
        public void Copy(FieldInfo other)
        {
            this.district_code = other.district_code;
            this.field_id = other.field_id;
            this.name = other.name;
            this.polygon = other.polygon;
            this.pol_api_key = other.pol_api_key;
            this.center = other.center;
            this.suiv_name = other.suiv_name;
            this.user_id = other.user_id;
        }
    }
}
