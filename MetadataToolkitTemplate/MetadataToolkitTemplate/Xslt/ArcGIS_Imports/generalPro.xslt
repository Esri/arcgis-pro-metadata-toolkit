<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:res="http://www.esri.com/metadata/res/" xmlns:esri="http://www.esri.com/metadata/" xmlns:gmd="http://www.isotc211.org/2005/gmd" xmlns:msxsl="urn:schemas-microsoft-com:xslt" >

<!-- An XSLT template for displaying metadata in ArcGIS stored in the ArcGIS metadata format.
     Copyright (c) 2014, Esri, Inc. All rights reserved.
     Revision History: Created 5/20/2014 avienneau
-->

  <xsl:import href = "codelistsPro.xslt" />
  <xsl:import href = "auxLangCountryPro.xslt" />
  <xsl:import href = "auxUCUMPro.xslt" />

<!-- HANDLE LARGE BLOCKS OF TEXT, e.g. abstract -->

<xsl:template name="handleURLs">
	<xsl:param name="text" />
	<xsl:variable name="replaceURL">http://</xsl:variable>
	
	<xsl:choose>
		<xsl:when test="contains($text, $replaceURL)">
			<xsl:variable name="before" select="substring-before($text, $replaceURL)" />
			<xsl:variable name="middle" select="substring-after($text, $replaceURL)" />
			
			<xsl:variable name="urlTemp">
				<xsl:choose>
					<xsl:when test="(contains($middle, ' '))">
						<xsl:value-of select="substring-before($middle, ' ')" />
					</xsl:when>
					<xsl:when test="($middle != '')">
						<xsl:value-of select="$middle" />
					</xsl:when>
					<xsl:otherwise>
						<xsl:text></xsl:text>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:variable>
			
			<xsl:variable name="urlTempLength" select="string-length($urlTemp)" />
			<xsl:variable name="urlTempLast" select="substring($urlTemp, $urlTempLength)" />
			<xsl:variable name="url">
				<xsl:choose>
					<xsl:when test="($urlTempLast = ',') or ($urlTempLast = ';') or ($urlTempLast = '.') or ($urlTempLast = '&gt;')">
						<xsl:value-of select="substring($urlTemp, 1, ($urlTempLength - 1))" />
					</xsl:when>
					<xsl:when test="($urlTemp != '')">
						<xsl:value-of select="$urlTemp" />
					</xsl:when>
					<xsl:otherwise>
						<xsl:text></xsl:text>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:variable>
			
			<xsl:variable name="after">
				<xsl:choose>
					<xsl:when test="(substring-after($middle, $url) != '')">
						<xsl:value-of select="substring-after($middle, $url)" />
					</xsl:when>
					<xsl:otherwise>
						<xsl:text></xsl:text>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:variable>
		
			<xsl:choose>
				<xsl:when test='$after'>
					<xsl:value-of select='$before'/><a target="_blank">
						<xsl:attribute name="href"><xsl:value-of select='$replaceURL' /><xsl:value-of select='$url' /></xsl:attribute>
						<xsl:value-of select='$replaceURL' /><xsl:value-of select='$url' />
					</a>
					
					<xsl:call-template name="handleURLs">
						<xsl:with-param name="text" select="$after" />
					</xsl:call-template>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="$text" />
				</xsl:otherwise>
			</xsl:choose>
		</xsl:when>
		<xsl:otherwise>
			<xsl:value-of select="$text" />
		</xsl:otherwise>
	</xsl:choose>
</xsl:template>

<!-- add target to links if one isn't already present -->
<xsl:template match="node() | @*" priority="1" mode="linkTarget">
	<xsl:copy>
		<xsl:apply-templates select="node() | @*" mode="linkTarget" />
	</xsl:copy>
</xsl:template>
<xsl:template match="a | A" priority="2" mode="linkTarget">
		<xsl:copy>
			<xsl:attribute name="target">_blank</xsl:attribute>
			<xsl:apply-templates select="node() | @*[not(name() = 'target')]" mode="linkTarget" />
		</xsl:copy>
