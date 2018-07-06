/*
COPYRIGHT 2013-2016 ESRI

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
using System.Threading.Tasks;

using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Internal.Models;
using ArcGIS.Desktop.Metadata.Editor;
using ArcGIS.Desktop.Core;

namespace ArcGIS.Desktop.Internal.Metadata.Events
{
  /// <summary>
  /// This class is not for public use and is used internally by the system to 
  /// implement support for other ArcGIS Pro modules
  /// </summary>
  public enum MetadataEditEventAction
  {
    Edit, CancelEdit, Print, Save, Select, Close, Reload
  };

  /// <summary>
  /// This class is not for public use and is used internally by the system to 
  /// implement support for other ArcGIS Pro modules
  /// </summary>
  public class MetadataEditEventArgs
  {
    public enum SenderEnum { esriMDSenderEditor, esriMDSenderMapPropsPage, esriMDSenderTask };
    public MetadataEditEventAction Action { get; set; }
    public uint PaneID { get; set; }
    public Item Item { get; set; }
    public string TypeID { get; set; }
    public string Path { get; set; }
    public string Metadata { get; set; }
    public SenderEnum Sender { get; set; } 
    public bool IsFromEditor { get; set; }

    public MetadataEditEventArgs(MetadataEditEventAction action)
    {
      // use the current active pane
      // assume this is a project view view model
      if (FrameworkApplication.Panes.ActivePane != null)
        this.PaneID = FrameworkApplication.Panes.ActivePane.InstanceID;
      this.Action = action;
    }

    public MetadataEditEventArgs(Item targetItem, MetadataEditEventAction action)
      : this(action)
    {
      this.Item = targetItem;
      this.TypeID = targetItem.TypeID;
    }
  }
}
