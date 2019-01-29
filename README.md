# ArcGIS Pro Metadata Toolkit

Extend ArcGIS Pro with ArcGIS Pro Metadata Toolkit. The ArcGIS Pro Metadata Toolkit is based on the add-in and configurations extensibility pattern. This toolkit provides resources to support customizing the pages that appear in the ArcGIS Pro metadata editor to suit your organizational, community, or regional requirements. Your modifications can be distributed as an ArcGIS Pro Add-In.

***

* [Introduction](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki#introduction)
* [Requirements](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki#requirements)
* [Installing ArcGIS Pro Metadata Toolkit](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki#installing-arcgis-pro-metadata-toolkit)
* [ArcGIS Pro Metadata Toolkit components](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki#arcgis-pro-metadata-toolkit-components)
* [ArcGIS Pro Metadata Toolkit templates](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki#arcgis-pro-metadata-toolkit-templates)
* [Get started](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki#get-started)
* [Known issues](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki#known-issues)

## Introduction[](#introduction)

The ArcGIS Metadata Toolkit provides information and supports the following activities relating to the creation and management of metadata in ArcGIS Pro. Customization of the metadata experience in ArcMap, ArcCatalog, ArcGlobe, and ArcScene is not supported by this toolkit.

- Document the XML format in which an item’s metadata is made available to the metadata editor.
- Change the pages included in the metadata editor, except for the Item Description page, which must be included.
- Change the values provided in drop-down lists in the metadata editor.
- Change the validation rules associated with the content that can be provided in the metadata editor.
- Change the elements included in an existing metadata page, except for metadata elements that are required by ArcGIS software.
- Add a custom metadata element to a page and to the ArcGIS metadata format.
- Add a custom page to the metadata editor.
- Change the manner in which metadata is displayed.
- Change the Translator that is specified by default in the Export Metadata and Import Metadata dialog boxes. The Translator converts an item's ArcGIS metadata to a standard XML format, or converts metadata in a standard XML format to ArcGIS metadata.

The ArcGIS Metadata Toolkit is not intended to be used for the following purposes.

- Change the manner in which ArcGIS software communicates with the metadata editor or an item’s metadata.
- Change the entire metadata editor to store content in a different XML format instead of storing content in the ArcGIS metadata format.

## Requirements[](#requirements)
The ArcGIS Pro Metadata Toolkit has the same requirements as the ArcGIS Pro SDK for .NET. The machine on which you develop a custom version of the ArcGIS Pro metadata editor must satisfy the requirements.
* [Requirements](https://github.com/Esri/arcgis-pro-sdk/wiki#requirements)

## Installing ArcGIS Pro Metadata Toolkit[](#installing-arcgis-pro-metadata-toolkit)
After the ArcGIS Pro SDK for .NET, and ArcGIS Pro SDK for .NET (Utilities), have been downloaded and installed, the ArcGIS Pro Metadata Toolkit can also be downloaded and installed from within Visual Studio.
* [Installing ArcGIS Pro SDK for .NET, and ArcGIS Pro SDK for .NET (Utilities)](https://github.com/Esri/arcgis-pro-sdk/wiki/ProGuide-Installation-and-Upgrade)
* [Installing ArcGIS Pro Metadata Toolkit](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/ArcGIS-Pro-Metadata-Toolkit-Installation)

## ArcGIS Pro Metadata Toolkit components[](#arcgis-pro-metadata-toolkit-components)
The following table summarizes the functionality of each .vsix file included in the SDK download:

| Name	| File	| Functionality	|
| ----- | -----	| -------------	|
|ArcGIS Pro Metadata Toolkit	| proapp-sdk-metadata-templates.vsix	| A collection of project templates to customize existing pages in the ArcGIS Pro metadata editor, or add a new custom page to the editor |

## ArcGIS Pro Metadata Toolkit templates[](#arcgis-pro-metadata-toolkit-templates)
Package: proapp-sdk-metadata-templates.vsix

ArcGIS Pro Metadata Toolkit provides the following project templates:

| C#	| Name	|
| ----- | -----	|
| ![ArcGIS Pro Add-in C#](https://camo.githubusercontent.com/fa0bb62d6c13e36c08fecaee3f61558e40b8ba16/687474703a2f2f457372692e6769746875622e696f2f6172636769732d70726f2d73646b2f696d616765732f56697375616c53747564696f54656d706c617465732f41726347495350726f4d6f64756c654333322e706e67 "ArcGIS Pro Add-in C#") | ArcGIS Pro Custom Metadata Editor Source Project template |

## Get started[](#get-started)
- [Build your first ArcGIS Pro metadata editor add-in](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Build-your-first-ArcGIS-Pro-metadata-editor-add-in)
- [Change the pages used in the metadata editor](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Change-the-pages-used-in-the-metadata-editor)
- [Change the values in a list](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Change-the-values-in-a-list)
- [Create a custom page](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Create-a-custom-page)
- [Customize the metadata display](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Customize-the-metadata-display)
- [Customize the metadata translators](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Customize-the-metadata-translators)
