using System;
using System.Collections.Generic;
using Xamarin.Forms;
using RebuyFormsRating.Models;

namespace RebuyFormsRating
{
    public partial class RatingView : ContentView
    {
        public static BindableProperty RatingViewBackgroundColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.RatingViewBackgroundColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).RatingViewBackgroundColor = newValue;
            } 
        );

        public static BindableProperty TitleColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.TitleColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).TitleColor = newValue;
            } 
        );

        public static BindableProperty DetailTextColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.DetailTextColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).DetailTextColor = newValue;
            } 
        );

        public static BindableProperty DetailTextProperty = BindableProperty.Create<RatingView, string>(
            o => o.DetailText, 
            default(string), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).DetailText = newValue;
            } 
        );

        public static BindableProperty TitleProperty = BindableProperty.Create<RatingView, string>(
            o => o.Title, 
            default(string), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).Title = newValue;
            } 
        );

        public static BindableProperty BtnRateTextProperty = BindableProperty.Create<RatingView, string>(
            o => o.BtnRateText, 
            default(string), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnRateText = newValue;
            } 
        );

        public static BindableProperty BtnRateTextColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.BtnRateTextColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnRateTextColor = newValue;
            } 
        );

        public static BindableProperty BtnRateColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.BtnRateColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnRateColor = newValue;
            } 
        );

        public static BindableProperty BtnRateLaterTextProperty = BindableProperty.Create<RatingView, string>(
            o => o.BtnRateLaterText, 
            default(string), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnRateLaterText = newValue;
            } 
        );

        public static BindableProperty BtnRateLaterTextColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.BtnRateLaterTextColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnRateLaterTextColor = newValue;
            } 
        );

        public static BindableProperty BtnRateLaterColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.BtnRateLaterColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnRateLaterColor = newValue;
            } 
        );

        public static BindableProperty BtnCancelTextProperty = BindableProperty.Create<RatingView, string>(
            o => o.BtnCancelText, 
            default(string), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnCancelText = newValue;
            } 
        );

        public static BindableProperty BtnCancelTextColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.BtnCancelTextColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnCancelTextColor = newValue;
            } 
        );

        public static BindableProperty BtnCancelColorProperty = BindableProperty.Create<RatingView, Color>(
            o => o.BtnCancelColor, 
            default(Color), 
            propertyChanged: (bindable, oldValue, newValue) => {
                ((RatingViewViewModel) bindable.BindingContext).BtnCancelColor = newValue;
            } 
        );

        public Color RatingViewBackgroundColor {
            get { return (Color) GetValue(RatingViewBackgroundColorProperty); }
            set { SetValue(RatingViewBackgroundColorProperty, value); }
        }

        public Color DetailTextColor {
            get { return (Color) GetValue(DetailTextColorProperty); }
            set { SetValue(DetailTextColorProperty, value); }
        }

        public Color TitleColor {
            get { return (Color) GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        public string DetailText {
            get { return (string) GetValue(DetailTextProperty); }
            set { SetValue(DetailTextProperty, value); }
        }

        public string Title {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string BtnRateText {
            get { return (string) GetValue(BtnRateTextProperty); }
            set { SetValue(BtnRateTextProperty, value); }
        }

        public Color BtnRateTextColor {
            get { return (Color) GetValue(BtnRateTextColorProperty); }
            set { SetValue(BtnRateTextColorProperty, value); }
        }

        public Color BtnRateColor {
            get { return (Color) GetValue(BtnRateColorProperty); }
            set { SetValue(BtnRateColorProperty, value); }
        }

        public string BtnRateLaterText {
            get { return (string) GetValue(BtnRateLaterTextProperty); }
            set { SetValue(BtnRateLaterTextProperty, value); }
        }

        public Color BtnRateLaterTextColor {
            get { return (Color) GetValue(BtnRateLaterTextColorProperty); }
            set { SetValue(BtnRateLaterTextColorProperty, value); }
        }

        public Color BtnRateLaterColor {
            get { return (Color) GetValue(BtnRateLaterColorProperty); }
            set { SetValue(BtnRateLaterColorProperty, value); }
        }

        public string BtnCancelText {
            get { return (string) GetValue(BtnCancelTextProperty); }
            set { SetValue(BtnCancelTextProperty, value); }
        }

        public Color BtnCancelTextColor {
            get { return (Color) GetValue(BtnCancelTextColorProperty); }
            set { SetValue(BtnCancelTextColorProperty, value); }
        }

        public Color BtnCancelColor {
            get { return (Color) GetValue(BtnCancelColorProperty); }
            set { SetValue(BtnCancelColorProperty, value); }
        }

        public RatingView()
        {
            InitializeComponent();
        }
    }
}

