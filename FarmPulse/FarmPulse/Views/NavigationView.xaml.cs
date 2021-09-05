using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationView : ContentView
    {
        #region Text
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                                    typeof(string),
                                    typeof(NavigationView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextPropertyChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (NavigationView)bindable;
            if (control != null)
                control.lbTitle.Text = newValue.ToString();
        }
        #endregion

        #region Text color
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor),
                                    typeof(Color),
                                    typeof(NavigationView),
                                    null,
                                    propertyChanged: TextColorPropertyChanged);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        private static void TextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (NavigationView)bindable;
            if (newValue != null)
            {
                control.lbTitle.TextColor = (Color)newValue; 
            }
        }
        #endregion

        #region Image icon source
        public static readonly BindableProperty ImageIconSourceProperty =
            BindableProperty.Create(nameof(ImageIconSource),
                                    typeof(string),
                                    typeof(NavigationView),
                                    null,
                                    propertyChanged: ImageIconSourcePropertyChanged);

        public string ImageIconSource
        {
            get { return (string)GetValue(ImageIconSourceProperty); }
            set { SetValue(ImageIconSourceProperty, value); }
        }

        private static void ImageIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (NavigationView)bindable;
            if (newValue != null)
            {
                control.imBack.Source = (string)newValue;
            }
        }
        #endregion

        #region Command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command),
                                    typeof(ICommand),
                                    typeof(NavigationView),
                                    null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter),
                                    typeof(object),
                                    typeof(NavigationView),
                                    null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        #endregion

        public NavigationView()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

            if (Command != null && Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }
    }
}