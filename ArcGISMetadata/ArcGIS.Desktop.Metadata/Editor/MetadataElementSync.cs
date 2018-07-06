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
using System.Xml;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Markup;
using System.Reflection;

namespace ArcGIS.Desktop.Metadata.Editor
{

  internal class SynchedElement
  {
    private string _originalContent = null;
    private bool _originalSync;
    //private string _syncedElement = ".";
    private bool isSynched = false;

    public string XPath { get; set; }

    public void TargetUpdated(Object sender, RoutedEventArgs args)
    {
      if (null != _originalContent)
        return; // already done

      // get xml context
      FrameworkElement tb = sender as FrameworkElement;
      var xmlContext = Utils.GetXmlDataContext(tb.DataContext);
      if (null == xmlContext)
        return;

      // get original sync status
      //
      var parent = xmlContext.First();
      if (null == parent)
        return; // nothing to do

      var node = parent.SelectSingleNode(XPath);

      if (null != node && 0 < node.InnerText.Length)
      {
        if (null == _originalContent)
        {

          // get original content from the source
          // may NOT be at the target yet...
          _originalContent = node.InnerText;

          XmlAttribute syncNode = GetSyncAttribute(node);
          if (null != syncNode)
          {
            isSynched = true;
            _originalSync = "true".Equals(syncNode.Value, StringComparison.InvariantCultureIgnoreCase);
          }
        }
      }
    }

    public void SourceUpdated(Object sender, RoutedEventArgs args)
    {

      if (!isSynched)
        return; // no work to do

      // get control
      //
      FrameworkElement tb = sender as FrameworkElement;

      // get xml context
      var xmlContext = Utils.GetXmlDataContext(tb.DataContext);
      if (null == xmlContext)
        return;

      // get xml context to set sync attribute if necessary
      //
      var parent = xmlContext.First();
      if (null == parent)
        return; // nothing to do

      var node = parent.SelectSingleNode(this.XPath);
      if (null != node && 0 < node.InnerText.Length)
      {

        String newContent = node.InnerText;

        // is modified
        bool isModified = (null != _originalContent) && (_originalContent != newContent);

        // get the sync attribute
        XmlAttribute syncNode = GetSyncAttribute(node);
        if (null != syncNode && isModified && "true".Equals(syncNode.Value, StringComparison.InvariantCultureIgnoreCase))
        {
          syncNode.Value = "FALSE";
        }
        else if (null != syncNode && _originalSync && !isModified)
        {
          syncNode.Value = "TRUE";
        }
      }
    }

    private static XmlAttribute GetSyncAttribute(XmlNode node)
    {
      var parent = node;
      if (XmlNodeType.Attribute == node.NodeType)
        parent = ((XmlAttribute)node).OwnerElement;

      var syncNode = parent.SelectSingleNode("@Sync|@sync|@SYNC") as XmlAttribute;
      return syncNode;
    }
  }


  public class MetadataBinding : MarkupExtension
  {

    // Our binding object, pre-initialized with PropertyChanged trigger.
    private Binding binding = new Binding
    {
      Mode = BindingMode.TwoWay,
      NotifyOnSourceUpdated = true,
      // NotifyOnTargetUpdated = true,
      XPath = ".",
      Converter = null,
    };

    public MetadataBinding() { }

    [DefaultValue(null)]
    public IValueConverter Converter
    {
      get { return binding.Converter; }
      set { binding.Converter = value; }
    }

    [DefaultValue(".")]
    public string XPath
    {
      get { return binding.XPath; }
      set { binding.XPath = value; }
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      if (serviceProvider == null)
        return this;

      var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

      DependencyObject targetDependencyObject;
      DependencyProperty targetDependencyProperty;

      MetadataElementSync.CheckCanReceiveMarkupExtension(this, provideValueTarget, out targetDependencyObject,
                                     out targetDependencyProperty);

      if (targetDependencyObject == null || targetDependencyProperty == null)
      {
        return this;
      }

      //// Fetch metadata - unused, just for your reference
      //var metadata =
      //    targetDependencyProperty.GetMetadata(targetDependencyObject.DependencyObjectType) as
      //    FrameworkPropertyMetadata;

      //if ((metadata != null && !metadata.IsDataBindingAllowed) || targetDependencyProperty.ReadOnly)
      //  throw new ArgumentException("");

      // Two-way binding requires a path
      if (
          (binding.Mode == BindingMode.TwoWay || binding.Mode == BindingMode.Default) &&
          binding.XPath == null &&
          (binding.Path == null || String.IsNullOrEmpty(binding.Path.Path))
          )
        throw new InvalidOperationException("Two way binding has no Path.");

      return binding.ProvideValue(serviceProvider);
    }
  }

  public class MetadataElementSync : MarkupExtension
  {

    private SynchedElement _se = null;

