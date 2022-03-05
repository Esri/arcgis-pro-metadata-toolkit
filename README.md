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
As indicated in the [ArcGIS Pro SDK Requirements](https://github.com/Esri/arcgis-pro-sdk#requirements), ArcGIS Pro 2.9 is the last release with .NET Framework 4.8. ArcGIS Pro 3.0 will introduce support for .NET 6.0, Microsoft's latest edition of .NET. Support for .NET 6.0 will replace support for .NET Framework 4.8. With 3.0, .NET Framework 4.8 will no longer be supported. This will be a breaking change.

### Supported IDEs
As indicated in the [ArcGIS Pro SDK Requirements](https://github.com/Esri/arcgis-pro-sdk#requirements),  ArcGIS Pro 2.9 SDK is the last release with support for Visual Studio 2017 and 2019. The ArcGIS Pro 3.0 SDK will introduce support for Visual Studio 2022, Microsoft's latest edition of its IDE. Support for Visual Studio 2022 will replace support for Visual Studio 2017 and 2019. With 3.0, Visual Studio 2017 and 2019 will no longer be supported.

### Third party assemblies
_Newtonsoft Json_
At 2.9 ArcGIS Pro is using version 12.0.1 of the Newtonsoft Json NuGet. It is recommended to use the same version for your ArcGIS Pro Metadata add-in.

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

### ArcGIS Pro Metadata Toolkit 2.9.0.32739

These release notes describe details of the ArcGIS Pro Metadata Toolkit 2.9.0.32739 release. Here you will find information about available functionality as well as known issues and limitations.

#### What’s new
This release of the ArcGIS Pro Metadata Toolkit is not significantly different from the previous release. 

##### Improved support for INSPIRE 
In this release, you can create an ArcGIS Pro Metadata Toolkit add-in that is based on the INSPIRE Metadata Directive version 2.0.1.

###### New INSPIRE-specific controls available
When you create a new Visual Studio project using the ArcGIS Pro Metadata Toolkit project template [two new references](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Build-your-first-ArcGIS-Pro-metadata-editor-add-in), Newtonsoft.Json and System.Net.Http, must be added to support a new INSPIRE-specific metadata control. (No change to the system requirements for consumers of the add-in.) A **Lookup** button on the **Overview > Topics & Keywords** page opens a dialog box. The dialog box accesses the INSPIRE GEMET thesaurus on the internet and provides a list of keywords for your language. The code associated with this dialog box is provided on the new ```MD_ThemeKeywords.xaml``` page. 

On the **Resource > Constraints** page, two additional INSPIRE-specific controls were added to set values for new INSPIRE-specific codelists. 
The INSPIRE-specific controls mentioned above will appear in your custom metadata editor if you set the ArcGISProfile property in the ```Config.daml``` file to "INSPIRE". Any style-specific controls provided in the default metadata editor pages will not appear in your custom metadata editor if you use a different profile keyword unless you change the condition for those controls to be associated with your profile keyword instead.

###### INSPIRE-required text can be added by default
On the **Overview > Topics & Keywords** page, the installed INSPIRE metadata style adds a default title automatically to define the GEMET thesaurus. This helps produce metadata that passes INSPIRE’s content validation process, which is particular about exact strings being present. The default text will not appear in your custom metadata editor even when the ArcGISProfile is set to "INSPIRE". Update the ```MD_Keywords.xaml.cs``` file to set the default thesaurus title and URL you want to use in the ```MD_Keywords_Loaded``` method. The INSPIRE validator expects the title "GEMET - INSPIRE themes, version 1.0" and the URL "http://www.eionet.europa.eu/gemet/inspire_themes". 

On the **Resource > Quality** page, for INSPIRE you are required to provide a domain consistency report, which must have a conformance result with a specification that correctly identifies the INSPIRE Metadata Directive in the language of the metadata. A drop-down list is available that can be used to select the appropriate title from a list. To show this drop-down list, change the ```UseDropdown``` setting from false to true in the ```CI_Citation.xaml.cs``` file in the ```SetDefaults``` method.

This framework can be adapted to support custom thesauri or dictionaries of data quality specifications, for example.

##### Resources updated
The ArcGIS Metadata XML format was updated—two new elements were added to capture these values. The Excel worksheet and the XML DTD that together define the ArcGIS Metadata format and are provided as [resources in this repository](https://github.com/Esri/arcgis-pro-metadata-toolkit/tree/master/resources) were updated. Additional housekeeping was performed to correct issues and bring files up to date.

The INSPIRE metadata style’s validation rules were updated in the metadata editor to reflect the current regulations defined in the 2.0.1 version of the metadata directive. The [resource file](https://github.com/Esri/arcgis-pro-metadata-toolkit/blob/master/resources/default%20editor%20configurations/INSPIRE.xml) that provides an example of the default metadata editor configuration for the INSPIRE Metadata Directive style was updated to reflect these changes. 

The [sample metadata documents](https://github.com/Esri/arcgis-pro-metadata-toolkit/tree/master/resources/sample%20metadata%20documents) provided as resources were also updated. The changes reflect the presence of the two new ArcGIS Metadata elements. Other sample documents represent how the ArcGIS Metadata format is converted to other standard formats. Those documents were also updated to reflect updates to the ArcGIS metadata exporters.

#### New topic in the wiki
A new page was added to the wiki that describes how to [customize validation rules](https://github.com/Esri/arcgis-pro-metadata-toolkit/wiki/Customize-the-validation-rules-for-a-page) for pages in the metadata editor.

#### Bug fixes
The metadata toolkit was also updated to include bug fixes related for saving thumbnails that were also included in the released version of the ArcGIS metadata editor. If you upload a new thumbnail on the **Overview > Item Description** page and switch to a different page before pressing **Save**, the thumbnail should now be saved in the item’s metadata. 

#### Leverage administrator settings
When you develop a custom metadata editor for your organization, you can work with the GIS administrator to [manage ArcGIS Pro application settings](https://pro.arcgis.com/en/pro-app/latest/get-started/application-setting-management.htm). People in the organization who use ArcGIS Pro can be required to use the custom metadata editor add-in by setting the ```MetadataStyle``` setting to the same value as the ```displayName``` property specified in your editor’s ```Config.daml``` file.

#### Known limitations
There are no changes to the existing list of known limitations at ArcGIS Pro version 2.9.

- When a custom metadata style is used, the importers and exporters defined for the custom style are not automatically selected when the Import Metadata and Export Metadata dialog boxes are opened. All of the importers and exporters provided with ArcGIS Pro are listed. If a custom importer and exporter are defined they will also be included in the list. The appropriate importer or exporter must be selected manually.
- The ArcGIS Pro metadata editor doesn't yet have a central location in which to display guidance for the content that should be provided in a metadata element.
- The capability to validate an item's metadata using an XML schema is not yet available in ArcGIS Pro.


### Previous releases

- [ArcGIS Pro 2.6 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/v2.6.0.24783)
- [ArcGIS Pro 2.4 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.4.0.18895)
- [ArcGIS Pro 2.3 Metadata Toolkit](https://github.com/Esri/arcgis-pro-metadata-toolkit/releases/tag/2.3.0.15769)

## Contributing

Esri welcomes contributions from anyone and everyone. For more information, see our [guidelines for contributing](https://github.com/esri/contributing).

## Issues
Find a bug or want to request a new feature? Let us know by submitting an issue.

## Licensing
Copyright 2020 Esri

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at:

http://www.apache.org/licenses/LICENSE-2.0.

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

A copy of the license is available in the repository's [license.txt](https://github.com/Esri/arcgis-pro-metadata-toolkit/blob/master/license.txt) file.