</xsl:template>

  <xsl:template name="elementSupportingMarkup">
	<xsl:param name="ele" />
	<xsl:choose>
		<xsl:when test="$ele/*">
			<!-- whitespace between nodes will be removed IF it isn't full HTML -->
			<!-- b or a inside plain text won't have carriage returns, br respected as carriage returns; must live with this behavior for unsupported content format -->
			<!-- full DIV or P containing all content will have whitespace retained between nodes -->
			<pre class="wrap">
				<xsl:copy-of select="$ele/node()" />
			</pre>
		</xsl:when>
		<xsl:when test="$ele[(contains(.,'&lt;/')) or (contains(.,'/&gt;'))]">
			<xsl:variable name="text">
				<xsl:copy-of select="esri:decodenodeset($ele)" />
			</xsl:variable>
			<xsl:choose>
				<xsl:when test="($text != '')">
					<pre class="wrap">
						<xsl:copy-of select="$text" />
					</pre>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="escapedHtmlText">
						<xsl:value-of select="esri:striphtml($ele)" />
					</xsl:variable>
					<xsl:choose>
						<xsl:when test="($escapedHtmlText != '')">
							<xsl:variable name="handleURLsResult">
								<xsl:call-template name="handleURLs">
									<xsl:with-param name="text" select="$ele" />
								</xsl:call-template>
							</xsl:variable>
							<pre class="wrap">
								<xsl:copy-of select="($handleURLsResult)" />
							</pre>
						</xsl:when>
						<xsl:otherwise>
							<p><span class="noContent">
								<xsl:choose>
									<xsl:when test="(name($ele) = 'idAbs')"><res:idNoDescForItem/></xsl:when>
									<xsl:when test="(name($ele) = 'idPurp')"><res:idNoSummaryForItem/></xsl:when>
									<xsl:when test="(name($ele) = 'idCredit')"><res:idNoCreditsForItem/></xsl:when>
									<xsl:when test="(name($ele) = 'useLimit')"><res:idNoUseLimitsForItem/></xsl:when>
								</xsl:choose>
							</span></p>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:when>
		<xsl:when test="$ele[(contains(.,'&amp;')) or (contains(.,'&lt;')) or (contains(.,'&gt;'))]">
			<!-- add pre tag with specific class around resulting text to keep whitespace -->
			<!-- putting result of handleURLs in a variable and using value-of with the variable causes URL to not be a link; use copy-of instead -->
			<!-- adding normalize-space around $ele to remove trailing whitespace removes all carriage returns; must live with trailing whitespace -->
			<xsl:variable name="handleURLsResult">
				<xsl:call-template name="handleURLs">
					<xsl:with-param name="text" select="$ele" />
				</xsl:call-template>
			</xsl:variable>
			<pre class="wrap">
				<xsl:copy-of select="($handleURLsResult)" />
			</pre>
		</xsl:when>
		<xsl:when test="$ele/text()">
			<xsl:variable name="escapedHtmlText">
				<xsl:value-of select="esri:striphtml($ele)" />
			</xsl:variable>
			<!-- add pre tag around result to keep whitespace -->
			<xsl:variable name="handleURLsResult">
				<xsl:call-template name="handleURLs">
					<xsl:with-param name="text" select="$escapedHtmlText" />
				</xsl:call-template>
			</xsl:variable>
			<pre class="wrap">
				<xsl:copy-of select="($handleURLsResult)" />
			</pre>
		</xsl:when>
	</xsl:choose>
  </xsl:template>


<!-- HANDLE DIFFERENT DATA TYPES -->

