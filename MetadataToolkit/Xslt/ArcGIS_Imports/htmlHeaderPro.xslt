<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:res="http://www.esri.com/metadata/res/" xmlns:esri="http://www.esri.com/metadata/" xmlns:gmd="http://www.isotc211.org/2005/gmd" xmlns:msxsl="urn:schemas-microsoft-com:xslt" >

<!-- An XSLT template for displaying metadata in ArcGIS stored in the ArcGIS metadata format.
     Copyright (c) 2014, Esri, Inc. All rights reserved.
     Revision History: Created 5/20/2014 avienneau
-->

<!-- templates for adding portions of the header to the HTML page -->

<xsl:template name="styles">
	<style type="text/css" id="internalStyle">
    body {
      font-family: "Segoe UI", Arial, Sans-serif;
      font-size: 10pt;
      color: #4C4C4C;
      background-color: #FFFFFF;
      margin: 6px, 6px, 6px, 6px;
    }
    h1 {
      font-family: "Segoe UI Light", "Segoe UI", Arial, Sans-serif;
      font-size: 14pt;
      color: #0079C1;
      margin: 0px 0px 8px 0px;
    }
    h3 {
      font-family: "Segoe UI semibold", "Segoe UI", Arial, Sans-serif;
      font-size: 12pt;
      margin: 10px 0px 4px 0px;
    }
    span.ContentHeader {
      font-family: "Segoe UI semibold", "Segoe UI", Arial, Sans-serif;
      font-size: 12pt;
    }
    span.SubContentHeader {
      font-family: "Segoe UI", Arial, Sans-serif;
      font-size: 10pt;
      color: #6D6C70;
    }
    span.ElementLabel {
      font-family: "Segoe UI", Arial, Sans-serif;
      font-size: 10pt;
      color: #929497;
    }
    div {
      margin: 0px 0px 0px 0px;
    }
    p {
      margin: 0px 0px 6px 0px;
    }
    .center {
      text-align: center;
    }
    img {
      width: 210px;
      height: 140px;
      margin: 8px 0px 8px 0px;
    }
    img.center {
      text-align: center;
      display: block;
    }
    img.gp {
      width: auto;
    }
    .noThumbnail {
      #color: rgb(70%, 70%, 70%);
      color: #A6A8AB;
      border-width: 1px;
      border-style: solid;
      #color: rgb(70%, 70%, 70%);
      border-color: #A6A8AB;
      padding: 3em 3em;
      position: relative;
      text-align: center;
      width: 210px;
      height: 140px;
      margin: 8px 0px 8px 0px;
    }
    .noContent {
      #color: rgb(70%, 70%, 70%);
      color: #A6A8AB;
    }
    h3 a.expander:link {
      color: #4C4C4C;
      font-weight: normal;
      text-decoration: none;
    }
    h3 a.expander:visited {
      color: #0079C1;
      text-decoration: none;
    }
    h3 a.expander:link:hover, h3 a.expander:visited:hover {
      color: #0079C1;
      text-decoration: none;
    }
    a.expander:link {
      color: #323232;
      font-weight: normal;
      text-decoration: none;
    }
    a.expander:visited {
      color: #0079C1;
      text-decoration: none;
    }
    a.expander:link:hover, a.expander:visited:hover {
      color: #0079C1;
      text-decoration: none;
    }
    a:link {
      color: #5A9359;
      font-weight: normal;
      text-decoration: none;
    }
    a:visited {
      color: #5A9359;
      text-decoration: underline;
    }
    a:link:hover, a:visited:hover {
      color: #5A9359;
      text-decoration: underline;
    }
    div.hide {
      display: none;
      margin: 0px 0px 20px 0px;
      color: #6D6C70;
    }
    div.show {
      display: block;
      margin: 0px 0px 20px 0px;
    }
    span.hide {
      display: none;
      font-family: Times;
    }
    span.show {
      display: inline-block;
      font-style: normal;
      font-family: Times;
    }
    table {
      margin: 0px 0px 0px 0px;
      padding: 0px 0px 8px 0px;
      border-collapse:collapse;
      font-size: 10pt;
    }
    th {
      font-family: "Segoe UI Semibold", Arial, Sans-serif;
      color: #4C4C4C;
      /* color: #6C6D70 for dialog/python reference heading; */
      text-align: left;
      vertical-align: bottom;
      border-bottom: 1px solid #4C4C4C;
    }
    td {
      text-align: left;
      vertical-align: top;
    }
    td.description {
      vertical-align: center;
    }
    td.gp {
      padding: 8px 8px 8px 8px;
      border-bottom: 1px solid #4C4C4C;
    }
    ul {
      margin: 0px 0px 0px 10px;
      padding: 0px 0px 0px 10px;
    }
    li {
      margin: 0px 0px 0px 0px;
      padding: 0px 0px 0px 10px;
    }
    ul ul {
      list-style-type: square;
    }
    pre.wrap {
      width: 99%;
      font-family: "Segoe UI", Arial, Sans-serif;
      font-size: 10pt;
      margin: 0px 0px 0px 0px;
      white-space: pre-wrap;       /* css-3 */
      white-space: -moz-pre-wrap;  /* Mozilla, since 1999 */
      white-space: -pre-wrap;      /* Opera 4-6 */
      white-space: -o-pre-wrap;    /* Opera 7 */
      word-wrap: break-word;       /* Internet Explorer 5.5+ */
    }
    pre.wrap p {
      padding-bottom: 1em;
    }
    pre.wrap li {
      padding-bottom: 1em;
    }
    pre.wrap br {
      display: block;
    }
    pre.gp {
      font-family: Courier New, Courier, monospace;
    }
    .gpcode {
      border: 1px dashed #ACC6D8;
      padding: 10px;
      background-color:#EEEEEE;
      height: auto;
      overflow: scroll; 
      width: 98%;
    }
    .code {
      font-family: monospace;
    }

    p.gp {
      margin: 7px 0px 7px 0px;
    }
    dl {
      margin: 0px 0px 0px 0px;
    }
    dt {
      margin: 0px 0px 0px 15px;
      clear: left;
    }
    dd {
      margin: 0px 0px 0px 15px;
      clear: left;
    }
  </style>
</xsl:template>

<xsl:template name="scripts">
	<script type="text/javascript">
	/* <![CDATA[ */
		function hideShow(divID) {
			var item = document.getElementById(divID);
			var itemShow = document.getElementById(divID + 'Show');
			var itemHide = document.getElementById(divID + 'Hide');
			if (item) {
				if (item.className == 'hide') {
					item.className='show';
					itemShow.className='hide';
					itemHide.className='show';
				}
				else {
					item.className='hide';
					itemShow.className='show';
					itemHide.className='hide';
				}
			}
		}
	/* ]]> */
	</script>
</xsl:template>

</xsl:stylesheet>