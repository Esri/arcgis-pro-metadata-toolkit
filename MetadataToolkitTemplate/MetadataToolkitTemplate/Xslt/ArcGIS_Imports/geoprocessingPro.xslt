<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:res="http://www.esri.com/metadata/res/" xmlns:esri="http://www.esri.com/metadata/" xmlns:msxsl="urn:schemas-microsoft-com:xslt" >
	
<!-- An XSLT template for displaying metadata in ArcGIS stored in the ArcGIS metadata format.
     Copyright (c) 2014, Esri, Inc. All rights reserved.
     Revision History: Created 5/20/2014 avienneau
-->

<!-- GEOPROCESSING TOOL CONTENT -->

	<xsl:variable name="pre_path" select="//toolbox/arcToolboxHelpPath/text() | //tool/arcToolboxHelpPath/text()"/>
	<xsl:variable name="path" select="translate($pre_path, '\', '/')"/>

	<xsl:template name="gp">
		<!-- tool name -->
		<h1>
			<xsl:value-of select="//tool/@displayname | //toolbox/@name"/>
		</h1>
		
		<!-- tool full title (not necessarily the same as the name) -->
		<xsl:choose>
		  <xsl:when test="(/metadata/dataIdInfo[1]/idCitation/resTitle != '')">
			<p><span class="ContentHeader"><res:resTitle /></span>&#x2003;
				<xsl:value-of select="/metadata/dataIdInfo[1]/idCitation/resTitle[1]" />
			</p>
		  </xsl:when>
		  <xsl:otherwise>
			<p><span class="ContentHeader"><res:resTitle /></span>&#x2003;<span class="noContent"><res:idNoTitle/></span></p>
		  </xsl:otherwise>
		</xsl:choose>

		<!--TOOL LOCATION-->
		<xsl:if test="//tool/@path">
			<p><span class="ContentHeader"><res:itemLocationLinkage/></span>&#x2003;
				<xsl:value-of select="."/>
			</p>
		</xsl:if>
		
		<!-- AGOL Description/Metadata Abstract/Toolbox Summary/Tool Summary -->
		<div>
			<h3><res:idDesc_ItemDescription /></h3>
			<xsl:choose>
				<xsl:when test="(//toolbox/summary != '')">
					<p>
						<xsl:call-template name="elementSupportingMarkup">
							<xsl:with-param name="ele" select="//toolbox/summary" />
						</xsl:call-template>
					</p>
				</xsl:when>
				<xsl:when test="(//tool/summary != '')">
					<p>
						<xsl:call-template name="elementSupportingMarkup">
							<xsl:with-param name="ele" select="//tool/summary" />
						</xsl:call-template>
					</p>
				</xsl:when>
				<xsl:when test="(/metadata/dataIdInfo[1]/idAbs != '')">
					<p>
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

		<!-- Thumbnail/Toolbox Illustration/Tool Illustration -->
		<xsl:if test="//tool/toolIllust[@src != ''] | /metadata/Binary/Thumbnail/img[@src != '']">
			<div>
				<h3><res:idIllus/></h3>
				<xsl:apply-templates select="//tool/toolIllust[@src != '']" mode="gp" />
				<xsl:apply-templates select="/metadata/Binary/Thumbnail[img/@src != '']" mode="gp" />
			</div>
		</xsl:if>
		
		<!-- Toolbox Toolsets -->
		<xsl:if test="//toolbox/toolsets[toolset]">
			<div>
				<h3><res:idToolsets/></h3>
				<ul>
					<xsl:for-each select="//toolbox/toolsets/toolset">
						<li><xsl:value-of select="@name"/></li>
					</xsl:for-each>
				</ul>
			</div>
		</xsl:if>
		
		<!-- Toolbox AGOL Summary/Metadata Purpose -->
		<xsl:if test="//toolbox">
			<div>
				<h3><res:idSummary_ItemDescription /></h3>
				<xsl:choose>
					<xsl:when test="(/metadata/dataIdInfo[1]/idPurp != '')">
						<p>
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
		</xsl:if>
		
		<!-- Tool Usage -->
		<xsl:if test="//tool">
			<div>
				<h3><res:idUsage/></h3>
				<xsl:choose>
					<xsl:when test="(//tool/usage != '')">
						<p>
							<xsl:call-template name="elementSupportingMarkup">
								<xsl:with-param name="ele" select="//tool/usage" />
							</xsl:call-template>
						</p>
					</xsl:when>
					<xsl:otherwise>
						<p><span class="noContent"><res:idNoUsageForTool/></span></p>
					</xsl:otherwise>
				</xsl:choose>
			</div>
			
			<!-- Tool Syntax -->
			<div>
				<h3><res:idSyntax/></h3>
				<p><xsl:call-template name="syntax"/></p>
				
				<xsl:choose>
					<xsl:when test="//tool/parameters/param">
						<xsl:call-template name="ScriptingTable"/>
					</xsl:when>
					<xsl:otherwise>
						<p><span class="noContent"><res:idNoParametersForTool /></span></p>
					</xsl:otherwise>
				</xsl:choose>
			</div>
			
			<!-- Code Samples -->
			<div>
				<h3><res:idCodeSamples/></h3>
				<xsl:choose>
					<xsl:when test="//tool/scriptExamples/scriptExample">
						<xsl:apply-templates select="//tool/scriptExamples" mode="gp" />
					</xsl:when>
					<xsl:when test="//tool/scriptExample">
						<xsl:apply-templates select="scriptExample" mode="gp" />
					</xsl:when>
					<xsl:otherwise>
						<div class="gpItemInfo">
							<p><span class="noContent"><res:idNoCodeSamplesForTool /></span></p>
						</div>
					</xsl:otherwise>
				</xsl:choose>
			</div>
			
      <!-- Side-Panel Enclosure/Tool Illustration -->
      <xsl:if test="/metadata/Binary/Enclosure/img[(@src != '') and (esri:strtolower(@OriginalFileName) = 'thumbnail.jpg')]">
        <div>
          <h3><res:idSidePanelIllus/></h3>
          <xsl:apply-templates select="/metadata/Binary/Enclosure/img[(@src != '') and (esri:strtolower(@OriginalFileName) = 'thumbnail.jpg')]" mode="gp" />
        </div>
      </xsl:if>
      
			<!-- Tool Environments -->
      <xsl:if test="//tool/environments/environment">
        <div>
          <h3><res:idEnvs/></h3>
          <p>
            <xsl:for-each select="//tool/environments/environment">
              <xsl:value-of select="@label"/>
              <xsl:if test="not(position() = last())">,&#160;</xsl:if>
            </xsl:for-each>
          </p>
        </div>
      </xsl:if>
    
    </xsl:if>
			
		<!-- Tags/Metadata Keywords -->
		<div>
			<h3><res:idTags /></h3>
		  <p>
			<xsl:choose>
				<xsl:when test="/metadata/dataIdInfo[1]/searchKeys/keyword/text()">
					<xsl:for-each select="/metadata/dataIdInfo[1]/searchKeys/keyword[text()]">
						<xsl:value-of select="."/>
						<xsl:if test="not(position()=last())">, </xsl:if>
					</xsl:for-each>
				</xsl:when>
				<xsl:when test="/metadata/dataIdInfo[1]/themeKeys/keyword/text() or /metadata/dataIdInfo/placeKeys/keyword/text()">
					<xsl:for-each select="/metadata/dataIdInfo[1]/themeKeys/keyword[text()] | /metadata/dataIdInfo/placeKeys/keyword[text()]">
						<xsl:value-of select="."/>
						<xsl:if test="not(position()=last())">, </xsl:if>
					</xsl:for-each>
				</xsl:when>
				<xsl:otherwise>
					<span class="noContent"><res:idNoTagsForItem/></span>
				</xsl:otherwise>
			</xsl:choose>
		  </p>
		</div>
		
		<!-- Credits -->
		<div>
			<h3><res:idCredits_ItemDescription /></h3>
			<xsl:choose>
				<xsl:when test="(/metadata/dataIdInfo[1]/idCredit != '')">
					<p>
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
		
		<!-- Use limitation -->
		<div>
			<h3><res:idUseLimits_ItemDescription /></h3>
			<xsl:choose>
				<xsl:when test="(/metadata/dataIdInfo[1]/resConst/Consts/useLimit[1] != '')">
					<p>
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
	</xsl:template>
		
	<!-- DISPLAY EMBEDDED THUMBNAIL -->
	<xsl:template match="/metadata/Binary/Thumbnail/img[@src]" mode="gp">
		<xsl:variable name="label" select="res:str('idIllus')" />
		<img class="gp" id="illustration" alt="{$label}" title="{$label}">
			<xsl:attribute name="src"><xsl:value-of select="@src"/></xsl:attribute>
		</img>
	</xsl:template>
	<xsl:template match="/metadata/Binary/Enclosure/img[(@src != '') and (esri:strtolower(@OriginalFileName) = 'thumbnail.jpg')]" mode="gp">
		<xsl:variable name="label" select="res:str('idSidePanelIllus')" />
		<img class="gp" id="sidePanelIllustration" alt="{$label}" title="{$label}">
			<xsl:attribute name="src"><xsl:value-of select="@src"/></xsl:attribute>
		</img>
	</xsl:template>

	<!-- EXTERNAL TOOL ILLUSTRATION-->
	<xsl:template match="tool/toolIllust" mode="gp">
		<xsl:choose>
			<xsl:when test="(@type='illustration')">
				<img class="gp">
					<xsl:attribute name="src">
						<xsl:choose>
							<!--check to see if ARCTOOLBOXHELP is set,
								if it is use it to define the path of the illustration -->
							<xsl:when test="(@src!='')">
								<xsl:value-of select="$path"/>
								<!-- check to make sure path is not empty -->
								<xsl:if test="$path !=''">
									<xsl:text>/</xsl:text>
								</xsl:if>
								<xsl:value-of select="@src"/>
							</xsl:when>
							<!-- the ARCTOOLBOXHELP is NOT set -->
							<xsl:otherwise>
								<xsl:value-of select="(substring-before($path,'/help'))"/>
								<!-- check to make sure path is not empty -->
								<xsl:if test="$path !=''">
									<xsl:text>/SearchResources/Icons/</xsl:text>
									<xsl:text>HORIZ_</xsl:text>
								</xsl:if>
								<xsl:value-of select="@src"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:attribute>
					<xsl:attribute name="alt"><xsl:value-of select="@alt"/></xsl:attribute>
				</img>
				<xsl:if test="text()">
					<b>
						<xsl:value-of select="text()"/>
					</b>
				</xsl:if>
			</xsl:when>
			<xsl:when test="not(@type) and (@src != '')">
				<img class="gp">
					<xsl:attribute name="src">
						<xsl:value-of select="@src"/>
					</xsl:attribute>
					<xsl:attribute name="alt">
						<xsl:value-of select="@alt"/>
					</xsl:attribute>
				</img>
				<xsl:if test="text()">
					<b>
						<xsl:value-of select="text()"/>
					</b>
				</xsl:if>
			</xsl:when>
		</xsl:choose>
	</xsl:template>

	<!-- SCRIPTING SYNTAX SECTION-->
	<xsl:template name="syntax">
		<xsl:value-of select="//tool/@name"/>
		<xsl:if test="//tool/@toolboxalias">
			<xsl:choose>
				<xsl:when test="not(//tool/@toolboxalias='')">
					<xsl:text>_</xsl:text>
					<xsl:value-of select="@toolboxalias"/>
				</xsl:when>
			</xsl:choose>
		</xsl:if>
		<xsl:text> (</xsl:text>
		<xsl:variable name="count" select="count(//tool/parameters/param)"/>
		<xsl:for-each select="//tool/parameters/param">
			<xsl:choose>
				<xsl:when test="(@type = 'Optional')">{<xsl:value-of select="@name"/>}</xsl:when>
				<xsl:otherwise><xsl:value-of select="@name"/></xsl:otherwise>
			</xsl:choose>
			<xsl:if test="position() &lt; $count">
				<xsl:text>, </xsl:text>
			</xsl:if>
		</xsl:for-each>
		<xsl:text>) </xsl:text>
		<br/><br/>
	</xsl:template>

	<xsl:template name="ScriptingTable">
		<table>
				<tr>
					<th width="30%"><res:idParam/></th>
					<th width="50%"><res:idExpl/></th>
					<th width="20%"><res:idDataType_geoprocessing/></th>
				</tr>
				<xsl:for-each select="//tool/parameters/param">
					<tr>
						<td class="gp">
							<xsl:call-template name="Script_Expression"/>
						</td>
						<td class="gp" align="left">
						  <xsl:if test="not(*)"><p><span class="noContent"><res:idNoExplanationForToolParam /></span></p></xsl:if>
						  <xsl:for-each select="dialogReference">
							<xsl:if test="(position() = 1)">
								<span class="SubContentHeader"><res:idToolParamDialogReference /></span><br />
							</xsl:if>
							<xsl:choose>
								<xsl:when test="(. = '') or not(node())"><p><span class="noContent"><res:idToolNoDialogRefForParam /></span></p></xsl:when>
								<xsl:when test="para or bulletList or bullet_item or indent or subSection or bold or italics">
									<xsl:choose>
										<xsl:when test="not(name(*) != 'bullet_item')">
											<ul>
												<xsl:apply-templates select="*" mode="gp" />
											</ul>
										</xsl:when>
										<xsl:otherwise>
											<xsl:apply-templates select="*" mode="gp" />
										</xsl:otherwise>
									</xsl:choose>
								</xsl:when>
								<xsl:when test="*">
									<xsl:copy-of select="node()" />
								</xsl:when>
								<xsl:when test="text()[(contains(.,'&lt;/')) or (contains(.,'/&gt;'))]">
									<!--
									<xsl:choose>
										<xsl:when test="(esri:striphtml(text()) = '')"><span class="noContent"><res:idToolNoDialogRefForParam /></span></xsl:when>
										<xsl:otherwise><xsl:copy-of select="esri:decodenodeset(text())" /></xsl:otherwise>
									</xsl:choose>
									-->
									<xsl:variable name="text">
										<xsl:copy-of select="esri:decodenodeset(.)" />
									</xsl:variable>
									<xsl:choose>
										<xsl:when test="($text != '')">
											<xsl:variable name="newText">
												<xsl:apply-templates select="msxsl:node-set($text)/node() | msxsl:node-set($text)/@*" mode="linkTarget" />
											</xsl:variable>
											<xsl:copy-of select="$newText" />
										</xsl:when>
										<xsl:otherwise>
											<xsl:variable name="escapedHtmlText">
												<xsl:value-of select="esri:striphtml(.)" />
											</xsl:variable>
											<xsl:choose>
												<xsl:when test="($escapedHtmlText != '')">
													<xsl:call-template name="handleURLs">
														<xsl:with-param name="text" select="normalize-space($escapedHtmlText)" />
													</xsl:call-template>
												</xsl:when>
												<xsl:when test="($escapedHtmlText = '')">
													<p><span class="noContent"><res:idToolNoDialogRefForParam /></span></p>
												</xsl:when>
											</xsl:choose>
										</xsl:otherwise>
									</xsl:choose>
								</xsl:when>
								<xsl:when test=".//text()">
									<xsl:apply-templates select="*" mode="gp" />
								</xsl:when>
								<xsl:when test="text()">
									<!-- <xsl:value-of select="." /> -->
									<xsl:variable name="escapedHtmlText">
										<xsl:value-of select="esri:striphtml(.)" />
									</xsl:variable>
									<xsl:call-template name="handleURLs">
										<xsl:with-param name="text" select="normalize-space($escapedHtmlText)" />
									</xsl:call-template>
								</xsl:when>
								<xsl:otherwise><p><span class="noContent"><res:idToolNoDialogRefForParam /></span></p></xsl:otherwise>
							</xsl:choose>
						  </xsl:for-each>
						  <xsl:if test="not(dialogReference) and (pythonReference or commandReference)">
							<p><span class="SubContentHeader"><res:idToolParamDialogReference /></span></p>
							<p><span class="noContent"><res:idToolNoDialogRefForParam /></span></p>
						  </xsl:if>
						  <xsl:if test="pythonReference or commandReference">
							  <div class="noContent" style="text-align:center; margin-top: -1em" >___________________</div><br />
							  <xsl:for-each select="pythonReference">
								<xsl:if test="(position() = 1)">
									<span class="SubContentHeader"><res:idToolParamPythonReference /></span><br />
								</xsl:if>
								<xsl:choose>
									<xsl:when test="(. = '') or not(node())"><p><span class="noContent"><res:idToolNoPythonRefForParam /></span></p></xsl:when>
									<xsl:when test="para or bulletList or bullet_item or indent or subSection or bold or italics">
										<xsl:choose>
											<xsl:when test="not(name(*) != 'bullet_item')">
												<ul>
													<xsl:apply-templates select="*" mode="gp" />
												</ul>
											</xsl:when>
											<xsl:otherwise>
												<xsl:apply-templates select="*" mode="gp" />
											</xsl:otherwise>
										</xsl:choose>
									</xsl:when>
									<xsl:when test="*">
										<xsl:copy-of select="node()" />
									</xsl:when>
									<xsl:when test="text()[(contains(.,'&lt;/')) or (contains(.,'/&gt;'))]">
										<!--
										<xsl:choose>
											<xsl:when test="(esri:striphtml(text()) = '')"><span class="noContent"><res:idToolNoPythonRefForParam /></span></xsl:when>
											<xsl:otherwise><xsl:copy-of select="esri:decodenodeset(text())" /></xsl:otherwise>
										</xsl:choose>
										-->
										<xsl:variable name="text">
											<xsl:copy-of select="esri:decodenodeset(.)" />
										</xsl:variable>
										<xsl:choose>
											<xsl:when test="($text != '')">
												<xsl:variable name="newText">
													<xsl:apply-templates select="msxsl:node-set($text)/node() | msxsl:node-set($text)/@*" mode="linkTarget" />
												</xsl:variable>
												<xsl:copy-of select="$newText" />
											</xsl:when>
											<xsl:otherwise>
												<xsl:variable name="escapedHtmlText">
													<xsl:value-of select="esri:striphtml(.)" />
												</xsl:variable>
												<xsl:choose>
													<xsl:when test="($escapedHtmlText != '')">
														<xsl:call-template name="handleURLs">
															<xsl:with-param name="text" select="normalize-space($escapedHtmlText)" />
														</xsl:call-template>
													</xsl:when>
													<xsl:when test="($escapedHtmlText = '')">
														<p><span class="noContent"><res:idToolNoPythonRefForParam /></span></p>
													</xsl:when>
												</xsl:choose>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:when>
									<xsl:when test=".//text()">
										<xsl:apply-templates select="*" mode="gp" />
									</xsl:when>
									<xsl:when test="text()">
										<!-- <xsl:value-of select="." /> -->
										<xsl:variable name="escapedHtmlText">
											<xsl:value-of select="esri:striphtml(.)" />
										</xsl:variable>
										<xsl:call-template name="handleURLs">
											<xsl:with-param name="text" select="normalize-space($escapedHtmlText)" />
										</xsl:call-template>
									</xsl:when>
									<xsl:otherwise><p><span class="noContent"><res:idToolNoPythonRefForParam /></span></p></xsl:otherwise>
								</xsl:choose>
							  </xsl:for-each>
							  <xsl:if test="not(pythonReference) and (commandReference)">
								  <xsl:for-each select="commandReference">
									<xsl:if test="position() = 1">
									  <span class="SubContentHeader"><res:idToolParamCommandReference /></span><br />
									</xsl:if>
									<xsl:choose>
										<xsl:when test="(. = '') or not(node())"><p><span class="noContent"><res:idToolNoCommandRefForParam /></span></p></xsl:when>
										<xsl:when test="para or bulletList or bullet_item or indent or subSection or bold or italics">
											<xsl:choose>
												<xsl:when test="not(name(*) != 'bullet_item')">
													<ul>
														<xsl:apply-templates select="*" mode="gp" />
													</ul>
												</xsl:when>
												<xsl:otherwise>
													<xsl:apply-templates select="*" mode="gp" />
												</xsl:otherwise>
											</xsl:choose>
										</xsl:when>
										<xsl:when test=".//text()">
											<xsl:apply-templates select="*" mode="gp" />
										</xsl:when>
										<xsl:when test="text()">
											<!-- <xsl:value-of select="." /> -->
											<xsl:variable name="escapedHtmlText">
												<xsl:value-of select="esri:striphtml(.)" />
											</xsl:variable>
											<xsl:call-template name="handleURLs">
												<xsl:with-param name="text" select="normalize-space($escapedHtmlText)" />
											</xsl:call-template>
										</xsl:when>
										<xsl:otherwise><p><span class="noContent"><res:idToolNoCommandRefForParam /></span></p></xsl:otherwise>
									</xsl:choose>
								  </xsl:for-each>
							  </xsl:if>
						  </xsl:if>
						  <xsl:if test="not(pythonReference or commandReference) and dialogReference"><p><span class="noContent"><res:idToolNoPythonRefForParam /></span></p></xsl:if>
						</td>
						<td class="gp" align="left">
							<xsl:value-of select="@datatype"/>
						</td>
					</tr>
				</xsl:for-each>
		</table>
	</xsl:template>

	<!--The Script Expression -->
	<xsl:template name="Script_Expression">
		<xsl:choose>
			<xsl:when test="@type='Required'">
				<xsl:value-of select="@name"/>
			</xsl:when>
			<xsl:when test="@type='Optional'">
				<xsl:value-of select="@name"/>
				<xsl:text> (</xsl:text>
				<xsl:value-of select="@type"/>
				<xsl:text>) </xsl:text>
			</xsl:when>
			<xsl:when test="@type='Choice'">
				<xsl:value-of select="@name"/>
			</xsl:when>
		</xsl:choose>
	</xsl:template>

	<!-- SCRIPT EXAMPLES-->
	<xsl:template match="scriptExamples" mode="gp">
		<xsl:for-each select="scriptExample">
			<p>
				<xsl:choose>
					<xsl:when test="(title != '')"><span class="span.SubContentHeader"><xsl:value-of select="title" /></span><br/></xsl:when>
					<xsl:otherwise><span class="noContent"><res:idToolCodeSampleNoTitle /></span><br/></xsl:otherwise>
				</xsl:choose>
			</p>
			<xsl:choose>
				<xsl:when test="(para != '')">
					<p>
						<xsl:call-template name="elementSupportingMarkup">
							<xsl:with-param name="ele" select="para" />
						</xsl:call-template>
					</p>
				</xsl:when>
				<xsl:otherwise>
					<p><span class="noContent"><res:idToolCodeSampleNoDescription/></span></p>
				</xsl:otherwise>
			</xsl:choose>
			<div class="gpcode">
				<pre class="gp"><xsl:value-of select="code"/></pre>
			</div>
			<xsl:if test="position() != last()">
				<br/>
			</xsl:if>
		</xsl:for-each>
	</xsl:template>

	<xsl:template match="tool/scriptExample" mode="gp">
		<b><res:idScriptExample/></b><br /><br />
		<div class="gpcode">
			<pre class="gp"><xsl:value-of select="."/></pre>
		</div>
	</xsl:template>

	<!--LINK-->
	<xsl:template match="link" mode="gp">
		<a target="newWindow" class="gp">
			<xsl:attribute name="href">
				<xsl:choose>
					<xsl:when test="contains(@src, 'ARCTOOLBOXHELP')">
						<xsl:call-template name="ToolPath">
							<xsl:with-param name="fullpath" select="@src"/>
						</xsl:call-template>
					</xsl:when>
					<!--The link is a URL that starts with http:// -->
					<xsl:when test="starts-with(@src, 'http://')">
						<xsl:value-of select="@src"/>
					</xsl:when>
					<!-- the ARCTOOLBOXHELP is NOT set -->
					<xsl:otherwise>
						<xsl:text>file://</xsl:text>
						<xsl:value-of select="@src"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:value-of select="."/>
		</a>
	</xsl:template>

	<!--ILLUSTRATION-->
	<xsl:template match="illust" mode="gp">
		<br/>
		<img class="gp">
			<xsl:attribute name="src">
				<xsl:choose>
					<xsl:when test="contains(@src, 'ARCTOOLBOXHELP')">
						<xsl:call-template name="ToolPath">
							<xsl:with-param name="fullpath" select="@src"/>
						</xsl:call-template>
					</xsl:when>
					<xsl:when test="starts-with(@src, 'http://')">
						<xsl:value-of select="@src"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:text>file://</xsl:text>
						<xsl:value-of select="@src"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="alt">
				<xsl:value-of select="@alt"/>
			</xsl:attribute>
		</img>
		<p/>
	</xsl:template>

	<!-- ARCTOOLBOXHELPPATH-->
	<xsl:template name="ToolPath">
		<xsl:param name="fullpath"/>
		<xsl:variable name="afterArcToolBoxHelp">
			<xsl:variable name="tempPath" select="substring-after($fullpath, '/')"/>
			<xsl:choose>
				<xsl:when test="$tempPath !=''">
					<xsl:value-of select="$tempPath"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:value-of select="substring-after($fullpath, '\')"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:variable>
		<xsl:text>file://</xsl:text>
		<xsl:variable name="srcPath">
			<xsl:value-of select="$path"/>
			<xsl:if test="$path !=''">
				<xsl:text>/</xsl:text>
			</xsl:if>
			<xsl:value-of select="$afterArcToolBoxHelp"/>
		</xsl:variable>
		<xsl:value-of select="$srcPath"/>
	</xsl:template>

	<!--CODE -->
	<xsl:template match="code[(. != '')]" mode="gp">
		<pre class="gp">
			<xsl:apply-templates select="*|text()" mode="gp" />
		</pre>
	</xsl:template>

	<!-- BOLD-->
	<xsl:template match="bold" mode="gp">
		<b>
			<xsl:apply-templates select="*|text()" mode="gp" />
		</b>
	</xsl:template>

	<!-- ITALICS-->
	<xsl:template match="italics" mode="gp">
		<i>
			<xsl:apply-templates select="*|text()" mode="gp" />
		</i>
	</xsl:template>

	<!-- PARAGRAPH-->
	<xsl:template match="para[(. != '')]" mode="gp">
		<p class="gp">
			<xsl:apply-templates select="*|text()" mode="gp"/>
		</p>
	</xsl:template>

	<!--BULLETS -->
	<xsl:template match="bulletList[(. != '')]" mode="gp">
		<ul>
			<xsl:apply-templates select="*|text()" mode="gp" />
		</ul>
	</xsl:template>

	<xsl:template match="bullet_item[(. != '')]" mode="gp">
		<li>
			<xsl:apply-templates select="*|text()" mode="gp" />
		</li>
	</xsl:template>

	<!--SUBSECTION-->
	<xsl:template match="subSection" mode="gp">
		<xsl:if test="*">
			<xsl:if test="(@title != '')">
				<p><span class="ContentHeader"><xsl:value-of select="@title"/></span></p>
			</xsl:if>
			<dl class="gp">
				<dd>
					<xsl:apply-templates select="*|text()" mode="gp" />
				</dd>
			</dl>
		</xsl:if>
	</xsl:template>

	<!--INDENT-->
	<xsl:template match="indent" mode="gp">
		<dl class="gp">
			<dd>
				<xsl:apply-templates select="*" mode="gp" />
			</dd>
		</dl>
	</xsl:template>

</xsl:stylesheet>
