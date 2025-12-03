# ArcGIS Pro Metadata Toolkit

Extend ArcGIS Pro with ArcGIS Pro Metadata Toolkit. The ArcGIS Pro Metadata Toolkit is based on the add-in and configurations extensibility pattern. This toolkit provides resources to support customizing the pages that appear in the ArcGIS Pro metadata editor to suit your organizational, community, or regional requirements. Customize the metadata display within ArcGIS Pro, and how metadata is imported to and exported from the ArcGIS Metadata XML format. Your modifications can be distributed as an ArcGIS Pro Metadata add-in.

***

## Table of Contents
- [Introduction](https://github.com/Esri/arcgis-pro-metadata-toolkit#introduction)
- [Requirements](https://github.com/Esri/arcgis-pro-metadata-toolkit#requirements)
- [Installing ArcGIS Pro Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit#installing-arcgis-pro-metadata-toolkit)
- [ArcGIS Pro Metadata Toolkit components](https://github.com/Esri/arcgis-pro-metadata-toolkit#arcgis-pro-metadata-toolkit-components)
- [ArcGIS Pro Metadata Toolkit templates](https://github.com/Esri/arcgis-pro-metadata-toolkit#arcgis-pro-metadata-toolkit-templates)
- [Build your first ArcGIS Pro metadata editor add-in](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Build-your-first-ArcGIS-Pro-metadata-editor-add-in)
- [Change the pages used in the metadata editor](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Change-the-pages-used-in-the-metadata-editor)
- [Change the values in a list](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Change-the-values-in-a-list)
- [Create a custom page](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Create-a-custom-page)
- [Customize the metadata display](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Customize-the-metadata-display)
- [Customize the metadata translators](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Customize-the-metadata-translators)
- [Release notes](https://github.com/Esri/arcgis-pro-metadata-toolkit#release-notes)

## Introduction[](#introduction)

The ArcGIS Metadata Toolkit provides information and supports the following activities relating to the creation and management of metadata in ArcGIS Pro. Customization of the metadata experience in ArcMap, ArcCatalog, ArcGlobe, and ArcScene is not supported by this toolkit.

- Change the pages included in the metadata editor, except for the Item Description page, which must be included.
- Change the values provided in drop-down lists in the metadata editor.
- Change the elements included in an existing metadata page, except for metadata elements that are required by ArcGIS software.
- Add a custom metadata element to a page and to the ArcGIS metadata format.
- Add a custom page to the metadata editor.
- Change the manner in which metadata is displayed.
- Change the manner in which metadata is imported and exported to ArcGIS items, for example, to support custom metadata content. For example, export an item's ArcGIS metadata to a standard XML format, or convert a standards-compliant metadata XML document to the ArcGIS metadata XML format and store the resulting content as an item's metadata.
- Change the validation rules associated with the content that can be provided in the metadata editor.

The ArcGIS Metadata Toolkit is not intended to be used for the following purposes.

- Change the manner in which ArcGIS software communicates with the metadata editor or an item’s metadata.
- Change the entire metadata editor to store content in a different XML format instead of storing content in the ArcGIS metadata format.

## Requirements[](#requirements)
The ArcGIS Pro Metadata Toolkit has the same requirements as the ArcGIS Pro SDK for .NET. The machine on which you develop a custom version of the ArcGIS Pro metadata editor must satisfy the requirements.
* [Requirements](https://github.com/Esri/arcgis-pro-sdk/wiki#requirements)

### Supported .NET framework
As indicated in the [ArcGIS Pro SDK Requirements](https://github.com/Esri/arcgis-pro-sdk#requirements), ArcGIS Pro 3.6 supports .NET 8.0, Microsoft's latest edition of .NET.

### Supported IDEs
As indicated in the [ArcGIS Pro SDK Requirements](https://github.com/Esri/arcgis-pro-sdk#requirements),  ArcGIS Pro 3.6 SDK supports Visual Studio 2022, Microsoft's latest edition of its IDE.

### Third party assemblies
_Newtonsoft Json_
At 3.6, ArcGIS Pro is using version 13.0.3.27908 of the Newtonsoft Json NuGet. It is recommended to use the same version for your ArcGIS Pro Metadata add-in.

_WebView2_

Add-in developers can use the new WebViewBrowser control based on Microsoft Edge WebView2. Microsoft Edge WebView2 Runtime version 132 or later is required.

## Installing ArcGIS Pro Metadata Toolkit[](#installing-arcgis-pro-metadata-toolkit)
After the ArcGIS Pro SDK for .NET, and ArcGIS Pro SDK for .NET (Utilities), have been downloaded and installed, the ArcGIS Pro Metadata Toolkit can also be downloaded and installed from within Visual Studio.
* [Installing ArcGIS Pro SDK for .NET, and ArcGIS Pro SDK for .NET (Utilities)](https://github.com/Esri/arcgis-pro-sdk/wiki/ProGuide-Installation-and-Upgrade)
* [Installing ArcGIS Pro Metadata Toolkit for ArcGIS Pro 3.6](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/ArcGIS-Pro-Metadata-Toolkit-Installation#install-arcgis-pro-metadata-toolkit-36)
                                                            
#### For ArcGIS Pro version 3.3 or earlier:
* Download the [VSIX file](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/3.3.0.52636) for ArcGIS Pro Metadata Toolkit version 3.3.0.52636 and install it.
* [Installing ArcGIS Pro Metadata Toolkit for ArcGIS Pro 3.3](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/ArcGIS-Pro-Metadata-Toolkit-Installation#install-arcgis-pro-metadata-toolkit-33)

## ArcGIS Pro Metadata Toolkit components[](#arcgis-pro-metadata-toolkit-components)
The following table summarizes the functionality of the .vsix file included in the ArcGIS Pro Metadata Toolkit download:

| Name	| File	| Functionality	|
| ----- | -----	| -------------	|
| ArcGIS Pro Metadata Toolkit	| proapp-sdk-metadata-templates.vsix	| A collection of project templates to customize existing pages in the ArcGIS Pro metadata editor, or add a new custom page to the editor |

## ArcGIS Pro Metadata Toolkit templates[](#arcgis-pro-metadata-toolkit-templates)
Package: proapp-sdk-metadata-templates.vsix

ArcGIS Pro Metadata Toolkit provides the following project templates:

| C#	| Name	|
| ----- | -----	|
| ![ArcGIS Pro Add-in C#](resources/metadata-toolkit-template-icon.png "ArcGIS Pro Add-in C#") | ArcGIS Pro Custom Metadata Editor Source Project template |

## Release notes[](#release-notes)

### ArcGIS Pro Metadata Toolkit 3.6.0.59527
These release notes describe details of the ArcGIS Pro Metadata Toolkit 3.6.0.59527 release. Here you will find information about available functionality as well as known issues and limitations.

#### What’s new
This release of the ArcGIS Pro Metadata Toolkit is not significantly different from the previous release.

The version of the Visual Studio template for ArcGIS Pro 3.6 is available from Visual Studio Marketplace. The Visual Studio template for ArcGIS Pro 3.0-3.3 remains available from the Visual Studio Marketplace website. For convenience, the older Visual Studio template and the source code are available as a download from this repository from the 3.3 release.

#### Bug fixes
The metadata toolkit includes bug fixes for the following items:
- Allowing minimum and maximum vertical extents to be the same value.
- Visibility and contrast issues on the geoprocessing history page.
- Displaying incorrect label for Metadata Contacts.

#### Leverage administrator settings
When you develop a custom metadata editor for your organization, you can work with the GIS administrator to [manage ArcGIS Pro application settings](https://pro.arcgis.com/en/pro-app/latest/get-started/application-setting-management.htm). People in the organization who use ArcGIS Pro can be required to use the custom metadata editor add-in by setting the ```MetadataStyle``` setting to the same value as the ```displayName``` property specified in your editor’s ```Config.daml``` file.

#### Known limitations
There are no additional limitations in Pro 3.6 beyond those documented with earlier releases.

### Previous releases
- [ArcGIS Pro 3.4 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/3.4.0.55405)
- [ArcGIS Pro 3.3 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/3.3.0.52636)
- [ArcGIS Pro 3.0 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/3.0.0.36056)
- [ArcGIS Pro 2.9 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.9.0.32739)
- [ArcGIS Pro 2.6 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.6.0.24783)
- [ArcGIS Pro 2.4 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.4.0.18895)
- [ArcGIS Pro 2.3 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.3.0.15769)

## Contributing
Esri welcomes contributions from anyone and everyone. For more information, see our [guidelines for contributing](https://github.com/esri/contributing).

## Issues
Find a bug or want to request a new feature? Let us know by submitting an issue.

## Licensing
Copyright 2025 Esri

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at:

http://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

A copy of the license is available in the repository's [license.txt](https://github.com/Esri/arcgis-pro-metadata-toolkit/blob/master/license.txt) file.
