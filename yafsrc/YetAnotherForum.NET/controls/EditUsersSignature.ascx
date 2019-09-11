﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="YAF.Controls.EditUsersSignature" Codebehind="EditUsersSignature.ascx.cs" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.HtmlControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="YAF" %>
<%@ Import Namespace="YAF.Classes" %>
<%@ Import Namespace="YAF.Configuration" %>
<%@ Import Namespace="YAF.Web.Controls" %>

<h2 runat="server" id="trHeader">
    <YAF:LocalizedLabel runat="server" 
                        LocalizedPage="CP_SIGNATURE" 
                        LocalizedTag="title" />
</h2>
<hr />
<h4>
<YAF:LocalizedLabel ID="LocalizedLabel3" runat="server" 
                    LocalizedPage="CP_SIGNATURE"
                    LocalizedTag="SIGNATURE_PREVIEW" />
</h4>
<div class="card">
    <div class="card-body mb-3">
        <asp:PlaceHolder id="PreviewLine" runat="server">
        </asp:PlaceHolder>
    </div>
</div>
<asp:PlaceHolder id="EditorLine" runat="server">
            <!-- editor goes here -->
</asp:PlaceHolder>
<hr />
<YAF:Alert runat="server" Type="info">
    <h2>
        <YAF:LocalizedLabel ID="LocalizedLabel2" runat="server" 
                            LocalizedPage="CP_SIGNATURE"
                            LocalizedTag="SIGNATURE_PERMISSIONS" />
    </h2>
    <hr />
    <div class="text-break">
        <asp:Label ID="TagsAllowedWarning" runat="server" />
    </div>
</YAF:Alert>
<div class="text-lg-center">
    <YAF:ThemeButton ID="preview" runat="server"
                     Type="Secondary"
                     Icon="image"
                     TextLocalizedTag="PREVIEW"/>
    <YAF:ThemeButton ID="save" runat="server"
                     Type="Primary" 
                     TextLocalizedTag="SAVE"
                     Icon="save"/>&nbsp;
    <YAF:ThemeButton ID="cancel" runat="server"
                     Type="Secondary" 
                     Icon="reply"
                     TextLocalizedTag="CANCEL"/>
</div>