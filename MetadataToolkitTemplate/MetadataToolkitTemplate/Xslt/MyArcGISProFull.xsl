<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 	xmlns:gmd="http://www.isotc211.org/2005/gmd" xmlns:res="http://www.esri.com/metadata/res/" >

  <!-- An XSLT template for displaying metadata stored in the ArcGIS metadata format.
    Copyright (c) 2014, Environmental Systems Research Institute, Inc. All rights reserved. -->

  <xsl:import href = "ArcGIS_Imports\htmlHeaderPro.xslt" />
  <xsl:import href = "ArcGIS_Imports\generalPro.xslt" />
  <xsl:import href = "ArcGIS_Imports\ItemDescriptionPro.xslt" />
  <xsl:import href = "ArcGIS_Imports\geoprocessingPro.xslt" />
  <xsl:import href = "ArcGIS_Imports\elementHeadingsPro.xslt" />
  <xsl:import href = "ArcGIS_Imports\ArcGISmetadataPro.xslt" />

  <xsl:output method="xml" indent="yes" encoding="UTF-8" doctype-public="-//W3C//DTD XHTML 1.0 Strict//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd" />
  
  <xsl:variable name="gpArcGIS" select="(/metadata/tool//* | /metadata/toolbox//*)[text()]" />

  <xsl:param name="flowdirection"/>

  <xsl:template match="/">
  <html xmlns="http://www.w3.org/1999/xhtml">
  <xsl:if test="/*/@xml:lang[. != '']">
	  <xsl:attribute name="xml:lang"><xsl:value-of select="/*/@xml:lang"/></xsl:attribute>
	  <xsl:attribute name="lang"><xsl:value-of select="/*/@xml:lang"/></xsl:attribute>
  </xsl:if>
  
  <head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
    <xsl:call-template name="styles" />
    <xsl:call-template name="scripts" />
  </head>

  <body oncontextmenu="return true">
    <h2>My ArcGIS Pro Style</h2>
  <xsl:if test="$flowdirection = 'RTL'">
    <xsl:attribute name="style">direction:rtl;</xsl:attribute>
  </xsl:if>
  
  <xsl:choose>
    <xsl:when test="$gpArcGIS">
      <xsl:call-template name="gp"/> 
      <xsl:call-template name="arcgis"/> 
    </xsl:when>
    <xsl:otherwise>
      <xsl:call-template name="iteminfo"/> 
      <xsl:call-template name="arcgis"/> 
    </xsl:otherwise>
  </xsl:choose>

  </body>
  </html>

</xsl:template>

</xsl:stylesheet>