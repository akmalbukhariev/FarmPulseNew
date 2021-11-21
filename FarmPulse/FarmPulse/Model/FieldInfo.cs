using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FarmPulse.Model
{
    public class FieldInfo : ModelView.BaseModel
    {
        #region Properties
        public string sequence { get; set; }
        public string tenantId { get; set; }
        public string fieldId { get; set; }
        public string username { get; set; } 
        public string villageSequence { get; set; }
        public string villageName { get; set; } 
        public string name { get; set; }
        public string polygon { get; set; }
        public string apiKey { get; set; }
        public string center { get; set; }
        public string cropId { get; set; }
        public string cropName { get; set; }
        public string area { get; set; }
        public string comment { get; set; }
        #endregion

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
             
        }
         
        /// <summary>
        /// Deep copy
        /// </summary>
        /// <param name="other"></param>
        public void Copy(FieldInfo other)
        { 
            this.sequence = other.sequence;
            this.tenantId = other.tenantId;
            this.fieldId = other.fieldId;
            this.username = other.username;
            this.villageSequence = other.villageSequence;
            this.villageName = other.villageName;
            this.name = other.name;
            this.polygon = other.polygon;
            this.apiKey = other.apiKey;
            this.center = other.center;
            this.cropId = other.cropId;
            this.cropName = other.cropName;
            this.area = other.area;
            this.comment = other.comment; 
        }
    }
}