<xsl:template name="booleanType">
	<xsl:param name="value" />
	<xsl:choose>
		<xsl:when test="($value = 1) or ($value = 'true') or ($value = 'TRUE') or ($value = 'True')"><res:boolTrue /></xsl:when>
		<xsl:when test="($value = 0) or ($value = 'false') or ($value = 'FALSE') or ($value = 'False')"><res:boolFalse /></xsl:when>
		<xsl:otherwise><xsl:value-of select="$value"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="dateType">
	<xsl:param name="value" />
	<xsl:choose>
		<xsl:when test="number($value)"><xsl:value-of select="substring($value,1,4)" /><xsl:if test="string-length($value) > 4">-<xsl:value-of select="substring($value,5,2)" /></xsl:if><xsl:if test="string-length($value) > 6">-<xsl:value-of select="substring($value,7,2)" /></xsl:if></xsl:when>
		<xsl:when test="contains($value, 'T')"><xsl:value-of select="substring-before($value,'T')" />&#x2003;<xsl:value-of select="substring-after($value,'T')" /></xsl:when>
		<xsl:otherwise><xsl:value-of select="$value"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="timeType">
	<xsl:param name="value" />
	<xsl:choose>
		<xsl:when test="number($value)"><xsl:value-of select="substring($value,1,2)" /><xsl:if test="string-length($value) > 2">:<xsl:value-of select="substring($value,3,2)" /></xsl:if><xsl:if test="string-length($value) > 4">:<xsl:value-of select="substring($value,5,2)" /></xsl:if></xsl:when>
		<xsl:otherwise><xsl:value-of select="$value"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="urlType">
	<xsl:param name="value" />
	<xsl:choose>
		<xsl:when test="(substring($value,1,7) = 'http://') or (substring($value,1,7) = 'HTTP://') or (substring($value,1,8) = 'https://') or (substring($value,1,8) = 'HTTPS://') or (substring($value,1,6) = 'ftp://') or (substring($value,1,6) = 'FTP://')"><a target="_blank">
			<xsl:attribute name="href"><xsl:value-of select="$value"/></xsl:attribute>
			<xsl:value-of select="$value"/></a></xsl:when>
		<xsl:otherwise><xsl:value-of select="$value"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="emailType">
	<xsl:param name="value" />
	<xsl:choose>
		<xsl:when test="contains($value,'@')"><a target="_blank">
			<xsl:attribute name="href">mailto:<xsl:value-of select="$value"/>?subject=<xsl:value-of select="/metadata/dataIdInfo/idCitation/resTitle"/></xsl:attribute>
			<xsl:value-of select="$value"/></a></xsl:when>
		<xsl:otherwise><xsl:value-of select="$value"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>


<!-- PLACE ELEMENTS ON THE HTML PAGE -->

<xsl:template name="arcgisElement">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
    <!-- sync characters tried: * not intrinsically associated with sync -->
    <!-- &#8635; and &#8651; arrowheads too small to be interpreted correctly -->
    <!-- &#8667; ok, but doesn't 100% look like an arrow -->
    <!-- &#8658; works fine, needs to be gray -->
		<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:value-of select="$ele"/></dt>
</xsl:template>

<xsl:template name="arcgisElementName">
	<xsl:param name="ele" />
	<dt><span class="SubContentHeader">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if></dt>
</xsl:template>

<xsl:template name="arcgisElementNameExpander">
	<xsl:param name="ele" />
	<dt>
    <xsl:call-template name="elementText">
      <xsl:with-param name="ele" select="$ele" />
    </xsl:call-template>&#160;<xsl:if test="$ele/@Sync = 'TRUE'">
  <span class="sync">&#8660;</span>&#x2009;</xsl:if></dt>
</xsl:template>

<xsl:template name="arcgisElementValueExpander">
	<xsl:param name="ele" />
	<xsl:param name="value" />
	<dt>
    <xsl:call-template name="elementText">
      <xsl:with-param name="ele" select="$ele" />
    </xsl:call-template>&#160;<xsl:value-of select="$value"/>&#160;<xsl:if test="$ele/@Sync = 'TRUE'">
  <span class="sync">&#8660;</span>&#x2009;</xsl:if></dt>
</xsl:template>

<xsl:template name="arcgisBoolean">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="booleanType">
			<xsl:with-param name="value" select="$ele" />
		</xsl:call-template></dt>
</xsl:template>

<xsl:template name="arcgisCode">
	<xsl:param name="ele" />
	<dt>
	<xsl:choose>
		<!-- some codes are stored in an @value on a subelement -->
		<xsl:when test="(./*)">
			<span class="ElementLabel">
					<xsl:call-template name="elementText">
						<xsl:with-param name="ele" select="$ele" />
					</xsl:call-template>
				</span>&#x2003;<xsl:if test="$ele/*/@Sync = 'TRUE'">
				<span class="sync">&#8660;</span>&#x2009;</xsl:if>
			<xsl:for-each select="*">
				<xsl:call-template name="codeText">
					<xsl:with-param name="ele" select="." />
				</xsl:call-template>
			</xsl:for-each>
		</xsl:when>
		<!-- some codes are stored directly in an element or attribute -->
		<xsl:otherwise>
			<span class="ElementLabel">
					<xsl:call-template name="elementText">
						<xsl:with-param name="ele" select="$ele" />
					</xsl:call-template>
				</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
				<span class="sync">&#8660;</span>&#x2009;</xsl:if>
				<xsl:call-template name="codeText">
					<xsl:with-param name="ele" select="." />
				</xsl:call-template>
		</xsl:otherwise>
	</xsl:choose>
	</dt>
