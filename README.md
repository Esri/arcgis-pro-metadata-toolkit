# ArcGIS Pro Metadata Toolkit

Extend ArcGIS Pro with ArcGIS Pro Metadata Toolkit. The ArcGIS Pro Metadata Toolkit is based on the add-in and configurations extensibility pattern. This toolkit provides resources to support customizing the pages that appear in the ArcGIS Pro metadata editor to suit your organizational, community, or regional requirements. Customize the metadata display within ArcGIS Pro, and how metadata is imported to and exported from the ArcGIS Metadata XML format. Your modifications can be distributed as an ArcGIS Pro Metadata add-in.

***

## Table of Contents
- [Introduction](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit#introduction)
- [Requirements](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit#requirements)
- [Installing ArcGIS Pro Metadata Toolkit](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit#installing-arcgis-pro-metadata-toolkit)
- [ArcGIS Pro Metadata Toolkit components](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit#arcgis-pro-metadata-toolkit-components)
- [ArcGIS Pro Metadata Toolkit templates](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit#arcgis-pro-metadata-toolkit-templates)
- [Build your first ArcGIS Pro metadata editor add-in](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Build-your-first-ArcGIS-Pro-metadata-editor-add-in)
- [Change the pages used in the metadata editor](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Change-the-pages-used-in-the-metadata-editor)
- [Change the values in a list](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Change-the-values-in-a-list)
- [Create a custom page](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Create-a-custom-page)
- [Customize the metadata display](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Customize-the-metadata-display)
- [Customize the metadata translators](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Customize-the-metadata-translators)
- [Release notes](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit#release-notes)

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
As indicated in the [ArcGIS Pro SDK Requirements](https://github.com/Esri/arcgis-pro-sdk#requirements), ArcGIS Pro 3.0 introduces support for .NET 6.0, Microsoft's latest edition of .NET. Support for .NET 6.0 replaces support for .NET Framework 4.8. With 3.0, .NET Framework 4.8 is no longer be supported. This is a breaking change.

### Supported IDEs
As indicated in the [ArcGIS Pro SDK Requirements](https://github.com/Esri/arcgis-pro-sdk#requirements),  ArcGIS Pro 3.0 SDK introduces support for Visual Studio 2022, Microsoft's latest edition of its IDE. With 3.0, Visual Studio 2017 and 2019 will no longer be supported.

### Third party assemblies
_Newtonsoft Json_
At 3.0, ArcGIS Pro is using version 13.0.1.25517 of the Newtonsoft Json NuGet. It is recommended to use the same version for your ArcGIS Pro Metadata add-in.

## Installing ArcGIS Pro Metadata Toolkit[](#installing-arcgis-pro-metadata-toolkit)
After the ArcGIS Pro SDK for .NET, and ArcGIS Pro SDK for .NET (Utilities), have been downloaded and installed, the ArcGIS Pro Metadata Toolkit can also be downloaded and installed from within Visual Studio.
* [Installing ArcGIS Pro SDK for .NET, and ArcGIS Pro SDK for .NET (Utilities)](https://github.com/Esri/arcgis-pro-sdk/wiki/ProGuide-Installation-and-Upgrade)
* [Installing ArcGIS Pro Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/ArcGIS-Pro-Metadata-Toolkit-Installation)

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

## Release notes[](#release-notes)

### ArcGIS Pro Metadata Toolkit 3.0.0.36056

These release notes describe details of the ArcGIS Pro Metadata Toolkit 3.0.0.36056 release. Here you will find information about available functionality as well as known issues and limitations.

#### What’s new
This release of the ArcGIS Pro Metadata Toolkit is not significantly different from the previous release. 

								   
																																	

											  
																																																																																																																																																																																 

																																			  
																																																																																																												 

													
																																																																																																																																																																										

																																																																																																																													

																													 

					   
																																																																																																					   

																																																																																																																				   

																																																																																																															

#### New topic in the wiki
A new page was added to the wiki that describes how to [customize validation rules](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/wiki/Customize-the-validation-rules-for-a-page) for pages in the metadata editor.

#### Bug fixes
The metadata toolkit was also updated to include bug fixes for the following items:
- A crash scenario when switching the localized langauge to Czech when editing metadata.
- Scale range logic was updated to display the appropriate scale when editing metadata.
- Labels for scale slider controls now display proper number formating for CZ/FR/TR/IT localized languages.
- Saving thumbnail images for multiple toolbox models now save the appropriate thumbnail image for their corresponding toolbox model.
- The namespace ```MetadataTookKit``` was updated to ```MetadataToolkit``` for naming consistency.

#### Leverage administrator settings
When you develop a custom metadata editor for your organization, you can work with the GIS administrator to [manage ArcGIS Pro application settings](https://pro.arcgis.com/en/pro-app/latest/get-started/application-setting-management.htm). People in the organization who use ArcGIS Pro can be required to use the custom metadata editor add-in by setting the ```MetadataStyle``` setting to the same value as the ```displayName``` property specified in your editor’s ```Config.daml``` file.

#### Known limitations
There are no changes to the existing list of known limitations at ArcGIS Pro version 3.0.

- When a custom metadata style is used, the importers and exporters defined for the custom style are not automatically selected when the Import Metadata and Export Metadata dialog boxes are opened. All of the importers and exporters provided with ArcGIS Pro are listed. If a custom importer and exporter are defined they will also be included in the list. The appropriate importer or exporter must be selected manually.
- The ArcGIS Pro metadata editor doesn't yet have a central location in which to display guidance for the content that should be provided in a metadata element.
- The capability to validate an item's metadata using an XML schema is not yet available in ArcGIS Pro.


### Previous releases

- [ArcGIS Pro 2.9 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.9.0.32739)
- [ArcGIS Pro 2.6 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/v2.6.0.24783)
- [ArcGIS Pro 2.4 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.4.0.18895)
- [ArcGIS Pro 2.3 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.3.0.15769)

## Contributing

Esri welcomes contributions from anyone and everyone. For more information, see our [guidelines for contributing](https://github.com/esri/contributing).

## Issues
Find a bug or want to request a new feature? Let us know by submitting an issue.

## Licensing
Copyright 2022 Esri

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at:

http://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

A copy of the license is available in the repository's [license.txt](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/blob/master/license.txt) file.