    // Our binding object, pre-initialized with PropertyChanged trigger.
    private Binding binding = new Binding
    {
      Mode = BindingMode.TwoWay,
      NotifyOnSourceUpdated = true,
      NotifyOnTargetUpdated = true,
      XPath = ".",
      Converter = null,
    };

    [DefaultValue(null)]
    public IValueConverter Converter
    {
      get { return binding.Converter; }
      set { binding.Converter = value; }
    }

    [DefaultValue(".")]
    public string XPath
    {
      get { return binding.XPath; }
      set { binding.XPath = value; }
    }

    public MetadataElementSync() { }

    public MetadataElementSync(string xpath)
      : this()
    {
      XPath = xpath;
      binding.XPath = xpath;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      if (serviceProvider == null)
        return this;

      var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

      DependencyObject targetDependencyObject;
      DependencyProperty targetDependencyProperty;

      CheckCanReceiveMarkupExtension(this, provideValueTarget, out targetDependencyObject,
                                     out targetDependencyProperty);

      if (targetDependencyObject == null || targetDependencyProperty == null)
      {
        return this;
      }

      if (null == _se)
      {
        // add binding handlers
        _se = new SynchedElement();
        _se.XPath = this.XPath;
        UIElement uiel = targetDependencyObject as UIElement;
        uiel.AddHandler(Binding.SourceUpdatedEvent, new RoutedEventHandler(_se.SourceUpdated));
        uiel.AddHandler(Binding.TargetUpdatedEvent, new RoutedEventHandler(_se.TargetUpdated));
      }

      // Fetch metadata - unused, just for your reference
      var metadata =
          targetDependencyProperty.GetMetadata(targetDependencyObject.DependencyObjectType) as
          FrameworkPropertyMetadata;

      if ((metadata != null && !metadata.IsDataBindingAllowed) || targetDependencyProperty.ReadOnly)
        throw new ArgumentException("");

      // Two-way binding requires a path
      if (
          (binding.Mode == BindingMode.TwoWay || binding.Mode == BindingMode.Default) &&
          binding.XPath == null &&
          (binding.Path == null || String.IsNullOrEmpty(binding.Path.Path))
          )
        throw new InvalidOperationException("Two way binding has no Path.");

      return binding.ProvideValue(serviceProvider);
    }

    ///
    /// This static method validates the holder of the current extension, where it is being defined. It detects the various scenarios
    /// where a MarkupExtension is allowed to be set and tests their candidacy for the assignment.
    ///
    public static void CheckCanReceiveMarkupExtension(MarkupExtension markupExtension,
                                                      IProvideValueTarget provideValueTarget,
                                                      out DependencyObject targetDependencyObject,
                                                      out DependencyProperty targetDependencyProperty)
    {
      targetDependencyObject = null;
      targetDependencyProperty = null;

      if (provideValueTarget == null)
        return;

      var targetObject = provideValueTarget.TargetObject;

      if (targetObject == null)
        return;

      var targetType = targetObject.GetType();
      var targetProperty = provideValueTarget.TargetProperty;

      if (targetProperty != null)
      {
        targetDependencyProperty = targetProperty as DependencyProperty;
        if (targetDependencyProperty != null)
        {
          targetDependencyObject = targetObject as DependencyObject;
        }
        else
        {
          // For the implementation at hand we should do this, because nothing else matters.
          // throw new XamlParseException("Type not assignable.");

          // Moving on with all possible cases...
          var targetMember = targetProperty as MemberInfo;
          if (targetMember != null)
          {
            // If targetMember is a MemberInfo, then its the CLR Property case.
            // Setters, Triggers, DataTriggers & Conditions are the special cases of
            // CLR properties in which DynamicResource and Bindings are allowed.
            // Since StyleHelper.ProcessSharedPropertyValue prevents calls to ProvideValue
            // in such cases, there is no need for special code to handle them here.
            Type memberType;

            var propertyInfo = targetMember as PropertyInfo;
            if (propertyInfo != null)
              memberType = propertyInfo.PropertyType;
            else
            {
              var methodInfo = (MethodInfo)targetMember;
              var parameterInfos = methodInfo.GetParameters();

              memberType = parameterInfos[1].ParameterType;
            }

            // Check if the MarkupExtensionType is assignable to the given MemberType
            // This checking allows properties like DataTrigger.Binding, Condition.Binding
            // HierarchicalDataTemplate.ItemsSource, GridViewColumn.DisplayMemberBinding
            if (!typeof(MarkupExtension).IsAssignableFrom(memberType) ||
                !memberType.IsAssignableFrom(markupExtension.GetType()))
            {
              throw new XamlParseException("Type not assignable.");
            }
          }
          else
          {
            throw new XamlParseException("Type not assignable.");
          }
        }
      }
      else
      {
        throw new XamlParseException("Type not assignable.");
      }
    }
  }
}
