<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:res="http://www.esri.com/metadata/res/" xmlns:esri="http://www.esri.com/metadata/" >

<!-- An XSLT template for displaying metadata in ArcGIS stored in the ArcGIS metadata format.
     Copyright (c) 2014, Esri, Inc. All rights reserved.
     Revision History: Created 5/20/2014 avienneau
-->


<!-- TEMPLATES FOR DISPLAYING METADATA CONTENT USED BY ARCGIS -->

  <xsl:template name="iteminfo" >
    <div id="overview">

	<!-- Title -->
	<h1 id="title">
		<xsl:choose>
			<xsl:when test="/metadata/dataIdInfo[1]/idCitation/resTitle/text()">
				<xsl:value-of select="/metadata/dataIdInfo[1]/idCitation/resTitle[1]" />
			</xsl:when>
			<xsl:when test="/metadata/Esri/DataProperties/itemProps/itemName/text()">
				<xsl:value-of select="/metadata/Esri/DataProperties/itemProps/itemName" />
			</xsl:when>
			<xsl:otherwise>
				<span class="noContent"><res:idNoTitle/></span>
			</xsl:otherwise>
		</xsl:choose>
	</h1>

	<!-- Data type -->
	<xsl:if test="/metadata/distInfo/distFormat/formatName or /metadata/distInfo/distributor/distorFormat/formatName">
    <p id="itemType"><span class="ContentHeader"><res:itemType/></span>&#x2003;
			<xsl:choose>
				<xsl:when test="/metadata/distInfo/distFormat/formatName/text()">
					<xsl:value-of select="/metadata/distInfo/distFormat/formatName[text()][1]"/>
				</xsl:when>
				<xsl:when test="/metadata/distInfo/distributor/distorFormat/formatName/text()">
					<xsl:value-of select="/metadata/distInfo/distributor/distorFormat/formatName[text()][1]"/>
				</xsl:when>
			</xsl:choose>
    </p>
	</xsl:if>

	<!-- Thumbnail/Tool Illustration -->
	<xsl:choose>
		<xsl:when test="/metadata/Binary/Thumbnail/img/@src">
			<img name="thumbnail" id="thumbnail" alt="Thumbnail" title="Thumbnail" class="summary">
				<xsl:attribute name="src">
					<xsl:value-of select="/metadata/Binary/Thumbnail/img/@src"/>
				</xsl:attribute>
			</img>
		</xsl:when>
		<xsl:when test="/metadata/idinfo/browse/img/@src">
			<img name="thumbnail" id="thumbnail" alt="Thumbnail" title="Thumbnail" class="summary">
				<xsl:attribute name="src">
					<xsl:value-of select="/metadata/idinfo/browse/img/@src"/>
				</xsl:attribute>
			</img>
		</xsl:when>
	</xsl:choose>

	<!-- Tags/Metadata Theme Keywords -->
	<div id="tags">
		<xsl:choose>
			<xsl:when test="/metadata/dataIdInfo[1]/searchKeys/keyword[text() and (. != '001') and (. != '002') and (. != '003') and (. != '004') and (. != '005') and (. != '006') and (. != '007') and (. != '008') and (. != '009') and (. != '010')]">
				<p><span class="ContentHeader"><res:idTags /></span>&#x2003;
					<xsl:for-each select="/metadata/dataIdInfo[1]/searchKeys/keyword[text() and (. != '001') and (. != '002') and (. != '003') and (. != '004') and (. != '005') and (. != '006') and (. != '007') and (. != '008') and (. != '009') and (. != '010')]">
						<xsl:value-of select="."/>
						<xsl:if test="not(position()=last())">, </xsl:if>
					</xsl:for-each>
				</p>
			</xsl:when>
			<xsl:otherwise>
				<p><span class="ContentHeader"><res:idTags /></span>&#x2003;<span class="noContent"><res:idNoTagsForItem/></span></p>
			</xsl:otherwise>
		</xsl:choose>
	</div>

	<!-- AGOL Summary/Metadata Purpose -->
	<div>
		<h3><res:idSummary_ItemDescription /></h3>
		<xsl:choose>
			<xsl:when test="(/metadata/dataIdInfo[1]/idPurp != '')">
				<p id="summary">
					<xsl:call-template name="elementSupportingMarkup">
						<xsl:with-param name="ele" select="/metadata/dataIdInfo[1]/idPurp" />
					</xsl:call-template>
				</p>
			</xsl:when>
			<xsl:otherwise>
				<p><span class="noContent"><res:idNoSummaryForItem/></span></p>
			</xsl:otherwise>
		</xsl:choose>
	</div>

	<!-- AGOL Description/Metadata Abstract/Tool Summary -->
	<div>
		<h3><res:idDesc_ItemDescription /></h3>
		<xsl:choose>
			<xsl:when test="(/metadata/dataIdInfo[1]/idAbs != '')">
				<p id="description">
					<xsl:call-template name="elementSupportingMarkup">
						<xsl:with-param name="ele" select="/metadata/dataIdInfo[1]/idAbs" />
					</xsl:call-template>
				</p>
			</xsl:when>
			<xsl:otherwise>
				<p><span class="noContent"><res:idNoDescForItem/></span></p>
			</xsl:otherwise>
		</xsl:choose>
	</div>

	<!-- Credits -->
	<div>
		<h3><res:idCredits_ItemDescription /></h3>
		<xsl:choose>
			<xsl:when test="(/metadata/dataIdInfo[1]/idCredit != '')">
				<p id="credits">
					<xsl:call-template name="elementSupportingMarkup">
						<xsl:with-param name="ele" select="/metadata/dataIdInfo[1]/idCredit" />
					</xsl:call-template>
				</p>
			</xsl:when>
			<xsl:otherwise>
				<p><span class="noContent"><res:idNoCreditsForItem/></span></p>
			</xsl:otherwise>
		</xsl:choose>
	</div>

	<!-- Use constraints -->
	<div>
		<h3><res:idUseLimits_ItemDescription /></h3>
		<xsl:choose>
			<xsl:when test="(/metadata/dataIdInfo[1]/resConst/Consts/useLimit[1] != '')">
				<p id="useLimitations">
					<xsl:call-template name="elementSupportingMarkup">
						<xsl:with-param name="ele" select="/metadata/dataIdInfo[1]/resConst/Consts/useLimit[1]" />
					</xsl:call-template>
				</p>
			</xsl:when>
			<xsl:otherwise>
				<p><span class="noContent"><res:idNoUseLimitsForItem/></span></p>
			</xsl:otherwise>
		</xsl:choose>
	</div>

	<!-- Extent -->
	<div>
		<h3><res:idExtent_ItemDescription /></h3>
		<xsl:choose>
			<xsl:when test="/metadata/dataIdInfo[1]/dataExt/geoEle/GeoBndBox[(@esriExtentType = 'search') and (westBL != '') and (eastBL != '') and (northBL != '') and (southBL != '')]">
				<xsl:for-each select="/metadata/dataIdInfo[1]/dataExt[geoEle/GeoBndBox/@esriExtentType = 'search'][1]/geoEle[(GeoBndBox/@esriExtentType = 'search')][1]/GeoBndBox[(@esriExtentType = 'search')][1]">
					<xsl:call-template name="extentTable">
						<xsl:with-param name="west" select="westBL" />
						<xsl:with-param name="east" select="eastBL" />
						<xsl:with-param name="north" select="northBL" />
						<xsl:with-param name="south" select="southBL" />
					</xsl:call-template>
				</xsl:for-each>
			</xsl:when>
			<xsl:otherwise>
				<p><span class="noContent"><res:idNoExtentForItem /></span></p>
			</xsl:otherwise>
		</xsl:choose>
	</div>

	<!-- Scale range -->
	<div>
		<h3><res:idScaleRange_ItemDescription /></h3>
		<xsl:choose>
			<xsl:when test="/metadata/Esri/scaleRange[(. != '')]">
				<xsl:for-each select="/metadata/Esri/scaleRange">
					<table cols="2" width="auto" border="0">
						<col align="left" />
						<col align="left" />
						<tr><!-- the little number (large scale), stored in maxScale -->
							<td class="description"><span class="ElementLabel"><res:idScaleRangeMax_ItemDescription /></span>&#160;&#160;</td>
							<td class="description"><xsl:text>1:</xsl:text><xsl:value-of select="format-number(maxScale,'###,###,###')"/></td>
						</tr>
						<tr><!-- the big number (small scale), stored in minScale -->
							<td class="description"><span class="ElementLabel"><res:idScaleRangeMin_ItemDescription /></span>&#160;&#160;</td>
							<td class="description"><xsl:text>1:</xsl:text><xsl:value-of select="format-number(minScale,'###,###,###')"/></td>
						</tr>
					</table>
				</xsl:for-each>
			</xsl:when>
			<xsl:otherwise>
				<p><span class="noContent"><res:idNoScaleRangeForItem /></span></p>
			</xsl:otherwise>
		</xsl:choose>
	</div>

    </div>
  </xsl:template>
  
  <xsl:template name="extentTable">
	<xsl:param name="west" />
	<xsl:param name="east" />
	<xsl:param name="north" />
	<xsl:param name="south" />
	<table cols="4" width="auto" border="0">
		<col align="left" />
		<col align="right" />
		<col align="left" />
		<col align="right" />
		<tr>
			<td class="description"><span class="ElementLabel"><res:idExtentWest_ItemDescription /></span>&#160;&#160;</td>
			<td class="description"><xsl:value-of select="$west"/></td>
			<td class="description">&#160;&#160;&#160;&#160;&#160;<span class="ElementLabel"><res:idExtentEast_ItemDescription /></span>&#160;</td>
			<td class="description"><xsl:value-of select="$east"/></td>
		</tr>
		<tr>
			<td class="description"><span class="ElementLabel"><res:idExtentNorth_ItemDescription /></span>&#160;&#160;</td>
			<td class="description"><xsl:value-of select="$north"/></td>
			<td class="description">&#160;&#160;&#160;&#160;&#160;<span class="ElementLabel"><res:idExtentSouth_ItemDescription /></span>&#160;</td>
			<td class="description"><xsl:value-of select="$south"/></td>
		</tr>
	</table>
  </xsl:template>
  
</xsl:stylesheet>