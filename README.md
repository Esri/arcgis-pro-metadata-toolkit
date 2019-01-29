# ArcGIS Pro Metadata Toolkit

Extend ArcGIS Pro with ArcGIS Pro Metadata Toolkit. The ArcGIS Pro Metadata Toolkit is based on the add-in and configurations extensibility pattern. This toolkit provides resources to support customizing the pages that appear in the ArcGIS Pro metadata editor to suit your organizational, community, or regional requirements. Your modifications can be distributed as an ArcGIS Pro Add-In.

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

## Release notes[](#release-notes)

### ArcGIS Pro Metadata Toolkit 1.0

These release notes describe details of the ArcGIS Pro Metadata Toolkit 1.0 release. Here you will find information about available functionality as well as known issues and limitations.

#### What's new

The ArcGIS Pro Metadata Toolkit 1.0 release is similar to the ArcGIS Metadata Toolkit for ArcMap that continues to be available as a download from the Esri Support site. The pages in the ArcGIS Pro metadata editor are very similar, and in general, the same customizations can be made in ArcMap and ArcGIS Pro. 

However, the code associated with the ArcGIS Pro Metadata Toolkit is available as a Visual Studio project template instead of as an archived solution. Also, customizations created with the ArcGIS Pro Metadata Toolkit are delivered as an add-in to ArcGIS Pro. Your customizations become available in the ArcGIS Pro Options dialog box on the Metadata tab once the add-in has been installed. Add-ins can be created for ArcGIS Pro 2.3. Add-ins with some limitations can also be created for ArcGIS Pro 2.2. 

#### Known limitations

- There is a spelling error for one of the pages in the Metadata Toolkit repo. One of the XAML pages is named for the MD_CoverageDescription class defined in the ISO 19115 metadata standard, however, the file name has this class name incorrectly spelled. The file name is spelled MD_ConverageDescriptionBase.xaml instead of MD_CoverageDescriptionBase.xaml. The page works correctly, and is correctly referenced by the rest of the application. The spelling error is only visible to those who develop customizations with the toolkit.
- The ArcGIS Pro metadata toolkit can be used to customize the metadata editor and the metadata display for ArcGIS Pro 2.2. However, while ArcGIS Pro 2.2 supports importing and exporting metadata, any custom importers or exporters defined in a metadata toolkit add-in compiled for this release will not be recognized and included in the Pro 2.2 Import Metadata and Export Metadata dialog boxes. They will appear in a metadata toolkit add-in compiled for ArcGIS Pro 2.3. 
- It is possible to add custom metadata elements in ArcGIS metadata, and to create a custom metadata importer for Pro 2.3 that handles those custom elements. However, if the custom metadata elements are in a separate custom section at the root of the metadata document, these elements will not be saved successfully in the item's ArcGIS metadata. Custom elements should be placed in a "custom" section at the root of the metadata document. A future update will correct the problem and ensure the "custom" section of the metadata is successfully saved to the item's metadata. 
- The ArcGIS Pro metadata editor doesn't yet have a central location in which to display guidance for the content that should be provided in a metadata element.  
- The capability to validate an item's metadata using an XML schema is not yet available in ArcGIS Pro.

## Contributing

Esri welcomes contributions from anyone and everyone. For more information, see our [guidelines for contributing](https://github.com/esri/contributing).

## Issues
Find a bug or want to request a new feature? Let us know by submitting an issue.

## Licensing
Copyright 2019 Esri

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at:

http://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

A copy of the license is available in the repository's [license.txt](https://github.com/ArcGIS/arcgis-pro-metadata-toolkit/blob/master/license.txt) file.
