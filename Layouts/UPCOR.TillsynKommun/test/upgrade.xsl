<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:dfs="http://schemas.microsoft.com/office/infopath/2003/dataFormSolution" xmlns:d="http://schemas.microsoft.com/office/infopath/2009/WSSList/dataFields" xmlns:pc="http://schemas.microsoft.com/office/infopath/2007/PartnerControls" xmlns:ma="http://schemas.microsoft.com/office/2009/metadata/properties/metaAttributes" xmlns:q="http://schemas.microsoft.com/office/infopath/2009/WSSList/queryFields" xmlns:dms="http://schemas.microsoft.com/office/2009/documentManagement/types" xmlns:my="http://schemas.microsoft.com/office/infopath/2009/WSSList/cmeDataFields" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" version="1.0">
	<xsl:output encoding="UTF-8" method="xml"/>
	<xsl:template match="/">
		<xsl:copy-of select="processing-instruction() | comment()"/>
		<xsl:choose>
			<xsl:when test="dfs:myFields">
				<xsl:apply-templates select="dfs:myFields" mode="_0"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:variable name="var">
					<xsl:element name="dfs:myFields"/>
				</xsl:variable>
				<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_0"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template match="q:SharePointListItem_RW" mode="_2">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:element name="q:ID">
				<xsl:choose>
					<xsl:when test="q:ID/text()[1]">
						<xsl:copy-of select="q:ID/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:Title">
				<xsl:choose>
					<xsl:when test="q:Title/text()[1]">
						<xsl:copy-of select="q:Title/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:Author">
				<xsl:choose>
					<xsl:when test="q:Author/text()[1]">
						<xsl:copy-of select="q:Author/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:Editor">
				<xsl:choose>
					<xsl:when test="q:Editor/text()[1]">
						<xsl:copy-of select="q:Editor/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:Modified">
				<xsl:choose>
					<xsl:when test="q:Modified/text()[1]">
						<xsl:copy-of select="q:Modified/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:Created">
				<xsl:choose>
					<xsl:when test="q:Created/text()[1]">
						<xsl:copy-of select="q:Created/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynUppfoljande">
				<xsl:choose>
					<xsl:when test="q:tillsynUppfoljande/text()[1]">
						<xsl:copy-of select="q:tillsynUppfoljande/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynFotodok">
				<xsl:choose>
					<xsl:when test="q:tillsynFotodok/text()[1]">
						<xsl:copy-of select="q:tillsynFotodok/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:aktivitetDatum">
				<xsl:choose>
					<xsl:when test="q:aktivitetDatum/text()[1]">
						<xsl:copy-of select="q:aktivitetDatum/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:aktivitetButik">
				<xsl:choose>
					<xsl:when test="q:aktivitetButik/text()[1]">
						<xsl:copy-of select="q:aktivitetButik/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynNaringAnmalt">
				<xsl:choose>
					<xsl:when test="q:tillsynNaringAnmalt/text()[1]">
						<xsl:copy-of select="q:tillsynNaringAnmalt/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynNaringIngett">
				<xsl:choose>
					<xsl:when test="q:tillsynNaringIngett/text()[1]">
						<xsl:copy-of select="q:tillsynNaringIngett/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynNaringPlan">
				<xsl:choose>
					<xsl:when test="q:tillsynNaringPlan/text()[1]">
						<xsl:copy-of select="q:tillsynNaringPlan/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynAktivInformation">
				<xsl:choose>
					<xsl:when test="q:tillsynAktivInformation/text()[1]">
						<xsl:copy-of select="q:tillsynAktivInformation/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynPersonalUtbildning">
				<xsl:choose>
					<xsl:when test="q:tillsynPersonalUtbildning/text()[1]">
						<xsl:copy-of select="q:tillsynPersonalUtbildning/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynLegitimation">
				<xsl:choose>
					<xsl:when test="q:tillsynLegitimation/text()[1]">
						<xsl:copy-of select="q:tillsynLegitimation/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynLegitimationAlder">
				<xsl:choose>
					<xsl:when test="q:tillsynLegitimationAlder/text()[1]">
						<xsl:copy-of select="q:tillsynLegitimationAlder/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynAutomat">
				<xsl:choose>
					<xsl:when test="q:tillsynAutomat/text()[1]">
						<xsl:copy-of select="q:tillsynAutomat/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynAutomatKontroll">
				<xsl:choose>
					<xsl:when test="q:tillsynAutomatKontroll/text()[1]">
						<xsl:copy-of select="q:tillsynAutomatKontroll/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynForekommerStyckevis">
				<xsl:choose>
					<xsl:when test="q:tillsynForekommerStyckevis/text()[1]">
						<xsl:copy-of select="q:tillsynForekommerStyckevis/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynForekommerUnder19">
				<xsl:choose>
					<xsl:when test="q:tillsynForekommerUnder19/text()[1]">
						<xsl:copy-of select="q:tillsynForekommerUnder19/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynReklamPatrangande">
				<xsl:choose>
					<xsl:when test="q:tillsynReklamPatrangande/text()[1]">
						<xsl:copy-of select="q:tillsynReklamPatrangande/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynReklamUtanfor">
				<xsl:choose>
					<xsl:when test="q:tillsynReklamUtanfor/text()[1]">
						<xsl:copy-of select="q:tillsynReklamUtanfor/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynReklamByra">
				<xsl:choose>
					<xsl:when test="q:tillsynReklamByra/text()[1]">
						<xsl:copy-of select="q:tillsynReklamByra/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynSponsrad">
				<xsl:choose>
					<xsl:when test="q:tillsynSponsrad/text()[1]">
						<xsl:copy-of select="q:tillsynSponsrad/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynReklamHandskriven">
				<xsl:choose>
					<xsl:when test="q:tillsynReklamHandskriven/text()[1]">
						<xsl:copy-of select="q:tillsynReklamHandskriven/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynBildskarmar">
				<xsl:choose>
					<xsl:when test="q:tillsynBildskarmar/text()[1]">
						<xsl:copy-of select="q:tillsynBildskarmar/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynLegitimationKassa">
				<xsl:choose>
					<xsl:when test="q:tillsynLegitimationKassa/text()[1]">
						<xsl:copy-of select="q:tillsynLegitimationKassa/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="q:tillsynTillKlockan">
				<xsl:choose>
					<xsl:when test="q:tillsynTillKlockan/text()[1]">
						<xsl:copy-of select="q:tillsynTillKlockan/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="dfs:queryFields" mode="_1">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="q:SharePointListItem_RW">
					<xsl:apply-templates select="q:SharePointListItem_RW[1]" mode="_2"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="q:SharePointListItem_RW"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_2"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="pc:Person" mode="_6">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:element name="pc:DisplayName">
				<xsl:copy-of select="pc:DisplayName/text()[1]"/>
			</xsl:element>
			<xsl:element name="pc:AccountId">
				<xsl:copy-of select="pc:AccountId/text()[1]"/>
			</xsl:element>
			<xsl:element name="pc:AccountType">
				<xsl:copy-of select="pc:AccountType/text()[1]"/>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:Author" mode="_5">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="pc:Person">
					<xsl:apply-templates select="pc:Person" mode="_6"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="pc:Person"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_6"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:Editor" mode="_7">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="pc:Person">
					<xsl:apply-templates select="pc:Person" mode="_6"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="pc:Person"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_6"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="attachmentURL" mode="_9">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:copy-of select="./text()[1]"/>
			<xsl:copy-of select="./@xsi:nil"/>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:Attachments" mode="_8">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:apply-templates select="attachmentURL" mode="_9"/>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="Value" mode="_11">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:copy-of select="./text()[1]"/>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:tillsynAnmalt" mode="_10">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="Value">
					<xsl:apply-templates select="Value" mode="_11"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="Value"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_11"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:tillsynSkyltat" mode="_12">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="Value">
					<xsl:apply-templates select="Value" mode="_11"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="Value"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_11"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:tillsynVarningstext" mode="_13">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="Value">
					<xsl:apply-templates select="Value" mode="_11"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="Value"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_11"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:tillsynForebyggandeAtgarder" mode="_14">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="Value">
					<xsl:apply-templates select="Value" mode="_11"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="Value"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_11"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:tillsynSammanfattning" mode="_15">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="Value">
					<xsl:apply-templates select="Value" mode="_11"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="Value"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_11"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:tillsynHandlaggare" mode="_16">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="pc:Person">
					<xsl:apply-templates select="pc:Person" mode="_6"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="pc:Person"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_6"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="my:SharePointListItem_RW" mode="_4">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:element name="my:ID">
				<xsl:choose>
					<xsl:when test="my:ID/text()[1]">
						<xsl:copy-of select="my:ID/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:Title">
				<xsl:copy-of select="my:Title/text()[1]"/>
			</xsl:element>
			<xsl:choose>
				<xsl:when test="my:Author">
					<xsl:apply-templates select="my:Author[1]" mode="_5"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:Author"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_5"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="my:Editor">
					<xsl:apply-templates select="my:Editor[1]" mode="_7"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:Editor"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_7"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="my:Modified">
				<xsl:choose>
					<xsl:when test="my:Modified/text()[1]">
						<xsl:copy-of select="my:Modified/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:Created">
				<xsl:choose>
					<xsl:when test="my:Created/text()[1]">
						<xsl:copy-of select="my:Created/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:choose>
				<xsl:when test="my:Attachments">
					<xsl:apply-templates select="my:Attachments[1]" mode="_8"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:Attachments"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_8"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="my:tillsynAnmalt">
					<xsl:apply-templates select="my:tillsynAnmalt[1]" mode="_10"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:tillsynAnmalt"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_10"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="my:tillsynUppfoljande">
				<xsl:copy-of select="my:tillsynUppfoljande/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynFotodok">
				<xsl:copy-of select="my:tillsynFotodok/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:aktivitetDatum">
				<xsl:choose>
					<xsl:when test="my:aktivitetDatum/text()[1]">
						<xsl:copy-of select="my:aktivitetDatum/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:aktivitetButik">
				<xsl:copy-of select="my:aktivitetButik/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynNaringAnmalt">
				<xsl:choose>
					<xsl:when test="my:tillsynNaringAnmalt/text()[1]">
						<xsl:copy-of select="my:tillsynNaringAnmalt/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynNaringIngett">
				<xsl:choose>
					<xsl:when test="my:tillsynNaringIngett/text()[1]">
						<xsl:copy-of select="my:tillsynNaringIngett/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynNaringPlan">
				<xsl:choose>
					<xsl:when test="my:tillsynNaringPlan/text()[1]">
						<xsl:copy-of select="my:tillsynNaringPlan/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynNaringPlanVarforInte">
				<xsl:copy-of select="my:tillsynNaringPlanVarforInte/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynAktivInformation">
				<xsl:choose>
					<xsl:when test="my:tillsynAktivInformation/text()[1]">
						<xsl:copy-of select="my:tillsynAktivInformation/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynAktivInformationNar">
				<xsl:copy-of select="my:tillsynAktivInformationNar/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynPersonalUtbildning">
				<xsl:choose>
					<xsl:when test="my:tillsynPersonalUtbildning/text()[1]">
						<xsl:copy-of select="my:tillsynPersonalUtbildning/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynPersonalUtbildningHur">
				<xsl:copy-of select="my:tillsynPersonalUtbildningHur/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynLegitimation">
				<xsl:choose>
					<xsl:when test="my:tillsynLegitimation/text()[1]">
						<xsl:copy-of select="my:tillsynLegitimation/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynLegitimationAlder">
				<xsl:copy-of select="my:tillsynLegitimationAlder/text()[1]"/>
			</xsl:element>
			<xsl:choose>
				<xsl:when test="my:tillsynSkyltat">
					<xsl:apply-templates select="my:tillsynSkyltat[1]" mode="_12"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:tillsynSkyltat"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_12"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="my:tillsynAutomat">
				<xsl:choose>
					<xsl:when test="my:tillsynAutomat/text()[1]">
						<xsl:copy-of select="my:tillsynAutomat/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynAutomatKontroll">
				<xsl:choose>
					<xsl:when test="my:tillsynAutomatKontroll/text()[1]">
						<xsl:copy-of select="my:tillsynAutomatKontroll/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynAutomatKontrollAnledning">
				<xsl:copy-of select="my:tillsynAutomatKontrollAnledning/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynForekommerStyckevis">
				<xsl:choose>
					<xsl:when test="my:tillsynForekommerStyckevis/text()[1]">
						<xsl:copy-of select="my:tillsynForekommerStyckevis/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynForekommerUnder19">
				<xsl:choose>
					<xsl:when test="my:tillsynForekommerUnder19/text()[1]">
						<xsl:copy-of select="my:tillsynForekommerUnder19/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:choose>
				<xsl:when test="my:tillsynVarningstext">
					<xsl:apply-templates select="my:tillsynVarningstext[1]" mode="_13"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:tillsynVarningstext"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_13"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="my:tillsynReklamPatrangande">
				<xsl:choose>
					<xsl:when test="my:tillsynReklamPatrangande/text()[1]">
						<xsl:copy-of select="my:tillsynReklamPatrangande/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynReklamPatrangandeBeskrivning">
				<xsl:copy-of select="my:tillsynReklamPatrangandeBeskrivning/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynReklamUtanfor">
				<xsl:choose>
					<xsl:when test="my:tillsynReklamUtanfor/text()[1]">
						<xsl:copy-of select="my:tillsynReklamUtanfor/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynReklamUtanforBeskrivning">
				<xsl:copy-of select="my:tillsynReklamUtanforBeskrivning/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynReklamByra">
				<xsl:choose>
					<xsl:when test="my:tillsynReklamByra/text()[1]">
						<xsl:copy-of select="my:tillsynReklamByra/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynReklamByraVilken">
				<xsl:copy-of select="my:tillsynReklamByraVilken/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynSponsrad">
				<xsl:choose>
					<xsl:when test="my:tillsynSponsrad/text()[1]">
						<xsl:copy-of select="my:tillsynSponsrad/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynSponsradVilken">
				<xsl:copy-of select="my:tillsynSponsradVilken/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynReklamHandskriven">
				<xsl:choose>
					<xsl:when test="my:tillsynReklamHandskriven/text()[1]">
						<xsl:copy-of select="my:tillsynReklamHandskriven/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynReklamHandskrivenBeskrivning">
				<xsl:copy-of select="my:tillsynReklamHandskrivenBeskrivning/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynBildskarmar">
				<xsl:choose>
					<xsl:when test="my:tillsynBildskarmar/text()[1]">
						<xsl:copy-of select="my:tillsynBildskarmar/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:tillsynBildskarmarBeskrivning">
				<xsl:copy-of select="my:tillsynBildskarmarBeskrivning/text()[1]"/>
			</xsl:element>
			<xsl:choose>
				<xsl:when test="my:tillsynForebyggandeAtgarder">
					<xsl:apply-templates select="my:tillsynForebyggandeAtgarder[1]" mode="_14"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:tillsynForebyggandeAtgarder"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_14"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="my:tillsynForebyggandeAtgarderAnnat">
				<xsl:copy-of select="my:tillsynForebyggandeAtgarderAnnat/text()[1]"/>
			</xsl:element>
			<xsl:element name="my:tillsynLegitimationKassa">
				<xsl:choose>
					<xsl:when test="my:tillsynLegitimationKassa/text()[1]">
						<xsl:copy-of select="my:tillsynLegitimationKassa/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:choose>
				<xsl:when test="my:tillsynSammanfattning">
					<xsl:apply-templates select="my:tillsynSammanfattning[1]" mode="_15"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:tillsynSammanfattning"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_15"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="my:tillsynHandlaggare">
					<xsl:apply-templates select="my:tillsynHandlaggare[1]" mode="_16"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:tillsynHandlaggare"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_16"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="my:tillsynTillKlockan">
				<xsl:choose>
					<xsl:when test="my:tillsynTillKlockan/text()[1]">
						<xsl:copy-of select="my:tillsynTillKlockan/text()[1]"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:attribute name="xsi:nil">true</xsl:attribute>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="my:aktivitetNotering">
				<xsl:copy-of select="my:aktivitetNotering/text()[1]"/>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="dfs:dataFields" mode="_3">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="my:SharePointListItem_RW">
					<xsl:apply-templates select="my:SharePointListItem_RW[1]" mode="_4"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="my:SharePointListItem_RW"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_4"/>
				</xsl:otherwise>
			</xsl:choose>
		</xsl:copy>
	</xsl:template>
	<xsl:template match="dfs:myFields" mode="_0">
		<xsl:copy>
			<xsl:copy-of select="@*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'urn:schemas-microsoft-com:xml-msdata' or namespace-uri() = 'urn:schemas-microsoft-com:xml-diffgram-v1']"/>
			<xsl:choose>
				<xsl:when test="dfs:queryFields">
					<xsl:apply-templates select="dfs:queryFields[1]" mode="_1"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="dfs:queryFields"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_1"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="dfs:dataFields">
					<xsl:apply-templates select="dfs:dataFields[1]" mode="_3"/>
				</xsl:when>
				<xsl:otherwise>
					<xsl:variable name="var">
						<xsl:element name="dfs:dataFields"/>
					</xsl:variable>
					<xsl:apply-templates select="msxsl:node-set($var)/*" mode="_3"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:copy-of select="*[namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/adomapping' or namespace-uri() = 'http://schemas.microsoft.com/office/infopath/2003/changeTracking']"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>