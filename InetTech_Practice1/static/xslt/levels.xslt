<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:lvl="http://eng.grammar/entity/level"
>
	<xsl:template match="lvl:levels">
		<html>
			<head>
				<title>English grammar levels</title>
				<link rel="stylesheet" type="text/css" href="css/styles.css"/>
			</head>
			<body>
				<h1 class="title">English grammar levels</h1>
				<ul class="list">
					<xsl:apply-templates select="lvl:level"/>
				</ul>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="lvl:level">
		<li class="list-item">
			<xsl:value-of select="lvl:code"/>: <xsl:value-of select="lvl:name"/>
		</li>
	</xsl:template>

</xsl:stylesheet>
