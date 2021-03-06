/* Yet Another Forum.NET
 * Copyright (C) 2003-2005 Bjørnar Henden
 * Copyright (C) 2006-2013 Jaben Cargman
 * Copyright (C) 2014-2022 Ingo Herbote
 * https://www.yetanotherforum.net/
 * 
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at

 * https://www.apache.org/licenses/LICENSE-2.0

 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

namespace YAF.Dialogs;

using YAF.Types.Models;

/// <summary>
/// The Nntp Server Add/Edit Dialog.
/// </summary>
public partial class NntpServerEdit : BaseUserControl
{
    /// <summary>
    /// Gets or sets the server identifier.
    /// </summary>
    /// <value>
    /// The server identifier.
    /// </value>
    public int? ServerId
    {
        get => this.ViewState["ServerId"].ToType<int?>();

        set => this.ViewState["ServerId"] = value;
    }

    /// <summary>
    /// Binds the data.
    /// </summary>
    /// <param name="serverId">The server identifier.</param>
    public void BindData(int? serverId)
    {
        this.ServerId = serverId;

        this.Title.LocalizedPage = "ADMIN_EDITNNTPSERVER";
        this.Save.TextLocalizedPage = "ADMIN_NNTPSERVERS";

        if (this.ServerId.HasValue)
        {
            // Edit
            var row = this.GetRepository<NntpServer>().GetById(this.ServerId.Value);

            this.Name.Text = row.Name;
            this.Address.Text = row.Address;
            this.Port.Text = row.Port.ToString();
            this.UserName.Text = row.UserName;
            this.UserPass.Text = row.UserPass;

            this.Title.LocalizedTag = "TITLE_EDIT";
            this.Save.TextLocalizedTag = "SAVE";
        }
        else
        {
            // Add
            this.Name.Text = string.Empty;
            this.Address.Text = string.Empty;
            this.Port.Text = "119";
            this.UserName.Text = string.Empty;
            this.UserPass.Text = string.Empty;

            this.Title.LocalizedTag = "TITLE";
            this.Save.TextLocalizedTag = "NEW_SERVER";
        }
    }

    /// <summary>
    /// The page_ load.
    /// </summary>
    /// <param name="sender">
    /// The sender. 
    /// </param>
    /// <param name="e">
    /// The e. 
    /// </param>
    protected void Page_Load([NotNull] object sender, [NotNull] EventArgs e)
    {
        if (!this.IsPostBack)
        {
            return;
        }

        this.PageBoardContext.PageElements.RegisterJsBlockStartup(
            "loadValidatorFormJs",
            JavaScriptBlocks.FormValidatorJs(this.Save.ClientID));
    }

    /// <summary>
    /// Handles the Click event of the Add control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Save_OnClick([NotNull] object sender, [NotNull] EventArgs e)
    {
        if (!this.Page.IsValid)
        {
            return;
        }

        this.GetRepository<NntpServer>().Save(
            this.ServerId,
            this.PageBoardContext.PageBoardID,
            this.Name.Text,
            this.Address.Text,
            this.Port.Text.Length > 0 ? this.Port.Text.ToType<int?>() : null,
            this.UserName.Text.Length > 0 ? this.UserName.Text : null,
            this.UserPass.Text.Length > 0 ? this.UserPass.Text : null);

        this.Get<LinkBuilder>().Redirect(ForumPages.Admin_NntpServers);
    }
}