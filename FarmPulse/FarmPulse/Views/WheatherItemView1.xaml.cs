using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WheatherItemView1 : ContentView
    {
        #region Text1
        public static readonly BindableProperty Text1Property =
            BindableProperty.Create(nameof(Text1),
                                    typeof(string),
                                    typeof(WheatherItemView1),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: Text1PropertyChanged);

        public string Text1
        {
            get { return (string)GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }

        private static void Text1PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView1)bindable;
            if (control != null)
                control.lbText1.Text = newValue.ToString();
        }
        #endregion

        #region Text2
        public static readonly BindableProperty Text2Property =
            BindableProperty.Create(nameof(Text2),
                                    typeof(string),
                                    typeof(WheatherItemView1),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: Text2PropertyChanged);

        public string Text2
        {
            get { return (string)GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }

        private static void Text2PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView1)bindable;
            if (control != null)
                control.lbText2.Text = newValue.ToString();
        }
        #endregion

        #region Image icon source
        public static readonly BindableProperty ImageIconSourceProperty =
            BindableProperty.Create(nameof(ImageIconSource),
                                    typeof(string),
                                    typeof(WheatherItemView1),
                                    null,
                                    propertyChanged: ImageIconSourcePropertyChanged);

        public string ImageIconSource
        {
            get { return (string)GetValue(ImageIconSourceProperty); }
            set { SetValue(ImageIconSourceProperty, value); }
        }

        private static void ImageIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView1)bindable;
            if (newValue != null)
            {
                control.image.Source = (string)newValue;
            }
        }
        #endregion

        public WheatherItemView1()
        {
            InitializeComponent();
        }
    }
}