</xsl:template>

<xsl:template name="arcgisDate">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="dateType">
			<xsl:with-param name="value" select="." />
		</xsl:call-template></dt>
		<xsl:if test="(@date != '') or (@time != '')">
			<dl>
				<xsl:if test="(@date != '')">
					<dt><span class="ElementLabel"><xsl:call-template name="elementText">
							<xsl:with-param name="ele" select="@date" />
						</xsl:call-template>
					</span>&#x2003;<xsl:value-of select="@date" /></dt>
				</xsl:if>
				<xsl:if test="(@time != '')">
					<dt><span class="ElementLabel"><xsl:call-template name="elementText">
							<xsl:with-param name="ele" select="@time" />
						</xsl:call-template>
					</span>&#x2003;<xsl:value-of select="@time" /></dt>
				</xsl:if>
			</dl>
		</xsl:if>
</xsl:template>

<xsl:template name="arcgisSeparateDateTime">
	<xsl:param name="dateEle" />
	<xsl:param name="timeEle" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$dateEle" />
			</xsl:call-template>
		</span>&#x2003;<xsl:if test="$dateEle/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="dateType">
			<xsl:with-param name="value" select="$dateEle" />
		</xsl:call-template>&#x2003;<xsl:call-template name="timeType">
			<xsl:with-param name="value" select="$timeEle" />
		</xsl:call-template></dt>
</xsl:template>

<xsl:template name="arcgisUrl">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="urlType">
			<xsl:with-param name="value" select="." />
		</xsl:call-template></dt>
</xsl:template>

<xsl:template name="arcgisEmail">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="emailType">
			<xsl:with-param name="value" select="." />
		</xsl:call-template></dt>
</xsl:template>

<xsl:template name="arcgisTextWithUrls">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template></span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if></dt>
	<dl><dd>
			<xsl:call-template name="elementSupportingMarkup">
				<!-- changing this to normalize-space removes carriage returns, but includes spaces between each word on same line and different lines -->
				<xsl:with-param name="ele" select="."/>
			</xsl:call-template><br />
	</dd></dl>
</xsl:template>

<xsl:template name="arcgisEscapedHtml">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template></span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if></dt>
	<dl><dd>
			<xsl:call-template name="elementSupportingMarkup">
				<!-- changing this to normalize-space removes carriage returns, but includes spaces between each word on same line and different lines -->
				<xsl:with-param name="ele" select="."/>
			</xsl:call-template><br />
	</dd></dl>
</xsl:template>

<xsl:template name="arcgisLangCntry">
	<xsl:param name="ele" />
    <dt>
	<xsl:choose>
		<xsl:when test="$ele/languageCode">
			<span class="ElementLabel">
				<xsl:call-template name="elementText">
					<xsl:with-param name="ele" select="$ele" />
				</xsl:call-template>
			</span>&#x2003;<xsl:if test="$ele/languageCode/@Sync = 'TRUE'">
			<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="ISO639_LanguageCode">
				<xsl:with-param name="code" select="$ele/languageCode/@value" />
			</xsl:call-template>
			<xsl:if test="($ele/countryCode/@value != '')">&#160;(<xsl:call-template name="ISO3166_CountryCode">
					<xsl:with-param name="code" select="$ele/countryCode/@value" />
				</xsl:call-template>)
			</xsl:if>
		</xsl:when>
		<xsl:otherwise>
			<span class="ElementLabel">
					<xsl:call-template name="elementText">
						<xsl:with-param name="ele" select="$ele" />
					</xsl:call-template>
				</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
				<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="ISO639_LanguageCode">
					<xsl:with-param name="code" select="$ele/@language" />
				</xsl:call-template>
				<xsl:if test="($ele/@country != '')">&#160;(<xsl:call-template name="ISO3166_CountryCode">
						<xsl:with-param name="code" select="$ele/@country" />
					</xsl:call-template>)
				</xsl:if>
		</xsl:otherwise>
	</xsl:choose>
	</dt>
