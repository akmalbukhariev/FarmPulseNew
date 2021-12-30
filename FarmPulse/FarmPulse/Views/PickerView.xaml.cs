using System;
using System.Collections;
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
    public partial class PickerView : ContentView
    {
        #region Title
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title),
                                    typeof(string),
                                    typeof(PickerView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: TitlePropertyChanged);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerView)bindable;
            if (control != null)
                control.lbTitle.Text = newValue.ToString();
        }
        #endregion

        #region Selected Item
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem),
                                    typeof(object),
                                    typeof(PickerView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: SelectedItemPropertyChanged);

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static void SelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerView)bindable;
            if (control != null)
                control.lsView.SelectedItem = (object)newValue;
        }
        #endregion

        #region Item Source
        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create(nameof(ItemsSource),
                                    typeof(List<string>),
                                    typeof(PickerView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: ItemSourcePropertyChanged);

        public List<string> ItemsSource
        {
            get { return (List<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        private static void ItemSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PickerView)bindable;
            if (control != null)
                control.lsView.ItemsSource = (List<string>)newValue;
        }
        #endregion

        #region Command Cancel
        public static readonly BindableProperty CommandCancelProperty =
            BindableProperty.Create(nameof(CommandCancel),
                                    typeof(ICommand),
                                    typeof(PickerView),
                                    null);

        public static readonly BindableProperty CommandCancelParameterProperty =
            BindableProperty.Create(nameof(CommandCancelParameter),
                                    typeof(object),
                                    typeof(PickerView),
                                    null);

        public ICommand CommandCancel
        {
            get { return (ICommand)GetValue(CommandCancelProperty); }
            set { SetValue(CommandCancelProperty, value); }
        }

        public object CommandCancelParameter
        {
            get => GetValue(CommandCancelParameterProperty);
            set => SetValue(CommandCancelParameterProperty, value);
        }
        #endregion

        #region Command Ok
        public static readonly BindableProperty CommandOkProperty =
            BindableProperty.Create(nameof(CommandOk),
                                    typeof(ICommand),
                                    typeof(PickerView),
                                    null);

        public static readonly BindableProperty CommandOkParameterProperty =
            BindableProperty.Create(nameof(CommandOkParameter),
                                    typeof(object),
                                    typeof(PickerView),
                                    null);

        public ICommand CommandOk
        {
            get { return (ICommand)GetValue(CommandOkProperty); }
            set { SetValue(CommandOkProperty, value); }
        }

        public object CommandOkParameter
        {
            get => GetValue(CommandOkParameterProperty);
            set => SetValue(CommandOkParameterProperty, value);
        }
        #endregion

        public PickerView()
        {
            InitializeComponent();  
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            if (CommandCancel != null && CommandCancel.CanExecute(CommandCancelParameter))
            {
                CommandCancel.Execute(CommandCancelParameter);
            }
        }

        private void btnOk_Clicked(object sender, EventArgs e)
        {
            if (CommandOk != null && CommandOk.CanExecute(CommandOkParameter))
            {
                CommandOk.Execute(CommandOkParameter);
            }
        }
    }
}