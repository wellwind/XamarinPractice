using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AttachedPropertyPractice
{
    public class EntryTypeAttachedProperty
    {
        #region EntryType Attached Property
        public static readonly BindableProperty EntryTypeProperty =
               BindableProperty.CreateAttached(
                   propertyName: "EntryType",
                   returnType: typeof(string),
                   declaringType: typeof(Entry),
                   defaultValue: null,
                   defaultBindingMode: BindingMode.OneWay,
                   validateValue: null,
                   propertyChanged: OnEntryTypeChanged);

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = bindable as Entry;
            if (entry == null)
            {
                return;
            }

            var oldVal = (oldValue as string)?.ToLower();
            var newVal = (newValue as string)?.ToLower();

            switch (newVal)
            {
                case "email":
                    entry.Placeholder = "Type your email...";
                    break;
                case "phone":
                    entry.Placeholder = "Type your phone...";
                    break;
                default:
                    entry.Placeholder = String.Empty;
                    break;
            }
        }

        public static void SetEntryType(BindableObject bindable, string entryType)
        {
            bindable.SetValue(EntryTypeProperty, entryType);
        }
        public static string GetEntryType(BindableObject bindable)
        {
            return (string)bindable.GetValue(EntryTypeProperty);
        }
        #endregion

    }
}
