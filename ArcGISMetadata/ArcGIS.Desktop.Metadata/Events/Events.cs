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

using ArcGIS.Desktop.Framework;
using ArcGIS.Core.Events;
using ArcGIS.Desktop.Framework.Events;

namespace ArcGIS.Desktop.Internal.Metadata.Events
{
  /// <summary>
  /// This class is not for public use and is used internally by the system to 
  /// implement support for other ArcGIS Pro modules
  /// </summary>
  public class MetadataEditEvent : ArcGIS.Core.Events.CompositePresentationEvent<MetadataEditEventArgs>
  {
    public static SubscriptionToken Subscribe(Action<MetadataEditEventArgs> action, bool keepSubscriberAlive = false)
    {
      return FrameworkApplication.EventAggregator.GetEvent<MetadataEditEvent>().Register(action, keepSubscriberAlive);
    }

    public static void Unsubscribe(Action<MetadataEditEventArgs> action)
    {
      FrameworkApplication.EventAggregator.GetEvent<MetadataEditEvent>().Unregister(action);
    }

    public static void Unsubscribe(SubscriptionToken token)
    {
      FrameworkApplication.EventAggregator.GetEvent<MetadataEditEvent>().Unregister(token);
    }

    public static void Publish(MetadataEditEventArgs metadataEventArgs)
    {
      FrameworkApplication.EventAggregator.GetEvent<MetadataEditEvent>().Broadcast(metadataEventArgs);
    }
  }
}
