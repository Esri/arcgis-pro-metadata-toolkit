/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Windows.Markup;
using ArcGIS.Desktop.Internal.Metadata.Properties;
using System.Globalization;

namespace ArcGIS.Desktop.Metadata.Editor.Controls
{
  /// <summary>
  /// Interaction logic for DoubleSlider.xaml
  /// </summary>
  /// <summary>
  /// Interaction logic for RangeSlider.xaml
  /// </summary>
  public partial class DoubleSlider : UserControl
  {
    public DoubleSlider()
    {
      InitializeComponent();
      this.Loaded += Slider_Loaded;
    }

    protected void Slider_Loaded(object sender, RoutedEventArgs e)
    {
      LowerSlider.ValueChanged += LowerSlider_ValueChanged;
      UpperSlider.ValueChanged += UpperSlider_ValueChanged;
    }

    private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (UpperSlider.Value <= e.NewValue)
      {
        if (UpperSlider.Value <= e.OldValue)
        {
          // error condition - reset
          UpperValue = 1;
          LowerValue = 0;
        }
        else
        {
          LowerValue = e.OldValue;
        }
      }
      else
      {

        LowerValue = e.NewValue;
      }

      e.Handled = true;
    }

    private void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (e.NewValue <= LowerSlider.Value)
      {
        if (e.OldValue <= LowerSlider.Value)
        {
          // error condition - reset
          UpperValue = 1;
          LowerValue = 0;
        }
        else
        {
          UpperValue = e.OldValue;
        }
      }
      else
      {
        UpperValue = e.NewValue;
      }

