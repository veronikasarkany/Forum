<%@ Control Language="C#" AutoEventWireup="True" EnableViewState="false" CodeBehind="SimilarTopics.ascx.cs"
    Inherits="YAF.Controls.SimilarTopics" %>
<%@ Import Namespace="YAF.Types.Interfaces" %>
<%@ Import Namespace="YAF.Core" %>

<asp:PlaceHolder id="SimilarTopicsHolder" runat="server" Visible="true">
    <asp:Repeater ID="Topics" runat="server" Visible="true">
        <HeaderTemplate>
            <div class="col-xl-12">
            <div class="card">
                <div class="card-header">
                    <YAF:LocalizedLabel runat="server" LocalizedPage="POSTS" LocalizedTag="SIMILAR_TOPICS"></YAF:LocalizedLabel>
                </div>
            <ul class="list-group list-group-flush">
        </HeaderTemplate>
        <ItemTemplate>
            <li class="list-group-item">
                   <a href="<%# DataBinder.Eval(Container.DataItem, "TopicUrl")%>"
                       class="post_link">
                       <strong><%# this.Get<IBadWordReplace>().Replace(this.HtmlEncode(DataBinder.Eval(Container.DataItem, "Topic"))) %></strong>
                   </a> (<a href="<%# DataBinder.Eval(Container.DataItem, "ForumUrl")%>"><%# DataBinder.Eval(Container.DataItem, "ForumName") %></a>)
                   
                   <YAF:LocalizedLabel runat="server" LocalizedPage="SEARCH" LocalizedTag="BY">
                   </YAF:LocalizedLabel> 
                    <YAF:UserLink ID="UserName" runat="server" 
                       UserID='<%# DataBinder.Eval(Container.DataItem, "UserId") %>' 
                       ReplaceName='<%# DataBinder.Eval(Container.DataItem, this.Get<YafBoardSettings>().EnableDisplayName ? "UserDisplayName" : "UserName") %>' 
                       Style='<%# DataBinder.Eval(Container.DataItem, "UserStyle") %>'>
                      </YAF:UserLink>
                      <YAF:DisplayDateTime ID="CreatedDate" runat="server"
                          Format="BothTopic" DateTime='<%# DataBinder.Eval(Container.DataItem, "Posted") %>'>
                      </YAF:DisplayDateTime>
            </li>
        </ItemTemplate>
        <FooterTemplate>
                </ul>
            </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:PlaceHolder>