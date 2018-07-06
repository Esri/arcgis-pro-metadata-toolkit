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
﻿namespace ArcGIS.Desktop.Metadata.Editor.Controls
{
	/// <summary>
	/// Defines possible directions a <see cref="Resizer"/> can resize.
	/// </summary>
	public enum ResizeDirection
	{
		/// <summary>
		/// Size is increased by dragging up and to the right, and decreased by dragging down and to the left.
		/// </summary>
		NorthEast,
		/// <summary>
		/// Size is increased by dragging up and to the left, and decreased by dragging down and to the right.
		/// </summary>
		NorthWest,
		/// <summary>
		/// Size is increased by dragging down and to the right, and decreased by dragging up and to the left.
		/// </summary>
		SouthEast,
		/// <summary>
		/// Size is increased by dragging down and to the left, and decreased by dragging up and to the right.
		/// </summary>
		SouthWest
	}
}
