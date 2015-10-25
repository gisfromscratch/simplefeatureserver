<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title><xsl:value-of select="//ServerFolder/Name"/>:</title>
        <link href="static/css/main.css" rel="stylesheet" type="text/css"></link>
      </head>
      <body>HUHU</body>
    </html>
  </xsl:template>
</xsl:stylesheet>