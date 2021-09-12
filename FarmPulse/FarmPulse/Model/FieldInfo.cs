using System;
using System.Collections.Generic;
using System.Text;

namespace FarmPulse.Model
{
    public class FieldInfo : ModelView.BaseModel
    {
        public string FieldName { get => GetValue<string>(); set => SetValue(value); }
        public string WUA_Village { get => GetValue<string>(); set => SetValue(value); }

        public string FieldNameText { get => GetValue<string>(); set => SetValue(value); }
        public string WUA_VillageText { get => GetValue<string>(); set => SetValue(value); }
    }
}