</xsl:template>

<xsl:template name="arcgisMeasures">
	<xsl:param name="ele" />
    <dt>
	<xsl:choose>
		<xsl:when test="$ele/@uom">
			<span class="ElementLabel">
				<xsl:call-template name="elementText">
					<xsl:with-param name="ele" select="$ele" />
				</xsl:call-template>
			</span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
			<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:value-of select="."/><xsl:for-each select="./@uom">&#160;<xsl:call-template name="ucum_units">
					<xsl:with-param name="unit" select="." />
				</xsl:call-template>
			</xsl:for-each>
		</xsl:when>
	</xsl:choose>
	</dt>
</xsl:template>

<xsl:template name="arcgisTypedElement">
	<xsl:param name="ele" />
	<xsl:param name="type" />
	<dt><span class="ElementLabel">
		<xsl:call-template name="elementText">
			<xsl:with-param name="ele" select="$ele" />
		</xsl:call-template></span>&#x2003;<xsl:if test="$ele/@Sync = 'TRUE'">
		<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:value-of select="."/></dt>
	<xsl:for-each select="$type">
		<dl>
			<dt><span class="ElementLabel">
				<xsl:call-template name="elementText">
					<xsl:with-param name="ele" select="$type" />
				</xsl:call-template></span>&#x2003;<xsl:call-template name="urlType">
					<xsl:with-param name="value" select="$type" />
				</xsl:call-template></dt>
		</dl>
	</xsl:for-each>
</xsl:template>

<xsl:template name="arcgisElementMany">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;
	    <xsl:for-each select="$ele[text()]">
	        <xsl:if test="@Sync = 'TRUE'">
				<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:value-of select="."/><xsl:if test="not(position() = last())">, </xsl:if>
	    </xsl:for-each>
	</dt>
</xsl:template>

<xsl:template name="arcgisCodeMany">
	<xsl:param name="ele" />
	<dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;
	    <xsl:for-each select="$ele">
			<xsl:choose>
				<!-- some codes are stored in an @value on a subelement -->
				<xsl:when test="(./*)">
					<xsl:if test="*/@Sync = 'TRUE'">
						<span class="sync">&#8660;</span>&#x2009;</xsl:if>
					<xsl:for-each select="*">
						<xsl:call-template name="codeText">
							<xsl:with-param name="ele" select="." />
						</xsl:call-template>
					</xsl:for-each>
				</xsl:when>
				<!-- some codes are stored directly in an element or attribute -->
				<xsl:otherwise>
					<xsl:if test="@Sync = 'TRUE'">
						<span class="sync">&#8660;</span>&#x2009;</xsl:if>
						<xsl:call-template name="codeText">
							<xsl:with-param name="ele" select="." />
						</xsl:call-template>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:if test="not(position() = last())">, </xsl:if>
	    </xsl:for-each>
	</dt>
</xsl:template>

<xsl:template name="arcgisLangCntryMany">
	<xsl:param name="ele" />
    <dt><span class="ElementLabel">
			<xsl:call-template name="elementText">
				<xsl:with-param name="ele" select="$ele" />
			</xsl:call-template>
		</span>&#x2003;
	<xsl:for-each select="$ele">
		<xsl:choose>
			<xsl:when test="languageCode/@value">
				<xsl:if test="languageCode/@Sync = 'TRUE'">
				<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="ISO639_LanguageCode">
					<xsl:with-param name="code" select="languageCode/@value" />
				</xsl:call-template>
				<xsl:if test="(countryCode/@value != '')">&#160;(<xsl:call-template name="ISO3166_CountryCode">
						<xsl:with-param name="code" select="countryCode/@value" />
					</xsl:call-template>)
				</xsl:if>
			</xsl:when>
			<xsl:otherwise>
				<xsl:if test="@Sync = 'TRUE'">
					<span class="sync">&#8660;</span>&#x2009;</xsl:if><xsl:call-template name="ISO639_LanguageCode">
						<xsl:with-param name="code" select="@language" />
					</xsl:call-template>
					<xsl:if test="(@country != '')">&#160;(<xsl:call-template name="ISO3166_CountryCode">
							<xsl:with-param name="code" select="@country" />
						</xsl:call-template>)
					</xsl:if>
			</xsl:otherwise>
		</xsl:choose>
		<xsl:if test="not(position() = last())">, </xsl:if>
	</xsl:for-each>
	</dt>
