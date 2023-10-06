<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:ex="http://eng.grammar/entity/exercise"
>

	<xsl:template match="ex:exercises">
		<html>
			<head>
				<title>English grammar exercises</title>
				<link rel="stylesheet" type="text/css" href="./css/styles.css"/>
			</head>
			<body>
				<h1 class="title">English grammar exercises</h1>
				<h3 class="subtitle">Translate sentences into English:</h3>
				<ol>
					<xsl:apply-templates select="ex:exercise[ex:type='Translation']"/>
				</ol>
				<h3 class="subtitle">Choose if statements are true or false:</h3>
				<ol>
					<xsl:apply-templates select="ex:exercise[ex:type='True/false']"/>
				</ol>
				<h3 class="subtitle">Correct the mistake:</h3>
				<ol>
					<xsl:apply-templates select="ex:exercise[ex:type='Correct the mistake']"/>
				</ol>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="ex:exercise">
		<li class="list-item">
			<p>
				Task: <xsl:value-of select="ex:task"/>
			</p>
			<p>
				Answer: <xsl:value-of select="ex:answer"/>
			</p>
		</li>
	</xsl:template>

</xsl:stylesheet>