      e.Handled = true;
    }


    #region Dependency Property - Lower Value
    public double LowerValue
    {
      set { SetValue(LowerValueProperty, value); }
      get { return (double)GetValue(LowerValueProperty); }
    }

    public static readonly DependencyProperty LowerValueProperty =
        DependencyProperty.Register("LowerValue", typeof(double), typeof(DoubleSlider), new FrameworkPropertyMetadata(Double.NaN));
    #endregion

    #region Dependency Property - Upper Value
    public double UpperValue
    {
      set { SetValue(UpperValueProperty, value); }
      get { return (double)GetValue(UpperValueProperty); }
    }

    public static readonly DependencyProperty UpperValueProperty =
       DependencyProperty.Register("UpperValue", typeof(Double), typeof(DoubleSlider), new PropertyMetadata(Double.Parse("0")));

    #endregion

    #region Dependency Property - Minimum
    public double Minimum
    {
      get { return (double)GetValue(MinimumProperty); }
      set { SetValue(MinimumProperty, value); }
    }

    public static readonly DependencyProperty MinimumProperty =
        DependencyProperty.Register("Minimum", typeof(double), typeof(DoubleSlider), new UIPropertyMetadata(Double.Parse("0")));
    #endregion

    #region Dependency Property - Maximum
    public double Maximum
    {
      get { return (double)GetValue(MaximumProperty); }
      set { SetValue(MaximumProperty, value); }
    }

    public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register("Maximum", typeof(double), typeof(DoubleSlider), new UIPropertyMetadata(Double.Parse("1")));

    #endregion
  }

  [ValueConversion(typeof(double), typeof(string))]
  public class DoubleSliderConverter : DependencyObject, IValueConverter
  {

    // list of scale-representing images
    public ArrayList ImageArrayList { get; set; }
    private static CultureInfo culture_en = CultureInfo.CreateSpecificCulture("en");

    public object ConvertDenom(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: scale value (double)
      // out: denom string

      int scaleValue = 0;
      try
      {
        scaleValue = System.Convert.ToInt32(value);
      }
      catch (Exception) { /* ignore */ }


      if (0 <= scaleValue && scaleValue <= (ImageArrayList.Count - 1))
      {
        ScaleImage ci = ImageArrayList[scaleValue] as ScaleImage;
        return string.Format("{0}{1}", Internal.Metadata.Properties.Resources.SCALE_PREFIX, ci.ScaleDenomLabel);
      }
      else
      {
        ScaleImage ci = ImageArrayList[0] as ScaleImage;
        return string.Format("{0}{1}", Internal.Metadata.Properties.Resources.SCALE_PREFIX, ci.ScaleDenomLabel);
      }
    }

    public object ConvertName(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: scale value (double)
      // out: string

      int scaleValue = 0;
      try
      {
        scaleValue = System.Convert.ToInt32(value);
      }
      catch (Exception) { /* ignore */ }


      if (0 <= scaleValue && scaleValue <= (ImageArrayList.Count - 1))
      {
        ScaleImage ci = ImageArrayList[scaleValue] as ScaleImage;
        return ci.ScaleName;
      }
      else
      {
        ScaleImage ci = ImageArrayList[0] as ScaleImage;
        return ci.ScaleName;
      }
    }

    public object ConvertImage(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: scale value (double)
      // out: ImageSource

      // requesting a slider value
      //
      int scaleValue = 0;

      try
      {
        scaleValue = System.Convert.ToInt32(value);
      }
      catch (Exception) { /* ignore */ }

      if (0 <= scaleValue && scaleValue <= (ImageArrayList.Count - 1))
      {
        ScaleImage ci = ImageArrayList[scaleValue] as ScaleImage;
        return ci.Image.Source;
      }
      else
      {
        ScaleImage ci = ImageArrayList[0] as ScaleImage;
        return ci.Image.Source;
      }
    }

    // from source to target
    //
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: scale denom as string
      // out: index

      // is requesting an image?
      //
      if ("scaleImage".Equals(parameter))
        return ConvertImage(value, targetType, parameter, culture);
      else if ("scaleName".Equals(parameter))
        return ConvertName(value, targetType, parameter, culture);
      else if ("scaleDenom".Equals(parameter))
        return ConvertDenom(value, targetType, parameter, culture);

      // requesting a slider value
      //
      double denom = 0.0;
      try
      {
        if (null != value && !"".Equals(value))
          denom = Double.Parse((string)value, culture_en);
      }
      catch (Exception) { /* igore */ }

      for (int i = 0; i < ImageArrayList.Count; i++)
      {
        ScaleImage ci = ImageArrayList[i] as ScaleImage;
        if (ci.ScaleDenom <= denom)
        {
          return i;
        }
      }

      return ImageArrayList.Count - 1;
    }

    // from target to source
    //
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      // in: index
      // out: string denom name

      double denom = 0.0;

      int index = System.Convert.ToInt16(value);
      if (0 <= index && index <= (ImageArrayList.Count - 1))
      {
        ScaleImage scaleImage = ImageArrayList[index] as ScaleImage;
        denom = scaleImage.ScaleDenom;
      }
      else if (0 < ImageArrayList.Count)
      {
        // fallback        
        denom = (ImageArrayList[0] as ScaleImage).ScaleDenom;
      }

      return denom;
    }
  }

  [ContentProperty("Image")]
  public class ScaleImage : DependencyObject
  {
    private Image _image;
    private double _scaleDenom = 0.0;

    public ScaleImage()
    {
      // NOOP
    }

    public double ScaleDenom
    {
      get { return _scaleDenom; }
      set { _scaleDenom = value; }
    }

    public System.Windows.Controls.Image Image
    {
      get { return _image; }
      set { _image = value; }
    }

    public string ScaleName
    {
      get { return (string)GetValue(ScaleNameProperty); }
      set { SetValue(ScaleNameProperty, value); }
    }

    public static readonly DependencyProperty ScaleNameProperty =
        DependencyProperty.Register("ScaleName", typeof(string), typeof(ScaleImage), new UIPropertyMetadata(String.Empty));

    public string ScaleDenomLabel
    {
      get { return (string)GetValue(ScaleDenomProperty); }
      set { SetValue(ScaleDenomProperty, value); }
    }

    public static readonly DependencyProperty ScaleDenomProperty =
        DependencyProperty.Register("ScaleDenomLabel", typeof(string), typeof(ScaleImage), new UIPropertyMetadata(String.Empty));
  }

}
