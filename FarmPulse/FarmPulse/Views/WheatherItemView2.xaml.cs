  
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WheatherItemView2 : ContentView
    {
        #region Text Day
        public static readonly BindableProperty TextDayProperty =
            BindableProperty.Create(nameof(TextDay),
                                    typeof(string),
                                    typeof(WheatherItemView2),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextDayPropertyChanged);

        public string TextDay
        {
            get { return (string)GetValue(TextDayProperty); }
            set { SetValue(TextDayProperty, value); }
        }

        private static void TextDayPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView2)bindable;
            if (control != null)
                control.lbDay.Text = newValue.ToString();
        }
        #endregion

        #region Text Date
        public static readonly BindableProperty TextDateProperty =
            BindableProperty.Create(nameof(TextDate),
                                    typeof(string),
                                    typeof(WheatherItemView2),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextDatePropertyChanged);

        public string TextDate
        {
            get { return (string)GetValue(TextDateProperty); }
            set { SetValue(TextDateProperty, value); }
        }

        private static void TextDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView2)bindable;
            if (control != null)
                control.lbDate.Text = newValue.ToString();
        }
        #endregion

        #region Text Cel1
        public static readonly BindableProperty TextCel1Property =
            BindableProperty.Create(nameof(TextCel1),
                                    typeof(string),
                                    typeof(WheatherItemView2),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextCel1PropertyChanged);

        public string TextCel1
        {
            get { return (string)GetValue(TextCel1Property); }
            set { SetValue(TextCel1Property, value); }
        }

        private static void TextCel1PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView2)bindable;
            if (control != null)
                control.lbCel1.Text = newValue.ToString();
        }
        #endregion

        #region Text Cel2
        public static readonly BindableProperty TextCel2Property =
            BindableProperty.Create(nameof(TextCel2),
                                    typeof(string),
                                    typeof(WheatherItemView2),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextCel2PropertyChanged);

        public string TextCel2
        {
            get { return (string)GetValue(TextCel2Property); }
            set { SetValue(TextCel2Property, value); }
        }

        private static void TextCel2PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView2)bindable;
            if (control != null)
                control.lbCel2.Text = newValue.ToString();
        }
        #endregion

        #region Text V1
        public static readonly BindableProperty TextV1Property =
            BindableProperty.Create(nameof(TextV1),
                                    typeof(string),
                                    typeof(WheatherItemView2),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextV1PropertyChanged);

        public string TextV1
        {
            get { return (string)GetValue(TextV1Property); }
            set { SetValue(TextV1Property, value); }
        }

        private static void TextV1PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView2)bindable;
            if (control != null)
                control.lbV1.Text = newValue.ToString();
        }
        #endregion

        #region Text V2
        public static readonly BindableProperty TextV2Property =
            BindableProperty.Create(nameof(TextV2),
                                    typeof(string),
                                    typeof(WheatherItemView2),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextV2PropertyChanged);

        public string TextV2
        {
            get { return (string)GetValue(TextV2Property); }
            set { SetValue(TextV2Property, value); }
        }

        private static void TextV2PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView2)bindable;
            if (control != null)
                control.lbV2.Text = newValue.ToString();
        }
        #endregion

        #region Image icon source
        public static readonly BindableProperty ImageIconSourceProperty =
            BindableProperty.Create(nameof(ImageIconSource),
                                    typeof(string),
                                    typeof(WheatherItemView2),
                                    null,
                                    propertyChanged: ImageIconSourcePropertyChanged);

        public string ImageIconSource
        {
            get { return (string)GetValue(ImageIconSourceProperty); }
            set { SetValue(ImageIconSourceProperty, value); }
        }

        private static void ImageIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (WheatherItemView2)bindable;
            if (newValue != null)
            {
                control.image.Source = (string)newValue;
            }
        }
        #endregion

        public WheatherItemView2()
        {
            InitializeComponent();
        }
    }
}