/*
COPYRIGHT 1995-2012 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States and applicable international
laws, treaties, and conventions.
 
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts and Legal Services Department
380 New York Street
Redlands, California, 92373
USA
 
email: contracts@esri.com
*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Windows.Data;
using System.Globalization;
using ArcGIS.Desktop.Metadata.Editor.Pages;
using ArcGIS.Desktop.Metadata.Editor.Controls;
using System.Text.RegularExpressions;
using ArcGIS.Desktop.Metadata.Editor;

namespace ArcGIS.Desktop.Metadata.Editor.Validation
{

  #region interface MetadataRuleSet

  public interface MetadataRuleSet
  {
    MetadataRuleSet GetRules();

    void RunRules(Object sender, RoutedEventArgs args);

    string Msg { get; set; }
    string Tag { get; set; }
    Nullable<double> Min { get; set; }
    Nullable<double> Max { get; set; }
  }

  #endregion

  #region MetadataRuleBase : DependencyObject

  public abstract class MetadataRuleBase : DependencyObject
  {

    protected static CultureInfo enCulture = new CultureInfo("en-US");

    public Nullable<double> Min { get; set; }
    public Nullable<double> Max { get; set; }

    /// <summary>
    /// Identifies the <see cref="IsGripEnabled"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty MsgProperty = DependencyProperty.Register("Msg",
      typeof(string),
      typeof(MetadataRuleBase),
      new FrameworkPropertyMetadata(String.Empty));

    public string Msg
    {
      get { return (string)GetValue(MsgProperty); }
      set { SetValue(MsgProperty, value); }
    }

    public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag",
      typeof(string),
      typeof(MetadataRuleBase),
      new FrameworkPropertyMetadata(String.Empty));

    public string Tag
    {
      get { return (string)GetValue(TagProperty); }
      set { SetValue(TagProperty, value); }
    }
  }

  #endregion

  #region MetadataMandatoryRules : MetadataRuleSet

  public class MetadataMandatoryRules : MetadataRuleBase, MetadataRuleSet
  {
    public MetadataRuleSet GetRules() { return this; }
   
    public void RunRules(Object sender, RoutedEventArgs args)
    {
      if (!(sender is FrameworkElement))
        return; // nothing to do
      FrameworkElement el = sender as FrameworkElement;

      DependencyProperty dp = null;
      if (el is TextBox)
      {
        dp = TextBox.TextProperty;
      }
      else if (el is ComboBox)
      {
        dp = ComboBox.SelectedValueProperty;
      }
      else
      {
        throw new MetadataException("Validation not handled for type: " + el.GetType());
      }

      if (null == dp)
        return; // nothing to do

      string strValue = (string)el.GetValue(dp);
      if (null == strValue || 0 == strValue.Length)
      {
        el.SetValue(MetadataRules.HasIssueProperty, true);

        // create issue
        var issue = MetadataRules.CreateIssue(this, el);
        //var issue = new MetadataValidationIssue(true, "FOO", "BAR", "BIN", "BAZ");

        if (null != issue)
        {
          // create event and raise it
          RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataIssueEvent, issue);
          el.RaiseEvent(newEventArgs);
        }
      }
      else
      {
        el.SetValue(MetadataRules.HasIssueProperty, false);
      }
    }
  }

  #endregion

  #region MetadataDoubleListRules

  public class MetadataDoubleListRules : MetadataRuleBase, MetadataRuleSet
  {
    public MetadataRuleSet GetRules() { return this; }
    //private static CultureInfo enCulture = new CultureInfo("en-US");
    private Regex re = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");

    public void RunRules(Object sender, RoutedEventArgs args)
    {
      if (!(sender is FrameworkElement))
        return; // nothing to do
      FrameworkElement el = sender as FrameworkElement;

      DependencyProperty dp = null;
      if (el is TextBox)
      {
        dp = TextBox.TextProperty;
      }
      else if (el is ComboBox)
      {
        dp = ComboBox.SelectedValueProperty;
      }
      else
      {
        throw new MetadataException("Validation not handled for type: " + el.GetType());
      }

      if (null == dp)
        return; // nothing to do

      bool prevHasIssue = (bool)el.GetValue(MetadataRules.HasIssueProperty);

      string doubleStr = (string)el.GetValue(dp);
      if (null != doubleStr && 0 < doubleStr.Length)
      {

        string[] parts = doubleStr.Split(' ');
        //double result;
        el.SetValue(MetadataRules.HasIssueProperty, false);
        foreach (string dval in parts)
        {
          var num = ((string)dval).Trim();

          if (null != num && 0 < num.Length && !re.IsMatch(num))
          //if (!Double.TryParse(dval as string, NumberStyles.AllowDecimalPoint | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingWhite, enCulture, out result))
          {
            el.SetValue(MetadataRules.HasIssueProperty, true);

            // create issue
            var issue = MetadataRules.CreateIssue(this, el);
            if (null != issue)
            {
              // create event and raise it
              RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataIssueEvent, issue);
              el.RaiseEvent(newEventArgs);
            }
          }
        }
      }

      // if switched from TRUE to FALSE
      // then update page validation
      if (true == prevHasIssue)
      {
        bool currHasIssue = (bool)el.GetValue(MetadataRules.HasIssueProperty);
        if (!currHasIssue)
        {
          // create event and raise it
          RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataCheckRulesEvent);
          el.RaiseEvent(newEventArgs);
        }
      }
    }
  }

  #endregion

  public class MetadataRulesAdapter : MetadataRuleBase, MetadataRuleSet
  {

    private MetadataRuleSet _adapted;

    public MetadataRulesAdapter(MetadataRuleSet adapted)
    {
      this._adapted = adapted;
    }

    public MetadataRuleSet GetRules()
    {
      return _adapted.GetRules();
    }

    public void RunRules(object sender, RoutedEventArgs args)
    {
      _adapted.RunRules(sender, args);
    }

  }

  #region MetadataIntegerRules : MetadataRuleSet

  public class MetadataIntegerRules : MetadataRuleBase, MetadataRuleSet
  {
    public MetadataRuleSet GetRules() { return this; }

    public void RunRules(Object sender, RoutedEventArgs args)
    {
      if (!(sender is FrameworkElement))
        return; // nothing to do
      FrameworkElement el = sender as FrameworkElement;

      DependencyProperty dp = null;
      if (el is TextBox)
      {
        dp = TextBox.TextProperty;
      }
      else if (el is ComboBox)
      {
        dp = ComboBox.SelectedValueProperty;
      }
      else
      {
        throw new MetadataException("Validation not handled for type: " + el.GetType());
      }

      if (null == dp)
        return; // nothing to do

      string strValue = (string)el.GetValue(dp);
      if (null != strValue && 0 < strValue.Length)
      {

        bool hasError = false;

        double db;
        if (double.TryParse(strValue, NumberStyles.Float, enCulture, out db))
        {

          // test for fraction
          if (db != Math.Truncate(db)) {
            hasError = true;
          }

          // get the integer
          var i = int.Parse(strValue, NumberStyles.Integer, enCulture);

          if (null != Min)
          {
            double min = Min.Value;
            if (i < min)
              hasError = true;
          }

          if (null != Max)
          {
            double max = Max.Value;
            if (max < i)
              hasError = true;
          }

          if (hasError)
          {
            el.SetValue(MetadataRules.HasIssueProperty, true);
            var issue = MetadataRules.CreateIssue(this, el);
            if (null != issue)
            {
              // create event and raise it
              RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataIssueEvent, issue);
              el.RaiseEvent(newEventArgs);
            }
          }
          else
          {
            el.SetValue(MetadataRules.HasIssueProperty, false);
          }
        }
        else  
        {
          el.SetValue(MetadataRules.HasIssueProperty, true);

          // create issue
          var issue = MetadataRules.CreateIssue(this, el);

          if (null != issue)
          {
            // create event and raise it
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataIssueEvent, issue);
            el.RaiseEvent(newEventArgs);
          }
        }
      }
      else
      {
        el.SetValue(MetadataRules.HasIssueProperty, false);
      }
    }
  }

  #endregion

  #region MetadataRealRules : MetadataRuleSet

  public class MetadataRealRules : MetadataRuleBase, MetadataRuleSet
  {    
    public MetadataRuleSet GetRules() { return this; }

    public void RunRules(Object sender, RoutedEventArgs args)
    {
      if (!(sender is FrameworkElement))
        return; // nothing to do
      FrameworkElement el = sender as FrameworkElement;

      DependencyProperty dp = null;
      if (el is TextBox)
      {
        dp = TextBox.TextProperty;
      }
      else if (el is ComboBox)
      {
        dp = ComboBox.SelectedValueProperty;
      }
      else
      {
        throw new MetadataException("Validation not handled for type: " + el.GetType());
      }

      if (null == dp)
        return; // nothing to do

      bool prevHasIssue = (bool)el.GetValue(MetadataRules.HasIssueProperty);

      string strValue = (string)el.GetValue(dp);
      if (null != strValue && 0 < strValue.Length)
      {

        double db;
        if (!double.TryParse(strValue, NumberStyles.Float, enCulture, out db))
        {
          el.SetValue(MetadataRules.HasIssueProperty, true);

          // create issue
          var issue = MetadataRules.CreateIssue(this, el);
          if (null != issue)
          {
            // create event and raise it
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataIssueEvent, issue);
            el.RaiseEvent(newEventArgs);
          }
        }
        else
        {
          bool hasError = false;

          if (null != Min)
          {
            double min = Min.Value;
            if (db < min)
              hasError = true;
          }

          if (null != Max)
          {
            double max = Max.Value;
            if (max < db)
              hasError = true;
          }

          if (hasError)
          {
            el.SetValue(MetadataRules.HasIssueProperty, true);
            var issue = MetadataRules.CreateIssue(this, el);
            if (null != issue)
            {
              // create event and raise it
              RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataIssueEvent, issue);
              el.RaiseEvent(newEventArgs);
            }
          }
          else
          {
            el.SetValue(MetadataRules.HasIssueProperty, false);
          }
        }
      }
      else
      {
        el.SetValue(MetadataRules.HasIssueProperty, false);
      }

      // if switched from TRUE to FALSE
      // then update page validation
      //
      // FIXME: THIS is faulty logic, because there may be OTHER rules that need to be applied even IF this rules passes
      // e.g. a combobox value may be required if this rule passes...
      if (true == prevHasIssue)
      {
        bool currHasIssue = (bool)el.GetValue(MetadataRules.HasIssueProperty);
        if (!currHasIssue)
        {
          // create event and raise it
          RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataCheckRulesEvent);
          el.RaiseEvent(newEventArgs);
        }
      }
    }
  }

  #endregion

  #region MetadataCheckRules : MetadataRuleSet

  public class MetadataCheckRules : MetadataRuleBase, MetadataRuleSet
  {
    public MetadataRuleSet GetRules() { return this; }

    public void RunRules(Object sender, RoutedEventArgs args)
    {
      if (!(sender is FrameworkElement))
        return; // nothing to do
      FrameworkElement el = sender as FrameworkElement;

      // create event and raise it
      RoutedEventArgs newEventArgs = new RoutedEventArgs(MetadataRules.MetadataCheckRulesEvent);
      el.RaiseEvent(newEventArgs);
    }
  }

  #endregion

  public class MetadataRules
  {

    #region BuiltInRules

    public static readonly MetadataRuleSet Mandatory = new MetadataMandatoryRules();
    public static readonly MetadataRuleSet CheckRules = new MetadataCheckRules();
    public static readonly MetadataRuleSet IntegerType = new MetadataIntegerRules();
    public static readonly MetadataRuleSet RealType = new MetadataRealRules();

    #endregion

    # region Metadata Check Rules Event

    public static readonly RoutedEvent MetadataCheckRulesEvent = EventManager.RegisterRoutedEvent(
        "MetadataCheckRules",
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(MetadataRules)
    );

    #endregion

    # region Metadata Issue Events

    public static readonly RoutedEvent MetadataXMLUpdatedEvent = EventManager.RegisterRoutedEvent(
      "MetadataXMLUpdated",
      RoutingStrategy.Tunnel,
      typeof(RoutedEventHandler),
      typeof(MetadataRules)
    );

    public static readonly RoutedEvent MetadataValidatePageEvent = EventManager.RegisterRoutedEvent(
      "MetadataValidatePage",
      RoutingStrategy.Tunnel,
      typeof(RoutedEventHandler),
      typeof(MetadataRules)
    );

    public static readonly RoutedEvent MetadataIssueEvent = EventManager.RegisterRoutedEvent(
        "MetadataIssueFound",
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(MetadataRules)
    );

    #endregion

    # region Metadata Issue Dependency Property

    /// <summary>
    ///  this property is set on issue Hyperlinks, created when finding errors in XAML or the profile config
    /// </summary>
    public static readonly DependencyProperty MetadataIssueProperty = DependencyProperty.RegisterAttached(
      "MetadataIssue",
      typeof(MetadataValidationIssue),
      typeof(MetadataRules),
      new PropertyMetadata(null)
    );

    public static void SetMetadataIssue(UIElement element, MetadataValidationIssue value)
    {
      element.SetValue(MetadataIssueProperty, value);
    }
    public static MetadataValidationIssue GetMetadataIssue(UIElement element)
    {
      return element.GetValue(MetadataIssueProperty) as MetadataValidationIssue;
    }

    #endregion

    #region Rules Dependency Property

    /// <summary>
    /// validation rule or rule set
    /// </summary>
    public static readonly DependencyProperty RulesProperty;

    public static DependencyProperty GetRules(UIElement target)
    {
      return target.GetValue(RulesProperty) as DependencyProperty;
    }

    public static void SetRules(UIElement target, DependencyProperty value)
    {
      target.SetValue(RulesProperty, value);
    }

    #endregion

    #region HasIssue

    /// <summary>
    /// flag set if an error has occured in a form element
    /// </summary>
    public static readonly DependencyProperty HasIssueProperty;

    public static bool GetHasIssue(UIElement target)
    {
      return (bool)target.GetValue(HasIssueProperty);
    }

    public static void SetHasIssue(UIElement target, bool value)
    {
      target.SetValue(HasIssueProperty, value);
    }

    #endregion

    #region Static Constructors

    static MetadataRules()
    {
      HasIssueProperty = DependencyProperty.RegisterAttached(
        "HasIssue",
        typeof(bool), typeof(MetadataRules),
        new UIPropertyMetadata(false, OnHasIssueChanged)
      );

      RulesProperty = DependencyProperty.RegisterAttached(
        "Rules",
        typeof(MetadataRuleSet), typeof(MetadataRules),
        new UIPropertyMetadata(null, OnRulesChanged)
      );
    }

    #endregion

    /// <summary>
    /// creating issues that arrise out of XAML and rules
    /// </summary>
    /// <param name="ruleSet"></param>
    /// <param name="dp"></param>
    /// <returns></returns>
    public static MetadataValidationIssue CreateIssue(MetadataRuleSet ruleSet, DependencyObject dp)
    {
      // get basic anchor name
      var anchor = Nav.GetAnchorInfo(dp);
      if (null == anchor)
        return null;

      //var expandedName = anchor.Expand(dp);
      var issue = new MetadataValidationIssue(true, ruleSet.Tag, "unknown", anchor.ExpandedAnchor, ruleSet.Msg, null);
      return issue;
    }

    /// <summary>
    /// triggered when the value v:MetadataRules.HasIssue is changed
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="args"></param>
    private static void OnHasIssueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
      if (!(obj is FrameworkElement)) return; // nothing to do

      FrameworkElement el = obj as FrameworkElement;

      DependencyProperty dp = null;
      if (el is TextBox)
      {
        dp = TextBox.TextProperty;
      }
      else if (el is ComboBox)
      {
        dp = ComboBox.SelectedValueProperty;
      }

      if (null == dp) return; // nothing to do

      // Throw Validation Error if we find any issue
      BindingExpression be = el.GetBindingExpression(dp);
      if (null != be)
      {
        if (GetHasIssue(el))
        {
          System.Windows.Controls.Validation.MarkInvalid(be, new ValidationError(new DummyValidator(), be));
        }
        else
        {
          System.Windows.Controls.Validation.ClearInvalid(be);
        }
      }
    }

    /// <summary>
    /// triggered when a control has v:MetadataRules.Rules="..."
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="args"></param>
    private static void OnRulesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
      // get UI element
      //
      if (!(obj is UIElement))
        throw new InvalidOperationException("Object must be a UI element.");
      Control el = obj as Control;

      // get rule set from the XAML
      //
      MetadataRuleSet ruleSet = args.NewValue as MetadataRuleSet;
      if (null == ruleSet)
        return;

      // get rules to run
      //
      MetadataRuleSet runSet = ruleSet.GetRules();

      // add handlers

      // avoid infinite loop!
      if (!(runSet is MetadataCheckRules))
        // run rules if a MetadataValidatePageEvent is received
        el.AddHandler(MetadataRules.MetadataValidatePageEvent, new RoutedEventHandler(runSet.RunRules));

      if (el is TextBox)
      {
        el.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(runSet.RunRules));
        el.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(MetadataRules.CheckRules.RunRules));
        el.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(runSet.RunRules));
      }
      else if (el is ComboBox)
      {
        el.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(runSet.RunRules));
        el.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(MetadataRules.CheckRules.RunRules));
        el.AddHandler(ComboBox.SelectionChangedEvent, new RoutedEventHandler(runSet.RunRules));
        el.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(runSet.RunRules));        
      }
      else if (el is DatePicker)
      {
        el.AddHandler(DatePicker.SelectedDateChangedEvent, new RoutedEventHandler(runSet.RunRules));
        el.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(runSet.RunRules));
      }
      else if (el is DateTimeControl)
      {
        // NOOP
      }
      else if (el is DateTimePicker)
      {
        // NOOP
      }
      else if (el is Label)
      {
        // NOOP
      }
      else if (el is EditorRichTextBox)
      {
        MetadataRuleSet adapted = new MetadataRulesAdapter(runSet); // TODO why doing this?
        el.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(adapted.RunRules));
      }
      else if (el is CheckBox)
      {
        el.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(runSet.RunRules));
        el.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(MetadataRules.CheckRules.RunRules)); 
        el.AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(runSet.RunRules));
        el.AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(runSet.RunRules));
        el.AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(runSet.RunRules));        
      }
      else if (el is RichTextBox)
      {
        el.AddHandler(RichTextBox.LoadedEvent, new RoutedEventHandler(runSet.RunRules));
        // NOTE see the RichTextBox class for how it adds other events for validation
      }
      else
      {
        // NOOP
      }   
    }
  }
}
