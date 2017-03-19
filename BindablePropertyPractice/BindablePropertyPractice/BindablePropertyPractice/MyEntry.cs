using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindablePropertyPractice
{
    public class MyEntry : Entry
    {
        #region BindablePropertyType BindableProperty
        public static readonly BindableProperty BindableEntryType =
            BindableProperty.Create("CustomProperty", // 屬性名稱 
                typeof(string), // 回傳類型 
                typeof(MyEntry), // 宣告類型 
                "None", // 預設值 
                propertyChanged: OnEntryTypeChanged);

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = bindable as MyEntry;

            if (entry.EntryType == "Email")
            {
                entry.SetValue(PlaceholderProperty, "Input Email");
            }

        }

        public string EntryType
        {
            set
            {
                SetValue(BindableEntryType, value);
            }
            get
            {
                return (string)GetValue(BindableEntryType);
            }
        }
        #endregion

    }
}
