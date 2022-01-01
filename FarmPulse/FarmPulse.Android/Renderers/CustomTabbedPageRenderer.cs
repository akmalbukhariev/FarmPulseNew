using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FarmPulse.Control;
using FarmPulse.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

//[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]

namespace FarmPulse.Droid.Renderers
{
    [Obsolete]
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

        }

        //private Activity activity;
        //private TabbedPage _tabbedPage;
        //private const string COLOR = "#00796B";

        //protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        //{
        //    base.OnElementChanged(e);
        //    activity = this.Context as Activity;

        //    _tabbedPage = e.NewElement as TabbedPage;  
        //}

        //protected override void DispatchDraw(Canvas canvas)
        //{ 
        //    ActionBar actionBar = activity.ActionBar;

        //    if (actionBar.TabCount > 0)
        //    {
        //        ColorDrawable colorDrawable = new ColorDrawable(global::Android.Graphics.Color.ParseColor(COLOR));
        //        actionBar.SetStackedBackgroundDrawable(colorDrawable);
        //        ActionBarTabsSetup(actionBar);

        //    }

        //    base.DispatchDraw(canvas);
        //}

        //private void ActionBarTabsSetup(ActionBar actionBar)
        //{
        //    try
        //    {   
        //        for (int i = 0; i < actionBar.TabCount; i++)
        //        {
        //            Android.App.ActionBar.Tab dashboardTab = actionBar.GetTabAt(i);
        //            if (TabIsEmpty(dashboardTab))
        //            { 
        //                int id = Resources.GetIdentifier(_tabbedPage.Children[i].Icon.File, "drawable", Context.PackageName);
        //                TabSetup(dashboardTab, id);
        //            } 
        //        } 
        //    }
        //    catch (Exception)
        //    {

        //    } 
        //}

        //private bool TabIsEmpty(ActionBar.Tab tab)
        //{
        //    if (tab != null)
        //        if (tab.CustomView == null)
        //            return true;
        //    return false;
        //}

        //private void TabSetup(ActionBar.Tab tab, int resourceID)
        //{
        //    ImageView iv = new ImageView(activity);
        //    iv.SetImageResource(resourceID);
        //    iv.SetPadding(0, 10, 0, 0);

        //    tab.SetCustomView(iv);
        //}
    }
}