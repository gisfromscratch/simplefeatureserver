<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:i="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:d="http://schemas.datacontract.org/2004/07/GIS.Services.Data">
  <xsl:template match="d:Catalog">
    <html>
      <head>
        <title>
          REST Services Version: <xsl:value-of select="d:currentVersion"/>
        </title>
        <link href="static/css/main.css" rel="stylesheet" type="text/css"></link>
      </head>
      <body>
        <!-- Header-->
        <table class="userTable" width="100%">
          <tbody>
            <tr>
              <td class="titlecell">REST Services Directory</td>
              <td align="right">Experimental</td>
            </tr>
          </tbody>
        </table>

        <!-- Navigation -->
        <table class="navTable" width="100%">
          <tbody>
            <tr valign="top">
              <td class="breadcrumbs">
                <a href="{url}">Home</a>&gt;<a href="{url}">services</a>
              </td>
              <td align="right">
                <a href="/sdk/rest/02ss/02ss00000057000000.htm" target="_blank">Help</a> | <a href="/rest/services?f=help" target="_blank">API Reference</a>
              </td>
            </tr>
          </tbody>
        </table>

        <!-- API -->
        <table>
          <tbody>
            <tr>
              <td class="apiref">
                <a href="{url}?f=pjson" target="_blank">JSON</a>
              </td>
            </tr>
          </tbody>
        </table>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>