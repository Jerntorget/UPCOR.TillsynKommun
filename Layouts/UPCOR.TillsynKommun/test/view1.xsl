<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:ma="http://schemas.microsoft.com/office/2009/metadata/properties/metaAttributes" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:dfs="http://schemas.microsoft.com/office/infopath/2003/dataFormSolution" xmlns:my="http://schemas.microsoft.com/office/infopath/2009/WSSList/cmeDataFields" xmlns:d="http://schemas.microsoft.com/office/infopath/2009/WSSList/dataFields" xmlns:pc="http://schemas.microsoft.com/office/infopath/2007/PartnerControls" xmlns:q="http://schemas.microsoft.com/office/infopath/2009/WSSList/queryFields" xmlns:dms="http://schemas.microsoft.com/office/2009/documentManagement/types" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:xdExtension="http://schemas.microsoft.com/office/infopath/2003/xslt/extension" xmlns:xdXDocument="http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument" xmlns:xdSolution="http://schemas.microsoft.com/office/infopath/2003/xslt/solution" xmlns:xdFormatting="http://schemas.microsoft.com/office/infopath/2003/xslt/formatting" xmlns:xdImage="http://schemas.microsoft.com/office/infopath/2003/xslt/xImage" xmlns:xdUtil="http://schemas.microsoft.com/office/infopath/2003/xslt/Util" xmlns:xdMath="http://schemas.microsoft.com/office/infopath/2003/xslt/Math" xmlns:xdDate="http://schemas.microsoft.com/office/infopath/2003/xslt/Date" xmlns:sig="http://www.w3.org/2000/09/xmldsig#" xmlns:xdSignatureProperties="http://schemas.microsoft.com/office/infopath/2003/SignatureProperties" xmlns:ipApp="http://schemas.microsoft.com/office/infopath/2006/XPathExtension/ipApp" xmlns:xdEnvironment="http://schemas.microsoft.com/office/infopath/2006/xslt/environment" xmlns:xdUser="http://schemas.microsoft.com/office/infopath/2006/xslt/User" xmlns:xdServerInfo="http://schemas.microsoft.com/office/infopath/2009/xslt/ServerInfo">
	<xsl:output method="html" indent="no"/>
	<xsl:template match="dfs:myFields">
		<html dir="ltr" xmlns:xsf="http://schemas.microsoft.com/office/infopath/2003/solutionDefinition" xmlns:xsf2="http://schemas.microsoft.com/office/infopath/2006/solutionDefinition/extensions" xmlns:xsf3="http://schemas.microsoft.com/office/infopath/2009/solutionDefinition/extensions" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xhtml="http://www.w3.org/1999/xhtml">
			<head>
				<meta content="text/html" http-equiv="Content-Type"></meta>
				<style controlStyle="controlStyle">@media screen 			{ 			BODY{margin-left:21px;background-position:21px 0px;} 			} 		BODY{color:windowtext;background-color:window;layout-grid:none;} 		.xdListItem {display:inline-block;width:100%;vertical-align:text-top;} 		.xdListBox,.xdComboBox{margin:1px;} 		.xdInlinePicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) } 		.xdLinkedPicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) url(#default#urn::controls/Binder) } 		.xdHyperlinkBox{word-wrap:break-word; text-overflow:ellipsis;overflow-x:hidden; OVERFLOW-Y: hidden; WHITE-SPACE:nowrap; display:inline-block;margin:1px;padding:5px;border: 1pt solid #dcdcdc;color:windowtext;BEHAVIOR: url(#default#urn::controls/Binder) url(#default#DataBindingUI)} 		.xdSection{border:1pt solid transparent ;margin:0px 0px 0px 0px;padding:0px 0px 0px 0px;} 		.xdRepeatingSection{border:1pt solid transparent;margin:0px 0px 0px 0px;padding:0px 0px 0px 0px;} 		.xdMultiSelectList{margin:1px;display:inline-block; border:1pt solid #dcdcdc; padding:1px 1px 1px 5px; text-indent:0; color:windowtext; background-color:window; overflow:auto; behavior: url(#default#DataBindingUI) url(#default#urn::controls/Binder) url(#default#MultiSelectHelper) url(#default#ScrollableRegion);} 		.xdMultiSelectListItem{display:block;white-space:nowrap}		.xdMultiSelectFillIn{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:left;}		.xdBehavior_Formatting {BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting);} 	 .xdBehavior_FormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting);} 	.xdExpressionBox{margin: 1px;padding:1px;word-wrap: break-word;text-overflow: ellipsis;overflow-x:hidden;}.xdBehavior_GhostedText,.xdBehavior_GhostedTextNoBUI{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#TextField) url(#default#GhostedText);}	.xdBehavior_GTFormatting{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_GTFormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_Boolean{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#BooleanHelper);}	.xdBehavior_Select{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#SelectHelper);}	.xdBehavior_ComboBox{BEHAVIOR: url(#default#ComboBox)} 	.xdBehavior_ComboBoxTextField{BEHAVIOR: url(#default#ComboBoxTextField);} 	.xdRepeatingTable{BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word;}.xdScrollableRegion{BEHAVIOR: url(#default#ScrollableRegion);} 		.xdLayoutRegion{display:inline-block;} 		.xdMaster{BEHAVIOR: url(#default#MasterHelper);} 		.xdActiveX{margin:1px; BEHAVIOR: url(#default#ActiveX);} 		.xdFileAttachment{display:inline-block;margin:1px;BEHAVIOR:url(#default#urn::xdFileAttachment);} 		.xdSharePointFileAttachment{display:inline-block;margin:2px;BEHAVIOR:url(#default#xdSharePointFileAttachment);} 		.xdAttachItem{display:inline-block;width:100%%;height:25px;margin:1px;BEHAVIOR:url(#default#xdSharePointFileAttachItem);} 		.xdSignatureLine{display:inline-block;margin:1px;background-color:transparent;border:1pt solid transparent;BEHAVIOR:url(#default#SignatureLine);} 		.xdHyperlinkBoxClickable{behavior: url(#default#HyperlinkBox)} 		.xdHyperlinkBoxButtonClickable{border-width:1px;border-style:outset;behavior: url(#default#HyperlinkBoxButton)} 		.xdPictureButton{background-color: transparent; padding: 0px; behavior: url(#default#PictureButton);} 		.xdPageBreak{display: none;}BODY{margin-right:21px;} 		.xdTextBoxRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:right;word-wrap:normal;} 		.xdRichTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:right;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTTextRTL{height:100%;width:100%;margin-left:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButtonRTL{margin-right:-21px;height:17px;width:20px;behavior: url(#default#DTPicker);} 		.xdMultiSelectFillinRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:right;}.xdTextBox{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:left;word-wrap:normal;} 		.xdRichTextBox{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:left;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTPicker{;display:inline;margin:1px;margin-bottom: 2px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-indent:0; layout-grid: none} 		.xdDTText{height:100%;width:100%;margin-right:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButton{margin-left:-21px;height:17px;width:20px;behavior: url(#default#DTPicker);} 		.xdRepeatingTable TD {VERTICAL-ALIGN: top;}</style>
				<style tableEditor="TableStyleRulesID">TABLE.xdLayout TD {
	BORDER-TOP: medium none; BORDER-RIGHT: medium none; BORDER-BOTTOM: medium none; BORDER-LEFT: medium none
}
TABLE.msoUcTable TD {
	BORDER-TOP: 1pt solid; BORDER-RIGHT: 1pt solid; BORDER-BOTTOM: 1pt solid; BORDER-LEFT: 1pt solid
}
TABLE {
	BEHAVIOR: url (#default#urn::tables/NDTable)
}
</style>
				<style themeStyle="urn:office.microsoft.com:themeOffice">TABLE {
	BORDER-TOP: medium none; BORDER-RIGHT: medium none; BORDER-COLLAPSE: collapse; BORDER-BOTTOM: medium none; BORDER-LEFT: medium none
}
TD {
	BORDER-TOP-COLOR: #d8d8d8; BORDER-BOTTOM-COLOR: #d8d8d8; BORDER-RIGHT-COLOR: #d8d8d8; BORDER-LEFT-COLOR: #d8d8d8
}
TH {
	BORDER-TOP-COLOR: #000000; COLOR: black; BORDER-BOTTOM-COLOR: #000000; BORDER-RIGHT-COLOR: #000000; BACKGROUND-COLOR: #f2f2f2; BORDER-LEFT-COLOR: #000000
}
.xdTableHeader {
	COLOR: black; BACKGROUND-COLOR: #f2f2f2
}
.light1 {
	BACKGROUND-COLOR: #ffffff
}
.dark1 {
	BACKGROUND-COLOR: #000000
}
.light2 {
	BACKGROUND-COLOR: #f6f6f6
}
.dark2 {
	BACKGROUND-COLOR: #182738
}
.accent1 {
	BACKGROUND-COLOR: #0072bc
}
.accent2 {
	BACKGROUND-COLOR: #ec008c
}
.accent3 {
	BACKGROUND-COLOR: #00adee
}
.accent4 {
	BACKGROUND-COLOR: #fd9f08
}
.accent5 {
	BACKGROUND-COLOR: #36b000
}
.accent6 {
	BACKGROUND-COLOR: #fae032
}
</style>
				<style tableStyle="Default">TR.xdTitleRow {
	MIN-HEIGHT: 58px
}
TD.xdTitleCell {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-RIGHT: #d8d8d8 1pt solid; PADDING-BOTTOM: 6px; PADDING-TOP: 18px; PADDING-LEFT: 22px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffffff
}
TR.xdTitleRowWithHeading {
	MIN-HEIGHT: 58px
}
TD.xdTitleCellWithHeading {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-RIGHT: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 18px; PADDING-LEFT: 22px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffffff
}
TR.xdTitleRowWithSubHeading {
	MIN-HEIGHT: 58px
}
TD.xdTitleCellWithSubHeading {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-RIGHT: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 18px; PADDING-LEFT: 22px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffffff
}
TR.xdTitleRowWithOffsetBody {
	MIN-HEIGHT: 58px
}
TD.xdTitleCellWithOffsetBody {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-RIGHT: #d8d8d8 1pt solid; PADDING-BOTTOM: 6px; PADDING-TOP: 18px; PADDING-LEFT: 22px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffffff
}
TR.xdTitleHeadingRow {
	MIN-HEIGHT: 38px
}
TD.xdTitleHeadingCell {
	BORDER-RIGHT: #d8d8d8 1pt solid; PADDING-BOTTOM: 12px; PADDING-TOP: 0px; PADDING-LEFT: 22px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffffff; valign: top
}
TR.xdTitleSubheadingRow {
	MIN-HEIGHT: 67px
}
TD.xdTitleSubheadingCell {
	BORDER-TOP: #243b56 1pt solid; BORDER-RIGHT: #d8d8d8 1pt solid; PADDING-BOTTOM: 18px; PADDING-TOP: 8px; PADDING-LEFT: 22px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffffff
}
TD.xdVerticalFill {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; BORDER-LEFT: #d8d8d8 1pt solid; BACKGROUND-COLOR: #6890be
}
TD.xdTableContentCellWithVerticalOffset {
	BORDER-RIGHT: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 0px; PADDING-TOP: 12px; PADDING-LEFT: 85px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 10px; BACKGROUND-COLOR: #ffffff
}
TR.xdTableContentRow {
	MIN-HEIGHT: 140px
}
TD.xdTableContentCell {
	BORDER-RIGHT: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 0px; BACKGROUND-COLOR: #ffffff
}
TD.xdTableContentCellWithVerticalFill {
	BORDER-RIGHT: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; PADDING-LEFT: 1px; BORDER-LEFT: #d8d8d8 1pt solid; PADDING-RIGHT: 1px; BACKGROUND-COLOR: #ffffff
}
TD.xdTableStyleOneCol {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 22px
}
TR.xdContentRowOneCol {
	MIN-HEIGHT: 45px; valign: center
}
TR.xdHeadingRow {
	MIN-HEIGHT: 36px
}
TD.xdHeadingCell {
	BORDER-BOTTOM: #6890be 1.5pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 6px; PADDING-LEFT: 22px; PADDING-RIGHT: 22px
}
TR.xdSubheadingRow {
	MIN-HEIGHT: 27px
}
TD.xdSubheadingCell {
	BORDER-BOTTOM: #a5a5a5 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 22px
}
TR.xdHeadingRowEmphasis {
	MIN-HEIGHT: 36px
}
TD.xdHeadingCellEmphasis {
	BORDER-BOTTOM: #6890be 1.5pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 6px; PADDING-LEFT: 22px; PADDING-RIGHT: 22px
}
TR.xdSubheadingRowEmphasis {
	MIN-HEIGHT: 27px
}
TD.xdSubheadingCellEmphasis {
	BORDER-BOTTOM: #a5a5a5 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 22px
}
TR.xdTableLabelControlStackedRow {
	MIN-HEIGHT: 45px
}
TD.xdTableLabelControlStackedCellLabel {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px
}
TD.xdTableLabelControlStackedCellComponent {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px
}
TR.xdTableRow {
	MIN-HEIGHT: 30px
}
TD.xdTableCellLabel {
	PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px
}
TD.xdTableCellComponent {
	PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px
}
TD.xdTableMiddleCell {
	PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px
}
TR.xdTableEmphasisRow {
	MIN-HEIGHT: 30px
}
TD.xdTableEmphasisCellLabel {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px; BACKGROUND-COLOR: #f6f6f6
}
TD.xdTableEmphasisCellComponent {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #f6f6f6
}
TD.xdTableMiddleCellEmphasis {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BACKGROUND-COLOR: #f6f6f6
}
TR.xdTableOffsetRow {
	MIN-HEIGHT: 30px
}
TD.xdTableOffsetCellLabel {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px
}
TD.xdTableOffsetCellComponent {
	BORDER-TOP: #d8d8d8 1pt solid; BORDER-BOTTOM: #d8d8d8 1pt solid; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #f6f6f6
}
P {
	FONT-SIZE: 10pt; COLOR: #3f3f3f; MARGIN-TOP: 0px
}
H1 {
	MARGIN-BOTTOM: 0px; FONT-SIZE: 22pt; FONT-WEIGHT: normal; COLOR: #3f3f3f; MARGIN-TOP: 0px
}
H2 {
	MARGIN-BOTTOM: 0px; FONT-SIZE: 15pt; FONT-WEIGHT: normal; COLOR: #262626; MARGIN-TOP: 0px
}
H3 {
	MARGIN-BOTTOM: 0px; FONT-SIZE: 12pt; FONT-WEIGHT: bold; COLOR: #3f3f3f; MARGIN-TOP: 0px
}
H4 {
	MARGIN-BOTTOM: 0px; FONT-SIZE: 10pt; FONT-WEIGHT: normal; COLOR: #3f3f3f; MARGIN-TOP: 0px
}
H5 {
	MARGIN-BOTTOM: 0px; FONT-SIZE: 10pt; FONT-WEIGHT: bold; COLOR: #3f3f3f; MARGIN-TOP: 0px
}
H6 {
	MARGIN-BOTTOM: 0px; FONT-SIZE: 10pt; FONT-WEIGHT: normal; COLOR: #3f3f3f; MARGIN-TOP: 0px
}
BODY {
	COLOR: black
}
</style>
				<style languageStyle="languageStyle">BODY {
	FONT-SIZE: 10pt; FONT-FAMILY: Calibri
}
SELECT {
	FONT-SIZE: 10pt; FONT-FAMILY: Calibri
}
TABLE {
	FONT-SIZE: 10pt; FONT-FAMILY: Calibri; TEXT-TRANSFORM: none; FONT-WEIGHT: normal; COLOR: black; FONT-STYLE: normal
}
.optionalPlaceholder {
	FONT-SIZE: 9pt; FONT-FAMILY: Calibri; FONT-WEIGHT: normal; COLOR: #333333; FONT-STYLE: normal; PADDING-LEFT: 20px; TEXT-DECORATION: none; BEHAVIOR: url(#default#xOptional)
}
.langFont {
	FONT-SIZE: 10pt; FONT-FAMILY: Calibri; WIDTH: 150px
}
.defaultInDocUI {
	FONT-SIZE: 9pt; FONT-FAMILY: Calibri
}
.optionalPlaceholder {
	PADDING-RIGHT: 20px
}
</style>
			</head>
			<body style="DIRECTION: ltr">
				<div align="center">
					<table class="xdFormLayout" style="BORDER-TOP-STYLE: none; WORD-WRAP: break-word; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; TABLE-LAYOUT: fixed; BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; WIDTH: 652px">
						<colgroup>
							<col style="WIDTH: 652px"></col>
						</colgroup>
						<tbody>
							<tr class="xdTableContentRow" style="MIN-HEIGHT: 4px">
								<td vAlign="top" style="BORDER-TOP: #d8d8d8 1pt; BORDER-RIGHT: #d8d8d8 1pt; BORDER-BOTTOM: #d8d8d8 1pt; BORDER-LEFT: #d8d8d8 1pt" class="xdTableContentCell">
									<div> </div>
									<div>
										<table class="xdFormLayout xdTableStyleTwoCol" style="BORDER-TOP-STYLE: none; WORD-WRAP: break-word; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; TABLE-LAYOUT: fixed; BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; WIDTH: 649px">
											<colgroup>
												<col style="WIDTH: 169px"></col>
												<col style="WIDTH: 480px"></col>
											</colgroup>
											<tbody vAlign="top">
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>1. Inledande uppgifter, 19 a §, 23 a och 23 b §§</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Tillsynsbesöket sker</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><xsl:choose>
															<xsl:when test="function-available('ipApp:GetMajorVersion') and ipApp:GetMajorVersion() &gt;= 12">
																<span title="" class="xdMultiSelectList" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%" xd:CtrlId="CTRL63" xd:xctname="multiselectlistbox" xd:boundProp="value" tabIndex="-1" xd:ref="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAnmalt/Value">
																	<xsl:variable name="values" select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAnmalt/Value"/>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynAnmalt/SharePointListChoice_RW">
																		<span class="xdMultiSelectListItem">
																			<input type="checkbox" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																				<xsl:attribute name="xd:value">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="xd:onValue">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="title">
																					<xsl:value-of select="@DisplayName"/>
																				</xsl:attribute>
																				<xsl:if test=".=$values">
																					<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																				</xsl:if>
																			</input>
																			<xsl:value-of select="@DisplayName"/>
																		</span>
																	</xsl:for-each>
																	<xsl:variable name="options" select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynAnmalt/SharePointListChoice_RW/."/>
																	<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAnmalt/Value[not(.=$options)]">
																		<xsl:if test="normalize-space(.)!=''">
																			<span class="xdMultiSelectListItem">
																				<input type="checkbox" CHECKED="CHECKED" xd:onValue="{.}" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																					<xsl:attribute name="xd:value">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																					<xsl:attribute name="title">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																				</input>
																				<xsl:value-of select="."/>
																			</span>
																		</xsl:if>
																	</xsl:for-each>
																</span>
															</xsl:when>
															<xsl:otherwise>
																<span class="xdRepeating" xd:xctname="BulletedList" title="" xd:CtrlId="CTRL63" xd:boundProp="value" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT: auto;">
																	<ol style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LIST-STYLE-TYPE: disc">
																		<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAnmalt/Value">
																			<li>
																				<span class="xdListItem" hideFocus="1" contentEditable="true" xd:CtrlId="CTRL63" xd:xctname="ListItem_Plain" xd:binding="." style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT:auto; WIDTH: 100%; WHITE-SPACE: normal; WORD-WRAP: break-word;" tabIndex="0">
																					<xsl:value-of select="."/>
																				</span>
																			</li>
																		</xsl:for-each>
																	</ol>
																</span>
															</xsl:otherwise>
														</xsl:choose>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Besöket är ett uppföljande tillsynsbesök</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<select title="" class="xdComboBox xdBehavior_Select" style="WIDTH: 100%" size="1" xd:CtrlId="CTRL64" xd:xctname="dropdown" xd:boundProp="value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynUppfoljande" xd:disableEditing="no" value="" tabIndex="0">
															<xsl:attribute name="value">
																<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynUppfoljande"/>
															</xsl:attribute>
															<xsl:choose>
																<xsl:when test="function-available('xdXDocument:GetDOM')">
																	<option/>
																	<xsl:variable name="val" select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynUppfoljande"/>
																	<xsl:if test="not(xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynUppfoljande/SharePointListChoice_RW[.=$val] or $val='')">
																		<option selected="selected">
																			<xsl:attribute name="value">
																				<xsl:value-of select="$val"/>
																			</xsl:attribute>
																			<xsl:value-of select="$val"/>
																		</option>
																	</xsl:if>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynUppfoljande/SharePointListChoice_RW">
																		<option>
																			<xsl:attribute name="value">
																				<xsl:value-of select="."/>
																			</xsl:attribute>
																			<xsl:if test="$val=.">
																				<xsl:attribute name="selected">selected</xsl:attribute>
																			</xsl:if>
																			<xsl:value-of select="@DisplayName"/>
																		</option>
																	</xsl:for-each>
																</xsl:when>
																<xsl:otherwise>
																	<option>
																		<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynUppfoljande"/>
																	</option>
																</xsl:otherwise>
															</xsl:choose>
														</select>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Fotodokumentation sker under tillsynsbesöket</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<select title="" class="xdComboBox xdBehavior_Select" style="WIDTH: 100%" size="1" xd:CtrlId="CTRL65" xd:xctname="dropdown" xd:boundProp="value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynFotodok" xd:disableEditing="no" value="" tabIndex="0">
															<xsl:attribute name="value">
																<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynFotodok"/>
															</xsl:attribute>
															<xsl:choose>
																<xsl:when test="function-available('xdXDocument:GetDOM')">
																	<option/>
																	<xsl:variable name="val" select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynFotodok"/>
																	<xsl:if test="not(xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynFotodok/SharePointListChoice_RW[.=$val] or $val='')">
																		<option selected="selected">
																			<xsl:attribute name="value">
																				<xsl:value-of select="$val"/>
																			</xsl:attribute>
																			<xsl:value-of select="$val"/>
																		</option>
																	</xsl:if>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynFotodok/SharePointListChoice_RW">
																		<option>
																			<xsl:attribute name="value">
																				<xsl:value-of select="."/>
																			</xsl:attribute>
																			<xsl:if test="$val=.">
																				<xsl:attribute name="selected">selected</xsl:attribute>
																			</xsl:if>
																			<xsl:value-of select="@DisplayName"/>
																		</option>
																	</xsl:for-each>
																</xsl:when>
																<xsl:otherwise>
																	<option>
																		<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynFotodok"/>
																	</option>
																</xsl:otherwise>
															</xsl:choose>
														</select>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>2. Tidpunkt för tillsynsbesöket</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Datum</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<div title="" class="xdDTPicker" style="WIDTH: 223px" noWrap="1" xd:CtrlId="CTRL66" xd:xctname="DTPicker"><span class="xdDTText xdBehavior_FormattingNoBUI" hideFocus="1" contentEditable="true" tabIndex="0" xd:xctname="DTPicker_DTText" xd:boundProp="xd:num" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum" xd:disableEditing="no" xd:innerCtrl="_DTText" xd:datafmt="&quot;datetime&quot;,&quot;dateFormat:Short Date;timeFormat:none;&quot;">
																<xsl:attribute name="xd:num">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum"/>
																</xsl:attribute>
																<xsl:choose>
																	<xsl:when test="function-available('xdFormatting:formatString')">
																		<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum,&quot;datetime&quot;,&quot;dateFormat:Short Date;timeFormat:none;&quot;)"/>
																	</xsl:when>
																	<xsl:otherwise>
																		<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum"/>
																	</xsl:otherwise>
																</xsl:choose>
															</span>
															<button class="xdDTButton" xd:xctname="DTPicker_DTButton" xd:innerCtrl="_DTButton" tabIndex="-1">
																<img src="res://infopath.exe/calendar.gif"/>
															</button>
														</div><span title="" class="xdTextBox xdBehavior_Formatting" hideFocus="1" contentEditable="true" tabIndex="0" xd:CtrlId="CTRL67" xd:xctname="PlainText" xd:boundProp="xd:num" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum" xd:disableEditing="no" xd:datafmt="&quot;datetime&quot;,&quot;dateFormat:none;&quot;" style="WIDTH: 223px">
															<xsl:attribute name="xd:num">
																<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum"/>
															</xsl:attribute>
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum,&quot;datetime&quot;,&quot;dateFormat:none;&quot;)"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetDatum"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>3. Tillsynsobjektets kontaktuppgifter, försäljningsstället</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Försäljningsställe</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<select title="" class="xdComboBox xdBehavior_Select" style="WIDTH: 100%" size="1" xd:CtrlId="CTRL68" xd:xctname="dropdown" xd:boundProp="value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetButik" value="" tabIndex="0">
															<xsl:attribute name="value">
																<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetButik"/>
															</xsl:attribute>
															<xsl:choose>
																<xsl:when test="function-available('xdXDocument:GetDOM')">
																	<option/>
																	<xsl:variable name="val" select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetButik"/>
																	<xsl:if test="not(xdXDocument:GetDOM(&quot;Kundkort&quot;)/dfs:myFields/dfs:dataFields/d:SharePointListItem_RW[d:ID=$val] or $val='')">
																		<option selected="selected">
																			<xsl:attribute name="value">
																				<xsl:value-of select="$val"/>
																			</xsl:attribute>
																			<xsl:value-of select="$val"/>
																		</option>
																	</xsl:if>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Kundkort&quot;)/dfs:myFields/dfs:dataFields/d:SharePointListItem_RW">
																		<option>
																			<xsl:attribute name="value">
																				<xsl:value-of select="d:ID"/>
																			</xsl:attribute>
																			<xsl:if test="$val=d:ID">
																				<xsl:attribute name="selected">selected</xsl:attribute>
																			</xsl:if>
																			<xsl:value-of select="d:Title"/>
																		</option>
																	</xsl:for-each>
																</xsl:when>
																<xsl:otherwise>
																	<option>
																		<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetButik"/>
																	</option>
																</xsl:otherwise>
															</xsl:choose>
														</select>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>4. Tillsynsobjektets kontaktuppgifter, ägare/bolag</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Ägare</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<div> </div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>5. Anmälan och egenkontroll 12 c och d §§</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Försäljning anmäld av näringsidkaren</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL69" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringAnmalt" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringAnmalt"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringAnmalt=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Har näringsidkaren anmält försäljning av tobak till kommunen?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Egenkontrollprogram har ingetts av näringsidkaren</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL70" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringIngett" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringIngett"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringIngett=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Har näringsidkaren ingett egenkontrollprogram till kommunen?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Plan har utarbetats av näringsidkaren</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL71" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringPlan" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringPlan"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringPlan=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Om ja, visar egenkontrollsprogrammet att näringsidkaren har utarbetat en plan för att säkerställa att tobakslagens bestämmelser följs i den egna verksamheten?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om nej, ange varför:</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL72" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringPlanVarforInte" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringPlanVarforInte,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynNaringPlanVarforInte" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Aktiv information ges</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL73" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAktivInformation" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAktivInformation"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAktivInformation=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Ges aktiv information och stöd till personalen för att de ska kunna följa tobakslagen och anslutande föreskrifter?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, ange hur och när senaste tillfället var:</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL74" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAktivInformationNar" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynAktivInformationNar,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAktivInformationNar" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Frågor till kassapersonal</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL75" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynPersonalUtbildning" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynPersonalUtbildning"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynPersonalUtbildning=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Har du fått information och utbildning av den försäljningsansvarige om arbetssätt och rutiner för att upprätthålla 18 års åldersgränsen?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, ange hur:</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL76" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynPersonalUtbildningHur" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynPersonalUtbildningHur,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynPersonalUtbildningHur" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>6. Kontroll av åldersgräns, 12 och 12 a §§</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Legitimation kontrolleras</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL77" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimation" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
															<xsl:attribute name="xd:value">
																<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimation"/>
															</xsl:attribute>
															<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimation=&quot;true&quot;">
																<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
															</xsl:if>
														</input>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, under vilken ålder</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL78" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimationAlder" xd:disableEditing="no" style="WIDTH: 100%">
															<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimationAlder"/>
														</span>
														<div>
															<h6 style="FONT-WEIGHT: normal">Om man bedömer att åldern på den som vill köpa är under ___ år så kontrolleras legitimation</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Tydligt skyltat</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><xsl:choose>
															<xsl:when test="function-available('ipApp:GetMajorVersion') and ipApp:GetMajorVersion() &gt;= 12">
																<span title="" class="xdMultiSelectList" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%" xd:CtrlId="CTRL79" xd:xctname="multiselectlistbox" xd:boundProp="value" tabIndex="-1" xd:ref="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSkyltat/Value">
																	<xsl:variable name="values" select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSkyltat/Value"/>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynSkyltat/SharePointListChoice_RW">
																		<span class="xdMultiSelectListItem">
																			<input type="checkbox" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																				<xsl:attribute name="xd:value">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="xd:onValue">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="title">
																					<xsl:value-of select="@DisplayName"/>
																				</xsl:attribute>
																				<xsl:if test=".=$values">
																					<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																				</xsl:if>
																			</input>
																			<xsl:value-of select="@DisplayName"/>
																		</span>
																	</xsl:for-each>
																	<xsl:variable name="options" select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynSkyltat/SharePointListChoice_RW/."/>
																	<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSkyltat/Value[not(.=$options)]">
																		<xsl:if test="normalize-space(.)!=''">
																			<span class="xdMultiSelectListItem">
																				<input type="checkbox" CHECKED="CHECKED" xd:onValue="{.}" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																					<xsl:attribute name="xd:value">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																					<xsl:attribute name="title">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																				</input>
																				<xsl:value-of select="."/>
																			</span>
																		</xsl:if>
																	</xsl:for-each>
																</span>
															</xsl:when>
															<xsl:otherwise>
																<span class="xdRepeating" xd:xctname="BulletedList" title="" xd:CtrlId="CTRL79" xd:boundProp="value" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT: auto;">
																	<ol style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LIST-STYLE-TYPE: disc">
																		<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSkyltat/Value">
																			<li>
																				<span class="xdListItem" hideFocus="1" contentEditable="true" xd:CtrlId="CTRL79" xd:xctname="ListItem_Plain" xd:binding="." style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT:auto; WIDTH: 100%; WHITE-SPACE: normal; WORD-WRAP: break-word;" tabIndex="0">
																					<xsl:value-of select="."/>
																				</span>
																			</li>
																		</xsl:for-each>
																	</ol>
																</span>
															</xsl:otherwise>
														</xsl:choose>
														<div>
															<h6 style="FONT-WEIGHT: normal">Finns en tydlig och klart synbar skylt med information om förbudet mot att sälja eller lämna ut tobaksvaror till den som inte har fyllt 18 år?</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Finns tobaksautomat</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL80" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomat" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
															<xsl:attribute name="xd:value">
																<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomat"/>
															</xsl:attribute>
															<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomat=&quot;true&quot;">
																<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
															</xsl:if>
														</input>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, har automaten godtagbar kontroll</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL81" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomatKontroll" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomatKontroll"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomatKontroll=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Finns det en godtabar kontroll över åldern på den som handlar i automaten?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om nej, ange på vilket sätt kontrollen inte är godtagbar</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL82" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomatKontrollAnledning" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomatKontrollAnledning,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynAutomatKontrollAnledning" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>7. Styckeförsäljningsförbudet, 12 b §</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Styckevis försäljning av cigaretter</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL83" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForekommerStyckevis" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForekommerStyckevis"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForekommerStyckevis=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Förekommer styckevis försäljning av cigaretter?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Förpackningar med färre än 19 cigaretter</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL84" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForekommerUnder19" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForekommerUnder19"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForekommerUnder19=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Förekommer försäljning av förpackningar med färre än 19 cigaretter?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>8. Varningstext och innehållsdeklaration, 9 och 11 §§, samt FHIS 2001:2<sup>2</sup> och 2002:4<sup>3</sup>
																</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Varningstext</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><xsl:choose>
															<xsl:when test="function-available('ipApp:GetMajorVersion') and ipApp:GetMajorVersion() &gt;= 12">
																<span title="" class="xdMultiSelectList" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%" xd:CtrlId="CTRL85" xd:xctname="multiselectlistbox" xd:boundProp="value" tabIndex="-1" xd:ref="dfs:dataFields/my:SharePointListItem_RW/my:tillsynVarningstext/Value">
																	<xsl:variable name="values" select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynVarningstext/Value"/>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynVarningstext/SharePointListChoice_RW">
																		<span class="xdMultiSelectListItem">
																			<input type="checkbox" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																				<xsl:attribute name="xd:value">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="xd:onValue">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="title">
																					<xsl:value-of select="@DisplayName"/>
																				</xsl:attribute>
																				<xsl:if test=".=$values">
																					<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																				</xsl:if>
																			</input>
																			<xsl:value-of select="@DisplayName"/>
																		</span>
																	</xsl:for-each>
																	<xsl:variable name="options" select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynVarningstext/SharePointListChoice_RW/."/>
																	<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynVarningstext/Value[not(.=$options)]">
																		<xsl:if test="normalize-space(.)!=''">
																			<span class="xdMultiSelectListItem">
																				<input type="checkbox" CHECKED="CHECKED" xd:onValue="{.}" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																					<xsl:attribute name="xd:value">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																					<xsl:attribute name="title">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																				</input>
																				<xsl:value-of select="."/>
																			</span>
																		</xsl:if>
																	</xsl:for-each>
																</span>
															</xsl:when>
															<xsl:otherwise>
																<span class="xdRepeating" xd:xctname="BulletedList" title="" xd:CtrlId="CTRL85" xd:boundProp="value" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT: auto;">
																	<ol style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LIST-STYLE-TYPE: disc">
																		<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynVarningstext/Value">
																			<li>
																				<span class="xdListItem" hideFocus="1" contentEditable="true" xd:CtrlId="CTRL85" xd:xctname="ListItem_Plain" xd:binding="." style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT:auto; WIDTH: 100%; WHITE-SPACE: normal; WORD-WRAP: break-word;" tabIndex="0">
																					<xsl:value-of select="."/>
																				</span>
																			</li>
																		</xsl:for-each>
																	</ol>
																</span>
															</xsl:otherwise>
														</xsl:choose>
														<div>
															<h6 style="FONT-WEIGHT: normal">Under tillsynsbesöket påträffas tobaksförpackningar (Obs! Även tobak till vattenpipa.)</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>9. Marknadsföring, 14 och 14 a §§ KOVFS 2009:7<sup>4</sup>
																</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Påträngande kommersiella meddelanden</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL86" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamPatrangande" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamPatrangande"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamPatrangande=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Finns det kommersiella meddelanden som är påträngande, uppsökande eller uppmanar till bruk av tobak inne på försäljningsstället?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, beskriv på vilket sätt</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL87" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamPatrangandeBeskrivning" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamPatrangandeBeskrivning,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamPatrangandeBeskrivning" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
														<div>
															<h6 style="FONT-WEIGHT: normal">Beskriv på vilket sätt som de av tillsynshandläggaren uppfattas såsom påträngande, uppsökande eller uppmanar till bruk av tobak</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Kommersiella meddelanden utanför</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL88" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamUtanfor" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamUtanfor"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamUtanfor=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Finns det kommersiella meddelanden utanför försäljningsstället eller som är synliga utifrån</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, beskriv</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL89" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamUtanforBeskrivning" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamUtanforBeskrivning,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamUtanforBeskrivning" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Kommersiella meddelandena gjorda av reklambyrå</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL90" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamByra" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamByra"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamByra=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Är de kommersiella meddelandena gjorda av en tillverkare/importör/säljagent/reklambyrå?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Ange om möjligt vilken tillverkare/importör/säljagent/reklambyrå</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL91" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamByraVilken" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamByraVilken,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamByraVilken" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
														<div>
															<h6 style="FONT-WEIGHT: normal">Ange om möjligt vilken tillverkare/importör/säljagent/reklambyrå</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Butiken sponsrad</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL92" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSponsrad" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSponsrad"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSponsrad=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Upplevs butiken som stylad eller sponsrad av en tillverkare/importör/säljagent/reklambyrå?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, vilken tillverkare/importör/säljagent/reklambyrå</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL93" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSponsradVilken" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynSponsradVilken,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSponsradVilken" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
														<div>
															<h6 style="FONT-WEIGHT: normal">Ange om möjligt vilken tillverkare/importör/säljagent/reklambyrå och på vilket sätt</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Handskrivna kommersiella meddelanden</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL94" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamHandskriven" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamHandskriven"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamHandskriven=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Är de kommersiella meddelandena handskrivna av butiksägaren själv?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, beskriv hur de har uttryckt sig</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL95" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamHandskrivenBeskrivning" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamHandskrivenBeskrivning,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynReklamHandskrivenBeskrivning" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
														<div>
															<h6 style="FONT-WEIGHT: normal">Lägg märke till och beskriv hur den som skrivit meddelandena uttryckt sig, bedöm sakligheten</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Bildskärmar med kommersiella meddelanden</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL96" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynBildskarmar" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynBildskarmar"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynBildskarmar=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Finns bildskärmar med kommersiella meddelanden?</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om ja, beskriv gärna dem</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL97" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynBildskarmarBeskrivning" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynBildskarmarBeskrivning,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynBildskarmarBeskrivning" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
														<div>
															<h6 style="FONT-WEIGHT: normal">Beskriv gärna storlek, placering och budskap samt allmänt intryck. Finns det ljud till bilden som påkallar uppmärksamhet?</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>10. Förebyggande åtgärder</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Förebyggande åtgärder</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><xsl:choose>
															<xsl:when test="function-available('ipApp:GetMajorVersion') and ipApp:GetMajorVersion() &gt;= 12">
																<span title="" class="xdMultiSelectList" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%" xd:CtrlId="CTRL98" xd:xctname="multiselectlistbox" xd:boundProp="value" tabIndex="-1" xd:ref="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForebyggandeAtgarder/Value">
																	<xsl:variable name="values" select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForebyggandeAtgarder/Value"/>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynForebyggandeAtgarder/SharePointListChoice_RW">
																		<span class="xdMultiSelectListItem">
																			<input type="checkbox" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																				<xsl:attribute name="xd:value">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="xd:onValue">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="title">
																					<xsl:value-of select="@DisplayName"/>
																				</xsl:attribute>
																				<xsl:if test=".=$values">
																					<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																				</xsl:if>
																			</input>
																			<xsl:value-of select="@DisplayName"/>
																		</span>
																	</xsl:for-each>
																	<xsl:variable name="options" select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynForebyggandeAtgarder/SharePointListChoice_RW/."/>
																	<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForebyggandeAtgarder/Value[not(.=$options)]">
																		<xsl:if test="normalize-space(.)!=''">
																			<span class="xdMultiSelectListItem">
																				<input type="checkbox" CHECKED="CHECKED" xd:onValue="{.}" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																					<xsl:attribute name="xd:value">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																					<xsl:attribute name="title">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																				</input>
																				<xsl:value-of select="."/>
																			</span>
																		</xsl:if>
																	</xsl:for-each>
																</span>
															</xsl:when>
															<xsl:otherwise>
																<span class="xdRepeating" xd:xctname="BulletedList" title="" xd:CtrlId="CTRL98" xd:boundProp="value" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT: auto;">
																	<ol style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LIST-STYLE-TYPE: disc">
																		<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForebyggandeAtgarder/Value">
																			<li>
																				<span class="xdListItem" hideFocus="1" contentEditable="true" xd:CtrlId="CTRL98" xd:xctname="ListItem_Plain" xd:binding="." style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT:auto; WIDTH: 100%; WHITE-SPACE: normal; WORD-WRAP: break-word;" tabIndex="0">
																					<xsl:value-of select="."/>
																				</span>
																			</li>
																		</xsl:for-each>
																	</ol>
																</span>
															</xsl:otherwise>
														</xsl:choose>
														<div>
															<h6 style="FONT-WEIGHT: normal">Under tillsynsbesöket överlämnades följande materiel</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Om annat materiel, ange vad</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL99" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForebyggandeAtgarderAnnat" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynForebyggandeAtgarderAnnat,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynForebyggandeAtgarderAnnat" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Legitimationskontroll i kassan</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<h6 style="FONT-WEIGHT: normal"><input title="" class="xdBehavior_Boolean" type="checkbox" value="" tabIndex="0" xd:CtrlId="CTRL100" xd:xctname="CheckBox" xd:boundProp="xd:value" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimationKassa" xd:disableEditing="no" xd:onValue="true" xd:offValue="false">
																<xsl:attribute name="xd:value">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimationKassa"/>
																</xsl:attribute>
																<xsl:if test="dfs:dataFields/my:SharePointListItem_RW/my:tillsynLegitimationKassa=&quot;true&quot;">
																	<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																</xsl:if>
															</input>Finns legitimationskontroll inbyggt i kassasystemet? Om Nej, informera gärna näringsidkaren om fördelarna med att ha ett sådant kassasystem.</h6>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>11. Sammanfattning av besöket</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Sammanfattning av besöket</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><xsl:choose>
															<xsl:when test="function-available('ipApp:GetMajorVersion') and ipApp:GetMajorVersion() &gt;= 12">
																<span title="" class="xdMultiSelectList" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%" xd:CtrlId="CTRL101" xd:xctname="multiselectlistbox" xd:boundProp="value" tabIndex="-1" xd:ref="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSammanfattning/Value">
																	<xsl:variable name="values" select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSammanfattning/Value"/>
																	<xsl:for-each select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynSammanfattning/SharePointListChoice_RW">
																		<span class="xdMultiSelectListItem">
																			<input type="checkbox" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																				<xsl:attribute name="xd:value">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="xd:onValue">
																					<xsl:value-of select="."/>
																				</xsl:attribute>
																				<xsl:attribute name="title">
																					<xsl:value-of select="@DisplayName"/>
																				</xsl:attribute>
																				<xsl:if test=".=$values">
																					<xsl:attribute name="CHECKED">CHECKED</xsl:attribute>
																				</xsl:if>
																			</input>
																			<xsl:value-of select="@DisplayName"/>
																		</span>
																	</xsl:for-each>
																	<xsl:variable name="options" select="xdXDocument:GetDOM(&quot;Alternativdataanslutning&quot;)/root/tillsynSammanfattning/SharePointListChoice_RW/."/>
																	<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSammanfattning/Value[not(.=$options)]">
																		<xsl:if test="normalize-space(.)!=''">
																			<span class="xdMultiSelectListItem">
																				<input type="checkbox" CHECKED="CHECKED" xd:onValue="{.}" xd:boundProp="xd:value" xd:binding="." xd:xctname="CheckBox" tabIndex="0">
																					<xsl:attribute name="xd:value">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																					<xsl:attribute name="title">
																						<xsl:value-of select="."/>
																					</xsl:attribute>
																				</input>
																				<xsl:value-of select="."/>
																			</span>
																		</xsl:if>
																	</xsl:for-each>
																</span>
															</xsl:when>
															<xsl:otherwise>
																<span class="xdRepeating" xd:xctname="BulletedList" title="" xd:CtrlId="CTRL101" xd:boundProp="value" style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT: auto;">
																	<ol style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LIST-STYLE-TYPE: disc">
																		<xsl:for-each select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynSammanfattning/Value">
																			<li>
																				<span class="xdListItem" hideFocus="1" contentEditable="true" xd:CtrlId="CTRL101" xd:xctname="ListItem_Plain" xd:binding="." style="HEIGHT: 100px; TEXT-ALIGN: left; WIDTH: 100%; HEIGHT:auto; WIDTH: 100%; WHITE-SPACE: normal; WORD-WRAP: break-word;" tabIndex="0">
																					<xsl:value-of select="."/>
																				</span>
																			</li>
																		</xsl:for-each>
																	</ol>
																</span>
															</xsl:otherwise>
														</xsl:choose>
														<div>
															<h6 style="FONT-WEIGHT: normal">Under tillsynsbesöket uppmärksammades brister gällande</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>12 Tillsynshandläggarens anteckningar i övrigt vad som sker under besöket</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Övriga anteckningar</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent"><span title="" class="xdTextBox" hideFocus="1" tabIndex="0" xd:CtrlId="CTRL105" xd:xctname="PlainText" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetNotering" xd:disableEditing="no" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="WORD-WRAP: break-word; HEIGHT: 50px; WHITE-SPACE: normal; OVERFLOW-X: auto; OVERFLOW-Y: auto; WIDTH: 100%">
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:aktivitetNotering,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:aktivitetNotering" disable-output-escaping="yes"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel"></span> </h4>
													</td>
												</tr>
												<tr class="xdTableOffsetRow" style="MIN-HEIGHT: 30px">
													<td colSpan="2" style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; BORDER-BOTTOM-COLOR: ; PADDING-TOP: 4px; PADDING-LEFT: 22px; BORDER-RIGHT-COLOR: ; PADDING-RIGHT: 22px; BACKGROUND-COLOR: #ffff00" class="xdTableOffsetCellLabel">
														<h3 style="FONT-WEIGHT: normal">
															<span class="xdlabel">
																<strong>13. Tillsynsprotokollet ifyllt, avslutande uppgifter</strong>
															</span>
														</h3>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Tillsynshandläggare</span>
														</h4>
													</td>
													<td style="BORDER-TOP-COLOR: ; VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<object class="xdActiveX" hideFocus="1" style="HEIGHT: 22px; WIDTH: 100%" tabIndex="0" xd:disableEditing="no" xd:SharePointGroup="0" xd:SearchPeopleOnly="true" xd:AllowMultiple="true" xd:boundProp="xd:inline" xd:bindingProperty="Value" xd:bindingType="xmlNode" xd:server="http://web1.upcor.se/sites/blg47/" xd:CtrlId="CTRL102" xd:xctname="{{61e40d31-993d-4777-8fa0-19ca59b6d0bb}}" tabStop="true" classid="clsid:61e40d31-993d-4777-8fa0-19ca59b6d0bb" contentEditable="false" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynHandlaggare">
															<xsl:if test="function-available('xdImage:getImageUrl')">
																<xsl:attribute name="src"><xsl:value-of select="xdImage:getImageUrl(dfs:dataFields/my:SharePointListItem_RW/my:tillsynHandlaggare)"/></xsl:attribute>
															</xsl:if>
															<param NAME="ButtonFont" VALUE="Verdana,10,0,400,0,0,0"/>
															<param NAME="ButtonText" VALUE=""/>
															<param NAME="DisplayNameXPath" VALUE="pc:DisplayName"/>
															<param NAME="ObjectIdXPath" VALUE="pc:AccountId"/>
															<param NAME="ObjectTypeXPath" VALUE="pc:AccountType"/>
															<param NAME="SiteUrlXPath" VALUE="/Context/@siteUrl"/>
															<param NAME="SiteUrlDataSource" VALUE="Context"/>
															<param NAME="NewNodeTemplate" VALUE="&lt;pc:Person&gt;&#xA; &lt;pc:DisplayName&gt;&lt;/pc:DisplayName&gt;&#xA; &lt;pc:AccountId&gt;&lt;/pc:AccountId&gt;&#xA; &lt;pc:AccountType&gt;&lt;/pc:AccountType&gt;&#xA;&lt;/pc:Person&gt;"/>
															<param NAME="BackgroundColor" VALUE="2147483653"/>
															<param NAME="MaxLines" VALUE="4"/>
															<param NAME="Direction" VALUE="0"/>
														</object>
														<div>
															<h6 style="FONT-WEIGHT: normal">Ange de personer som utfört tillsynen eller mottagit kontakten med försäljningsstället</h6>
														</div>
													</td>
												</tr>
												<tr class="xdTableOffsetRow">
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 22px; PADDING-RIGHT: 5px" class="xdTableOffsetCellLabel">
														<h4>
															<span class="xdlabel">Sluttid besök</span>
														</h4>
													</td>
													<td style="VERTICAL-ALIGN: top; PADDING-BOTTOM: 4px; PADDING-TOP: 4px; PADDING-LEFT: 5px; PADDING-RIGHT: 22px" class="xdTableOffsetCellComponent">
														<div title="" class="xdDTPicker" style="WIDTH: 223px" noWrap="1" xd:CtrlId="CTRL103" xd:xctname="DTPicker"><span class="xdDTText xdBehavior_FormattingNoBUI" hideFocus="1" contentEditable="true" tabIndex="0" xd:xctname="DTPicker_DTText" xd:boundProp="xd:num" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan" xd:disableEditing="no" xd:innerCtrl="_DTText" xd:datafmt="&quot;datetime&quot;,&quot;dateFormat:Short Date;timeFormat:none;&quot;">
																<xsl:attribute name="xd:num">
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan"/>
																</xsl:attribute>
																<xsl:choose>
																	<xsl:when test="function-available('xdFormatting:formatString')">
																		<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan,&quot;datetime&quot;,&quot;dateFormat:Short Date;timeFormat:none;&quot;)"/>
																	</xsl:when>
																	<xsl:otherwise>
																		<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan"/>
																	</xsl:otherwise>
																</xsl:choose>
															</span>
															<button class="xdDTButton" xd:xctname="DTPicker_DTButton" xd:innerCtrl="_DTButton" tabIndex="-1">
																<img src="res://infopath.exe/calendar.gif"/>
															</button>
														</div><span title="" class="xdTextBox xdBehavior_Formatting" hideFocus="1" contentEditable="true" tabIndex="0" xd:CtrlId="CTRL104" xd:xctname="PlainText" xd:boundProp="xd:num" xd:binding="dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan" xd:disableEditing="no" xd:datafmt="&quot;datetime&quot;,&quot;dateFormat:none;&quot;" style="WIDTH: 223px">
															<xsl:attribute name="xd:num">
																<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan"/>
															</xsl:attribute>
															<xsl:choose>
																<xsl:when test="function-available('xdFormatting:formatString')">
																	<xsl:value-of select="xdFormatting:formatString(dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan,&quot;datetime&quot;,&quot;dateFormat:none;&quot;)"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="dfs:dataFields/my:SharePointListItem_RW/my:tillsynTillKlockan"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
														<div>
															<h6 style="FONT-WEIGHT: normal">Tillsynsbesöket pågick till klockan</h6>
														</div>
													</td>
												</tr>
											</tbody>
										</table>
									</div>
									<div> </div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
