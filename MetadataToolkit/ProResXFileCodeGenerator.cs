/*
Copyright 2019 Esri
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.​
*/

using System.Threading;
using System.Web;

namespace MetadataToolkit.Properties
{
	internal class Definitions
	{
        private static global::System.Resources.ResourceManager resourceMan;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(resourceMan, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MetadataToolkit.Properties.Definitions", typeof(Definitions).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = Thread.CurrentThread.CurrentUICulture;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
       
		
		public static string CI_Address_administrativeArea { get { return GetResourceString("CI_Address_administrativeArea"); } }

		public static string CI_Address_city { get { return GetResourceString("CI_Address_city"); } }

		public static string CI_Address_country { get { return GetResourceString("CI_Address_country"); } }

		public static string CI_Address_deliveryPoint { get { return GetResourceString("CI_Address_deliveryPoint"); } }

		public static string CI_Address_electronicMailAddress { get { return GetResourceString("CI_Address_electronicMailAddress"); } }

		public static string CI_Address_postalCode { get { return GetResourceString("CI_Address_postalCode"); } }

		public static string CI_Citation_alternateTitle { get { return GetResourceString("CI_Citation_alternateTitle"); } }

		public static string CI_Citation_citedResponsibleParty { get { return GetResourceString("CI_Citation_citedResponsibleParty"); } }

		public static string CI_Citation_collectiveTitle { get { return GetResourceString("CI_Citation_collectiveTitle"); } }

		public static string CI_Citation_edition { get { return GetResourceString("CI_Citation_edition"); } }

		public static string CI_Citation_editionDate { get { return GetResourceString("CI_Citation_editionDate"); } }

		public static string CI_Citation_identifier { get { return GetResourceString("CI_Citation_identifier"); } }

		public static string CI_Citation_ISBN { get { return GetResourceString("CI_Citation_ISBN"); } }

		public static string CI_Citation_ISSN { get { return GetResourceString("CI_Citation_ISSN"); } }

		public static string CI_Citation_otherCitationDetails { get { return GetResourceString("CI_Citation_otherCitationDetails"); } }

		public static string CI_Citation_presentationForm { get { return GetResourceString("CI_Citation_presentationForm"); } }

		public static string CI_Citation_series { get { return GetResourceString("CI_Citation_series"); } }

		public static string CI_Citation_title { get { return GetResourceString("CI_Citation_title"); } }

		public static string CI_Contact_address { get { return GetResourceString("CI_Contact_address"); } }

		public static string CI_Contact_contactInstructions { get { return GetResourceString("CI_Contact_contactInstructions"); } }

		public static string CI_Contact_hoursOfService { get { return GetResourceString("CI_Contact_hoursOfService"); } }

		public static string CI_Contact_onlineResource { get { return GetResourceString("CI_Contact_onlineResource"); } }

		public static string CI_Contact_phone { get { return GetResourceString("CI_Contact_phone"); } }

		public static string CI_OnlineResource_applicationProfile { get { return GetResourceString("CI_OnlineResource_applicationProfile"); } }

		public static string CI_OnlineResource_description { get { return GetResourceString("CI_OnlineResource_description"); } }

		public static string CI_OnlineResource_function { get { return GetResourceString("CI_OnlineResource_function"); } }

		public static string CI_OnlineResource_linkage { get { return GetResourceString("CI_OnlineResource_linkage"); } }

		public static string CI_OnlineResource_name { get { return GetResourceString("CI_OnlineResource_name"); } }

		public static string CI_OnlineResource_protocol { get { return GetResourceString("CI_OnlineResource_protocol"); } }

		public static string CI_ResponsibleParty_contactInfo { get { return GetResourceString("CI_ResponsibleParty_contactInfo"); } }

		public static string CI_ResponsibleParty_individualName { get { return GetResourceString("CI_ResponsibleParty_individualName"); } }

		public static string CI_ResponsibleParty_organisationName { get { return GetResourceString("CI_ResponsibleParty_organisationName"); } }

		public static string CI_ResponsibleParty_positionName { get { return GetResourceString("CI_ResponsibleParty_positionName"); } }

		public static string CI_ResponsibleParty_role { get { return GetResourceString("CI_ResponsibleParty_role"); } }

		public static string CI_Series_issueIdentification { get { return GetResourceString("CI_Series_issueIdentification"); } }

		public static string CI_Series_name { get { return GetResourceString("CI_Series_name"); } }

		public static string CI_Series_page { get { return GetResourceString("CI_Series_page"); } }

		public static string CI_Telephone_facsimile { get { return GetResourceString("CI_Telephone_facsimile"); } }

		public static string CI_Telephone_voice { get { return GetResourceString("CI_Telephone_voice"); } }

		public static string DQ_ConformanceResult { get { return GetResourceString("DQ_ConformanceResult"); } }

		public static string DQ_ConformanceResult_explanation { get { return GetResourceString("DQ_ConformanceResult_explanation"); } }

		public static string DQ_ConformanceResult_pass { get { return GetResourceString("DQ_ConformanceResult_pass"); } }

		public static string DQ_ConformanceResult_specification { get { return GetResourceString("DQ_ConformanceResult_specification"); } }

		public static string DQ_DataQuality_lineage { get { return GetResourceString("DQ_DataQuality_lineage"); } }

		public static string DQ_DataQuality_report { get { return GetResourceString("DQ_DataQuality_report"); } }

		public static string DQ_DataQuality_scope { get { return GetResourceString("DQ_DataQuality_scope"); } }

		public static string DQ_Element_dateTime { get { return GetResourceString("DQ_Element_dateTime"); } }

		public static string DQ_Element_evaluationMethodDescription { get { return GetResourceString("DQ_Element_evaluationMethodDescription"); } }

		public static string DQ_Element_evaluationMethodType { get { return GetResourceString("DQ_Element_evaluationMethodType"); } }

		public static string DQ_Element_evaluationProcedure { get { return GetResourceString("DQ_Element_evaluationProcedure"); } }

		public static string DQ_Element_measureDescription { get { return GetResourceString("DQ_Element_measureDescription"); } }

		public static string DQ_Element_measureIdentification { get { return GetResourceString("DQ_Element_measureIdentification"); } }

		public static string DQ_Element_nameOfMeasure { get { return GetResourceString("DQ_Element_nameOfMeasure"); } }

		public static string DQ_Element_result { get { return GetResourceString("DQ_Element_result"); } }

		public static string DQ_Element_type { get { return GetResourceString("DQ_Element_type"); } }

		public static string DQ_QuantitativeResult { get { return GetResourceString("DQ_QuantitativeResult"); } }

		public static string DQ_QuantitativeResult_errorStatistic { get { return GetResourceString("DQ_QuantitativeResult_errorStatistic"); } }

		public static string DQ_QuantitativeResult_value { get { return GetResourceString("DQ_QuantitativeResult_value"); } }

		public static string DQ_QuantitativeResult_valueType { get { return GetResourceString("DQ_QuantitativeResult_valueType"); } }

		public static string DQ_QuantitativeResult_valueUnit { get { return GetResourceString("DQ_QuantitativeResult_valueUnit"); } }

		public static string DQ_Scope_extent { get { return GetResourceString("DQ_Scope_extent"); } }

		public static string DQ_Scope_level { get { return GetResourceString("DQ_Scope_level"); } }

		public static string DQ_Scope_levelDescription { get { return GetResourceString("DQ_Scope_levelDescription"); } }

		public static string ESRI_searchTags { get { return GetResourceString("ESRI_searchTags"); } }

		public static string EX_BoundingPolygon { get { return GetResourceString("EX_BoundingPolygon"); } }

		public static string EX_BoundingPolygon_polygon { get { return GetResourceString("EX_BoundingPolygon_polygon"); } }

		public static string EX_Extent_description { get { return GetResourceString("EX_Extent_description"); } }

		public static string EX_Extent_geographicElement { get { return GetResourceString("EX_Extent_geographicElement"); } }

		public static string EX_Extent_temporalElement { get { return GetResourceString("EX_Extent_temporalElement"); } }

		public static string EX_Extent_verticalElement { get { return GetResourceString("EX_Extent_verticalElement"); } }

		public static string EX_GeographicBoundingBox { get { return GetResourceString("EX_GeographicBoundingBox"); } }

		public static string EX_GeographicBoundingBox_eastBoundLongitude { get { return GetResourceString("EX_GeographicBoundingBox_eastBoundLongitude"); } }

		public static string EX_GeographicBoundingBox_northBoundLatitude { get { return GetResourceString("EX_GeographicBoundingBox_northBoundLatitude"); } }

		public static string EX_GeographicBoundingBox_southBoundLatitude { get { return GetResourceString("EX_GeographicBoundingBox_southBoundLatitude"); } }

		public static string EX_GeographicBoundingBox_westBoundLongitude { get { return GetResourceString("EX_GeographicBoundingBox_westBoundLongitude"); } }

		public static string EX_GeographicDescription { get { return GetResourceString("EX_GeographicDescription"); } }

		public static string EX_GeographicDescription_geographicIdentifier { get { return GetResourceString("EX_GeographicDescription_geographicIdentifier"); } }

		public static string EX_GeographicExtent_extentTypeCode { get { return GetResourceString("EX_GeographicExtent_extentTypeCode"); } }

		public static string EX_SpatialTemporalExtent { get { return GetResourceString("EX_SpatialTemporalExtent"); } }

		public static string EX_SpatialTemporalExtent_spatialExtent { get { return GetResourceString("EX_SpatialTemporalExtent_spatialExtent"); } }

		public static string EX_TemporalExtent { get { return GetResourceString("EX_TemporalExtent"); } }

		public static string EX_TemporalExtent_extent { get { return GetResourceString("EX_TemporalExtent_extent"); } }

		public static string EX_VerticalExtent { get { return GetResourceString("EX_VerticalExtent"); } }

		public static string EX_VerticalExtent_maximumValue { get { return GetResourceString("EX_VerticalExtent_maximumValue"); } }

		public static string EX_VerticalExtent_minimumValue { get { return GetResourceString("EX_VerticalExtent_minimumValue"); } }

		public static string LI_Lineage_processStep { get { return GetResourceString("LI_Lineage_processStep"); } }

		public static string LI_Lineage_source { get { return GetResourceString("LI_Lineage_source"); } }

		public static string LI_Lineage_statement { get { return GetResourceString("LI_Lineage_statement"); } }

		public static string LI_ProcessStep_dateTime { get { return GetResourceString("LI_ProcessStep_dateTime"); } }

		public static string LI_ProcessStep_description { get { return GetResourceString("LI_ProcessStep_description"); } }

		public static string LI_ProcessStep_processor { get { return GetResourceString("LI_ProcessStep_processor"); } }

		public static string LI_ProcessStep_rationale { get { return GetResourceString("LI_ProcessStep_rationale"); } }

		public static string LI_ProcessStep_source { get { return GetResourceString("LI_ProcessStep_source"); } }

		public static string LI_Source_description { get { return GetResourceString("LI_Source_description"); } }

		public static string LI_Source_scaleDenominator { get { return GetResourceString("LI_Source_scaleDenominator"); } }

		public static string LI_Source_sourceCitation { get { return GetResourceString("LI_Source_sourceCitation"); } }

		public static string LI_Source_sourceExtent { get { return GetResourceString("LI_Source_sourceExtent"); } }

		public static string LI_Source_sourceReferenceSystem { get { return GetResourceString("LI_Source_sourceReferenceSystem"); } }

		public static string LI_Source_sourceStep { get { return GetResourceString("LI_Source_sourceStep"); } }

		public static string MD_AggregateInformation_aggregateDataSetIdentifier { get { return GetResourceString("MD_AggregateInformation_aggregateDataSetIdentifier"); } }

		public static string MD_AggregateInformation_aggregateDataSetName { get { return GetResourceString("MD_AggregateInformation_aggregateDataSetName"); } }

		public static string MD_AggregateInformation_associationType { get { return GetResourceString("MD_AggregateInformation_associationType"); } }

		public static string MD_AggregateInformation_initiativeType { get { return GetResourceString("MD_AggregateInformation_initiativeType"); } }

		public static string MD_ApplicationSchemaInformation_constraintLanguage { get { return GetResourceString("MD_ApplicationSchemaInformation_constraintLanguage"); } }

		public static string MD_ApplicationSchemaInformation_graphicsFile { get { return GetResourceString("MD_ApplicationSchemaInformation_graphicsFile"); } }

		public static string MD_ApplicationSchemaInformation_name { get { return GetResourceString("MD_ApplicationSchemaInformation_name"); } }

		public static string MD_ApplicationSchemaInformation_schemaAscii { get { return GetResourceString("MD_ApplicationSchemaInformation_schemaAscii"); } }

		public static string MD_ApplicationSchemaInformation_schemaLanguage { get { return GetResourceString("MD_ApplicationSchemaInformation_schemaLanguage"); } }

		public static string MD_ApplicationSchemaInformation_softwareDevelopmenFileFormat { get { return GetResourceString("MD_ApplicationSchemaInformation_softwareDevelopmenFileFormat"); } }

		public static string MD_ApplicationSchemaInformation_softwareDevelopmentFile { get { return GetResourceString("MD_ApplicationSchemaInformation_softwareDevelopmentFile"); } }

		public static string MD_Band { get { return GetResourceString("MD_Band"); } }

		public static string MD_Band_bitsPerValue { get { return GetResourceString("MD_Band_bitsPerValue"); } }

		public static string MD_Band_maxValue { get { return GetResourceString("MD_Band_maxValue"); } }

		public static string MD_Band_minValue { get { return GetResourceString("MD_Band_minValue"); } }

		public static string MD_Band_offset { get { return GetResourceString("MD_Band_offset"); } }

		public static string MD_Band_peakResponse { get { return GetResourceString("MD_Band_peakResponse"); } }

		public static string MD_Band_scaleFactor { get { return GetResourceString("MD_Band_scaleFactor"); } }

		public static string MD_Band_toneGradation { get { return GetResourceString("MD_Band_toneGradation"); } }

		public static string MD_Band_units { get { return GetResourceString("MD_Band_units"); } }

		public static string MD_BrowseGraphic_fileDescription { get { return GetResourceString("MD_BrowseGraphic_fileDescription"); } }

		public static string MD_BrowseGraphic_fileName { get { return GetResourceString("MD_BrowseGraphic_fileName"); } }

		public static string MD_BrowseGraphic_fileType { get { return GetResourceString("MD_BrowseGraphic_fileType"); } }

		public static string MD_Constraints_useLimitation { get { return GetResourceString("MD_Constraints_useLimitation"); } }

		public static string MD_CoverageDescription { get { return GetResourceString("MD_CoverageDescription"); } }

		public static string MD_CoverageDescription_attributeDescription { get { return GetResourceString("MD_CoverageDescription_attributeDescription"); } }

		public static string MD_CoverageDescription_contentType { get { return GetResourceString("MD_CoverageDescription_contentType"); } }

		public static string MD_CoverageDescription_dimension { get { return GetResourceString("MD_CoverageDescription_dimension"); } }

		public static string MD_DataIdentification { get { return GetResourceString("MD_DataIdentification"); } }

		public static string MD_DataIdentification_characterSet { get { return GetResourceString("MD_DataIdentification_characterSet"); } }

		public static string MD_DataIdentification_environmentDescription { get { return GetResourceString("MD_DataIdentification_environmentDescription"); } }

		public static string MD_DataIdentification_extent { get { return GetResourceString("MD_DataIdentification_extent"); } }

		public static string MD_DataIdentification_language { get { return GetResourceString("MD_DataIdentification_language"); } }

		public static string MD_DataIdentification_spatialResolution { get { return GetResourceString("MD_DataIdentification_spatialResolution"); } }

		public static string MD_DataIdentification_supplementInformation { get { return GetResourceString("MD_DataIdentification_supplementInformation"); } }

		public static string MD_DataIdentification_topicCategory { get { return GetResourceString("MD_DataIdentification_topicCategory"); } }

		public static string MD_DigitalTransferOptions_offLine { get { return GetResourceString("MD_DigitalTransferOptions_offLine"); } }

		public static string MD_DigitalTransferOptions_onLine { get { return GetResourceString("MD_DigitalTransferOptions_onLine"); } }

		public static string MD_DigitalTransferOptions_transferSize { get { return GetResourceString("MD_DigitalTransferOptions_transferSize"); } }

		public static string MD_DigitalTransferOptions_unitsOfDistribution { get { return GetResourceString("MD_DigitalTransferOptions_unitsOfDistribution"); } }

		public static string MD_Dimension_dimensionName { get { return GetResourceString("MD_Dimension_dimensionName"); } }

		public static string MD_Dimension_dimensionSize { get { return GetResourceString("MD_Dimension_dimensionSize"); } }

		public static string MD_Dimension_resolution { get { return GetResourceString("MD_Dimension_resolution"); } }

		public static string MD_Distribution_distributionFormat { get { return GetResourceString("MD_Distribution_distributionFormat"); } }

		public static string MD_Distribution_distributor { get { return GetResourceString("MD_Distribution_distributor"); } }

		public static string MD_Distribution_transferOptions { get { return GetResourceString("MD_Distribution_transferOptions"); } }

		public static string MD_Distributor_distributionOrderprocess { get { return GetResourceString("MD_Distributor_distributionOrderprocess"); } }

		public static string MD_Distributor_distributorContact { get { return GetResourceString("MD_Distributor_distributorContact"); } }

		public static string MD_Distributor_distributorFormat { get { return GetResourceString("MD_Distributor_distributorFormat"); } }

		public static string MD_Distributor_distributorTransferOptions { get { return GetResourceString("MD_Distributor_distributorTransferOptions"); } }

		public static string MD_ExtendedElementInformation_condition { get { return GetResourceString("MD_ExtendedElementInformation_condition"); } }

		public static string MD_ExtendedElementInformation_dataType { get { return GetResourceString("MD_ExtendedElementInformation_dataType"); } }

		public static string MD_ExtendedElementInformation_definition { get { return GetResourceString("MD_ExtendedElementInformation_definition"); } }

		public static string MD_ExtendedElementInformation_domainCode { get { return GetResourceString("MD_ExtendedElementInformation_domainCode"); } }

		public static string MD_ExtendedElementInformation_domainValue { get { return GetResourceString("MD_ExtendedElementInformation_domainValue"); } }

		public static string MD_ExtendedElementInformation_maximumOccurrence { get { return GetResourceString("MD_ExtendedElementInformation_maximumOccurrence"); } }

		public static string MD_ExtendedElementInformation_name { get { return GetResourceString("MD_ExtendedElementInformation_name"); } }

		public static string MD_ExtendedElementInformation_obligation { get { return GetResourceString("MD_ExtendedElementInformation_obligation"); } }

		public static string MD_ExtendedElementInformation_parentEntity { get { return GetResourceString("MD_ExtendedElementInformation_parentEntity"); } }

		public static string MD_ExtendedElementInformation_rationale { get { return GetResourceString("MD_ExtendedElementInformation_rationale"); } }

		public static string MD_ExtendedElementInformation_rule { get { return GetResourceString("MD_ExtendedElementInformation_rule"); } }

		public static string MD_ExtendedElementInformation_shortName { get { return GetResourceString("MD_ExtendedElementInformation_shortName"); } }

		public static string MD_FeatureCatalogueDescription { get { return GetResourceString("MD_FeatureCatalogueDescription"); } }

		public static string MD_FeatureCatalogueDescription_complianceCode { get { return GetResourceString("MD_FeatureCatalogueDescription_complianceCode"); } }

		public static string MD_FeatureCatalogueDescription_featureCatalogueCitation { get { return GetResourceString("MD_FeatureCatalogueDescription_featureCatalogueCitation"); } }

		public static string MD_FeatureCatalogueDescription_featureTypes { get { return GetResourceString("MD_FeatureCatalogueDescription_featureTypes"); } }

		public static string MD_FeatureCatalogueDescription_includedWithDataset { get { return GetResourceString("MD_FeatureCatalogueDescription_includedWithDataset"); } }

		public static string MD_FeatureCatalogueDescription_language { get { return GetResourceString("MD_FeatureCatalogueDescription_language"); } }

		public static string MD_Format_amendmentNumber { get { return GetResourceString("MD_Format_amendmentNumber"); } }

		public static string MD_Format_fileDecompressionTechnique { get { return GetResourceString("MD_Format_fileDecompressionTechnique"); } }

		public static string MD_Format_formatDistirbutor { get { return GetResourceString("MD_Format_formatDistirbutor"); } }

		public static string MD_Format_name { get { return GetResourceString("MD_Format_name"); } }

		public static string MD_Format_specification { get { return GetResourceString("MD_Format_specification"); } }

		public static string MD_Format_version { get { return GetResourceString("MD_Format_version"); } }

		public static string MD_GeometricObjects_geometricObjectCount { get { return GetResourceString("MD_GeometricObjects_geometricObjectCount"); } }

		public static string MD_GeometricObjects_geometricObjectType { get { return GetResourceString("MD_GeometricObjects_geometricObjectType"); } }

		public static string MD_Georectified { get { return GetResourceString("MD_Georectified"); } }

		public static string MD_Georectified_centerPoint { get { return GetResourceString("MD_Georectified_centerPoint"); } }

		public static string MD_Georectified_checkPointAvailability { get { return GetResourceString("MD_Georectified_checkPointAvailability"); } }

		public static string MD_Georectified_checkPointDescription { get { return GetResourceString("MD_Georectified_checkPointDescription"); } }

		public static string MD_Georectified_cornerPoints { get { return GetResourceString("MD_Georectified_cornerPoints"); } }

		public static string MD_Georectified_pointInPixel { get { return GetResourceString("MD_Georectified_pointInPixel"); } }

		public static string MD_Georectified_transformationDimensionDescription { get { return GetResourceString("MD_Georectified_transformationDimensionDescription"); } }

		public static string MD_Georectified_transformationDimensionMapping { get { return GetResourceString("MD_Georectified_transformationDimensionMapping"); } }

		public static string MD_Georeferenceable { get { return GetResourceString("MD_Georeferenceable"); } }

		public static string MD_Georeferenceable_controlPointAvailability { get { return GetResourceString("MD_Georeferenceable_controlPointAvailability"); } }

		public static string MD_Georeferenceable_georeferencedParameters { get { return GetResourceString("MD_Georeferenceable_georeferencedParameters"); } }

		public static string MD_Georeferenceable_orientationParameterAvailability { get { return GetResourceString("MD_Georeferenceable_orientationParameterAvailability"); } }

		public static string MD_Georeferenceable_orientationparameterDescription { get { return GetResourceString("MD_Georeferenceable_orientationparameterDescription"); } }

		public static string MD_Georeferenceable_parameterCitation { get { return GetResourceString("MD_Georeferenceable_parameterCitation"); } }

		public static string MD_GridSpatialRepresentation { get { return GetResourceString("MD_GridSpatialRepresentation"); } }

		public static string MD_GridSpatialRepresentation_axisDimensionProperties { get { return GetResourceString("MD_GridSpatialRepresentation_axisDimensionProperties"); } }

		public static string MD_GridSpatialRepresentation_cellGeometry { get { return GetResourceString("MD_GridSpatialRepresentation_cellGeometry"); } }

		public static string MD_GridSpatialRepresentation_numberOfDimensions { get { return GetResourceString("MD_GridSpatialRepresentation_numberOfDimensions"); } }

		public static string MD_GridSpatialRepresentation_transformationParameterAvailability { get { return GetResourceString("MD_GridSpatialRepresentation_transformationParameterAvailability"); } }

		public static string MD_Identification_abstract { get { return GetResourceString("MD_Identification_abstract"); } }

		public static string MD_Identification_aggregationInfo { get { return GetResourceString("MD_Identification_aggregationInfo"); } }

		public static string MD_Identification_citation { get { return GetResourceString("MD_Identification_citation"); } }

		public static string MD_Identification_credit { get { return GetResourceString("MD_Identification_credit"); } }

		public static string MD_Identification_graphicOverview { get { return GetResourceString("MD_Identification_graphicOverview"); } }

		public static string MD_Identification_pointOfContact { get { return GetResourceString("MD_Identification_pointOfContact"); } }

		public static string MD_Identification_purpose { get { return GetResourceString("MD_Identification_purpose"); } }

		public static string MD_Identification_resourceConstraints { get { return GetResourceString("MD_Identification_resourceConstraints"); } }

		public static string MD_Identification_resourceFormat { get { return GetResourceString("MD_Identification_resourceFormat"); } }

		public static string MD_Identification_resourceMaintenance { get { return GetResourceString("MD_Identification_resourceMaintenance"); } }

		public static string MD_Identification_resourceSpecificUsage { get { return GetResourceString("MD_Identification_resourceSpecificUsage"); } }

		public static string MD_DataIdentification_spatialRepresentationType { get { return GetResourceString("MD_DataIdentification_spatialRepresentationType"); } }

		public static string MD_Identification_status { get { return GetResourceString("MD_Identification_status"); } }

		public static string MD_Identifier_authority { get { return GetResourceString("MD_Identifier_authority"); } }

		public static string MD_Identifier_code { get { return GetResourceString("MD_Identifier_code"); } }

		public static string MD_ImageDescription { get { return GetResourceString("MD_ImageDescription"); } }

		public static string MD_ImageDescription_cameraCalibrationInformationAvailability { get { return GetResourceString("MD_ImageDescription_cameraCalibrationInformationAvailability"); } }

		public static string MD_ImageDescription_cloudCoverPercentage { get { return GetResourceString("MD_ImageDescription_cloudCoverPercentage"); } }

		public static string MD_ImageDescription_compressionGenerationQuantity { get { return GetResourceString("MD_ImageDescription_compressionGenerationQuantity"); } }

		public static string MD_ImageDescription_filmDistortionInformationAvailability { get { return GetResourceString("MD_ImageDescription_filmDistortionInformationAvailability"); } }

		public static string MD_ImageDescription_illuminationAzimuthAngle { get { return GetResourceString("MD_ImageDescription_illuminationAzimuthAngle"); } }

		public static string MD_ImageDescription_illuminationElevationAngle { get { return GetResourceString("MD_ImageDescription_illuminationElevationAngle"); } }

		public static string MD_ImageDescription_imageQualityCode { get { return GetResourceString("MD_ImageDescription_imageQualityCode"); } }

		public static string MD_ImageDescription_imagingCondition { get { return GetResourceString("MD_ImageDescription_imagingCondition"); } }

		public static string MD_ImageDescription_lensDistortionInformationAvailability { get { return GetResourceString("MD_ImageDescription_lensDistortionInformationAvailability"); } }

		public static string MD_ImageDescription_processingLevelCode { get { return GetResourceString("MD_ImageDescription_processingLevelCode"); } }

		public static string MD_ImageDescription_radiometricCalibrationDataAvailability { get { return GetResourceString("MD_ImageDescription_radiometricCalibrationDataAvailability"); } }

		public static string MD_ImageDescription_triangulationIndicator { get { return GetResourceString("MD_ImageDescription_triangulationIndicator"); } }

		public static string MD_Keywords_discipline { get { return GetResourceString("MD_Keywords_discipline"); } }

		public static string MD_Keywords_keyword { get { return GetResourceString("MD_Keywords_keyword"); } }

		public static string MD_Keywords_other { get { return GetResourceString("MD_Keywords_other"); } }

		public static string MD_Keywords_place { get { return GetResourceString("MD_Keywords_place"); } }

		public static string MD_Keywords_stratum { get { return GetResourceString("MD_Keywords_stratum"); } }

		public static string MD_Keywords_temporal { get { return GetResourceString("MD_Keywords_temporal"); } }

		public static string MD_Keywords_theme { get { return GetResourceString("MD_Keywords_theme"); } }

		public static string MD_Keywords_thesaurusName { get { return GetResourceString("MD_Keywords_thesaurusName"); } }

		public static string MD_LegalConstraints_accessConstraints { get { return GetResourceString("MD_LegalConstraints_accessConstraints"); } }

		public static string MD_LegalConstraints_otherConstraints { get { return GetResourceString("MD_LegalConstraints_otherConstraints"); } }

		public static string MD_LegalConstraints_useConstraints { get { return GetResourceString("MD_LegalConstraints_useConstraints"); } }

		public static string MD_MaintenanceInformation_contact { get { return GetResourceString("MD_MaintenanceInformation_contact"); } }

		public static string MD_MaintenanceInformation_dateOfNextUpdate { get { return GetResourceString("MD_MaintenanceInformation_dateOfNextUpdate"); } }

		public static string MD_MaintenanceInformation_maintenanceAndUpdateFrequency { get { return GetResourceString("MD_MaintenanceInformation_maintenanceAndUpdateFrequency"); } }

		public static string MD_MaintenanceInformation_maintenanceNote { get { return GetResourceString("MD_MaintenanceInformation_maintenanceNote"); } }

		public static string MD_MaintenanceInformation_updateScope { get { return GetResourceString("MD_MaintenanceInformation_updateScope"); } }

		public static string MD_MaintenanceInformation_updateScopeDescription { get { return GetResourceString("MD_MaintenanceInformation_updateScopeDescription"); } }

		public static string MD_MaintenanceInformation_userDefinedMaintenanceFrequency { get { return GetResourceString("MD_MaintenanceInformation_userDefinedMaintenanceFrequency"); } }

		public static string MD_Medium_density { get { return GetResourceString("MD_Medium_density"); } }

		public static string MD_Medium_densityUnits { get { return GetResourceString("MD_Medium_densityUnits"); } }

		public static string MD_Medium_mediumFormat { get { return GetResourceString("MD_Medium_mediumFormat"); } }

		public static string MD_Medium_mediumNote { get { return GetResourceString("MD_Medium_mediumNote"); } }

		public static string MD_Medium_name { get { return GetResourceString("MD_Medium_name"); } }

		public static string MD_Medium_volumes { get { return GetResourceString("MD_Medium_volumes"); } }

		public static string MD_Metadata { get { return GetResourceString("MD_Metadata"); } }

		public static string MD_MetadataExtensionInformation_extendedElementInformation { get { return GetResourceString("MD_MetadataExtensionInformation_extendedElementInformation"); } }

		public static string MD_MetadataExtensionInformation_extensionOnLineResource { get { return GetResourceString("MD_MetadataExtensionInformation_extensionOnLineResource"); } }

		public static string MD_Metadata_applicationSchemaInfo { get { return GetResourceString("MD_Metadata_applicationSchemaInfo"); } }

		public static string MD_Metadata_characterSet { get { return GetResourceString("MD_Metadata_characterSet"); } }

		public static string MD_Metadata_contact { get { return GetResourceString("MD_Metadata_contact"); } }

		public static string MD_Metadata_contentInfo { get { return GetResourceString("MD_Metadata_contentInfo"); } }

		public static string MD_Metadata_dataQualityInfo { get { return GetResourceString("MD_Metadata_dataQualityInfo"); } }

		public static string MD_Metadata_dataSetURI { get { return GetResourceString("MD_Metadata_dataSetURI"); } }

		public static string MD_Metadata_dateStamp { get { return GetResourceString("MD_Metadata_dateStamp"); } }

		public static string MD_Metadata_distributionInfo { get { return GetResourceString("MD_Metadata_distributionInfo"); } }

		public static string MD_Metadata_fileIdentifier { get { return GetResourceString("MD_Metadata_fileIdentifier"); } }

		public static string MD_Metadata_hierarchyLevel { get { return GetResourceString("MD_Metadata_hierarchyLevel"); } }

		public static string MD_Metadata_hierarchyLevelName { get { return GetResourceString("MD_Metadata_hierarchyLevelName"); } }

		public static string MD_Metadata_language { get { return GetResourceString("MD_Metadata_language"); } }

		public static string MD_Metadata_metadataConstraints { get { return GetResourceString("MD_Metadata_metadataConstraints"); } }

		public static string MD_Metadata_metadataExtensionInfo { get { return GetResourceString("MD_Metadata_metadataExtensionInfo"); } }

		public static string MD_Metadata_metadataMaintenance { get { return GetResourceString("MD_Metadata_metadataMaintenance"); } }

		public static string MD_Metadata_metadataStandardName { get { return GetResourceString("MD_Metadata_metadataStandardName"); } }

		public static string MD_Metadata_metadataStandardVersion { get { return GetResourceString("MD_Metadata_metadataStandardVersion"); } }

		public static string MD_Metadata_parentIdentifier { get { return GetResourceString("MD_Metadata_parentIdentifier"); } }

		public static string MD_Metadata_portrayalCatalogueInfo { get { return GetResourceString("MD_Metadata_portrayalCatalogueInfo"); } }

		public static string MD_Metadata_referenceSystemInfo { get { return GetResourceString("MD_Metadata_referenceSystemInfo"); } }

		public static string MD_Metadata_spatialRepresentationInfo { get { return GetResourceString("MD_Metadata_spatialRepresentationInfo"); } }

		public static string MD_PortrayalCatalogueReference_portrayalCatalogueCitation { get { return GetResourceString("MD_PortrayalCatalogueReference_portrayalCatalogueCitation"); } }

		public static string MD_RangeDimension { get { return GetResourceString("MD_RangeDimension"); } }

		public static string MD_RangeDimensions_descriptor { get { return GetResourceString("MD_RangeDimensions_descriptor"); } }

		public static string MD_RangeDimension_sequenceIdentifier { get { return GetResourceString("MD_RangeDimension_sequenceIdentifier"); } }

		public static string MD_ReferenceSystem_referenceSystemIdentifier { get { return GetResourceString("MD_ReferenceSystem_referenceSystemIdentifier"); } }

		public static string MD_RepresentativeFraction_denominator { get { return GetResourceString("MD_RepresentativeFraction_denominator"); } }

		public static string MD_Resolution_distance { get { return GetResourceString("MD_Resolution_distance"); } }

		public static string MD_Resolution_equivalentScale { get { return GetResourceString("MD_Resolution_equivalentScale"); } }

		public static string MD_ScopeDescription_attributeInstances { get { return GetResourceString("MD_ScopeDescription_attributeInstances"); } }

		public static string MD_ScopeDescription_attributes { get { return GetResourceString("MD_ScopeDescription_attributes"); } }

		public static string MD_ScopeDescription_dataset { get { return GetResourceString("MD_ScopeDescription_dataset"); } }

		public static string MD_ScopeDescription_featureInstances { get { return GetResourceString("MD_ScopeDescription_featureInstances"); } }

		public static string MD_ScopeDescription_features { get { return GetResourceString("MD_ScopeDescription_features"); } }

		public static string MD_ScopeDescription_other { get { return GetResourceString("MD_ScopeDescription_other"); } }

		public static string MD_SecurityConstraints_classification { get { return GetResourceString("MD_SecurityConstraints_classification"); } }

		public static string MD_SecurityConstraints_classificationSystem { get { return GetResourceString("MD_SecurityConstraints_classificationSystem"); } }

		public static string MD_SecurityConstraints_handlingDescription { get { return GetResourceString("MD_SecurityConstraints_handlingDescription"); } }

		public static string MD_SecurityConstraints_userNote { get { return GetResourceString("MD_SecurityConstraints_userNote"); } }

		public static string MD_StandardOrderProcess_fees { get { return GetResourceString("MD_StandardOrderProcess_fees"); } }

		public static string MD_StandardOrderProcess_orderingInstructions { get { return GetResourceString("MD_StandardOrderProcess_orderingInstructions"); } }

		public static string MD_StandardOrderProcess_plannedAvailableDateTime { get { return GetResourceString("MD_StandardOrderProcess_plannedAvailableDateTime"); } }

		public static string MD_StandardOrderProcess_turnaround { get { return GetResourceString("MD_StandardOrderProcess_turnaround"); } }

		public static string MD_Usage_specificUsage { get { return GetResourceString("MD_Usage_specificUsage"); } }

		public static string MD_Usage_usageDateTime { get { return GetResourceString("MD_Usage_usageDateTime"); } }

		public static string MD_Usage_userContactInfo { get { return GetResourceString("MD_Usage_userContactInfo"); } }

		public static string MD_Usage_userDeterminedLimitations { get { return GetResourceString("MD_Usage_userDeterminedLimitations"); } }

		public static string MD_VectorSpatialRepresentation { get { return GetResourceString("MD_VectorSpatialRepresentation"); } }

		public static string MD_VectorSpatialRepresentation_geometricObjects { get { return GetResourceString("MD_VectorSpatialRepresentation_geometricObjects"); } }

		public static string MD_VectorSpatialRepresentation_topologyLevel { get { return GetResourceString("MD_VectorSpatialRepresentation_topologyLevel"); } }

		public static string RS_Identifier_codeSpace { get { return GetResourceString("RS_Identifier_codeSpace"); } }

		public static string RS_Identifier_version { get { return GetResourceString("RS_Identifier_version"); } }

		public static string SV_ServiceIdentification { get { return GetResourceString("SV_ServiceIdentification"); } }

		public static string MD_Metadata_locale { get { return GetResourceString("MD_Metadata_locale"); } }

		public static string MD_ExtendedElementInformation_source { get { return GetResourceString("MD_ExtendedElementInformation_source"); } }

		public static string CI_Date_creationDate { get { return GetResourceString("CI_Date_creationDate"); } }

		public static string CI_Date_publicationDate { get { return GetResourceString("CI_Date_publicationDate"); } }

		public static string CI_Date_revisionDate { get { return GetResourceString("CI_Date_revisionDate"); } }

		public static string ESRI_thumbnail { get { return GetResourceString("ESRI_thumbnail"); } }

		public static string ESRI_tool_codeSample_code { get { return GetResourceString("ESRI_tool_codeSample_code"); } }

		public static string ESRI_tool_codeSample_description { get { return GetResourceString("ESRI_tool_codeSample_description"); } }

		public static string ESRI_tool_codeSample_title { get { return GetResourceString("ESRI_tool_codeSample_title"); } }

		public static string ESRI_tool_parameter_dialogExplanation { get { return GetResourceString("ESRI_tool_parameter_dialogExplanation"); } }

		public static string ESRI_tool_parameter_pythonExplanation { get { return GetResourceString("ESRI_tool_parameter_pythonExplanation"); } }

		public static string ESRI_tool_usage { get { return GetResourceString("ESRI_tool_usage"); } }

		public static string CI_Date_NAP_adopted { get { return GetResourceString("CI_Date_NAP_adopted"); } }

		public static string CI_Date_NAP_deprecated { get { return GetResourceString("CI_Date_NAP_deprecated"); } }

		public static string CI_Date_NAP_inForce { get { return GetResourceString("CI_Date_NAP_inForce"); } }

		public static string CI_Date_NAP_notAvailable { get { return GetResourceString("CI_Date_NAP_notAvailable"); } }

		public static string CI_Date_NAP_superseded { get { return GetResourceString("CI_Date_NAP_superseded"); } }

		public static string MD_Keywords_NAP_product { get { return GetResourceString("MD_Keywords_NAP_product"); } }

		public static string MD_Keywords_NAP_subtopic { get { return GetResourceString("MD_Keywords_NAP_subtopic"); } }

		public static string DQ_DataQuality_reportDimension { get { return GetResourceString("DQ_DataQuality_reportDimension"); } }

		public static string DQ_DataQuality_reportType { get { return GetResourceString("DQ_DataQuality_reportType"); } }

		public static string ESRI_exportContentTypeToFGDC { get { return GetResourceString("ESRI_exportContentTypeToFGDC"); } }

		public static string ESRI_geoportalContentType { get { return GetResourceString("ESRI_geoportalContentType"); } }

		public static string ESRI_geoprocessingHistory_export { get { return GetResourceString("ESRI_geoprocessingHistory_export"); } }

		public static string ESRI_scaleRange { get { return GetResourceString("ESRI_scaleRange"); } }

		public static string ESRI_scaleRangeMaximum { get { return GetResourceString("ESRI_scaleRangeMaximum"); } }

		public static string ESRI_scaleRangeMinimum { get { return GetResourceString("ESRI_scaleRangeMinimum"); } }

		public static string EX_TemporalExtent_beginTimePeriod { get { return GetResourceString("EX_TemporalExtent_beginTimePeriod"); } }

		public static string EX_TemporalExtent_endTimePeriod { get { return GetResourceString("EX_TemporalExtent_endTimePeriod"); } }

		public static string EX_TemporalExtent_timeInstant { get { return GetResourceString("EX_TemporalExtent_timeInstant"); } }

		public static string FGDC_Citation_geoform { get { return GetResourceString("FGDC_Citation_geoform"); } }

		public static string FGDC_Contact_addrtype { get { return GetResourceString("FGDC_Contact_addrtype"); } }

		public static string FGDC_Contact_tddtty { get { return GetResourceString("FGDC_Contact_tddtty"); } }

		public static string FGDC_Distribution_availabl_beginTimePeriod { get { return GetResourceString("FGDC_Distribution_availabl_beginTimePeriod"); } }

		public static string FGDC_Distribution_availabl_endTimePeriod { get { return GetResourceString("FGDC_Distribution_availabl_endTimePeriod"); } }

		public static string FGDC_Distribution_formcont { get { return GetResourceString("FGDC_Distribution_formcont"); } }

		public static string FGDC_EntityAndAttribute_atindex { get { return GetResourceString("FGDC_EntityAndAttribute_atindex"); } }

		public static string FGDC_EntityAndAttribute_atprecis { get { return GetResourceString("FGDC_EntityAndAttribute_atprecis"); } }

		public static string FGDC_EntityAndAttribute_attalias { get { return GetResourceString("FGDC_EntityAndAttribute_attalias"); } }

		public static string FGDC_EntityAndAttribute_attrdef { get { return GetResourceString("FGDC_EntityAndAttribute_attrdef"); } }

		public static string FGDC_EntityAndAttribute_attrdefs { get { return GetResourceString("FGDC_EntityAndAttribute_attrdefs"); } }

		public static string FGDC_EntityAndAttribute_attrlabl { get { return GetResourceString("FGDC_EntityAndAttribute_attrlabl"); } }

		public static string FGDC_EntityAndAttribute_attrmfrq { get { return GetResourceString("FGDC_EntityAndAttribute_attrmfrq"); } }

		public static string FGDC_EntityAndAttribute_attrtype { get { return GetResourceString("FGDC_EntityAndAttribute_attrtype"); } }

		public static string FGDC_EntityAndAttribute_attrva { get { return GetResourceString("FGDC_EntityAndAttribute_attrva"); } }

		public static string FGDC_EntityAndAttribute_attrvae { get { return GetResourceString("FGDC_EntityAndAttribute_attrvae"); } }

		public static string FGDC_EntityAndAttribute_attscale { get { return GetResourceString("FGDC_EntityAndAttribute_attscale"); } }

		public static string FGDC_EntityAndAttribute_attwidth { get { return GetResourceString("FGDC_EntityAndAttribute_attwidth"); } }

		public static string FGDC_EntityAndAttribute_begdatea { get { return GetResourceString("FGDC_EntityAndAttribute_begdatea"); } }

		public static string FGDC_EntityAndAttribute_codesetn { get { return GetResourceString("FGDC_EntityAndAttribute_codesetn"); } }

		public static string FGDC_EntityAndAttribute_codesets { get { return GetResourceString("FGDC_EntityAndAttribute_codesets"); } }

		public static string FGDC_EntityAndAttribute_eadetcit { get { return GetResourceString("FGDC_EntityAndAttribute_eadetcit"); } }

		public static string FGDC_EntityAndAttribute_eaover { get { return GetResourceString("FGDC_EntityAndAttribute_eaover"); } }

		public static string FGDC_EntityAndAttribute_edomv { get { return GetResourceString("FGDC_EntityAndAttribute_edomv"); } }

		public static string FGDC_EntityAndAttribute_edomvd { get { return GetResourceString("FGDC_EntityAndAttribute_edomvd"); } }

		public static string FGDC_EntityAndAttribute_edomvds { get { return GetResourceString("FGDC_EntityAndAttribute_edomvds"); } }

		public static string FGDC_EntityAndAttribute_enddatea { get { return GetResourceString("FGDC_EntityAndAttribute_enddatea"); } }

		public static string FGDC_EntityAndAttribute_enttypc { get { return GetResourceString("FGDC_EntityAndAttribute_enttypc"); } }

		public static string FGDC_EntityAndAttribute_enttypd { get { return GetResourceString("FGDC_EntityAndAttribute_enttypd"); } }

		public static string FGDC_EntityAndAttribute_enttypds { get { return GetResourceString("FGDC_EntityAndAttribute_enttypds"); } }

		public static string FGDC_EntityAndAttribute_enttypl { get { return GetResourceString("FGDC_EntityAndAttribute_enttypl"); } }

		public static string FGDC_EntityAndAttribute_enttypt { get { return GetResourceString("FGDC_EntityAndAttribute_enttypt"); } }

		public static string FGDC_EntityAndAttribute_rdommax { get { return GetResourceString("FGDC_EntityAndAttribute_rdommax"); } }

		public static string FGDC_EntityAndAttribute_rdommean { get { return GetResourceString("FGDC_EntityAndAttribute_rdommean"); } }

		public static string FGDC_EntityAndAttribute_rdommin { get { return GetResourceString("FGDC_EntityAndAttribute_rdommin"); } }

		public static string FGDC_EntityAndAttribute_rdommres { get { return GetResourceString("FGDC_EntityAndAttribute_rdommres"); } }

		public static string FGDC_EntityAndAttribute_rdomstdv { get { return GetResourceString("FGDC_EntityAndAttribute_rdomstdv"); } }

		public static string FGDC_EntityAndAttribute_rdomunit { get { return GetResourceString("FGDC_EntityAndAttribute_rdomunit"); } }

		public static string FGDC_EntityAndAttribute_udom { get { return GetResourceString("FGDC_EntityAndAttribute_udom"); } }

		public static string FGDC_SpatialDataOrganization_indspref { get { return GetResourceString("FGDC_SpatialDataOrganization_indspref"); } }

		public static string GCO_Binary_href { get { return GetResourceString("GCO_Binary_href"); } }

		public static string GML_description { get { return GetResourceString("GML_description"); } }

		public static string GML_descriptionReference { get { return GetResourceString("GML_descriptionReference"); } }

		public static string GML_identifier { get { return GetResourceString("GML_identifier"); } }

		public static string GML_identifierCodespace { get { return GetResourceString("GML_identifierCodespace"); } }

		public static string LI_ProcessStep_sourceType { get { return GetResourceString("LI_ProcessStep_sourceType"); } }

		public static string MD_Dimension_resolutionUnits { get { return GetResourceString("MD_Dimension_resolutionUnits"); } }

		public static string MD_FeatureCatalogueDescription_featureTypeCodespace { get { return GetResourceString("MD_FeatureCatalogueDescription_featureTypeCodespace"); } }

		public static string MD_RangeDimension_sequenceIdentifierType { get { return GetResourceString("MD_RangeDimension_sequenceIdentifierType"); } }

		public static string MD_Resolution_distance_units { get { return GetResourceString("MD_Resolution_distance_units"); } }

		public static string MD_StandardOrderProcess_feesCurrency { get { return GetResourceString("MD_StandardOrderProcess_feesCurrency"); } }

		public static string NAP_Metadata_DatasetURI_Function { get { return GetResourceString("NAP_Metadata_DatasetURI_Function"); } }

		public static string PT_Locale_country { get { return GetResourceString("PT_Locale_country"); } }

		public static string PT_Locale_language { get { return GetResourceString("PT_Locale_language"); } }

		public static string SV_CoupledResource_operationName { get { return GetResourceString("SV_CoupledResource_operationName"); } }

		public static string SV_CoupledResource_resourceIdentifier { get { return GetResourceString("SV_CoupledResource_resourceIdentifier"); } }

		public static string SV_IdentificationInfo_couplingType { get { return GetResourceString("SV_IdentificationInfo_couplingType"); } }

		public static string SV_IdentificationInfo_serviceType { get { return GetResourceString("SV_IdentificationInfo_serviceType"); } }

		public static string SV_IdentificationInfo_serviceTypeCodelist { get { return GetResourceString("SV_IdentificationInfo_serviceTypeCodelist"); } }

		public static string SV_IdentificationInfo_serviceTypeVersion { get { return GetResourceString("SV_IdentificationInfo_serviceTypeVersion"); } }

		public static string GenericName_codeSpace { get { return GetResourceString("GenericName_codeSpace"); } }
	}
	internal class Issues
	{
        private static global::System.Resources.ResourceManager resourceMan;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(resourceMan, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MetadataToolkit.Properties.Issues", typeof(Issues).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = Thread.CurrentThread.CurrentUICulture;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
       
		
		public static string attDesc_REQ { get { return GetResourceString("attDesc_REQ"); } }

		public static string attrdefs_REQ { get { return GetResourceString("attrdefs_REQ"); } }

		public static string attrdef_REQ { get { return GetResourceString("attrdef_REQ"); } }

		public static string attrdomv_REQ { get { return GetResourceString("attrdomv_REQ"); } }

		public static string attrlabl_REQ { get { return GetResourceString("attrlabl_REQ"); } }

		public static string attrtype_REQ { get { return GetResourceString("attrtype_REQ"); } }

		public static string attwidth_REQ { get { return GetResourceString("attwidth_REQ"); } }

		public static string bgFileName_REQ { get { return GetResourceString("bgFileName_REQ"); } }

		public static string cellGeo_REQ { get { return GetResourceString("cellGeo_REQ"); } }

		public static string codesetn_REQ { get { return GetResourceString("codesetn_REQ"); } }

		public static string codesets_REQ { get { return GetResourceString("codesets_REQ"); } }

		public static string conExpl_REQ { get { return GetResourceString("conExpl_REQ"); } }

		public static string ContentTypCd_REQ { get { return GetResourceString("ContentTypCd_REQ"); } }

		public static string dates_REQ { get { return GetResourceString("dates_REQ"); } }

		public static string dimSize_REQ { get { return GetResourceString("dimSize_REQ"); } }

		public static string DimType_REQ { get { return GetResourceString("DimType_REQ"); } }

		public static string disciplineKeywords_REQ { get { return GetResourceString("disciplineKeywords_REQ"); } }

		public static string edomvds_REQ { get { return GetResourceString("edomvds_REQ"); } }

		public static string edomvd_REQ { get { return GetResourceString("edomvd_REQ"); } }

		public static string edomv_REQ { get { return GetResourceString("edomv_REQ"); } }

		public static string enttypds_REQ { get { return GetResourceString("enttypds_REQ"); } }

		public static string enttypd_REQ { get { return GetResourceString("enttypd_REQ"); } }

		public static string enttypl_REQ { get { return GetResourceString("enttypl_REQ"); } }

		public static string formatName_REQ { get { return GetResourceString("formatName_REQ"); } }

		public static string formatVer_REQ { get { return GetResourceString("formatVer_REQ"); } }

		public static string geoObjCnt_INTEGER { get { return GetResourceString("geoObjCnt_INTEGER"); } }

		public static string GeoObjTypCd_REQ { get { return GetResourceString("GeoObjTypCd_REQ"); } }

		public static string idAbs_REQ { get { return GetResourceString("idAbs_REQ"); } }

		public static string identCode_REQ { get { return GetResourceString("identCode_REQ"); } }

		public static string INTEGER_REQ { get { return GetResourceString("INTEGER_REQ"); } }

		public static string LAT_COORD_REQ { get { return GetResourceString("LAT_COORD_REQ"); } }

		public static string linkage_REQ { get { return GetResourceString("linkage_REQ"); } }

		public static string LON_COORD_REQ { get { return GetResourceString("LON_COORD_REQ"); } }

		public static string maintFreq_REQ { get { return GetResourceString("maintFreq_REQ"); } }

		public static string maintScp_REQ { get { return GetResourceString("maintScp_REQ"); } }

		public static string metadataContact_REQ { get { return GetResourceString("metadataContact_REQ"); } }

		public static string MinMaxVal_REQ { get { return GetResourceString("MinMaxVal_REQ"); } }

		public static string numDims_REQ { get { return GetResourceString("numDims_REQ"); } }

		public static string otherKeywords_REQ { get { return GetResourceString("otherKeywords_REQ"); } }

		public static string party_REQ { get { return GetResourceString("party_REQ"); } }

		public static string placeKeywords_REQ { get { return GetResourceString("placeKeywords_REQ"); } }

		public static string productKeywords_REQ { get { return GetResourceString("productKeywords_REQ"); } }

		public static string ptInPixel_REQ { get { return GetResourceString("ptInPixel_REQ"); } }

		public static string rdommax_REQ { get { return GetResourceString("rdommax_REQ"); } }

		public static string rdommin_REQ { get { return GetResourceString("rdommin_REQ"); } }

		public static string refSysID_REQ { get { return GetResourceString("refSysID_REQ"); } }

		public static string ReportType_REQ { get { return GetResourceString("ReportType_REQ"); } }

		public static string resTitle_REQ { get { return GetResourceString("resTitle_REQ"); } }

		public static string role_REQ { get { return GetResourceString("role_REQ"); } }

		public static string scriptTitle_REQ { get { return GetResourceString("scriptTitle_REQ"); } }

		public static string specUsage_REQ { get { return GetResourceString("specUsage_REQ"); } }

		public static string stepDesc_REQ { get { return GetResourceString("stepDesc_REQ"); } }

		public static string stratumKeywords_REQ { get { return GetResourceString("stratumKeywords_REQ"); } }

		public static string temporalKeywords_REQ { get { return GetResourceString("temporalKeywords_REQ"); } }

		public static string themeKeywords_REQ { get { return GetResourceString("themeKeywords_REQ"); } }

		public static string topics_REQ { get { return GetResourceString("topics_REQ"); } }

		public static string valUnit_REQ { get { return GetResourceString("valUnit_REQ"); } }

		public static string atprecis_INTEGER { get { return GetResourceString("atprecis_INTEGER"); } }

		public static string attrmres_REAL { get { return GetResourceString("attrmres_REAL"); } }

		public static string attrva_REAL { get { return GetResourceString("attrva_REAL"); } }

		public static string attscale_INTEGER { get { return GetResourceString("attscale_INTEGER"); } }

		public static string attwidth_INTEGER { get { return GetResourceString("attwidth_INTEGER"); } }

		public static string bitsPerVal_INTEGER { get { return GetResourceString("bitsPerVal_INTEGER"); } }

		public static string dimSize_INTEGER { get { return GetResourceString("dimSize_INTEGER"); } }

		public static string maxVal_REAL { get { return GetResourceString("maxVal_REAL"); } }

		public static string medVol_INTEGER { get { return GetResourceString("medVol_INTEGER"); } }

		public static string minVal_REAL { get { return GetResourceString("minVal_REAL"); } }

		public static string numDims_INTEGER { get { return GetResourceString("numDims_INTEGER"); } }

		public static string offset_REAL { get { return GetResourceString("offset_REAL"); } }

		public static string pkResp_REAL { get { return GetResourceString("pkResp_REAL"); } }

		public static string rfDenom_INTEGER { get { return GetResourceString("rfDenom_INTEGER"); } }

		public static string sclFac_REAL { get { return GetResourceString("sclFac_REAL"); } }

		public static string toneGrad_INTEGER { get { return GetResourceString("toneGrad_INTEGER"); } }

		public static string transSize_REAL { get { return GetResourceString("transSize_REAL"); } }

		public static string ValueUoMUnits_REQ { get { return GetResourceString("ValueUoMUnits_REQ"); } }

		public static string ValueUOM_Real { get { return GetResourceString("ValueUOM_Real"); } }

		public static string rdommax_REAL { get { return GetResourceString("rdommax_REAL"); } }

		public static string rdommean_REAL { get { return GetResourceString("rdommean_REAL"); } }

		public static string rdommin_REAL { get { return GetResourceString("rdommin_REAL"); } }

		public static string rdomstdv_REAL { get { return GetResourceString("rdomstdv_REAL"); } }

		public static string vertMaxVal_REAL { get { return GetResourceString("vertMaxVal_REAL"); } }

		public static string vertMaxVal_REQ { get { return GetResourceString("vertMaxVal_REQ"); } }

		public static string vertMinVal_REAL { get { return GetResourceString("vertMinVal_REAL"); } }

		public static string vertMinVal_REQ { get { return GetResourceString("vertMinVal_REQ"); } }

		public static string geoObjCnt_REQ { get { return GetResourceString("geoObjCnt_REQ"); } }

		public static string language_REQ { get { return GetResourceString("language_REQ"); } }

		public static string extent_coord_REQ { get { return GetResourceString("extent_coord_REQ"); } }

		public static string extent_latBoundsError { get { return GetResourceString("extent_latBoundsError"); } }

		public static string extent_lonBoundsError { get { return GetResourceString("extent_lonBoundsError"); } }

		public static string band_minMaxBoundsError { get { return GetResourceString("band_minMaxBoundsError"); } }

		public static string ClasscationCd_REQ { get { return GetResourceString("ClasscationCd_REQ"); } }

		public static string conPass_REQ { get { return GetResourceString("conPass_REQ"); } }

		public static string conSpec_REQ { get { return GetResourceString("conSpec_REQ"); } }

		public static string DQDomConsis_Report_REQ { get { return GetResourceString("DQDomConsis_Report_REQ"); } }

		public static string DQDomConsis_REQ { get { return GetResourceString("DQDomConsis_REQ"); } }

		public static string dq_dataset_REQ { get { return GetResourceString("dq_dataset_REQ"); } }

		public static string dq_report_REQ { get { return GetResourceString("dq_report_REQ"); } }

		public static string eMailAdd_REQ { get { return GetResourceString("eMailAdd_REQ"); } }

		public static string OrgName_REQ { get { return GetResourceString("OrgName_REQ"); } }

		public static string othConsts_REQ { get { return GetResourceString("othConsts_REQ"); } }

		public static string quanVal_REQ { get { return GetResourceString("quanVal_REQ"); } }

		public static string rdomain_minMaxError { get { return GetResourceString("rdomain_minMaxError"); } }

		public static string RefSystem_dimension_REQ { get { return GetResourceString("RefSystem_dimension_REQ"); } }

		public static string RefSystem_REQ { get { return GetResourceString("RefSystem_REQ"); } }

		public static string resConst_REQ { get { return GetResourceString("resConst_REQ"); } }

		public static string scpLvlDesc_REQ { get { return GetResourceString("scpLvlDesc_REQ"); } }

		public static string UOM_REQ { get { return GetResourceString("UOM_REQ"); } }

		public static string useLimit_REQ { get { return GetResourceString("useLimit_REQ"); } }

		public static string protocol_REQ { get { return GetResourceString("protocol_REQ"); } }

		public static string role_POC_REQ { get { return GetResourceString("role_POC_REQ"); } }

		public static string rpCntInfo_NAP_REQ { get { return GetResourceString("rpCntInfo_NAP_REQ"); } }

		public static string rpOrgName_REQ { get { return GetResourceString("rpOrgName_REQ"); } }

		public static string countryCode_REQ { get { return GetResourceString("countryCode_REQ"); } }

		public static string languageCode_EU_REQ { get { return GetResourceString("languageCode_EU_REQ"); } }

		public static string languageCode_REQ { get { return GetResourceString("languageCode_REQ"); } }

		public static string mdChar_REQ { get { return GetResourceString("mdChar_REQ"); } }

		public static string mdDateSt_REQ { get { return GetResourceString("mdDateSt_REQ"); } }

		public static string mdFileID_REQ { get { return GetResourceString("mdFileID_REQ"); } }

		public static string mdHrLvName_REQ { get { return GetResourceString("mdHrLvName_REQ"); } }

		public static string mdHrLv_REQ { get { return GetResourceString("mdHrLv_REQ"); } }

		public static string idPurp_REQ { get { return GetResourceString("idPurp_REQ"); } }

		public static string toolSummary_REQ { get { return GetResourceString("toolSummary_REQ"); } }

		public static string dataLineage_REQ { get { return GetResourceString("dataLineage_REQ"); } }

		public static string dataSource_NAP_REQ { get { return GetResourceString("dataSource_NAP_REQ"); } }

		public static string dataSource_REQ { get { return GetResourceString("dataSource_REQ"); } }

		public static string dqInfo_REQ { get { return GetResourceString("dqInfo_REQ"); } }

		public static string dqScope_INSPIRE_REQ { get { return GetResourceString("dqScope_INSPIRE_REQ"); } }

		public static string dqStatement_INSPIRE_REQ { get { return GetResourceString("dqStatement_INSPIRE_REQ"); } }

		public static string srcDesc_REQ { get { return GetResourceString("srcDesc_REQ"); } }

		public static string extent_dataExtGeoBndBoxReq { get { return GetResourceString("extent_dataExtGeoBndBoxReq"); } }

		public static string extent_dataExtService_REQ { get { return GetResourceString("extent_dataExtService_REQ"); } }

		public static string extent_dataExt_NAP_REQ { get { return GetResourceString("extent_dataExt_NAP_REQ"); } }

		public static string extent_dataExt_REQ { get { return GetResourceString("extent_dataExt_REQ"); } }

		public static string searchKeys_REQ { get { return GetResourceString("searchKeys_REQ"); } }

		public static string AZIM_ANGLE_BND { get { return GetResourceString("AZIM_ANGLE_BND"); } }

		public static string CLOUDCOVER_PER { get { return GetResourceString("CLOUDCOVER_PER"); } }

		public static string CouplTypCd_REQ { get { return GetResourceString("CouplTypCd_REQ"); } }

		public static string ELEV_ANGLE_BND { get { return GetResourceString("ELEV_ANGLE_BND"); } }

		public static string rpCntInfo_incWithDS { get { return GetResourceString("rpCntInfo_incWithDS"); } }

		public static string seqID_REQ { get { return GetResourceString("seqID_REQ"); } }

		public static string svCouplRes_REQ { get { return GetResourceString("svCouplRes_REQ"); } }

		public static string svType_REQ { get { return GetResourceString("svType_REQ"); } }

		public static string medDensity_REAL { get { return GetResourceString("medDensity_REAL"); } }

		public static string medDenUnits_REQ { get { return GetResourceString("medDenUnits_REQ"); } }

		public static string aggrInfo_REQ { get { return GetResourceString("aggrInfo_REQ"); } }

		public static string AscTypeCd_REQ { get { return GetResourceString("AscTypeCd_REQ"); } }

		public static string doubleList_REQ { get { return GetResourceString("doubleList_REQ"); } }

		public static string ScopeCd_REQ { get { return GetResourceString("ScopeCd_REQ"); } }

		public static string chkPtDesc_REQ { get { return GetResourceString("chkPtDesc_REQ"); } }

		public static string georefPars_REQ { get { return GetResourceString("georefPars_REQ"); } }

		public static string cntAddress_FGDC_REQ { get { return GetResourceString("cntAddress_FGDC_REQ"); } }

		public static string datasetSeries_FGDC_REQ { get { return GetResourceString("datasetSeries_FGDC_REQ"); } }

		public static string originator_FGDC_REQ { get { return GetResourceString("originator_FGDC_REQ"); } }

		public static string partyFgdc_FGDC_REQ { get { return GetResourceString("partyFgdc_FGDC_REQ"); } }

		public static string pubDate_FGDC_REQ { get { return GetResourceString("pubDate_FGDC_REQ"); } }

		public static string publisher_FGDC_REQ { get { return GetResourceString("publisher_FGDC_REQ"); } }

		public static string tagTopicKeyword_REQ { get { return GetResourceString("tagTopicKeyword_REQ"); } }

		public static string voiceNum_FGDC_REQ { get { return GetResourceString("voiceNum_FGDC_REQ"); } }

		public static string vertMinMaxVal_REQ { get { return GetResourceString("vertMinMaxVal_REQ"); } }

		public static string bgFileDesc_REQ { get { return GetResourceString("bgFileDesc_REQ"); } }

		public static string bgFileType_REQ { get { return GetResourceString("bgFileType_REQ"); } }

		public static string extent_dataExtBBox_REQ { get { return GetResourceString("extent_dataExtBBox_REQ"); } }

		public static string extent_dataExtDesc_REQ { get { return GetResourceString("extent_dataExtDesc_REQ"); } }

		public static string extent_dataExtTemp_REQ { get { return GetResourceString("extent_dataExtTemp_REQ"); } }

		public static string idStatus_REQ { get { return GetResourceString("idStatus_REQ"); } }

		public static string SpatRepTypCd_REQ { get { return GetResourceString("SpatRepTypCd_REQ"); } }

		public static string classSys_REQ { get { return GetResourceString("classSys_REQ"); } }

		public static string handDesc_REQ { get { return GetResourceString("handDesc_REQ"); } }

		public static string useLimitDist_REQ { get { return GetResourceString("useLimitDist_REQ"); } }

		public static string DQConcConsis_REQ { get { return GetResourceString("DQConcConsis_REQ"); } }

		public static string DQCompOm_REQ { get { return GetResourceString("DQCompOm_REQ"); } }

		public static string evalMethDesc_REQ { get { return GetResourceString("evalMethDesc_REQ"); } }

		public static string measDesc_REQ { get { return GetResourceString("measDesc_REQ"); } }

		public static string addressType_REQ { get { return GetResourceString("addressType_REQ"); } }

		public static string adminArea_REQ { get { return GetResourceString("adminArea_REQ"); } }

		public static string city_REQ { get { return GetResourceString("city_REQ"); } }

		public static string dataExtBBoxReq_FGDC { get { return GetResourceString("dataExtBBoxReq_FGDC"); } }

		public static string postCode_REQ { get { return GetResourceString("postCode_REQ"); } }

		public static string tempEle_exDesc_REQ { get { return GetResourceString("tempEle_exDesc_REQ"); } }

		public static string adminArea_FGDC_REQ { get { return GetResourceString("adminArea_FGDC_REQ"); } }

		public static string dataLineage_FGDC_REQ { get { return GetResourceString("dataLineage_FGDC_REQ"); } }

		public static string LAT_COORD_REAL_REQ { get { return GetResourceString("LAT_COORD_REAL_REQ"); } }

		public static string LON_COORD_REAL_REQ { get { return GetResourceString("LON_COORD_REAL_REQ"); } }

		public static string stepDateTm_REQ { get { return GetResourceString("stepDateTm_REQ"); } }
	}
	internal class Resources
	{
        private static global::System.Resources.ResourceManager resourceMan;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(resourceMan, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MetadataToolkit.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = Thread.CurrentThread.CurrentUICulture;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
       
		
		public static string BTN_ADD_CONTACT { get { return GetResourceString("BTN_ADD_CONTACT"); } }

		public static string BTN_CANCEL { get { return GetResourceString("BTN_CANCEL"); } }

		public static string BTN_COV_NEW_COVDESC { get { return GetResourceString("BTN_COV_NEW_COVDESC"); } }

		public static string BTN_COV_NEW_IMGDESC { get { return GetResourceString("BTN_COV_NEW_IMGDESC"); } }

		public static string BTN_EDIT { get { return GetResourceString("BTN_EDIT"); } }

		public static string BTN_Export { get { return GetResourceString("BTN_Export"); } }

		public static string BTN_EXTENTS_ADD_TEMP { get { return GetResourceString("BTN_EXTENTS_ADD_TEMP"); } }

		public static string BTN_EXTENTS_ADD_TEMPSPAT { get { return GetResourceString("BTN_EXTENTS_ADD_TEMPSPAT"); } }

		public static string BTN_EXTENTS_NEW_BBOX { get { return GetResourceString("BTN_EXTENTS_NEW_BBOX"); } }

		public static string BTN_EXTENTS_NEW_GEODESC { get { return GetResourceString("BTN_EXTENTS_NEW_GEODESC"); } }

		public static string BTN_Import { get { return GetResourceString("BTN_Import"); } }

		public static string BTN_KEY_NEW_DIS { get { return GetResourceString("BTN_KEY_NEW_DIS"); } }

		public static string BTN_KEY_NEW_PLACE { get { return GetResourceString("BTN_KEY_NEW_PLACE"); } }

		public static string BTN_KEY_NEW_STRAT { get { return GetResourceString("BTN_KEY_NEW_STRAT"); } }

		public static string BTN_KEY_NEW_TEMP { get { return GetResourceString("BTN_KEY_NEW_TEMP"); } }

		public static string BTN_KEY_NEW_THEME { get { return GetResourceString("BTN_KEY_NEW_THEME"); } }

		public static string BTN_NEW { get { return GetResourceString("BTN_NEW"); } }

		public static string BTN_PRINT { get { return GetResourceString("BTN_PRINT"); } }

		public static string BTN_RES_EXTENTS_NEW { get { return GetResourceString("BTN_RES_EXTENTS_NEW"); } }

		public static string BTN_SAVE { get { return GetResourceString("BTN_SAVE"); } }

		public static string BTN_VALIDATE { get { return GetResourceString("BTN_VALIDATE"); } }

		public static string LBL_ALTERNATE_TITLE { get { return GetResourceString("LBL_ALTERNATE_TITLE"); } }

		public static string LBL_CITATION_DETAILS { get { return GetResourceString("LBL_CITATION_DETAILS"); } }

		public static string LBL_CITATION_TITLES { get { return GetResourceString("LBL_CITATION_TITLES"); } }

		public static string LBL_COLLECTIVE_TITLE { get { return GetResourceString("LBL_COLLECTIVE_TITLE"); } }

		public static string LBL_COV_ATTRDESC { get { return GetResourceString("LBL_COV_ATTRDESC"); } }

		public static string LBL_COV_CONTTYPE { get { return GetResourceString("LBL_COV_CONTTYPE"); } }

		public static string LBL_COV_DESC { get { return GetResourceString("LBL_COV_DESC"); } }

		public static string LBL_COV_ILLAZIANG { get { return GetResourceString("LBL_COV_ILLAZIANG"); } }

		public static string LBL_COV_ILLELEVANG { get { return GetResourceString("LBL_COV_ILLELEVANG"); } }

		public static string LBL_COV_IMAGCOND { get { return GetResourceString("LBL_COV_IMAGCOND"); } }

		public static string LBL_COV_IMAGQUCODE { get { return GetResourceString("LBL_COV_IMAGQUCODE"); } }

		public static string LBL_COV_IMGDESC { get { return GetResourceString("LBL_COV_IMGDESC"); } }

		public static string LBL_CREATED_DATE { get { return GetResourceString("LBL_CREATED_DATE"); } }

		public static string LBL_DATES { get { return GetResourceString("LBL_DATES"); } }

		public static string LBL_DESC_ABSTRACT { get { return GetResourceString("LBL_DESC_ABSTRACT"); } }

		public static string LBL_DESC_CREDIT { get { return GetResourceString("LBL_DESC_CREDIT"); } }

		public static string LBL_DESC_DISKEY { get { return GetResourceString("LBL_DESC_DISKEY"); } }

		public static string LBL_DESC_PLACEKEY { get { return GetResourceString("LBL_DESC_PLACEKEY"); } }

		public static string LBL_DESC_PURPOSE { get { return GetResourceString("LBL_DESC_PURPOSE"); } }

		public static string LBL_DESC_STATUS { get { return GetResourceString("LBL_DESC_STATUS"); } }

		public static string LBL_DESC_STRATKEY { get { return GetResourceString("LBL_DESC_STRATKEY"); } }

		public static string LBL_DESC_TEMPKEY { get { return GetResourceString("LBL_DESC_TEMPKEY"); } }

		public static string LBL_DESC_THEMEKEY { get { return GetResourceString("LBL_DESC_THEMEKEY"); } }

		public static string LBL_DESC_TITLE { get { return GetResourceString("LBL_DESC_TITLE"); } }

		public static string LBL_DESC_TOPICS { get { return GetResourceString("LBL_DESC_TOPICS"); } }

		public static string LBL_DQ_LEVELDESC { get { return GetResourceString("LBL_DQ_LEVELDESC"); } }

		public static string LBL_DQ_LEVELSCOPE { get { return GetResourceString("LBL_DQ_LEVELSCOPE"); } }

		public static string LBL_DQ_QUALITYREPORTS { get { return GetResourceString("LBL_DQ_QUALITYREPORTS"); } }

		public static string LBL_EDITION { get { return GetResourceString("LBL_EDITION"); } }

		public static string LBL_EDITION_DATE { get { return GetResourceString("LBL_EDITION_DATE"); } }

		public static string LBL_EXTENT { get { return GetResourceString("LBL_EXTENT"); } }

		public static string LBL_EXTENTS_BBOX { get { return GetResourceString("LBL_EXTENTS_BBOX"); } }

		public static string LBL_EXTENTS_GEODESC { get { return GetResourceString("LBL_EXTENTS_GEODESC"); } }

		public static string LBL_EXTENTS_TEMP { get { return GetResourceString("LBL_EXTENTS_TEMP"); } }

		public static string LBL_EXTENTS_TEMPSPAT { get { return GetResourceString("LBL_EXTENTS_TEMPSPAT"); } }

		public static string LBL_EXT_EAST { get { return GetResourceString("LBL_EXT_EAST"); } }

		public static string LBL_EXT_GEOID_CODE { get { return GetResourceString("LBL_EXT_GEOID_CODE"); } }

		public static string LBL_EXT_NORTH { get { return GetResourceString("LBL_EXT_NORTH"); } }

		public static string LBL_EXT_SOUTH { get { return GetResourceString("LBL_EXT_SOUTH"); } }

		public static string LBL_EXT_WEST { get { return GetResourceString("LBL_EXT_WEST"); } }

		public static string LBL_IDENTIFIER { get { return GetResourceString("LBL_IDENTIFIER"); } }

		public static string LBL_IDENTIFIERS { get { return GetResourceString("LBL_IDENTIFIERS"); } }

		public static string LBL_ISBN { get { return GetResourceString("LBL_ISBN"); } }

		public static string LBL_ISSN { get { return GetResourceString("LBL_ISSN"); } }

		public static string LBL_LN_STATEMENT { get { return GetResourceString("LBL_LN_STATEMENT"); } }

		public static string LBL_MAINT_CUSTOMFREQ { get { return GetResourceString("LBL_MAINT_CUSTOMFREQ"); } }

		public static string LBL_MAINT_NEXTUPDATE { get { return GetResourceString("LBL_MAINT_NEXTUPDATE"); } }

		public static string LBL_MAINT_NOTE { get { return GetResourceString("LBL_MAINT_NOTE"); } }

		public static string LBL_MAINT_UPDATEDESC { get { return GetResourceString("LBL_MAINT_UPDATEDESC"); } }

		public static string LBL_MAINT_UPDATEFREQ { get { return GetResourceString("LBL_MAINT_UPDATEFREQ"); } }

		public static string LBL_MAINT_UPDATESCOPE { get { return GetResourceString("LBL_MAINT_UPDATESCOPE"); } }

		public static string LBL_MAINT_UPDATESCOPEDESC { get { return GetResourceString("LBL_MAINT_UPDATESCOPEDESC"); } }

		public static string LBL_MD_IDENTAUTH { get { return GetResourceString("LBL_MD_IDENTAUTH"); } }

		public static string LBL_MD_IDENTCODE { get { return GetResourceString("LBL_MD_IDENTCODE"); } }

		public static string LBL_META_MAINT { get { return GetResourceString("LBL_META_MAINT"); } }

		public static string LBL_META_MAINT_CONTACTS { get { return GetResourceString("LBL_META_MAINT_CONTACTS"); } }

		public static string LBL_PRESENTATIONCODE_DIGITALDOCUMENT { get { return GetResourceString("LBL_PRESENTATIONCODE_DIGITALDOCUMENT"); } }

		public static string LBL_PRESENTATIONCODE_HARDCOPYDOCUMENT { get { return GetResourceString("LBL_PRESENTATIONCODE_HARDCOPYDOCUMENT"); } }

		public static string LBL_PRESENTATION_FORM { get { return GetResourceString("LBL_PRESENTATION_FORM"); } }

		public static string LBL_PUBLISHED_DATE { get { return GetResourceString("LBL_PUBLISHED_DATE"); } }

		public static string LBL_RES_CITATION_CONTACTS { get { return GetResourceString("LBL_RES_CITATION_CONTACTS"); } }

		public static string LBL_RES_EXTENTS { get { return GetResourceString("LBL_RES_EXTENTS"); } }

		public static string LBL_RES_MAINT { get { return GetResourceString("LBL_RES_MAINT"); } }

		public static string LBL_RES_MAINT_CONTACTS { get { return GetResourceString("LBL_RES_MAINT_CONTACTS"); } }

		public static string LBL_RES_POCS { get { return GetResourceString("LBL_RES_POCS"); } }

		public static string LBL_REVISED_DATE { get { return GetResourceString("LBL_REVISED_DATE"); } }

		public static string LBL_SCOPEDESC_ATTRIBUTEINSTANCES { get { return GetResourceString("LBL_SCOPEDESC_ATTRIBUTEINSTANCES"); } }

		public static string LBL_SCOPEDESC_ATTRIBUTES { get { return GetResourceString("LBL_SCOPEDESC_ATTRIBUTES"); } }

		public static string LBL_SCOPEDESC_DATASET { get { return GetResourceString("LBL_SCOPEDESC_DATASET"); } }

		public static string LBL_SCOPEDESC_FEATUREINSTANCES { get { return GetResourceString("LBL_SCOPEDESC_FEATUREINSTANCES"); } }

		public static string LBL_SCOPEDESC_FEATURES { get { return GetResourceString("LBL_SCOPEDESC_FEATURES"); } }

		public static string LBL_SCOPEDESC_OTHERINSTANCES { get { return GetResourceString("LBL_SCOPEDESC_OTHERINSTANCES"); } }

		public static string LBL_SERIES { get { return GetResourceString("LBL_SERIES"); } }

		public static string LBL_SERIES_ISSUE_ID { get { return GetResourceString("LBL_SERIES_ISSUE_ID"); } }

		public static string LBL_SERIES_NAME { get { return GetResourceString("LBL_SERIES_NAME"); } }

		public static string LBL_SERIES_PAGE { get { return GetResourceString("LBL_SERIES_PAGE"); } }

		public static string LBL_TITLE { get { return GetResourceString("LBL_TITLE"); } }

		public static string LBL_TOPICS_001 { get { return GetResourceString("LBL_TOPICS_001"); } }

		public static string LBL_TOPICS_002 { get { return GetResourceString("LBL_TOPICS_002"); } }

		public static string LBL_TOPICS_003 { get { return GetResourceString("LBL_TOPICS_003"); } }

		public static string LBL_TOPICS_004 { get { return GetResourceString("LBL_TOPICS_004"); } }

		public static string LBL_TOPICS_005 { get { return GetResourceString("LBL_TOPICS_005"); } }

		public static string LBL_TOPICS_006 { get { return GetResourceString("LBL_TOPICS_006"); } }

		public static string LBL_TOPICS_007 { get { return GetResourceString("LBL_TOPICS_007"); } }

		public static string LBL_TOPICS_008 { get { return GetResourceString("LBL_TOPICS_008"); } }

		public static string LBL_TOPICS_009 { get { return GetResourceString("LBL_TOPICS_009"); } }

		public static string LBL_TOPICS_010 { get { return GetResourceString("LBL_TOPICS_010"); } }

		public static string LBL_TOPICS_011 { get { return GetResourceString("LBL_TOPICS_011"); } }

		public static string LBL_TOPICS_012 { get { return GetResourceString("LBL_TOPICS_012"); } }

		public static string LBL_TOPICS_013 { get { return GetResourceString("LBL_TOPICS_013"); } }

		public static string LBL_TOPICS_014 { get { return GetResourceString("LBL_TOPICS_014"); } }

		public static string LBL_TOPICS_015 { get { return GetResourceString("LBL_TOPICS_015"); } }

		public static string LBL_TOPICS_016 { get { return GetResourceString("LBL_TOPICS_016"); } }

		public static string LBL_TOPICS_017 { get { return GetResourceString("LBL_TOPICS_017"); } }

		public static string LBL_TOPICS_018 { get { return GetResourceString("LBL_TOPICS_018"); } }

		public static string LBL_TOPICS_019 { get { return GetResourceString("LBL_TOPICS_019"); } }

		public static string SB_DATAQUAL { get { return GetResourceString("SB_DATAQUAL"); } }

		public static string SB_METADATA { get { return GetResourceString("SB_METADATA"); } }

		public static string SB_METADATA_CONTACTS { get { return GetResourceString("SB_METADATA_CONTACTS"); } }

		public static string SB_METADATA_MAINT { get { return GetResourceString("SB_METADATA_MAINT"); } }

		public static string SB_METADATA_MAINTCONT { get { return GetResourceString("SB_METADATA_MAINTCONT"); } }

		public static string SB_OVERVIEW { get { return GetResourceString("SB_OVERVIEW"); } }

		public static string SB_OVERVIEW_DESC { get { return GetResourceString("SB_OVERVIEW_DESC"); } }

		public static string SB_RASTER { get { return GetResourceString("SB_RASTER"); } }

		public static string SB_RESOURCE { get { return GetResourceString("SB_RESOURCE"); } }

		public static string SB_RESOURCE_CITATION { get { return GetResourceString("SB_RESOURCE_CITATION"); } }

		public static string SB_RESOURCE_CITECONT { get { return GetResourceString("SB_RESOURCE_CITECONT"); } }

		public static string SB_RESOURCE_EXTENTS { get { return GetResourceString("SB_RESOURCE_EXTENTS"); } }

		public static string SB_RESOURCE_MAINT { get { return GetResourceString("SB_RESOURCE_MAINT"); } }

		public static string SB_RESOURCE_MAINTCONT { get { return GetResourceString("SB_RESOURCE_MAINTCONT"); } }

		public static string SB_VECTOR { get { return GetResourceString("SB_VECTOR"); } }

		public static string SEC_CONTENT_INFO { get { return GetResourceString("SEC_CONTENT_INFO"); } }

		public static string SEC_DESCRIPTION { get { return GetResourceString("SEC_DESCRIPTION"); } }

		public static string SEC_KEYWORDS { get { return GetResourceString("SEC_KEYWORDS"); } }

		public static string SEC_METADATA_CONTACTS { get { return GetResourceString("SEC_METADATA_CONTACTS"); } }

		public static string SEC_RES_CITE { get { return GetResourceString("SEC_RES_CITE"); } }

		public static string BTN_KEY_NEW_OTHER { get { return GetResourceString("BTN_KEY_NEW_OTHER"); } }

		public static string LBL_DESC_OTHERKEY { get { return GetResourceString("LBL_DESC_OTHERKEY"); } }

		public static string BTN_Upgrade { get { return GetResourceString("BTN_Upgrade"); } }

		public static string BTN_DELETE { get { return GetResourceString("BTN_DELETE"); } }

		public static string BTN_ABSTRACT_NEW_CREDIT { get { return GetResourceString("BTN_ABSTRACT_NEW_CREDIT"); } }

		public static string BTN_ABSTRACT_NEW_LOCAL { get { return GetResourceString("BTN_ABSTRACT_NEW_LOCAL"); } }

		public static string BTN_ABSTRACT_NEW_STATUS { get { return GetResourceString("BTN_ABSTRACT_NEW_STATUS"); } }

		public static string BTN_TITLE_NEW_lOCAL { get { return GetResourceString("BTN_TITLE_NEW_lOCAL"); } }

		public static string SEC_DATAQUAL { get { return GetResourceString("SEC_DATAQUAL"); } }

		public static string BTN_DATAQUAL_NEW_EXT { get { return GetResourceString("BTN_DATAQUAL_NEW_EXT"); } }

		public static string BTN_DQ_NEW_MEASDATETIME { get { return GetResourceString("BTN_DQ_NEW_MEASDATETIME"); } }

		public static string BTN_DQ_NEW_MEASNAME { get { return GetResourceString("BTN_DQ_NEW_MEASNAME"); } }

		public static string BTN_DQ_NEW_REPORT { get { return GetResourceString("BTN_DQ_NEW_REPORT"); } }

		public static string BTN_KEY_NEW_SEARCH { get { return GetResourceString("BTN_KEY_NEW_SEARCH"); } }

		public static string BTN_LI_NEW_PROCESS_STEP { get { return GetResourceString("BTN_LI_NEW_PROCESS_STEP"); } }

		public static string BTN_LI_NEW_SOURCE { get { return GetResourceString("BTN_LI_NEW_SOURCE"); } }

		public static string BTN_LI_PROCESS_STEP_NEW_PROC { get { return GetResourceString("BTN_LI_PROCESS_STEP_NEW_PROC"); } }

		public static string BTN_LI_SOURCE_NEW_EXT { get { return GetResourceString("BTN_LI_SOURCE_NEW_EXT"); } }

		public static string BTN_MAIN_NEW_CONTACT { get { return GetResourceString("BTN_MAIN_NEW_CONTACT"); } }

		public static string BTN_MAIN_NEW_NOTE { get { return GetResourceString("BTN_MAIN_NEW_NOTE"); } }

		public static string BTN_MAIN_NEW_SCOPEDESC { get { return GetResourceString("BTN_MAIN_NEW_SCOPEDESC"); } }

		public static string BTN_MAIN_NEW_UPDATE_SCOPE { get { return GetResourceString("BTN_MAIN_NEW_UPDATE_SCOPE"); } }

		public static string BTN_MD_RS_NEW_RS { get { return GetResourceString("BTN_MD_RS_NEW_RS"); } }

		public static string BTN_NEW_LEVELDESC { get { return GetResourceString("BTN_NEW_LEVELDESC"); } }

		public static string LBL_DESC_SEARCHKEY { get { return GetResourceString("LBL_DESC_SEARCHKEY"); } }

		public static string LBL_DQ_EVALDESC { get { return GetResourceString("LBL_DQ_EVALDESC"); } }

		public static string LBL_DQ_EVALMETHTYPE { get { return GetResourceString("LBL_DQ_EVALMETHTYPE"); } }

		public static string LBL_DQ_EVALPROC { get { return GetResourceString("LBL_DQ_EVALPROC"); } }

		public static string LBL_DQ_LEVELEXT { get { return GetResourceString("LBL_DQ_LEVELEXT"); } }

		public static string LBL_DQ_MEASDATE { get { return GetResourceString("LBL_DQ_MEASDATE"); } }

		public static string LBL_DQ_MEASDESC { get { return GetResourceString("LBL_DQ_MEASDESC"); } }

		public static string LBL_DQ_MEASID { get { return GetResourceString("LBL_DQ_MEASID"); } }

		public static string LBL_DQ_MEASNAME { get { return GetResourceString("LBL_DQ_MEASNAME"); } }

		public static string LBL_DQ_REPORT { get { return GetResourceString("LBL_DQ_REPORT"); } }

		public static string LBL_DQ_REPORTTYPE { get { return GetResourceString("LBL_DQ_REPORTTYPE"); } }

		public static string LBL_ITEMINFO_ABST { get { return GetResourceString("LBL_ITEMINFO_ABST"); } }

		public static string LBL_ITEMINFO_ACCESS { get { return GetResourceString("LBL_ITEMINFO_ACCESS"); } }

		public static string LBL_ITEMINFO_KEY { get { return GetResourceString("LBL_ITEMINFO_KEY"); } }

		public static string LBL_ITEMINFO_SNIP { get { return GetResourceString("LBL_ITEMINFO_SNIP"); } }

		public static string LBL_ITEMINFO_TITLE { get { return GetResourceString("LBL_ITEMINFO_TITLE"); } }

		public static string LBL_LI_PROCESS_PROCESSOR { get { return GetResourceString("LBL_LI_PROCESS_PROCESSOR"); } }

		public static string LBL_LI_PROCESS_STEP { get { return GetResourceString("LBL_LI_PROCESS_STEP"); } }

		public static string LBL_LI_PROCESS_STEP_DATE { get { return GetResourceString("LBL_LI_PROCESS_STEP_DATE"); } }

		public static string LBL_LI_PROCESS_STEP_DESC { get { return GetResourceString("LBL_LI_PROCESS_STEP_DESC"); } }

		public static string LBL_LI_PROCESS_STEP_RATIONALE { get { return GetResourceString("LBL_LI_PROCESS_STEP_RATIONALE"); } }

		public static string LBL_LI_SOURCE { get { return GetResourceString("LBL_LI_SOURCE"); } }

		public static string LBL_LI_SOURCE_CITATION { get { return GetResourceString("LBL_LI_SOURCE_CITATION"); } }

		public static string LBL_LI_SOURCE_DESC { get { return GetResourceString("LBL_LI_SOURCE_DESC"); } }

		public static string LBL_LI_SOURCE_EXTENT { get { return GetResourceString("LBL_LI_SOURCE_EXTENT"); } }

		public static string LBL_LI_SOURCE_REFDENOM { get { return GetResourceString("LBL_LI_SOURCE_REFDENOM"); } }

		public static string LBL_LI_SOURCE_REFSYS { get { return GetResourceString("LBL_LI_SOURCE_REFSYS"); } }

		public static string LBL_LI_STATEMENT { get { return GetResourceString("LBL_LI_STATEMENT"); } }

		public static string LBL_MAIN_CONTACT { get { return GetResourceString("LBL_MAIN_CONTACT"); } }

		public static string LBL_MD_RS { get { return GetResourceString("LBL_MD_RS"); } }

		public static string LBL_RS_IDENTAUTH { get { return GetResourceString("LBL_RS_IDENTAUTH"); } }

		public static string LBL_RS_IDENTCODE { get { return GetResourceString("LBL_RS_IDENTCODE"); } }

		public static string LBL_RS_IDENTCODESPACE { get { return GetResourceString("LBL_RS_IDENTCODESPACE"); } }

		public static string LBL_RS_IDENTVERSION { get { return GetResourceString("LBL_RS_IDENTVERSION"); } }

		public static string SEC_ITEMINFO { get { return GetResourceString("SEC_ITEMINFO"); } }

		public static string SEC_LINEAGE { get { return GetResourceString("SEC_LINEAGE"); } }

		public static string SEC_REFSYSINFO { get { return GetResourceString("SEC_REFSYSINFO"); } }

		public static string BTN_CI_NEW_PRESFORM { get { return GetResourceString("BTN_CI_NEW_PRESFORM"); } }

		public static string BTN_DIGOPT_NEW_ONLINE { get { return GetResourceString("BTN_DIGOPT_NEW_ONLINE"); } }

		public static string BTN_DIST_NEW_CONT { get { return GetResourceString("BTN_DIST_NEW_CONT"); } }

		public static string BTN_DIST_NEW_DISTOR { get { return GetResourceString("BTN_DIST_NEW_DISTOR"); } }

		public static string BTN_DIST_NEW_FORMAT { get { return GetResourceString("BTN_DIST_NEW_FORMAT"); } }

		public static string BTN_DIST_NEW_ORDER { get { return GetResourceString("BTN_DIST_NEW_ORDER"); } }

		public static string BTN_DIST_NEW_TRANS { get { return GetResourceString("BTN_DIST_NEW_TRANS"); } }

		public static string BTN_MED_NEW_FORMAT { get { return GetResourceString("BTN_MED_NEW_FORMAT"); } }

		public static string LBL_DIGOPT_OFFLINE { get { return GetResourceString("LBL_DIGOPT_OFFLINE"); } }

		public static string LBL_DIGOPT_ONLINE { get { return GetResourceString("LBL_DIGOPT_ONLINE"); } }

		public static string LBL_DIGOPT_SIZE { get { return GetResourceString("LBL_DIGOPT_SIZE"); } }

		public static string LBL_DIGOPT_UNITS { get { return GetResourceString("LBL_DIGOPT_UNITS"); } }

		public static string LBL_DIST_CONT { get { return GetResourceString("LBL_DIST_CONT"); } }

		public static string LBL_DIST_DISTOR { get { return GetResourceString("LBL_DIST_DISTOR"); } }

		public static string LBL_DIST_FORMAT { get { return GetResourceString("LBL_DIST_FORMAT"); } }

		public static string LBL_DIST_ORDER { get { return GetResourceString("LBL_DIST_ORDER"); } }

		public static string LBL_DIST_TRANS { get { return GetResourceString("LBL_DIST_TRANS"); } }

		public static string LBL_FMTK_AMD { get { return GetResourceString("LBL_FMTK_AMD"); } }

		public static string LBL_FMTK_DECOM { get { return GetResourceString("LBL_FMTK_DECOM"); } }

		public static string LBL_FMTK_NAME { get { return GetResourceString("LBL_FMTK_NAME"); } }

		public static string LBL_FMTK_SPEC { get { return GetResourceString("LBL_FMTK_SPEC"); } }

		public static string LBL_FMTK_VER { get { return GetResourceString("LBL_FMTK_VER"); } }

		public static string LBL_MED_DENUNITS { get { return GetResourceString("LBL_MED_DENUNITS"); } }

		public static string LBL_MED_FORMAT { get { return GetResourceString("LBL_MED_FORMAT"); } }

		public static string LBL_MED_NAME { get { return GetResourceString("LBL_MED_NAME"); } }

		public static string LBL_MED_VOLUMES { get { return GetResourceString("LBL_MED_VOLUMES"); } }

		public static string LBL_ONLINE_DESC { get { return GetResourceString("LBL_ONLINE_DESC"); } }

		public static string LBL_ONLINE_FUNCTION { get { return GetResourceString("LBL_ONLINE_FUNCTION"); } }

		public static string LBL_ONLINE_LINKAGE { get { return GetResourceString("LBL_ONLINE_LINKAGE"); } }

		public static string LBL_ONLINE_NAME { get { return GetResourceString("LBL_ONLINE_NAME"); } }

		public static string LBL_ONLINE_PROFILE { get { return GetResourceString("LBL_ONLINE_PROFILE"); } }

		public static string LBL_ONLINE_PROTOCOL { get { return GetResourceString("LBL_ONLINE_PROTOCOL"); } }

		public static string LBL_STD_AVAILDATE { get { return GetResourceString("LBL_STD_AVAILDATE"); } }

		public static string LBL_STD_FEES { get { return GetResourceString("LBL_STD_FEES"); } }

		public static string LBL_STD_ORDER { get { return GetResourceString("LBL_STD_ORDER"); } }

		public static string LBL_STD_TURNAROUND { get { return GetResourceString("LBL_STD_TURNAROUND"); } }

		public static string SEC_DISTRIBUTION { get { return GetResourceString("SEC_DISTRIBUTION"); } }

		public static string BTN_META_NEW_HIER { get { return GetResourceString("BTN_META_NEW_HIER"); } }

		public static string LBL_CONT_ADDRESS { get { return GetResourceString("LBL_CONT_ADDRESS"); } }

		public static string LBL_CONT_CITY { get { return GetResourceString("LBL_CONT_CITY"); } }

		public static string LBL_CONT_CONTACT { get { return GetResourceString("LBL_CONT_CONTACT"); } }

		public static string LBL_CONT_COUNTRY { get { return GetResourceString("LBL_CONT_COUNTRY"); } }

		public static string LBL_CONT_EMAIL { get { return GetResourceString("LBL_CONT_EMAIL"); } }

		public static string LBL_CONT_FAX { get { return GetResourceString("LBL_CONT_FAX"); } }

		public static string LBL_CONT_HOURS { get { return GetResourceString("LBL_CONT_HOURS"); } }

		public static string LBL_CONT_INSTR { get { return GetResourceString("LBL_CONT_INSTR"); } }

		public static string LBL_CONT_ONRES { get { return GetResourceString("LBL_CONT_ONRES"); } }

		public static string LBL_CONT_PHONE { get { return GetResourceString("LBL_CONT_PHONE"); } }

		public static string LBL_CONT_POSTAL { get { return GetResourceString("LBL_CONT_POSTAL"); } }

		public static string LBL_CONT_STATE { get { return GetResourceString("LBL_CONT_STATE"); } }

		public static string LBL_DESC_OTHERTITLE { get { return GetResourceString("LBL_DESC_OTHERTITLE"); } }

		public static string LBL_META_FILEID { get { return GetResourceString("LBL_META_FILEID"); } }

		public static string LBL_META_HIER { get { return GetResourceString("LBL_META_HIER"); } }

		public static string LBL_META_LANG { get { return GetResourceString("LBL_META_LANG"); } }

		public static string LBL_META_PARENTFILEID { get { return GetResourceString("LBL_META_PARENTFILEID"); } }

		public static string SEC_METADETAILS { get { return GetResourceString("SEC_METADETAILS"); } }

		public static string BTN_CONSTS_NEW_GENERAL { get { return GetResourceString("BTN_CONSTS_NEW_GENERAL"); } }

		public static string BTN_CONSTS_NEW_LEGAL { get { return GetResourceString("BTN_CONSTS_NEW_LEGAL"); } }

		public static string BTN_CONSTS_NEW_OTHER { get { return GetResourceString("BTN_CONSTS_NEW_OTHER"); } }

		public static string BTN_CONSTS_NEW_SECURITY { get { return GetResourceString("BTN_CONSTS_NEW_SECURITY"); } }

		public static string BTN_CONSTS_NEW_USELIMIT { get { return GetResourceString("BTN_CONSTS_NEW_USELIMIT"); } }

		public static string BTN_COV_NEW_BAND { get { return GetResourceString("BTN_COV_NEW_BAND"); } }

		public static string BTN_COV_NEW_FEATCAT { get { return GetResourceString("BTN_COV_NEW_FEATCAT"); } }

		public static string BTN_COV_NEW_RANGEDIM { get { return GetResourceString("BTN_COV_NEW_RANGEDIM"); } }

		public static string BTN_META_NEW_HIERNAME { get { return GetResourceString("BTN_META_NEW_HIERNAME"); } }

		public static string LBL_BAND_BITS { get { return GetResourceString("LBL_BAND_BITS"); } }

		public static string LBL_BAND_MAXVAL { get { return GetResourceString("LBL_BAND_MAXVAL"); } }

		public static string LBL_BAND_MINVAL { get { return GetResourceString("LBL_BAND_MINVAL"); } }

		public static string LBL_BAND_OFFSET { get { return GetResourceString("LBL_BAND_OFFSET"); } }

		public static string LBL_BAND_PEAK { get { return GetResourceString("LBL_BAND_PEAK"); } }

		public static string LBL_BAND_SCALE { get { return GetResourceString("LBL_BAND_SCALE"); } }

		public static string LBL_BAND_TONE { get { return GetResourceString("LBL_BAND_TONE"); } }

		public static string LBL_BAND_UNITS { get { return GetResourceString("LBL_BAND_UNITS"); } }

		public static string LBL_CONSTS_ACCESS { get { return GetResourceString("LBL_CONSTS_ACCESS"); } }

		public static string LBL_CONSTS_CLASS { get { return GetResourceString("LBL_CONSTS_CLASS"); } }

		public static string LBL_CONSTS_GENERAL { get { return GetResourceString("LBL_CONSTS_GENERAL"); } }

		public static string LBL_CONSTS_HANDLING { get { return GetResourceString("LBL_CONSTS_HANDLING"); } }

		public static string LBL_CONSTS_LEGAL { get { return GetResourceString("LBL_CONSTS_LEGAL"); } }

		public static string LBL_CONSTS_METADATA { get { return GetResourceString("LBL_CONSTS_METADATA"); } }

		public static string LBL_CONSTS_OTHER { get { return GetResourceString("LBL_CONSTS_OTHER"); } }

		public static string LBL_CONSTS_RESOURCE { get { return GetResourceString("LBL_CONSTS_RESOURCE"); } }

		public static string LBL_CONSTS_SECURITY { get { return GetResourceString("LBL_CONSTS_SECURITY"); } }

		public static string LBL_CONSTS_SYSTEM { get { return GetResourceString("LBL_CONSTS_SYSTEM"); } }

		public static string LBL_CONSTS_USE { get { return GetResourceString("LBL_CONSTS_USE"); } }

		public static string LBL_CONSTS_USELIMIT { get { return GetResourceString("LBL_CONSTS_USELIMIT"); } }

		public static string LBL_CONSTS_USERNOTE { get { return GetResourceString("LBL_CONSTS_USERNOTE"); } }

		public static string LBL_COV_ATTTYPE { get { return GetResourceString("LBL_COV_ATTTYPE"); } }

		public static string LBL_COV_BAND { get { return GetResourceString("LBL_COV_BAND"); } }

		public static string LBL_COV_DESCRIPTOR { get { return GetResourceString("LBL_COV_DESCRIPTOR"); } }

		public static string LBL_COV_FEATCAT { get { return GetResourceString("LBL_COV_FEATCAT"); } }

		public static string LBL_COV_RANGEDIM { get { return GetResourceString("LBL_COV_RANGEDIM"); } }

		public static string LBL_COV_SEQID { get { return GetResourceString("LBL_COV_SEQID"); } }

		public static string LBL_EXT_BOX { get { return GetResourceString("LBL_EXT_BOX"); } }

		public static string LBL_EXT_GEODESC { get { return GetResourceString("LBL_EXT_GEODESC"); } }

		public static string LBL_IMG_QUALCODE { get { return GetResourceString("LBL_IMG_QUALCODE"); } }

		public static string LBL_META_CHAR { get { return GetResourceString("LBL_META_CHAR"); } }

		public static string LBL_META_DATE { get { return GetResourceString("LBL_META_DATE"); } }

		public static string LBL_META_HIERNAME { get { return GetResourceString("LBL_META_HIERNAME"); } }

		public static string LBL_META_STDNAME { get { return GetResourceString("LBL_META_STDNAME"); } }

		public static string LBL_META_STDVER { get { return GetResourceString("LBL_META_STDVER"); } }

		public static string LBL_META_URI { get { return GetResourceString("LBL_META_URI"); } }

		public static string TT_RTB_ALIGNCENTER { get { return GetResourceString("TT_RTB_ALIGNCENTER"); } }

		public static string TT_RTB_ALIGNJUSTIFY { get { return GetResourceString("TT_RTB_ALIGNJUSTIFY"); } }

		public static string TT_RTB_ALIGNLEFT { get { return GetResourceString("TT_RTB_ALIGNLEFT"); } }

		public static string TT_RTB_ALIGNRIGHT { get { return GetResourceString("TT_RTB_ALIGNRIGHT"); } }

		public static string TT_RTB_BOLD { get { return GetResourceString("TT_RTB_BOLD"); } }

		public static string TT_RTB_BULLETS { get { return GetResourceString("TT_RTB_BULLETS"); } }

		public static string TT_RTB_COPY { get { return GetResourceString("TT_RTB_COPY"); } }

		public static string TT_RTB_CUT { get { return GetResourceString("TT_RTB_CUT"); } }

		public static string TT_RTB_DECINDENT { get { return GetResourceString("TT_RTB_DECINDENT"); } }

		public static string TT_RTB_GROWFONT { get { return GetResourceString("TT_RTB_GROWFONT"); } }

		public static string TT_RTB_INCINDENT { get { return GetResourceString("TT_RTB_INCINDENT"); } }

		public static string TT_RTB_ITALIC { get { return GetResourceString("TT_RTB_ITALIC"); } }

		public static string TT_RTB_NUMBERING { get { return GetResourceString("TT_RTB_NUMBERING"); } }

		public static string TT_RTB_PASTE { get { return GetResourceString("TT_RTB_PASTE"); } }

		public static string TT_RTB_REDO { get { return GetResourceString("TT_RTB_REDO"); } }

		public static string TT_RTB_SHRINKFONT { get { return GetResourceString("TT_RTB_SHRINKFONT"); } }

		public static string TT_RTB_UNDERLINE { get { return GetResourceString("TT_RTB_UNDERLINE"); } }

		public static string TT_RTB_UNDO { get { return GetResourceString("TT_RTB_UNDO"); } }

		public static string BTN_FEAT_NEW_CITATION { get { return GetResourceString("BTN_FEAT_NEW_CITATION"); } }

		public static string BTN_RESOL_NEW_SCALE { get { return GetResourceString("BTN_RESOL_NEW_SCALE"); } }

		public static string LBL_FEAT_CITATION { get { return GetResourceString("LBL_FEAT_CITATION"); } }

		public static string LBL_FEAT_COMP { get { return GetResourceString("LBL_FEAT_COMP"); } }

		public static string LBL_FEAT_FEATURE { get { return GetResourceString("LBL_FEAT_FEATURE"); } }

		public static string LBL_FEAT_INCDATASET { get { return GetResourceString("LBL_FEAT_INCDATASET"); } }

		public static string LBL_FEAT_LANG { get { return GetResourceString("LBL_FEAT_LANG"); } }

		public static string LBL_IMG_CAMERA { get { return GetResourceString("LBL_IMG_CAMERA"); } }

		public static string LBL_IMG_CLOUDPER { get { return GetResourceString("LBL_IMG_CLOUDPER"); } }

		public static string LBL_IMG_COMPRESS { get { return GetResourceString("LBL_IMG_COMPRESS"); } }

		public static string LBL_IMG_FILM { get { return GetResourceString("LBL_IMG_FILM"); } }

		public static string LBL_IMG_LENS { get { return GetResourceString("LBL_IMG_LENS"); } }

		public static string LBL_IMG_PROCCODE { get { return GetResourceString("LBL_IMG_PROCCODE"); } }

		public static string LBL_IMG_RADIO { get { return GetResourceString("LBL_IMG_RADIO"); } }

		public static string LBL_IMG_TRIANG { get { return GetResourceString("LBL_IMG_TRIANG"); } }

		public static string LBL_RESOL_SCALE { get { return GetResourceString("LBL_RESOL_SCALE"); } }

		public static string LBL_RES_CHAR { get { return GetResourceString("LBL_RES_CHAR"); } }

		public static string LBL_RES_LANG { get { return GetResourceString("LBL_RES_LANG"); } }

		public static string LBL_RES_SPATTYPE { get { return GetResourceString("LBL_RES_SPATTYPE"); } }

		public static string SEC_RES_DETAILS { get { return GetResourceString("SEC_RES_DETAILS"); } }

		public static string BTN_EAINFO_NEW_ATT { get { return GetResourceString("BTN_EAINFO_NEW_ATT"); } }

		public static string BTN_EAINFO_NEW_CODESET { get { return GetResourceString("BTN_EAINFO_NEW_CODESET"); } }

		public static string BTN_EAINFO_NEW_DETAILS { get { return GetResourceString("BTN_EAINFO_NEW_DETAILS"); } }

		public static string BTN_EAINFO_NEW_ENUM_DOMAIN { get { return GetResourceString("BTN_EAINFO_NEW_ENUM_DOMAIN"); } }

		public static string BTN_EAINFO_NEW_RANGE { get { return GetResourceString("BTN_EAINFO_NEW_RANGE"); } }

		public static string BTN_EAINFO_NEW_UDOM { get { return GetResourceString("BTN_EAINFO_NEW_UDOM"); } }

		public static string BTN_NEW_BROWSE { get { return GetResourceString("BTN_NEW_BROWSE"); } }

		public static string BTN_RESOL_NEW_DIST { get { return GetResourceString("BTN_RESOL_NEW_DIST"); } }

		public static string BTN_SPATREF_NEW_GEOOBJ { get { return GetResourceString("BTN_SPATREF_NEW_GEOOBJ"); } }

		public static string BTN_SPATREF_NEW_GEOREC { get { return GetResourceString("BTN_SPATREF_NEW_GEOREC"); } }

		public static string BTN_SPATREF_NEW_GEOREF { get { return GetResourceString("BTN_SPATREF_NEW_GEOREF"); } }

		public static string BTN_SPATREF_NEW_GRID { get { return GetResourceString("BTN_SPATREF_NEW_GRID"); } }

		public static string BTN_SPATREF_NEW_VEC { get { return GetResourceString("BTN_SPATREF_NEW_VEC"); } }

		public static string LBL_BROWSE_DESC { get { return GetResourceString("LBL_BROWSE_DESC"); } }

		public static string LBL_BROWSE_FILE { get { return GetResourceString("LBL_BROWSE_FILE"); } }

		public static string LBL_BROWSE_GRAPHIC { get { return GetResourceString("LBL_BROWSE_GRAPHIC"); } }

		public static string LBL_BROWSE_TYPE { get { return GetResourceString("LBL_BROWSE_TYPE"); } }

		public static string LBL_DESC_THECOUNTRY { get { return GetResourceString("LBL_DESC_THECOUNTRY"); } }

		public static string LBL_DESC_THELANG { get { return GetResourceString("LBL_DESC_THELANG"); } }

		public static string LBL_DESC_THESCITE { get { return GetResourceString("LBL_DESC_THESCITE"); } }

		public static string LBL_EAINFO_ATINDEX { get { return GetResourceString("LBL_EAINFO_ATINDEX"); } }

		public static string LBL_EAINFO_ATNUMDEC { get { return GetResourceString("LBL_EAINFO_ATNUMDEC"); } }

		public static string LBL_EAINFO_ATOUTWID { get { return GetResourceString("LBL_EAINFO_ATOUTWID"); } }

		public static string LBL_EAINFO_ATPRECIS { get { return GetResourceString("LBL_EAINFO_ATPRECIS"); } }

		public static string LBL_EAINFO_ATT { get { return GetResourceString("LBL_EAINFO_ATT"); } }

		public static string LBL_EAINFO_ATTALIAS { get { return GetResourceString("LBL_EAINFO_ATTALIAS"); } }

		public static string LBL_EAINFO_ATTRDEF { get { return GetResourceString("LBL_EAINFO_ATTRDEF"); } }

		public static string LBL_EAINFO_ATTRDEFS { get { return GetResourceString("LBL_EAINFO_ATTRDEFS"); } }

		public static string LBL_EAINFO_ATTRLABL { get { return GetResourceString("LBL_EAINFO_ATTRLABL"); } }

		public static string LBL_EAINFO_ATTRMFRQ { get { return GetResourceString("LBL_EAINFO_ATTRMFRQ"); } }

		public static string LBL_EAINFO_ATTRMRES { get { return GetResourceString("LBL_EAINFO_ATTRMRES"); } }

		public static string LBL_EAINFO_ATTRTYPE { get { return GetResourceString("LBL_EAINFO_ATTRTYPE"); } }

		public static string LBL_EAINFO_ATTRUNIT { get { return GetResourceString("LBL_EAINFO_ATTRUNIT"); } }

		public static string LBL_EAINFO_ATTRVA { get { return GetResourceString("LBL_EAINFO_ATTRVA"); } }

		public static string LBL_EAINFO_ATTRVAE { get { return GetResourceString("LBL_EAINFO_ATTRVAE"); } }

		public static string LBL_EAINFO_ATTSCALE { get { return GetResourceString("LBL_EAINFO_ATTSCALE"); } }

		public static string LBL_EAINFO_ATTWIDTH { get { return GetResourceString("LBL_EAINFO_ATTWIDTH"); } }

		public static string LBL_EAINFO_BEGDATEA { get { return GetResourceString("LBL_EAINFO_BEGDATEA"); } }

		public static string LBL_EAINFO_CODESET { get { return GetResourceString("LBL_EAINFO_CODESET"); } }

		public static string LBL_EAINFO_CODESETN { get { return GetResourceString("LBL_EAINFO_CODESETN"); } }

		public static string LBL_EAINFO_CODESETS { get { return GetResourceString("LBL_EAINFO_CODESETS"); } }

		public static string LBL_EAINFO_DETAILS { get { return GetResourceString("LBL_EAINFO_DETAILS"); } }

		public static string LBL_EAINFO_ENDDATEA { get { return GetResourceString("LBL_EAINFO_ENDDATEA"); } }

		public static string LBL_EAINFO_ENTTYPC { get { return GetResourceString("LBL_EAINFO_ENTTYPC"); } }

		public static string LBL_EAINFO_ENTTYPD { get { return GetResourceString("LBL_EAINFO_ENTTYPD"); } }

		public static string LBL_EAINFO_ENTTYPDS { get { return GetResourceString("LBL_EAINFO_ENTTYPDS"); } }

		public static string LBL_EAINFO_ENTTYPL { get { return GetResourceString("LBL_EAINFO_ENTTYPL"); } }

		public static string LBL_EAINFO_ENTTYPT { get { return GetResourceString("LBL_EAINFO_ENTTYPT"); } }

		public static string LBL_EAINFO_ENUM_DEF { get { return GetResourceString("LBL_EAINFO_ENUM_DEF"); } }

		public static string LBL_EAINFO_ENUM_DOMAIN { get { return GetResourceString("LBL_EAINFO_ENUM_DOMAIN"); } }

		public static string LBL_EAINFO_ENUM_SOURCE { get { return GetResourceString("LBL_EAINFO_ENUM_SOURCE"); } }

		public static string LBL_EAINFO_ENUM_VALUE { get { return GetResourceString("LBL_EAINFO_ENUM_VALUE"); } }

		public static string LBL_EAINFO_RANGE_DOMAIN { get { return GetResourceString("LBL_EAINFO_RANGE_DOMAIN"); } }

		public static string LBL_EAINFO_RDOMMAX { get { return GetResourceString("LBL_EAINFO_RDOMMAX"); } }

		public static string LBL_EAINFO_RDOMMEAN { get { return GetResourceString("LBL_EAINFO_RDOMMEAN"); } }

		public static string LBL_EAINFO_RDOMMIN { get { return GetResourceString("LBL_EAINFO_RDOMMIN"); } }

		public static string LBL_EAINFO_RDOMSTDV { get { return GetResourceString("LBL_EAINFO_RDOMSTDV"); } }

		public static string LBL_EAINFO_UDOM { get { return GetResourceString("LBL_EAINFO_UDOM"); } }

		public static string LBL_RESOL_DIST { get { return GetResourceString("LBL_RESOL_DIST"); } }

		public static string LBL_SPATREF_CELLGEOM { get { return GetResourceString("LBL_SPATREF_CELLGEOM"); } }

		public static string LBL_SPATREF_CHKDESC { get { return GetResourceString("LBL_SPATREF_CHKDESC"); } }

		public static string LBL_SPATREF_CHKPT { get { return GetResourceString("LBL_SPATREF_CHKPT"); } }

		public static string LBL_SPATREF_CONPT { get { return GetResourceString("LBL_SPATREF_CONPT"); } }

		public static string LBL_SPATREF_DIMNAME { get { return GetResourceString("LBL_SPATREF_DIMNAME"); } }

		public static string LBL_SPATREF_DIMRES { get { return GetResourceString("LBL_SPATREF_DIMRES"); } }

		public static string LBL_SPATREF_DIMSIZE { get { return GetResourceString("LBL_SPATREF_DIMSIZE"); } }

		public static string LBL_SPATREF_GEOOBJ { get { return GetResourceString("LBL_SPATREF_GEOOBJ"); } }

		public static string LBL_SPATREF_GEOREC { get { return GetResourceString("LBL_SPATREF_GEOREC"); } }

		public static string LBL_SPATREF_GEOREF { get { return GetResourceString("LBL_SPATREF_GEOREF"); } }

		public static string LBL_SPATREF_GEOREFPARAMS { get { return GetResourceString("LBL_SPATREF_GEOREFPARAMS"); } }

		public static string LBL_SPATREF_GRID { get { return GetResourceString("LBL_SPATREF_GRID"); } }

		public static string LBL_SPATREF_NUMDIM { get { return GetResourceString("LBL_SPATREF_NUMDIM"); } }

		public static string LBL_SPATREF_ORAVAIL { get { return GetResourceString("LBL_SPATREF_ORAVAIL"); } }

		public static string LBL_SPATREF_ORDESC { get { return GetResourceString("LBL_SPATREF_ORDESC"); } }

		public static string LBL_SPATREF_POINTPIXEL { get { return GetResourceString("LBL_SPATREF_POINTPIXEL"); } }

		public static string LBL_SPATREF_TOPLEVEL { get { return GetResourceString("LBL_SPATREF_TOPLEVEL"); } }

		public static string LBL_SPATREF_TRANS { get { return GetResourceString("LBL_SPATREF_TRANS"); } }

		public static string LBL_SPATREF_TRANSDIMDESC { get { return GetResourceString("LBL_SPATREF_TRANSDIMDESC"); } }

		public static string LBL_SPATREF_TRANSDIMMAP { get { return GetResourceString("LBL_SPATREF_TRANSDIMMAP"); } }

		public static string LBL_SPATREF_VEC { get { return GetResourceString("LBL_SPATREF_VEC"); } }

		public static string SEC_EAINFO { get { return GetResourceString("SEC_EAINFO"); } }

		public static string SEC_SPATREF { get { return GetResourceString("SEC_SPATREF"); } }

		public static string LBL_TOOL_SUMMARY { get { return GetResourceString("LBL_TOOL_SUMMARY"); } }

		public static string SEC_TOOL { get { return GetResourceString("SEC_TOOL"); } }

		public static string TT_NAP_fileIdentifier { get { return GetResourceString("TT_NAP_fileIdentifier"); } }

		public static string TT_NAP_parentIdentifier { get { return GetResourceString("TT_NAP_parentIdentifier"); } }

		public static string LBL_PRHIST_CMD { get { return GetResourceString("LBL_PRHIST_CMD"); } }

		public static string LBL_PRHIST_EXPORT { get { return GetResourceString("LBL_PRHIST_EXPORT"); } }

		public static string LBL_PRHIST_NAME { get { return GetResourceString("LBL_PRHIST_NAME"); } }

		public static string LBL_PRHIST_SOURCE { get { return GetResourceString("LBL_PRHIST_SOURCE"); } }

		public static string LBL_TOOL_EXPL { get { return GetResourceString("LBL_TOOL_EXPL"); } }

		public static string LBL_TOOL_EXPR { get { return GetResourceString("LBL_TOOL_EXPR"); } }

		public static string LBL_TOOL_SCRIPTREF { get { return GetResourceString("LBL_TOOL_SCRIPTREF"); } }

		public static string SEC_PROCESSHISTORY { get { return GetResourceString("SEC_PROCESSHISTORY"); } }

		public static string MSGBOX_SAVE_CAPTION { get { return GetResourceString("MSGBOX_SAVE_CAPTION"); } }

		public static string MSGBOX_SAVE_MSG { get { return GetResourceString("MSGBOX_SAVE_MSG"); } }

		public static string MSG_CONFIGFILE_ERROR { get { return GetResourceString("MSG_CONFIGFILE_ERROR"); } }

		public static string MSG_BAD_SOURCE_XML { get { return GetResourceString("MSG_BAD_SOURCE_XML"); } }

		public static string MSG_UNSUPPORTED_OBJECT { get { return GetResourceString("MSG_UNSUPPORTED_OBJECT"); } }

		public static string MSG_XSLT_ERROR { get { return GetResourceString("MSG_XSLT_ERROR"); } }

		public static string MSG_XSLT_TRANSFORM_ERROR { get { return GetResourceString("MSG_XSLT_TRANSFORM_ERROR"); } }

		public static string LBL_TOOL_DIALOGREF { get { return GetResourceString("LBL_TOOL_DIALOGREF"); } }

		public static string TT_NAP_abstract { get { return GetResourceString("TT_NAP_abstract"); } }

		public static string TT_NAP_credit { get { return GetResourceString("TT_NAP_credit"); } }

		public static string TT_NAP_purpose { get { return GetResourceString("TT_NAP_purpose"); } }

		public static string TT_NAP_theme { get { return GetResourceString("TT_NAP_theme"); } }

		public static string TT_NAP_title { get { return GetResourceString("TT_NAP_title"); } }

		public static string MSGBOX_SAVE_ERR_MSG { get { return GetResourceString("MSGBOX_SAVE_ERR_MSG"); } }

		public static string MSGBOX_SYNC_ERR_MSG { get { return GetResourceString("MSGBOX_SYNC_ERR_MSG"); } }

		public static string TT_RTB_HYPERLINK { get { return GetResourceString("TT_RTB_HYPERLINK"); } }

		public static string LBL_TOOL_SYNTAX { get { return GetResourceString("LBL_TOOL_SYNTAX"); } }

		public static string LBL_TOOL_USAGE { get { return GetResourceString("LBL_TOOL_USAGE"); } }

		public static string BTN_ADD_TOOL_EXAMPLE { get { return GetResourceString("BTN_ADD_TOOL_EXAMPLE"); } }

		public static string LBL_TOOL_CODE { get { return GetResourceString("LBL_TOOL_CODE"); } }

		public static string LBL_TOOL_EXAMPLE { get { return GetResourceString("LBL_TOOL_EXAMPLE"); } }

		public static string LBL_TOOL_EXAMPLES { get { return GetResourceString("LBL_TOOL_EXAMPLES"); } }

		public static string LBL_TOOL_TITLE { get { return GetResourceString("LBL_TOOL_TITLE"); } }

		public static string BTN_GP_NEW_DIALOGREF { get { return GetResourceString("BTN_GP_NEW_DIALOGREF"); } }

		public static string BTN_GP_NEW_PYREF { get { return GetResourceString("BTN_GP_NEW_PYREF"); } }

		public static string MSGBOX_DELETE_CAPTION { get { return GetResourceString("MSGBOX_DELETE_CAPTION"); } }

		public static string MSGBOX_DELETE_MSG { get { return GetResourceString("MSGBOX_DELETE_MSG"); } }

		public static string BTN_THUMB_REPLACE { get { return GetResourceString("BTN_THUMB_REPLACE"); } }

		public static string SBAR_ITEMINFO { get { return GetResourceString("SBAR_ITEMINFO"); } }

		public static string BTN_THUMB_DELETE { get { return GetResourceString("BTN_THUMB_DELETE"); } }

		public static string MSG_METADATA_MISSING { get { return GetResourceString("MSG_METADATA_MISSING"); } }

		public static string XSLT_RES_NOTFOUND { get { return GetResourceString("XSLT_RES_NOTFOUND"); } }

		public static string CFG_LBL_CONTENTINFORMATION { get { return GetResourceString("CFG_LBL_CONTENTINFORMATION"); } }

		public static string CFG_LBL_DATAQUALITY { get { return GetResourceString("CFG_LBL_DATAQUALITY"); } }

		public static string CFG_LBL_DATASETCITATION { get { return GetResourceString("CFG_LBL_DATASETCITATION"); } }

		public static string CFG_LBL_DISTRIBUTIONINFO { get { return GetResourceString("CFG_LBL_DISTRIBUTIONINFO"); } }

		public static string CFG_LBL_ENTITYATTRIBUTEINFO { get { return GetResourceString("CFG_LBL_ENTITYATTRIBUTEINFO"); } }

		public static string CFG_LBL_ITEMINFO { get { return GetResourceString("CFG_LBL_ITEMINFO"); } }

		public static string CFG_LBL_KEYWORDS { get { return GetResourceString("CFG_LBL_KEYWORDS"); } }

		public static string CFG_LBL_LILINEAGE { get { return GetResourceString("CFG_LBL_LILINEAGE"); } }

		public static string CFG_LBL_METADATA { get { return GetResourceString("CFG_LBL_METADATA"); } }

		public static string CFG_LBL_METADATACONSTRAINTS { get { return GetResourceString("CFG_LBL_METADATACONSTRAINTS"); } }

		public static string CFG_LBL_METADATACONTACTS { get { return GetResourceString("CFG_LBL_METADATACONTACTS"); } }

		public static string CFG_LBL_METADATADETAILS { get { return GetResourceString("CFG_LBL_METADATADETAILS"); } }

		public static string CFG_LBL_METADATAMAINTENANCE { get { return GetResourceString("CFG_LBL_METADATAMAINTENANCE"); } }

		public static string CFG_LBL_OVERVIEW { get { return GetResourceString("CFG_LBL_OVERVIEW"); } }

		public static string CFG_LBL_REFERENCESYSTEM { get { return GetResourceString("CFG_LBL_REFERENCESYSTEM"); } }

		public static string CFG_LBL_RESOUCEDETAILS { get { return GetResourceString("CFG_LBL_RESOUCEDETAILS"); } }

		public static string CFG_LBL_RESOURCE { get { return GetResourceString("CFG_LBL_RESOURCE"); } }

		public static string CFG_LBL_RESOURCECITATIONCONTACTS { get { return GetResourceString("CFG_LBL_RESOURCECITATIONCONTACTS"); } }

		public static string CFG_LBL_RESOURCECONSTRAINTS { get { return GetResourceString("CFG_LBL_RESOURCECONSTRAINTS"); } }

		public static string CFG_LBL_RESOURCEEXTENT { get { return GetResourceString("CFG_LBL_RESOURCEEXTENT"); } }

		public static string CFG_LBL_RESOURCEMAINTENANCE { get { return GetResourceString("CFG_LBL_RESOURCEMAINTENANCE"); } }

		public static string CFG_LBL_RESOURCEPOC { get { return GetResourceString("CFG_LBL_RESOURCEPOC"); } }

		public static string CFG_LBL_SPATIALREPRESENTATION { get { return GetResourceString("CFG_LBL_SPATIALREPRESENTATION"); } }

		public static string BTN_NEW_LOCALE { get { return GetResourceString("BTN_NEW_LOCALE"); } }

		public static string CFG_LBL_LOCALES { get { return GetResourceString("CFG_LBL_LOCALES"); } }

		public static string LBL_LOCALE_LOCALE { get { return GetResourceString("LBL_LOCALE_LOCALE"); } }

		public static string SEC_LOCALES { get { return GetResourceString("SEC_LOCALES"); } }

		public static string BTN_CONSTS_NEW_DIM { get { return GetResourceString("BTN_CONSTS_NEW_DIM"); } }

		public static string LBL_DIMENSION { get { return GetResourceString("LBL_DIMENSION"); } }

		public static string CFG_LBL_GEOPROCESSING { get { return GetResourceString("CFG_LBL_GEOPROCESSING"); } }

		public static string LBL_PROCESS { get { return GetResourceString("LBL_PROCESS"); } }

		public static string LBL_TOOLDATE { get { return GetResourceString("LBL_TOOLDATE"); } }

		public static string LBL_TOOLSOURCE { get { return GetResourceString("LBL_TOOLSOURCE"); } }

		public static string LBL_TOOLTIME { get { return GetResourceString("LBL_TOOLTIME"); } }

		public static string LBL_GEOPROCESSING_CMD { get { return GetResourceString("LBL_GEOPROCESSING_CMD"); } }

		public static string LBL_GEOPROCESSING_EXPORT { get { return GetResourceString("LBL_GEOPROCESSING_EXPORT"); } }

		public static string LBL_ENVDESC { get { return GetResourceString("LBL_ENVDESC"); } }

		public static string LBL_DQ_CONFORMREPORT { get { return GetResourceString("LBL_DQ_CONFORMREPORT"); } }

		public static string LBL_DQ_SPEC { get { return GetResourceString("LBL_DQ_SPEC"); } }

		public static string BTN_ADD_CITATION { get { return GetResourceString("BTN_ADD_CITATION"); } }

		public static string LBL_CI_CITATION { get { return GetResourceString("LBL_CI_CITATION"); } }

		public static string LBL_CI_PARTIES { get { return GetResourceString("LBL_CI_PARTIES"); } }

		public static string LBL_CI_PARTY { get { return GetResourceString("LBL_CI_PARTY"); } }

		public static string LBL_DQ_CNFRMEXPLAIN { get { return GetResourceString("LBL_DQ_CNFRMEXPLAIN"); } }

		public static string LBL_DQ_ERRORSTAT { get { return GetResourceString("LBL_DQ_ERRORSTAT"); } }

		public static string LBL_DQ_PASS { get { return GetResourceString("LBL_DQ_PASS"); } }

		public static string LBL_DQ_QUANRESULT { get { return GetResourceString("LBL_DQ_QUANRESULT"); } }

		public static string LBL_DQ_VALTYPE { get { return GetResourceString("LBL_DQ_VALTYPE"); } }

		public static string LBL_DQ_VALUNIT { get { return GetResourceString("LBL_DQ_VALUNIT"); } }

		public static string LBL_DQ_VALUE { get { return GetResourceString("LBL_DQ_VALUE"); } }

		public static string LBL_MED_NOTE { get { return GetResourceString("LBL_MED_NOTE"); } }

		public static string BTN_NEW_USAGE { get { return GetResourceString("BTN_NEW_USAGE"); } }

		public static string LBL_GML_POINT_DESC { get { return GetResourceString("LBL_GML_POINT_DESC"); } }

		public static string LBL_GML_POINT_DESCREF { get { return GetResourceString("LBL_GML_POINT_DESCREF"); } }

		public static string LBL_GML_POINT_ID { get { return GetResourceString("LBL_GML_POINT_ID"); } }

		public static string LBL_GML_POINT_ID_CODESPACE { get { return GetResourceString("LBL_GML_POINT_ID_CODESPACE"); } }

		public static string LBL_GML_POINT_POS { get { return GetResourceString("LBL_GML_POINT_POS"); } }

		public static string LBL_SPATREF_CENTER { get { return GetResourceString("LBL_SPATREF_CENTER"); } }

		public static string LBL_USAGE { get { return GetResourceString("LBL_USAGE"); } }

		public static string LBL_USAGE_DATE { get { return GetResourceString("LBL_USAGE_DATE"); } }

		public static string LBL_USAGE_LIM { get { return GetResourceString("LBL_USAGE_LIM"); } }

		public static string LBL_USAGE_SPEC { get { return GetResourceString("LBL_USAGE_SPEC"); } }

		public static string LBL_SPATREF_PARAMCIT { get { return GetResourceString("LBL_SPATREF_PARAMCIT"); } }

		public static string SEC_SV_DETAILS { get { return GetResourceString("SEC_SV_DETAILS"); } }

		public static string BTN_NEW_FEATURE_TYPE { get { return GetResourceString("BTN_NEW_FEATURE_TYPE"); } }

		public static string BTN_NEW_SERVICE_TYPEVERSION { get { return GetResourceString("BTN_NEW_SERVICE_TYPEVERSION"); } }

		public static string BTN_SERVICE_NEW_EXT { get { return GetResourceString("BTN_SERVICE_NEW_EXT"); } }

		public static string CFG_LBL_SERVICES { get { return GetResourceString("CFG_LBL_SERVICES"); } }

		public static string LBL_GENERICNAME_CODESPACE { get { return GetResourceString("LBL_GENERICNAME_CODESPACE"); } }

		public static string LBL_GENERICNAME_NAME { get { return GetResourceString("LBL_GENERICNAME_NAME"); } }

		public static string LBL_SERVICE_ACCESSPROPS { get { return GetResourceString("LBL_SERVICE_ACCESSPROPS"); } }

		public static string LBL_SERVICE_EXTENT { get { return GetResourceString("LBL_SERVICE_EXTENT"); } }

		public static string LBL_SERVICE_SERVICETYPE { get { return GetResourceString("LBL_SERVICE_SERVICETYPE"); } }

		public static string LBL_SERVICE_SERVICETYPEVER { get { return GetResourceString("LBL_SERVICE_SERVICETYPEVER"); } }

		public static string BTN_SERVICE_NEW_COUPLEDRES { get { return GetResourceString("BTN_SERVICE_NEW_COUPLEDRES"); } }

		public static string LBL_SERVICE_COUPLEDRES { get { return GetResourceString("LBL_SERVICE_COUPLEDRES"); } }

		public static string LBL_SERVICE_COUPLEDRES_CODE { get { return GetResourceString("LBL_SERVICE_COUPLEDRES_CODE"); } }

		public static string LBL_SERVICE_COUPLEDRES_NAME { get { return GetResourceString("LBL_SERVICE_COUPLEDRES_NAME"); } }

		public static string LBL_SERVICE_COUPLINGTYPE { get { return GetResourceString("LBL_SERVICE_COUPLINGTYPE"); } }

		public static string LBL_NO_GEO_PROCESS { get { return GetResourceString("LBL_NO_GEO_PROCESS"); } }

		public static string BTN_LI_NEW_CITATION { get { return GetResourceString("BTN_LI_NEW_CITATION"); } }

		public static string BTN_NEW_PARAM_CITATION { get { return GetResourceString("BTN_NEW_PARAM_CITATION"); } }

		public static string LBL_DQ_EVALMETH { get { return GetResourceString("LBL_DQ_EVALMETH"); } }

		public static string LBL_DQ_MEASURE { get { return GetResourceString("LBL_DQ_MEASURE"); } }

		public static string CMB_UNRECOGNIZED_VALUE { get { return GetResourceString("CMB_UNRECOGNIZED_VALUE"); } }

		public static string LBL_BTN_CREATE_GUID { get { return GetResourceString("LBL_BTN_CREATE_GUID"); } }

		public static string BTN_KEY_NEW_PRODUCT { get { return GetResourceString("BTN_KEY_NEW_PRODUCT"); } }

		public static string BTN_KEY_NEW_SUBTOPIC { get { return GetResourceString("BTN_KEY_NEW_SUBTOPIC"); } }

		public static string LBL_DATE_NAP_ADOPTED { get { return GetResourceString("LBL_DATE_NAP_ADOPTED"); } }

		public static string LBL_DATE_NAP_DEPRECATED { get { return GetResourceString("LBL_DATE_NAP_DEPRECATED"); } }

		public static string LBL_DATE_NAP_INFORCE { get { return GetResourceString("LBL_DATE_NAP_INFORCE"); } }

		public static string LBL_DATE_NAP_NOT_AVAIL { get { return GetResourceString("LBL_DATE_NAP_NOT_AVAIL"); } }

		public static string LBL_DATE_NAP_SUPERSEDED { get { return GetResourceString("LBL_DATE_NAP_SUPERSEDED"); } }

		public static string LBL_DESC_PRODUCTKEY { get { return GetResourceString("LBL_DESC_PRODUCTKEY"); } }

		public static string LBL_DESC_SUBTOPICKEY { get { return GetResourceString("LBL_DESC_SUBTOPICKEY"); } }

		public static string LBL_META_NAP_COUNTRY { get { return GetResourceString("LBL_META_NAP_COUNTRY"); } }

		public static string LBL_RES_LANGS { get { return GetResourceString("LBL_RES_LANGS"); } }

		public static string BTN_RICHTEXT_APPLY { get { return GetResourceString("BTN_RICHTEXT_APPLY"); } }

		public static string BTN_RICHTEXT_URL { get { return GetResourceString("BTN_RICHTEXT_URL"); } }

		public static string LBL_EXT_DESC { get { return GetResourceString("LBL_EXT_DESC"); } }

		public static string LBL_SPATREF_EXTYPECODE { get { return GetResourceString("LBL_SPATREF_EXTYPECODE"); } }

		public static string LBL_SPATREF_EXTYPECODE1 { get { return GetResourceString("LBL_SPATREF_EXTYPECODE1"); } }

		public static string LBL_SPATREF_EXTYPECODE2 { get { return GetResourceString("LBL_SPATREF_EXTYPECODE2"); } }

		public static string BTN_EXIT { get { return GetResourceString("BTN_EXIT"); } }

		public static string LBL_EAINFO_ENTITY_TYPE { get { return GetResourceString("LBL_EAINFO_ENTITY_TYPE"); } }

		public static string LBL_ISS_LOCALONLY { get { return GetResourceString("LBL_ISS_LOCALONLY"); } }

		public static string LBL_ISS_NO_INFO { get { return GetResourceString("LBL_ISS_NO_INFO"); } }

		public static string BTN_VALIDATE_PAGE { get { return GetResourceString("BTN_VALIDATE_PAGE"); } }

		public static string LBL_VALIDATE_NO_ERRORS { get { return GetResourceString("LBL_VALIDATE_NO_ERRORS"); } }

		public static string MSG_BAD_CONFIGDOC { get { return GetResourceString("MSG_BAD_CONFIGDOC"); } }

		public static string CFG_LBL_CONTACT_MGR { get { return GetResourceString("CFG_LBL_CONTACT_MGR"); } }

		public static string BTN_NEW_AGG_INFO { get { return GetResourceString("BTN_NEW_AGG_INFO"); } }

		public static string SEC_CONTACT_MGR { get { return GetResourceString("SEC_CONTACT_MGR"); } }

		public static string BTN_NEW_PORTRAYAL_CIT { get { return GetResourceString("BTN_NEW_PORTRAYAL_CIT"); } }

		public static string CFG_LBL_RES_REF { get { return GetResourceString("CFG_LBL_RES_REF"); } }

		public static string LBL_AGG_ID { get { return GetResourceString("LBL_AGG_ID"); } }

		public static string LBL_AGG_INFO { get { return GetResourceString("LBL_AGG_INFO"); } }

		public static string LBL_AGG_NAME { get { return GetResourceString("LBL_AGG_NAME"); } }

		public static string LBL_AGG_TYPE { get { return GetResourceString("LBL_AGG_TYPE"); } }

		public static string LBL_DIGOPT_DENSITY { get { return GetResourceString("LBL_DIGOPT_DENSITY"); } }

		public static string LBL_MD_PORTRAYAL { get { return GetResourceString("LBL_MD_PORTRAYAL"); } }

		public static string LBL_PORTRAYAL_CIT { get { return GetResourceString("LBL_PORTRAYAL_CIT"); } }

		public static string LBL_SPATREF_CORNER { get { return GetResourceString("LBL_SPATREF_CORNER"); } }

		public static string LBL_SUPPINFO { get { return GetResourceString("LBL_SUPPINFO"); } }

		public static string SEC_RES_REF { get { return GetResourceString("SEC_RES_REF"); } }

		public static string BTN_EXTENTS_NEW_TEMP { get { return GetResourceString("BTN_EXTENTS_NEW_TEMP"); } }

		public static string LBL_EXT_SING_DATE { get { return GetResourceString("LBL_EXT_SING_DATE"); } }

		public static string LBL_EXT_TEMP { get { return GetResourceString("LBL_EXT_TEMP"); } }

		public static string LBL_EXT_TEMP_BEG { get { return GetResourceString("LBL_EXT_TEMP_BEG"); } }

		public static string LBL_EXT_TEMP_END { get { return GetResourceString("LBL_EXT_TEMP_END"); } }

		public static string LBL_EXT_TEMP_PERIOD { get { return GetResourceString("LBL_EXT_TEMP_PERIOD"); } }

		public static string LBL_SCALE_SCALE { get { return GetResourceString("LBL_SCALE_SCALE"); } }

		public static string SCALE_BUILDINGS_LABEL { get { return GetResourceString("SCALE_BUILDINGS_LABEL"); } }

		public static string SCALE_BUILDINGS_NUM { get { return GetResourceString("SCALE_BUILDINGS_NUM"); } }

		public static string SCALE_BUILDING_LABEL { get { return GetResourceString("SCALE_BUILDING_LABEL"); } }

		public static string SCALE_BUILDING_NUM { get { return GetResourceString("SCALE_BUILDING_NUM"); } }

		public static string SCALE_CITIES_LABEL { get { return GetResourceString("SCALE_CITIES_LABEL"); } }

		public static string SCALE_CITIES_NUM { get { return GetResourceString("SCALE_CITIES_NUM"); } }

		public static string SCALE_CITY_BLOCKS_LABEL { get { return GetResourceString("SCALE_CITY_BLOCKS_LABEL"); } }

		public static string SCALE_CITY_BLOCKS_NUM { get { return GetResourceString("SCALE_CITY_BLOCKS_NUM"); } }

		public static string SCALE_CITY_BLOCK_LABEL { get { return GetResourceString("SCALE_CITY_BLOCK_LABEL"); } }

		public static string SCALE_CITY_BLOCK_NUM { get { return GetResourceString("SCALE_CITY_BLOCK_NUM"); } }

		public static string SCALE_CITY_LABEL { get { return GetResourceString("SCALE_CITY_LABEL"); } }

		public static string SCALE_CITY_NUM { get { return GetResourceString("SCALE_CITY_NUM"); } }

		public static string SCALE_CONTINENT_LABEL { get { return GetResourceString("SCALE_CONTINENT_LABEL"); } }

		public static string SCALE_CONTINENT_NUM { get { return GetResourceString("SCALE_CONTINENT_NUM"); } }

		public static string SCALE_COUNTIES_LABEL { get { return GetResourceString("SCALE_COUNTIES_LABEL"); } }

		public static string SCALE_COUNTIES_NUM { get { return GetResourceString("SCALE_COUNTIES_NUM"); } }

		public static string SCALE_COUNTRIES_LABEL { get { return GetResourceString("SCALE_COUNTRIES_LABEL"); } }

		public static string SCALE_COUNTRIES_NUM { get { return GetResourceString("SCALE_COUNTRIES_NUM"); } }

		public static string SCALE_COUNTRY_LABEL { get { return GetResourceString("SCALE_COUNTRY_LABEL"); } }

		public static string SCALE_COUNTRY_NUM { get { return GetResourceString("SCALE_COUNTRY_NUM"); } }

		public static string SCALE_COUNTY_LABEL { get { return GetResourceString("SCALE_COUNTY_LABEL"); } }

		public static string SCALE_COUNTY_NUM { get { return GetResourceString("SCALE_COUNTY_NUM"); } }

		public static string SCALE_GLOBE_LABEL { get { return GetResourceString("SCALE_GLOBE_LABEL"); } }

		public static string SCALE_GLOBE_NUM { get { return GetResourceString("SCALE_GLOBE_NUM"); } }

		public static string SCALE_HOUSES_LABEL { get { return GetResourceString("SCALE_HOUSES_LABEL"); } }

		public static string SCALE_HOUSES_NUM { get { return GetResourceString("SCALE_HOUSES_NUM"); } }

		public static string SCALE_HOUSE_LABEL { get { return GetResourceString("SCALE_HOUSE_LABEL"); } }

		public static string SCALE_HOUSE_NUM { get { return GetResourceString("SCALE_HOUSE_NUM"); } }

		public static string SCALE_HOUSE_PROPERTY_LABEL { get { return GetResourceString("SCALE_HOUSE_PROPERTY_LABEL"); } }

		public static string SCALE_HOUSE_PROPERTY_NUM { get { return GetResourceString("SCALE_HOUSE_PROPERTY_NUM"); } }

		public static string SCALE_METRO_AREA_LABEL { get { return GetResourceString("SCALE_METRO_AREA_LABEL"); } }

		public static string SCALE_METRO_AREA_NUM { get { return GetResourceString("SCALE_METRO_AREA_NUM"); } }

		public static string SCALE_NEIGHBORHOOD_LABEL { get { return GetResourceString("SCALE_NEIGHBORHOOD_LABEL"); } }

		public static string SCALE_NEIGHBORHOOD_NUM { get { return GetResourceString("SCALE_NEIGHBORHOOD_NUM"); } }

		public static string SCALE_PREFIX { get { return GetResourceString("SCALE_PREFIX"); } }

		public static string SCALE_ROOMS_LABEL { get { return GetResourceString("SCALE_ROOMS_LABEL"); } }

		public static string SCALE_ROOMS_NUM { get { return GetResourceString("SCALE_ROOMS_NUM"); } }

		public static string SCALE_ROOM_LABEL { get { return GetResourceString("SCALE_ROOM_LABEL"); } }

		public static string SCALE_ROOM_NUM { get { return GetResourceString("SCALE_ROOM_NUM"); } }

		public static string SCALE_STATES_LABEL { get { return GetResourceString("SCALE_STATES_LABEL"); } }

		public static string SCALE_STATES_NUM { get { return GetResourceString("SCALE_STATES_NUM"); } }

		public static string SCALE_STATE_LABEL { get { return GetResourceString("SCALE_STATE_LABEL"); } }

		public static string SCALE_STATE_NUM { get { return GetResourceString("SCALE_STATE_NUM"); } }

		public static string SCALE_TOWN_LABEL { get { return GetResourceString("SCALE_TOWN_LABEL"); } }

		public static string SCALE_TOWN_NUM { get { return GetResourceString("SCALE_TOWN_NUM"); } }

		public static string BTN_MAINT_NEW_SCOPE { get { return GetResourceString("BTN_MAINT_NEW_SCOPE"); } }

		public static string BTN_SPATREF_GEOOBJECTS { get { return GetResourceString("BTN_SPATREF_GEOOBJECTS"); } }

		public static string BTN_LOAD_CONTACT { get { return GetResourceString("BTN_LOAD_CONTACT"); } }

		public static string LBL_TOOL_SIDEBARHELPIMAGE { get { return GetResourceString("LBL_TOOL_SIDEBARHELPIMAGE"); } }

		public static string LBL_CI_PARTY_PICK { get { return GetResourceString("LBL_CI_PARTY_PICK"); } }

		public static string BTN_EXTENTS_NEW_VERT { get { return GetResourceString("BTN_EXTENTS_NEW_VERT"); } }

		public static string BTN_NEW_APP_SCHEMA { get { return GetResourceString("BTN_NEW_APP_SCHEMA"); } }

		public static string LBL_APP_SCHEMA { get { return GetResourceString("LBL_APP_SCHEMA"); } }

		public static string LBL_APP_SCHEMA_ASCII { get { return GetResourceString("LBL_APP_SCHEMA_ASCII"); } }

		public static string LBL_APP_SCHEMA_CONSTRAINT_LANG { get { return GetResourceString("LBL_APP_SCHEMA_CONSTRAINT_LANG"); } }

		public static string LBL_APP_SCHEMA_GRAPHICS { get { return GetResourceString("LBL_APP_SCHEMA_GRAPHICS"); } }

		public static string LBL_APP_SCHEMA_LANG { get { return GetResourceString("LBL_APP_SCHEMA_LANG"); } }

		public static string LBL_APP_SCHEMA_NAME { get { return GetResourceString("LBL_APP_SCHEMA_NAME"); } }

		public static string LBL_APP_SCHEMA_SOFTWARE { get { return GetResourceString("LBL_APP_SCHEMA_SOFTWARE"); } }

		public static string LBL_APP_SCHEMA_SOFTWARE_FORMAT { get { return GetResourceString("LBL_APP_SCHEMA_SOFTWARE_FORMAT"); } }

		public static string LBL_CI_LOAD_DISTRIBUTOR { get { return GetResourceString("LBL_CI_LOAD_DISTRIBUTOR"); } }

		public static string LBL_CI_LOAD_MAINT_CONTACT { get { return GetResourceString("LBL_CI_LOAD_MAINT_CONTACT"); } }

		public static string LBL_CI_LOAD_META_CONTACT { get { return GetResourceString("LBL_CI_LOAD_META_CONTACT"); } }

		public static string LBL_CI_LOAD_POC_CONTACT { get { return GetResourceString("LBL_CI_LOAD_POC_CONTACT"); } }

		public static string LBL_CI_LOAD_PROCESSOR { get { return GetResourceString("LBL_CI_LOAD_PROCESSOR"); } }

		public static string LBL_CI_LOAD_USAGE_CONTACT { get { return GetResourceString("LBL_CI_LOAD_USAGE_CONTACT"); } }

		public static string LBL_EXT_VERT { get { return GetResourceString("LBL_EXT_VERT"); } }

		public static string LBL_EXT_VERT_MAX { get { return GetResourceString("LBL_EXT_VERT_MAX"); } }

		public static string LBL_EXT_VERT_MIN { get { return GetResourceString("LBL_EXT_VERT_MIN"); } }

		public static string BTN_EXTENTS_NEW_TEMP_INSTANT { get { return GetResourceString("BTN_EXTENTS_NEW_TEMP_INSTANT"); } }

		public static string LBL_EXT_TEMPINSTANT { get { return GetResourceString("LBL_EXT_TEMPINSTANT"); } }

		public static string LBL_EXT_TEMP_INSTANT { get { return GetResourceString("LBL_EXT_TEMP_INSTANT"); } }

		public static string LBL_ADDRESS_TYPE { get { return GetResourceString("LBL_ADDRESS_TYPE"); } }

		public static string LBL_FGDC_GEOFORM { get { return GetResourceString("LBL_FGDC_GEOFORM"); } }

		public static string BTN_NEW_OVERVIEW { get { return GetResourceString("BTN_NEW_OVERVIEW"); } }

		public static string LBL_EAINFO_OVERVIEW { get { return GetResourceString("LBL_EAINFO_OVERVIEW"); } }

		public static string LBL_FMTK_INFO { get { return GetResourceString("LBL_FMTK_INFO"); } }

		public static string BTN_SPATREF_NEW_IND { get { return GetResourceString("BTN_SPATREF_NEW_IND"); } }

		public static string LBL_CONT_TDDTTY { get { return GetResourceString("LBL_CONT_TDDTTY"); } }

		public static string LBL_EAINFO_OVERCIT { get { return GetResourceString("LBL_EAINFO_OVERCIT"); } }

		public static string LBL_EAINFO_SUMMARY { get { return GetResourceString("LBL_EAINFO_SUMMARY"); } }

		public static string LBL_SPATREF_IND { get { return GetResourceString("LBL_SPATREF_IND"); } }

		public static string LBL_DATES_OTHER { get { return GetResourceString("LBL_DATES_OTHER"); } }

		public static string LBL_DQ_REPORTDIM { get { return GetResourceString("LBL_DQ_REPORTDIM"); } }

		public static string LBL_LI_SOURCE_TYPE { get { return GetResourceString("LBL_LI_SOURCE_TYPE"); } }

		public static string LBL_STD_AVAILDATEPERIOD { get { return GetResourceString("LBL_STD_AVAILDATEPERIOD"); } }

		public static string LBL_AGG_INIT_TYPE { get { return GetResourceString("LBL_AGG_INIT_TYPE"); } }

		public static string BTN_EAINFO_NEW_CIT { get { return GetResourceString("BTN_EAINFO_NEW_CIT"); } }

		public static string MSGBOX_UPGRADE { get { return GetResourceString("MSGBOX_UPGRADE"); } }

		public static string MSGBOX_UPGRADE_CAPTION { get { return GetResourceString("MSGBOX_UPGRADE_CAPTION"); } }

		public static string MSGBOX_UPGRADE_LINK { get { return GetResourceString("MSGBOX_UPGRADE_LINK"); } }

		public static string MSGBOX_UPGRADE_OPTION { get { return GetResourceString("MSGBOX_UPGRADE_OPTION"); } }

		public static string LBL_LOCALE_ABSTRACT { get { return GetResourceString("LBL_LOCALE_ABSTRACT"); } }

		public static string LBL_RS_DIMENSION { get { return GetResourceString("LBL_RS_DIMENSION"); } }

		public static string BTN_ADD_CONTACT_INFO { get { return GetResourceString("BTN_ADD_CONTACT_INFO"); } }

		public static string BTN_ADD_DQ_CONF_RESULTS { get { return GetResourceString("BTN_ADD_DQ_CONF_RESULTS"); } }

		public static string BTN_ADD_DQ_QUAN_RESULTS { get { return GetResourceString("BTN_ADD_DQ_QUAN_RESULTS"); } }

		public static string BTN_ADD_ONLINE_RES { get { return GetResourceString("BTN_ADD_ONLINE_RES"); } }

		public static string LBL_ITEMINFO_THUMB { get { return GetResourceString("LBL_ITEMINFO_THUMB"); } }

		public static string LBL_IMS_CONTENT_TYPE { get { return GetResourceString("LBL_IMS_CONTENT_TYPE"); } }

		public static string LBL_IMS_CONTENT_TYPE_EXPORT { get { return GetResourceString("LBL_IMS_CONTENT_TYPE_EXPORT"); } }

		public static string LBL_ITEMINFO_EXTENT { get { return GetResourceString("LBL_ITEMINFO_EXTENT"); } }

		public static string LBL_APP_SCHEMA_GRAPHICS_SRC { get { return GetResourceString("LBL_APP_SCHEMA_GRAPHICS_SRC"); } }

		public static string LBL_APP_SCHEMA_SOFTWARE_SRC { get { return GetResourceString("LBL_APP_SCHEMA_SOFTWARE_SRC"); } }

		public static string MSGBOX_SAVEUPGRADE_CAPTION { get { return GetResourceString("MSGBOX_SAVEUPGRADE_CAPTION"); } }

		public static string MSGBOX_SAVEUPGRADE_MSG { get { return GetResourceString("MSGBOX_SAVEUPGRADE_MSG"); } }

		public static string BTN_ADD_AGG_CIT { get { return GetResourceString("BTN_ADD_AGG_CIT"); } }

		public static string BTN_ADD_AGG_ID { get { return GetResourceString("BTN_ADD_AGG_ID"); } }

		public static string BTN_ADD_AUTH_CIT { get { return GetResourceString("BTN_ADD_AUTH_CIT"); } }

		public static string BTN_ADD_ID { get { return GetResourceString("BTN_ADD_ID"); } }

		public static string BTN_ADD_THESAURUS { get { return GetResourceString("BTN_ADD_THESAURUS"); } }

		public static string BTN_RES_NEW_FORMAT { get { return GetResourceString("BTN_RES_NEW_FORMAT"); } }

		public static string BTN_NEW_CORNER { get { return GetResourceString("BTN_NEW_CORNER"); } }

		public static string LBL_CI_Name { get { return GetResourceString("LBL_CI_Name"); } }

		public static string LBL_CI_Organization { get { return GetResourceString("LBL_CI_Organization"); } }

		public static string LBL_CI_Position { get { return GetResourceString("LBL_CI_Position"); } }

		public static string LBL_CI_Role { get { return GetResourceString("LBL_CI_Role"); } }

		public static string LBL_CM_Confirm { get { return GetResourceString("LBL_CM_Confirm"); } }

		public static string LBL_CM_ConfirmTitle { get { return GetResourceString("LBL_CM_ConfirmTitle"); } }

		public static string LBL_CM_Save { get { return GetResourceString("LBL_CM_Save"); } }

		public static string LBL_CI_PARTY_ADD_FORMAT { get { return GetResourceString("LBL_CI_PARTY_ADD_FORMAT"); } }

		public static string LBL_CI_PARTY_FORMAT { get { return GetResourceString("LBL_CI_PARTY_FORMAT"); } }

		public static string LBL_CI_PARTY_READONLY_FORMAT { get { return GetResourceString("LBL_CI_PARTY_READONLY_FORMAT"); } }

		public static string LBL_CI_PARTY_ROLE_UNKNOWN { get { return GetResourceString("LBL_CI_PARTY_ROLE_UNKNOWN"); } }

		public static string BTN_DQ_NEW_EVALPROC { get { return GetResourceString("BTN_DQ_NEW_EVALPROC"); } }

		public static string BTN_DQ_NEW_MEASID { get { return GetResourceString("BTN_DQ_NEW_MEASID"); } }

		public static string BTN_DQ_NEW_SRCREFSYS { get { return GetResourceString("BTN_DQ_NEW_SRCREFSYS"); } }

		public static string BTN_IMG_NEW_IMGQUAL { get { return GetResourceString("BTN_IMG_NEW_IMGQUAL"); } }

		public static string BTN_IMG_NEW_PROCLEVEL { get { return GetResourceString("BTN_IMG_NEW_PROCLEVEL"); } }

		public static string ProjectItemNoMetadata { get { return GetResourceString("ProjectItemNoMetadata"); } }

		public static string Save_Button_Enabled_ToolTip { get { return GetResourceString("Save_Button_Enabled_ToolTip"); } }

		public static string Save_Button_Disabled_ToolTip { get { return GetResourceString("Save_Button_Disabled_ToolTip"); } }

		public static string CategoryMetadata { get { return GetResourceString("CategoryMetadata"); } }

		public static string SaveMetadataOperationName { get { return GetResourceString("SaveMetadataOperationName"); } }

		public static string MSGBOX_APPLY_MSG { get { return GetResourceString("MSGBOX_APPLY_MSG"); } }

		public static string ITEM_INFO_LOCATION { get { return GetResourceString("ITEM_INFO_LOCATION"); } }

		public static string ITEM_INFO_TYPE { get { return GetResourceString("ITEM_INFO_TYPE"); } }

		public static string MD_SOURCE_NOT_EXIST_MSG { get { return GetResourceString("MD_SOURCE_NOT_EXIST_MSG"); } }

		public static string MD_SOURCE_NOT_EXIST_TITLE { get { return GetResourceString("MD_SOURCE_NOT_EXIST_TITLE"); } }

		public static string UNQUALIFIED_MD_HTML { get { return GetResourceString("UNQUALIFIED_MD_HTML"); } }

		public static string UNQUALIFIED_MD_ISO_19139 { get { return GetResourceString("UNQUALIFIED_MD_ISO_19139"); } }

		public static string UNQUALIFIED_MD_ISO_19139_2 { get { return GetResourceString("UNQUALIFIED_MD_ISO_19139_2"); } }

		public static string UNQUALIFIED_MD_OUTDATED_ESRI { get { return GetResourceString("UNQUALIFIED_MD_OUTDATED_ESRI"); } }

		public static string UNQUALIFIED_MD_OUTDATED_ESRI2 { get { return GetResourceString("UNQUALIFIED_MD_OUTDATED_ESRI2"); } }

		public static string UNQUALIFIED_MD_OUTDATED_FGDC { get { return GetResourceString("UNQUALIFIED_MD_OUTDATED_FGDC"); } }

		public static string UNQUALIFIED_MD_UNREC_MD { get { return GetResourceString("UNQUALIFIED_MD_UNREC_MD"); } }

		public static string Apply_Button_Disabled_ToolTip { get { return GetResourceString("Apply_Button_Disabled_ToolTip"); } }

		public static string Apply_Button_Enabled_ToolTip { get { return GetResourceString("Apply_Button_Enabled_ToolTip"); } }

		public static string Browse_Item_MD_Not_Supported { get { return GetResourceString("Browse_Item_MD_Not_Supported"); } }

		public static string ERROR_INVALID_XML { get { return GetResourceString("ERROR_INVALID_XML"); } }

		public static string UNQUALIFIED_MD_ROOT_ONLY { get { return GetResourceString("UNQUALIFIED_MD_ROOT_ONLY"); } }

		public static string MD_View_Content_Label { get { return GetResourceString("MD_View_Content_Label"); } }

		public static string BROWSER_TITLE_DESTINATION { get { return GetResourceString("BROWSER_TITLE_DESTINATION"); } }

		public static string BROWSER_SAVEAS_TITLE { get { return GetResourceString("BROWSER_SAVEAS_TITLE"); } }

		public static string EXPORT_MD_TITLE { get { return GetResourceString("EXPORT_MD_TITLE"); } }

		public static string IMPORT_MD_TITLE { get { return GetResourceString("IMPORT_MD_TITLE"); } }

		public static string MDExportMetadataFailureTitle { get { return GetResourceString("MDExportMetadataFailureTitle"); } }

		public static string MDImportMetadataFailureTitle { get { return GetResourceString("MDImportMetadataFailureTitle"); } }

		public static string MDSaveAsFailureTitle { get { return GetResourceString("MDSaveAsFailureTitle"); } }
	}
}
