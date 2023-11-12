<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:eng="http://eng.grammar/entity/topic"
>
	<xsl:output method="html" encoding="UTF-8"/>
	
	<xsl:template match="eng:topics">
		<html>
			<head>
				<title>English grammar topics</title>
				<link rel="stylesheet" type="text/css" href="style.css"/>
			</head>
			<body>
				<div class="container">
					<h1 class="title">English grammar catalog</h1>
					<div class="list">
						<xsl:apply-templates select="eng:topic"/>
					</div>
				</div>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="eng:topic">
		<div class="list-item">
			<p class="p-medium">Topic: <xsl:value-of select="eng:name"/></p>
			<xsl:apply-templates select="eng:level"/>
			<p class="p-small"><xsl:value-of select="eng:content"/></p>
			<p class="p-small">Exercises:</p>
			<xsl:apply-templates select="eng:exercises"/>
				
		</div>
	</xsl:template>

	<xsl:template match="eng:level">
		<p class="p-small"><xsl:value-of select="eng:code"/>: <xsl:value-of select="eng:name"/></p>
	</xsl:template>
	
	<xsl:template match="eng:exercises">
		<ol class="numbered-list">
			<xsl:apply-templates select="eng:exercise"/>
		</ol>
	</xsl:template>

	<xsl:template match="eng:exercise">
		<li>
			<p class="margin-small">Type: <xsl:value-of select="eng:type"/></p>
			<p class="margin-small">Task: <xsl:value-of select="eng:task"/></p>
			<p class="margin-small">Answer: <xsl:value-of select="eng:answer"/></p>
		</li>
	</xsl:template>
</xsl:stylesheet>
