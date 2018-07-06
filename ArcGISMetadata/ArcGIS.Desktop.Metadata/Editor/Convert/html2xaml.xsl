<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" 
    xmlns:esri="http://www.esri.com/metadata/" 
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes" omit-xml-declaration="yes" />


<!--
<Section xml:space=\"preserve\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">
  <Section FontStyle=\"normal\" TextAlignment=\"left\" Foreground=\"#000000\" FontSize=\"11\" FontFamily=\"microsoft sans serif\" FontWeight=\"normal\">
    <Paragraph><Run FontSize="16">This is a summary Here </Run><Run FontWeight="Bold" FontSize="16">is some more sumary</Run></Paragraph>
  </Section>
</Section>"
-->

  <!-- 
  
  Supported HTML:
  
  DIV
  SPAN
  P
  A
  B
  I
  EM
  
  <DIV STYLE="text-align:Left;font-family:Microsoft Sans Serif;font-style:normal;font-weight:normal;font-size: medium;color:#000000;">
  <DIV>
  <DIV>
  <P>
  <SPAN STYLE="font-size: xx-large;">This is a summary Here </SPAN>
  <SPAN STYLE="font-weight:bold;font-size: xx-large;">is some more sumary</SPAN>
  </P>
  </DIV>
  </DIV>
  </DIV>
  

  -->

  <xsl:template match="/">
    <x:Section
        xml:space="preserve"
        TextAlignment="Left"
        LineHeight="Auto"
        IsHyphenationEnabled="False"
        xml:lang="en-us"
        FlowDirection="LeftToRight"
        NumberSubstitution.CultureSource="Text"
        NumberSubstitution.Substitution="AsCulture"
        FontFamily="Microsoft Sans Serif"
        FontStyle="Normal"
        FontWeight="Normal"
        FontStretch="Normal"
        FontSize="11"
        Foreground="#FF000000"
        Typography.StandardLigatures="True"
        Typography.ContextualLigatures="True"
        Typography.DiscretionaryLigatures="False"
        Typography.HistoricalLigatures="False"
        Typography.AnnotationAlternates="0"
        Typography.ContextualAlternates="True"
        Typography.HistoricalForms="False"
        Typography.Kerning="True"
        Typography.CapitalSpacing="False"
        Typography.CaseSensitiveForms="False"
        Typography.StylisticSet1="False"
        Typography.StylisticSet2="False"
        Typography.StylisticSet3="False"
        Typography.StylisticSet4="False"
        Typography.StylisticSet5="False"
        Typography.StylisticSet6="False"
        Typography.StylisticSet7="False"
        Typography.StylisticSet8="False"
        Typography.StylisticSet9="False"
        Typography.StylisticSet10="False"
        Typography.StylisticSet11="False"
        Typography.StylisticSet12="False"
        Typography.StylisticSet13="False"
        Typography.StylisticSet14="False"
        Typography.StylisticSet15="False"
        Typography.StylisticSet16="False"
        Typography.StylisticSet17="False"
        Typography.StylisticSet18="False"
        Typography.StylisticSet19="False"
        Typography.StylisticSet20="False"
        Typography.Fraction="Normal"
        Typography.SlashedZero="False"
        Typography.MathematicalGreek="False"
        Typography.EastAsianExpertForms="False"
        Typography.Variants="Normal"
        Typography.Capitals="Normal"
        Typography.NumeralStyle="Normal"
        Typography.NumeralAlignment="Normal"
        Typography.EastAsianWidths="Normal"
        Typography.EastAsianLanguage="Normal"
        Typography.StandardSwashes="0"
        Typography.ContextualSwashes="0"
        Typography.StylisticAlternates="0">
        
        <!--
        <Section>
          <Section>
            <Paragraph>
              <Run FontSize="16">This is a summary Here </Run>
              <Run FontWeight="Bold" FontSize="16">is some more sumary</Run>
            </Paragraph>
          </Section>
        </Section>-->
      
      
      
      <xsl:apply-templates select="*" />
    </x:Section>
  </xsl:template> 
  
  <xsl:template match="DIV | PRE | BLOCKQUOTE | CAPTION | CITE">
    <x:Section>

      <xsl:comment>
        <xsl:copy-of select="esri:htmlproperties(.)"/>
        <!--<xsl:apply-templates select="esri:htmlproperties(.)"/>-->
      </xsl:comment>
      <xsl:apply-templates/>
    </x:Section>
  </xsl:template>  
  
  <xsl:template match="P | H1 | H2 | H3 | H4 | H5 | H6 | H7">
    <x:Paragraph>
      <xsl:apply-templates/>
    </x:Paragraph>
  </xsl:template>

  <xsl:template match="SPAN">
    <x:Run>
      <xsl:apply-templates/>
    </x:Run>
  </xsl:template>

  <xsl:template match="text()">
    <xsl:copy/>
  </xsl:template>
  
</xsl:stylesheet>