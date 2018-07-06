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

using System.Threading;
using System.Web;

namespace ArcGIS.Desktop.Internal.Metadata.Properties
{
	internal class XsltResources
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ArcGIS.Desktop.Metadata.Properties.XsltResources", typeof(XsltResources).Assembly);
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
       
		
		public static string accessConsts { get { return GetResourceString("accessConsts"); } }

		public static string ApplicationSchema { get { return GetResourceString("ApplicationSchema"); } }

		public static string attribIntSet { get { return GetResourceString("attribIntSet"); } }

		public static string attribSet { get { return GetResourceString("attribSet"); } }

		public static string classification { get { return GetResourceString("classification"); } }

		public static string Consts { get { return GetResourceString("Consts"); } }

		public static string ContentInformation { get { return GetResourceString("ContentInformation"); } }

		public static string DataQuality { get { return GetResourceString("DataQuality"); } }

		public static string dataSet { get { return GetResourceString("dataSet"); } }

		public static string dataSetURI { get { return GetResourceString("dataSetURI"); } }

		public static string dateNext { get { return GetResourceString("dateNext"); } }

		public static string days { get { return GetResourceString("days"); } }

		public static string designator { get { return GetResourceString("designator"); } }

		public static string DistributionInformation { get { return GetResourceString("DistributionInformation"); } }

		public static string ESRIFieldsAndSubtypes { get { return GetResourceString("ESRIFieldsAndSubtypes"); } }

		public static string ESRIGeometricNetwork { get { return GetResourceString("ESRIGeometricNetwork"); } }

		public static string ESRIGeoprocessingHistory { get { return GetResourceString("ESRIGeoprocessingHistory"); } }

		public static string ESRILocator { get { return GetResourceString("ESRILocator"); } }

		public static string ESRIMetadataAndItemProperties { get { return GetResourceString("ESRIMetadataAndItemProperties"); } }

		public static string ESRIRaster { get { return GetResourceString("ESRIRaster"); } }

		public static string ESRITerrain { get { return GetResourceString("ESRITerrain"); } }

		public static string ESRIThumbnailsAndEnclosures { get { return GetResourceString("ESRIThumbnailsAndEnclosures"); } }

		public static string ESRITopology { get { return GetResourceString("ESRITopology"); } }

		public static string featIntSet { get { return GetResourceString("featIntSet"); } }

		public static string featSet { get { return GetResourceString("featSet"); } }

		public static string hours { get { return GetResourceString("hours"); } }

		public static string LegConsts { get { return GetResourceString("LegConsts"); } }

		public static string maintFreq { get { return GetResourceString("maintFreq"); } }

		public static string maintNote { get { return GetResourceString("maintNote"); } }

		public static string maintScp { get { return GetResourceString("maintScp"); } }

		public static string mdChar { get { return GetResourceString("mdChar"); } }

		public static string mdConst { get { return GetResourceString("mdConst"); } }

		public static string mdDateSt { get { return GetResourceString("mdDateSt"); } }

		public static string mdFileID { get { return GetResourceString("mdFileID"); } }

		public static string mdHrLv { get { return GetResourceString("mdHrLv"); } }

		public static string mdHrLvName { get { return GetResourceString("mdHrLvName"); } }

		public static string mdLang { get { return GetResourceString("mdLang"); } }

		public static string mdParentID { get { return GetResourceString("mdParentID"); } }

		public static string mdStanName { get { return GetResourceString("mdStanName"); } }

		public static string mdStanVer { get { return GetResourceString("mdStanVer"); } }

		public static string MetadataDetails { get { return GetResourceString("MetadataDetails"); } }

		public static string MetadataExtensions { get { return GetResourceString("MetadataExtensions"); } }

		public static string minutes { get { return GetResourceString("minutes"); } }

		public static string months { get { return GetResourceString("months"); } }

		public static string othConsts { get { return GetResourceString("othConsts"); } }

		public static string other { get { return GetResourceString("other"); } }

		public static string PortrayalCatalogue { get { return GetResourceString("PortrayalCatalogue"); } }

		public static string ReferenceSystem { get { return GetResourceString("ReferenceSystem"); } }

		public static string resMaint { get { return GetResourceString("resMaint"); } }

		public static string resOtherwise { get { return GetResourceString("resOtherwise"); } }

		public static string ResourceIdentification { get { return GetResourceString("ResourceIdentification"); } }

		public static string scpLvlDesc { get { return GetResourceString("scpLvlDesc"); } }

		public static string SecConsts { get { return GetResourceString("SecConsts"); } }

		public static string seconds { get { return GetResourceString("seconds"); } }

		public static string SpatialRepresentation { get { return GetResourceString("SpatialRepresentation"); } }

		public static string timeIndicator { get { return GetResourceString("timeIndicator"); } }

		public static string useConsts { get { return GetResourceString("useConsts"); } }

		public static string useLimit { get { return GetResourceString("useLimit"); } }

		public static string usrDefFreq { get { return GetResourceString("usrDefFreq"); } }

		public static string years { get { return GetResourceString("years"); } }

		public static string bgFileDesc { get { return GetResourceString("bgFileDesc"); } }

		public static string bgFileName { get { return GetResourceString("bgFileName"); } }

		public static string bgFileType { get { return GetResourceString("bgFileType"); } }

		public static string chkPtAv { get { return GetResourceString("chkPtAv"); } }

		public static string chkPtDesc { get { return GetResourceString("chkPtDesc"); } }

		public static string classSys { get { return GetResourceString("classSys"); } }

		public static string conversionToISOstandardUnit { get { return GetResourceString("conversionToISOstandardUnit"); } }

		public static string coordinates { get { return GetResourceString("coordinates"); } }

		public static string cornerPts { get { return GetResourceString("cornerPts"); } }

		public static string dataChar { get { return GetResourceString("dataChar"); } }

		public static string dataLang { get { return GetResourceString("dataLang"); } }

		public static string dataScale { get { return GetResourceString("dataScale"); } }

		public static string discKeys { get { return GetResourceString("discKeys"); } }

		public static string envirDesc { get { return GetResourceString("envirDesc"); } }

		public static string equScale { get { return GetResourceString("equScale"); } }

		public static string graphOver { get { return GetResourceString("graphOver"); } }

		public static string handDesc { get { return GetResourceString("handDesc"); } }

		public static string idAbs { get { return GetResourceString("idAbs"); } }

		public static string idCredit { get { return GetResourceString("idCredit"); } }

		public static string idPurp { get { return GetResourceString("idPurp"); } }

		public static string idSpecUse { get { return GetResourceString("idSpecUse"); } }

		public static string idStatus { get { return GetResourceString("idStatus"); } }

		public static string MdCoRefSys { get { return GetResourceString("MdCoRefSys"); } }

		public static string otherKeys { get { return GetResourceString("otherKeys"); } }

		public static string placeKeys { get { return GetResourceString("placeKeys"); } }

		public static string ptInPixel { get { return GetResourceString("ptInPixel"); } }

		public static string resConst { get { return GetResourceString("resConst"); } }

		public static string rfDenom { get { return GetResourceString("rfDenom"); } }

		public static string Scale { get { return GetResourceString("Scale"); } }

		public static string scaleDist { get { return GetResourceString("scaleDist"); } }

		public static string scaleOtherwise { get { return GetResourceString("scaleOtherwise"); } }

		public static string serType { get { return GetResourceString("serType"); } }

		public static string spatRpType { get { return GetResourceString("spatRpType"); } }

		public static string specUsage { get { return GetResourceString("specUsage"); } }

		public static string srcScale { get { return GetResourceString("srcScale"); } }

		public static string stratKeys { get { return GetResourceString("stratKeys"); } }

		public static string suppInfo { get { return GetResourceString("suppInfo"); } }

		public static string tempKeys { get { return GetResourceString("tempKeys"); } }

		public static string themeKeys { get { return GetResourceString("themeKeys"); } }

		public static string tpCat { get { return GetResourceString("tpCat"); } }

		public static string tranParaAv { get { return GetResourceString("tranParaAv"); } }

		public static string transDimDesc { get { return GetResourceString("transDimDesc"); } }

		public static string transDimMap { get { return GetResourceString("transDimMap"); } }

		public static string typeProps { get { return GetResourceString("typeProps"); } }

		public static string UomAngle { get { return GetResourceString("UomAngle"); } }

		public static string UomArea { get { return GetResourceString("UomArea"); } }

		public static string UomLength { get { return GetResourceString("UomLength"); } }

		public static string uomName { get { return GetResourceString("uomName"); } }

		public static string UomOtherwise { get { return GetResourceString("UomOtherwise"); } }

		public static string UomScale { get { return GetResourceString("UomScale"); } }

		public static string UomTime { get { return GetResourceString("UomTime"); } }

		public static string UomVelocity { get { return GetResourceString("UomVelocity"); } }

		public static string UomVolume { get { return GetResourceString("UomVolume"); } }

		public static string usageDate { get { return GetResourceString("usageDate"); } }

		public static string userNote { get { return GetResourceString("userNote"); } }

		public static string usrDetLim { get { return GetResourceString("usrDetLim"); } }

		public static string value { get { return GetResourceString("value"); } }

		public static string adminArea { get { return GetResourceString("adminArea"); } }

		public static string Adoption { get { return GetResourceString("Adoption"); } }

		public static string allDestSubtypes { get { return GetResourceString("allDestSubtypes"); } }

		public static string allOriginSubtypes { get { return GetResourceString("allOriginSubtypes"); } }

		public static string aName { get { return GetResourceString("aName"); } }

		public static string appProfile { get { return GetResourceString("appProfile"); } }

		public static string ArcGISFormat { get { return GetResourceString("ArcGISFormat"); } }

		public static string artPage { get { return GetResourceString("artPage"); } }

		public static string asAscii { get { return GetResourceString("asAscii"); } }

		public static string asCstLang { get { return GetResourceString("asCstLang"); } }

		public static string asGraFile { get { return GetResourceString("asGraFile"); } }

		public static string asName { get { return GetResourceString("asName"); } }

		public static string asSchLang { get { return GetResourceString("asSchLang"); } }

		public static string asSwDevFiFt { get { return GetResourceString("asSwDevFiFt"); } }

		public static string asSwDevFile { get { return GetResourceString("asSwDevFile"); } }

		public static string atindex { get { return GetResourceString("atindex"); } }

		public static string atnumdec { get { return GetResourceString("atnumdec"); } }

		public static string atoutwid { get { return GetResourceString("atoutwid"); } }

		public static string atprecis { get { return GetResourceString("atprecis"); } }

		public static string attalias { get { return GetResourceString("attalias"); } }

		public static string attDesc { get { return GetResourceString("attDesc"); } }

		public static string attExtentDecDegrees { get { return GetResourceString("attExtentDecDegrees"); } }

		public static string attExtentNative { get { return GetResourceString("attExtentNative"); } }

		public static string attExtentType { get { return GetResourceString("attExtentType"); } }

		public static string attrdef { get { return GetResourceString("attrdef"); } }

		public static string attributeType { get { return GetResourceString("attributeType"); } }

		public static string attrmfrq { get { return GetResourceString("attrmfrq"); } }

		public static string attrmres { get { return GetResourceString("attrmres"); } }

		public static string attrtype { get { return GetResourceString("attrtype"); } }

		public static string attrunit { get { return GetResourceString("attrunit"); } }

		public static string attscale { get { return GetResourceString("attscale"); } }

		public static string attwidth { get { return GetResourceString("attwidth"); } }

		public static string axDimProps { get { return GetResourceString("axDimProps"); } }

		public static string Band { get { return GetResourceString("Band"); } }

		public static string begdatea { get { return GetResourceString("begdatea"); } }

		public static string begin { get { return GetResourceString("begin"); } }

		public static string bitsPerVal { get { return GetResourceString("bitsPerVal"); } }

		public static string BoundPoly { get { return GetResourceString("BoundPoly"); } }

		public static string calDate { get { return GetResourceString("calDate"); } }

		public static string camCalInAv { get { return GetResourceString("camCalInAv"); } }

		public static string catCitation { get { return GetResourceString("catCitation"); } }

		public static string catFetTyps { get { return GetResourceString("catFetTyps"); } }

		public static string catLang { get { return GetResourceString("catLang"); } }

		public static string cellGeo { get { return GetResourceString("cellGeo"); } }

		public static string centerPt { get { return GetResourceString("centerPt"); } }

		public static string citId { get { return GetResourceString("citId"); } }

		public static string citIdType { get { return GetResourceString("citIdType"); } }

		public static string citRespParty { get { return GetResourceString("citRespParty"); } }

		public static string city { get { return GetResourceString("city"); } }

		public static string clkTime { get { return GetResourceString("clkTime"); } }

		public static string cloudCovPer { get { return GetResourceString("cloudCovPer"); } }

		public static string clusterTol { get { return GetResourceString("clusterTol"); } }

		public static string cmpGenQuan { get { return GetResourceString("cmpGenQuan"); } }

		public static string cntAddress { get { return GetResourceString("cntAddress"); } }

		public static string cntHours { get { return GetResourceString("cntHours"); } }

		public static string cntInstr { get { return GetResourceString("cntInstr"); } }

		public static string cntPhone { get { return GetResourceString("cntPhone"); } }

		public static string codesetd { get { return GetResourceString("codesetd"); } }

		public static string codesetn { get { return GetResourceString("codesetn"); } }

		public static string codesets { get { return GetResourceString("codesets"); } }

		public static string collTitle { get { return GetResourceString("collTitle"); } }

		public static string compCode { get { return GetResourceString("compCode"); } }

		public static string conExpl { get { return GetResourceString("conExpl"); } }

		public static string connrule { get { return GetResourceString("connrule"); } }

		public static string conPass { get { return GetResourceString("conPass"); } }

		public static string ConResult { get { return GetResourceString("ConResult"); } }

		public static string conSpec { get { return GetResourceString("conSpec"); } }

		public static string contentTyp { get { return GetResourceString("contentTyp"); } }

		public static string ContInfo { get { return GetResourceString("ContInfo"); } }

		public static string conversionToISOUnits { get { return GetResourceString("conversionToISOUnits"); } }

		public static string coordRef { get { return GetResourceString("coordRef"); } }

		public static string copy { get { return GetResourceString("copy"); } }

		public static string copyHistory { get { return GetResourceString("copyHistory"); } }

		public static string country { get { return GetResourceString("country"); } }

		public static string CreaDate { get { return GetResourceString("CreaDate"); } }

		public static string Creation { get { return GetResourceString("Creation"); } }

		public static string ctrlPtAv { get { return GetResourceString("ctrlPtAv"); } }

		public static string dataExt { get { return GetResourceString("dataExt"); } }

		public static string dataLineage { get { return GetResourceString("dataLineage"); } }

		public static string datasetSeries { get { return GetResourceString("datasetSeries"); } }

		public static string dataSource { get { return GetResourceString("dataSource"); } }

		public static string date { get { return GetResourceString("date"); } }

		public static string delPoint { get { return GetResourceString("delPoint"); } }

		public static string Deprecation { get { return GetResourceString("Deprecation"); } }

		public static string Descript { get { return GetResourceString("Descript"); } }

		public static string dest { get { return GetResourceString("dest"); } }

		public static string dimDescrp { get { return GetResourceString("dimDescrp"); } }

		public static string Dimen { get { return GetResourceString("Dimen"); } }

		public static string dimName { get { return GetResourceString("dimName"); } }

		public static string dimResol { get { return GetResourceString("dimResol"); } }

		public static string dimSize { get { return GetResourceString("dimSize"); } }

		public static string distance { get { return GetResourceString("distance"); } }

		public static string distFormat { get { return GetResourceString("distFormat"); } }

		public static string distorCont { get { return GetResourceString("distorCont"); } }

		public static string distorFormat { get { return GetResourceString("distorFormat"); } }

		public static string distorOrdPrc { get { return GetResourceString("distorOrdPrc"); } }

		public static string distorTran { get { return GetResourceString("distorTran"); } }

		public static string distributor { get { return GetResourceString("distributor"); } }

		public static string domdesc { get { return GetResourceString("domdesc"); } }

		public static string domtype { get { return GetResourceString("domtype"); } }

		public static string DQAbsExtPosAcc { get { return GetResourceString("DQAbsExtPosAcc"); } }

		public static string DQAccTimeMeas { get { return GetResourceString("DQAccTimeMeas"); } }

		public static string DQCompComm { get { return GetResourceString("DQCompComm"); } }

		public static string DQComplete { get { return GetResourceString("DQComplete"); } }

		public static string DQCompOm { get { return GetResourceString("DQCompOm"); } }

		public static string DQConcConsis { get { return GetResourceString("DQConcConsis"); } }

		public static string DQDomConsis { get { return GetResourceString("DQDomConsis"); } }

		public static string DQFormConsis { get { return GetResourceString("DQFormConsis"); } }

		public static string DQGridDataPosAcc { get { return GetResourceString("DQGridDataPosAcc"); } }

		public static string DQLogConsis { get { return GetResourceString("DQLogConsis"); } }

		public static string DQNonQuanAttAcc { get { return GetResourceString("DQNonQuanAttAcc"); } }

		public static string DQOtherwise { get { return GetResourceString("DQOtherwise"); } }

		public static string DQPosAcc { get { return GetResourceString("DQPosAcc"); } }

		public static string DQQuanAttAcc { get { return GetResourceString("DQQuanAttAcc"); } }

		public static string DQRelIntPosAcc { get { return GetResourceString("DQRelIntPosAcc"); } }

		public static string dqScope { get { return GetResourceString("dqScope"); } }

		public static string DQTempAcc { get { return GetResourceString("DQTempAcc"); } }

		public static string DQTempConsis { get { return GetResourceString("DQTempConsis"); } }

		public static string DQTempValid { get { return GetResourceString("DQTempValid"); } }

		public static string DQThemAcc { get { return GetResourceString("DQThemAcc"); } }

		public static string DQThemClassCor { get { return GetResourceString("DQThemClassCor"); } }

		public static string DQTopConsis { get { return GetResourceString("DQTopConsis"); } }

		public static string dsFormat { get { return GetResourceString("dsFormat"); } }

		public static string dsOtherwise { get { return GetResourceString("dsOtherwise"); } }

		public static string dtfc { get { return GetResourceString("dtfc"); } }

		public static string eastBL { get { return GetResourceString("eastBL"); } }

		public static string edom { get { return GetResourceString("edom"); } }

		public static string edomv { get { return GetResourceString("edomv"); } }

		public static string edomvd { get { return GetResourceString("edomvd"); } }

		public static string efeacnt { get { return GetResourceString("efeacnt"); } }

		public static string efeageom { get { return GetResourceString("efeageom"); } }

		public static string efeatyp { get { return GetResourceString("efeatyp"); } }

		public static string eleDataType { get { return GetResourceString("eleDataType"); } }

		public static string eMailAdd { get { return GetResourceString("eMailAdd"); } }

		public static string Enclosure { get { return GetResourceString("Enclosure"); } }

		public static string EnclosureType { get { return GetResourceString("EnclosureType"); } }

		public static string end { get { return GetResourceString("end"); } }

		public static string enddatea { get { return GetResourceString("enddatea"); } }

		public static string errStat { get { return GetResourceString("errStat"); } }

		public static string esritopo { get { return GetResourceString("esritopo"); } }

		public static string evalMethDesc { get { return GetResourceString("evalMethDesc"); } }

		public static string evalMethType { get { return GetResourceString("evalMethType"); } }

		public static string evalProc { get { return GetResourceString("evalProc"); } }

		public static string exDesc { get { return GetResourceString("exDesc"); } }

		public static string exSpat { get { return GetResourceString("exSpat"); } }

		public static string extDomCode { get { return GetResourceString("extDomCode"); } }

		public static string extEleCond { get { return GetResourceString("extEleCond"); } }

		public static string extEleDef { get { return GetResourceString("extEleDef"); } }

		public static string extEleDomVal { get { return GetResourceString("extEleDomVal"); } }

		public static string extEleInfo { get { return GetResourceString("extEleInfo"); } }

		public static string extEleMxOc { get { return GetResourceString("extEleMxOc"); } }

		public static string extEleName { get { return GetResourceString("extEleName"); } }

		public static string extEleOb { get { return GetResourceString("extEleOb"); } }

		public static string extEleParEnt { get { return GetResourceString("extEleParEnt"); } }

		public static string extEleRat { get { return GetResourceString("extEleRat"); } }

		public static string extEleRule { get { return GetResourceString("extEleRule"); } }

		public static string extEleSrc { get { return GetResourceString("extEleSrc"); } }

		public static string exTemp { get { return GetResourceString("exTemp"); } }

		public static string extent { get { return GetResourceString("extent"); } }

		public static string extOnRes { get { return GetResourceString("extOnRes"); } }

		public static string extShortName { get { return GetResourceString("extShortName"); } }

		public static string exTypeCode { get { return GetResourceString("exTypeCode"); } }

		public static string exTypeCode1 { get { return GetResourceString("exTypeCode1"); } }

		public static string exTypeCode2 { get { return GetResourceString("exTypeCode2"); } }

		public static string Fallback { get { return GetResourceString("Fallback"); } }

		public static string faxNum { get { return GetResourceString("faxNum"); } }

		public static string fcname { get { return GetResourceString("fcname"); } }

		public static string featCatSup { get { return GetResourceString("featCatSup"); } }

		public static string featdesc { get { return GetResourceString("featdesc"); } }

		public static string featTypeList { get { return GetResourceString("featTypeList"); } }

		public static string FeatureClass { get { return GetResourceString("FeatureClass"); } }

		public static string Field { get { return GetResourceString("Field"); } }

		public static string Fields { get { return GetResourceString("Fields"); } }

		public static string fileDecmTech { get { return GetResourceString("fileDecmTech"); } }

		public static string FileMAT { get { return GetResourceString("FileMAT"); } }

		public static string FileSTN { get { return GetResourceString("FileSTN"); } }

		public static string filmDistInAv { get { return GetResourceString("filmDistInAv"); } }

		public static string formatAmdNum { get { return GetResourceString("formatAmdNum"); } }

		public static string formatName { get { return GetResourceString("formatName"); } }

		public static string formatSpec { get { return GetResourceString("formatSpec"); } }

		public static string formatVer { get { return GetResourceString("formatVer"); } }

		public static string General { get { return GetResourceString("General"); } }

		public static string GeoBndBox { get { return GetResourceString("GeoBndBox"); } }

		public static string GeoDesc { get { return GetResourceString("GeoDesc"); } }

		public static string geoEle { get { return GetResourceString("geoEle"); } }

		public static string geogcsn { get { return GetResourceString("geogcsn"); } }

		public static string geoId { get { return GetResourceString("geoId"); } }

		public static string geometObjs { get { return GetResourceString("geometObjs"); } }

		public static string geoObjCnt { get { return GetResourceString("geoObjCnt"); } }

		public static string geoObjTyp { get { return GetResourceString("geoObjTyp"); } }

		public static string georefPars { get { return GetResourceString("georefPars"); } }

		public static string idCitation { get { return GetResourceString("idCitation"); } }

		public static string identAuth { get { return GetResourceString("identAuth"); } }

		public static string identCode { get { return GetResourceString("identCode"); } }

		public static string Identifier { get { return GetResourceString("Identifier"); } }

		public static string idPoC { get { return GetResourceString("idPoC"); } }

		public static string illAziAng { get { return GetResourceString("illAziAng"); } }

		public static string illElevAng { get { return GetResourceString("illElevAng"); } }

		public static string imagCond { get { return GetResourceString("imagCond"); } }

		public static string Image { get { return GetResourceString("Image"); } }

		public static string imagQuCode { get { return GetResourceString("imagQuCode"); } }

		public static string imsContentType { get { return GetResourceString("imsContentType"); } }

		public static string incWithDS { get { return GetResourceString("incWithDS"); } }

		public static string InForce { get { return GetResourceString("InForce"); } }

		public static string InputFields { get { return GetResourceString("InputFields"); } }

		public static string IntFileMAT { get { return GetResourceString("IntFileMAT"); } }

		public static string IntFileSTN { get { return GetResourceString("IntFileSTN"); } }

		public static string isbn { get { return GetResourceString("isbn"); } }

		public static string issId { get { return GetResourceString("issId"); } }

		public static string issn { get { return GetResourceString("issn"); } }

		public static string itemName { get { return GetResourceString("itemName"); } }

		public static string itemProps { get { return GetResourceString("itemProps"); } }

		public static string itemSize { get { return GetResourceString("itemSize"); } }

		public static string junctid { get { return GetResourceString("junctid"); } }

		public static string junctst { get { return GetResourceString("junctst"); } }

		public static string lensDistInAv { get { return GetResourceString("lensDistInAv"); } }

		public static string linkage { get { return GetResourceString("linkage"); } }

		public static string linrefer { get { return GetResourceString("linrefer"); } }

		public static string maxErrors { get { return GetResourceString("maxErrors"); } }

		public static string maxVal { get { return GetResourceString("maxVal"); } }

		public static string mdContact { get { return GetResourceString("mdContact"); } }

		public static string MdCoRefSys1 { get { return GetResourceString("MdCoRefSys1"); } }

		public static string measDateTm { get { return GetResourceString("measDateTm"); } }

		public static string measDesc { get { return GetResourceString("measDesc"); } }

		public static string measId { get { return GetResourceString("measId"); } }

		public static string measName { get { return GetResourceString("measName"); } }

		public static string medDensity { get { return GetResourceString("medDensity"); } }

		public static string medDenUnits { get { return GetResourceString("medDenUnits"); } }

		public static string medFormat { get { return GetResourceString("medFormat"); } }

		public static string medName { get { return GetResourceString("medName"); } }

		public static string medNote { get { return GetResourceString("medNote"); } }

		public static string medVol { get { return GetResourceString("medVol"); } }

		public static string minVal { get { return GetResourceString("minVal"); } }

		public static string ModDate { get { return GetResourceString("ModDate"); } }

		public static string mrgtype { get { return GetResourceString("mrgtype"); } }

		public static string nativeExtBox { get { return GetResourceString("nativeExtBox"); } }

		public static string nettype { get { return GetResourceString("nettype"); } }

		public static string netwrole { get { return GetResourceString("netwrole"); } }

		public static string northBL { get { return GetResourceString("northBL"); } }

		public static string NotAvailable { get { return GetResourceString("NotAvailable"); } }

		public static string notTrusted { get { return GetResourceString("notTrusted"); } }

		public static string numDims { get { return GetResourceString("numDims"); } }

		public static string offLineMed { get { return GetResourceString("offLineMed"); } }

		public static string offset { get { return GetResourceString("offset"); } }

		public static string onLineRes { get { return GetResourceString("onLineRes"); } }

		public static string onLineSrc { get { return GetResourceString("onLineSrc"); } }

		public static string orDesc { get { return GetResourceString("orDesc"); } }

		public static string ordInstr { get { return GetResourceString("ordInstr"); } }

		public static string ordTurn { get { return GetResourceString("ordTurn"); } }

		public static string orFunct { get { return GetResourceString("orFunct"); } }

		public static string orieParaAv { get { return GetResourceString("orieParaAv"); } }

		public static string orieParaDs { get { return GetResourceString("orieParaDs"); } }

		public static string OriginalFileName { get { return GetResourceString("OriginalFileName"); } }

		public static string orName { get { return GetResourceString("orName"); } }

		public static string otfc { get { return GetResourceString("otfc"); } }

		public static string otfcfkey { get { return GetResourceString("otfcfkey"); } }

		public static string otfcname { get { return GetResourceString("otfcname"); } }

		public static string otfcpkey { get { return GetResourceString("otfcpkey"); } }

		public static string otherCitDet { get { return GetResourceString("otherCitDet"); } }

		public static string paraCit { get { return GetResourceString("paraCit"); } }

		public static string ParticipatesIn { get { return GetResourceString("ParticipatesIn"); } }

		public static string partTopoRules { get { return GetResourceString("partTopoRules"); } }

		public static string peXml { get { return GetResourceString("peXml"); } }

		public static string Picture { get { return GetResourceString("Picture"); } }

		public static string pkResp { get { return GetResourceString("pkResp"); } }

		public static string planAvDtTm { get { return GetResourceString("planAvDtTm"); } }

		public static string polygonCoordinates { get { return GetResourceString("polygonCoordinates"); } }

		public static string polygonMdCoRefSys { get { return GetResourceString("polygonMdCoRefSys"); } }

		public static string portCatCit { get { return GetResourceString("portCatCit"); } }

		public static string postCode { get { return GetResourceString("postCode"); } }

		public static string prcStep { get { return GetResourceString("prcStep"); } }

		public static string prcTypCde { get { return GetResourceString("prcTypCde"); } }

		public static string presForm { get { return GetResourceString("presForm"); } }

		public static string Process { get { return GetResourceString("Process"); } }

		public static string ProcessCommandIssued { get { return GetResourceString("ProcessCommandIssued"); } }

		public static string ProcessDate { get { return GetResourceString("ProcessDate"); } }

		public static string ProcessName { get { return GetResourceString("ProcessName"); } }

		public static string ProcessTime { get { return GetResourceString("ProcessTime"); } }

		public static string ProcessToolLocation { get { return GetResourceString("ProcessToolLocation"); } }

		public static string projcsn { get { return GetResourceString("projcsn"); } }

		public static string Properties { get { return GetResourceString("Properties"); } }

		public static string protocol { get { return GetResourceString("protocol"); } }

		public static string Publication { get { return GetResourceString("Publication"); } }

		public static string PublishedDocID { get { return GetResourceString("PublishedDocID"); } }

		public static string PublishStatus { get { return GetResourceString("PublishStatus"); } }

		public static string QuanResult { get { return GetResourceString("QuanResult"); } }

		public static string quanValPrecision { get { return GetResourceString("quanValPrecision"); } }

		public static string quanValType { get { return GetResourceString("quanValType"); } }

		public static string quanValue { get { return GetResourceString("quanValue"); } }

		public static string quanValUnit { get { return GetResourceString("quanValUnit"); } }

		public static string radCalDatAv { get { return GetResourceString("radCalDatAv"); } }

		public static string RangeDim { get { return GetResourceString("RangeDim"); } }

		public static string RangeOtherwise { get { return GetResourceString("RangeOtherwise"); } }

		public static string rdom { get { return GetResourceString("rdom"); } }

		public static string rdommax { get { return GetResourceString("rdommax"); } }

		public static string rdommean { get { return GetResourceString("rdommean"); } }

		public static string rdommin { get { return GetResourceString("rdommin"); } }

		public static string rdomstdv { get { return GetResourceString("rdomstdv"); } }

		public static string refSysID { get { return GetResourceString("refSysID"); } }

		public static string refSysName { get { return GetResourceString("refSysName"); } }

		public static string relattr { get { return GetResourceString("relattr"); } }

		public static string relblab { get { return GetResourceString("relblab"); } }

		public static string relcard { get { return GetResourceString("relcard"); } }

		public static string relcomp { get { return GetResourceString("relcomp"); } }

		public static string reldesc { get { return GetResourceString("reldesc"); } }

		public static string relflab { get { return GetResourceString("relflab"); } }

		public static string relnodir { get { return GetResourceString("relnodir"); } }

		public static string resAltTitle { get { return GetResourceString("resAltTitle"); } }

		public static string resEd { get { return GetResourceString("resEd"); } }

		public static string resEdDate { get { return GetResourceString("resEdDate"); } }

		public static string resFees { get { return GetResourceString("resFees"); } }

		public static string resTitle { get { return GetResourceString("resTitle"); } }

		public static string Result { get { return GetResourceString("Result"); } }

		public static string Revision { get { return GetResourceString("Revision"); } }

		public static string role { get { return GetResourceString("role"); } }

		public static string RowCount { get { return GetResourceString("RowCount"); } }

		public static string rpCntInfo { get { return GetResourceString("rpCntInfo"); } }

		public static string rpIndName { get { return GetResourceString("rpIndName"); } }

		public static string rpOrgName { get { return GetResourceString("rpOrgName"); } }

		public static string rpPosName { get { return GetResourceString("rpPosName"); } }

		public static string RuleBases { get { return GetResourceString("RuleBases"); } }

		public static string rulecat { get { return GetResourceString("rulecat"); } }

		public static string ruledjid { get { return GetResourceString("ruledjid"); } }

		public static string ruledjst { get { return GetResourceString("ruledjst"); } }

		public static string ruleeid { get { return GetResourceString("ruleeid"); } }

		public static string ruleemnc { get { return GetResourceString("ruleemnc"); } }

		public static string ruleemxc { get { return GetResourceString("ruleemxc"); } }

		public static string ruleest { get { return GetResourceString("ruleest"); } }

		public static string rulefeid { get { return GetResourceString("rulefeid"); } }

		public static string rulefest { get { return GetResourceString("rulefest"); } }

		public static string rulehelp { get { return GetResourceString("rulehelp"); } }

		public static string rulejid { get { return GetResourceString("rulejid"); } }

		public static string rulejmnc { get { return GetResourceString("rulejmnc"); } }

		public static string rulejmxc { get { return GetResourceString("rulejmxc"); } }

		public static string rulejst { get { return GetResourceString("rulejst"); } }

		public static string rulejunc { get { return GetResourceString("rulejunc"); } }

		public static string ruleteid { get { return GetResourceString("ruleteid"); } }

		public static string ruletest { get { return GetResourceString("ruletest"); } }

		public static string ruletype { get { return GetResourceString("ruletype"); } }

		public static string sclFac { get { return GetResourceString("sclFac"); } }

		public static string scope { get { return GetResourceString("scope"); } }

		public static string scpExt { get { return GetResourceString("scpExt"); } }

		public static string scpLvl { get { return GetResourceString("scpLvl"); } }

		public static string seqID { get { return GetResourceString("seqID"); } }

		public static string seriesName { get { return GetResourceString("seriesName"); } }

		public static string Server { get { return GetResourceString("Server"); } }

		public static string Service { get { return GetResourceString("Service"); } }

		public static string ServiceFCName { get { return GetResourceString("ServiceFCName"); } }

		public static string ServiceFCType { get { return GetResourceString("ServiceFCType"); } }

		public static string ServiceInfo { get { return GetResourceString("ServiceInfo"); } }

		public static string ServiceType { get { return GetResourceString("ServiceType"); } }

		public static string source { get { return GetResourceString("source"); } }

		public static string SourceMetadata { get { return GetResourceString("SourceMetadata"); } }

		public static string southBL { get { return GetResourceString("southBL"); } }

		public static string spatObj { get { return GetResourceString("spatObj"); } }

		public static string spatSchName { get { return GetResourceString("spatSchName"); } }

		public static string SpatTempEx { get { return GetResourceString("SpatTempEx"); } }

		public static string spindex { get { return GetResourceString("spindex"); } }

		public static string splttype { get { return GetResourceString("splttype"); } }

		public static string srcCitatn { get { return GetResourceString("srcCitatn"); } }

		public static string srcDesc { get { return GetResourceString("srcDesc"); } }

		public static string srcExt { get { return GetResourceString("srcExt"); } }

		public static string srcRefSys { get { return GetResourceString("srcRefSys"); } }

		public static string statement { get { return GetResourceString("statement"); } }

		public static string stcode { get { return GetResourceString("stcode"); } }

		public static string stDomain { get { return GetResourceString("stDomain"); } }

		public static string stepDateTm { get { return GetResourceString("stepDateTm"); } }

		public static string stepDesc { get { return GetResourceString("stepDesc"); } }

		public static string stepProc { get { return GetResourceString("stepProc"); } }

		public static string stepRat { get { return GetResourceString("stepRat"); } }

		public static string stname { get { return GetResourceString("stname"); } }

		public static string Style { get { return GetResourceString("Style"); } }

		public static string subtype { get { return GetResourceString("subtype"); } }

		public static string subtypeDefaultValue { get { return GetResourceString("subtypeDefaultValue"); } }

		public static string subtypeName { get { return GetResourceString("subtypeName"); } }

		public static string Superseded { get { return GetResourceString("Superseded"); } }

		public static string Sync { get { return GetResourceString("Sync"); } }

		public static string SyncDate { get { return GetResourceString("SyncDate"); } }

		public static string SyncOnce { get { return GetResourceString("SyncOnce"); } }

		public static string SyncWhenViewing { get { return GetResourceString("SyncWhenViewing"); } }

		public static string tagsForSearching { get { return GetResourceString("tagsForSearching"); } }

		public static string TempExtent { get { return GetResourceString("TempExtent"); } }

		public static string thesaName { get { return GetResourceString("thesaName"); } }

		public static string Thumbnail { get { return GetResourceString("Thumbnail"); } }

		public static string toneGrad { get { return GetResourceString("toneGrad"); } }

		public static string topLvl { get { return GetResourceString("topLvl"); } }

		public static string topoName { get { return GetResourceString("topoName"); } }

		public static string topoRule { get { return GetResourceString("topoRule"); } }

		public static string topoRuleDest { get { return GetResourceString("topoRuleDest"); } }

		public static string topoRuleID { get { return GetResourceString("topoRuleID"); } }

		public static string topoRuleName { get { return GetResourceString("topoRuleName"); } }

		public static string topoRuleOrigin { get { return GetResourceString("topoRuleOrigin"); } }

		public static string topoRuleType { get { return GetResourceString("topoRuleType"); } }

		public static string topoWeight { get { return GetResourceString("topoWeight"); } }

		public static string totalPts { get { return GetResourceString("totalPts"); } }

		public static string transSize { get { return GetResourceString("transSize"); } }

		public static string trianInd { get { return GetResourceString("trianInd"); } }

		public static string trustedPolygon { get { return GetResourceString("trustedPolygon"); } }

		public static string type { get { return GetResourceString("type"); } }

		public static string udom { get { return GetResourceString("udom"); } }

		public static string udomDesc { get { return GetResourceString("udomDesc"); } }

		public static string unitsODist { get { return GetResourceString("unitsODist"); } }

		public static string usrCntInfo { get { return GetResourceString("usrCntInfo"); } }

		public static string validateEvents { get { return GetResourceString("validateEvents"); } }

		public static string valUnit { get { return GetResourceString("valUnit"); } }

		public static string vertEle { get { return GetResourceString("vertEle"); } }

		public static string vertMaxVal { get { return GetResourceString("vertMaxVal"); } }

		public static string vertMinVal { get { return GetResourceString("vertMinVal"); } }

		public static string vertUoM { get { return GetResourceString("vertUoM"); } }

		public static string voiceNum { get { return GetResourceString("voiceNum"); } }

		public static string westBL { get { return GetResourceString("westBL"); } }

		public static string XYRank { get { return GetResourceString("XYRank"); } }

		public static string ZRank { get { return GetResourceString("ZRank"); } }

		public static string cellGeometry { get { return GetResourceString("cellGeometry"); } }

		public static string idAbst { get { return GetResourceString("idAbst"); } }

		public static string idAccConst { get { return GetResourceString("idAccConst"); } }

		public static string idAddResHandRes { get { return GetResourceString("idAddResHandRes"); } }

		public static string IDadministrativeArea { get { return GetResourceString("IDadministrativeArea"); } }

		public static string IDalternateTitle { get { return GetResourceString("IDalternateTitle"); } }

		public static string IDamendmentNumber { get { return GetResourceString("IDamendmentNumber"); } }

		public static string IDaName { get { return GetResourceString("IDaName"); } }

		public static string IDapplicationProfile { get { return GetResourceString("IDapplicationProfile"); } }

		public static string IDAppSchname { get { return GetResourceString("IDAppSchname"); } }

		public static string idAtt { get { return GetResourceString("idAtt"); } }

		public static string IDAttDescCellValue { get { return GetResourceString("IDAttDescCellValue"); } }

		public static string idAttInst { get { return GetResourceString("idAttInst"); } }

		public static string IDattributeDescription { get { return GetResourceString("IDattributeDescription"); } }

		public static string IDattributeType { get { return GetResourceString("IDattributeType"); } }

		public static string IDauthority { get { return GetResourceString("IDauthority"); } }

		public static string idAxisDimProp { get { return GetResourceString("idAxisDimProp"); } }

		public static string IDbeginPosition { get { return GetResourceString("IDbeginPosition"); } }

		public static string IDbitsPerValue { get { return GetResourceString("IDbitsPerValue"); } }

		public static string IDcameraCalibrationInformationAvailability { get { return GetResourceString("IDcameraCalibrationInformationAvailability"); } }

		public static string IDcenterPoint { get { return GetResourceString("IDcenterPoint"); } }

		public static string IDcheckPointAvailability { get { return GetResourceString("IDcheckPointAvailability"); } }

		public static string IDcheckPointDescription { get { return GetResourceString("IDcheckPointDescription"); } }

		public static string IDcitation2 { get { return GetResourceString("IDcitation2"); } }

		public static string IDCitation3 { get { return GetResourceString("IDCitation3"); } }

		public static string IDCity { get { return GetResourceString("IDCity"); } }

		public static string IDCI_Address { get { return GetResourceString("IDCI_Address"); } }

		public static string IDCI_Contact { get { return GetResourceString("IDCI_Contact"); } }

		public static string IDCI_OnlineResource { get { return GetResourceString("IDCI_OnlineResource"); } }

		public static string IDCI_Telephone { get { return GetResourceString("IDCI_Telephone"); } }

		public static string idClassification { get { return GetResourceString("idClassification"); } }

		public static string idClassificationSys { get { return GetResourceString("idClassificationSys"); } }

		public static string IDcloudCoverPercentage { get { return GetResourceString("IDcloudCoverPercentage"); } }

		public static string idCodeSpace { get { return GetResourceString("idCodeSpace"); } }

		public static string IDcollectiveTitle { get { return GetResourceString("IDcollectiveTitle"); } }

		public static string IDcomplianceCode { get { return GetResourceString("IDcomplianceCode"); } }

		public static string IDcompressionGenerationQuantity { get { return GetResourceString("IDcompressionGenerationQuantity"); } }

		public static string IDcondition { get { return GetResourceString("IDcondition"); } }

		public static string idConstaints { get { return GetResourceString("idConstaints"); } }

		public static string IDconstraintLanguage { get { return GetResourceString("IDconstraintLanguage"); } }

		public static string IDcontactInstructions { get { return GetResourceString("IDcontactInstructions"); } }

		public static string IDcontentType { get { return GetResourceString("IDcontentType"); } }

		public static string IDcontrolPointAvailability { get { return GetResourceString("IDcontrolPointAvailability"); } }

		public static string IDCoordinates { get { return GetResourceString("IDCoordinates"); } }

		public static string IDCoordRefSys { get { return GetResourceString("IDCoordRefSys"); } }

		public static string IDcornerPoints { get { return GetResourceString("IDcornerPoints"); } }

		public static string IDCountry { get { return GetResourceString("IDCountry"); } }

		public static string idCredits { get { return GetResourceString("idCredits"); } }

		public static string IDdataType { get { return GetResourceString("IDdataType"); } }

		public static string idDateOfNxtUpdate { get { return GetResourceString("idDateOfNxtUpdate"); } }

		public static string IDdateTime { get { return GetResourceString("IDdateTime"); } }

		public static string IDdateTime2 { get { return GetResourceString("IDdateTime2"); } }

		public static string idDateTimeUse { get { return GetResourceString("idDateTimeUse"); } }

		public static string idDays { get { return GetResourceString("idDays"); } }

		public static string IDdefinition { get { return GetResourceString("IDdefinition"); } }

		public static string IDdeliveryPoint { get { return GetResourceString("IDdeliveryPoint"); } }

		public static string IDdensity { get { return GetResourceString("IDdensity"); } }

		public static string IDdensityUnits { get { return GetResourceString("IDdensityUnits"); } }

		public static string idDesc { get { return GetResourceString("idDesc"); } }

		public static string idDescKeywords { get { return GetResourceString("idDescKeywords"); } }

		public static string IDdescription { get { return GetResourceString("IDdescription"); } }

		public static string IDDescription2 { get { return GetResourceString("IDDescription2"); } }

		public static string IDdescriptor { get { return GetResourceString("IDdescriptor"); } }

		public static string IDDimension { get { return GetResourceString("IDDimension"); } }

		public static string IDdimensionName { get { return GetResourceString("IDdimensionName"); } }

		public static string IDdimensionSize { get { return GetResourceString("IDdimensionSize"); } }

		public static string idDisKey { get { return GetResourceString("idDisKey"); } }

		public static string IDDistance { get { return GetResourceString("IDDistance"); } }

		public static string IDdistributorFormat { get { return GetResourceString("IDdistributorFormat"); } }

		public static string IDdomainCode { get { return GetResourceString("IDdomainCode"); } }

		public static string IDdomainValue { get { return GetResourceString("IDdomainValue"); } }

		public static string IDDQ_AbsoluteExternalPositionalAccuracy { get { return GetResourceString("IDDQ_AbsoluteExternalPositionalAccuracy"); } }

		public static string IDDQ_AccuracyOfATimeMeasurement { get { return GetResourceString("IDDQ_AccuracyOfATimeMeasurement"); } }

		public static string IDDQ_CompletenessCommission { get { return GetResourceString("IDDQ_CompletenessCommission"); } }

		public static string IDDQ_CompletenessOmission { get { return GetResourceString("IDDQ_CompletenessOmission"); } }

		public static string IDDQ_ConceptualConsistency { get { return GetResourceString("IDDQ_ConceptualConsistency"); } }

		public static string IDDQ_ConformanceResult { get { return GetResourceString("IDDQ_ConformanceResult"); } }

		public static string IDDQ_DomainConsistency { get { return GetResourceString("IDDQ_DomainConsistency"); } }

		public static string IDDQ_FormatConsistency { get { return GetResourceString("IDDQ_FormatConsistency"); } }

		public static string IDDQ_GriddedDataPositionalAccuracy { get { return GetResourceString("IDDQ_GriddedDataPositionalAccuracy"); } }

		public static string IDDQ_NonQuantitativeAttributeAccuracy { get { return GetResourceString("IDDQ_NonQuantitativeAttributeAccuracy"); } }

		public static string IDDQ_QuantitativeAttributeAccuracy { get { return GetResourceString("IDDQ_QuantitativeAttributeAccuracy"); } }

		public static string IDDQ_QuantitativeResult { get { return GetResourceString("IDDQ_QuantitativeResult"); } }

		public static string IDDQ_RelativeInternalPositionalAccuracy { get { return GetResourceString("IDDQ_RelativeInternalPositionalAccuracy"); } }

		public static string IDDQ_TemporalConsistency { get { return GetResourceString("IDDQ_TemporalConsistency"); } }

		public static string IDDQ_TemporalValidity { get { return GetResourceString("IDDQ_TemporalValidity"); } }

		public static string IDDQ_ThematicClassificationCorrectness { get { return GetResourceString("IDDQ_ThematicClassificationCorrectness"); } }

		public static string IDDQ_TopologicalConsistency { get { return GetResourceString("IDDQ_TopologicalConsistency"); } }

		public static string idDs { get { return GetResourceString("idDs"); } }

		public static string idDsCharSet { get { return GetResourceString("idDsCharSet"); } }

		public static string idDsLang { get { return GetResourceString("idDsLang"); } }

		public static string idDsScle { get { return GetResourceString("idDsScle"); } }

		public static string IDeastBoundLongitude { get { return GetResourceString("IDeastBoundLongitude"); } }

		public static string IDEdition { get { return GetResourceString("IDEdition"); } }

		public static string IDeditionDate { get { return GetResourceString("IDeditionDate"); } }

		public static string IDelectronicMailAddress { get { return GetResourceString("IDelectronicMailAddress"); } }

		public static string IDElementname { get { return GetResourceString("IDElementname"); } }

		public static string IDendPosition { get { return GetResourceString("IDendPosition"); } }

		public static string IDerrorStatistic { get { return GetResourceString("IDerrorStatistic"); } }

		public static string IDevaluationMethodDescription { get { return GetResourceString("IDevaluationMethodDescription"); } }

		public static string IDevaluationMethodType { get { return GetResourceString("IDevaluationMethodType"); } }

		public static string IDevaluationProcedure { get { return GetResourceString("IDevaluationProcedure"); } }

		public static string IDexplanation { get { return GetResourceString("IDexplanation"); } }

		public static string IDExtdescription { get { return GetResourceString("IDExtdescription"); } }

		public static string IDExtent { get { return GetResourceString("IDExtent"); } }

		public static string IDextentTypeCode { get { return GetResourceString("IDextentTypeCode"); } }

		public static string IDextentTypeCode2 { get { return GetResourceString("IDextentTypeCode2"); } }

		public static string IDextentTypeCode4 { get { return GetResourceString("IDextentTypeCode4"); } }

		public static string IDEX_BoundingPolygon { get { return GetResourceString("IDEX_BoundingPolygon"); } }

		public static string IDEX_GeographicBoundingBox { get { return GetResourceString("IDEX_GeographicBoundingBox"); } }

		public static string IDEX_GeographicDescription { get { return GetResourceString("IDEX_GeographicDescription"); } }

		public static string IDEX_SpatialTemporalExtent { get { return GetResourceString("IDEX_SpatialTemporalExtent"); } }

		public static string IDEX_TemporalExtent { get { return GetResourceString("IDEX_TemporalExtent"); } }

		public static string IDEX_VerticalExtent { get { return GetResourceString("IDEX_VerticalExtent"); } }

		public static string IDFax { get { return GetResourceString("IDFax"); } }

		public static string idFeat { get { return GetResourceString("idFeat"); } }

		public static string idFeatInst { get { return GetResourceString("idFeatInst"); } }

		public static string IDfeatureCatalogueCitation { get { return GetResourceString("IDfeatureCatalogueCitation"); } }

		public static string IDfeatureTypes { get { return GetResourceString("IDfeatureTypes"); } }

		public static string IDfees { get { return GetResourceString("IDfees"); } }

		public static string IDfileDecompressionTechnique { get { return GetResourceString("IDfileDecompressionTechnique"); } }

		public static string idFileDesc { get { return GetResourceString("idFileDesc"); } }

		public static string idFileName { get { return GetResourceString("idFileName"); } }

		public static string idFileType { get { return GetResourceString("idFileType"); } }

		public static string IDfilmDistortionInformationAvailability { get { return GetResourceString("IDfilmDistortionInformationAvailability"); } }

		public static string IDFormat { get { return GetResourceString("IDFormat"); } }

		public static string IDFormatname { get { return GetResourceString("IDFormatname"); } }

		public static string IDFormatversion { get { return GetResourceString("IDFormatversion"); } }

		public static string IDfunction { get { return GetResourceString("IDfunction"); } }

		public static string IDGeogExtent { get { return GetResourceString("IDGeogExtent"); } }

		public static string IDgeographicIdentifier { get { return GetResourceString("IDgeographicIdentifier"); } }

		public static string IDgeometricObjectCount { get { return GetResourceString("IDgeometricObjectCount"); } }

		public static string IDgeometricObjectType { get { return GetResourceString("IDgeometricObjectType"); } }

		public static string IDGeometry { get { return GetResourceString("IDGeometry"); } }

		public static string IDgeoreferencedParameters { get { return GetResourceString("IDgeoreferencedParameters"); } }

		public static string idGraphicOverview { get { return GetResourceString("idGraphicOverview"); } }

		public static string IDgraphicsFile { get { return GetResourceString("IDgraphicsFile"); } }

		public static string idGrdSampleDist { get { return GetResourceString("idGrdSampleDist"); } }

		public static string IDhoursOfService { get { return GetResourceString("IDhoursOfService"); } }

		public static string idHowResUsed { get { return GetResourceString("idHowResUsed"); } }

		public static string idHowToResUsed { get { return GetResourceString("idHowToResUsed"); } }

		public static string idHrs { get { return GetResourceString("idHrs"); } }

		public static string IDidentifier { get { return GetResourceString("IDidentifier"); } }

		public static string IDilluminationAzimuthAngle { get { return GetResourceString("IDilluminationAzimuthAngle"); } }

		public static string IDilluminationElevationAngle { get { return GetResourceString("IDilluminationElevationAngle"); } }

		public static string IDimageQualityCode { get { return GetResourceString("IDimageQualityCode"); } }

		public static string IDimagingCondition { get { return GetResourceString("IDimagingCondition"); } }

		public static string IDincludedWithDataset { get { return GetResourceString("IDincludedWithDataset"); } }

		public static string IDindividualName { get { return GetResourceString("IDindividualName"); } }

		public static string IDISBN { get { return GetResourceString("IDISBN"); } }

		public static string IDISSN { get { return GetResourceString("IDISSN"); } }

		public static string IDIssue { get { return GetResourceString("IDIssue"); } }

		public static string idKeywords { get { return GetResourceString("idKeywords"); } }

		public static string IDlanguage { get { return GetResourceString("IDlanguage"); } }

		public static string idLastUpdate { get { return GetResourceString("idLastUpdate"); } }

		public static string idLegConst { get { return GetResourceString("idLegConst"); } }

		public static string idUserNote { get { return GetResourceString("idUserNote"); } }

		public static string IDlensDistortionInformationAvailability { get { return GetResourceString("IDlensDistortionInformationAvailability"); } }

		public static string IDlevel { get { return GetResourceString("IDlevel"); } }

		public static string idLimOfUse { get { return GetResourceString("idLimOfUse"); } }

		public static string IDlinkage { get { return GetResourceString("IDlinkage"); } }

		public static string IDLI_Lineage { get { return GetResourceString("IDLI_Lineage"); } }

		public static string IDLI_ProcessStep { get { return GetResourceString("IDLI_ProcessStep"); } }

		public static string IDLI_Source { get { return GetResourceString("IDLI_Source"); } }

		public static string IDLI_SourceData { get { return GetResourceString("IDLI_SourceData"); } }

		public static string IDLongWavelength { get { return GetResourceString("IDLongWavelength"); } }

		public static string idMaint { get { return GetResourceString("idMaint"); } }

		public static string IDmaximumOccurrence { get { return GetResourceString("IDmaximumOccurrence"); } }

		public static string IDmaximumValue { get { return GetResourceString("IDmaximumValue"); } }

		public static string idMDCharSet { get { return GetResourceString("idMDCharSet"); } }

		public static string idMDConstraints { get { return GetResourceString("idMDConstraints"); } }

		public static string idMDIdent { get { return GetResourceString("idMDIdent"); } }

		public static string idMDLang { get { return GetResourceString("idMDLang"); } }

		public static string IDMD_Band { get { return GetResourceString("IDMD_Band"); } }

		public static string IDMD_DigitalTransferOptions { get { return GetResourceString("IDMD_DigitalTransferOptions"); } }

		public static string IDMD_Distributor { get { return GetResourceString("IDMD_Distributor"); } }

		public static string IDMD_ExtendedElementInformation { get { return GetResourceString("IDMD_ExtendedElementInformation"); } }

		public static string IDMD_GeometricObjects { get { return GetResourceString("IDMD_GeometricObjects"); } }

		public static string IDMD_Medium { get { return GetResourceString("IDMD_Medium"); } }

		public static string IDMD_RangeDimension { get { return GetResourceString("IDMD_RangeDimension"); } }

		public static string IDMD_StandardOrderProcess { get { return GetResourceString("IDMD_StandardOrderProcess"); } }

		public static string IDmeasureDescription { get { return GetResourceString("IDmeasureDescription"); } }

		public static string IDmeasureIdentification { get { return GetResourceString("IDmeasureIdentification"); } }

		public static string IDmediumFormat { get { return GetResourceString("IDmediumFormat"); } }

		public static string IDmediumNote { get { return GetResourceString("IDmediumNote"); } }

		public static string idMin { get { return GetResourceString("idMin"); } }

		public static string IDminimumValue { get { return GetResourceString("IDminimumValue"); } }

		public static string idMths { get { return GetResourceString("idMths"); } }

		public static string IDname { get { return GetResourceString("IDname"); } }

		public static string IDname2 { get { return GetResourceString("IDname2"); } }

		public static string IDName3 { get { return GetResourceString("IDName3"); } }

		public static string idNameMDStand { get { return GetResourceString("idNameMDStand"); } }

		public static string IDnameOfMeasure { get { return GetResourceString("IDnameOfMeasure"); } }

		public static string IDnorthBoundLatitude { get { return GetResourceString("IDnorthBoundLatitude"); } }

		public static string idNumDim { get { return GetResourceString("idNumDim"); } }

		public static string IDObligation { get { return GetResourceString("IDObligation"); } }

		public static string IDoffset { get { return GetResourceString("IDoffset"); } }

		public static string IDorderingInstructions { get { return GetResourceString("IDorderingInstructions"); } }

		public static string IDorganisationName { get { return GetResourceString("IDorganisationName"); } }

		public static string IDorientationParameterAvailability { get { return GetResourceString("IDorientationParameterAvailability"); } }

		public static string IDorientationParameterDescription { get { return GetResourceString("IDorientationParameterDescription"); } }

		public static string idOther { get { return GetResourceString("idOther"); } }

		public static string IDotherCitationDetails { get { return GetResourceString("IDotherCitationDetails"); } }

		public static string idOtherConst { get { return GetResourceString("idOtherConst"); } }

		public static string idOtherMaintReq { get { return GetResourceString("idOtherMaintReq"); } }

		public static string IDPage { get { return GetResourceString("IDPage"); } }

		public static string IDparameterCitation { get { return GetResourceString("IDparameterCitation"); } }

		public static string IDparentEntity { get { return GetResourceString("IDparentEntity"); } }

		public static string idParIdent { get { return GetResourceString("idParIdent"); } }

		public static string IDpass { get { return GetResourceString("IDpass"); } }

		public static string IDpeakResponse { get { return GetResourceString("IDpeakResponse"); } }

		public static string idPlaceKeywords { get { return GetResourceString("idPlaceKeywords"); } }

		public static string IDplannedAvailableDateTime { get { return GetResourceString("IDplannedAvailableDateTime"); } }

		public static string IDportrayalCatalogueCitation { get { return GetResourceString("IDportrayalCatalogueCitation"); } }

		public static string IDpositionName { get { return GetResourceString("IDpositionName"); } }

		public static string IDpostalCode { get { return GetResourceString("IDpostalCode"); } }

		public static string IDpresentationForm { get { return GetResourceString("IDpresentationForm"); } }

		public static string idProcEnv { get { return GetResourceString("idProcEnv"); } }

		public static string IDprocessingLevelCode { get { return GetResourceString("IDprocessingLevelCode"); } }

		public static string IDprotocol { get { return GetResourceString("IDprotocol"); } }

		public static string idPurpose { get { return GetResourceString("idPurpose"); } }

		public static string IDradiometricCalibrationDataAvailability { get { return GetResourceString("IDradiometricCalibrationDataAvailability"); } }

		public static string IDRationale { get { return GetResourceString("IDRationale"); } }

		public static string IDrationale2 { get { return GetResourceString("IDrationale2"); } }

		public static string IDreferenceSystemIdentifier { get { return GetResourceString("IDreferenceSystemIdentifier"); } }

		public static string idResConst { get { return GetResourceString("idResConst"); } }

		public static string idResMaint { get { return GetResourceString("idResMaint"); } }

		public static string IDresolution { get { return GetResourceString("IDresolution"); } }

		public static string IDresourceFormat { get { return GetResourceString("IDresourceFormat"); } }

		public static string IDResvalue { get { return GetResourceString("IDResvalue"); } }

		public static string IDrule { get { return GetResourceString("IDrule"); } }

		public static string idScaleDem { get { return GetResourceString("idScaleDem"); } }

		public static string IDscaleFactor { get { return GetResourceString("IDscaleFactor"); } }

		public static string IDschemaAscii { get { return GetResourceString("IDschemaAscii"); } }

		public static string IDschemaLanguage { get { return GetResourceString("IDschemaLanguage"); } }

		public static string IDScope { get { return GetResourceString("IDScope"); } }

		public static string idScopeDesc { get { return GetResourceString("idScopeDesc"); } }

		public static string idScopeName { get { return GetResourceString("idScopeName"); } }

		public static string idScopeOfMDDesc { get { return GetResourceString("idScopeOfMDDesc"); } }

		public static string idScopeOfUpdates { get { return GetResourceString("idScopeOfUpdates"); } }

		public static string IDScopeQuality { get { return GetResourceString("IDScopeQuality"); } }

		public static string idSec { get { return GetResourceString("idSec"); } }

		public static string idSecConst { get { return GetResourceString("idSecConst"); } }

		public static string IDsequenceIdentifier { get { return GetResourceString("IDsequenceIdentifier"); } }

		public static string IDSeries { get { return GetResourceString("IDSeries"); } }

		public static string IDshortName { get { return GetResourceString("IDshortName"); } }

		public static string IDShortWaveLength { get { return GetResourceString("IDShortWaveLength"); } }

		public static string IDsoftwareDevelopmentFile { get { return GetResourceString("IDsoftwareDevelopmentFile"); } }

		public static string IDsoftwareDevelopmentFileFormat { get { return GetResourceString("IDsoftwareDevelopmentFileFormat"); } }

		public static string IDsourceCitation { get { return GetResourceString("IDsourceCitation"); } }

		public static string IDsourceReferenceSystem { get { return GetResourceString("IDsourceReferenceSystem"); } }

		public static string IDsouthBoundLatitude { get { return GetResourceString("IDsouthBoundLatitude"); } }

		public static string IDspatialExtent { get { return GetResourceString("IDspatialExtent"); } }

		public static string idSpatialRes { get { return GetResourceString("idSpatialRes"); } }

		public static string idSpatRepType { get { return GetResourceString("idSpatRepType"); } }

		public static string IDspecification { get { return GetResourceString("IDspecification"); } }

		public static string IDspecification2 { get { return GetResourceString("IDspecification2"); } }

		public static string IDstatement { get { return GetResourceString("IDstatement"); } }

		public static string idStrKeywords { get { return GetResourceString("idStrKeywords"); } }

		public static string idSubInfo { get { return GetResourceString("idSubInfo"); } }

		public static string idTempKeywords { get { return GetResourceString("idTempKeywords"); } }

		public static string idThemeCatRes { get { return GetResourceString("idThemeCatRes"); } }

		public static string idThemeKeywords { get { return GetResourceString("idThemeKeywords"); } }

		public static string IDthesaurusName { get { return GetResourceString("IDthesaurusName"); } }

		public static string idTimeInd { get { return GetResourceString("idTimeInd"); } }

		public static string idTimePerBtwUpdate { get { return GetResourceString("idTimePerBtwUpdate"); } }

		public static string idTimePerDes { get { return GetResourceString("idTimePerDes"); } }

		public static string IDtimePosition { get { return GetResourceString("IDtimePosition"); } }

		public static string IDTitle { get { return GetResourceString("IDTitle"); } }

		public static string IDtoneGradation { get { return GetResourceString("IDtoneGradation"); } }

		public static string IDtopologyLevel { get { return GetResourceString("IDtopologyLevel"); } }

		public static string IDtransferSize { get { return GetResourceString("IDtransferSize"); } }

		public static string IDunitsOfDistribution { get { return GetResourceString("IDunitsOfDistribution"); } }

		public static string IDtransformationDimensionDescription { get { return GetResourceString("IDtransformationDimensionDescription"); } }

		public static string IDtransformationDimensionMapping { get { return GetResourceString("IDtransformationDimensionMapping"); } }

		public static string IDtriangulationIndicator { get { return GetResourceString("IDtriangulationIndicator"); } }

		public static string IDturnaround { get { return GetResourceString("IDturnaround"); } }

		public static string IDTypeofContent { get { return GetResourceString("IDTypeofContent"); } }

		public static string IDunits { get { return GetResourceString("IDunits"); } }

		public static string IDUnits2 { get { return GetResourceString("IDUnits2"); } }

		public static string idUpdateFreq { get { return GetResourceString("idUpdateFreq"); } }

		public static string idURIDataDesc { get { return GetResourceString("idURIDataDesc"); } }

		public static string idUseConst { get { return GetResourceString("idUseConst"); } }

		public static string IDValue { get { return GetResourceString("IDValue"); } }

		public static string IDvalueType { get { return GetResourceString("IDvalueType"); } }

		public static string IDvalueUnit { get { return GetResourceString("IDvalueUnit"); } }

		public static string idVerMDStand { get { return GetResourceString("idVerMDStand"); } }

		public static string idVersion { get { return GetResourceString("idVersion"); } }

		public static string IDVoice { get { return GetResourceString("IDVoice"); } }

		public static string IDvolumes { get { return GetResourceString("IDvolumes"); } }

		public static string IDwestBoundLongitude { get { return GetResourceString("IDwestBoundLongitude"); } }

		public static string idYrs { get { return GetResourceString("idYrs"); } }

		public static string pointInPixel { get { return GetResourceString("pointInPixel"); } }

		public static string transformationParameterAvailability { get { return GetResourceString("transformationParameterAvailability"); } }

		public static string IDAppSchInfo { get { return GetResourceString("IDAppSchInfo"); } }

		public static string IDAppSchInfo2 { get { return GetResourceString("IDAppSchInfo2"); } }

		public static string IDAppSchInfoSchema { get { return GetResourceString("IDAppSchInfoSchema"); } }

		public static string IDBackToTop { get { return GetResourceString("IDBackToTop"); } }

		public static string IDCatalogue { get { return GetResourceString("IDCatalogue"); } }

		public static string IDContact { get { return GetResourceString("IDContact"); } }

		public static string IDContentInfo { get { return GetResourceString("IDContentInfo"); } }

		public static string IDContInfo { get { return GetResourceString("IDContInfo"); } }

		public static string IDContInfoFeatCatDesc { get { return GetResourceString("IDContInfoFeatCatDesc"); } }

		public static string IDContInfoFeatCovDesc { get { return GetResourceString("IDContInfoFeatCovDesc"); } }

		public static string IDContInfoImgDesc { get { return GetResourceString("IDContInfoImgDesc"); } }

		public static string IDDataQualDesc { get { return GetResourceString("IDDataQualDesc"); } }

		public static string IDDataQualInfo { get { return GetResourceString("IDDataQualInfo"); } }

		public static string IDDataQualInfo2 { get { return GetResourceString("IDDataQualInfo2"); } }

		public static string IDDataQuality { get { return GetResourceString("IDDataQuality"); } }

		public static string IDDate { get { return GetResourceString("IDDate"); } }

		public static string IDDescription3 { get { return GetResourceString("IDDescription3"); } }

		public static string IDDist { get { return GetResourceString("IDDist"); } }

		public static string IDDistInfo { get { return GetResourceString("IDDistInfo"); } }

		public static string IDDistInfo2 { get { return GetResourceString("IDDistInfo2"); } }

		public static string IDExtension { get { return GetResourceString("IDExtension"); } }

		public static string IDExtSrc { get { return GetResourceString("IDExtSrc"); } }

		public static string IDISO19139MetaDataCnt { get { return GetResourceString("IDISO19139MetaDataCnt"); } }

		public static string IDMetadataContact { get { return GetResourceString("IDMetadataContact"); } }

		public static string IDMetadataExtInfo { get { return GetResourceString("IDMetadataExtInfo"); } }

		public static string IDMetadataFormat19139 { get { return GetResourceString("IDMetadataFormat19139"); } }

		public static string IDMetaExtInfo { get { return GetResourceString("IDMetaExtInfo"); } }

		public static string IDMetaInfo { get { return GetResourceString("IDMetaInfo"); } }

		public static string IDPartyUsRes { get { return GetResourceString("IDPartyUsRes"); } }

		public static string IDPorCatRef { get { return GetResourceString("IDPorCatRef"); } }

		public static string IDPortCatRef { get { return GetResourceString("IDPortCatRef"); } }

		public static string IDPrcCnt { get { return GetResourceString("IDPrcCnt"); } }

		public static string IDPtOfCnt { get { return GetResourceString("IDPtOfCnt"); } }

		public static string IDRefSys { get { return GetResourceString("IDRefSys"); } }

		public static string IDRefSysInfo { get { return GetResourceString("IDRefSysInfo"); } }

		public static string IDRefSysinfo2 { get { return GetResourceString("IDRefSysinfo2"); } }

		public static string IDRefSysInfoSys { get { return GetResourceString("IDRefSysInfoSys"); } }

		public static string idRepresentation { get { return GetResourceString("idRepresentation"); } }

		public static string idResIdInfo { get { return GetResourceString("idResIdInfo"); } }

		public static string IDResIdInfo2 { get { return GetResourceString("IDResIdInfo2"); } }

		public static string IDResIdInfoRes { get { return GetResourceString("IDResIdInfoRes"); } }

		public static string idResource { get { return GetResourceString("idResource"); } }

		public static string IDResParty { get { return GetResourceString("IDResParty"); } }

		public static string IDSchema { get { return GetResourceString("IDSchema"); } }

		public static string IDSpatRefGrid { get { return GetResourceString("IDSpatRefGrid"); } }

		public static string IDSpatRepGeorec { get { return GetResourceString("IDSpatRepGeorec"); } }

		public static string IDSpatRepGeoRef { get { return GetResourceString("IDSpatRepGeoRef"); } }

		public static string idSpatRepInfo { get { return GetResourceString("idSpatRepInfo"); } }

		public static string IDSpatRepVec { get { return GetResourceString("IDSpatRepVec"); } }

		public static string idIdent { get { return GetResourceString("idIdent"); } }

		public static string idDataQual { get { return GetResourceString("idDataQual"); } }

		public static string idSpaDataOrg { get { return GetResourceString("idSpaDataOrg"); } }

		public static string idSpaRef { get { return GetResourceString("idSpaRef"); } }

		public static string idEntsAndAttribs { get { return GetResourceString("idEntsAndAttribs"); } }

		public static string idHide { get { return GetResourceString("idHide"); } }

		public static string idDistInfo_FGDC { get { return GetResourceString("idDistInfo_FGDC"); } }

		public static string idMetaRef { get { return GetResourceString("idMetaRef"); } }

		public static string idAbstract { get { return GetResourceString("idAbstract"); } }

		public static string idSupplInfo { get { return GetResourceString("idSupplInfo"); } }

		public static string idTimePerOfContent { get { return GetResourceString("idTimePerOfContent"); } }

		public static string idCurrRef { get { return GetResourceString("idCurrRef"); } }

		public static string idProgress { get { return GetResourceString("idProgress"); } }

		public static string idMaintAndUpdateFreq { get { return GetResourceString("idMaintAndUpdateFreq"); } }

		public static string idSpaDomain { get { return GetResourceString("idSpaDomain"); } }

		public static string idBoundCoords { get { return GetResourceString("idBoundCoords"); } }

		public static string idWestBoundCoord { get { return GetResourceString("idWestBoundCoord"); } }

		public static string idEastBoundCoord { get { return GetResourceString("idEastBoundCoord"); } }

		public static string idNorthBoundCoord { get { return GetResourceString("idNorthBoundCoord"); } }

		public static string idSouthBoundCoord { get { return GetResourceString("idSouthBoundCoord"); } }

		public static string idDatasetGPoly { get { return GetResourceString("idDatasetGPoly"); } }

		public static string idDatasetGPolyOuterGRing { get { return GetResourceString("idDatasetGPolyOuterGRing"); } }

		public static string idDatasetGPolyExclGRing { get { return GetResourceString("idDatasetGPolyExclGRing"); } }

		public static string idKeywds { get { return GetResourceString("idKeywds"); } }

		public static string idTheme { get { return GetResourceString("idTheme"); } }

		public static string idThemeKeywdThes { get { return GetResourceString("idThemeKeywdThes"); } }

		public static string idThemeKeywd { get { return GetResourceString("idThemeKeywd"); } }

		public static string idPlace { get { return GetResourceString("idPlace"); } }

		public static string idPlaceKeywdThes { get { return GetResourceString("idPlaceKeywdThes"); } }

		public static string idPlaceKeywd { get { return GetResourceString("idPlaceKeywd"); } }

		public static string idStratum { get { return GetResourceString("idStratum"); } }

		public static string idStratumKeywdThes { get { return GetResourceString("idStratumKeywdThes"); } }

		public static string idStratumKeywd { get { return GetResourceString("idStratumKeywd"); } }

		public static string idTemporal { get { return GetResourceString("idTemporal"); } }

		public static string idTemporalKeywdThes { get { return GetResourceString("idTemporalKeywdThes"); } }

		public static string idTemporalKeywd { get { return GetResourceString("idTemporalKeywd"); } }

		public static string idAccessConst { get { return GetResourceString("idAccessConst"); } }

		public static string idPointOfContact { get { return GetResourceString("idPointOfContact"); } }

		public static string idBrowseGraphic { get { return GetResourceString("idBrowseGraphic"); } }

		public static string idBrowseGraphicFN { get { return GetResourceString("idBrowseGraphicFN"); } }

		public static string idBrowseGraphicFDesc { get { return GetResourceString("idBrowseGraphicFDesc"); } }

		public static string idBrowseGraphicFType { get { return GetResourceString("idBrowseGraphicFType"); } }

		public static string idDatasetCredit { get { return GetResourceString("idDatasetCredit"); } }

		public static string idSecInfo { get { return GetResourceString("idSecInfo"); } }

		public static string idSecClassSys { get { return GetResourceString("idSecClassSys"); } }

		public static string idSecClass { get { return GetResourceString("idSecClass"); } }

		public static string idSecHandlingDesc { get { return GetResourceString("idSecHandlingDesc"); } }

		public static string idNaticeDatasetEnv { get { return GetResourceString("idNaticeDatasetEnv"); } }

		public static string idCrossRef { get { return GetResourceString("idCrossRef"); } }

		public static string idAttribAcc { get { return GetResourceString("idAttribAcc"); } }

		public static string idAttribAccRep { get { return GetResourceString("idAttribAccRep"); } }

		public static string idQuantAttribAccAssess { get { return GetResourceString("idQuantAttribAccAssess"); } }

		public static string idAttribAccVal { get { return GetResourceString("idAttribAccVal"); } }

		public static string idAttribAccExpl { get { return GetResourceString("idAttribAccExpl"); } }

		public static string idLogConsistRep { get { return GetResourceString("idLogConsistRep"); } }

		public static string idCompleteRep { get { return GetResourceString("idCompleteRep"); } }

		public static string idPosAcc { get { return GetResourceString("idPosAcc"); } }

		public static string idHorizPosAcc { get { return GetResourceString("idHorizPosAcc"); } }

		public static string idHorizPosAccRep { get { return GetResourceString("idHorizPosAccRep"); } }

		public static string idQuantHorizPosAccAssess { get { return GetResourceString("idQuantHorizPosAccAssess"); } }

		public static string idHorizPosAccVal { get { return GetResourceString("idHorizPosAccVal"); } }

		public static string idHorizPosAccExpl { get { return GetResourceString("idHorizPosAccExpl"); } }

		public static string idVertPosAcc { get { return GetResourceString("idVertPosAcc"); } }

		public static string idVertPosAccRep { get { return GetResourceString("idVertPosAccRep"); } }

		public static string idQuantVertPosAccAssess { get { return GetResourceString("idQuantVertPosAccAssess"); } }

		public static string idVertPosAccVal { get { return GetResourceString("idVertPosAccVal"); } }

		public static string idVertPosAccExpl { get { return GetResourceString("idVertPosAccExpl"); } }

		public static string idLineage { get { return GetResourceString("idLineage"); } }

		public static string idSrcInfo { get { return GetResourceString("idSrcInfo"); } }

		public static string idSrcCitation { get { return GetResourceString("idSrcCitation"); } }

		public static string idSrcScaleDenom { get { return GetResourceString("idSrcScaleDenom"); } }

		public static string idTypeSrcMedia { get { return GetResourceString("idTypeSrcMedia"); } }

		public static string idSrcTimePrdContent { get { return GetResourceString("idSrcTimePrdContent"); } }

		public static string idSrcCurrRef { get { return GetResourceString("idSrcCurrRef"); } }

		public static string idSrcCitationAbbrev { get { return GetResourceString("idSrcCitationAbbrev"); } }

		public static string idSrcContrib { get { return GetResourceString("idSrcContrib"); } }

		public static string idProcStep { get { return GetResourceString("idProcStep"); } }

		public static string idProcDesc { get { return GetResourceString("idProcDesc"); } }

		public static string idSrcUsedCitationAbbrev { get { return GetResourceString("idSrcUsedCitationAbbrev"); } }

		public static string idProcDate { get { return GetResourceString("idProcDate"); } }

		public static string idProcTime { get { return GetResourceString("idProcTime"); } }

		public static string idSrcProdCitationAbbrev { get { return GetResourceString("idSrcProdCitationAbbrev"); } }

		public static string idProcContact { get { return GetResourceString("idProcContact"); } }

		public static string idCloudCover { get { return GetResourceString("idCloudCover"); } }

		public static string idIndirectSpaRefMethod { get { return GetResourceString("idIndirectSpaRefMethod"); } }

		public static string idDirectSpaRefMethod { get { return GetResourceString("idDirectSpaRefMethod"); } }

		public static string idPtVecObjInfo { get { return GetResourceString("idPtVecObjInfo"); } }

		public static string idSdtsTermsDesc { get { return GetResourceString("idSdtsTermsDesc"); } }

		public static string idSdtsPtVecObjType { get { return GetResourceString("idSdtsPtVecObjType"); } }

		public static string idPtVecObjCnt { get { return GetResourceString("idPtVecObjCnt"); } }

		public static string idPtVecObjCnt_FGDC { get { return GetResourceString("idPtVecObjCnt_FGDC"); } }

		public static string idVpfTermsDesc { get { return GetResourceString("idVpfTermsDesc"); } }

		public static string idVpfTopoLvl { get { return GetResourceString("idVpfTopoLvl"); } }

		public static string idVpfPtVecObjInfo { get { return GetResourceString("idVpfPtVecObjInfo"); } }

		public static string idVpfPtVecObjType { get { return GetResourceString("idVpfPtVecObjType"); } }

		public static string idRasterObjInfo { get { return GetResourceString("idRasterObjInfo"); } }

		public static string idRasterObjType { get { return GetResourceString("idRasterObjType"); } }

		public static string idRowCnt { get { return GetResourceString("idRowCnt"); } }

		public static string idColCnt { get { return GetResourceString("idColCnt"); } }

		public static string idVertCnt { get { return GetResourceString("idVertCnt"); } }

		public static string idHorizCoordSysDef { get { return GetResourceString("idHorizCoordSysDef"); } }

		public static string idGeographic { get { return GetResourceString("idGeographic"); } }

		public static string idLatRez { get { return GetResourceString("idLatRez"); } }

		public static string idLongRez { get { return GetResourceString("idLongRez"); } }

		public static string idGeoCoordUnits { get { return GetResourceString("idGeoCoordUnits"); } }

		public static string idPlanar { get { return GetResourceString("idPlanar"); } }

		public static string idMapProj { get { return GetResourceString("idMapProj"); } }

		public static string idMapProjName { get { return GetResourceString("idMapProjName"); } }

		public static string idAlbersConicEqArea { get { return GetResourceString("idAlbersConicEqArea"); } }

		public static string idAzimuthEquidist { get { return GetResourceString("idAzimuthEquidist"); } }

		public static string idAzimuthEquidist_FGDC { get { return GetResourceString("idAzimuthEquidist_FGDC"); } }

		public static string idEquidistConic { get { return GetResourceString("idEquidistConic"); } }

		public static string idEquirect { get { return GetResourceString("idEquirect"); } }

		public static string idEquirect_FGDC { get { return GetResourceString("idEquirect_FGDC"); } }

		public static string idGenVertNearsidePerspective { get { return GetResourceString("idGenVertNearsidePerspective"); } }

		public static string idGnomonic { get { return GetResourceString("idGnomonic"); } }

		public static string idLambertAzimuthEqArea { get { return GetResourceString("idLambertAzimuthEqArea"); } }

		public static string idMercator { get { return GetResourceString("idMercator"); } }

		public static string idModStereoAlaska { get { return GetResourceString("idModStereoAlaska"); } }

		public static string idMillerCylind { get { return GetResourceString("idMillerCylind"); } }

		public static string idObliqueMercator { get { return GetResourceString("idObliqueMercator"); } }

		public static string idObliqueMercator_FGDC { get { return GetResourceString("idObliqueMercator_FGDC"); } }

		public static string idOrtho { get { return GetResourceString("idOrtho"); } }

		public static string idPolarStereo { get { return GetResourceString("idPolarStereo"); } }

		public static string idPolarStereo_FGDC { get { return GetResourceString("idPolarStereo_FGDC"); } }

		public static string idPolyconic { get { return GetResourceString("idPolyconic"); } }

		public static string idPolyconic_FGDC { get { return GetResourceString("idPolyconic_FGDC"); } }

		public static string idRobinson { get { return GetResourceString("idRobinson"); } }

		public static string idSinusoidal { get { return GetResourceString("idSinusoidal"); } }

		public static string idSpaceObliqueMercatorLandsat { get { return GetResourceString("idSpaceObliqueMercatorLandsat"); } }

		public static string idStereo { get { return GetResourceString("idStereo"); } }

		public static string idXverseMercator { get { return GetResourceString("idXverseMercator"); } }

		public static string idXverseMercator_FGDC { get { return GetResourceString("idXverseMercator_FGDC"); } }

		public static string idXverseMercator_FGDC2 { get { return GetResourceString("idXverseMercator_FGDC2"); } }

		public static string idVanderGrinten { get { return GetResourceString("idVanderGrinten"); } }

		public static string idGridCoordSys { get { return GetResourceString("idGridCoordSys"); } }

		public static string idGridCoordSysName { get { return GetResourceString("idGridCoordSysName"); } }

		public static string idUnivXverseMercator { get { return GetResourceString("idUnivXverseMercator"); } }

		public static string idUtmZoneNum { get { return GetResourceString("idUtmZoneNum"); } }

		public static string idUnivPolarStereo { get { return GetResourceString("idUnivPolarStereo"); } }

		public static string idUpsZoneID { get { return GetResourceString("idUpsZoneID"); } }

		public static string idStatePlaneCoordSys { get { return GetResourceString("idStatePlaneCoordSys"); } }

		public static string idSpcsZoneID { get { return GetResourceString("idSpcsZoneID"); } }

		public static string idLambertConfConic { get { return GetResourceString("idLambertConfConic"); } }

		public static string idLambertConfConic_FGDC { get { return GetResourceString("idLambertConfConic_FGDC"); } }

		public static string idArcCoordSys { get { return GetResourceString("idArcCoordSys"); } }

		public static string idArcSysZoneID { get { return GetResourceString("idArcSysZoneID"); } }

		public static string idOtherGridSysDef { get { return GetResourceString("idOtherGridSysDef"); } }

		public static string idLocalPlanar { get { return GetResourceString("idLocalPlanar"); } }

		public static string idLocalPlanarDesc { get { return GetResourceString("idLocalPlanarDesc"); } }

		public static string idLocalPlanarGeorefInfo { get { return GetResourceString("idLocalPlanarGeorefInfo"); } }

		public static string idPlanarCoordInfo { get { return GetResourceString("idPlanarCoordInfo"); } }

		public static string idPlanarCoordEncodMethod { get { return GetResourceString("idPlanarCoordEncodMethod"); } }

		public static string idCoordRep { get { return GetResourceString("idCoordRep"); } }

		public static string idAbscissaReso { get { return GetResourceString("idAbscissaReso"); } }

		public static string idOrdinateReso { get { return GetResourceString("idOrdinateReso"); } }

		public static string idDistBearingRep { get { return GetResourceString("idDistBearingRep"); } }

		public static string idDistReso { get { return GetResourceString("idDistReso"); } }

		public static string idBearingReso { get { return GetResourceString("idBearingReso"); } }

		public static string idBearingUnits { get { return GetResourceString("idBearingUnits"); } }

		public static string idBearingRefDir { get { return GetResourceString("idBearingRefDir"); } }

		public static string idBearingRefMeridian { get { return GetResourceString("idBearingRefMeridian"); } }

		public static string idPlanarDistUnits { get { return GetResourceString("idPlanarDistUnits"); } }

		public static string idLocal { get { return GetResourceString("idLocal"); } }

		public static string idLocalDesc { get { return GetResourceString("idLocalDesc"); } }

		public static string idLocalGeorefInfo { get { return GetResourceString("idLocalGeorefInfo"); } }

		public static string idGeodeticModel { get { return GetResourceString("idGeodeticModel"); } }

		public static string idHorizDatumName { get { return GetResourceString("idHorizDatumName"); } }

		public static string idEllipsName { get { return GetResourceString("idEllipsName"); } }

		public static string idSemimajorAxis { get { return GetResourceString("idSemimajorAxis"); } }

		public static string idDenomFlatRatio { get { return GetResourceString("idDenomFlatRatio"); } }

		public static string idVertCoordSysDef { get { return GetResourceString("idVertCoordSysDef"); } }

		public static string idAltSysDef { get { return GetResourceString("idAltSysDef"); } }

		public static string idAltDatumName { get { return GetResourceString("idAltDatumName"); } }

		public static string idAltReso { get { return GetResourceString("idAltReso"); } }

		public static string idAltDistUnits { get { return GetResourceString("idAltDistUnits"); } }

		public static string idAltEncMethod { get { return GetResourceString("idAltEncMethod"); } }

		public static string idDepthSysDef { get { return GetResourceString("idDepthSysDef"); } }

		public static string idDepthDatumName { get { return GetResourceString("idDepthDatumName"); } }

		public static string idDepthReso { get { return GetResourceString("idDepthReso"); } }

		public static string idDepthDistUnits { get { return GetResourceString("idDepthDistUnits"); } }

		public static string idDepthEncMethod { get { return GetResourceString("idDepthEncMethod"); } }

		public static string idDetailedDesc { get { return GetResourceString("idDetailedDesc"); } }

		public static string idEntityType { get { return GetResourceString("idEntityType"); } }

		public static string idEntityTypeLbl { get { return GetResourceString("idEntityTypeLbl"); } }

		public static string idEntityTypeDef { get { return GetResourceString("idEntityTypeDef"); } }

		public static string idEntityTypeDefSrc { get { return GetResourceString("idEntityTypeDefSrc"); } }

		public static string idAttrib { get { return GetResourceString("idAttrib"); } }

		public static string idAttrib_FGDC { get { return GetResourceString("idAttrib_FGDC"); } }

		public static string idAttrib_FGDC2 { get { return GetResourceString("idAttrib_FGDC2"); } }

		public static string idAttribLbl { get { return GetResourceString("idAttribLbl"); } }

		public static string idAttribDef { get { return GetResourceString("idAttribDef"); } }

		public static string idAttribDefSrc { get { return GetResourceString("idAttribDefSrc"); } }

		public static string idAttribDomainVals { get { return GetResourceString("idAttribDomainVals"); } }

		public static string idEnumDomain { get { return GetResourceString("idEnumDomain"); } }

		public static string idEnumDomainVal { get { return GetResourceString("idEnumDomainVal"); } }

		public static string idEnumDomainValDef { get { return GetResourceString("idEnumDomainValDef"); } }

		public static string idEnumDomainValDefSrc { get { return GetResourceString("idEnumDomainValDefSrc"); } }

		public static string idRangeDomain { get { return GetResourceString("idRangeDomain"); } }

		public static string idRangeDomainMin { get { return GetResourceString("idRangeDomainMin"); } }

		public static string idRangeDomainMax { get { return GetResourceString("idRangeDomainMax"); } }

		public static string idAttribUnitsMeasure { get { return GetResourceString("idAttribUnitsMeasure"); } }

		public static string idAttribMeasureReso { get { return GetResourceString("idAttribMeasureReso"); } }

		public static string idCodesetDomain { get { return GetResourceString("idCodesetDomain"); } }

		public static string idCodesetName { get { return GetResourceString("idCodesetName"); } }

		public static string idCodesetSrc { get { return GetResourceString("idCodesetSrc"); } }

		public static string idUnrepDomain { get { return GetResourceString("idUnrepDomain"); } }

		public static string idBeginDateAttribVals { get { return GetResourceString("idBeginDateAttribVals"); } }

		public static string idEndDateAttribVals { get { return GetResourceString("idEndDateAttribVals"); } }

		public static string idAttribValAccInfo { get { return GetResourceString("idAttribValAccInfo"); } }

		public static string idAttribValAcc { get { return GetResourceString("idAttribValAcc"); } }

		public static string idAttribValAccExpl { get { return GetResourceString("idAttribValAccExpl"); } }

		public static string idAttribMeasureFreq { get { return GetResourceString("idAttribMeasureFreq"); } }

		public static string idOverviewDesc { get { return GetResourceString("idOverviewDesc"); } }

		public static string idEntityAttribOverview { get { return GetResourceString("idEntityAttribOverview"); } }

		public static string idEntityAttribDetailCitation { get { return GetResourceString("idEntityAttribDetailCitation"); } }

		public static string idDistrib { get { return GetResourceString("idDistrib"); } }

		public static string idResourceDesc { get { return GetResourceString("idResourceDesc"); } }

		public static string idDistribLiability { get { return GetResourceString("idDistribLiability"); } }

		public static string idStdOrderProc { get { return GetResourceString("idStdOrderProc"); } }

		public static string idNondigitalForm { get { return GetResourceString("idNondigitalForm"); } }

		public static string idDigitalForm { get { return GetResourceString("idDigitalForm"); } }

		public static string idDigitalXferInfo { get { return GetResourceString("idDigitalXferInfo"); } }

		public static string idFormatName_FGDC { get { return GetResourceString("idFormatName_FGDC"); } }

		public static string idFormatVersNum { get { return GetResourceString("idFormatVersNum"); } }

		public static string idFormatVersDate { get { return GetResourceString("idFormatVersDate"); } }

		public static string idFormatSpec { get { return GetResourceString("idFormatSpec"); } }

		public static string idFormatInfoContent { get { return GetResourceString("idFormatInfoContent"); } }

		public static string idFileDecompressTech { get { return GetResourceString("idFileDecompressTech"); } }

		public static string idXferSize { get { return GetResourceString("idXferSize"); } }

		public static string idDigitalXferOpt { get { return GetResourceString("idDigitalXferOpt"); } }

		public static string idOnlineOpt { get { return GetResourceString("idOnlineOpt"); } }

		public static string idCompContactInfo { get { return GetResourceString("idCompContactInfo"); } }

		public static string idNetAddr { get { return GetResourceString("idNetAddr"); } }

		public static string idNetResName { get { return GetResourceString("idNetResName"); } }

		public static string idDialupInst { get { return GetResourceString("idDialupInst"); } }

		public static string idLowestBPS { get { return GetResourceString("idLowestBPS"); } }

		public static string idHighestBPS { get { return GetResourceString("idHighestBPS"); } }

		public static string idNumDataBits { get { return GetResourceString("idNumDataBits"); } }

		public static string idNumStopBits { get { return GetResourceString("idNumStopBits"); } }

		public static string idParity { get { return GetResourceString("idParity"); } }

		public static string idCompressionSupport { get { return GetResourceString("idCompressionSupport"); } }

		public static string idDialupTelephone { get { return GetResourceString("idDialupTelephone"); } }

		public static string idDialupFileName { get { return GetResourceString("idDialupFileName"); } }

		public static string idAccessInst { get { return GetResourceString("idAccessInst"); } }

		public static string idOnlineCompOS { get { return GetResourceString("idOnlineCompOS"); } }

		public static string idOfflineOpt { get { return GetResourceString("idOfflineOpt"); } }

		public static string idOfflineMedia { get { return GetResourceString("idOfflineMedia"); } }

		public static string idRecordCap { get { return GetResourceString("idRecordCap"); } }

		public static string idRecordDensity { get { return GetResourceString("idRecordDensity"); } }

		public static string idRecordDensityUnits { get { return GetResourceString("idRecordDensityUnits"); } }

		public static string idRecordFormat { get { return GetResourceString("idRecordFormat"); } }

		public static string idCompatInfo { get { return GetResourceString("idCompatInfo"); } }

		public static string idFees_FGDC { get { return GetResourceString("idFees_FGDC"); } }

		public static string idOrderInst { get { return GetResourceString("idOrderInst"); } }

		public static string idTurnaround_FGDC { get { return GetResourceString("idTurnaround_FGDC"); } }

		public static string idCustOrderProc { get { return GetResourceString("idCustOrderProc"); } }

		public static string idTechPrereqs { get { return GetResourceString("idTechPrereqs"); } }

		public static string idAvailTimePeriod { get { return GetResourceString("idAvailTimePeriod"); } }

		public static string idMetaDate { get { return GetResourceString("idMetaDate"); } }

		public static string idMetaRevDate { get { return GetResourceString("idMetaRevDate"); } }

		public static string idMetaFutureRevDate { get { return GetResourceString("idMetaFutureRevDate"); } }

		public static string idMetaContact { get { return GetResourceString("idMetaContact"); } }

		public static string idMetaStdName { get { return GetResourceString("idMetaStdName"); } }

		public static string idMetaStdVers { get { return GetResourceString("idMetaStdVers"); } }

		public static string idMetaTimeConvention { get { return GetResourceString("idMetaTimeConvention"); } }

		public static string idMetaAccConst { get { return GetResourceString("idMetaAccConst"); } }

		public static string idMetaUseConst { get { return GetResourceString("idMetaUseConst"); } }

		public static string idMetaSecInfo { get { return GetResourceString("idMetaSecInfo"); } }

		public static string idMetaSecClassSys { get { return GetResourceString("idMetaSecClassSys"); } }

		public static string idMetaSecClass { get { return GetResourceString("idMetaSecClass"); } }

		public static string idMetaSecHandDesc { get { return GetResourceString("idMetaSecHandDesc"); } }

		public static string idMetaExts { get { return GetResourceString("idMetaExts"); } }

		public static string idOnlineLinkage { get { return GetResourceString("idOnlineLinkage"); } }

		public static string idOnlineLinkage_FGDC { get { return GetResourceString("idOnlineLinkage_FGDC"); } }

		public static string idProfileName { get { return GetResourceString("idProfileName"); } }

		public static string idCitationInfo { get { return GetResourceString("idCitationInfo"); } }

		public static string idOriginator { get { return GetResourceString("idOriginator"); } }

		public static string idPublicationDate { get { return GetResourceString("idPublicationDate"); } }

		public static string idPublicationTime { get { return GetResourceString("idPublicationTime"); } }

		public static string idTitle_FGDC { get { return GetResourceString("idTitle_FGDC"); } }

		public static string idEdition_FGDC { get { return GetResourceString("idEdition_FGDC"); } }

		public static string idGeoDataPresentationForm { get { return GetResourceString("idGeoDataPresentationForm"); } }

		public static string idSeriesInfo { get { return GetResourceString("idSeriesInfo"); } }

		public static string idSeriesName { get { return GetResourceString("idSeriesName"); } }

		public static string idIssueID { get { return GetResourceString("idIssueID"); } }

		public static string idPublicationInfo { get { return GetResourceString("idPublicationInfo"); } }

		public static string idPublicationPlace { get { return GetResourceString("idPublicationPlace"); } }

		public static string idPublisher { get { return GetResourceString("idPublisher"); } }

		public static string idOtherCitationDetails_FGDC { get { return GetResourceString("idOtherCitationDetails_FGDC"); } }

		public static string idLargerWorkCitation { get { return GetResourceString("idLargerWorkCitation"); } }

		public static string idContactInfo { get { return GetResourceString("idContactInfo"); } }

		public static string idContactPersonPrimary { get { return GetResourceString("idContactPersonPrimary"); } }

		public static string idContactPerson { get { return GetResourceString("idContactPerson"); } }

		public static string idContactPerson_FGDC { get { return GetResourceString("idContactPerson_FGDC"); } }

		public static string idContactOrg { get { return GetResourceString("idContactOrg"); } }

		public static string idContactOrg_FGDC { get { return GetResourceString("idContactOrg_FGDC"); } }

		public static string idContactOrgPrimary { get { return GetResourceString("idContactOrgPrimary"); } }

		public static string idContactPosition { get { return GetResourceString("idContactPosition"); } }

		public static string idContactAddr { get { return GetResourceString("idContactAddr"); } }

		public static string idAddrType { get { return GetResourceString("idAddrType"); } }

		public static string idAddr { get { return GetResourceString("idAddr"); } }

		public static string idCity_FGDC { get { return GetResourceString("idCity_FGDC"); } }

		public static string idStateProvince { get { return GetResourceString("idStateProvince"); } }

		public static string idPostalCode_FGDC { get { return GetResourceString("idPostalCode_FGDC"); } }

		public static string idCountry_FGDC { get { return GetResourceString("idCountry_FGDC"); } }

		public static string idContactVoiceTelephone { get { return GetResourceString("idContactVoiceTelephone"); } }

		public static string idContactTDDTTYTelephone { get { return GetResourceString("idContactTDDTTYTelephone"); } }

		public static string idContactFaxTelephone { get { return GetResourceString("idContactFaxTelephone"); } }

		public static string idContactEmailAddr { get { return GetResourceString("idContactEmailAddr"); } }

		public static string idHrsSvc { get { return GetResourceString("idHrsSvc"); } }

		public static string idContactInst { get { return GetResourceString("idContactInst"); } }

		public static string idTimePeriodInfo { get { return GetResourceString("idTimePeriodInfo"); } }

		public static string idSingleDateTime { get { return GetResourceString("idSingleDateTime"); } }

		public static string idCalendarDate { get { return GetResourceString("idCalendarDate"); } }

		public static string idTimeDay { get { return GetResourceString("idTimeDay"); } }

		public static string idMultDatesTimes { get { return GetResourceString("idMultDatesTimes"); } }

		public static string idRangeDatesTimes { get { return GetResourceString("idRangeDatesTimes"); } }

		public static string idBeginDate { get { return GetResourceString("idBeginDate"); } }

		public static string idBeginTime { get { return GetResourceString("idBeginTime"); } }

		public static string idEndDate { get { return GetResourceString("idEndDate"); } }

		public static string idEndTime { get { return GetResourceString("idEndTime"); } }

		public static string idGRingPoint { get { return GetResourceString("idGRingPoint"); } }

		public static string idGRingLat { get { return GetResourceString("idGRingLat"); } }

		public static string idGRingLong { get { return GetResourceString("idGRingLong"); } }

		public static string idGRing { get { return GetResourceString("idGRing"); } }

		public static string idStdParallel { get { return GetResourceString("idStdParallel"); } }

		public static string idLongCentMeridian { get { return GetResourceString("idLongCentMeridian"); } }

		public static string idLatProjOrigin { get { return GetResourceString("idLatProjOrigin"); } }

		public static string idFalseEasting { get { return GetResourceString("idFalseEasting"); } }

		public static string idFalseNorthing { get { return GetResourceString("idFalseNorthing"); } }

		public static string idScaleFactEquator { get { return GetResourceString("idScaleFactEquator"); } }

		public static string idHeightPerspectivePtAboveSurf { get { return GetResourceString("idHeightPerspectivePtAboveSurf"); } }

		public static string idLongProjCenter { get { return GetResourceString("idLongProjCenter"); } }

		public static string idLatProjCenter { get { return GetResourceString("idLatProjCenter"); } }

		public static string idScaleFactCenterLine { get { return GetResourceString("idScaleFactCenterLine"); } }

		public static string idObliqueLineAzimuth { get { return GetResourceString("idObliqueLineAzimuth"); } }

		public static string idAzimuthAngle { get { return GetResourceString("idAzimuthAngle"); } }

		public static string idAzimuthMeasurePtLong { get { return GetResourceString("idAzimuthMeasurePtLong"); } }

		public static string idObliqueLinePt { get { return GetResourceString("idObliqueLinePt"); } }

		public static string idObliqueLineLat { get { return GetResourceString("idObliqueLineLat"); } }

		public static string idObliqueLineLong { get { return GetResourceString("idObliqueLineLong"); } }

		public static string idStraightVertLongPole { get { return GetResourceString("idStraightVertLongPole"); } }

		public static string idScaleFactProjOrigin { get { return GetResourceString("idScaleFactProjOrigin"); } }

		public static string idLandsatNum { get { return GetResourceString("idLandsatNum"); } }

		public static string idPathNum { get { return GetResourceString("idPathNum"); } }

		public static string idScaleFactCentMeridian { get { return GetResourceString("idScaleFactCentMeridian"); } }

		public static string idOtherProjDef { get { return GetResourceString("idOtherProjDef"); } }

		public static string idCreation { get { return GetResourceString("idCreation"); } }

		public static string idPub { get { return GetResourceString("idPub"); } }

		public static string idRev { get { return GetResourceString("idRev"); } }

		public static string idDownload { get { return GetResourceString("idDownload"); } }

		public static string idInfo { get { return GetResourceString("idInfo"); } }

		public static string idOfflineAccess { get { return GetResourceString("idOfflineAccess"); } }

		public static string idOrder { get { return GetResourceString("idOrder"); } }

		public static string idSearch { get { return GetResourceString("idSearch"); } }

		public static string idDigitalDoc { get { return GetResourceString("idDigitalDoc"); } }

		public static string idHardcopyDoc { get { return GetResourceString("idHardcopyDoc"); } }

		public static string idDigitalImg { get { return GetResourceString("idDigitalImg"); } }

		public static string idHardcopyImg { get { return GetResourceString("idHardcopyImg"); } }

		public static string idDigitalMap { get { return GetResourceString("idDigitalMap"); } }

		public static string idHardcopyMap { get { return GetResourceString("idHardcopyMap"); } }

		public static string idDigitalModel { get { return GetResourceString("idDigitalModel"); } }

		public static string idHardcopyModel { get { return GetResourceString("idHardcopyModel"); } }

		public static string idDigitalProfile { get { return GetResourceString("idDigitalProfile"); } }

		public static string idHardcopyProfile { get { return GetResourceString("idHardcopyProfile"); } }

		public static string idDigitalTable { get { return GetResourceString("idDigitalTable"); } }

		public static string idHardcopyTable { get { return GetResourceString("idHardcopyTable"); } }

		public static string idDigitalVid { get { return GetResourceString("idDigitalVid"); } }

		public static string idHardcopyVid { get { return GetResourceString("idHardcopyVid"); } }

		public static string idResProv { get { return GetResourceString("idResProv"); } }

		public static string idCustodian { get { return GetResourceString("idCustodian"); } }

		public static string idOwner { get { return GetResourceString("idOwner"); } }

		public static string idUser { get { return GetResourceString("idUser"); } }

		public static string idDistrib_codelists { get { return GetResourceString("idDistrib_codelists"); } }

		public static string idOrigin { get { return GetResourceString("idOrigin"); } }

		public static string idPtContact { get { return GetResourceString("idPtContact"); } }

		public static string idPrincipalInvestigator { get { return GetResourceString("idPrincipalInvestigator"); } }

		public static string idProcessor { get { return GetResourceString("idProcessor"); } }

		public static string idPublisher_codelists { get { return GetResourceString("idPublisher_codelists"); } }

		public static string idAuthor { get { return GetResourceString("idAuthor"); } }

		public static string idDirectInternal { get { return GetResourceString("idDirectInternal"); } }

		public static string idDirectExternal { get { return GetResourceString("idDirectExternal"); } }

		public static string idIndirect { get { return GetResourceString("idIndirect"); } }

		public static string idCrossRef_codelists { get { return GetResourceString("idCrossRef_codelists"); } }

		public static string idLargerWorkCitation_codelists { get { return GetResourceString("idLargerWorkCitation_codelists"); } }

		public static string idPartSeamlessDb { get { return GetResourceString("idPartSeamlessDb"); } }

		public static string idSrc { get { return GetResourceString("idSrc"); } }

		public static string idStereoMate { get { return GetResourceString("idStereoMate"); } }

		public static string idCampaign { get { return GetResourceString("idCampaign"); } }

		public static string idColl { get { return GetResourceString("idColl"); } }

		public static string idEx { get { return GetResourceString("idEx"); } }

		public static string idExperiment { get { return GetResourceString("idExperiment"); } }

		public static string idInvestigation { get { return GetResourceString("idInvestigation"); } }

		public static string idMission { get { return GetResourceString("idMission"); } }

		public static string idSensor { get { return GetResourceString("idSensor"); } }

		public static string idOperation { get { return GetResourceString("idOperation"); } }

		public static string idPlatform { get { return GetResourceString("idPlatform"); } }

		public static string idProc { get { return GetResourceString("idProc"); } }

		public static string idProg { get { return GetResourceString("idProg"); } }

		public static string idProj { get { return GetResourceString("idProj"); } }

		public static string idStudy { get { return GetResourceString("idStudy"); } }

		public static string idTask { get { return GetResourceString("idTask"); } }

		public static string idTrial { get { return GetResourceString("idTrial"); } }

		public static string idPt { get { return GetResourceString("idPt"); } }

		public static string idArea { get { return GetResourceString("idArea"); } }

		public static string idUCS2 { get { return GetResourceString("idUCS2"); } }

		public static string idUCS4 { get { return GetResourceString("idUCS4"); } }

		public static string idUTF7 { get { return GetResourceString("idUTF7"); } }

		public static string idUTF8 { get { return GetResourceString("idUTF8"); } }

		public static string idUTF16 { get { return GetResourceString("idUTF16"); } }

		public static string id8859p1 { get { return GetResourceString("id8859p1"); } }

		public static string id8859p2 { get { return GetResourceString("id8859p2"); } }

		public static string id8859p3 { get { return GetResourceString("id8859p3"); } }

		public static string id8859p4 { get { return GetResourceString("id8859p4"); } }

		public static string id8859p5 { get { return GetResourceString("id8859p5"); } }

		public static string id8859p6 { get { return GetResourceString("id8859p6"); } }

		public static string id8859p7 { get { return GetResourceString("id8859p7"); } }

		public static string id8859p8 { get { return GetResourceString("id8859p8"); } }

		public static string id8859p9 { get { return GetResourceString("id8859p9"); } }

		public static string id8859p10 { get { return GetResourceString("id8859p10"); } }

		public static string id8859p11 { get { return GetResourceString("id8859p11"); } }

		public static string idReservedFutureUse { get { return GetResourceString("idReservedFutureUse"); } }

		public static string id8859p13 { get { return GetResourceString("id8859p13"); } }

		public static string id8859p14 { get { return GetResourceString("id8859p14"); } }

		public static string id8859p15 { get { return GetResourceString("id8859p15"); } }

		public static string id8859p16 { get { return GetResourceString("id8859p16"); } }

		public static string idJIS { get { return GetResourceString("idJIS"); } }

		public static string idShiftJIS { get { return GetResourceString("idShiftJIS"); } }

		public static string idEUCJP { get { return GetResourceString("idEUCJP"); } }

		public static string idUSASCII { get { return GetResourceString("idUSASCII"); } }

		public static string idebcdic { get { return GetResourceString("idebcdic"); } }

		public static string idEUCKR { get { return GetResourceString("idEUCKR"); } }

		public static string idBIG5 { get { return GetResourceString("idBIG5"); } }

		public static string idGB2312 { get { return GetResourceString("idGB2312"); } }

		public static string idUnclass { get { return GetResourceString("idUnclass"); } }

		public static string idRestr { get { return GetResourceString("idRestr"); } }

		public static string idConfid { get { return GetResourceString("idConfid"); } }

		public static string idSecret { get { return GetResourceString("idSecret"); } }

		public static string idTopSecret { get { return GetResourceString("idTopSecret"); } }

		public static string idImg { get { return GetResourceString("idImg"); } }

		public static string idThematicClass { get { return GetResourceString("idThematicClass"); } }

		public static string idPhysMeas { get { return GetResourceString("idPhysMeas"); } }

		public static string idClass { get { return GetResourceString("idClass"); } }

		public static string idCodelist { get { return GetResourceString("idCodelist"); } }

		public static string idEnum { get { return GetResourceString("idEnum"); } }

		public static string idCodelistElem { get { return GetResourceString("idCodelistElem"); } }

		public static string idAbstractClass { get { return GetResourceString("idAbstractClass"); } }

		public static string idAggregateClass { get { return GetResourceString("idAggregateClass"); } }

		public static string idSpecClass { get { return GetResourceString("idSpecClass"); } }

		public static string idDatatypeClass { get { return GetResourceString("idDatatypeClass"); } }

		public static string idInterfaceClass { get { return GetResourceString("idInterfaceClass"); } }

		public static string idUnionClass { get { return GetResourceString("idUnionClass"); } }

		public static string idMetaClass { get { return GetResourceString("idMetaClass"); } }

		public static string idTypeClass { get { return GetResourceString("idTypeClass"); } }

		public static string idCharString { get { return GetResourceString("idCharString"); } }

		public static string idInt { get { return GetResourceString("idInt"); } }

		public static string idAssoc { get { return GetResourceString("idAssoc"); } }

		public static string idRowYaxis { get { return GetResourceString("idRowYaxis"); } }

		public static string idColXaxis { get { return GetResourceString("idColXaxis"); } }

		public static string idVertZaxis { get { return GetResourceString("idVertZaxis"); } }

		public static string idTrack { get { return GetResourceString("idTrack"); } }

		public static string idCrossTrack { get { return GetResourceString("idCrossTrack"); } }

		public static string idSensorScanLine { get { return GetResourceString("idSensorScanLine"); } }

		public static string idSampleAlongScanLine { get { return GetResourceString("idSampleAlongScanLine"); } }

		public static string idTimeDur { get { return GetResourceString("idTimeDur"); } }

		public static string idComplex { get { return GetResourceString("idComplex"); } }

		public static string idComposite { get { return GetResourceString("idComposite"); } }

		public static string idCurve { get { return GetResourceString("idCurve"); } }

		public static string idPoint { get { return GetResourceString("idPoint"); } }

		public static string idSolid { get { return GetResourceString("idSolid"); } }

		public static string idSurface { get { return GetResourceString("idSurface"); } }

		public static string idBlurredImg { get { return GetResourceString("idBlurredImg"); } }

		public static string idCloud { get { return GetResourceString("idCloud"); } }

		public static string idDegradingObliquity { get { return GetResourceString("idDegradingObliquity"); } }

		public static string idFog { get { return GetResourceString("idFog"); } }

		public static string idHeavySmokeDust { get { return GetResourceString("idHeavySmokeDust"); } }

		public static string idNight { get { return GetResourceString("idNight"); } }

		public static string idRain { get { return GetResourceString("idRain"); } }

		public static string idSemidark { get { return GetResourceString("idSemidark"); } }

		public static string idShadow { get { return GetResourceString("idShadow"); } }

		public static string idSnow { get { return GetResourceString("idSnow"); } }

		public static string idTerrainMask { get { return GetResourceString("idTerrainMask"); } }

		public static string idDiscipline { get { return GetResourceString("idDiscipline"); } }

		public static string idPlace_codelists { get { return GetResourceString("idPlace_codelists"); } }

		public static string idStratum_codelists { get { return GetResourceString("idStratum_codelists"); } }

		public static string idTemporal_codelists { get { return GetResourceString("idTemporal_codelists"); } }

		public static string idTheme_codelists { get { return GetResourceString("idTheme_codelists"); } }

		public static string idCont { get { return GetResourceString("idCont"); } }

		public static string idDaily { get { return GetResourceString("idDaily"); } }

		public static string idWeekly { get { return GetResourceString("idWeekly"); } }

		public static string idFortnightly { get { return GetResourceString("idFortnightly"); } }

		public static string idMonthly { get { return GetResourceString("idMonthly"); } }

		public static string idQuarterly { get { return GetResourceString("idQuarterly"); } }

		public static string idBiannually { get { return GetResourceString("idBiannually"); } }

		public static string idAnnually { get { return GetResourceString("idAnnually"); } }

		public static string idAsNeeded { get { return GetResourceString("idAsNeeded"); } }

		public static string idIrregular { get { return GetResourceString("idIrregular"); } }

		public static string idNotPlanned { get { return GetResourceString("idNotPlanned"); } }

		public static string idUnkn { get { return GetResourceString("idUnkn"); } }

		public static string idCpio { get { return GetResourceString("idCpio"); } }

		public static string idTar { get { return GetResourceString("idTar"); } }

		public static string idHighSierraFileSys { get { return GetResourceString("idHighSierraFileSys"); } }

		public static string idIso9660Cdrom { get { return GetResourceString("idIso9660Cdrom"); } }

		public static string idIso9660RockRidgeUnix { get { return GetResourceString("idIso9660RockRidgeUnix"); } }

		public static string idIso9660AppleHfs { get { return GetResourceString("idIso9660AppleHfs"); } }

		public static string idCdrom { get { return GetResourceString("idCdrom"); } }

		public static string idDvd { get { return GetResourceString("idDvd"); } }

		public static string idDvdrom { get { return GetResourceString("idDvdrom"); } }

		public static string id35InFDD { get { return GetResourceString("id35InFDD"); } }

		public static string id525InFDD { get { return GetResourceString("id525InFDD"); } }

		public static string id7TrackTape { get { return GetResourceString("id7TrackTape"); } }

		public static string id9TrackTape { get { return GetResourceString("id9TrackTape"); } }

		public static string id3480CartridgeTape { get { return GetResourceString("id3480CartridgeTape"); } }

		public static string id3490CartridgeTape { get { return GetResourceString("id3490CartridgeTape"); } }

		public static string id3580CartridgeTape { get { return GetResourceString("id3580CartridgeTape"); } }

		public static string id4mmCartridgeTape { get { return GetResourceString("id4mmCartridgeTape"); } }

		public static string id8mmCartridgeTape { get { return GetResourceString("id8mmCartridgeTape"); } }

		public static string id025InCartridgeTape { get { return GetResourceString("id025InCartridgeTape"); } }

		public static string idDigitalLinearTape { get { return GetResourceString("idDigitalLinearTape"); } }

		public static string idOnlineLink { get { return GetResourceString("idOnlineLink"); } }

		public static string idSatLink { get { return GetResourceString("idSatLink"); } }

		public static string idTelephoneLink { get { return GetResourceString("idTelephoneLink"); } }

		public static string idHardcopy { get { return GetResourceString("idHardcopy"); } }

		public static string idMandatory { get { return GetResourceString("idMandatory"); } }

		public static string idOptional { get { return GetResourceString("idOptional"); } }

		public static string idConditional { get { return GetResourceString("idConditional"); } }

		public static string idCenter { get { return GetResourceString("idCenter"); } }

		public static string idLowerLeft { get { return GetResourceString("idLowerLeft"); } }

		public static string idLowerRight { get { return GetResourceString("idLowerRight"); } }

		public static string idUpperRight { get { return GetResourceString("idUpperRight"); } }

		public static string idUpperLeft { get { return GetResourceString("idUpperLeft"); } }

		public static string idCompleted { get { return GetResourceString("idCompleted"); } }

		public static string idHistArchive { get { return GetResourceString("idHistArchive"); } }

		public static string idObsolete { get { return GetResourceString("idObsolete"); } }

		public static string idOngoing { get { return GetResourceString("idOngoing"); } }

		public static string idPlanned { get { return GetResourceString("idPlanned"); } }

		public static string idReqd { get { return GetResourceString("idReqd"); } }

		public static string idUnderDev { get { return GetResourceString("idUnderDev"); } }

		public static string idCopyright { get { return GetResourceString("idCopyright"); } }

		public static string idPatent { get { return GetResourceString("idPatent"); } }

		public static string idPatentPending { get { return GetResourceString("idPatentPending"); } }

		public static string idTrademark { get { return GetResourceString("idTrademark"); } }

		public static string idLicense { get { return GetResourceString("idLicense"); } }

		public static string idIntellectualPropRights { get { return GetResourceString("idIntellectualPropRights"); } }

		public static string idRestr_codelists { get { return GetResourceString("idRestr_codelists"); } }

		public static string idOtherRestr { get { return GetResourceString("idOtherRestr"); } }

		public static string idAttrib_codelists { get { return GetResourceString("idAttrib_codelists"); } }

		public static string idAttribType { get { return GetResourceString("idAttribType"); } }

		public static string idCollHw { get { return GetResourceString("idCollHw"); } }

		public static string idCollSession { get { return GetResourceString("idCollSession"); } }

		public static string idDataset { get { return GetResourceString("idDataset"); } }

		public static string idSeries_codelists { get { return GetResourceString("idSeries_codelists"); } }

		public static string idNongeoDataset { get { return GetResourceString("idNongeoDataset"); } }

		public static string idDimGrp { get { return GetResourceString("idDimGrp"); } }

		public static string idFeature { get { return GetResourceString("idFeature"); } }

		public static string idFeatureType { get { return GetResourceString("idFeatureType"); } }

		public static string idPropType { get { return GetResourceString("idPropType"); } }

		public static string idFieldSession { get { return GetResourceString("idFieldSession"); } }

		public static string idSw { get { return GetResourceString("idSw"); } }

		public static string idService { get { return GetResourceString("idService"); } }

		public static string idModel { get { return GetResourceString("idModel"); } }

		public static string idTile { get { return GetResourceString("idTile"); } }

		public static string idVec { get { return GetResourceString("idVec"); } }

		public static string idGrid { get { return GetResourceString("idGrid"); } }

		public static string idTextTable { get { return GetResourceString("idTextTable"); } }

		public static string idTin { get { return GetResourceString("idTin"); } }

		public static string idStereoModel { get { return GetResourceString("idStereoModel"); } }

		public static string idVid { get { return GetResourceString("idVid"); } }

		public static string idFarming { get { return GetResourceString("idFarming"); } }

		public static string idBiota { get { return GetResourceString("idBiota"); } }

		public static string idBounds { get { return GetResourceString("idBounds"); } }

		public static string idCMA { get { return GetResourceString("idCMA"); } }

		public static string idEcon { get { return GetResourceString("idEcon"); } }

		public static string idElev { get { return GetResourceString("idElev"); } }

		public static string idEnv { get { return GetResourceString("idEnv"); } }

		public static string idGSI { get { return GetResourceString("idGSI"); } }

		public static string idHealth { get { return GetResourceString("idHealth"); } }

		public static string idImageryBMEC { get { return GetResourceString("idImageryBMEC"); } }

		public static string idIntelMil { get { return GetResourceString("idIntelMil"); } }

		public static string idInlandwaters { get { return GetResourceString("idInlandwaters"); } }

		public static string idLocation { get { return GetResourceString("idLocation"); } }

		public static string idOceans { get { return GetResourceString("idOceans"); } }

		public static string idPlancadastre { get { return GetResourceString("idPlancadastre"); } }

		public static string idSociety { get { return GetResourceString("idSociety"); } }

		public static string idStructure { get { return GetResourceString("idStructure"); } }

		public static string idTransportation { get { return GetResourceString("idTransportation"); } }

		public static string idUtilsComm { get { return GetResourceString("idUtilsComm"); } }

		public static string idFarming_arcgis { get { return GetResourceString("idFarming_arcgis"); } }

		public static string idBiota_arcgis { get { return GetResourceString("idBiota_arcgis"); } }

		public static string idBounds_arcgis { get { return GetResourceString("idBounds_arcgis"); } }

		public static string idCMA_arcgis { get { return GetResourceString("idCMA_arcgis"); } }

		public static string idEcon_arcgis { get { return GetResourceString("idEcon_arcgis"); } }

		public static string idElev_arcgis { get { return GetResourceString("idElev_arcgis"); } }

		public static string idEnv_arcgis { get { return GetResourceString("idEnv_arcgis"); } }

		public static string idGSI_arcgis { get { return GetResourceString("idGSI_arcgis"); } }

		public static string idHealth_arcgis { get { return GetResourceString("idHealth_arcgis"); } }

		public static string idImageryBMEC_arcgis { get { return GetResourceString("idImageryBMEC_arcgis"); } }

		public static string idIntelMil_arcgis { get { return GetResourceString("idIntelMil_arcgis"); } }

		public static string idInlandwaters_arcgis { get { return GetResourceString("idInlandwaters_arcgis"); } }

		public static string idLocation_arcgis { get { return GetResourceString("idLocation_arcgis"); } }

		public static string idOceans_arcgis { get { return GetResourceString("idOceans_arcgis"); } }

		public static string idPlancadastre_arcgis { get { return GetResourceString("idPlancadastre_arcgis"); } }

		public static string idSociety_arcgis { get { return GetResourceString("idSociety_arcgis"); } }

		public static string idStructure_arcgis { get { return GetResourceString("idStructure_arcgis"); } }

		public static string idTransportation_arcgis { get { return GetResourceString("idTransportation_arcgis"); } }

		public static string idUtilsComm_arcgis { get { return GetResourceString("idUtilsComm_arcgis"); } }

		public static string idGeoOnly { get { return GetResourceString("idGeoOnly"); } }

		public static string idTopo1d { get { return GetResourceString("idTopo1d"); } }

		public static string idPlanarGraph { get { return GetResourceString("idPlanarGraph"); } }

		public static string idFullPlanarGraph { get { return GetResourceString("idFullPlanarGraph"); } }

		public static string idSurfaceGraph { get { return GetResourceString("idSurfaceGraph"); } }

		public static string idFullSurfaceGraph { get { return GetResourceString("idFullSurfaceGraph"); } }

		public static string idTopo3d { get { return GetResourceString("idTopo3d"); } }

		public static string idFullTopo3d { get { return GetResourceString("idFullTopo3d"); } }

		public static string idAbstract_codelists { get { return GetResourceString("idAbstract_codelists"); } }

		public static string idLiveDataMaps { get { return GetResourceString("idLiveDataMaps"); } }

		public static string idDlData { get { return GetResourceString("idDlData"); } }

		public static string idOfflineData { get { return GetResourceString("idOfflineData"); } }

		public static string idStaticMapImages { get { return GetResourceString("idStaticMapImages"); } }

		public static string idOtherDocs { get { return GetResourceString("idOtherDocs"); } }

		public static string idApps { get { return GetResourceString("idApps"); } }

		public static string idGeoSvcs { get { return GetResourceString("idGeoSvcs"); } }

		public static string idClearinghouses { get { return GetResourceString("idClearinghouses"); } }

		public static string idMapFiles { get { return GetResourceString("idMapFiles"); } }

		public static string idGeoActivities { get { return GetResourceString("idGeoActivities"); } }

		public static string idPixDepth { get { return GetResourceString("idPixDepth"); } }

		public static string idHasColmap { get { return GetResourceString("idHasColmap"); } }

		public static string idCompressionType { get { return GetResourceString("idCompressionType"); } }

		public static string idNumBands { get { return GetResourceString("idNumBands"); } }

		public static string idRasterFmt { get { return GetResourceString("idRasterFmt"); } }

		public static string idHasPyramids { get { return GetResourceString("idHasPyramids"); } }

		public static string idSrcType { get { return GetResourceString("idSrcType"); } }

		public static string idPixType { get { return GetResourceString("idPixType"); } }

		public static string idNoDataVal { get { return GetResourceString("idNoDataVal"); } }

		public static string idToolsets { get { return GetResourceString("idToolsets"); } }

		public static string idToolset { get { return GetResourceString("idToolset"); } }

		public static string idSummary { get { return GetResourceString("idSummary"); } }

		public static string idIllus { get { return GetResourceString("idIllus"); } }

		public static string idIllus_geoprocessing { get { return GetResourceString("idIllus_geoprocessing"); } }

		public static string idUsage { get { return GetResourceString("idUsage"); } }

		public static string idSyntax { get { return GetResourceString("idSyntax"); } }

		public static string idParam { get { return GetResourceString("idParam"); } }

		public static string idExpl { get { return GetResourceString("idExpl"); } }

		public static string idDataType_geoprocessing { get { return GetResourceString("idDataType_geoprocessing"); } }

		public static string idCodeSamples { get { return GetResourceString("idCodeSamples"); } }

		public static string idScriptExample { get { return GetResourceString("idScriptExample"); } }

		public static string idEnvs { get { return GetResourceString("idEnvs"); } }

		public static string idModel_geoprocessing { get { return GetResourceString("idModel_geoprocessing"); } }

		public static string idElements { get { return GetResourceString("idElements"); } }

		public static string idName_geoprocessing { get { return GetResourceString("idName_geoprocessing"); } }

		public static string idExpl_geoprocessing { get { return GetResourceString("idExpl_geoprocessing"); } }

		public static string idItemDesc { get { return GetResourceString("idItemDesc"); } }

		public static string idTags { get { return GetResourceString("idTags"); } }

		public static string idSummary_ItemDescription { get { return GetResourceString("idSummary_ItemDescription"); } }

		public static string idDesc_ItemDescription { get { return GetResourceString("idDesc_ItemDescription"); } }

		public static string idAbstract_ItemDescription { get { return GetResourceString("idAbstract_ItemDescription"); } }

		public static string idCredits_ItemDescription { get { return GetResourceString("idCredits_ItemDescription"); } }

		public static string idNoTitle { get { return GetResourceString("idNoTitle"); } }

		public static string idThumbnailNotAvail { get { return GetResourceString("idThumbnailNotAvail"); } }

		public static string idNoTagsForItem { get { return GetResourceString("idNoTagsForItem"); } }

		public static string idNoSummaryForItem { get { return GetResourceString("idNoSummaryForItem"); } }

		public static string idNoDescForItem { get { return GetResourceString("idNoDescForItem"); } }

		public static string idNoCreditsForItem { get { return GetResourceString("idNoCreditsForItem"); } }

		public static string idCountryName_AFG { get { return GetResourceString("idCountryName_AFG"); } }

		public static string idCountryName_ALA { get { return GetResourceString("idCountryName_ALA"); } }

		public static string idCountryName_ALB { get { return GetResourceString("idCountryName_ALB"); } }

		public static string idCountryName_DZA { get { return GetResourceString("idCountryName_DZA"); } }

		public static string idCountryName_ASM { get { return GetResourceString("idCountryName_ASM"); } }

		public static string idCountryName_AND { get { return GetResourceString("idCountryName_AND"); } }

		public static string idCountryName_AGO { get { return GetResourceString("idCountryName_AGO"); } }

		public static string idCountryName_AIA { get { return GetResourceString("idCountryName_AIA"); } }

		public static string idCountryName_ATA { get { return GetResourceString("idCountryName_ATA"); } }

		public static string idCountryName_ATG { get { return GetResourceString("idCountryName_ATG"); } }

		public static string idCountryName_ARG { get { return GetResourceString("idCountryName_ARG"); } }

		public static string idCountryName_ARM { get { return GetResourceString("idCountryName_ARM"); } }

		public static string idCountryName_ABW { get { return GetResourceString("idCountryName_ABW"); } }

		public static string idCountryName_AUS { get { return GetResourceString("idCountryName_AUS"); } }

		public static string idCountryName_AUT { get { return GetResourceString("idCountryName_AUT"); } }

		public static string idCountryName_AZE { get { return GetResourceString("idCountryName_AZE"); } }

		public static string idCountryName_BHS { get { return GetResourceString("idCountryName_BHS"); } }

		public static string idCountryName_BHR { get { return GetResourceString("idCountryName_BHR"); } }

		public static string idCountryName_BGD { get { return GetResourceString("idCountryName_BGD"); } }

		public static string idCountryName_BRB { get { return GetResourceString("idCountryName_BRB"); } }

		public static string idCountryName_BLR { get { return GetResourceString("idCountryName_BLR"); } }

		public static string idCountryName_BEL { get { return GetResourceString("idCountryName_BEL"); } }

		public static string idCountryName_BLZ { get { return GetResourceString("idCountryName_BLZ"); } }

		public static string idCountryName_BEN { get { return GetResourceString("idCountryName_BEN"); } }

		public static string idCountryName_BMU { get { return GetResourceString("idCountryName_BMU"); } }

		public static string idCountryName_BTN { get { return GetResourceString("idCountryName_BTN"); } }

		public static string idCountryName_BOL { get { return GetResourceString("idCountryName_BOL"); } }

		public static string idCountryName_BIH { get { return GetResourceString("idCountryName_BIH"); } }

		public static string idCountryName_BWA { get { return GetResourceString("idCountryName_BWA"); } }

		public static string idCountryName_BVT { get { return GetResourceString("idCountryName_BVT"); } }

		public static string idCountryName_BRA { get { return GetResourceString("idCountryName_BRA"); } }

		public static string idCountryName_IOT { get { return GetResourceString("idCountryName_IOT"); } }

		public static string idCountryName_BRN { get { return GetResourceString("idCountryName_BRN"); } }

		public static string idCountryName_BGR { get { return GetResourceString("idCountryName_BGR"); } }

		public static string idCountryName_BFA { get { return GetResourceString("idCountryName_BFA"); } }

		public static string idCountryName_BDI { get { return GetResourceString("idCountryName_BDI"); } }

		public static string idCountryName_KHM { get { return GetResourceString("idCountryName_KHM"); } }

		public static string idCountryName_CMR { get { return GetResourceString("idCountryName_CMR"); } }

		public static string idCountryName_CAN { get { return GetResourceString("idCountryName_CAN"); } }

		public static string idCountryName_CPV { get { return GetResourceString("idCountryName_CPV"); } }

		public static string idCountryName_CYM { get { return GetResourceString("idCountryName_CYM"); } }

		public static string idCountryName_CAF { get { return GetResourceString("idCountryName_CAF"); } }

		public static string idCountryName_TCD { get { return GetResourceString("idCountryName_TCD"); } }

		public static string idCountryName_CHL { get { return GetResourceString("idCountryName_CHL"); } }

		public static string idCountryName_CHN { get { return GetResourceString("idCountryName_CHN"); } }

		public static string idCountryName_CXR { get { return GetResourceString("idCountryName_CXR"); } }

		public static string idCountryName_CCK { get { return GetResourceString("idCountryName_CCK"); } }

		public static string idCountryName_COL { get { return GetResourceString("idCountryName_COL"); } }

		public static string idCountryName_COM { get { return GetResourceString("idCountryName_COM"); } }

		public static string idCountryName_COG { get { return GetResourceString("idCountryName_COG"); } }

		public static string idCountryName_COD { get { return GetResourceString("idCountryName_COD"); } }

		public static string idCountryName_COK { get { return GetResourceString("idCountryName_COK"); } }

		public static string idCountryName_CRI { get { return GetResourceString("idCountryName_CRI"); } }

		public static string idCountryName_CIV { get { return GetResourceString("idCountryName_CIV"); } }

		public static string idCountryName_HRV { get { return GetResourceString("idCountryName_HRV"); } }

		public static string idCountryName_CUB { get { return GetResourceString("idCountryName_CUB"); } }

		public static string idCountryName_CYP { get { return GetResourceString("idCountryName_CYP"); } }

		public static string idCountryName_CZE { get { return GetResourceString("idCountryName_CZE"); } }

		public static string idCountryName_DNK { get { return GetResourceString("idCountryName_DNK"); } }

		public static string idCountryName_DJI { get { return GetResourceString("idCountryName_DJI"); } }

		public static string idCountryName_DMA { get { return GetResourceString("idCountryName_DMA"); } }

		public static string idCountryName_DOM { get { return GetResourceString("idCountryName_DOM"); } }

		public static string idCountryName_ECU { get { return GetResourceString("idCountryName_ECU"); } }

		public static string idCountryName_EGY { get { return GetResourceString("idCountryName_EGY"); } }

		public static string idCountryName_SLV { get { return GetResourceString("idCountryName_SLV"); } }

		public static string idCountryName_GNQ { get { return GetResourceString("idCountryName_GNQ"); } }

		public static string idCountryName_ERI { get { return GetResourceString("idCountryName_ERI"); } }

		public static string idCountryName_EST { get { return GetResourceString("idCountryName_EST"); } }

		public static string idCountryName_ETH { get { return GetResourceString("idCountryName_ETH"); } }

		public static string idCountryName_FLK { get { return GetResourceString("idCountryName_FLK"); } }

		public static string idCountryName_FRO { get { return GetResourceString("idCountryName_FRO"); } }

		public static string idCountryName_FJI { get { return GetResourceString("idCountryName_FJI"); } }

		public static string idCountryName_FIN { get { return GetResourceString("idCountryName_FIN"); } }

		public static string idCountryName_FRA { get { return GetResourceString("idCountryName_FRA"); } }

		public static string idCountryName_GUF { get { return GetResourceString("idCountryName_GUF"); } }

		public static string idCountryName_PYF { get { return GetResourceString("idCountryName_PYF"); } }

		public static string idCountryName_ATF { get { return GetResourceString("idCountryName_ATF"); } }

		public static string idCountryName_GAB { get { return GetResourceString("idCountryName_GAB"); } }

		public static string idCountryName_GMB { get { return GetResourceString("idCountryName_GMB"); } }

		public static string idCountryName_GEO { get { return GetResourceString("idCountryName_GEO"); } }

		public static string idCountryName_DEU { get { return GetResourceString("idCountryName_DEU"); } }

		public static string idCountryName_GHA { get { return GetResourceString("idCountryName_GHA"); } }

		public static string idCountryName_GIB { get { return GetResourceString("idCountryName_GIB"); } }

		public static string idCountryName_GRC { get { return GetResourceString("idCountryName_GRC"); } }

		public static string idCountryName_GRL { get { return GetResourceString("idCountryName_GRL"); } }

		public static string idCountryName_GRD { get { return GetResourceString("idCountryName_GRD"); } }

		public static string idCountryName_GLP { get { return GetResourceString("idCountryName_GLP"); } }

		public static string idCountryName_GUM { get { return GetResourceString("idCountryName_GUM"); } }

		public static string idCountryName_GTM { get { return GetResourceString("idCountryName_GTM"); } }

		public static string idCountryName_GGY { get { return GetResourceString("idCountryName_GGY"); } }

		public static string idCountryName_GIN { get { return GetResourceString("idCountryName_GIN"); } }

		public static string idCountryName_GNB { get { return GetResourceString("idCountryName_GNB"); } }

		public static string idCountryName_GUY { get { return GetResourceString("idCountryName_GUY"); } }

		public static string idCountryName_HTI { get { return GetResourceString("idCountryName_HTI"); } }

		public static string idCountryName_HMD { get { return GetResourceString("idCountryName_HMD"); } }

		public static string idCountryName_VAT { get { return GetResourceString("idCountryName_VAT"); } }

		public static string idCountryName_HND { get { return GetResourceString("idCountryName_HND"); } }

		public static string idCountryName_HKG { get { return GetResourceString("idCountryName_HKG"); } }

		public static string idCountryName_HUN { get { return GetResourceString("idCountryName_HUN"); } }

		public static string idCountryName_ISL { get { return GetResourceString("idCountryName_ISL"); } }

		public static string idCountryName_IND { get { return GetResourceString("idCountryName_IND"); } }

		public static string idCountryName_IDN { get { return GetResourceString("idCountryName_IDN"); } }

		public static string idCountryName_IRN { get { return GetResourceString("idCountryName_IRN"); } }

		public static string idCountryName_IRQ { get { return GetResourceString("idCountryName_IRQ"); } }

		public static string idCountryName_IRL { get { return GetResourceString("idCountryName_IRL"); } }

		public static string idCountryName_IMN { get { return GetResourceString("idCountryName_IMN"); } }

		public static string idCountryName_ISR { get { return GetResourceString("idCountryName_ISR"); } }

		public static string idCountryName_ITA { get { return GetResourceString("idCountryName_ITA"); } }

		public static string idCountryName_JAM { get { return GetResourceString("idCountryName_JAM"); } }

		public static string idCountryName_JPN { get { return GetResourceString("idCountryName_JPN"); } }

		public static string idCountryName_JEY { get { return GetResourceString("idCountryName_JEY"); } }

		public static string idCountryName_JOR { get { return GetResourceString("idCountryName_JOR"); } }

		public static string idCountryName_KAZ { get { return GetResourceString("idCountryName_KAZ"); } }

		public static string idCountryName_KEN { get { return GetResourceString("idCountryName_KEN"); } }

		public static string idCountryName_KIR { get { return GetResourceString("idCountryName_KIR"); } }

		public static string idCountryName_PRK { get { return GetResourceString("idCountryName_PRK"); } }

		public static string idCountryName_KOR { get { return GetResourceString("idCountryName_KOR"); } }

		public static string idCountryName_KWT { get { return GetResourceString("idCountryName_KWT"); } }

		public static string idCountryName_KGZ { get { return GetResourceString("idCountryName_KGZ"); } }

		public static string idCountryName_LAO { get { return GetResourceString("idCountryName_LAO"); } }

		public static string idCountryName_LVA { get { return GetResourceString("idCountryName_LVA"); } }

		public static string idCountryName_LBN { get { return GetResourceString("idCountryName_LBN"); } }

		public static string idCountryName_LSO { get { return GetResourceString("idCountryName_LSO"); } }

		public static string idCountryName_LBR { get { return GetResourceString("idCountryName_LBR"); } }

		public static string idCountryName_LBY { get { return GetResourceString("idCountryName_LBY"); } }

		public static string idCountryName_LIE { get { return GetResourceString("idCountryName_LIE"); } }

		public static string idCountryName_LTU { get { return GetResourceString("idCountryName_LTU"); } }

		public static string idCountryName_LUX { get { return GetResourceString("idCountryName_LUX"); } }

		public static string idCountryName_MAC { get { return GetResourceString("idCountryName_MAC"); } }

		public static string idCountryName_MKD { get { return GetResourceString("idCountryName_MKD"); } }

		public static string idCountryName_MDG { get { return GetResourceString("idCountryName_MDG"); } }

		public static string idCountryName_MWI { get { return GetResourceString("idCountryName_MWI"); } }

		public static string idCountryName_MYS { get { return GetResourceString("idCountryName_MYS"); } }

		public static string idCountryName_MDV { get { return GetResourceString("idCountryName_MDV"); } }

		public static string idCountryName_MLI { get { return GetResourceString("idCountryName_MLI"); } }

		public static string idCountryName_MLT { get { return GetResourceString("idCountryName_MLT"); } }

		public static string idCountryName_MHL { get { return GetResourceString("idCountryName_MHL"); } }

		public static string idCountryName_MTQ { get { return GetResourceString("idCountryName_MTQ"); } }

		public static string idCountryName_MRT { get { return GetResourceString("idCountryName_MRT"); } }

		public static string idCountryName_MUS { get { return GetResourceString("idCountryName_MUS"); } }

		public static string idCountryName_MYT { get { return GetResourceString("idCountryName_MYT"); } }

		public static string idCountryName_MEX { get { return GetResourceString("idCountryName_MEX"); } }

		public static string idCountryName_FSM { get { return GetResourceString("idCountryName_FSM"); } }

		public static string idCountryName_MDA { get { return GetResourceString("idCountryName_MDA"); } }

		public static string idCountryName_MCO { get { return GetResourceString("idCountryName_MCO"); } }

		public static string idCountryName_MNG { get { return GetResourceString("idCountryName_MNG"); } }

		public static string idCountryName_MNE { get { return GetResourceString("idCountryName_MNE"); } }

		public static string idCountryName_MSR { get { return GetResourceString("idCountryName_MSR"); } }

		public static string idCountryName_MAR { get { return GetResourceString("idCountryName_MAR"); } }

		public static string idCountryName_MOZ { get { return GetResourceString("idCountryName_MOZ"); } }

		public static string idCountryName_MMR { get { return GetResourceString("idCountryName_MMR"); } }

		public static string idCountryName_NAM { get { return GetResourceString("idCountryName_NAM"); } }

		public static string idCountryName_NRU { get { return GetResourceString("idCountryName_NRU"); } }

		public static string idCountryName_NPL { get { return GetResourceString("idCountryName_NPL"); } }

		public static string idCountryName_NLD { get { return GetResourceString("idCountryName_NLD"); } }

		public static string idCountryName_NCL { get { return GetResourceString("idCountryName_NCL"); } }

		public static string idCountryName_NZL { get { return GetResourceString("idCountryName_NZL"); } }

		public static string idCountryName_NIC { get { return GetResourceString("idCountryName_NIC"); } }

		public static string idCountryName_NER { get { return GetResourceString("idCountryName_NER"); } }

		public static string idCountryName_NGA { get { return GetResourceString("idCountryName_NGA"); } }

		public static string idCountryName_NIU { get { return GetResourceString("idCountryName_NIU"); } }

		public static string idCountryName_NFK { get { return GetResourceString("idCountryName_NFK"); } }

		public static string idCountryName_MNP { get { return GetResourceString("idCountryName_MNP"); } }

		public static string idCountryName_NOR { get { return GetResourceString("idCountryName_NOR"); } }

		public static string idCountryName_OMN { get { return GetResourceString("idCountryName_OMN"); } }

		public static string idCountryName_PAK { get { return GetResourceString("idCountryName_PAK"); } }

		public static string idCountryName_PLW { get { return GetResourceString("idCountryName_PLW"); } }

		public static string idCountryName_PSE { get { return GetResourceString("idCountryName_PSE"); } }

		public static string idCountryName_PAN { get { return GetResourceString("idCountryName_PAN"); } }

		public static string idCountryName_PNG { get { return GetResourceString("idCountryName_PNG"); } }

		public static string idCountryName_PRY { get { return GetResourceString("idCountryName_PRY"); } }

		public static string idCountryName_PER { get { return GetResourceString("idCountryName_PER"); } }

		public static string idCountryName_PHL { get { return GetResourceString("idCountryName_PHL"); } }

		public static string idCountryName_PCN { get { return GetResourceString("idCountryName_PCN"); } }

		public static string idCountryName_POL { get { return GetResourceString("idCountryName_POL"); } }

		public static string idCountryName_PRT { get { return GetResourceString("idCountryName_PRT"); } }

		public static string idCountryName_PRI { get { return GetResourceString("idCountryName_PRI"); } }

		public static string idCountryName_QAT { get { return GetResourceString("idCountryName_QAT"); } }

		public static string idCountryName_REU { get { return GetResourceString("idCountryName_REU"); } }

		public static string idCountryName_ROU { get { return GetResourceString("idCountryName_ROU"); } }

		public static string idCountryName_RUS { get { return GetResourceString("idCountryName_RUS"); } }

		public static string idCountryName_RWA { get { return GetResourceString("idCountryName_RWA"); } }

		public static string idCountryName_BLM { get { return GetResourceString("idCountryName_BLM"); } }

		public static string idCountryName_SHN { get { return GetResourceString("idCountryName_SHN"); } }

		public static string idCountryName_KNA { get { return GetResourceString("idCountryName_KNA"); } }

		public static string idCountryName_LCA { get { return GetResourceString("idCountryName_LCA"); } }

		public static string idCountryName_MAF { get { return GetResourceString("idCountryName_MAF"); } }

		public static string idCountryName_SPM { get { return GetResourceString("idCountryName_SPM"); } }

		public static string idCountryName_VCT { get { return GetResourceString("idCountryName_VCT"); } }

		public static string idCountryName_WSM { get { return GetResourceString("idCountryName_WSM"); } }

		public static string idCountryName_SMR { get { return GetResourceString("idCountryName_SMR"); } }

		public static string idCountryName_STP { get { return GetResourceString("idCountryName_STP"); } }

		public static string idCountryName_SAU { get { return GetResourceString("idCountryName_SAU"); } }

		public static string idCountryName_SEN { get { return GetResourceString("idCountryName_SEN"); } }

		public static string idCountryName_SRB { get { return GetResourceString("idCountryName_SRB"); } }

		public static string idCountryName_SYC { get { return GetResourceString("idCountryName_SYC"); } }

		public static string idCountryName_SLE { get { return GetResourceString("idCountryName_SLE"); } }

		public static string idCountryName_SGP { get { return GetResourceString("idCountryName_SGP"); } }

		public static string idCountryName_SVK { get { return GetResourceString("idCountryName_SVK"); } }

		public static string idCountryName_SVN { get { return GetResourceString("idCountryName_SVN"); } }

		public static string idCountryName_SLB { get { return GetResourceString("idCountryName_SLB"); } }

		public static string idCountryName_SOM { get { return GetResourceString("idCountryName_SOM"); } }

		public static string idCountryName_ZAF { get { return GetResourceString("idCountryName_ZAF"); } }

		public static string idCountryName_SGS { get { return GetResourceString("idCountryName_SGS"); } }

		public static string idCountryName_ESP { get { return GetResourceString("idCountryName_ESP"); } }

		public static string idCountryName_LKA { get { return GetResourceString("idCountryName_LKA"); } }

		public static string idCountryName_SDN { get { return GetResourceString("idCountryName_SDN"); } }

		public static string idCountryName_SSD { get { return GetResourceString("idCountryName_SSD"); } }

		public static string idCountryName_SUR { get { return GetResourceString("idCountryName_SUR"); } }

		public static string idCountryName_SJM { get { return GetResourceString("idCountryName_SJM"); } }

		public static string idCountryName_SWZ { get { return GetResourceString("idCountryName_SWZ"); } }

		public static string idCountryName_SWE { get { return GetResourceString("idCountryName_SWE"); } }

		public static string idCountryName_CHE { get { return GetResourceString("idCountryName_CHE"); } }

		public static string idCountryName_SYR { get { return GetResourceString("idCountryName_SYR"); } }

		public static string idCountryName_TWN { get { return GetResourceString("idCountryName_TWN"); } }

		public static string idCountryName_TJK { get { return GetResourceString("idCountryName_TJK"); } }

		public static string idCountryName_TZA { get { return GetResourceString("idCountryName_TZA"); } }

		public static string idCountryName_THA { get { return GetResourceString("idCountryName_THA"); } }

		public static string idCountryName_TLS { get { return GetResourceString("idCountryName_TLS"); } }

		public static string idCountryName_TGO { get { return GetResourceString("idCountryName_TGO"); } }

		public static string idCountryName_TKL { get { return GetResourceString("idCountryName_TKL"); } }

		public static string idCountryName_TON { get { return GetResourceString("idCountryName_TON"); } }

		public static string idCountryName_TTO { get { return GetResourceString("idCountryName_TTO"); } }

		public static string idCountryName_TUN { get { return GetResourceString("idCountryName_TUN"); } }

		public static string idCountryName_TUR { get { return GetResourceString("idCountryName_TUR"); } }

		public static string idCountryName_TKM { get { return GetResourceString("idCountryName_TKM"); } }

		public static string idCountryName_TCA { get { return GetResourceString("idCountryName_TCA"); } }

		public static string idCountryName_TUV { get { return GetResourceString("idCountryName_TUV"); } }

		public static string idCountryName_UGA { get { return GetResourceString("idCountryName_UGA"); } }

		public static string idCountryName_UKR { get { return GetResourceString("idCountryName_UKR"); } }

		public static string idCountryName_ARE { get { return GetResourceString("idCountryName_ARE"); } }

		public static string idCountryName_GBR { get { return GetResourceString("idCountryName_GBR"); } }

		public static string idCountryName_USA { get { return GetResourceString("idCountryName_USA"); } }

		public static string idCountryName_UMI { get { return GetResourceString("idCountryName_UMI"); } }

		public static string idCountryName_URY { get { return GetResourceString("idCountryName_URY"); } }

		public static string idCountryName_UZB { get { return GetResourceString("idCountryName_UZB"); } }

		public static string idCountryName_VUT { get { return GetResourceString("idCountryName_VUT"); } }

		public static string idCountryName_VEN { get { return GetResourceString("idCountryName_VEN"); } }

		public static string idCountryName_VNM { get { return GetResourceString("idCountryName_VNM"); } }

		public static string idCountryName_VGB { get { return GetResourceString("idCountryName_VGB"); } }

		public static string idCountryName_VIR { get { return GetResourceString("idCountryName_VIR"); } }

		public static string idCountryName_WLF { get { return GetResourceString("idCountryName_WLF"); } }

		public static string idCountryName_ESH { get { return GetResourceString("idCountryName_ESH"); } }

		public static string idCountryName_YEM { get { return GetResourceString("idCountryName_YEM"); } }

		public static string idCountryName_ZMB { get { return GetResourceString("idCountryName_ZMB"); } }

		public static string idCountryName_ZWE { get { return GetResourceString("idCountryName_ZWE"); } }

		public static string idLanguageName_AAR { get { return GetResourceString("idLanguageName_AAR"); } }

		public static string idLanguageName_ABK { get { return GetResourceString("idLanguageName_ABK"); } }

		public static string idLanguageName_ACE { get { return GetResourceString("idLanguageName_ACE"); } }

		public static string idLanguageName_ACH { get { return GetResourceString("idLanguageName_ACH"); } }

		public static string idLanguageName_ADA { get { return GetResourceString("idLanguageName_ADA"); } }

		public static string idLanguageName_ADY { get { return GetResourceString("idLanguageName_ADY"); } }

		public static string idLanguageName_AFA { get { return GetResourceString("idLanguageName_AFA"); } }

		public static string idLanguageName_AFH { get { return GetResourceString("idLanguageName_AFH"); } }

		public static string idLanguageName_AFR { get { return GetResourceString("idLanguageName_AFR"); } }

		public static string idLanguageName_AIN { get { return GetResourceString("idLanguageName_AIN"); } }

		public static string idLanguageName_AKA { get { return GetResourceString("idLanguageName_AKA"); } }

		public static string idLanguageName_AKK { get { return GetResourceString("idLanguageName_AKK"); } }

		public static string idLanguageName_ALB { get { return GetResourceString("idLanguageName_ALB"); } }

		public static string idLanguageName_SQI { get { return GetResourceString("idLanguageName_SQI"); } }

		public static string idLanguageName_ALE { get { return GetResourceString("idLanguageName_ALE"); } }

		public static string idLanguageName_ALG { get { return GetResourceString("idLanguageName_ALG"); } }

		public static string idLanguageName_ALT { get { return GetResourceString("idLanguageName_ALT"); } }

		public static string idLanguageName_AMH { get { return GetResourceString("idLanguageName_AMH"); } }

		public static string idLanguageName_ANG { get { return GetResourceString("idLanguageName_ANG"); } }

		public static string idLanguageName_ANP { get { return GetResourceString("idLanguageName_ANP"); } }

		public static string idLanguageName_APA { get { return GetResourceString("idLanguageName_APA"); } }

		public static string idLanguageName_ARA { get { return GetResourceString("idLanguageName_ARA"); } }

		public static string idLanguageName_ARC { get { return GetResourceString("idLanguageName_ARC"); } }

		public static string idLanguageName_ARG { get { return GetResourceString("idLanguageName_ARG"); } }

		public static string idLanguageName_ARM { get { return GetResourceString("idLanguageName_ARM"); } }

		public static string idLanguageName_HYE { get { return GetResourceString("idLanguageName_HYE"); } }

		public static string idLanguageName_ARN { get { return GetResourceString("idLanguageName_ARN"); } }

		public static string idLanguageName_ARP { get { return GetResourceString("idLanguageName_ARP"); } }

		public static string idLanguageName_ART { get { return GetResourceString("idLanguageName_ART"); } }

		public static string idLanguageName_ARW { get { return GetResourceString("idLanguageName_ARW"); } }

		public static string idLanguageName_ASM { get { return GetResourceString("idLanguageName_ASM"); } }

		public static string idLanguageName_AST { get { return GetResourceString("idLanguageName_AST"); } }

		public static string idLanguageName_ATH { get { return GetResourceString("idLanguageName_ATH"); } }

		public static string idLanguageName_AUS { get { return GetResourceString("idLanguageName_AUS"); } }

		public static string idLanguageName_AVA { get { return GetResourceString("idLanguageName_AVA"); } }

		public static string idLanguageName_AVE { get { return GetResourceString("idLanguageName_AVE"); } }

		public static string idLanguageName_AWA { get { return GetResourceString("idLanguageName_AWA"); } }

		public static string idLanguageName_AYM { get { return GetResourceString("idLanguageName_AYM"); } }

		public static string idLanguageName_AZE { get { return GetResourceString("idLanguageName_AZE"); } }

		public static string idLanguageName_BAD { get { return GetResourceString("idLanguageName_BAD"); } }

		public static string idLanguageName_BAI { get { return GetResourceString("idLanguageName_BAI"); } }

		public static string idLanguageName_BAK { get { return GetResourceString("idLanguageName_BAK"); } }

		public static string idLanguageName_BAL { get { return GetResourceString("idLanguageName_BAL"); } }

		public static string idLanguageName_BAM { get { return GetResourceString("idLanguageName_BAM"); } }

		public static string idLanguageName_BAN { get { return GetResourceString("idLanguageName_BAN"); } }

		public static string idLanguageName_BAQ { get { return GetResourceString("idLanguageName_BAQ"); } }

		public static string idLanguageName_EUS { get { return GetResourceString("idLanguageName_EUS"); } }

		public static string idLanguageName_BAS { get { return GetResourceString("idLanguageName_BAS"); } }

		public static string idLanguageName_BAT { get { return GetResourceString("idLanguageName_BAT"); } }

		public static string idLanguageName_BEJ { get { return GetResourceString("idLanguageName_BEJ"); } }

		public static string idLanguageName_BEL { get { return GetResourceString("idLanguageName_BEL"); } }

		public static string idLanguageName_BEM { get { return GetResourceString("idLanguageName_BEM"); } }

		public static string idLanguageName_BEN { get { return GetResourceString("idLanguageName_BEN"); } }

		public static string idLanguageName_BER { get { return GetResourceString("idLanguageName_BER"); } }

		public static string idLanguageName_BHO { get { return GetResourceString("idLanguageName_BHO"); } }

		public static string idLanguageName_BIH { get { return GetResourceString("idLanguageName_BIH"); } }

		public static string idLanguageName_BIK { get { return GetResourceString("idLanguageName_BIK"); } }

		public static string idLanguageName_BIN { get { return GetResourceString("idLanguageName_BIN"); } }

		public static string idLanguageName_BIS { get { return GetResourceString("idLanguageName_BIS"); } }

		public static string idLanguageName_BLA { get { return GetResourceString("idLanguageName_BLA"); } }

		public static string idLanguageName_BNT { get { return GetResourceString("idLanguageName_BNT"); } }

		public static string idLanguageName_BOS { get { return GetResourceString("idLanguageName_BOS"); } }

		public static string idLanguageName_BRA { get { return GetResourceString("idLanguageName_BRA"); } }

		public static string idLanguageName_BRE { get { return GetResourceString("idLanguageName_BRE"); } }

		public static string idLanguageName_BTK { get { return GetResourceString("idLanguageName_BTK"); } }

		public static string idLanguageName_BUA { get { return GetResourceString("idLanguageName_BUA"); } }

		public static string idLanguageName_BUG { get { return GetResourceString("idLanguageName_BUG"); } }

		public static string idLanguageName_BUL { get { return GetResourceString("idLanguageName_BUL"); } }

		public static string idLanguageName_BUR { get { return GetResourceString("idLanguageName_BUR"); } }

		public static string idLanguageName_MYA { get { return GetResourceString("idLanguageName_MYA"); } }

		public static string idLanguageName_BYN { get { return GetResourceString("idLanguageName_BYN"); } }

		public static string idLanguageName_CAD { get { return GetResourceString("idLanguageName_CAD"); } }

		public static string idLanguageName_CAI { get { return GetResourceString("idLanguageName_CAI"); } }

		public static string idLanguageName_CAR { get { return GetResourceString("idLanguageName_CAR"); } }

		public static string idLanguageName_CAT { get { return GetResourceString("idLanguageName_CAT"); } }

		public static string idLanguageName_CAU { get { return GetResourceString("idLanguageName_CAU"); } }

		public static string idLanguageName_CEB { get { return GetResourceString("idLanguageName_CEB"); } }

		public static string idLanguageName_CEL { get { return GetResourceString("idLanguageName_CEL"); } }

		public static string idLanguageName_CHA { get { return GetResourceString("idLanguageName_CHA"); } }

		public static string idLanguageName_CHB { get { return GetResourceString("idLanguageName_CHB"); } }

		public static string idLanguageName_CHE { get { return GetResourceString("idLanguageName_CHE"); } }

		public static string idLanguageName_CHG { get { return GetResourceString("idLanguageName_CHG"); } }

		public static string idLanguageName_CHI { get { return GetResourceString("idLanguageName_CHI"); } }

		public static string idLanguageName_ZHO { get { return GetResourceString("idLanguageName_ZHO"); } }

		public static string idLanguageName_CHK { get { return GetResourceString("idLanguageName_CHK"); } }

		public static string idLanguageName_CHM { get { return GetResourceString("idLanguageName_CHM"); } }

		public static string idLanguageName_CHN { get { return GetResourceString("idLanguageName_CHN"); } }

		public static string idLanguageName_CHO { get { return GetResourceString("idLanguageName_CHO"); } }

		public static string idLanguageName_CHP { get { return GetResourceString("idLanguageName_CHP"); } }

		public static string idLanguageName_CHR { get { return GetResourceString("idLanguageName_CHR"); } }

		public static string idLanguageName_CHU { get { return GetResourceString("idLanguageName_CHU"); } }

		public static string idLanguageName_CHV { get { return GetResourceString("idLanguageName_CHV"); } }

		public static string idLanguageName_CHY { get { return GetResourceString("idLanguageName_CHY"); } }

		public static string idLanguageName_CMC { get { return GetResourceString("idLanguageName_CMC"); } }

		public static string idLanguageName_COP { get { return GetResourceString("idLanguageName_COP"); } }

		public static string idLanguageName_COR { get { return GetResourceString("idLanguageName_COR"); } }

		public static string idLanguageName_COS { get { return GetResourceString("idLanguageName_COS"); } }

		public static string idLanguageName_CPE { get { return GetResourceString("idLanguageName_CPE"); } }

		public static string idLanguageName_CPF { get { return GetResourceString("idLanguageName_CPF"); } }

		public static string idLanguageName_CPP { get { return GetResourceString("idLanguageName_CPP"); } }

		public static string idLanguageName_CRE { get { return GetResourceString("idLanguageName_CRE"); } }

		public static string idLanguageName_CRH { get { return GetResourceString("idLanguageName_CRH"); } }

		public static string idLanguageName_CRP { get { return GetResourceString("idLanguageName_CRP"); } }

		public static string idLanguageName_CSB { get { return GetResourceString("idLanguageName_CSB"); } }

		public static string idLanguageName_CUS { get { return GetResourceString("idLanguageName_CUS"); } }

		public static string idLanguageName_CZE { get { return GetResourceString("idLanguageName_CZE"); } }

		public static string idLanguageName_CES { get { return GetResourceString("idLanguageName_CES"); } }

		public static string idLanguageName_DAK { get { return GetResourceString("idLanguageName_DAK"); } }

		public static string idLanguageName_DAN { get { return GetResourceString("idLanguageName_DAN"); } }

		public static string idLanguageName_DAR { get { return GetResourceString("idLanguageName_DAR"); } }

		public static string idLanguageName_DAY { get { return GetResourceString("idLanguageName_DAY"); } }

		public static string idLanguageName_DEL { get { return GetResourceString("idLanguageName_DEL"); } }

		public static string idLanguageName_DEN { get { return GetResourceString("idLanguageName_DEN"); } }

		public static string idLanguageName_DGR { get { return GetResourceString("idLanguageName_DGR"); } }

		public static string idLanguageName_DIN { get { return GetResourceString("idLanguageName_DIN"); } }

		public static string idLanguageName_DIV { get { return GetResourceString("idLanguageName_DIV"); } }

		public static string idLanguageName_DOI { get { return GetResourceString("idLanguageName_DOI"); } }

		public static string idLanguageName_DRA { get { return GetResourceString("idLanguageName_DRA"); } }

		public static string idLanguageName_DSB { get { return GetResourceString("idLanguageName_DSB"); } }

		public static string idLanguageName_DUA { get { return GetResourceString("idLanguageName_DUA"); } }

		public static string idLanguageName_DUM { get { return GetResourceString("idLanguageName_DUM"); } }

		public static string idLanguageName_DUT { get { return GetResourceString("idLanguageName_DUT"); } }

		public static string idLanguageName_NLD { get { return GetResourceString("idLanguageName_NLD"); } }

		public static string idLanguageName_DYU { get { return GetResourceString("idLanguageName_DYU"); } }

		public static string idLanguageName_DZO { get { return GetResourceString("idLanguageName_DZO"); } }

		public static string idLanguageName_EFI { get { return GetResourceString("idLanguageName_EFI"); } }

		public static string idLanguageName_EGY { get { return GetResourceString("idLanguageName_EGY"); } }

		public static string idLanguageName_EKA { get { return GetResourceString("idLanguageName_EKA"); } }

		public static string idLanguageName_ELX { get { return GetResourceString("idLanguageName_ELX"); } }

		public static string idLanguageName_ENG { get { return GetResourceString("idLanguageName_ENG"); } }

		public static string idLanguageName_ENM { get { return GetResourceString("idLanguageName_ENM"); } }

		public static string idLanguageName_EPO { get { return GetResourceString("idLanguageName_EPO"); } }

		public static string idLanguageName_EST { get { return GetResourceString("idLanguageName_EST"); } }

		public static string idLanguageName_EWE { get { return GetResourceString("idLanguageName_EWE"); } }

		public static string idLanguageName_EWO { get { return GetResourceString("idLanguageName_EWO"); } }

		public static string idLanguageName_FAN { get { return GetResourceString("idLanguageName_FAN"); } }

		public static string idLanguageName_FAO { get { return GetResourceString("idLanguageName_FAO"); } }

		public static string idLanguageName_FAT { get { return GetResourceString("idLanguageName_FAT"); } }

		public static string idLanguageName_FIJ { get { return GetResourceString("idLanguageName_FIJ"); } }

		public static string idLanguageName_FIL { get { return GetResourceString("idLanguageName_FIL"); } }

		public static string idLanguageName_FIN { get { return GetResourceString("idLanguageName_FIN"); } }

		public static string idLanguageName_FIU { get { return GetResourceString("idLanguageName_FIU"); } }

		public static string idLanguageName_FON { get { return GetResourceString("idLanguageName_FON"); } }

		public static string idLanguageName_FRE { get { return GetResourceString("idLanguageName_FRE"); } }

		public static string idLanguageName_FRA { get { return GetResourceString("idLanguageName_FRA"); } }

		public static string idLanguageName_FRM { get { return GetResourceString("idLanguageName_FRM"); } }

		public static string idLanguageName_FRO { get { return GetResourceString("idLanguageName_FRO"); } }

		public static string idLanguageName_FRR { get { return GetResourceString("idLanguageName_FRR"); } }

		public static string idLanguageName_FRS { get { return GetResourceString("idLanguageName_FRS"); } }

		public static string idLanguageName_FRY { get { return GetResourceString("idLanguageName_FRY"); } }

		public static string idLanguageName_FUL { get { return GetResourceString("idLanguageName_FUL"); } }

		public static string idLanguageName_FUR { get { return GetResourceString("idLanguageName_FUR"); } }

		public static string idLanguageName_GAA { get { return GetResourceString("idLanguageName_GAA"); } }

		public static string idLanguageName_GAY { get { return GetResourceString("idLanguageName_GAY"); } }

		public static string idLanguageName_GBA { get { return GetResourceString("idLanguageName_GBA"); } }

		public static string idLanguageName_GEM { get { return GetResourceString("idLanguageName_GEM"); } }

		public static string idLanguageName_GEO { get { return GetResourceString("idLanguageName_GEO"); } }

		public static string idLanguageName_KAT { get { return GetResourceString("idLanguageName_KAT"); } }

		public static string idLanguageName_GER { get { return GetResourceString("idLanguageName_GER"); } }

		public static string idLanguageName_DEU { get { return GetResourceString("idLanguageName_DEU"); } }

		public static string idLanguageName_GEZ { get { return GetResourceString("idLanguageName_GEZ"); } }

		public static string idLanguageName_GIL { get { return GetResourceString("idLanguageName_GIL"); } }

		public static string idLanguageName_GLA { get { return GetResourceString("idLanguageName_GLA"); } }

		public static string idLanguageName_GLE { get { return GetResourceString("idLanguageName_GLE"); } }

		public static string idLanguageName_GLG { get { return GetResourceString("idLanguageName_GLG"); } }

		public static string idLanguageName_GLV { get { return GetResourceString("idLanguageName_GLV"); } }

		public static string idLanguageName_GMH { get { return GetResourceString("idLanguageName_GMH"); } }

		public static string idLanguageName_GOH { get { return GetResourceString("idLanguageName_GOH"); } }

		public static string idLanguageName_GON { get { return GetResourceString("idLanguageName_GON"); } }

		public static string idLanguageName_GOR { get { return GetResourceString("idLanguageName_GOR"); } }

		public static string idLanguageName_GOT { get { return GetResourceString("idLanguageName_GOT"); } }

		public static string idLanguageName_GRB { get { return GetResourceString("idLanguageName_GRB"); } }

		public static string idLanguageName_GRC { get { return GetResourceString("idLanguageName_GRC"); } }

		public static string idLanguageName_GRE { get { return GetResourceString("idLanguageName_GRE"); } }

		public static string idLanguageName_ELL { get { return GetResourceString("idLanguageName_ELL"); } }

		public static string idLanguageName_GRN { get { return GetResourceString("idLanguageName_GRN"); } }

		public static string idLanguageName_GSW { get { return GetResourceString("idLanguageName_GSW"); } }

		public static string idLanguageName_GUJ { get { return GetResourceString("idLanguageName_GUJ"); } }

		public static string idLanguageName_GWI { get { return GetResourceString("idLanguageName_GWI"); } }

		public static string idLanguageName_HAI { get { return GetResourceString("idLanguageName_HAI"); } }

		public static string idLanguageName_HAT { get { return GetResourceString("idLanguageName_HAT"); } }

		public static string idLanguageName_HAU { get { return GetResourceString("idLanguageName_HAU"); } }

		public static string idLanguageName_HAW { get { return GetResourceString("idLanguageName_HAW"); } }

		public static string idLanguageName_HEB { get { return GetResourceString("idLanguageName_HEB"); } }

		public static string idLanguageName_HER { get { return GetResourceString("idLanguageName_HER"); } }

		public static string idLanguageName_HIL { get { return GetResourceString("idLanguageName_HIL"); } }

		public static string idLanguageName_HIM { get { return GetResourceString("idLanguageName_HIM"); } }

		public static string idLanguageName_HIN { get { return GetResourceString("idLanguageName_HIN"); } }

		public static string idLanguageName_HIT { get { return GetResourceString("idLanguageName_HIT"); } }

		public static string idLanguageName_HMN { get { return GetResourceString("idLanguageName_HMN"); } }

		public static string idLanguageName_HMO { get { return GetResourceString("idLanguageName_HMO"); } }

		public static string idLanguageName_HRV { get { return GetResourceString("idLanguageName_HRV"); } }

		public static string idLanguageName_HSB { get { return GetResourceString("idLanguageName_HSB"); } }

		public static string idLanguageName_HUN { get { return GetResourceString("idLanguageName_HUN"); } }

		public static string idLanguageName_HUP { get { return GetResourceString("idLanguageName_HUP"); } }

		public static string idLanguageName_IBA { get { return GetResourceString("idLanguageName_IBA"); } }

		public static string idLanguageName_IBO { get { return GetResourceString("idLanguageName_IBO"); } }

		public static string idLanguageName_ICE { get { return GetResourceString("idLanguageName_ICE"); } }

		public static string idLanguageName_ISL { get { return GetResourceString("idLanguageName_ISL"); } }

		public static string idLanguageName_IDO { get { return GetResourceString("idLanguageName_IDO"); } }

		public static string idLanguageName_III { get { return GetResourceString("idLanguageName_III"); } }

		public static string idLanguageName_IJO { get { return GetResourceString("idLanguageName_IJO"); } }

		public static string idLanguageName_IKU { get { return GetResourceString("idLanguageName_IKU"); } }

		public static string idLanguageName_ILE { get { return GetResourceString("idLanguageName_ILE"); } }

		public static string idLanguageName_ILO { get { return GetResourceString("idLanguageName_ILO"); } }

		public static string idLanguageName_INA { get { return GetResourceString("idLanguageName_INA"); } }

		public static string idLanguageName_INC { get { return GetResourceString("idLanguageName_INC"); } }

		public static string idLanguageName_IND { get { return GetResourceString("idLanguageName_IND"); } }

		public static string idLanguageName_INE { get { return GetResourceString("idLanguageName_INE"); } }

		public static string idLanguageName_INH { get { return GetResourceString("idLanguageName_INH"); } }

		public static string idLanguageName_IPK { get { return GetResourceString("idLanguageName_IPK"); } }

		public static string idLanguageName_IRA { get { return GetResourceString("idLanguageName_IRA"); } }

		public static string idLanguageName_IRO { get { return GetResourceString("idLanguageName_IRO"); } }

		public static string idLanguageName_ITA { get { return GetResourceString("idLanguageName_ITA"); } }

		public static string idLanguageName_JAV { get { return GetResourceString("idLanguageName_JAV"); } }

		public static string idLanguageName_JBO { get { return GetResourceString("idLanguageName_JBO"); } }

		public static string idLanguageName_JPN { get { return GetResourceString("idLanguageName_JPN"); } }

		public static string idLanguageName_JPR { get { return GetResourceString("idLanguageName_JPR"); } }

		public static string idLanguageName_JRB { get { return GetResourceString("idLanguageName_JRB"); } }

		public static string idLanguageName_KAA { get { return GetResourceString("idLanguageName_KAA"); } }

		public static string idLanguageName_KAB { get { return GetResourceString("idLanguageName_KAB"); } }

		public static string idLanguageName_KAC { get { return GetResourceString("idLanguageName_KAC"); } }

		public static string idLanguageName_KAL { get { return GetResourceString("idLanguageName_KAL"); } }

		public static string idLanguageName_KAM { get { return GetResourceString("idLanguageName_KAM"); } }

		public static string idLanguageName_KAN { get { return GetResourceString("idLanguageName_KAN"); } }

		public static string idLanguageName_KAR { get { return GetResourceString("idLanguageName_KAR"); } }

		public static string idLanguageName_KAS { get { return GetResourceString("idLanguageName_KAS"); } }

		public static string idLanguageName_KAU { get { return GetResourceString("idLanguageName_KAU"); } }

		public static string idLanguageName_KAW { get { return GetResourceString("idLanguageName_KAW"); } }

		public static string idLanguageName_KAZ { get { return GetResourceString("idLanguageName_KAZ"); } }

		public static string idLanguageName_KBD { get { return GetResourceString("idLanguageName_KBD"); } }

		public static string idLanguageName_KHA { get { return GetResourceString("idLanguageName_KHA"); } }

		public static string idLanguageName_KHI { get { return GetResourceString("idLanguageName_KHI"); } }

		public static string idLanguageName_KHM { get { return GetResourceString("idLanguageName_KHM"); } }

		public static string idLanguageName_KHO { get { return GetResourceString("idLanguageName_KHO"); } }

		public static string idLanguageName_KIK { get { return GetResourceString("idLanguageName_KIK"); } }

		public static string idLanguageName_KIN { get { return GetResourceString("idLanguageName_KIN"); } }

		public static string idLanguageName_KIR { get { return GetResourceString("idLanguageName_KIR"); } }

		public static string idLanguageName_KMB { get { return GetResourceString("idLanguageName_KMB"); } }

		public static string idLanguageName_KOK { get { return GetResourceString("idLanguageName_KOK"); } }

		public static string idLanguageName_KOM { get { return GetResourceString("idLanguageName_KOM"); } }

		public static string idLanguageName_KON { get { return GetResourceString("idLanguageName_KON"); } }

		public static string idLanguageName_KOR { get { return GetResourceString("idLanguageName_KOR"); } }

		public static string idLanguageName_KOS { get { return GetResourceString("idLanguageName_KOS"); } }

		public static string idLanguageName_KPE { get { return GetResourceString("idLanguageName_KPE"); } }

		public static string idLanguageName_KRC { get { return GetResourceString("idLanguageName_KRC"); } }

		public static string idLanguageName_KRL { get { return GetResourceString("idLanguageName_KRL"); } }

		public static string idLanguageName_KRO { get { return GetResourceString("idLanguageName_KRO"); } }

		public static string idLanguageName_KRU { get { return GetResourceString("idLanguageName_KRU"); } }

		public static string idLanguageName_KUA { get { return GetResourceString("idLanguageName_KUA"); } }

		public static string idLanguageName_KUM { get { return GetResourceString("idLanguageName_KUM"); } }

		public static string idLanguageName_KUR { get { return GetResourceString("idLanguageName_KUR"); } }

		public static string idLanguageName_KUT { get { return GetResourceString("idLanguageName_KUT"); } }

		public static string idLanguageName_LAD { get { return GetResourceString("idLanguageName_LAD"); } }

		public static string idLanguageName_LAH { get { return GetResourceString("idLanguageName_LAH"); } }

		public static string idLanguageName_LAM { get { return GetResourceString("idLanguageName_LAM"); } }

		public static string idLanguageName_LAO { get { return GetResourceString("idLanguageName_LAO"); } }

		public static string idLanguageName_LAT { get { return GetResourceString("idLanguageName_LAT"); } }

		public static string idLanguageName_LAV { get { return GetResourceString("idLanguageName_LAV"); } }

		public static string idLanguageName_LEZ { get { return GetResourceString("idLanguageName_LEZ"); } }

		public static string idLanguageName_LIM { get { return GetResourceString("idLanguageName_LIM"); } }

		public static string idLanguageName_LIN { get { return GetResourceString("idLanguageName_LIN"); } }

		public static string idLanguageName_LIT { get { return GetResourceString("idLanguageName_LIT"); } }

		public static string idLanguageName_LOL { get { return GetResourceString("idLanguageName_LOL"); } }

		public static string idLanguageName_LOZ { get { return GetResourceString("idLanguageName_LOZ"); } }

		public static string idLanguageName_LTZ { get { return GetResourceString("idLanguageName_LTZ"); } }

		public static string idLanguageName_LUA { get { return GetResourceString("idLanguageName_LUA"); } }

		public static string idLanguageName_LUB { get { return GetResourceString("idLanguageName_LUB"); } }

		public static string idLanguageName_LUG { get { return GetResourceString("idLanguageName_LUG"); } }

		public static string idLanguageName_LUI { get { return GetResourceString("idLanguageName_LUI"); } }

		public static string idLanguageName_LUN { get { return GetResourceString("idLanguageName_LUN"); } }

		public static string idLanguageName_LUO { get { return GetResourceString("idLanguageName_LUO"); } }

		public static string idLanguageName_LUS { get { return GetResourceString("idLanguageName_LUS"); } }

		public static string idLanguageName_MAC { get { return GetResourceString("idLanguageName_MAC"); } }

		public static string idLanguageName_MKD { get { return GetResourceString("idLanguageName_MKD"); } }

		public static string idLanguageName_MAD { get { return GetResourceString("idLanguageName_MAD"); } }

		public static string idLanguageName_MAG { get { return GetResourceString("idLanguageName_MAG"); } }

		public static string idLanguageName_MAH { get { return GetResourceString("idLanguageName_MAH"); } }

		public static string idLanguageName_MAI { get { return GetResourceString("idLanguageName_MAI"); } }

		public static string idLanguageName_MAK { get { return GetResourceString("idLanguageName_MAK"); } }

		public static string idLanguageName_MAL { get { return GetResourceString("idLanguageName_MAL"); } }

		public static string idLanguageName_MAN { get { return GetResourceString("idLanguageName_MAN"); } }

		public static string idLanguageName_MAO { get { return GetResourceString("idLanguageName_MAO"); } }

		public static string idLanguageName_MRI { get { return GetResourceString("idLanguageName_MRI"); } }

		public static string idLanguageName_MAP { get { return GetResourceString("idLanguageName_MAP"); } }

		public static string idLanguageName_MAR { get { return GetResourceString("idLanguageName_MAR"); } }

		public static string idLanguageName_MAS { get { return GetResourceString("idLanguageName_MAS"); } }

		public static string idLanguageName_MAY { get { return GetResourceString("idLanguageName_MAY"); } }

		public static string idLanguageName_MSA { get { return GetResourceString("idLanguageName_MSA"); } }

		public static string idLanguageName_MDF { get { return GetResourceString("idLanguageName_MDF"); } }

		public static string idLanguageName_MDR { get { return GetResourceString("idLanguageName_MDR"); } }

		public static string idLanguageName_MEN { get { return GetResourceString("idLanguageName_MEN"); } }

		public static string idLanguageName_MGA { get { return GetResourceString("idLanguageName_MGA"); } }

		public static string idLanguageName_MIC { get { return GetResourceString("idLanguageName_MIC"); } }

		public static string idLanguageName_MIN { get { return GetResourceString("idLanguageName_MIN"); } }

		public static string idLanguageName_MIS { get { return GetResourceString("idLanguageName_MIS"); } }

		public static string idLanguageName_MKH { get { return GetResourceString("idLanguageName_MKH"); } }

		public static string idLanguageName_MLG { get { return GetResourceString("idLanguageName_MLG"); } }

		public static string idLanguageName_MLT { get { return GetResourceString("idLanguageName_MLT"); } }

		public static string idLanguageName_MNC { get { return GetResourceString("idLanguageName_MNC"); } }

		public static string idLanguageName_MNI { get { return GetResourceString("idLanguageName_MNI"); } }

		public static string idLanguageName_MNO { get { return GetResourceString("idLanguageName_MNO"); } }

		public static string idLanguageName_MOH { get { return GetResourceString("idLanguageName_MOH"); } }

		public static string idLanguageName_MON { get { return GetResourceString("idLanguageName_MON"); } }

		public static string idLanguageName_MOS { get { return GetResourceString("idLanguageName_MOS"); } }

		public static string idLanguageName_MUL { get { return GetResourceString("idLanguageName_MUL"); } }

		public static string idLanguageName_MUN { get { return GetResourceString("idLanguageName_MUN"); } }

		public static string idLanguageName_MUS { get { return GetResourceString("idLanguageName_MUS"); } }

		public static string idLanguageName_MWL { get { return GetResourceString("idLanguageName_MWL"); } }

		public static string idLanguageName_MWR { get { return GetResourceString("idLanguageName_MWR"); } }

		public static string idLanguageName_MYN { get { return GetResourceString("idLanguageName_MYN"); } }

		public static string idLanguageName_MYV { get { return GetResourceString("idLanguageName_MYV"); } }

		public static string idLanguageName_NAH { get { return GetResourceString("idLanguageName_NAH"); } }

		public static string idLanguageName_NAI { get { return GetResourceString("idLanguageName_NAI"); } }

		public static string idLanguageName_NAP { get { return GetResourceString("idLanguageName_NAP"); } }

		public static string idLanguageName_NAU { get { return GetResourceString("idLanguageName_NAU"); } }

		public static string idLanguageName_NAV { get { return GetResourceString("idLanguageName_NAV"); } }

		public static string idLanguageName_NBL { get { return GetResourceString("idLanguageName_NBL"); } }

		public static string idLanguageName_NDE { get { return GetResourceString("idLanguageName_NDE"); } }

		public static string idLanguageName_NDO { get { return GetResourceString("idLanguageName_NDO"); } }

		public static string idLanguageName_NDS { get { return GetResourceString("idLanguageName_NDS"); } }

		public static string idLanguageName_NEP { get { return GetResourceString("idLanguageName_NEP"); } }

		public static string idLanguageName_NEW { get { return GetResourceString("idLanguageName_NEW"); } }

		public static string idLanguageName_NIA { get { return GetResourceString("idLanguageName_NIA"); } }

		public static string idLanguageName_NIC { get { return GetResourceString("idLanguageName_NIC"); } }

		public static string idLanguageName_NIU { get { return GetResourceString("idLanguageName_NIU"); } }

		public static string idLanguageName_NNO { get { return GetResourceString("idLanguageName_NNO"); } }

		public static string idLanguageName_NOB { get { return GetResourceString("idLanguageName_NOB"); } }

		public static string idLanguageName_NOG { get { return GetResourceString("idLanguageName_NOG"); } }

		public static string idLanguageName_NON { get { return GetResourceString("idLanguageName_NON"); } }

		public static string idLanguageName_NOR { get { return GetResourceString("idLanguageName_NOR"); } }

		public static string idLanguageName_NQO { get { return GetResourceString("idLanguageName_NQO"); } }

		public static string idLanguageName_NSO { get { return GetResourceString("idLanguageName_NSO"); } }

		public static string idLanguageName_NUB { get { return GetResourceString("idLanguageName_NUB"); } }

		public static string idLanguageName_NWC { get { return GetResourceString("idLanguageName_NWC"); } }

		public static string idLanguageName_NYA { get { return GetResourceString("idLanguageName_NYA"); } }

		public static string idLanguageName_NYM { get { return GetResourceString("idLanguageName_NYM"); } }

		public static string idLanguageName_NYN { get { return GetResourceString("idLanguageName_NYN"); } }

		public static string idLanguageName_NYO { get { return GetResourceString("idLanguageName_NYO"); } }

		public static string idLanguageName_NZI { get { return GetResourceString("idLanguageName_NZI"); } }

		public static string idLanguageName_OCI { get { return GetResourceString("idLanguageName_OCI"); } }

		public static string idLanguageName_OJI { get { return GetResourceString("idLanguageName_OJI"); } }

		public static string idLanguageName_ORI { get { return GetResourceString("idLanguageName_ORI"); } }

		public static string idLanguageName_ORM { get { return GetResourceString("idLanguageName_ORM"); } }

		public static string idLanguageName_OSA { get { return GetResourceString("idLanguageName_OSA"); } }

		public static string idLanguageName_OSS { get { return GetResourceString("idLanguageName_OSS"); } }

		public static string idLanguageName_OTA { get { return GetResourceString("idLanguageName_OTA"); } }

		public static string idLanguageName_OTO { get { return GetResourceString("idLanguageName_OTO"); } }

		public static string idLanguageName_PAA { get { return GetResourceString("idLanguageName_PAA"); } }

		public static string idLanguageName_PAG { get { return GetResourceString("idLanguageName_PAG"); } }

		public static string idLanguageName_PAL { get { return GetResourceString("idLanguageName_PAL"); } }

		public static string idLanguageName_PAM { get { return GetResourceString("idLanguageName_PAM"); } }

		public static string idLanguageName_PAN { get { return GetResourceString("idLanguageName_PAN"); } }

		public static string idLanguageName_PAP { get { return GetResourceString("idLanguageName_PAP"); } }

		public static string idLanguageName_PAU { get { return GetResourceString("idLanguageName_PAU"); } }

		public static string idLanguageName_PEO { get { return GetResourceString("idLanguageName_PEO"); } }

		public static string idLanguageName_PER { get { return GetResourceString("idLanguageName_PER"); } }

		public static string idLanguageName_FAS { get { return GetResourceString("idLanguageName_FAS"); } }

		public static string idLanguageName_PHI { get { return GetResourceString("idLanguageName_PHI"); } }

		public static string idLanguageName_PHN { get { return GetResourceString("idLanguageName_PHN"); } }

		public static string idLanguageName_PLI { get { return GetResourceString("idLanguageName_PLI"); } }

		public static string idLanguageName_POL { get { return GetResourceString("idLanguageName_POL"); } }

		public static string idLanguageName_PON { get { return GetResourceString("idLanguageName_PON"); } }

		public static string idLanguageName_POR { get { return GetResourceString("idLanguageName_POR"); } }

		public static string idLanguageName_PRA { get { return GetResourceString("idLanguageName_PRA"); } }

		public static string idLanguageName_PRO { get { return GetResourceString("idLanguageName_PRO"); } }

		public static string idLanguageName_PUS { get { return GetResourceString("idLanguageName_PUS"); } }

		public static string idLanguageName_QUE { get { return GetResourceString("idLanguageName_QUE"); } }

		public static string idLanguageName_RAJ { get { return GetResourceString("idLanguageName_RAJ"); } }

		public static string idLanguageName_RAP { get { return GetResourceString("idLanguageName_RAP"); } }

		public static string idLanguageName_RAR { get { return GetResourceString("idLanguageName_RAR"); } }

		public static string idLanguageName_ROA { get { return GetResourceString("idLanguageName_ROA"); } }

		public static string idLanguageName_ROH { get { return GetResourceString("idLanguageName_ROH"); } }

		public static string idLanguageName_ROM { get { return GetResourceString("idLanguageName_ROM"); } }

		public static string idLanguageName_RUM { get { return GetResourceString("idLanguageName_RUM"); } }

		public static string idLanguageName_RON { get { return GetResourceString("idLanguageName_RON"); } }

		public static string idLanguageName_RUN { get { return GetResourceString("idLanguageName_RUN"); } }

		public static string idLanguageName_RUP { get { return GetResourceString("idLanguageName_RUP"); } }

		public static string idLanguageName_RUS { get { return GetResourceString("idLanguageName_RUS"); } }

		public static string idLanguageName_SAD { get { return GetResourceString("idLanguageName_SAD"); } }

		public static string idLanguageName_SAG { get { return GetResourceString("idLanguageName_SAG"); } }

		public static string idLanguageName_SAH { get { return GetResourceString("idLanguageName_SAH"); } }

		public static string idLanguageName_SAI { get { return GetResourceString("idLanguageName_SAI"); } }

		public static string idLanguageName_SAL { get { return GetResourceString("idLanguageName_SAL"); } }

		public static string idLanguageName_SAM { get { return GetResourceString("idLanguageName_SAM"); } }

		public static string idLanguageName_SAN { get { return GetResourceString("idLanguageName_SAN"); } }

		public static string idLanguageName_SAS { get { return GetResourceString("idLanguageName_SAS"); } }

		public static string idLanguageName_SAT { get { return GetResourceString("idLanguageName_SAT"); } }

		public static string idLanguageName_SCN { get { return GetResourceString("idLanguageName_SCN"); } }

		public static string idLanguageName_SCO { get { return GetResourceString("idLanguageName_SCO"); } }

		public static string idLanguageName_SEL { get { return GetResourceString("idLanguageName_SEL"); } }

		public static string idLanguageName_SEM { get { return GetResourceString("idLanguageName_SEM"); } }

		public static string idLanguageName_SGA { get { return GetResourceString("idLanguageName_SGA"); } }

		public static string idLanguageName_SGN { get { return GetResourceString("idLanguageName_SGN"); } }

		public static string idLanguageName_SHN { get { return GetResourceString("idLanguageName_SHN"); } }

		public static string idLanguageName_SID { get { return GetResourceString("idLanguageName_SID"); } }

		public static string idLanguageName_SIN { get { return GetResourceString("idLanguageName_SIN"); } }

		public static string idLanguageName_SIO { get { return GetResourceString("idLanguageName_SIO"); } }

		public static string idLanguageName_SIT { get { return GetResourceString("idLanguageName_SIT"); } }

		public static string idLanguageName_SLA { get { return GetResourceString("idLanguageName_SLA"); } }

		public static string idLanguageName_SLO { get { return GetResourceString("idLanguageName_SLO"); } }

		public static string idLanguageName_SLK { get { return GetResourceString("idLanguageName_SLK"); } }

		public static string idLanguageName_SLV { get { return GetResourceString("idLanguageName_SLV"); } }

		public static string idLanguageName_SMA { get { return GetResourceString("idLanguageName_SMA"); } }

		public static string idLanguageName_SME { get { return GetResourceString("idLanguageName_SME"); } }

		public static string idLanguageName_SMI { get { return GetResourceString("idLanguageName_SMI"); } }

		public static string idLanguageName_SMJ { get { return GetResourceString("idLanguageName_SMJ"); } }

		public static string idLanguageName_SMN { get { return GetResourceString("idLanguageName_SMN"); } }

		public static string idLanguageName_SMO { get { return GetResourceString("idLanguageName_SMO"); } }

		public static string idLanguageName_SMS { get { return GetResourceString("idLanguageName_SMS"); } }

		public static string idLanguageName_SNA { get { return GetResourceString("idLanguageName_SNA"); } }

		public static string idLanguageName_SND { get { return GetResourceString("idLanguageName_SND"); } }

		public static string idLanguageName_SNK { get { return GetResourceString("idLanguageName_SNK"); } }

		public static string idLanguageName_SOG { get { return GetResourceString("idLanguageName_SOG"); } }

		public static string idLanguageName_SOM { get { return GetResourceString("idLanguageName_SOM"); } }

		public static string idLanguageName_SON { get { return GetResourceString("idLanguageName_SON"); } }

		public static string idLanguageName_SOT { get { return GetResourceString("idLanguageName_SOT"); } }

		public static string idLanguageName_SPA { get { return GetResourceString("idLanguageName_SPA"); } }

		public static string idLanguageName_SRD { get { return GetResourceString("idLanguageName_SRD"); } }

		public static string idLanguageName_SRN { get { return GetResourceString("idLanguageName_SRN"); } }

		public static string idLanguageName_SRP { get { return GetResourceString("idLanguageName_SRP"); } }

		public static string idLanguageName_SRR { get { return GetResourceString("idLanguageName_SRR"); } }

		public static string idLanguageName_SSA { get { return GetResourceString("idLanguageName_SSA"); } }

		public static string idLanguageName_SSW { get { return GetResourceString("idLanguageName_SSW"); } }

		public static string idLanguageName_SUK { get { return GetResourceString("idLanguageName_SUK"); } }

		public static string idLanguageName_SUN { get { return GetResourceString("idLanguageName_SUN"); } }

		public static string idLanguageName_SUS { get { return GetResourceString("idLanguageName_SUS"); } }

		public static string idLanguageName_SUX { get { return GetResourceString("idLanguageName_SUX"); } }

		public static string idLanguageName_SWA { get { return GetResourceString("idLanguageName_SWA"); } }

		public static string idLanguageName_SWE { get { return GetResourceString("idLanguageName_SWE"); } }

		public static string idLanguageName_SYC { get { return GetResourceString("idLanguageName_SYC"); } }

		public static string idLanguageName_SYR { get { return GetResourceString("idLanguageName_SYR"); } }

		public static string idLanguageName_TAH { get { return GetResourceString("idLanguageName_TAH"); } }

		public static string idLanguageName_TAI { get { return GetResourceString("idLanguageName_TAI"); } }

		public static string idLanguageName_TAM { get { return GetResourceString("idLanguageName_TAM"); } }

		public static string idLanguageName_TAT { get { return GetResourceString("idLanguageName_TAT"); } }

		public static string idLanguageName_TEL { get { return GetResourceString("idLanguageName_TEL"); } }

		public static string idLanguageName_TEM { get { return GetResourceString("idLanguageName_TEM"); } }

		public static string idLanguageName_TER { get { return GetResourceString("idLanguageName_TER"); } }

		public static string idLanguageName_TET { get { return GetResourceString("idLanguageName_TET"); } }

		public static string idLanguageName_TGK { get { return GetResourceString("idLanguageName_TGK"); } }

		public static string idLanguageName_TGL { get { return GetResourceString("idLanguageName_TGL"); } }

		public static string idLanguageName_THA { get { return GetResourceString("idLanguageName_THA"); } }

		public static string idLanguageName_TIB { get { return GetResourceString("idLanguageName_TIB"); } }

		public static string idLanguageName_BOD { get { return GetResourceString("idLanguageName_BOD"); } }

		public static string idLanguageName_TIG { get { return GetResourceString("idLanguageName_TIG"); } }

		public static string idLanguageName_TIR { get { return GetResourceString("idLanguageName_TIR"); } }

		public static string idLanguageName_TIV { get { return GetResourceString("idLanguageName_TIV"); } }

		public static string idLanguageName_TKL { get { return GetResourceString("idLanguageName_TKL"); } }

		public static string idLanguageName_TLH { get { return GetResourceString("idLanguageName_TLH"); } }

		public static string idLanguageName_TLI { get { return GetResourceString("idLanguageName_TLI"); } }

		public static string idLanguageName_TMH { get { return GetResourceString("idLanguageName_TMH"); } }

		public static string idLanguageName_TOG { get { return GetResourceString("idLanguageName_TOG"); } }

		public static string idLanguageName_TON { get { return GetResourceString("idLanguageName_TON"); } }

		public static string idLanguageName_TPI { get { return GetResourceString("idLanguageName_TPI"); } }

		public static string idLanguageName_TSI { get { return GetResourceString("idLanguageName_TSI"); } }

		public static string idLanguageName_TSN { get { return GetResourceString("idLanguageName_TSN"); } }

		public static string idLanguageName_TSO { get { return GetResourceString("idLanguageName_TSO"); } }

		public static string idLanguageName_TUK { get { return GetResourceString("idLanguageName_TUK"); } }

		public static string idLanguageName_TUM { get { return GetResourceString("idLanguageName_TUM"); } }

		public static string idLanguageName_TUP { get { return GetResourceString("idLanguageName_TUP"); } }

		public static string idLanguageName_TUR { get { return GetResourceString("idLanguageName_TUR"); } }

		public static string idLanguageName_TUT { get { return GetResourceString("idLanguageName_TUT"); } }

		public static string idLanguageName_TVL { get { return GetResourceString("idLanguageName_TVL"); } }

		public static string idLanguageName_TWI { get { return GetResourceString("idLanguageName_TWI"); } }

		public static string idLanguageName_TYV { get { return GetResourceString("idLanguageName_TYV"); } }

		public static string idLanguageName_UDM { get { return GetResourceString("idLanguageName_UDM"); } }

		public static string idLanguageName_UGA { get { return GetResourceString("idLanguageName_UGA"); } }

		public static string idLanguageName_UIG { get { return GetResourceString("idLanguageName_UIG"); } }

		public static string idLanguageName_UKR { get { return GetResourceString("idLanguageName_UKR"); } }

		public static string idLanguageName_UMB { get { return GetResourceString("idLanguageName_UMB"); } }

		public static string idLanguageName_UND { get { return GetResourceString("idLanguageName_UND"); } }

		public static string idLanguageName_URD { get { return GetResourceString("idLanguageName_URD"); } }

		public static string idLanguageName_UZB { get { return GetResourceString("idLanguageName_UZB"); } }

		public static string idLanguageName_VAI { get { return GetResourceString("idLanguageName_VAI"); } }

		public static string idLanguageName_VEN { get { return GetResourceString("idLanguageName_VEN"); } }

		public static string idLanguageName_VIE { get { return GetResourceString("idLanguageName_VIE"); } }

		public static string idLanguageName_VOL { get { return GetResourceString("idLanguageName_VOL"); } }

		public static string idLanguageName_VOT { get { return GetResourceString("idLanguageName_VOT"); } }

		public static string idLanguageName_WAK { get { return GetResourceString("idLanguageName_WAK"); } }

		public static string idLanguageName_WAL { get { return GetResourceString("idLanguageName_WAL"); } }

		public static string idLanguageName_WAR { get { return GetResourceString("idLanguageName_WAR"); } }

		public static string idLanguageName_WAS { get { return GetResourceString("idLanguageName_WAS"); } }

		public static string idLanguageName_WEL { get { return GetResourceString("idLanguageName_WEL"); } }

		public static string idLanguageName_CYM { get { return GetResourceString("idLanguageName_CYM"); } }

		public static string idLanguageName_WEN { get { return GetResourceString("idLanguageName_WEN"); } }

		public static string idLanguageName_WLN { get { return GetResourceString("idLanguageName_WLN"); } }

		public static string idLanguageName_WOL { get { return GetResourceString("idLanguageName_WOL"); } }

		public static string idLanguageName_XAL { get { return GetResourceString("idLanguageName_XAL"); } }

		public static string idLanguageName_XHO { get { return GetResourceString("idLanguageName_XHO"); } }

		public static string idLanguageName_YAO { get { return GetResourceString("idLanguageName_YAO"); } }

		public static string idLanguageName_YAP { get { return GetResourceString("idLanguageName_YAP"); } }

		public static string idLanguageName_YID { get { return GetResourceString("idLanguageName_YID"); } }

		public static string idLanguageName_YOR { get { return GetResourceString("idLanguageName_YOR"); } }

		public static string idLanguageName_YPK { get { return GetResourceString("idLanguageName_YPK"); } }

		public static string idLanguageName_ZAP { get { return GetResourceString("idLanguageName_ZAP"); } }

		public static string idLanguageName_ZBL { get { return GetResourceString("idLanguageName_ZBL"); } }

		public static string idLanguageName_ZEN { get { return GetResourceString("idLanguageName_ZEN"); } }

		public static string idLanguageName_ZHA { get { return GetResourceString("idLanguageName_ZHA"); } }

		public static string idLanguageName_ZND { get { return GetResourceString("idLanguageName_ZND"); } }

		public static string idLanguageName_ZUL { get { return GetResourceString("idLanguageName_ZUL"); } }

		public static string idLanguageName_ZUN { get { return GetResourceString("idLanguageName_ZUN"); } }

		public static string idLanguageName_ZXX { get { return GetResourceString("idLanguageName_ZXX"); } }

		public static string idLanguageName_ZZA { get { return GetResourceString("idLanguageName_ZZA"); } }

		public static string idYotta { get { return GetResourceString("idYotta"); } }

		public static string idZetta { get { return GetResourceString("idZetta"); } }

		public static string idExa { get { return GetResourceString("idExa"); } }

		public static string idPeta { get { return GetResourceString("idPeta"); } }

		public static string idTera { get { return GetResourceString("idTera"); } }

		public static string idGiga { get { return GetResourceString("idGiga"); } }

		public static string idMega { get { return GetResourceString("idMega"); } }

		public static string idKilo { get { return GetResourceString("idKilo"); } }

		public static string idHecto { get { return GetResourceString("idHecto"); } }

		public static string idDeka { get { return GetResourceString("idDeka"); } }

		public static string idDeci { get { return GetResourceString("idDeci"); } }

		public static string idCenti { get { return GetResourceString("idCenti"); } }

		public static string idMilli { get { return GetResourceString("idMilli"); } }

		public static string idMicro { get { return GetResourceString("idMicro"); } }

		public static string idNano { get { return GetResourceString("idNano"); } }

		public static string idPico { get { return GetResourceString("idPico"); } }

		public static string idFemto { get { return GetResourceString("idFemto"); } }

		public static string idAtto { get { return GetResourceString("idAtto"); } }

		public static string idZepto { get { return GetResourceString("idZepto"); } }

		public static string idYocto { get { return GetResourceString("idYocto"); } }

		public static string idMeter { get { return GetResourceString("idMeter"); } }

		public static string idSecond { get { return GetResourceString("idSecond"); } }

		public static string idGram { get { return GetResourceString("idGram"); } }

		public static string idRadian { get { return GetResourceString("idRadian"); } }

		public static string idKelvin { get { return GetResourceString("idKelvin"); } }

		public static string idCoulomb { get { return GetResourceString("idCoulomb"); } }

		public static string idCandela { get { return GetResourceString("idCandela"); } }

		public static string idTenArbPowsStar { get { return GetResourceString("idTenArbPowsStar"); } }

		public static string idTenArbPowsCarat { get { return GetResourceString("idTenArbPowsCarat"); } }

		public static string idPi { get { return GetResourceString("idPi"); } }

		public static string idPercent { get { return GetResourceString("idPercent"); } }

		public static string idPPTh { get { return GetResourceString("idPPTh"); } }

		public static string idPPM { get { return GetResourceString("idPPM"); } }

		public static string idPPB { get { return GetResourceString("idPPB"); } }

		public static string idPPTr { get { return GetResourceString("idPPTr"); } }

		public static string idMole { get { return GetResourceString("idMole"); } }

		public static string idSteradian { get { return GetResourceString("idSteradian"); } }

		public static string idHertz { get { return GetResourceString("idHertz"); } }

		public static string idNewton { get { return GetResourceString("idNewton"); } }

		public static string idPascal { get { return GetResourceString("idPascal"); } }

		public static string idJoule { get { return GetResourceString("idJoule"); } }

		public static string idWatt { get { return GetResourceString("idWatt"); } }

		public static string idAmp { get { return GetResourceString("idAmp"); } }

		public static string idVolt { get { return GetResourceString("idVolt"); } }

		public static string idFarad { get { return GetResourceString("idFarad"); } }

		public static string idOhm { get { return GetResourceString("idOhm"); } }

		public static string idSiemens { get { return GetResourceString("idSiemens"); } }

		public static string idWeber { get { return GetResourceString("idWeber"); } }

		public static string idDegCelsius { get { return GetResourceString("idDegCelsius"); } }

		public static string idTesla { get { return GetResourceString("idTesla"); } }

		public static string idHenry { get { return GetResourceString("idHenry"); } }

		public static string idLumen { get { return GetResourceString("idLumen"); } }

		public static string idLux { get { return GetResourceString("idLux"); } }

		public static string idBecquerel { get { return GetResourceString("idBecquerel"); } }

		public static string idGray { get { return GetResourceString("idGray"); } }

		public static string idSievert { get { return GetResourceString("idSievert"); } }

		public static string idGonGrade { get { return GetResourceString("idGonGrade"); } }

		public static string idDegree { get { return GetResourceString("idDegree"); } }

		public static string idMinute { get { return GetResourceString("idMinute"); } }

		public static string idSecond_auxUCUM { get { return GetResourceString("idSecond_auxUCUM"); } }

		public static string idLiter { get { return GetResourceString("idLiter"); } }

		public static string idLiter_auxUCUM { get { return GetResourceString("idLiter_auxUCUM"); } }

		public static string idAre { get { return GetResourceString("idAre"); } }

		public static string idMinute_auxUCUM { get { return GetResourceString("idMinute_auxUCUM"); } }

		public static string idHour { get { return GetResourceString("idHour"); } }

		public static string idDay { get { return GetResourceString("idDay"); } }

		public static string idTropicalYear { get { return GetResourceString("idTropicalYear"); } }

		public static string idMeanJulianYear { get { return GetResourceString("idMeanJulianYear"); } }

		public static string idMeanGregorianYear { get { return GetResourceString("idMeanGregorianYear"); } }

		public static string idYear { get { return GetResourceString("idYear"); } }

		public static string idWeek { get { return GetResourceString("idWeek"); } }

		public static string idSynodalMonth { get { return GetResourceString("idSynodalMonth"); } }

		public static string idMeanJulianMonth { get { return GetResourceString("idMeanJulianMonth"); } }

		public static string idMeanGregorianMonth { get { return GetResourceString("idMeanGregorianMonth"); } }

		public static string idMonth { get { return GetResourceString("idMonth"); } }

		public static string idTonne { get { return GetResourceString("idTonne"); } }

		public static string idBar { get { return GetResourceString("idBar"); } }

		public static string idAMU { get { return GetResourceString("idAMU"); } }

		public static string idEV { get { return GetResourceString("idEV"); } }

		public static string idAU { get { return GetResourceString("idAU"); } }

		public static string idParsec { get { return GetResourceString("idParsec"); } }

		public static string idVelocityOfLight { get { return GetResourceString("idVelocityOfLight"); } }

		public static string idPlanckConstant { get { return GetResourceString("idPlanckConstant"); } }

		public static string idBoltzmannConstant { get { return GetResourceString("idBoltzmannConstant"); } }

		public static string idPermittivityOfVacuum { get { return GetResourceString("idPermittivityOfVacuum"); } }

		public static string idPermeabilityOfVacuum { get { return GetResourceString("idPermeabilityOfVacuum"); } }

		public static string idElementaryCharge { get { return GetResourceString("idElementaryCharge"); } }

		public static string idElectronMass { get { return GetResourceString("idElectronMass"); } }

		public static string idProtonMass { get { return GetResourceString("idProtonMass"); } }

		public static string idNewtonGravConstant { get { return GetResourceString("idNewtonGravConstant"); } }

		public static string idStdFreefallAccel { get { return GetResourceString("idStdFreefallAccel"); } }

		public static string idStdAtmo { get { return GetResourceString("idStdAtmo"); } }

		public static string idLightyear { get { return GetResourceString("idLightyear"); } }

		public static string idGramForce { get { return GetResourceString("idGramForce"); } }

		public static string idPoundForce { get { return GetResourceString("idPoundForce"); } }

		public static string idKayser { get { return GetResourceString("idKayser"); } }

		public static string idGal { get { return GetResourceString("idGal"); } }

		public static string idDyne { get { return GetResourceString("idDyne"); } }

		public static string idErg { get { return GetResourceString("idErg"); } }

		public static string idPoise { get { return GetResourceString("idPoise"); } }

		public static string idBiot { get { return GetResourceString("idBiot"); } }

		public static string idStokes { get { return GetResourceString("idStokes"); } }

		public static string idMaxwell { get { return GetResourceString("idMaxwell"); } }

		public static string idGauss { get { return GetResourceString("idGauss"); } }

		public static string idOersted { get { return GetResourceString("idOersted"); } }

		public static string idGilbert { get { return GetResourceString("idGilbert"); } }

		public static string idStilb { get { return GetResourceString("idStilb"); } }

		public static string idLambert { get { return GetResourceString("idLambert"); } }

		public static string idPhot { get { return GetResourceString("idPhot"); } }

		public static string idCurie { get { return GetResourceString("idCurie"); } }

		public static string idRoentgen { get { return GetResourceString("idRoentgen"); } }

		public static string idRadiationAbsorbedDose { get { return GetResourceString("idRadiationAbsorbedDose"); } }

		public static string idRadiationEquivalentMan { get { return GetResourceString("idRadiationEquivalentMan"); } }

		public static string idInch { get { return GetResourceString("idInch"); } }

		public static string idFoot { get { return GetResourceString("idFoot"); } }

		public static string idYard { get { return GetResourceString("idYard"); } }

		public static string idStatuteMile { get { return GetResourceString("idStatuteMile"); } }

		public static string idFathom { get { return GetResourceString("idFathom"); } }

		public static string idNauticalMile { get { return GetResourceString("idNauticalMile"); } }

		public static string idKnot { get { return GetResourceString("idKnot"); } }

		public static string idSquareInch { get { return GetResourceString("idSquareInch"); } }

		public static string idSquareFoot { get { return GetResourceString("idSquareFoot"); } }

		public static string idSquareYard { get { return GetResourceString("idSquareYard"); } }

		public static string idCubicInch { get { return GetResourceString("idCubicInch"); } }

		public static string idCubicFoot { get { return GetResourceString("idCubicFoot"); } }

		public static string idCubicYard { get { return GetResourceString("idCubicYard"); } }

		public static string idBoardFoot { get { return GetResourceString("idBoardFoot"); } }

		public static string idCord { get { return GetResourceString("idCord"); } }

		public static string idMil { get { return GetResourceString("idMil"); } }

		public static string idCircularMil { get { return GetResourceString("idCircularMil"); } }

		public static string idHand { get { return GetResourceString("idHand"); } }

		public static string idFoot_auxUCUM { get { return GetResourceString("idFoot_auxUCUM"); } }

		public static string idYard_auxUCUM { get { return GetResourceString("idYard_auxUCUM"); } }

		public static string idInch_auxUCUM { get { return GetResourceString("idInch_auxUCUM"); } }

		public static string idRod { get { return GetResourceString("idRod"); } }

		public static string idGunterSurveyorChain { get { return GetResourceString("idGunterSurveyorChain"); } }

		public static string idGunterChainLink { get { return GetResourceString("idGunterChainLink"); } }

		public static string idRamdenEngineerChain { get { return GetResourceString("idRamdenEngineerChain"); } }

		public static string idRamdenChainLink { get { return GetResourceString("idRamdenChainLink"); } }

		public static string idFathom_auxUCUM { get { return GetResourceString("idFathom_auxUCUM"); } }

		public static string idFurlong { get { return GetResourceString("idFurlong"); } }

		public static string idMile { get { return GetResourceString("idMile"); } }

		public static string idAcre { get { return GetResourceString("idAcre"); } }

		public static string idSquareRod { get { return GetResourceString("idSquareRod"); } }

		public static string idSquareMile { get { return GetResourceString("idSquareMile"); } }

		public static string idSection { get { return GetResourceString("idSection"); } }

		public static string idTownship { get { return GetResourceString("idTownship"); } }

		public static string idMil_auxUCUM { get { return GetResourceString("idMil_auxUCUM"); } }

		public static string idInch_auxUCUM_0 { get { return GetResourceString("idInch_auxUCUM_0"); } }

		public static string idFoot_auxUCUM_0 { get { return GetResourceString("idFoot_auxUCUM_0"); } }

		public static string idRod_auxUCUM { get { return GetResourceString("idRod_auxUCUM"); } }

		public static string idGunterChain { get { return GetResourceString("idGunterChain"); } }

		public static string idGunterChainLink_auxUCUM { get { return GetResourceString("idGunterChainLink_auxUCUM"); } }

		public static string idFathom_auxUCUM_0 { get { return GetResourceString("idFathom_auxUCUM_0"); } }

		public static string idPace { get { return GetResourceString("idPace"); } }

		public static string idYard_auxUCUM_0 { get { return GetResourceString("idYard_auxUCUM_0"); } }

		public static string idMile_auxUCUM { get { return GetResourceString("idMile_auxUCUM"); } }

		public static string idNauticalMile_auxUCUM { get { return GetResourceString("idNauticalMile_auxUCUM"); } }

		public static string idKnot_auxUCUM { get { return GetResourceString("idKnot_auxUCUM"); } }

		public static string idAcre_auxUCUM { get { return GetResourceString("idAcre_auxUCUM"); } }

		public static string idQueenAnneWineGallon { get { return GetResourceString("idQueenAnneWineGallon"); } }

		public static string idBarrel { get { return GetResourceString("idBarrel"); } }

		public static string idQuart { get { return GetResourceString("idQuart"); } }

		public static string idPint { get { return GetResourceString("idPint"); } }

		public static string idGill { get { return GetResourceString("idGill"); } }

		public static string idFluidOunce { get { return GetResourceString("idFluidOunce"); } }

		public static string idFluidDram { get { return GetResourceString("idFluidDram"); } }

		public static string idMinim { get { return GetResourceString("idMinim"); } }

		public static string idCord_auxUCUM { get { return GetResourceString("idCord_auxUCUM"); } }

		public static string idBushel { get { return GetResourceString("idBushel"); } }

		public static string idHistWinchesterGallon { get { return GetResourceString("idHistWinchesterGallon"); } }

		public static string idPeck { get { return GetResourceString("idPeck"); } }

		public static string idDryQuart { get { return GetResourceString("idDryQuart"); } }

		public static string idDryPint { get { return GetResourceString("idDryPint"); } }

		public static string idTablespoon { get { return GetResourceString("idTablespoon"); } }

		public static string idTeaspoon { get { return GetResourceString("idTeaspoon"); } }

		public static string idCup { get { return GetResourceString("idCup"); } }

		public static string idGallon { get { return GetResourceString("idGallon"); } }

		public static string idPeck_auxUCUM { get { return GetResourceString("idPeck_auxUCUM"); } }

		public static string idBushel_auxUCUM { get { return GetResourceString("idBushel_auxUCUM"); } }

		public static string idQuart_auxUCUM { get { return GetResourceString("idQuart_auxUCUM"); } }

		public static string idPint_auxUCUM { get { return GetResourceString("idPint_auxUCUM"); } }

		public static string idGill_auxUCUM { get { return GetResourceString("idGill_auxUCUM"); } }

		public static string idFluidOunce_auxUCUM { get { return GetResourceString("idFluidOunce_auxUCUM"); } }

		public static string idFluidDram_auxUCUM { get { return GetResourceString("idFluidDram_auxUCUM"); } }

		public static string idMinim_auxUCUM { get { return GetResourceString("idMinim_auxUCUM"); } }

		public static string idGrain { get { return GetResourceString("idGrain"); } }

		public static string idPound { get { return GetResourceString("idPound"); } }

		public static string idOunce { get { return GetResourceString("idOunce"); } }

		public static string idDram { get { return GetResourceString("idDram"); } }

		public static string idShortUSHundredweight { get { return GetResourceString("idShortUSHundredweight"); } }

		public static string idLongBritishHundredweight { get { return GetResourceString("idLongBritishHundredweight"); } }

		public static string idShortUSTon { get { return GetResourceString("idShortUSTon"); } }

		public static string idLongBritishTon { get { return GetResourceString("idLongBritishTon"); } }

		public static string idBritishStone { get { return GetResourceString("idBritishStone"); } }

		public static string idPennyweight { get { return GetResourceString("idPennyweight"); } }

		public static string idOunce_auxUCUM { get { return GetResourceString("idOunce_auxUCUM"); } }

		public static string idPound_auxUCUM { get { return GetResourceString("idPound_auxUCUM"); } }

		public static string idScruple { get { return GetResourceString("idScruple"); } }

		public static string idDramDrachm { get { return GetResourceString("idDramDrachm"); } }

		public static string idOunce_auxUCUM_0 { get { return GetResourceString("idOunce_auxUCUM_0"); } }

		public static string idPound_auxUCUM_0 { get { return GetResourceString("idPound_auxUCUM_0"); } }

		public static string idLine { get { return GetResourceString("idLine"); } }

		public static string idPoint_auxUCUM { get { return GetResourceString("idPoint_auxUCUM"); } }

		public static string idPica { get { return GetResourceString("idPica"); } }

		public static string idPrinterPoint { get { return GetResourceString("idPrinterPoint"); } }

		public static string idPrinterPica { get { return GetResourceString("idPrinterPica"); } }

		public static string idPiedFrenchFoot { get { return GetResourceString("idPiedFrenchFoot"); } }

		public static string idPouceFrenchInch { get { return GetResourceString("idPouceFrenchInch"); } }

		public static string idLigneFrenchLine { get { return GetResourceString("idLigneFrenchLine"); } }

		public static string idDidotPoint { get { return GetResourceString("idDidotPoint"); } }

		public static string idCiceroDidotPica { get { return GetResourceString("idCiceroDidotPica"); } }

		public static string idDegreeFahrenheit { get { return GetResourceString("idDegreeFahrenheit"); } }

		public static string idCalorieAt15C { get { return GetResourceString("idCalorieAt15C"); } }

		public static string idCalorieAt20C { get { return GetResourceString("idCalorieAt20C"); } }

		public static string idMeanCalorie { get { return GetResourceString("idMeanCalorie"); } }

		public static string idIntlTableCalorie { get { return GetResourceString("idIntlTableCalorie"); } }

		public static string idThermochemCalorie { get { return GetResourceString("idThermochemCalorie"); } }

		public static string idCalorie { get { return GetResourceString("idCalorie"); } }

		public static string idNutritionLabelCalories { get { return GetResourceString("idNutritionLabelCalories"); } }

		public static string idBTUAt39F { get { return GetResourceString("idBTUAt39F"); } }

		public static string idBTUAt59F { get { return GetResourceString("idBTUAt59F"); } }

		public static string idBTUAt60F { get { return GetResourceString("idBTUAt60F"); } }

		public static string idMeanBTU { get { return GetResourceString("idMeanBTU"); } }

		public static string idIntlTableBTU { get { return GetResourceString("idIntlTableBTU"); } }

		public static string idThermochemBTU { get { return GetResourceString("idThermochemBTU"); } }

		public static string idBTU { get { return GetResourceString("idBTU"); } }

		public static string idHorsepower { get { return GetResourceString("idHorsepower"); } }

		public static string idMeterOfWaterColumn { get { return GetResourceString("idMeterOfWaterColumn"); } }

		public static string idMeterOfMercuryColumn { get { return GetResourceString("idMeterOfMercuryColumn"); } }

		public static string idInchOfWaterColumn { get { return GetResourceString("idInchOfWaterColumn"); } }

		public static string idInchOfMercuryColumn { get { return GetResourceString("idInchOfMercuryColumn"); } }

		public static string idPeripheralVascularResistanceUnit { get { return GetResourceString("idPeripheralVascularResistanceUnit"); } }

		public static string idDiopter { get { return GetResourceString("idDiopter"); } }

		public static string idPrismDiopter { get { return GetResourceString("idPrismDiopter"); } }

		public static string idPercentOfSlope { get { return GetResourceString("idPercentOfSlope"); } }

		public static string idMesh { get { return GetResourceString("idMesh"); } }

		public static string idCharriereFrench { get { return GetResourceString("idCharriereFrench"); } }

		public static string idDrop { get { return GetResourceString("idDrop"); } }

		public static string idHounsfieldUnit { get { return GetResourceString("idHounsfieldUnit"); } }

		public static string idMetabolicEquivalent { get { return GetResourceString("idMetabolicEquivalent"); } }

		public static string idHomeopathicPotencyOfDecimalSeries { get { return GetResourceString("idHomeopathicPotencyOfDecimalSeries"); } }

		public static string idHomeopathicPotencyOfCentesimalSeries { get { return GetResourceString("idHomeopathicPotencyOfCentesimalSeries"); } }

		public static string idEquivalents { get { return GetResourceString("idEquivalents"); } }

		public static string idOsmole { get { return GetResourceString("idOsmole"); } }

		public static string idPh { get { return GetResourceString("idPh"); } }

		public static string idGramPercent { get { return GetResourceString("idGramPercent"); } }

		public static string idSvedbergUnit { get { return GetResourceString("idSvedbergUnit"); } }

		public static string idHighPowerField { get { return GetResourceString("idHighPowerField"); } }

		public static string idLowPowerField { get { return GetResourceString("idLowPowerField"); } }

		public static string idKatal { get { return GetResourceString("idKatal"); } }

		public static string idUnit { get { return GetResourceString("idUnit"); } }

		public static string idIntlUnit { get { return GetResourceString("idIntlUnit"); } }

		public static string idArbitaryUnit { get { return GetResourceString("idArbitaryUnit"); } }

		public static string idUnitedStatesPharmacopeiaUnit { get { return GetResourceString("idUnitedStatesPharmacopeiaUnit"); } }

		public static string idGPLUnit { get { return GetResourceString("idGPLUnit"); } }

		public static string idMPLUnit { get { return GetResourceString("idMPLUnit"); } }

		public static string idAPLUnit { get { return GetResourceString("idAPLUnit"); } }

		public static string idBethesdaUnit { get { return GetResourceString("idBethesdaUnit"); } }

		public static string idToddUnit { get { return GetResourceString("idToddUnit"); } }

		public static string idDyeUnit { get { return GetResourceString("idDyeUnit"); } }

		public static string idSomogyiUnit { get { return GetResourceString("idSomogyiUnit"); } }

		public static string idBodanskyUnit { get { return GetResourceString("idBodanskyUnit"); } }

		public static string idKingArmstrongUnit { get { return GetResourceString("idKingArmstrongUnit"); } }

		public static string idKunkelUnit { get { return GetResourceString("idKunkelUnit"); } }

		public static string idMacLaganUnit { get { return GetResourceString("idMacLaganUnit"); } }

		public static string idTuberculinUnit { get { return GetResourceString("idTuberculinUnit"); } }

		public static string id50PctCellCultureInfectiousDose { get { return GetResourceString("id50PctCellCultureInfectiousDose"); } }

		public static string id50PctTissueCultureInfectiousDose { get { return GetResourceString("id50PctTissueCultureInfectiousDose"); } }

		public static string idPlaqueFormingUnits { get { return GetResourceString("idPlaqueFormingUnits"); } }

		public static string idImmunofocusFormingUnits { get { return GetResourceString("idImmunofocusFormingUnits"); } }

		public static string idColonyFormingUnits { get { return GetResourceString("idColonyFormingUnits"); } }

		public static string idNeper { get { return GetResourceString("idNeper"); } }

		public static string idBel { get { return GetResourceString("idBel"); } }

		public static string idBelSoundPressure { get { return GetResourceString("idBelSoundPressure"); } }

		public static string idBelVolt { get { return GetResourceString("idBelVolt"); } }

		public static string idBelMillivolt { get { return GetResourceString("idBelMillivolt"); } }

		public static string idBelMicrovolt { get { return GetResourceString("idBelMicrovolt"); } }

		public static string idBelWatt { get { return GetResourceString("idBelWatt"); } }

		public static string idBelKilowatt { get { return GetResourceString("idBelKilowatt"); } }

		public static string idStere { get { return GetResourceString("idStere"); } }

		public static string idAngstrom { get { return GetResourceString("idAngstrom"); } }

		public static string idBarn { get { return GetResourceString("idBarn"); } }

		public static string idTechAtmo { get { return GetResourceString("idTechAtmo"); } }

		public static string idMho { get { return GetResourceString("idMho"); } }

		public static string idPoundPerSqareInch { get { return GetResourceString("idPoundPerSqareInch"); } }

		public static string idCircle { get { return GetResourceString("idCircle"); } }

		public static string idSpere { get { return GetResourceString("idSpere"); } }

		public static string idMetricCarat { get { return GetResourceString("idMetricCarat"); } }

		public static string idCaratOfGoldAlloys { get { return GetResourceString("idCaratOfGoldAlloys"); } }

		public static string idSmoot { get { return GetResourceString("idSmoot"); } }

		public static string idBit { get { return GetResourceString("idBit"); } }

		public static string idBit_auxUCUM { get { return GetResourceString("idBit_auxUCUM"); } }

		public static string idByte { get { return GetResourceString("idByte"); } }

		public static string idBaud { get { return GetResourceString("idBaud"); } }

		public static string idKibi { get { return GetResourceString("idKibi"); } }

		public static string idMebi { get { return GetResourceString("idMebi"); } }

		public static string idGibi { get { return GetResourceString("idGibi"); } }

		public static string idTebi { get { return GetResourceString("idTebi"); } }

		public static string idMetaFmtUnkn { get { return GetResourceString("idMetaFmtUnkn"); } }

		public static string idViewSrcForDoctype { get { return GetResourceString("idViewSrcForDoctype"); } }

		public static string aggrDSIdent { get { return GetResourceString("aggrDSIdent"); } }

		public static string aggrDSName { get { return GetResourceString("aggrDSName"); } }

		public static string aggrInfo { get { return GetResourceString("aggrInfo"); } }

		public static string ArcGISProfile { get { return GetResourceString("ArcGISProfile"); } }

		public static string ArcGISstyle { get { return GetResourceString("ArcGISstyle"); } }

		public static string assocType { get { return GetResourceString("assocType"); } }

		public static string attExtentSearch { get { return GetResourceString("attExtentSearch"); } }

		public static string attrdefs { get { return GetResourceString("attrdefs"); } }

		public static string attrva { get { return GetResourceString("attrva"); } }

		public static string attrvae { get { return GetResourceString("attrvae"); } }

		public static string attrvai { get { return GetResourceString("attrvai"); } }

		public static string axisDimension { get { return GetResourceString("axisDimension"); } }

		public static string axisDimension_type { get { return GetResourceString("axisDimension_type"); } }

		public static string axisUnits { get { return GetResourceString("axisUnits"); } }

		public static string aziAngle { get { return GetResourceString("aziAngle"); } }

		public static string aziPtLong { get { return GetResourceString("aziPtLong"); } }

		public static string boolFalse { get { return GetResourceString("boolFalse"); } }

		public static string boolTrue { get { return GetResourceString("boolTrue"); } }

		public static string catLang_charset { get { return GetResourceString("catLang_charset"); } }

		public static string dataSetFn { get { return GetResourceString("dataSetFn"); } }

		public static string datum { get { return GetResourceString("datum"); } }

		public static string datumID { get { return GetResourceString("datumID"); } }

		public static string denFlatRat { get { return GetResourceString("denFlatRat"); } }

		public static string descKeys_other { get { return GetResourceString("descKeys_other"); } }

		public static string duration { get { return GetResourceString("duration"); } }

		public static string edomvds { get { return GetResourceString("edomvds"); } }

		public static string edom_attr { get { return GetResourceString("edom_attr"); } }

		public static string ellipsoid { get { return GetResourceString("ellipsoid"); } }

		public static string ellParas { get { return GetResourceString("ellParas"); } }

		public static string enttypd { get { return GetResourceString("enttypd"); } }

		public static string enttypds { get { return GetResourceString("enttypds"); } }

		public static string ESRIISOFormat { get { return GetResourceString("ESRIISOFormat"); } }

		public static string ESRISpatial { get { return GetResourceString("ESRISpatial"); } }

		public static string exterior { get { return GetResourceString("exterior"); } }

		public static string falEastng { get { return GetResourceString("falEastng"); } }

		public static string falENUnits { get { return GetResourceString("falENUnits"); } }

		public static string falNorthng { get { return GetResourceString("falNorthng"); } }

		public static string geoDesc_0 { get { return GetResourceString("geoDesc_0"); } }

		public static string GeographicCoordinateSystem { get { return GetResourceString("GeographicCoordinateSystem"); } }

		public static string gmlAttributes { get { return GetResourceString("gmlAttributes"); } }

		public static string gmlDesc { get { return GetResourceString("gmlDesc"); } }

		public static string gmlDescRef { get { return GetResourceString("gmlDescRef"); } }

		public static string gmlID { get { return GetResourceString("gmlID"); } }

		public static string gmlIdent { get { return GetResourceString("gmlIdent"); } }

		public static string gmlIdent_codespace { get { return GetResourceString("gmlIdent_codespace"); } }

		public static string gmlName { get { return GetResourceString("gmlName"); } }

		public static string gmlName_codespace { get { return GetResourceString("gmlName_codespace"); } }

		public static string gmlRemarks { get { return GetResourceString("gmlRemarks"); } }

		public static string hgtProsPt { get { return GetResourceString("hgtProsPt"); } }

		public static string HighPrecision { get { return GetResourceString("HighPrecision"); } }

		public static string idAllowedCompressions { get { return GetResourceString("idAllowedCompressions"); } }

		public static string idAllowedFields { get { return GetResourceString("idAllowedFields"); } }

		public static string idAllowedItemMetadata { get { return GetResourceString("idAllowedItemMetadata"); } }

		public static string idAllowedMosaicMethods { get { return GetResourceString("idAllowedMosaicMethods"); } }

		public static string idAvailableCompressionMethods { get { return GetResourceString("idAvailableCompressionMethods"); } }

		public static string idAvailableItemMetadataLevels { get { return GetResourceString("idAvailableItemMetadataLevels"); } }

		public static string idAvailableMosaicMethods { get { return GetResourceString("idAvailableMosaicMethods"); } }

		public static string idAvailableVisibleFields { get { return GetResourceString("idAvailableVisibleFields"); } }

		public static string idCouplLoose { get { return GetResourceString("idCouplLoose"); } }

		public static string idCouplMixed { get { return GetResourceString("idCouplMixed"); } }

		public static string idCouplTight { get { return GetResourceString("idCouplTight"); } }

		public static string idDcpCom { get { return GetResourceString("idDcpCom"); } }

		public static string idDcpCorba { get { return GetResourceString("idDcpCorba"); } }

		public static string idDcpJava { get { return GetResourceString("idDcpJava"); } }

		public static string idDcpSql { get { return GetResourceString("idDcpSql"); } }

		public static string idDcpWebSvc { get { return GetResourceString("idDcpWebSvc"); } }

		public static string idDcpXml { get { return GetResourceString("idDcpXml"); } }

		public static string idDefaultCompressionQuality { get { return GetResourceString("idDefaultCompressionQuality"); } }

		public static string idDefaultResamplingMethod { get { return GetResourceString("idDefaultResamplingMethod"); } }

		public static string idDirIn { get { return GetResourceString("idDirIn"); } }

		public static string idDirInOut { get { return GetResourceString("idDirInOut"); } }

		public static string idDirOut { get { return GetResourceString("idDirOut"); } }

		public static string idGeomAny { get { return GetResourceString("idGeomAny"); } }

		public static string idGeomBag { get { return GetResourceString("idGeomBag"); } }

		public static string idGeomBez { get { return GetResourceString("idGeomBez"); } }

		public static string idGeomCircArc { get { return GetResourceString("idGeomCircArc"); } }

		public static string idGeomEllArc { get { return GetResourceString("idGeomEllArc"); } }

		public static string idGeomEnv { get { return GetResourceString("idGeomEnv"); } }

		public static string idGeomLine { get { return GetResourceString("idGeomLine"); } }

		public static string idGeomMultipt { get { return GetResourceString("idGeomMultipt"); } }

		public static string idGeomMultiptch { get { return GetResourceString("idGeomMultiptch"); } }

		public static string idGeomNull { get { return GetResourceString("idGeomNull"); } }

		public static string idGeomPath { get { return GetResourceString("idGeomPath"); } }

		public static string idGeomPolygn { get { return GetResourceString("idGeomPolygn"); } }

		public static string idGeomPolyln { get { return GetResourceString("idGeomPolyln"); } }

		public static string idGeomPt { get { return GetResourceString("idGeomPt"); } }

		public static string idGeomRay { get { return GetResourceString("idGeomRay"); } }

		public static string idGeomRing { get { return GetResourceString("idGeomRing"); } }

		public static string idGeomSph { get { return GetResourceString("idGeomSph"); } }

		public static string idGeomTri { get { return GetResourceString("idGeomTri"); } }

		public static string idGeomTriFan { get { return GetResourceString("idGeomTriFan"); } }

		public static string idGeomTriStr { get { return GetResourceString("idGeomTriStr"); } }

		public static string idMaxDownloadImageCount { get { return GetResourceString("idMaxDownloadImageCount"); } }

		public static string idMaxImageHeight { get { return GetResourceString("idMaxImageHeight"); } }

		public static string idMaxImageWidth { get { return GetResourceString("idMaxImageWidth"); } }

		public static string idMaxMosaicImageCount { get { return GetResourceString("idMaxMosaicImageCount"); } }

		public static string idMaxRecordCount { get { return GetResourceString("idMaxRecordCount"); } }

		public static string idNoUseLimitsForItem { get { return GetResourceString("idNoUseLimitsForItem"); } }

		public static string idUseLimits_ItemDescription { get { return GetResourceString("idUseLimits_ItemDescription"); } }

		public static string initType { get { return GetResourceString("initType"); } }

		public static string interior { get { return GetResourceString("interior"); } }

		public static string keyTyp { get { return GetResourceString("keyTyp"); } }

		public static string latProjCnt { get { return GetResourceString("latProjCnt"); } }

		public static string latProjOri { get { return GetResourceString("latProjOri"); } }

		public static string LeftLongitude { get { return GetResourceString("LeftLongitude"); } }

		public static string loc { get { return GetResourceString("loc"); } }

		public static string locCountry { get { return GetResourceString("locCountry"); } }

		public static string locEncoding { get { return GetResourceString("locEncoding"); } }

		public static string locLang { get { return GetResourceString("locLang"); } }

		public static string longCntMer { get { return GetResourceString("longCntMer"); } }

		public static string longProjCnt { get { return GetResourceString("longProjCnt"); } }

		public static string MapLyrSync { get { return GetResourceString("MapLyrSync"); } }

		public static string metadataFormat { get { return GetResourceString("metadataFormat"); } }

		public static string MetaID { get { return GetResourceString("MetaID"); } }

		public static string MOrigin { get { return GetResourceString("MOrigin"); } }

		public static string MosaicArguments { get { return GetResourceString("MosaicArguments"); } }

		public static string MosaicDescription { get { return GetResourceString("MosaicDescription"); } }

		public static string MosaicFunction { get { return GetResourceString("MosaicFunction"); } }

		public static string MosaicFunctions { get { return GetResourceString("MosaicFunctions"); } }

		public static string MosaicProperties { get { return GetResourceString("MosaicProperties"); } }

		public static string MScale { get { return GetResourceString("MScale"); } }

		public static string MTolerance { get { return GetResourceString("MTolerance"); } }

		public static string obLineLat { get { return GetResourceString("obLineLat"); } }

		public static string obLineLong { get { return GetResourceString("obLineLong"); } }

		public static string obLnAziPars { get { return GetResourceString("obLnAziPars"); } }

		public static string obLnPtPars { get { return GetResourceString("obLnPtPars"); } }

		public static string polygon { get { return GetResourceString("polygon"); } }

		public static string pos { get { return GetResourceString("pos"); } }

		public static string ProjectedCoordinateSystem { get { return GetResourceString("ProjectedCoordinateSystem"); } }

		public static string projection { get { return GetResourceString("projection"); } }

		public static string projParas { get { return GetResourceString("projParas"); } }

		public static string rdom_attr { get { return GetResourceString("rdom_attr"); } }

		public static string resRefDate { get { return GetResourceString("resRefDate"); } }

		public static string sclFacCnt { get { return GetResourceString("sclFacCnt"); } }

		public static string sclFacEqu { get { return GetResourceString("sclFacEqu"); } }

		public static string sclFacPrOr { get { return GetResourceString("sclFacPrOr"); } }

		public static string semiMajAx { get { return GetResourceString("semiMajAx"); } }

		public static string ServiceIdentification { get { return GetResourceString("ServiceIdentification"); } }

		public static string srcMedName { get { return GetResourceString("srcMedName"); } }

		public static string stanParal { get { return GetResourceString("stanParal"); } }

		public static string stVrLongPl { get { return GetResourceString("stVrLongPl"); } }

		public static string svAccProps { get { return GetResourceString("svAccProps"); } }

		public static string svConPt { get { return GetResourceString("svConPt"); } }

		public static string svCouplRes { get { return GetResourceString("svCouplRes"); } }

		public static string svCouplType { get { return GetResourceString("svCouplType"); } }

		public static string svDCP { get { return GetResourceString("svDCP"); } }

		public static string svDesc { get { return GetResourceString("svDesc"); } }

		public static string svExt { get { return GetResourceString("svExt"); } }

		public static string svInvocName { get { return GetResourceString("svInvocName"); } }

		public static string svOper { get { return GetResourceString("svOper"); } }

		public static string svOperOn { get { return GetResourceString("svOperOn"); } }

		public static string svOpName { get { return GetResourceString("svOpName"); } }

		public static string svOpName_0 { get { return GetResourceString("svOpName_0"); } }

		public static string svParams { get { return GetResourceString("svParams"); } }

		public static string svParDir { get { return GetResourceString("svParDir"); } }

		public static string svParName { get { return GetResourceString("svParName"); } }

		public static string svParOpt { get { return GetResourceString("svParOpt"); } }

		public static string svRepeat { get { return GetResourceString("svRepeat"); } }

		public static string svType { get { return GetResourceString("svType"); } }

		public static string svTypeVer { get { return GetResourceString("svTypeVer"); } }

		public static string svType_codespace { get { return GetResourceString("svType_codespace"); } }

		public static string svValType { get { return GetResourceString("svValType"); } }

		public static string thesaLang { get { return GetResourceString("thesaLang"); } }

		public static string tmPosition { get { return GetResourceString("tmPosition"); } }

		public static string unitQuanRef { get { return GetResourceString("unitQuanRef"); } }

		public static string unitQuanType { get { return GetResourceString("unitQuanType"); } }

		public static string unitSymbol { get { return GetResourceString("unitSymbol"); } }

		public static string unitSymbol_codespace { get { return GetResourceString("unitSymbol_codespace"); } }

		public static string WKID { get { return GetResourceString("WKID"); } }

		public static string WKT { get { return GetResourceString("WKT"); } }

		public static string XOrigin { get { return GetResourceString("XOrigin"); } }

		public static string XYScale { get { return GetResourceString("XYScale"); } }

		public static string XYTolerance { get { return GetResourceString("XYTolerance"); } }

		public static string YOrigin { get { return GetResourceString("YOrigin"); } }

		public static string zone { get { return GetResourceString("zone"); } }

		public static string ZOrigin { get { return GetResourceString("ZOrigin"); } }

		public static string ZScale { get { return GetResourceString("ZScale"); } }

		public static string ZTolerance { get { return GetResourceString("ZTolerance"); } }

		public static string CovDesc { get { return GetResourceString("CovDesc"); } }

		public static string ESRIFeatureClass { get { return GetResourceString("ESRIFeatureClass"); } }

		public static string FetCatDesc { get { return GetResourceString("FetCatDesc"); } }

		public static string Georect { get { return GetResourceString("Georect"); } }

		public static string Georef { get { return GetResourceString("Georef"); } }

		public static string GridSpatRep { get { return GetResourceString("GridSpatRep"); } }

		public static string idMD_Distribution { get { return GetResourceString("idMD_Distribution"); } }

		public static string idMD_DistributionMany { get { return GetResourceString("idMD_DistributionMany"); } }

		public static string idTopArcGIS { get { return GetResourceString("idTopArcGIS"); } }

		public static string idTopFGDC { get { return GetResourceString("idTopFGDC"); } }

		public static string ImgDesc { get { return GetResourceString("ImgDesc"); } }

		public static string VectSpatRep { get { return GetResourceString("VectSpatRep"); } }

		public static string ESRILocales { get { return GetResourceString("ESRILocales"); } }

		public static string idLocale { get { return GetResourceString("idLocale"); } }

		public static string CODE_MD_ScopeCode_001 { get { return GetResourceString("CODE_MD_ScopeCode_001"); } }

		public static string CODE_MD_ScopeCode_002 { get { return GetResourceString("CODE_MD_ScopeCode_002"); } }

		public static string CODE_MD_ScopeCode_003 { get { return GetResourceString("CODE_MD_ScopeCode_003"); } }

		public static string CODE_MD_ScopeCode_004 { get { return GetResourceString("CODE_MD_ScopeCode_004"); } }

		public static string CODE_MD_ScopeCode_005 { get { return GetResourceString("CODE_MD_ScopeCode_005"); } }

		public static string CODE_MD_ScopeCode_006 { get { return GetResourceString("CODE_MD_ScopeCode_006"); } }

		public static string CODE_MD_ScopeCode_007 { get { return GetResourceString("CODE_MD_ScopeCode_007"); } }

		public static string CODE_MD_ScopeCode_008 { get { return GetResourceString("CODE_MD_ScopeCode_008"); } }

		public static string CODE_MD_ScopeCode_009 { get { return GetResourceString("CODE_MD_ScopeCode_009"); } }

		public static string CODE_MD_ScopeCode_010 { get { return GetResourceString("CODE_MD_ScopeCode_010"); } }

		public static string CODE_MD_ScopeCode_011 { get { return GetResourceString("CODE_MD_ScopeCode_011"); } }

		public static string CODE_MD_ScopeCode_012 { get { return GetResourceString("CODE_MD_ScopeCode_012"); } }

		public static string CODE_MD_ScopeCode_013 { get { return GetResourceString("CODE_MD_ScopeCode_013"); } }

		public static string CODE_MD_ScopeCode_014 { get { return GetResourceString("CODE_MD_ScopeCode_014"); } }

		public static string CODE_MD_ScopeCode_015 { get { return GetResourceString("CODE_MD_ScopeCode_015"); } }

		public static string CODE_MD_ScopeCode_016 { get { return GetResourceString("CODE_MD_ScopeCode_016"); } }

		public static string CODE_MD_ScopeCode_017 { get { return GetResourceString("CODE_MD_ScopeCode_017"); } }

		public static string CODE_MD_ScopeCode_018 { get { return GetResourceString("CODE_MD_ScopeCode_018"); } }

		public static string CODE_MD_ScopeCode_019 { get { return GetResourceString("CODE_MD_ScopeCode_019"); } }

		public static string CODE_MD_ScopeCode_020 { get { return GetResourceString("CODE_MD_ScopeCode_020"); } }

		public static string CODE_MD_ScopeCode_021 { get { return GetResourceString("CODE_MD_ScopeCode_021"); } }

		public static string CODE_MD_ScopeCode_022 { get { return GetResourceString("CODE_MD_ScopeCode_022"); } }

		public static string CODE_MD_ScopeCode_023 { get { return GetResourceString("CODE_MD_ScopeCode_023"); } }

		public static string CODE_MD_ScopeCode_024 { get { return GetResourceString("CODE_MD_ScopeCode_024"); } }

		public static string CODE_MD_CharacterSetCode_1 { get { return GetResourceString("CODE_MD_CharacterSetCode_1"); } }

		public static string CODE_MD_CharacterSetCode_2 { get { return GetResourceString("CODE_MD_CharacterSetCode_2"); } }

		public static string CODE_MD_CharacterSetCode_3 { get { return GetResourceString("CODE_MD_CharacterSetCode_3"); } }

		public static string CODE_MD_CharacterSetCode_4 { get { return GetResourceString("CODE_MD_CharacterSetCode_4"); } }

		public static string CODE_MD_CharacterSetCode_5 { get { return GetResourceString("CODE_MD_CharacterSetCode_5"); } }

		public static string CODE_MD_CharacterSetCode_6 { get { return GetResourceString("CODE_MD_CharacterSetCode_6"); } }

		public static string CODE_MD_CharacterSetCode_7 { get { return GetResourceString("CODE_MD_CharacterSetCode_7"); } }

		public static string CODE_MD_CharacterSetCode_8 { get { return GetResourceString("CODE_MD_CharacterSetCode_8"); } }

		public static string CODE_MD_CharacterSetCode_9 { get { return GetResourceString("CODE_MD_CharacterSetCode_9"); } }

		public static string CODE_MD_CharacterSetCode_10 { get { return GetResourceString("CODE_MD_CharacterSetCode_10"); } }

		public static string CODE_MD_CharacterSetCode_11 { get { return GetResourceString("CODE_MD_CharacterSetCode_11"); } }

		public static string CODE_MD_CharacterSetCode_12 { get { return GetResourceString("CODE_MD_CharacterSetCode_12"); } }

		public static string CODE_MD_CharacterSetCode_13 { get { return GetResourceString("CODE_MD_CharacterSetCode_13"); } }

		public static string CODE_MD_CharacterSetCode_14 { get { return GetResourceString("CODE_MD_CharacterSetCode_14"); } }

		public static string CODE_MD_CharacterSetCode_15 { get { return GetResourceString("CODE_MD_CharacterSetCode_15"); } }

		public static string CODE_MD_CharacterSetCode_16 { get { return GetResourceString("CODE_MD_CharacterSetCode_16"); } }

		public static string CODE_MD_CharacterSetCode_18 { get { return GetResourceString("CODE_MD_CharacterSetCode_18"); } }

		public static string CODE_MD_CharacterSetCode_19 { get { return GetResourceString("CODE_MD_CharacterSetCode_19"); } }

		public static string CODE_MD_CharacterSetCode_20 { get { return GetResourceString("CODE_MD_CharacterSetCode_20"); } }

		public static string CODE_MD_CharacterSetCode_21 { get { return GetResourceString("CODE_MD_CharacterSetCode_21"); } }

		public static string CODE_MD_CharacterSetCode_22 { get { return GetResourceString("CODE_MD_CharacterSetCode_22"); } }

		public static string CODE_MD_CharacterSetCode_23 { get { return GetResourceString("CODE_MD_CharacterSetCode_23"); } }

		public static string CODE_MD_CharacterSetCode_24 { get { return GetResourceString("CODE_MD_CharacterSetCode_24"); } }

		public static string CODE_MD_CharacterSetCode_25 { get { return GetResourceString("CODE_MD_CharacterSetCode_25"); } }

		public static string CODE_MD_CharacterSetCode_26 { get { return GetResourceString("CODE_MD_CharacterSetCode_26"); } }

		public static string CODE_MD_CharacterSetCode_27 { get { return GetResourceString("CODE_MD_CharacterSetCode_27"); } }

		public static string CODE_MD_CharacterSetCode_28 { get { return GetResourceString("CODE_MD_CharacterSetCode_28"); } }

		public static string CODE_MD_CharacterSetCode_29 { get { return GetResourceString("CODE_MD_CharacterSetCode_29"); } }

		public static string CODE_MD_TopologyLevelCode_001 { get { return GetResourceString("CODE_MD_TopologyLevelCode_001"); } }

		public static string CODE_MD_TopologyLevelCode_002 { get { return GetResourceString("CODE_MD_TopologyLevelCode_002"); } }

		public static string CODE_MD_TopologyLevelCode_003 { get { return GetResourceString("CODE_MD_TopologyLevelCode_003"); } }

		public static string CODE_MD_TopologyLevelCode_004 { get { return GetResourceString("CODE_MD_TopologyLevelCode_004"); } }

		public static string CODE_MD_TopologyLevelCode_005 { get { return GetResourceString("CODE_MD_TopologyLevelCode_005"); } }

		public static string CODE_MD_TopologyLevelCode_006 { get { return GetResourceString("CODE_MD_TopologyLevelCode_006"); } }

		public static string CODE_MD_TopologyLevelCode_007 { get { return GetResourceString("CODE_MD_TopologyLevelCode_007"); } }

		public static string CODE_MD_TopologyLevelCode_008 { get { return GetResourceString("CODE_MD_TopologyLevelCode_008"); } }

		public static string CODE_MD_TopologyLevelCode_009 { get { return GetResourceString("CODE_MD_TopologyLevelCode_009"); } }

		public static string CODE_UoM_measure { get { return GetResourceString("CODE_UoM_measure"); } }

		public static string CODE_UoM_area { get { return GetResourceString("CODE_UoM_area"); } }

		public static string CODE_UoM_time { get { return GetResourceString("CODE_UoM_time"); } }

		public static string CODE_UoM_length { get { return GetResourceString("CODE_UoM_length"); } }

		public static string CODE_UoM_volume { get { return GetResourceString("CODE_UoM_volume"); } }

		public static string CODE_UoM_velocity { get { return GetResourceString("CODE_UoM_velocity"); } }

		public static string CODE_UoM_angle { get { return GetResourceString("CODE_UoM_angle"); } }

		public static string CODE_UoM_scale { get { return GetResourceString("CODE_UoM_scale"); } }

		public static string CODE_MD_SpatialRepresentationTypeCode_001 { get { return GetResourceString("CODE_MD_SpatialRepresentationTypeCode_001"); } }

		public static string CODE_MD_SpatialRepresentationTypeCode_002 { get { return GetResourceString("CODE_MD_SpatialRepresentationTypeCode_002"); } }

		public static string CODE_MD_SpatialRepresentationTypeCode_003 { get { return GetResourceString("CODE_MD_SpatialRepresentationTypeCode_003"); } }

		public static string CODE_MD_SpatialRepresentationTypeCode_004 { get { return GetResourceString("CODE_MD_SpatialRepresentationTypeCode_004"); } }

		public static string CODE_MD_SpatialRepresentationTypeCode_005 { get { return GetResourceString("CODE_MD_SpatialRepresentationTypeCode_005"); } }

		public static string CODE_MD_SpatialRepresentationTypeCode_006 { get { return GetResourceString("CODE_MD_SpatialRepresentationTypeCode_006"); } }

		public static string CODE_MD_GeometricObjectTypeCode_001 { get { return GetResourceString("CODE_MD_GeometricObjectTypeCode_001"); } }

		public static string CODE_MD_GeometricObjectTypeCode_002 { get { return GetResourceString("CODE_MD_GeometricObjectTypeCode_002"); } }

		public static string CODE_MD_GeometricObjectTypeCode_003 { get { return GetResourceString("CODE_MD_GeometricObjectTypeCode_003"); } }

		public static string CODE_MD_GeometricObjectTypeCode_004 { get { return GetResourceString("CODE_MD_GeometricObjectTypeCode_004"); } }

		public static string CODE_MD_GeometricObjectTypeCode_005 { get { return GetResourceString("CODE_MD_GeometricObjectTypeCode_005"); } }

		public static string CODE_MD_GeometricObjectTypeCode_006 { get { return GetResourceString("CODE_MD_GeometricObjectTypeCode_006"); } }

		public static string CODE_MD_RestrictionCode_001 { get { return GetResourceString("CODE_MD_RestrictionCode_001"); } }

		public static string CODE_MD_RestrictionCode_002 { get { return GetResourceString("CODE_MD_RestrictionCode_002"); } }

		public static string CODE_MD_RestrictionCode_003 { get { return GetResourceString("CODE_MD_RestrictionCode_003"); } }

		public static string CODE_MD_RestrictionCode_004 { get { return GetResourceString("CODE_MD_RestrictionCode_004"); } }

		public static string CODE_MD_RestrictionCode_005 { get { return GetResourceString("CODE_MD_RestrictionCode_005"); } }

		public static string CODE_MD_RestrictionCode_006 { get { return GetResourceString("CODE_MD_RestrictionCode_006"); } }

		public static string CODE_MD_RestrictionCode_007 { get { return GetResourceString("CODE_MD_RestrictionCode_007"); } }

		public static string CODE_MD_RestrictionCode_008 { get { return GetResourceString("CODE_MD_RestrictionCode_008"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_001 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_001"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_002 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_002"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_003 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_003"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_004 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_004"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_005 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_005"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_006 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_006"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_007 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_007"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_008 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_008"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_009 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_009"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_010 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_010"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_011 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_011"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_012 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_012"); } }

		public static string CODE_MD_DimensionNameTypeCode_001 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_001"); } }

		public static string CODE_MD_DimensionNameTypeCode_002 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_002"); } }

		public static string CODE_MD_DimensionNameTypeCode_003 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_003"); } }

		public static string CODE_MD_DimensionNameTypeCode_004 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_004"); } }

		public static string CODE_MD_DimensionNameTypeCode_005 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_005"); } }

		public static string CODE_MD_DimensionNameTypeCode_006 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_006"); } }

		public static string CODE_MD_DimensionNameTypeCode_007 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_007"); } }

		public static string CODE_MD_DimensionNameTypeCode_008 { get { return GetResourceString("CODE_MD_DimensionNameTypeCode_008"); } }

		public static string CODE_MD_CellGeometryCode_001 { get { return GetResourceString("CODE_MD_CellGeometryCode_001"); } }

		public static string CODE_MD_CellGeometryCode_002 { get { return GetResourceString("CODE_MD_CellGeometryCode_002"); } }

		public static string CODE_MD_CoverageContentTypeCode_001 { get { return GetResourceString("CODE_MD_CoverageContentTypeCode_001"); } }

		public static string CODE_MD_CoverageContentTypeCode_002 { get { return GetResourceString("CODE_MD_CoverageContentTypeCode_002"); } }

		public static string CODE_MD_CoverageContentTypeCode_003 { get { return GetResourceString("CODE_MD_CoverageContentTypeCode_003"); } }

		public static string CODE_MD_ImagingConditionCode_001 { get { return GetResourceString("CODE_MD_ImagingConditionCode_001"); } }

		public static string CODE_MD_ImagingConditionCode_002 { get { return GetResourceString("CODE_MD_ImagingConditionCode_002"); } }

		public static string CODE_MD_ImagingConditionCode_003 { get { return GetResourceString("CODE_MD_ImagingConditionCode_003"); } }

		public static string CODE_MD_ImagingConditionCode_004 { get { return GetResourceString("CODE_MD_ImagingConditionCode_004"); } }

		public static string CODE_MD_ImagingConditionCode_005 { get { return GetResourceString("CODE_MD_ImagingConditionCode_005"); } }

		public static string CODE_MD_ImagingConditionCode_006 { get { return GetResourceString("CODE_MD_ImagingConditionCode_006"); } }

		public static string CODE_MD_ImagingConditionCode_007 { get { return GetResourceString("CODE_MD_ImagingConditionCode_007"); } }

		public static string CODE_MD_ImagingConditionCode_008 { get { return GetResourceString("CODE_MD_ImagingConditionCode_008"); } }

		public static string CODE_MD_ImagingConditionCode_009 { get { return GetResourceString("CODE_MD_ImagingConditionCode_009"); } }

		public static string CODE_MD_ImagingConditionCode_010 { get { return GetResourceString("CODE_MD_ImagingConditionCode_010"); } }

		public static string CODE_MD_ImagingConditionCode_011 { get { return GetResourceString("CODE_MD_ImagingConditionCode_011"); } }

		public static string CODE_MD_PixelOrientationCode_001 { get { return GetResourceString("CODE_MD_PixelOrientationCode_001"); } }

		public static string CODE_MD_PixelOrientationCode_002 { get { return GetResourceString("CODE_MD_PixelOrientationCode_002"); } }

		public static string CODE_MD_PixelOrientationCode_003 { get { return GetResourceString("CODE_MD_PixelOrientationCode_003"); } }

		public static string CODE_MD_PixelOrientationCode_004 { get { return GetResourceString("CODE_MD_PixelOrientationCode_004"); } }

		public static string CODE_MD_PixelOrientationCode_005 { get { return GetResourceString("CODE_MD_PixelOrientationCode_005"); } }

		public static string CODE_CI_RoleCode_001 { get { return GetResourceString("CODE_CI_RoleCode_001"); } }

		public static string CODE_CI_RoleCode_002 { get { return GetResourceString("CODE_CI_RoleCode_002"); } }

		public static string CODE_CI_RoleCode_003 { get { return GetResourceString("CODE_CI_RoleCode_003"); } }

		public static string CODE_CI_RoleCode_004 { get { return GetResourceString("CODE_CI_RoleCode_004"); } }

		public static string CODE_CI_RoleCode_005 { get { return GetResourceString("CODE_CI_RoleCode_005"); } }

		public static string CODE_CI_RoleCode_006 { get { return GetResourceString("CODE_CI_RoleCode_006"); } }

		public static string CODE_CI_RoleCode_007 { get { return GetResourceString("CODE_CI_RoleCode_007"); } }

		public static string CODE_CI_RoleCode_008 { get { return GetResourceString("CODE_CI_RoleCode_008"); } }

		public static string CODE_CI_RoleCode_009 { get { return GetResourceString("CODE_CI_RoleCode_009"); } }

		public static string CODE_CI_RoleCode_010 { get { return GetResourceString("CODE_CI_RoleCode_010"); } }

		public static string CODE_CI_RoleCode_011 { get { return GetResourceString("CODE_CI_RoleCode_011"); } }

		public static string CODE_CI_OnLineFunctionCode_001 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_001"); } }

		public static string CODE_CI_OnLineFunctionCode_002 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_002"); } }

		public static string CODE_CI_OnLineFunctionCode_003 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_003"); } }

		public static string CODE_CI_OnLineFunctionCode_004 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_004"); } }

		public static string CODE_CI_OnLineFunctionCode_005 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_005"); } }

		public static string CODE_MD_ClassificationCode_001 { get { return GetResourceString("CODE_MD_ClassificationCode_001"); } }

		public static string CODE_MD_ClassificationCode_002 { get { return GetResourceString("CODE_MD_ClassificationCode_002"); } }

		public static string CODE_MD_ClassificationCode_003 { get { return GetResourceString("CODE_MD_ClassificationCode_003"); } }

		public static string CODE_MD_ClassificationCode_004 { get { return GetResourceString("CODE_MD_ClassificationCode_004"); } }

		public static string CODE_MD_ClassificationCode_005 { get { return GetResourceString("CODE_MD_ClassificationCode_005"); } }

		public static string CODE_MD_MediumFormatCode_001 { get { return GetResourceString("CODE_MD_MediumFormatCode_001"); } }

		public static string CODE_MD_MediumFormatCode_002 { get { return GetResourceString("CODE_MD_MediumFormatCode_002"); } }

		public static string CODE_MD_MediumFormatCode_003 { get { return GetResourceString("CODE_MD_MediumFormatCode_003"); } }

		public static string CODE_MD_MediumFormatCode_004 { get { return GetResourceString("CODE_MD_MediumFormatCode_004"); } }

		public static string CODE_MD_MediumFormatCode_005 { get { return GetResourceString("CODE_MD_MediumFormatCode_005"); } }

		public static string CODE_MD_MediumFormatCode_006 { get { return GetResourceString("CODE_MD_MediumFormatCode_006"); } }

		public static string CODE_MD_MediumFormatCode_NAP_007 { get { return GetResourceString("CODE_MD_MediumFormatCode_NAP_007"); } }

		public static string CODE_MD_MediumNameCode_001 { get { return GetResourceString("CODE_MD_MediumNameCode_001"); } }

		public static string CODE_MD_MediumNameCode_002 { get { return GetResourceString("CODE_MD_MediumNameCode_002"); } }

		public static string CODE_MD_MediumNameCode_003 { get { return GetResourceString("CODE_MD_MediumNameCode_003"); } }

		public static string CODE_MD_MediumNameCode_004 { get { return GetResourceString("CODE_MD_MediumNameCode_004"); } }

		public static string CODE_MD_MediumNameCode_005 { get { return GetResourceString("CODE_MD_MediumNameCode_005"); } }

		public static string CODE_MD_MediumNameCode_006 { get { return GetResourceString("CODE_MD_MediumNameCode_006"); } }

		public static string CODE_MD_MediumNameCode_007 { get { return GetResourceString("CODE_MD_MediumNameCode_007"); } }

		public static string CODE_MD_MediumNameCode_008 { get { return GetResourceString("CODE_MD_MediumNameCode_008"); } }

		public static string CODE_MD_MediumNameCode_009 { get { return GetResourceString("CODE_MD_MediumNameCode_009"); } }

		public static string CODE_MD_MediumNameCode_010 { get { return GetResourceString("CODE_MD_MediumNameCode_010"); } }

		public static string CODE_MD_MediumNameCode_011 { get { return GetResourceString("CODE_MD_MediumNameCode_011"); } }

		public static string CODE_MD_MediumNameCode_012 { get { return GetResourceString("CODE_MD_MediumNameCode_012"); } }

		public static string CODE_MD_MediumNameCode_013 { get { return GetResourceString("CODE_MD_MediumNameCode_013"); } }

		public static string CODE_MD_MediumNameCode_014 { get { return GetResourceString("CODE_MD_MediumNameCode_014"); } }

		public static string CODE_MD_MediumNameCode_015 { get { return GetResourceString("CODE_MD_MediumNameCode_015"); } }

		public static string CODE_MD_MediumNameCode_016 { get { return GetResourceString("CODE_MD_MediumNameCode_016"); } }

		public static string CODE_MD_MediumNameCode_017 { get { return GetResourceString("CODE_MD_MediumNameCode_017"); } }

		public static string CODE_MD_MediumNameCode_018 { get { return GetResourceString("CODE_MD_MediumNameCode_018"); } }

		public static string CODE_MD_ProgressCode_001 { get { return GetResourceString("CODE_MD_ProgressCode_001"); } }

		public static string CODE_MD_ProgressCode_002 { get { return GetResourceString("CODE_MD_ProgressCode_002"); } }

		public static string CODE_MD_ProgressCode_003 { get { return GetResourceString("CODE_MD_ProgressCode_003"); } }

		public static string CODE_MD_ProgressCode_004 { get { return GetResourceString("CODE_MD_ProgressCode_004"); } }

		public static string CODE_MD_ProgressCode_005 { get { return GetResourceString("CODE_MD_ProgressCode_005"); } }

		public static string CODE_MD_ProgressCode_006 { get { return GetResourceString("CODE_MD_ProgressCode_006"); } }

		public static string CODE_MD_ProgressCode_007 { get { return GetResourceString("CODE_MD_ProgressCode_007"); } }

		public static string CODE_CI_PresentationCode_001 { get { return GetResourceString("CODE_CI_PresentationCode_001"); } }

		public static string CODE_CI_PresentationCode_002 { get { return GetResourceString("CODE_CI_PresentationCode_002"); } }

		public static string CODE_CI_PresentationCode_003 { get { return GetResourceString("CODE_CI_PresentationCode_003"); } }

		public static string CODE_CI_PresentationCode_004 { get { return GetResourceString("CODE_CI_PresentationCode_004"); } }

		public static string CODE_CI_PresentationCode_005 { get { return GetResourceString("CODE_CI_PresentationCode_005"); } }

		public static string CODE_CI_PresentationCode_006 { get { return GetResourceString("CODE_CI_PresentationCode_006"); } }

		public static string CODE_CI_PresentationCode_007 { get { return GetResourceString("CODE_CI_PresentationCode_007"); } }

		public static string CODE_CI_PresentationCode_008 { get { return GetResourceString("CODE_CI_PresentationCode_008"); } }

		public static string CODE_CI_PresentationCode_009 { get { return GetResourceString("CODE_CI_PresentationCode_009"); } }

		public static string CODE_CI_PresentationCode_010 { get { return GetResourceString("CODE_CI_PresentationCode_010"); } }

		public static string CODE_CI_PresentationCode_011 { get { return GetResourceString("CODE_CI_PresentationCode_011"); } }

		public static string CODE_CI_PresentationCode_012 { get { return GetResourceString("CODE_CI_PresentationCode_012"); } }

		public static string CODE_CI_PresentationCode_013 { get { return GetResourceString("CODE_CI_PresentationCode_013"); } }

		public static string CODE_CI_PresentationCode_014 { get { return GetResourceString("CODE_CI_PresentationCode_014"); } }

		public static string CODE_DQ_ElementType_DQCompComm { get { return GetResourceString("CODE_DQ_ElementType_DQCompComm"); } }

		public static string CODE_DQ_ElementType_DQCompOm { get { return GetResourceString("CODE_DQ_ElementType_DQCompOm"); } }

		public static string CODE_DQ_ElementType_DQConcConsis { get { return GetResourceString("CODE_DQ_ElementType_DQConcConsis"); } }

		public static string CODE_DQ_ElementType_DQDomConsis { get { return GetResourceString("CODE_DQ_ElementType_DQDomConsis"); } }

		public static string CODE_DQ_ElementType_DQFormConsis { get { return GetResourceString("CODE_DQ_ElementType_DQFormConsis"); } }

		public static string CODE_DQ_ElementType_DQTopConsis { get { return GetResourceString("CODE_DQ_ElementType_DQTopConsis"); } }

		public static string CODE_DQ_ElementType_DQAbsExtPosAcc { get { return GetResourceString("CODE_DQ_ElementType_DQAbsExtPosAcc"); } }

		public static string CODE_DQ_ElementType_DQGridDataPosAcc { get { return GetResourceString("CODE_DQ_ElementType_DQGridDataPosAcc"); } }

		public static string CODE_DQ_ElementType_DQRelIntPosAcc { get { return GetResourceString("CODE_DQ_ElementType_DQRelIntPosAcc"); } }

		public static string CODE_DQ_ElementType_DQThemClassCor { get { return GetResourceString("CODE_DQ_ElementType_DQThemClassCor"); } }

		public static string CODE_DQ_ElementType_DQNonQuanAttAcc { get { return GetResourceString("CODE_DQ_ElementType_DQNonQuanAttAcc"); } }

		public static string CODE_DQ_ElementType_DQQuanAttAcc { get { return GetResourceString("CODE_DQ_ElementType_DQQuanAttAcc"); } }

		public static string CODE_DQ_ElementType_DQAccTimeMeas { get { return GetResourceString("CODE_DQ_ElementType_DQAccTimeMeas"); } }

		public static string CODE_DQ_ElementType_DQTempConsis { get { return GetResourceString("CODE_DQ_ElementType_DQTempConsis"); } }

		public static string CODE_DQ_ElementType_DQTempValid { get { return GetResourceString("CODE_DQ_ElementType_DQTempValid"); } }

		public static string CODE_DQ_EvaluationMethodTypeCode_001 { get { return GetResourceString("CODE_DQ_EvaluationMethodTypeCode_001"); } }

		public static string CODE_DQ_EvaluationMethodTypeCode_002 { get { return GetResourceString("CODE_DQ_EvaluationMethodTypeCode_002"); } }

		public static string CODE_DQ_EvaluationMethodTypeCode_003 { get { return GetResourceString("CODE_DQ_EvaluationMethodTypeCode_003"); } }

		public static string CODE_EMPTY { get { return GetResourceString("CODE_EMPTY"); } }

		public static string ucum_k { get { return GetResourceString("ucum_k"); } }

		public static string ucum_g { get { return GetResourceString("ucum_g"); } }

		public static string ucum_gal { get { return GetResourceString("ucum_gal"); } }

		public static string ucum_g_1 { get { return GetResourceString("ucum_g_1"); } }

		public static string ucum_ph { get { return GetResourceString("ucum_ph"); } }

		public static string ucum_h { get { return GetResourceString("ucum_h"); } }

		public static string ucum_b { get { return GetResourceString("ucum_b"); } }

		public static string ucum_cfu { get { return GetResourceString("ucum_cfu"); } }

		public static string ucum_ffu { get { return GetResourceString("ucum_ffu"); } }

		public static string ucum_pfu { get { return GetResourceString("ucum_pfu"); } }

		public static string ucum_bits { get { return GetResourceString("ucum_bits"); } }

		public static string ucum_bit { get { return GetResourceString("ucum_bit"); } }

		public static string ucum_by { get { return GetResourceString("ucum_by"); } }

		public static string ucum_eq { get { return GetResourceString("ucum_eq"); } }

		public static string ucum_mol { get { return GetResourceString("ucum_mol"); } }

		public static string ucum_osm { get { return GetResourceString("ucum_osm"); } }

		public static string ucum_arbu { get { return GetResourceString("ucum_arbu"); } }

		public static string ucum_iu { get { return GetResourceString("ucum_iu"); } }

		public static string ucum_uspu { get { return GetResourceString("ucum_uspu"); } }

		public static string ucum_knku { get { return GetResourceString("ucum_knku"); } }

		public static string ucum_mclgu { get { return GetResourceString("ucum_mclgu"); } }

		public static string ucum_acrus { get { return GetResourceString("ucum_acrus"); } }

		public static string ucum_acrbr { get { return GetResourceString("ucum_acrbr"); } }

		public static string ucum_ar { get { return GetResourceString("ucum_ar"); } }

		public static string ucum_cmli { get { return GetResourceString("ucum_cmli"); } }

		public static string ucum_sct { get { return GetResourceString("ucum_sct"); } }

		public static string ucum_sfti { get { return GetResourceString("ucum_sfti"); } }

		public static string ucum_sini { get { return GetResourceString("ucum_sini"); } }

		public static string ucum_smius { get { return GetResourceString("ucum_smius"); } }

		public static string ucum_srdus { get { return GetResourceString("ucum_srdus"); } }

		public static string ucum_sydi { get { return GetResourceString("ucum_sydi"); } }

		public static string ucum_twp { get { return GetResourceString("ucum_twp"); } }

		public static string ucum_ccid50 { get { return GetResourceString("ucum_ccid50"); } }

		public static string ucum_tcid50 { get { return GetResourceString("ucum_tcid50"); } }

		public static string ucum_toddu { get { return GetResourceString("ucum_toddu"); } }

		public static string ucum_dyeu { get { return GetResourceString("ucum_dyeu"); } }

		public static string ucum_smgyu { get { return GetResourceString("ucum_smgyu"); } }

		public static string ucum_aplu { get { return GetResourceString("ucum_aplu"); } }

		public static string ucum_gplu { get { return GetResourceString("ucum_gplu"); } }

		public static string ucum_mplu { get { return GetResourceString("ucum_mplu"); } }

		public static string ucum_bethu { get { return GetResourceString("ucum_bethu"); } }

		public static string ucum_bdsku { get { return GetResourceString("ucum_bdsku"); } }

		public static string ucum_kau { get { return GetResourceString("ucum_kau"); } }

		public static string ucum_tbu { get { return GetResourceString("ucum_tbu"); } }

		public static string ucum_lmb { get { return GetResourceString("ucum_lmb"); } }

		public static string ucum_kat { get { return GetResourceString("ucum_kat"); } }

		public static string ucum_u { get { return GetResourceString("ucum_u"); } }

		public static string ucum_fthi { get { return GetResourceString("ucum_fthi"); } }

		public static string ucum_rem { get { return GetResourceString("ucum_rem"); } }

		public static string ucum_sv { get { return GetResourceString("ucum_sv"); } }

		public static string ucum_buus { get { return GetResourceString("ucum_buus"); } }

		public static string ucum_dptus { get { return GetResourceString("ucum_dptus"); } }

		public static string ucum_dqtus { get { return GetResourceString("ucum_dqtus"); } }

		public static string ucum_galwi { get { return GetResourceString("ucum_galwi"); } }

		public static string ucum_pkus { get { return GetResourceString("ucum_pkus"); } }

		public static string ucum_p { get { return GetResourceString("ucum_p"); } }

		public static string ucum_f { get { return GetResourceString("ucum_f"); } }

		public static string ucum_c { get { return GetResourceString("ucum_c"); } }

		public static string ucum_e { get { return GetResourceString("ucum_e"); } }

		public static string ucum_mho { get { return GetResourceString("ucum_mho"); } }

		public static string ucum_s { get { return GetResourceString("ucum_s"); } }

		public static string ucum_a { get { return GetResourceString("ucum_a"); } }

		public static string ucum_bi { get { return GetResourceString("ucum_bi"); } }

		public static string ucum_eps0 { get { return GetResourceString("ucum_eps0"); } }

		public static string ucum_v { get { return GetResourceString("ucum_v"); } }

		public static string ucum_buv { get { return GetResourceString("ucum_buv"); } }

		public static string ucum_bmv { get { return GetResourceString("ucum_bmv"); } }

		public static string ucum_bv { get { return GetResourceString("ucum_bv"); } }

		public static string ucum_ohm { get { return GetResourceString("ucum_ohm"); } }

		public static string ucum_btu { get { return GetResourceString("ucum_btu"); } }

		public static string ucum_btu39 { get { return GetResourceString("ucum_btu39"); } }

		public static string ucum_btu59 { get { return GetResourceString("ucum_btu59"); } }

		public static string ucum_btu60 { get { return GetResourceString("ucum_btu60"); } }

		public static string ucum_cal { get { return GetResourceString("ucum_cal"); } }

		public static string ucum_cal15 { get { return GetResourceString("ucum_cal15"); } }

		public static string ucum_cal20 { get { return GetResourceString("ucum_cal20"); } }

		public static string ucum_ev { get { return GetResourceString("ucum_ev"); } }

		public static string ucum_erg { get { return GetResourceString("ucum_erg"); } }

		public static string ucum_btuit { get { return GetResourceString("ucum_btuit"); } }

		public static string ucum_calit { get { return GetResourceString("ucum_calit"); } }

		public static string ucum_j { get { return GetResourceString("ucum_j"); } }

		public static string ucum_btum { get { return GetResourceString("ucum_btum"); } }

		public static string ucum_calm { get { return GetResourceString("ucum_calm"); } }

		public static string ucum_cal_1 { get { return GetResourceString("ucum_cal_1"); } }

		public static string ucum_btuth { get { return GetResourceString("ucum_btuth"); } }

		public static string ucum_calth { get { return GetResourceString("ucum_calth"); } }

		public static string ucum_gy { get { return GetResourceString("ucum_gy"); } }

		public static string ucum_rad { get { return GetResourceString("ucum_rad"); } }

		public static string ucum_pru { get { return GetResourceString("ucum_pru"); } }

		public static string ucum_bblus { get { return GetResourceString("ucum_bblus"); } }

		public static string ucum_crdus { get { return GetResourceString("ucum_crdus"); } }

		public static string ucum_fdrus { get { return GetResourceString("ucum_fdrus"); } }

		public static string ucum_fozus { get { return GetResourceString("ucum_fozus"); } }

		public static string ucum_gilus { get { return GetResourceString("ucum_gilus"); } }

		public static string ucum_minus { get { return GetResourceString("ucum_minus"); } }

		public static string ucum_ptus { get { return GetResourceString("ucum_ptus"); } }

		public static string ucum_qtus { get { return GetResourceString("ucum_qtus"); } }

		public static string ucum_galus { get { return GetResourceString("ucum_galus"); } }

		public static string ucum_mx { get { return GetResourceString("ucum_mx"); } }

		public static string ucum_dyn { get { return GetResourceString("ucum_dyn"); } }

		public static string ucum_gf { get { return GetResourceString("ucum_gf"); } }

		public static string ucum_n { get { return GetResourceString("ucum_n"); } }

		public static string ucum_lbfav { get { return GetResourceString("ucum_lbfav"); } }

		public static string ucum_ppb { get { return GetResourceString("ucum_ppb"); } }

		public static string ucum_ppm { get { return GetResourceString("ucum_ppm"); } }

		public static string ucum_ppth { get { return GetResourceString("ucum_ppth"); } }

		public static string ucum_pptr { get { return GetResourceString("ucum_pptr"); } }

		public static string ucum_ { get { return GetResourceString("ucum_"); } }

		public static string ucum_hz { get { return GetResourceString("ucum_hz"); } }

		public static string ucum_ch { get { return GetResourceString("ucum_ch"); } }

		public static string ucum_hdi { get { return GetResourceString("ucum_hdi"); } }

		public static string ucum_hpc { get { return GetResourceString("ucum_hpc"); } }

		public static string ucum_hpx { get { return GetResourceString("ucum_hpx"); } }

		public static string ucum_lx { get { return GetResourceString("ucum_lx"); } }

		public static string ucum_ph_1 { get { return GetResourceString("ucum_ph_1"); } }

		public static string ucum_h_1 { get { return GetResourceString("ucum_h_1"); } }

		public static string ucum_r { get { return GetResourceString("ucum_r"); } }

		public static string ucum_st { get { return GetResourceString("ucum_st"); } }

		public static string ucum_ao { get { return GetResourceString("ucum_ao"); } }

		public static string ucum_au { get { return GetResourceString("ucum_au"); } }

		public static string ucum_cicero { get { return GetResourceString("ucum_cicero"); } }

		public static string ucum_didot { get { return GetResourceString("ucum_didot"); } }

		public static string ucum_fthus { get { return GetResourceString("ucum_fthus"); } }

		public static string ucum_fthbr { get { return GetResourceString("ucum_fthbr"); } }

		public static string ucum_fti { get { return GetResourceString("ucum_fti"); } }

		public static string ucum_ftus { get { return GetResourceString("ucum_ftus"); } }

		public static string ucum_ftbr { get { return GetResourceString("ucum_ftbr"); } }

		public static string ucum_furus { get { return GetResourceString("ucum_furus"); } }

		public static string ucum_chbr { get { return GetResourceString("ucum_chbr"); } }

		public static string ucum_chus { get { return GetResourceString("ucum_chus"); } }

		public static string ucum_ini { get { return GetResourceString("ucum_ini"); } }

		public static string ucum_inus { get { return GetResourceString("ucum_inus"); } }

		public static string ucum_inbr { get { return GetResourceString("ucum_inbr"); } }

		public static string ucum_ly { get { return GetResourceString("ucum_ly"); } }

		public static string ucum_ligne { get { return GetResourceString("ucum_ligne"); } }

		public static string ucum_lne { get { return GetResourceString("ucum_lne"); } }

		public static string ucum_lkus { get { return GetResourceString("ucum_lkus"); } }

		public static string ucum_lkbr { get { return GetResourceString("ucum_lkbr"); } }

		public static string ucum_rlkus { get { return GetResourceString("ucum_rlkus"); } }

		public static string ucum_m { get { return GetResourceString("ucum_m"); } }

		public static string ucum_mili { get { return GetResourceString("ucum_mili"); } }

		public static string ucum_milus { get { return GetResourceString("ucum_milus"); } }

		public static string ucum_mius { get { return GetResourceString("ucum_mius"); } }

		public static string ucum_mibr { get { return GetResourceString("ucum_mibr"); } }

		public static string ucum_nmii { get { return GetResourceString("ucum_nmii"); } }

		public static string ucum_nmibr { get { return GetResourceString("ucum_nmibr"); } }

		public static string ucum_pcbr { get { return GetResourceString("ucum_pcbr"); } }

		public static string ucum_pc { get { return GetResourceString("ucum_pc"); } }

		public static string ucum_pca { get { return GetResourceString("ucum_pca"); } }

		public static string ucum_pied { get { return GetResourceString("ucum_pied"); } }

		public static string ucum_pnt { get { return GetResourceString("ucum_pnt"); } }

		public static string ucum_pouce { get { return GetResourceString("ucum_pouce"); } }

		public static string ucum_pcapr { get { return GetResourceString("ucum_pcapr"); } }

		public static string ucum_pntpr { get { return GetResourceString("ucum_pntpr"); } }

		public static string ucum_rchus { get { return GetResourceString("ucum_rchus"); } }

		public static string ucum_rdus { get { return GetResourceString("ucum_rdus"); } }

		public static string ucum_rdbr { get { return GetResourceString("ucum_rdbr"); } }

		public static string ucum_smoot { get { return GetResourceString("ucum_smoot"); } }

		public static string ucum_mii { get { return GetResourceString("ucum_mii"); } }

		public static string ucum_ydi { get { return GetResourceString("ucum_ydi"); } }

		public static string ucum_ydus { get { return GetResourceString("ucum_ydus"); } }

		public static string ucum_ydbr { get { return GetResourceString("ucum_ydbr"); } }

		public static string ucum_b_1 { get { return GetResourceString("ucum_b_1"); } }

		public static string ucum_np { get { return GetResourceString("ucum_np"); } }

		public static string ucum_ky { get { return GetResourceString("ucum_ky"); } }

		public static string ucum_meshi { get { return GetResourceString("ucum_meshi"); } }

		public static string ucum_sb { get { return GetResourceString("ucum_sb"); } }

		public static string ucum_lm { get { return GetResourceString("ucum_lm"); } }

		public static string ucum_cd { get { return GetResourceString("ucum_cd"); } }

		public static string ucum_wb { get { return GetResourceString("ucum_wb"); } }

		public static string ucum_oe { get { return GetResourceString("ucum_oe"); } }

		public static string ucum_g_2 { get { return GetResourceString("ucum_g_2"); } }

		public static string ucum_t { get { return GetResourceString("ucum_t"); } }

		public static string ucum_mu0 { get { return GetResourceString("ucum_mu0"); } }

		public static string ucum_gb { get { return GetResourceString("ucum_gb"); } }

		public static string ucum_drav { get { return GetResourceString("ucum_drav"); } }

		public static string ucum_drap { get { return GetResourceString("ucum_drap"); } }

		public static string ucum_me { get { return GetResourceString("ucum_me"); } }

		public static string ucum_gr { get { return GetResourceString("ucum_gr"); } }

		public static string ucum_g_3 { get { return GetResourceString("ucum_g_3"); } }

		public static string ucum_lcwtav { get { return GetResourceString("ucum_lcwtav"); } }

		public static string ucum_ltonav { get { return GetResourceString("ucum_ltonav"); } }

		public static string ucum_carm { get { return GetResourceString("ucum_carm"); } }

		public static string ucum_ozav { get { return GetResourceString("ucum_ozav"); } }

		public static string ucum_oztr { get { return GetResourceString("ucum_oztr"); } }

		public static string ucum_ozap { get { return GetResourceString("ucum_ozap"); } }

		public static string ucum_pwttr { get { return GetResourceString("ucum_pwttr"); } }

		public static string ucum_lbav { get { return GetResourceString("ucum_lbav"); } }

		public static string ucum_lbtr { get { return GetResourceString("ucum_lbtr"); } }

		public static string ucum_lbap { get { return GetResourceString("ucum_lbap"); } }

		public static string ucum_mp { get { return GetResourceString("ucum_mp"); } }

		public static string ucum_scap { get { return GetResourceString("ucum_scap"); } }

		public static string ucum_scwtav { get { return GetResourceString("ucum_scwtav"); } }

		public static string ucum_stonav { get { return GetResourceString("ucum_stonav"); } }

		public static string ucum_stoneav { get { return GetResourceString("ucum_stoneav"); } }

		public static string ucum_t_1 { get { return GetResourceString("ucum_t_1"); } }

		public static string ucum_u_1 { get { return GetResourceString("ucum_u_1"); } }

		public static string ucum_g_4 { get { return GetResourceString("ucum_g_4"); } }

		public static string ucum_carau { get { return GetResourceString("ucum_carau"); } }

		public static string ucum_met { get { return GetResourceString("ucum_met"); } }

		public static string ucum_pi { get { return GetResourceString("ucum_pi"); } }

		public static string ucum_10 { get { return GetResourceString("ucum_10"); } }

		public static string ucum_10_1 { get { return GetResourceString("ucum_10_1"); } }

		public static string ucum_circ { get { return GetResourceString("ucum_circ"); } }

		public static string ucum_deg { get { return GetResourceString("ucum_deg"); } }

		public static string ucum_gon { get { return GetResourceString("ucum_gon"); } }

		public static string ucum__1 { get { return GetResourceString("ucum__1"); } }

		public static string ucum_rad_1 { get { return GetResourceString("ucum_rad_1"); } }

		public static string ucum__2 { get { return GetResourceString("ucum__2"); } }

		public static string ucum_hp { get { return GetResourceString("ucum_hp"); } }

		public static string ucum_w { get { return GetResourceString("ucum_w"); } }

		public static string ucum_bkw { get { return GetResourceString("ucum_bkw"); } }

		public static string ucum_bw { get { return GetResourceString("ucum_bw"); } }

		public static string ucum_bar { get { return GetResourceString("ucum_bar"); } }

		public static string ucum_inihg { get { return GetResourceString("ucum_inihg"); } }

		public static string ucum_inih2o { get { return GetResourceString("ucum_inih2o"); } }

		public static string ucum_mhg { get { return GetResourceString("ucum_mhg"); } }

		public static string ucum_mh2o { get { return GetResourceString("ucum_mh2o"); } }

		public static string ucum_pa { get { return GetResourceString("ucum_pa"); } }

		public static string ucum_psi { get { return GetResourceString("ucum_psi"); } }

		public static string ucum_atm { get { return GetResourceString("ucum_atm"); } }

		public static string ucum_att { get { return GetResourceString("ucum_att"); } }

		public static string ucum_bspl { get { return GetResourceString("ucum_bspl"); } }

		public static string ucum_bq { get { return GetResourceString("ucum_bq"); } }

		public static string ucum_ci { get { return GetResourceString("ucum_ci"); } }

		public static string ucum_diop { get { return GetResourceString("ucum_diop"); } }

		public static string ucum_pdiop { get { return GetResourceString("ucum_pdiop"); } }

		public static string ucum_s_1 { get { return GetResourceString("ucum_s_1"); } }

		public static string ucum_bd { get { return GetResourceString("ucum_bd"); } }

		public static string ucum_slope { get { return GetResourceString("ucum_slope"); } }

		public static string ucum_sph { get { return GetResourceString("ucum_sph"); } }

		public static string ucum_sr { get { return GetResourceString("ucum_sr"); } }

		public static string ucum_cel { get { return GetResourceString("ucum_cel"); } }

		public static string ucum_degf { get { return GetResourceString("ucum_degf"); } }

		public static string ucum_k_1 { get { return GetResourceString("ucum_k_1"); } }

		public static string ucum_d { get { return GetResourceString("ucum_d"); } }

		public static string ucum_h_2 { get { return GetResourceString("ucum_h_2"); } }

		public static string ucum_mog { get { return GetResourceString("ucum_mog"); } }

		public static string ucum_ag { get { return GetResourceString("ucum_ag"); } }

		public static string ucum_moj { get { return GetResourceString("ucum_moj"); } }

		public static string ucum_aj { get { return GetResourceString("ucum_aj"); } }

		public static string ucum_min { get { return GetResourceString("ucum_min"); } }

		public static string ucum_mo { get { return GetResourceString("ucum_mo"); } }

		public static string ucum_s_2 { get { return GetResourceString("ucum_s_2"); } }

		public static string ucum_mos { get { return GetResourceString("ucum_mos"); } }

		public static string ucum_at { get { return GetResourceString("ucum_at"); } }

		public static string ucum_wk { get { return GetResourceString("ucum_wk"); } }

		public static string ucum_a_1 { get { return GetResourceString("ucum_a_1"); } }

		public static string ucum_kni { get { return GetResourceString("ucum_kni"); } }

		public static string ucum_knbr { get { return GetResourceString("ucum_knbr"); } }

		public static string ucum_c_1 { get { return GetResourceString("ucum_c_1"); } }

		public static string ucum_hpf { get { return GetResourceString("ucum_hpf"); } }

		public static string ucum_lpf { get { return GetResourceString("ucum_lpf"); } }

		public static string ucum_bfi { get { return GetResourceString("ucum_bfi"); } }

		public static string ucum_bubr { get { return GetResourceString("ucum_bubr"); } }

		public static string ucum_cri { get { return GetResourceString("ucum_cri"); } }

		public static string ucum_cfti { get { return GetResourceString("ucum_cfti"); } }

		public static string ucum_cini { get { return GetResourceString("ucum_cini"); } }

		public static string ucum_cydi { get { return GetResourceString("ucum_cydi"); } }

		public static string ucum_cupus { get { return GetResourceString("ucum_cupus"); } }

		public static string ucum_drp { get { return GetResourceString("ucum_drp"); } }

		public static string ucum_fdrbr { get { return GetResourceString("ucum_fdrbr"); } }

		public static string ucum_fozbr { get { return GetResourceString("ucum_fozbr"); } }

		public static string ucum_galbr { get { return GetResourceString("ucum_galbr"); } }

		public static string ucum_gilbr { get { return GetResourceString("ucum_gilbr"); } }

		public static string ucum_l { get { return GetResourceString("ucum_l"); } }

		public static string ucum_l_1 { get { return GetResourceString("ucum_l_1"); } }

		public static string ucum_minbr { get { return GetResourceString("ucum_minbr"); } }

		public static string ucum_pkbr { get { return GetResourceString("ucum_pkbr"); } }

		public static string ucum_ptbr { get { return GetResourceString("ucum_ptbr"); } }

		public static string ucum_qtbr { get { return GetResourceString("ucum_qtbr"); } }

		public static string ucum_st_1 { get { return GetResourceString("ucum_st_1"); } }

		public static string ucum_tbsus { get { return GetResourceString("ucum_tbsus"); } }

		public static string ucum_tspus { get { return GetResourceString("ucum_tspus"); } }

		public static string ucum_hnsfu { get { return GetResourceString("ucum_hnsfu"); } }

		public static string CODE_SV_CouplingType_Loose { get { return GetResourceString("CODE_SV_CouplingType_Loose"); } }

		public static string CODE_SV_CouplingType_Mixed { get { return GetResourceString("CODE_SV_CouplingType_Mixed"); } }

		public static string CODE_SV_CouplingType_Tight { get { return GetResourceString("CODE_SV_CouplingType_Tight"); } }

		public static string idNoCodeSamplesForTool { get { return GetResourceString("idNoCodeSamplesForTool"); } }

		public static string idNoExplanationForToolParam { get { return GetResourceString("idNoExplanationForToolParam"); } }

		public static string idNoParametersForTool { get { return GetResourceString("idNoParametersForTool"); } }

		public static string idNoUsageForTool { get { return GetResourceString("idNoUsageForTool"); } }

		public static string idToolCodeSampleNoDescription { get { return GetResourceString("idToolCodeSampleNoDescription"); } }

		public static string idToolCodeSampleNoTitle { get { return GetResourceString("idToolCodeSampleNoTitle"); } }

		public static string idToolNoCommandRefForParam { get { return GetResourceString("idToolNoCommandRefForParam"); } }

		public static string idToolNoDialogRefForParam { get { return GetResourceString("idToolNoDialogRefForParam"); } }

		public static string idToolNoPythonRefForParam { get { return GetResourceString("idToolNoPythonRefForParam"); } }

		public static string idToolParamCommandReference { get { return GetResourceString("idToolParamCommandReference"); } }

		public static string idToolParamDialogReference { get { return GetResourceString("idToolParamDialogReference"); } }

		public static string idToolParamPythonReference { get { return GetResourceString("idToolParamPythonReference"); } }

		public static string gmlCatalogSymbol { get { return GetResourceString("gmlCatalogSymbol"); } }

		public static string gmlCatalogSymbol_codespace { get { return GetResourceString("gmlCatalogSymbol_codespace"); } }

		public static string gmlDesc2 { get { return GetResourceString("gmlDesc2"); } }

		public static string gmlID2 { get { return GetResourceString("gmlID2"); } }

		public static string gmlIdent2 { get { return GetResourceString("gmlIdent2"); } }

		public static string gmlIdent2_codespace { get { return GetResourceString("gmlIdent2_codespace"); } }

		public static string gmlName2 { get { return GetResourceString("gmlName2"); } }

		public static string gmlName2_codespace { get { return GetResourceString("gmlName2_codespace"); } }

		public static string gmlPos { get { return GetResourceString("gmlPos"); } }

		public static string gmlQuantityType { get { return GetResourceString("gmlQuantityType"); } }

		public static string gmlRemarks2 { get { return GetResourceString("gmlRemarks2"); } }

		public static string idLevelDescription { get { return GetResourceString("idLevelDescription"); } }

		public static string IDSvcIdInfo2 { get { return GetResourceString("IDSvcIdInfo2"); } }

		public static string IDSvcIdInfoRes { get { return GetResourceString("IDSvcIdInfoRes"); } }

		public static string idUpdateScopeDescription { get { return GetResourceString("idUpdateScopeDescription"); } }

		public static string srcAttribute { get { return GetResourceString("srcAttribute"); } }

		public static string CODE_CI_OnLineFunctionCode_NAP_006 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_NAP_006"); } }

		public static string CODE_CI_OnLineFunctionCode_NAP_007 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_NAP_007"); } }

		public static string CODE_CI_OnLineFunctionCode_NAP_008 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_NAP_008"); } }

		public static string CODE_CI_OnLineFunctionCode_NAP_009 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_NAP_009"); } }

		public static string CODE_CI_OnLineFunctionCode_NAP_010 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_NAP_010"); } }

		public static string CODE_CI_OnLineFunctionCode_NAP_011 { get { return GetResourceString("CODE_CI_OnLineFunctionCode_NAP_011"); } }

		public static string CODE_CI_PresentationCode_NAP_015 { get { return GetResourceString("CODE_CI_PresentationCode_NAP_015"); } }

		public static string CODE_CI_PresentationCode_NAP_016 { get { return GetResourceString("CODE_CI_PresentationCode_NAP_016"); } }

		public static string CODE_CI_PresentationCode_NAP_017 { get { return GetResourceString("CODE_CI_PresentationCode_NAP_017"); } }

		public static string CODE_CI_PresentationCode_NAP_018 { get { return GetResourceString("CODE_CI_PresentationCode_NAP_018"); } }

		public static string CODE_CI_PresentationCode_NAP_019 { get { return GetResourceString("CODE_CI_PresentationCode_NAP_019"); } }

		public static string CODE_CI_PresentationCode_NAP_020 { get { return GetResourceString("CODE_CI_PresentationCode_NAP_020"); } }

		public static string CODE_CI_RoleCode_NAP_012 { get { return GetResourceString("CODE_CI_RoleCode_NAP_012"); } }

		public static string CODE_CI_RoleCode_NAP_013 { get { return GetResourceString("CODE_CI_RoleCode_NAP_013"); } }

		public static string CODE_CI_RoleCode_NAP_014 { get { return GetResourceString("CODE_CI_RoleCode_NAP_014"); } }

		public static string CODE_CI_RoleCode_NAP_015 { get { return GetResourceString("CODE_CI_RoleCode_NAP_015"); } }

		public static string CODE_MD_CellGeometryCode_NAP_003 { get { return GetResourceString("CODE_MD_CellGeometryCode_NAP_003"); } }

		public static string CODE_MD_ClassificationCode_NAP_006 { get { return GetResourceString("CODE_MD_ClassificationCode_NAP_006"); } }

		public static string CODE_MD_ClassificationCode_NAP_007 { get { return GetResourceString("CODE_MD_ClassificationCode_NAP_007"); } }

		public static string CODE_MD_MaintenanceFrequenceCode_NAP_013 { get { return GetResourceString("CODE_MD_MaintenanceFrequenceCode_NAP_013"); } }

		public static string CODE_MD_MediumNameCode_NAP_019 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_019"); } }

		public static string CODE_MD_MediumNameCode_NAP_020 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_020"); } }

		public static string CODE_MD_MediumNameCode_NAP_021 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_021"); } }

		public static string CODE_MD_MediumNameCode_NAP_022 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_022"); } }

		public static string CODE_MD_MediumNameCode_NAP_023 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_023"); } }

		public static string CODE_MD_MediumNameCode_NAP_024 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_024"); } }

		public static string CODE_MD_MediumNameCode_NAP_025 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_025"); } }

		public static string CODE_MD_MediumNameCode_NAP_026 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_026"); } }

		public static string CODE_MD_MediumNameCode_NAP_027 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_027"); } }

		public static string CODE_MD_MediumNameCode_NAP_028 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_028"); } }

		public static string CODE_MD_MediumNameCode_NAP_029 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_029"); } }

		public static string CODE_MD_MediumNameCode_NAP_030 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_030"); } }

		public static string CODE_MD_MediumNameCode_NAP_031 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_031"); } }

		public static string CODE_MD_MediumNameCode_NAP_032 { get { return GetResourceString("CODE_MD_MediumNameCode_NAP_032"); } }

		public static string CODE_MD_ProgressCode_NAP_008 { get { return GetResourceString("CODE_MD_ProgressCode_NAP_008"); } }

		public static string CODE_MD_RestrictionCode_NAP_009 { get { return GetResourceString("CODE_MD_RestrictionCode_NAP_009"); } }

		public static string CODE_MD_RestrictionCode_NAP_010 { get { return GetResourceString("CODE_MD_RestrictionCode_NAP_010"); } }

		public static string CODE_MD_RestrictionCode_NAP_011 { get { return GetResourceString("CODE_MD_RestrictionCode_NAP_011"); } }

		public static string CODE_MD_RestrictionCode_NAP_012 { get { return GetResourceString("CODE_MD_RestrictionCode_NAP_012"); } }

		public static string CODE_MD_RestrictionCode_NAP_013 { get { return GetResourceString("CODE_MD_RestrictionCode_NAP_013"); } }

		public static string CODE_MD_RestrictionCode_NAP_014 { get { return GetResourceString("CODE_MD_RestrictionCode_NAP_014"); } }

		public static string CODE_MD_RestrictionCode_NAP_015 { get { return GetResourceString("CODE_MD_RestrictionCode_NAP_015"); } }

		public static string asGraFileSrc { get { return GetResourceString("asGraFileSrc"); } }

		public static string asSwDevFileSrc { get { return GetResourceString("asSwDevFileSrc"); } }

		public static string idBrowsing { get { return GetResourceString("idBrowsing"); } }

		public static string idCollaborator { get { return GetResourceString("idCollaborator"); } }

		public static string idConfidential { get { return GetResourceString("idConfidential"); } }

		public static string idConfigKeyword { get { return GetResourceString("idConfigKeyword"); } }

		public static string idDigitalAudio { get { return GetResourceString("idDigitalAudio"); } }

		public static string idDigitalDiagram { get { return GetResourceString("idDigitalDiagram"); } }

		public static string idDigitalMultiMed { get { return GetResourceString("idDigitalMultiMed"); } }

		public static string idEditor { get { return GetResourceString("idEditor"); } }

		public static string idEmailService { get { return GetResourceString("idEmailService"); } }

		public static string idFileAccess { get { return GetResourceString("idFileAccess"); } }

		public static string idForOfficialUseOnly { get { return GetResourceString("idForOfficialUseOnly"); } }

		public static string idHardcopyAudio { get { return GetResourceString("idHardcopyAudio"); } }

		public static string idHardcopyCardMicrofilm { get { return GetResourceString("idHardcopyCardMicrofilm"); } }

		public static string idHardcopyDiagram { get { return GetResourceString("idHardcopyDiagram"); } }

		public static string idHardcopyDiazo { get { return GetResourceString("idHardcopyDiazo"); } }

		public static string idHardcopyDiazoPolyester08 { get { return GetResourceString("idHardcopyDiazoPolyester08"); } }

		public static string idHardcopyMicrofilm240 { get { return GetResourceString("idHardcopyMicrofilm240"); } }

		public static string idHardcopyMicrofilm35 { get { return GetResourceString("idHardcopyMicrofilm35"); } }

		public static string idHardcopyMicrofilm70 { get { return GetResourceString("idHardcopyMicrofilm70"); } }

		public static string idHardcopyMicrofilmGeneral { get { return GetResourceString("idHardcopyMicrofilmGeneral"); } }

		public static string idHardcopyMicrofilmMicrofiche { get { return GetResourceString("idHardcopyMicrofilmMicrofiche"); } }

		public static string idHardcopyMultiMed { get { return GetResourceString("idHardcopyMultiMed"); } }

		public static string idHardcopyNegativePhoto { get { return GetResourceString("idHardcopyNegativePhoto"); } }

		public static string idHardcopyPaper { get { return GetResourceString("idHardcopyPaper"); } }

		public static string idHardcopyPhoto { get { return GetResourceString("idHardcopyPhoto"); } }

		public static string idHardcopyTracedPaper { get { return GetResourceString("idHardcopyTracedPaper"); } }

		public static string idHardDisk { get { return GetResourceString("idHardDisk"); } }

		public static string idIsComposedOf { get { return GetResourceString("idIsComposedOf"); } }

		public static string idLicenseDistributor { get { return GetResourceString("idLicenseDistributor"); } }

		public static string idLicenseEndUser { get { return GetResourceString("idLicenseEndUser"); } }

		public static string idLicenseUnrestricted { get { return GetResourceString("idLicenseUnrestricted"); } }

		public static string idMediator { get { return GetResourceString("idMediator"); } }

		public static string idPrivacy { get { return GetResourceString("idPrivacy"); } }

		public static string idProposed { get { return GetResourceString("idProposed"); } }

		public static string idRightsHolder { get { return GetResourceString("idRightsHolder"); } }

		public static string idSemiMonthly { get { return GetResourceString("idSemiMonthly"); } }

		public static string idSensitive { get { return GetResourceString("idSensitive"); } }

		public static string idSensitivity { get { return GetResourceString("idSensitivity"); } }

		public static string idStatutory { get { return GetResourceString("idStatutory"); } }

		public static string idUDF { get { return GetResourceString("idUDF"); } }

		public static string idUpload { get { return GetResourceString("idUpload"); } }

		public static string idUSBFlashDrive { get { return GetResourceString("idUSBFlashDrive"); } }

		public static string idViewpointSpacingX { get { return GetResourceString("idViewpointSpacingX"); } }

		public static string idViewpointSpacingY { get { return GetResourceString("idViewpointSpacingY"); } }

		public static string idVoxel { get { return GetResourceString("idVoxel"); } }

		public static string idWebMapService { get { return GetResourceString("idWebMapService"); } }

		public static string idWebService { get { return GetResourceString("idWebService"); } }

		public static string productKeys { get { return GetResourceString("productKeys"); } }

		public static string subTopicCatKeys { get { return GetResourceString("subTopicCatKeys"); } }

		public static string idServiceAccessProperties { get { return GetResourceString("idServiceAccessProperties"); } }

		public static string idServiceCoupledResource { get { return GetResourceString("idServiceCoupledResource"); } }

		public static string idServiceCouplingType { get { return GetResourceString("idServiceCouplingType"); } }

		public static string idServiceDCPtype { get { return GetResourceString("idServiceDCPtype"); } }

		public static string idServiceOperation { get { return GetResourceString("idServiceOperation"); } }

		public static string idServiceOperationDescription { get { return GetResourceString("idServiceOperationDescription"); } }

		public static string idServiceOperationInvocationName { get { return GetResourceString("idServiceOperationInvocationName"); } }

		public static string idServiceOperationName { get { return GetResourceString("idServiceOperationName"); } }

		public static string idServiceParameter { get { return GetResourceString("idServiceParameter"); } }

		public static string idServiceParameterDescription { get { return GetResourceString("idServiceParameterDescription"); } }

		public static string idServiceParameterDirection { get { return GetResourceString("idServiceParameterDirection"); } }

		public static string idServiceParameterName { get { return GetResourceString("idServiceParameterName"); } }

		public static string idServiceParameterOptionality { get { return GetResourceString("idServiceParameterOptionality"); } }

		public static string idServiceParameterRepeatability { get { return GetResourceString("idServiceParameterRepeatability"); } }

		public static string idServiceParameterValueType { get { return GetResourceString("idServiceParameterValueType"); } }

		public static string idServiceResourceIdentifier { get { return GetResourceString("idServiceResourceIdentifier"); } }

		public static string idServiceType { get { return GetResourceString("idServiceType"); } }

		public static string idServiceTypeVersion { get { return GetResourceString("idServiceTypeVersion"); } }

		public static string idServiceType_codespace { get { return GetResourceString("idServiceType_codespace"); } }

		public static string CODE_DS_AssociationTypeCode_001 { get { return GetResourceString("CODE_DS_AssociationTypeCode_001"); } }

		public static string CODE_DS_AssociationTypeCode_002 { get { return GetResourceString("CODE_DS_AssociationTypeCode_002"); } }

		public static string CODE_DS_AssociationTypeCode_003 { get { return GetResourceString("CODE_DS_AssociationTypeCode_003"); } }

		public static string CODE_DS_AssociationTypeCode_004 { get { return GetResourceString("CODE_DS_AssociationTypeCode_004"); } }

		public static string CODE_DS_AssociationTypeCode_005 { get { return GetResourceString("CODE_DS_AssociationTypeCode_005"); } }

		public static string CODE_DS_AssociationTypeCode_006 { get { return GetResourceString("CODE_DS_AssociationTypeCode_006"); } }

		public static string CODE_DS_InitiativeTypeCode_001 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_001"); } }

		public static string CODE_DS_InitiativeTypeCode_002 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_002"); } }

		public static string CODE_DS_InitiativeTypeCode_003 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_003"); } }

		public static string CODE_DS_InitiativeTypeCode_004 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_004"); } }

		public static string CODE_DS_InitiativeTypeCode_005 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_005"); } }

		public static string CODE_DS_InitiativeTypeCode_006 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_006"); } }

		public static string CODE_DS_InitiativeTypeCode_007 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_007"); } }

		public static string CODE_DS_InitiativeTypeCode_008 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_008"); } }

		public static string CODE_DS_InitiativeTypeCode_009 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_009"); } }

		public static string CODE_DS_InitiativeTypeCode_010 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_010"); } }

		public static string CODE_DS_InitiativeTypeCode_011 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_011"); } }

		public static string CODE_DS_InitiativeTypeCode_012 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_012"); } }

		public static string CODE_DS_InitiativeTypeCode_013 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_013"); } }

		public static string CODE_DS_InitiativeTypeCode_014 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_014"); } }

		public static string CODE_DS_InitiativeTypeCode_015 { get { return GetResourceString("CODE_DS_InitiativeTypeCode_015"); } }

		public static string idCountryName_BES { get { return GetResourceString("idCountryName_BES"); } }

		public static string idCountryName_CUW { get { return GetResourceString("idCountryName_CUW"); } }

		public static string idCountryName_SXM { get { return GetResourceString("idCountryName_SXM"); } }

		public static string idExtentEast_ItemDescription { get { return GetResourceString("idExtentEast_ItemDescription"); } }

		public static string idExtentNorth_ItemDescription { get { return GetResourceString("idExtentNorth_ItemDescription"); } }

		public static string idExtentSouth_ItemDescription { get { return GetResourceString("idExtentSouth_ItemDescription"); } }

		public static string idExtentWest_ItemDescription { get { return GetResourceString("idExtentWest_ItemDescription"); } }

		public static string idExtent_ItemDescription { get { return GetResourceString("idExtent_ItemDescription"); } }

		public static string idNoExtentForItem { get { return GetResourceString("idNoExtentForItem"); } }

		public static string idNoScaleRangeForItem { get { return GetResourceString("idNoScaleRangeForItem"); } }

		public static string idScaleRangeMax_ItemDescription { get { return GetResourceString("idScaleRangeMax_ItemDescription"); } }

		public static string idScaleRangeMin_ItemDescription { get { return GetResourceString("idScaleRangeMin_ItemDescription"); } }

		public static string idScaleRange_ItemDescription { get { return GetResourceString("idScaleRange_ItemDescription"); } }

		public static string idTopArcGISTooltip { get { return GetResourceString("idTopArcGISTooltip"); } }

		public static string idTopFGDCTooltip { get { return GetResourceString("idTopFGDCTooltip"); } }

		public static string idAggregateIdentifier { get { return GetResourceString("idAggregateIdentifier"); } }

		public static string idAggregateInfo { get { return GetResourceString("idAggregateInfo"); } }

		public static string idAggregateName { get { return GetResourceString("idAggregateName"); } }

		public static string idAssociationType { get { return GetResourceString("idAssociationType"); } }

		public static string idInitiativeType { get { return GetResourceString("idInitiativeType"); } }

		public static string itemLocationLinkage { get { return GetResourceString("itemLocationLinkage"); } }

		public static string itemLocationProtocol { get { return GetResourceString("itemLocationProtocol"); } }

		public static string Base64 { get { return GetResourceString("Base64"); } }

		public static string detailed { get { return GetResourceString("detailed"); } }

		public static string enttypt { get { return GetResourceString("enttypt"); } }

		public static string subtypeNoDefaultValue { get { return GetResourceString("subtypeNoDefaultValue"); } }

		public static string ThumbnailType { get { return GetResourceString("ThumbnailType"); } }

		public static string addressType { get { return GetResourceString("addressType"); } }

		public static string CitationContacts { get { return GetResourceString("CitationContacts"); } }

		public static string Indref { get { return GetResourceString("Indref"); } }

		public static string planAvTmPd { get { return GetResourceString("planAvTmPd"); } }

		public static string tddttyNum { get { return GetResourceString("tddttyNum"); } }

		public static string TopicsAndKeywords { get { return GetResourceString("TopicsAndKeywords"); } }

		public static string units { get { return GetResourceString("units"); } }

		public static string CODE_AddressType_Both { get { return GetResourceString("CODE_AddressType_Both"); } }

		public static string CODE_AddressType_Physical { get { return GetResourceString("CODE_AddressType_Physical"); } }

		public static string CODE_AddressType_Postal { get { return GetResourceString("CODE_AddressType_Postal"); } }

		public static string CODE_Presentation_Atlas { get { return GetResourceString("CODE_Presentation_Atlas"); } }

		public static string CODE_Presentation_Audio { get { return GetResourceString("CODE_Presentation_Audio"); } }

		public static string CODE_Presentation_Diagram { get { return GetResourceString("CODE_Presentation_Diagram"); } }

		public static string CODE_Presentation_Document { get { return GetResourceString("CODE_Presentation_Document"); } }

		public static string CODE_Presentation_Globe { get { return GetResourceString("CODE_Presentation_Globe"); } }

		public static string CODE_Presentation_Map { get { return GetResourceString("CODE_Presentation_Map"); } }

		public static string CODE_Presentation_Model { get { return GetResourceString("CODE_Presentation_Model"); } }

		public static string CODE_Presentation_Multimedia_Presentation { get { return GetResourceString("CODE_Presentation_Multimedia_Presentation"); } }

		public static string CODE_Presentation_Profile { get { return GetResourceString("CODE_Presentation_Profile"); } }

		public static string CODE_Presentation_Raster_Digital_Data { get { return GetResourceString("CODE_Presentation_Raster_Digital_Data"); } }

		public static string CODE_Presentation_Remote_Sensing_Image { get { return GetResourceString("CODE_Presentation_Remote_Sensing_Image"); } }

		public static string CODE_Presentation_Section { get { return GetResourceString("CODE_Presentation_Section"); } }

		public static string CODE_Presentation_Spreadsheet { get { return GetResourceString("CODE_Presentation_Spreadsheet"); } }

		public static string CODE_Presentation_Tabular_Digital_Data { get { return GetResourceString("CODE_Presentation_Tabular_Digital_Data"); } }

		public static string CODE_Presentation_Vector_Digital_Data { get { return GetResourceString("CODE_Presentation_Vector_Digital_Data"); } }

		public static string CODE_Presentation_Video { get { return GetResourceString("CODE_Presentation_Video"); } }

		public static string CODE_Presentation_View { get { return GetResourceString("CODE_Presentation_View"); } }

		public static string CODE_MON_Afghani { get { return GetResourceString("CODE_MON_Afghani"); } }

		public static string CODE_MON_Euro { get { return GetResourceString("CODE_MON_Euro"); } }

		public static string CODE_MON_Lek { get { return GetResourceString("CODE_MON_Lek"); } }

		public static string CODE_MON_Algerian_Dinar { get { return GetResourceString("CODE_MON_Algerian_Dinar"); } }

		public static string CODE_MON_US_Dollar { get { return GetResourceString("CODE_MON_US_Dollar"); } }

		public static string CODE_MON_Kwanza { get { return GetResourceString("CODE_MON_Kwanza"); } }

		public static string CODE_MON_East_Caribbean_Dollar { get { return GetResourceString("CODE_MON_East_Caribbean_Dollar"); } }

		public static string CODE_MON_No_universal_currency { get { return GetResourceString("CODE_MON_No_universal_currency"); } }

		public static string CODE_MON_Argentine_Peso { get { return GetResourceString("CODE_MON_Argentine_Peso"); } }

		public static string CODE_MON_Armenian_Dram { get { return GetResourceString("CODE_MON_Armenian_Dram"); } }

		public static string CODE_MON_Aruban_Guilder { get { return GetResourceString("CODE_MON_Aruban_Guilder"); } }

		public static string CODE_MON_Australian_Dollar { get { return GetResourceString("CODE_MON_Australian_Dollar"); } }

		public static string CODE_MON_Azerbaijanian_Manat { get { return GetResourceString("CODE_MON_Azerbaijanian_Manat"); } }

		public static string CODE_MON_Bahamian_Dollar { get { return GetResourceString("CODE_MON_Bahamian_Dollar"); } }

		public static string CODE_MON_Bahraini_Dinar { get { return GetResourceString("CODE_MON_Bahraini_Dinar"); } }

		public static string CODE_MON_Taka { get { return GetResourceString("CODE_MON_Taka"); } }

		public static string CODE_MON_Barbados_Dollar { get { return GetResourceString("CODE_MON_Barbados_Dollar"); } }

		public static string CODE_MON_Belarussian_Ruble { get { return GetResourceString("CODE_MON_Belarussian_Ruble"); } }

		public static string CODE_MON_Belize_Dollar { get { return GetResourceString("CODE_MON_Belize_Dollar"); } }

		public static string CODE_MON_CFA_Franc_BCEAO { get { return GetResourceString("CODE_MON_CFA_Franc_BCEAO"); } }

		public static string CODE_MON_Bermudian_Dollar { get { return GetResourceString("CODE_MON_Bermudian_Dollar"); } }

		public static string CODE_MON_Indian_Rupee { get { return GetResourceString("CODE_MON_Indian_Rupee"); } }

		public static string CODE_MON_Ngultrum { get { return GetResourceString("CODE_MON_Ngultrum"); } }

		public static string CODE_MON_Boliviano { get { return GetResourceString("CODE_MON_Boliviano"); } }

		public static string CODE_MON_Mvdol { get { return GetResourceString("CODE_MON_Mvdol"); } }

		public static string CODE_MON_Convertible_Mark { get { return GetResourceString("CODE_MON_Convertible_Mark"); } }

		public static string CODE_MON_Pula { get { return GetResourceString("CODE_MON_Pula"); } }

		public static string CODE_MON_Norwegian_Krone { get { return GetResourceString("CODE_MON_Norwegian_Krone"); } }

		public static string CODE_MON_Brazilian_Real { get { return GetResourceString("CODE_MON_Brazilian_Real"); } }

		public static string CODE_MON_Brunei_Dollar { get { return GetResourceString("CODE_MON_Brunei_Dollar"); } }

		public static string CODE_MON_Bulgarian_Lev { get { return GetResourceString("CODE_MON_Bulgarian_Lev"); } }

		public static string CODE_MON_Burundi_Franc { get { return GetResourceString("CODE_MON_Burundi_Franc"); } }

		public static string CODE_MON_Riel { get { return GetResourceString("CODE_MON_Riel"); } }

		public static string CODE_MON_CFA_Franc_BEAC { get { return GetResourceString("CODE_MON_CFA_Franc_BEAC"); } }

		public static string CODE_MON_Canadian_Dollar { get { return GetResourceString("CODE_MON_Canadian_Dollar"); } }

		public static string CODE_MON_Cape_Verde_Escudo { get { return GetResourceString("CODE_MON_Cape_Verde_Escudo"); } }

		public static string CODE_MON_Cayman_Islands_Dollar { get { return GetResourceString("CODE_MON_Cayman_Islands_Dollar"); } }

		public static string CODE_MON_Chilean_Peso { get { return GetResourceString("CODE_MON_Chilean_Peso"); } }

		public static string CODE_MON_Unidades_de_fomento { get { return GetResourceString("CODE_MON_Unidades_de_fomento"); } }

		public static string CODE_MON_Yuan_Renminbi { get { return GetResourceString("CODE_MON_Yuan_Renminbi"); } }

		public static string CODE_MON_Colombian_Peso { get { return GetResourceString("CODE_MON_Colombian_Peso"); } }

		public static string CODE_MON_Unidad_de_Valor_Real { get { return GetResourceString("CODE_MON_Unidad_de_Valor_Real"); } }

		public static string CODE_MON_Comoro_Franc { get { return GetResourceString("CODE_MON_Comoro_Franc"); } }

		public static string CODE_MON_Congolese_Franc { get { return GetResourceString("CODE_MON_Congolese_Franc"); } }

		public static string CODE_MON_New_Zealand_Dollar { get { return GetResourceString("CODE_MON_New_Zealand_Dollar"); } }

		public static string CODE_MON_Costa_Rican_Colon { get { return GetResourceString("CODE_MON_Costa_Rican_Colon"); } }

		public static string CODE_MON_Croatian_Kuna { get { return GetResourceString("CODE_MON_Croatian_Kuna"); } }

		public static string CODE_MON_Cuban_Peso { get { return GetResourceString("CODE_MON_Cuban_Peso"); } }

		public static string CODE_MON_Peso_Convertible { get { return GetResourceString("CODE_MON_Peso_Convertible"); } }

		public static string CODE_MON_Netherlands_Antillean_Guilder { get { return GetResourceString("CODE_MON_Netherlands_Antillean_Guilder"); } }

		public static string CODE_MON_Czech_Koruna { get { return GetResourceString("CODE_MON_Czech_Koruna"); } }

		public static string CODE_MON_Danish_Krone { get { return GetResourceString("CODE_MON_Danish_Krone"); } }

		public static string CODE_MON_Djibouti_Franc { get { return GetResourceString("CODE_MON_Djibouti_Franc"); } }

		public static string CODE_MON_Dominican_Peso { get { return GetResourceString("CODE_MON_Dominican_Peso"); } }

		public static string CODE_MON_Egyptian_Pound { get { return GetResourceString("CODE_MON_Egyptian_Pound"); } }

		public static string CODE_MON_El_Salvador_Colon { get { return GetResourceString("CODE_MON_El_Salvador_Colon"); } }

		public static string CODE_MON_Nakfa { get { return GetResourceString("CODE_MON_Nakfa"); } }

		public static string CODE_MON_Ethiopian_Birr { get { return GetResourceString("CODE_MON_Ethiopian_Birr"); } }

		public static string CODE_MON_Falkland_Islands_Pound { get { return GetResourceString("CODE_MON_Falkland_Islands_Pound"); } }

		public static string CODE_MON_Fiji_Dollar { get { return GetResourceString("CODE_MON_Fiji_Dollar"); } }

		public static string CODE_MON_CFP_Franc { get { return GetResourceString("CODE_MON_CFP_Franc"); } }

		public static string CODE_MON_Dalasi { get { return GetResourceString("CODE_MON_Dalasi"); } }

		public static string CODE_MON_Lari { get { return GetResourceString("CODE_MON_Lari"); } }

		public static string CODE_MON_Cedi { get { return GetResourceString("CODE_MON_Cedi"); } }

		public static string CODE_MON_Gibraltar_Pound { get { return GetResourceString("CODE_MON_Gibraltar_Pound"); } }

		public static string CODE_MON_Quetzal { get { return GetResourceString("CODE_MON_Quetzal"); } }

		public static string CODE_MON_Pound_Sterling { get { return GetResourceString("CODE_MON_Pound_Sterling"); } }

		public static string CODE_MON_Guinea_Franc { get { return GetResourceString("CODE_MON_Guinea_Franc"); } }

		public static string CODE_MON_Guyana_Dollar { get { return GetResourceString("CODE_MON_Guyana_Dollar"); } }

		public static string CODE_MON_Gourde { get { return GetResourceString("CODE_MON_Gourde"); } }

		public static string CODE_MON_Lempira { get { return GetResourceString("CODE_MON_Lempira"); } }

		public static string CODE_MON_Hong_Kong_Dollar { get { return GetResourceString("CODE_MON_Hong_Kong_Dollar"); } }

		public static string CODE_MON_Forint { get { return GetResourceString("CODE_MON_Forint"); } }

		public static string CODE_MON_Iceland_Krona { get { return GetResourceString("CODE_MON_Iceland_Krona"); } }

		public static string CODE_MON_Rupiah { get { return GetResourceString("CODE_MON_Rupiah"); } }

		public static string CODE_MON_SDR_Special_Drawing_Right { get { return GetResourceString("CODE_MON_SDR_Special_Drawing_Right"); } }

		public static string CODE_MON_Iranian_Rial { get { return GetResourceString("CODE_MON_Iranian_Rial"); } }

		public static string CODE_MON_Iraqi_Dinar { get { return GetResourceString("CODE_MON_Iraqi_Dinar"); } }

		public static string CODE_MON_New_Israeli_Sheqel { get { return GetResourceString("CODE_MON_New_Israeli_Sheqel"); } }

		public static string CODE_MON_Jamaican_Dollar { get { return GetResourceString("CODE_MON_Jamaican_Dollar"); } }

		public static string CODE_MON_Yen { get { return GetResourceString("CODE_MON_Yen"); } }

		public static string CODE_MON_Jordanian_Dinar { get { return GetResourceString("CODE_MON_Jordanian_Dinar"); } }

		public static string CODE_MON_Tenge { get { return GetResourceString("CODE_MON_Tenge"); } }

		public static string CODE_MON_Kenyan_Shilling { get { return GetResourceString("CODE_MON_Kenyan_Shilling"); } }

		public static string CODE_MON_North_Korean_Won { get { return GetResourceString("CODE_MON_North_Korean_Won"); } }

		public static string CODE_MON_Won { get { return GetResourceString("CODE_MON_Won"); } }

		public static string CODE_MON_Kuwaiti_Dinar { get { return GetResourceString("CODE_MON_Kuwaiti_Dinar"); } }

		public static string CODE_MON_Som { get { return GetResourceString("CODE_MON_Som"); } }

		public static string CODE_MON_Kip { get { return GetResourceString("CODE_MON_Kip"); } }

		public static string CODE_MON_Latvian_Lats { get { return GetResourceString("CODE_MON_Latvian_Lats"); } }

		public static string CODE_MON_Lebanese_Pound { get { return GetResourceString("CODE_MON_Lebanese_Pound"); } }

		public static string CODE_MON_Loti { get { return GetResourceString("CODE_MON_Loti"); } }

		public static string CODE_MON_Rand { get { return GetResourceString("CODE_MON_Rand"); } }

		public static string CODE_MON_Liberian_Dollar { get { return GetResourceString("CODE_MON_Liberian_Dollar"); } }

		public static string CODE_MON_Libyan_Dinar { get { return GetResourceString("CODE_MON_Libyan_Dinar"); } }

		public static string CODE_MON_Swiss_Franc { get { return GetResourceString("CODE_MON_Swiss_Franc"); } }

		public static string CODE_MON_Lithuanian_Litas { get { return GetResourceString("CODE_MON_Lithuanian_Litas"); } }

		public static string CODE_MON_Pataca { get { return GetResourceString("CODE_MON_Pataca"); } }

		public static string CODE_MON_Denar { get { return GetResourceString("CODE_MON_Denar"); } }

		public static string CODE_MON_Malagasy_Ariary { get { return GetResourceString("CODE_MON_Malagasy_Ariary"); } }

		public static string CODE_MON_Kwacha { get { return GetResourceString("CODE_MON_Kwacha"); } }

		public static string CODE_MON_Malaysian_Ringgit { get { return GetResourceString("CODE_MON_Malaysian_Ringgit"); } }

		public static string CODE_MON_Rufiyaa { get { return GetResourceString("CODE_MON_Rufiyaa"); } }

		public static string CODE_MON_Ouguiya { get { return GetResourceString("CODE_MON_Ouguiya"); } }

		public static string CODE_MON_Mauritius_Rupee { get { return GetResourceString("CODE_MON_Mauritius_Rupee"); } }

		public static string CODE_MON_ADB_Unit_of_Account { get { return GetResourceString("CODE_MON_ADB_Unit_of_Account"); } }

		public static string CODE_MON_Mexican_Peso { get { return GetResourceString("CODE_MON_Mexican_Peso"); } }

		public static string CODE_MON_Mexican_Unidad_de_Inversion_UDI { get { return GetResourceString("CODE_MON_Mexican_Unidad_de_Inversion_UDI"); } }

		public static string CODE_MON_Moldovan_Leu { get { return GetResourceString("CODE_MON_Moldovan_Leu"); } }

		public static string CODE_MON_Tugrik { get { return GetResourceString("CODE_MON_Tugrik"); } }

		public static string CODE_MON_Moroccan_Dirham { get { return GetResourceString("CODE_MON_Moroccan_Dirham"); } }

		public static string CODE_MON_Metical { get { return GetResourceString("CODE_MON_Metical"); } }

		public static string CODE_MON_Kyat { get { return GetResourceString("CODE_MON_Kyat"); } }

		public static string CODE_MON_Namibia_Dollar { get { return GetResourceString("CODE_MON_Namibia_Dollar"); } }

		public static string CODE_MON_South_African_Rand { get { return GetResourceString("CODE_MON_South_African_Rand"); } }

		public static string CODE_MON_Nepalese_Rupee { get { return GetResourceString("CODE_MON_Nepalese_Rupee"); } }

		public static string CODE_MON_Cordoba_Oro { get { return GetResourceString("CODE_MON_Cordoba_Oro"); } }

		public static string CODE_MON_Naira { get { return GetResourceString("CODE_MON_Naira"); } }

		public static string CODE_MON_Rial_Omani { get { return GetResourceString("CODE_MON_Rial_Omani"); } }

		public static string CODE_MON_Pakistan_Rupee { get { return GetResourceString("CODE_MON_Pakistan_Rupee"); } }

		public static string CODE_MON_Balboa { get { return GetResourceString("CODE_MON_Balboa"); } }

		public static string CODE_MON_Kina { get { return GetResourceString("CODE_MON_Kina"); } }

		public static string CODE_MON_Guarani { get { return GetResourceString("CODE_MON_Guarani"); } }

		public static string CODE_MON_Nuevo_Sol { get { return GetResourceString("CODE_MON_Nuevo_Sol"); } }

		public static string CODE_MON_Philippine_Peso { get { return GetResourceString("CODE_MON_Philippine_Peso"); } }

		public static string CODE_MON_Zloty { get { return GetResourceString("CODE_MON_Zloty"); } }

		public static string CODE_MON_Qatari_Rial { get { return GetResourceString("CODE_MON_Qatari_Rial"); } }

		public static string CODE_MON_Leu { get { return GetResourceString("CODE_MON_Leu"); } }

		public static string CODE_MON_Russian_Ruble { get { return GetResourceString("CODE_MON_Russian_Ruble"); } }

		public static string CODE_MON_Rwanda_Franc { get { return GetResourceString("CODE_MON_Rwanda_Franc"); } }

		public static string CODE_MON_Saint_Helena_Pound { get { return GetResourceString("CODE_MON_Saint_Helena_Pound"); } }

		public static string CODE_MON_Tala { get { return GetResourceString("CODE_MON_Tala"); } }

		public static string CODE_MON_Dobra { get { return GetResourceString("CODE_MON_Dobra"); } }

		public static string CODE_MON_Saudi_Riyal { get { return GetResourceString("CODE_MON_Saudi_Riyal"); } }

		public static string CODE_MON_Serbian_Dinar { get { return GetResourceString("CODE_MON_Serbian_Dinar"); } }

		public static string CODE_MON_Seychelles_Rupee { get { return GetResourceString("CODE_MON_Seychelles_Rupee"); } }

		public static string CODE_MON_Leone { get { return GetResourceString("CODE_MON_Leone"); } }

		public static string CODE_MON_Singapore_Dollar { get { return GetResourceString("CODE_MON_Singapore_Dollar"); } }

		public static string CODE_MON_Sucre { get { return GetResourceString("CODE_MON_Sucre"); } }

		public static string CODE_MON_Solomon_Islands_Dollar { get { return GetResourceString("CODE_MON_Solomon_Islands_Dollar"); } }

		public static string CODE_MON_Somali_Shilling { get { return GetResourceString("CODE_MON_Somali_Shilling"); } }

		public static string CODE_MON_Sri_Lanka_Rupee { get { return GetResourceString("CODE_MON_Sri_Lanka_Rupee"); } }

		public static string CODE_MON_Sudanese_Pound { get { return GetResourceString("CODE_MON_Sudanese_Pound"); } }

		public static string CODE_MON_Surinam_Dollar { get { return GetResourceString("CODE_MON_Surinam_Dollar"); } }

		public static string CODE_MON_Lilangeni { get { return GetResourceString("CODE_MON_Lilangeni"); } }

		public static string CODE_MON_Swedish_Krona { get { return GetResourceString("CODE_MON_Swedish_Krona"); } }

		public static string CODE_MON_WIR_Euro { get { return GetResourceString("CODE_MON_WIR_Euro"); } }

		public static string CODE_MON_WIR_Franc { get { return GetResourceString("CODE_MON_WIR_Franc"); } }

		public static string CODE_MON_Syrian_Pound { get { return GetResourceString("CODE_MON_Syrian_Pound"); } }

		public static string CODE_MON_New_Taiwan_Dollar { get { return GetResourceString("CODE_MON_New_Taiwan_Dollar"); } }

		public static string CODE_MON_Somoni { get { return GetResourceString("CODE_MON_Somoni"); } }

		public static string CODE_MON_Tanzanian_Shilling { get { return GetResourceString("CODE_MON_Tanzanian_Shilling"); } }

		public static string CODE_MON_Baht { get { return GetResourceString("CODE_MON_Baht"); } }

		public static string CODE_MON_Paanga { get { return GetResourceString("CODE_MON_Paanga"); } }

		public static string CODE_MON_Trinidad_and_Tobago_Dollar { get { return GetResourceString("CODE_MON_Trinidad_and_Tobago_Dollar"); } }

		public static string CODE_MON_Tunisian_Dinar { get { return GetResourceString("CODE_MON_Tunisian_Dinar"); } }

		public static string CODE_MON_Turkish_Lira { get { return GetResourceString("CODE_MON_Turkish_Lira"); } }

		public static string CODE_MON_New_Manat { get { return GetResourceString("CODE_MON_New_Manat"); } }

		public static string CODE_MON_Uganda_Shilling { get { return GetResourceString("CODE_MON_Uganda_Shilling"); } }

		public static string CODE_MON_Hryvnia { get { return GetResourceString("CODE_MON_Hryvnia"); } }

		public static string CODE_MON_UAE_Dirham { get { return GetResourceString("CODE_MON_UAE_Dirham"); } }

		public static string CODE_MON_US_Dollar_Next_day { get { return GetResourceString("CODE_MON_US_Dollar_Next_day"); } }

		public static string CODE_MON_US_Dollar_Same_day { get { return GetResourceString("CODE_MON_US_Dollar_Same_day"); } }

		public static string CODE_MON_Peso_Uruguayo { get { return GetResourceString("CODE_MON_Peso_Uruguayo"); } }

		public static string CODE_MON_Uruguay_Peso_en_Unidades_Indexadas_URUIURUI { get { return GetResourceString("CODE_MON_Uruguay_Peso_en_Unidades_Indexadas_URUIURUI"); } }

		public static string CODE_MON_Uzbekistan_Sum { get { return GetResourceString("CODE_MON_Uzbekistan_Sum"); } }

		public static string CODE_MON_Vatu { get { return GetResourceString("CODE_MON_Vatu"); } }

		public static string CODE_MON_Bolivar_Fuerte { get { return GetResourceString("CODE_MON_Bolivar_Fuerte"); } }

		public static string CODE_MON_Dong { get { return GetResourceString("CODE_MON_Dong"); } }

		public static string CODE_MON_Yemeni_Rial { get { return GetResourceString("CODE_MON_Yemeni_Rial"); } }

		public static string CODE_MON_Zambian_Kwacha { get { return GetResourceString("CODE_MON_Zambian_Kwacha"); } }

		public static string CODE_MON_Zimbabwe_Dollar { get { return GetResourceString("CODE_MON_Zimbabwe_Dollar"); } }

		public static string CODE_MON_Bond_Markets_Unit_European_Composite_Unit_EURCO { get { return GetResourceString("CODE_MON_Bond_Markets_Unit_European_Composite_Unit_EURCO"); } }

		public static string CODE_MON_Bond_Markets_Unit_European_Monetary_Unit_EMU_6 { get { return GetResourceString("CODE_MON_Bond_Markets_Unit_European_Monetary_Unit_EMU_6"); } }

		public static string CODE_MON_Bond_Markets_Unit_European_Unit_of_Account_9_EUA_9 { get { return GetResourceString("CODE_MON_Bond_Markets_Unit_European_Unit_of_Account_9_EUA_9"); } }

		public static string CODE_MON_Bond_Markets_Unit_European_Unit_of_Account_17_EUA_17 { get { return GetResourceString("CODE_MON_Bond_Markets_Unit_European_Unit_of_Account_17_EUA_17"); } }

		public static string CODE_MON_UIC_Franc { get { return GetResourceString("CODE_MON_UIC_Franc"); } }

		public static string CODE_MON_Codes_specifically_reserved_for_testing_purposes { get { return GetResourceString("CODE_MON_Codes_specifically_reserved_for_testing_purposes"); } }

		public static string CODE_MON_The_codes_assigned_for_transactions_where_no_currency_is_involved { get { return GetResourceString("CODE_MON_The_codes_assigned_for_transactions_where_no_currency_is_involved"); } }

		public static string CODE_MON_Gold { get { return GetResourceString("CODE_MON_Gold"); } }

		public static string CODE_MON_Palladium { get { return GetResourceString("CODE_MON_Palladium"); } }

		public static string CODE_MON_Platinum { get { return GetResourceString("CODE_MON_Platinum"); } }

		public static string CODE_MON_Silver { get { return GetResourceString("CODE_MON_Silver"); } }

		public static string CODE_DQ_DIM_horizontal { get { return GetResourceString("CODE_DQ_DIM_horizontal"); } }

		public static string CODE_DQ_DIM_vertical { get { return GetResourceString("CODE_DQ_DIM_vertical"); } }

		public static string CODE_LISOURCE_PRODUCED { get { return GetResourceString("CODE_LISOURCE_PRODUCED"); } }

		public static string CODE_LISOURCE_USED { get { return GetResourceString("CODE_LISOURCE_USED"); } }

		public static string dataSource_type { get { return GetResourceString("dataSource_type"); } }

		public static string Extents { get { return GetResourceString("Extents"); } }

		public static string fgdcGeoform { get { return GetResourceString("fgdcGeoform"); } }

		public static string genericName_codespace { get { return GetResourceString("genericName_codespace"); } }

		public static string MetadataConstraints { get { return GetResourceString("MetadataConstraints"); } }

		public static string MetadataContacts { get { return GetResourceString("MetadataContacts"); } }

		public static string MetadataMaintenance { get { return GetResourceString("MetadataMaintenance"); } }

		public static string References { get { return GetResourceString("References"); } }

		public static string relinfo { get { return GetResourceString("relinfo"); } }

		public static string ResourceConstraints { get { return GetResourceString("ResourceConstraints"); } }

		public static string ResourceDetails { get { return GetResourceString("ResourceDetails"); } }

		public static string ResourceMaintenance { get { return GetResourceString("ResourceMaintenance"); } }

		public static string ResourcePointsOfContact { get { return GetResourceString("ResourcePointsOfContact"); } }

		public static string ServiceDetails { get { return GetResourceString("ServiceDetails"); } }

		public static string posList { get { return GetResourceString("posList"); } }

		public static string citOnlineRes { get { return GetResourceString("citOnlineRes"); } }

		public static string IndeterminateDate { get { return GetResourceString("IndeterminateDate"); } }

		public static string IndeterminateTime { get { return GetResourceString("IndeterminateTime"); } }

		public static string nilReason { get { return GetResourceString("nilReason"); } }

		public static string dtfcfkey { get { return GetResourceString("dtfcfkey"); } }

		public static string dtfcname { get { return GetResourceString("dtfcname"); } }

		public static string dtfcpkey { get { return GetResourceString("dtfcpkey"); } }

		public static string CODE_RS_DIM_horizontal { get { return GetResourceString("CODE_RS_DIM_horizontal"); } }

		public static string CODE_RS_DIM_temporal { get { return GetResourceString("CODE_RS_DIM_temporal"); } }

		public static string CODE_RS_DIM_vertical { get { return GetResourceString("CODE_RS_DIM_vertical"); } }

		public static string idAdoptedDate { get { return GetResourceString("idAdoptedDate"); } }

		public static string idCreationDate { get { return GetResourceString("idCreationDate"); } }

		public static string idDeprecatedDate { get { return GetResourceString("idDeprecatedDate"); } }

		public static string idInForceDate { get { return GetResourceString("idInForceDate"); } }

		public static string idNotAvailableDate { get { return GetResourceString("idNotAvailableDate"); } }

		public static string idProductKeywords { get { return GetResourceString("idProductKeywords"); } }

		public static string idPublicationDate2 { get { return GetResourceString("idPublicationDate2"); } }

		public static string idRevisionDate { get { return GetResourceString("idRevisionDate"); } }

		public static string idSubtopicKeywords { get { return GetResourceString("idSubtopicKeywords"); } }

		public static string idSupersededDate { get { return GetResourceString("idSupersededDate"); } }

		public static string maintCont { get { return GetResourceString("maintCont"); } }

		public static string ProcessExport { get { return GetResourceString("ProcessExport"); } }

		public static string CODE_IMS_APPLICATIONS { get { return GetResourceString("CODE_IMS_APPLICATIONS"); } }

		public static string CODE_IMS_CLEARINGHOUSES { get { return GetResourceString("CODE_IMS_CLEARINGHOUSES"); } }

		public static string CODE_IMS_DOWNLOADABLE_DATA { get { return GetResourceString("CODE_IMS_DOWNLOADABLE_DATA"); } }

		public static string CODE_IMS_GEOGRAPHIC_ACTIVITIES { get { return GetResourceString("CODE_IMS_GEOGRAPHIC_ACTIVITIES"); } }

		public static string CODE_IMS_GEOGRAPHIC_SERVICES { get { return GetResourceString("CODE_IMS_GEOGRAPHIC_SERVICES"); } }

		public static string CODE_IMS_LIVE_DATA_AND_MAPS { get { return GetResourceString("CODE_IMS_LIVE_DATA_AND_MAPS"); } }

		public static string CODE_IMS_MAP_FILES { get { return GetResourceString("CODE_IMS_MAP_FILES"); } }

		public static string CODE_IMS_OFFLINE_DATA { get { return GetResourceString("CODE_IMS_OFFLINE_DATA"); } }

		public static string CODE_IMS_OTHER_DOCUMENTS { get { return GetResourceString("CODE_IMS_OTHER_DOCUMENTS"); } }

		public static string CODE_IMS_STATIC_MAP_IMAGES { get { return GetResourceString("CODE_IMS_STATIC_MAP_IMAGES"); } }

		public static string imsContentTypeExport { get { return GetResourceString("imsContentTypeExport"); } }

		public static string imsContentTypeThesaurus { get { return GetResourceString("imsContentTypeThesaurus"); } }

		public static string gmlDescRef2 { get { return GetResourceString("gmlDescRef2"); } }

		public static string idInitiative { get { return GetResourceString("idInitiative"); } }

		public static string idOtherAggregate { get { return GetResourceString("idOtherAggregate"); } }

		public static string idPlatformSeries { get { return GetResourceString("idPlatformSeries"); } }

		public static string idProductionSeries { get { return GetResourceString("idProductionSeries"); } }

		public static string idSensorSeries { get { return GetResourceString("idSensorSeries"); } }

		public static string idSensor_scope { get { return GetResourceString("idSensor_scope"); } }

		public static string idStereomate_scope { get { return GetResourceString("idStereomate_scope"); } }

		public static string idTransferAggregate { get { return GetResourceString("idTransferAggregate"); } }

		public static string idSidePanelIllus { get { return GetResourceString("idSidePanelIllus"); } }

		public static string SourceMetadataSchema { get { return GetResourceString("SourceMetadataSchema"); } }

		public static string toolThumbnail { get { return GetResourceString("toolThumbnail"); } }

		public static string LatestWKID { get { return GetResourceString("LatestWKID"); } }

		public static string idHelpMoreMetadata_ItemDescription { get { return GetResourceString("idHelpMoreMetadata_ItemDescription"); } }

		public static string formatInfo { get { return GetResourceString("formatInfo"); } }

		public static string formatTech { get { return GetResourceString("formatTech"); } }

		public static string itemType { get { return GetResourceString("itemType"); } }

		public static string createdBy { get { return GetResourceString("createdBy"); } }

		public static string ESRINetworkDiagram { get { return GetResourceString("ESRINetworkDiagram"); } }

		public static string lastUpdatedBy { get { return GetResourceString("lastUpdatedBy"); } }

		public static string templateName { get { return GetResourceString("templateName"); } }
	}
}
namespace ArcGIS.Desktop.Internal.Metadata.Views
{
	internal class MetadataOptionsViewRes
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ArcGIS.Desktop.Metadata.Views.MetadataOptionsViewRes", typeof(MetadataOptionsViewRes).Assembly);
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
       
		
		public static string MetadataStyleHeader { get { return GetResourceString("MetadataStyleHeader"); } }

		public static string MetaDataOptionsPageTitle { get { return GetResourceString("MetaDataOptionsPageTitle"); } }

		public static string MetadataOptionsHelp { get { return GetResourceString("MetadataOptionsHelp"); } }
	}
}
