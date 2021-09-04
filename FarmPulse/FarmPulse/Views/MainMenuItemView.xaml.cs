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
    public partial class MainMenuItemView : ContentView
    {
        #region Text
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                                    typeof(string),
                                    typeof(MainMenuItemView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TextPropertyChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MainMenuItemView)bindable;
            if (control != null)
                control.lbText.Text = newValue.ToString();
        }
        #endregion

        #region Image back source
        public static readonly BindableProperty ImageBackSourceProperty =
            BindableProperty.Create(nameof(ImageBackSource),
                                    typeof(string),
                                    typeof(MainMenuItemView),
                                    null,
                                    propertyChanged: ImageBackSourcePropertyChanged);

        public string ImageBackSource
        {
            get { return (string)GetValue(ImageBackSourceProperty); }
            set { SetValue(ImageBackSourceProperty, value); }
        }

        private static void ImageBackSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MainMenuItemView)bindable;
            if (newValue != null)
            {
                control.imBack.Source = (string)newValue; 
            }
        }
        #endregion

        #region Image icon source
        public static readonly BindableProperty ImageIconSourceProperty =
            BindableProperty.Create(nameof(ImageIconSource),
                                    typeof(string),
                                    typeof(MainMenuItemView),
                                    null,
                                    propertyChanged: ImageIconSourcePropertyChanged);

        public string ImageIconSource
        {
            get { return (string)GetValue(ImageIconSourceProperty); }
            set { SetValue(ImageIconSourceProperty, value); }
        }

        private static void ImageIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MainMenuItemView)bindable;
            if (newValue != null)
            {
                control.imIcon.Source = (string)newValue;
            }
        }
        #endregion

        #region Command
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command),
                                    typeof(ICommand),
                                    typeof(MainMenuItemView),
                                    null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter),
                                    typeof(object),
                                    typeof(MainMenuItemView),
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

        public MainMenuItemView()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            backBoxView.Opacity = 0.8;
            await Task.Delay(100);

            backBoxView.Opacity = 0.5;
            await Task.Delay(200);

            if (Command != null && Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        } 
    }
}