</xsl:template>

<xsl:template name="codeText">
	<xsl:param name="ele" />
	<xsl:variable name="eleName"><xsl:value-of select="name($ele)" /></xsl:variable>
	<xsl:choose>
		<!-- some codes are stored in an @value on a subelement -->
		<xsl:when test="($eleName = 'DateTypCd')">
			<xsl:call-template name="CI_DateTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'OnFunctCd') or ($eleName = 'dataSetFn')">
			<xsl:call-template name="CI_OnLineFunctionCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'PresFormCd')">
			<xsl:call-template name="CI_PresentationFormCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'fgdcGeoform')">
		</xsl:when>
		<xsl:when test="($eleName = 'RoleCd')">
			<xsl:call-template name="CI_RoleCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'EvalMethTypeCd')">
			<xsl:call-template name="DQ_EvaluationMethodTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'AscTypeCd')">
			<xsl:call-template name="DS_AssociationTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'InitTypCd')">
			<xsl:call-template name="DS_InitiativeTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'CellGeoCd')">
			<xsl:call-template name="MD_CellGeometryCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'CharSetCd')">
			<xsl:call-template name="MD_CharSetCd">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'ClasscationCd')">
			<xsl:call-template name="MD_ClassificationCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'ContentTypCd')">
			<xsl:call-template name="MD_CoverageContentTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'DatatypeCd')">
			<xsl:call-template name="MD_DatatypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'DimNameTypCd')">
			<xsl:call-template name="MD_DimensionNameTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'GeoObjTypCd')">
			<xsl:call-template name="MD_GeometricObjectTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'ImgCondCd')">
			<xsl:call-template name="MD_ImagingConditionCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'MaintFreqCd')">
			<xsl:call-template name="MD_MaintenanceFrequencyCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'MedFormCd')">
			<xsl:call-template name="MD_MediumFormatCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'MedNameCd')">
			<xsl:call-template name="MD_MediumNameCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'ObCd')">
			<xsl:call-template name="MD_ObligationCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'PixOrientCd')">
			<xsl:call-template name="MD_PixelOrientationCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'ProgCd')">
			<xsl:call-template name="MD_ProgressCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'RestrictCd')">
			<xsl:call-template name="MD_RestrictionCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'ScopeCd')">
			<xsl:call-template name="MD_ScopeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'SpatRepTypCd')">
			<xsl:call-template name="MD_SpatialRepresentationTypeCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'TopicCatCd')">
			<xsl:call-template name="MD_TopicCategoryCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'TopoLevCd')">
			<xsl:call-template name="MD_TopologyLevelCode">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'CouplTypCd')">
			<xsl:call-template name="SV_CouplTypCd">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'DCPListCd')">
			<xsl:call-template name="SV_DCPList">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'ParamDirCd')">
			<xsl:call-template name="SV_ParamDirCd">
				<xsl:with-param name="code" select="@value" />
			</xsl:call-template>
		</xsl:when>
		<!-- some codes are stored directly in an element or attribute -->
		<xsl:when test="($eleName = 'type') and (name($ele/..) = 'axisDimension')">
			<xsl:call-template name="MD_DimensionNameTypeCode">
				<xsl:with-param name="code" select="." />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'attrmfrq')">
			<xsl:call-template name="MD_MaintenanceFrequencyCode">
				<xsl:with-param name="code" select="." />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'orDesc') or (name() = 'imsContentType')">
			<xsl:call-template name="ArcIMS_ContentTypeCode">
				<xsl:with-param name="code" select="." />
			</xsl:call-template>
		</xsl:when>
		<xsl:when test="($eleName = 'type') and ((name($ele/..) = 'report') or (name($ele/..) = 'dqReport'))">
			<xsl:call-template name="DataQuality_ReportTypeCode">
				<xsl:with-param name="code" select="$ele" />
			</xsl:call-template>
		</xsl:when>
		<xsl:otherwise><span class="unknownElement"><xsl:value-of select="$eleName" /></span></xsl:otherwise>
	</xsl:choose>
</xsl:template>

</xsl:stylesheet>