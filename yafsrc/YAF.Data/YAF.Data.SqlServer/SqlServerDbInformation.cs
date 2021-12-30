﻿/* Yet Another Forum.NET
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

namespace YAF.Data.SqlServer
{
    using ServiceStack.OrmLite;

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using YAF.Core.Data;
    using YAF.Types;
    using YAF.Types.Interfaces.Data;
    using YAF.Types.Models;

    using Config = YAF.Configuration.Config;

    /// <summary>
    /// MySQL DB Information
    /// </summary>
    public class SqlServerDbInformation : IDbInformation
    {
        /// <summary>
        /// The YAF Provider Upgrade script list
        /// </summary>
        private static readonly string[] IdentityUpgradeScriptList = {
            "mssql/upgrade/identity/upgrade.sql"
        };

        /// <summary>
        /// The DB parameters
        /// </summary>
        private readonly DbConnectionParam[] connectionParameters = {
            new(0, "Password", string.Empty),
            new(1, "Data Source", "(local)"),
            new(2, "Initial Catalog", string.Empty),
            new(11, "Use Integrated Security", "true")
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDbInformation"/> class.
        /// </summary>
        public SqlServerDbInformation()
        {
            this.ConnectionString = () => Config.ConnectionString;
            this.ProviderName = SqlServerDbAccess.ProviderTypeName;
        }

        /// <summary>
        /// Gets or sets the DB Connection String
        /// </summary>
        public Func<string> ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the DB Provider Name
        /// </summary>
        public string ProviderName { get; protected set; }

        /// <summary>
        /// Gets the YAF Provider Upgrade Script List.
        /// </summary>
        public IEnumerable<string> IdentityUpgradeScripts => IdentityUpgradeScriptList;

        /// <summary>
        /// Gets the DB Connection Parameters.
        /// </summary>
        public IDbConnectionParam[] DbConnectionParameters =>
            this.connectionParameters.OfType<IDbConnectionParam>().ToArray();

        /// <summary>
        /// Builds a connection string.
        /// </summary>
        /// <param name="parameters">The Connection Parameters</param>
        /// <returns>Returns the Connection String</returns>
        public string BuildConnectionString([NotNull] IEnumerable<IDbConnectionParam> parameters)
        {
            var connectionParams = parameters.ToList();

            CodeContracts.VerifyNotNull(connectionParams);

            var connBuilder = new SqlConnectionStringBuilder();

            connectionParams.ForEach(param => connBuilder[param.Name] = param.Value);

            return connBuilder.ConnectionString;
        }

        /// <summary>
        /// Create Table Views
        /// </summary>
        /// <param name="dbAccess">
        /// The database access.
        /// </param>
        /// <param name="dbCommand">
        /// The database command.
        /// </param>
        public bool CreateViews(IDbAccess dbAccess, IDbCommand dbCommand)
        {
            var vaccessGroupSelect = new StringBuilder();

            vaccessGroupSelect.Append(" select ");

            vaccessGroupSelect.Append("e.BoardID,");
            vaccessGroupSelect.Append("b.UserID,");
            vaccessGroupSelect.Append("c.ForumID,");
            vaccessGroupSelect.Append("d.AccessMaskID,");
            vaccessGroupSelect.Append("b.GroupID,");
            vaccessGroupSelect.Append("ReadAccess = convert(int,d.Flags & 1),");
            vaccessGroupSelect.Append("PostAccess = convert(int,d.Flags & 2),");
            vaccessGroupSelect.Append("ReplyAccess = convert(int,d.Flags & 4),");
            vaccessGroupSelect.Append("PriorityAccess = convert(int,d.Flags & 8),");
            vaccessGroupSelect.Append("PollAccess = convert(int,d.Flags & 16),");
            vaccessGroupSelect.Append("VoteAccess = convert(int,d.Flags & 32),");
            vaccessGroupSelect.Append("ModeratorAccess = convert(int,d.Flags & 64),");
            vaccessGroupSelect.Append("EditAccess = convert(int,d.Flags & 128),");
            vaccessGroupSelect.Append("DeleteAccess = convert(int,d.Flags & 256),");
            vaccessGroupSelect.Append("UploadAccess = convert(int,d.Flags & 512),");
            vaccessGroupSelect.Append("DownloadAccess = convert(int,d.Flags & 1024),");
            vaccessGroupSelect.Append("AdminGroup = convert(int,e.Flags & 1)");

            vaccessGroupSelect.Append(" from");

            vaccessGroupSelect.AppendFormat(
                " [{0}].[{1}UserGroup] b",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessGroupSelect.AppendFormat(
                " INNER JOIN [{0}].[{1}ForumAccess] c on c.GroupID=b.GroupID",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessGroupSelect.AppendFormat(
                " INNER JOIN [{0}].[{1}AccessMask] d on d.AccessMaskID=c.AccessMaskID",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessGroupSelect.AppendFormat(
                " INNER JOIN [{0}].[{1}Group] e on e.GroupID=b.GroupID",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);

            dbCommand.Connection.CreateView<vaccess_group>(vaccessGroupSelect);

            var vaccessNullSelect = new StringBuilder();

            vaccessNullSelect.Append(" select ");

            vaccessNullSelect.Append("a.UserID,");
            vaccessNullSelect.Append("ForumID = convert(int,0),");
            vaccessNullSelect.Append("GroupID = convert(int,0),");
            vaccessNullSelect.Append("AccessMaskID = convert(int, 0),");
            vaccessNullSelect.Append("ReadAccess = convert(int, 0),");
            vaccessNullSelect.Append("PostAccess = convert(int, 0),");
            vaccessNullSelect.Append("ReplyAccess = convert(int, 0),");
            vaccessNullSelect.Append("PriorityAccess = convert(int, 0),");
            vaccessNullSelect.Append("PollAccess = convert(int, 0),");
            vaccessNullSelect.Append("VoteAccess = convert(int, 0),");
            vaccessNullSelect.Append("ModeratorAccess = convert(int, 0),");
            vaccessNullSelect.Append("EditAccess = convert(int, 0),");
            vaccessNullSelect.Append("DeleteAccess = convert(int, 0),");
            vaccessNullSelect.Append("UploadAccess = convert(int, 0),");
            vaccessNullSelect.Append("DownloadAccess = convert(int, 0),");
            vaccessNullSelect.Append("AdminGroup = convert(int, 0)");

            vaccessNullSelect.Append(" from");

            vaccessNullSelect.AppendFormat(" [{0}].[{1}User] a", Config.DatabaseOwner, Config.DatabaseObjectQualifier);

            dbCommand.Connection.CreateView<vaccess_null>(vaccessNullSelect);

            var vaccessUserSelect = new StringBuilder();

            vaccessUserSelect.Append(" select ");

            vaccessUserSelect.Append("b.UserID,");
            vaccessUserSelect.Append("b.ForumID,");
            vaccessUserSelect.Append("c.AccessMaskID,");
            vaccessUserSelect.Append("GroupID = convert(int, 0),");
            vaccessUserSelect.Append("ReadAccess = convert(int, c.Flags & 1),");
            vaccessUserSelect.Append("PostAccess = convert(int, c.Flags & 2),");
            vaccessUserSelect.Append("ReplyAccess = convert(int, c.Flags & 4),");
            vaccessUserSelect.Append("PriorityAccess = convert(int, c.Flags & 8),");
            vaccessUserSelect.Append("PollAccess = convert(int, c.Flags & 16),");
            vaccessUserSelect.Append("VoteAccess = convert(int, c.Flags & 32),");
            vaccessUserSelect.Append("ModeratorAccess = convert(int, c.Flags & 64),");
            vaccessUserSelect.Append("EditAccess = convert(int, c.Flags & 128),");
            vaccessUserSelect.Append("DeleteAccess = convert(int, c.Flags & 256),");
            vaccessUserSelect.Append("UploadAccess = convert(int, c.Flags & 512),");
            vaccessUserSelect.Append("DownloadAccess = convert(int, c.Flags & 1024),");
            vaccessUserSelect.Append("AdminGroup = convert(int, 0)");

            vaccessUserSelect.Append(" from");
            vaccessUserSelect.AppendFormat(
                " [{0}].[{1}UserForum] b",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessUserSelect.AppendFormat(
                " INNER JOIN [{0}].[{1}AccessMask] c on c.AccessMaskID=b.AccessMaskID",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);

            dbCommand.Connection.CreateView<vaccess_user>(vaccessUserSelect);

            var vaccessFullSelect = new StringBuilder();

            vaccessFullSelect.Append(" select ");

            vaccessFullSelect.Append("UserID,ForumID,");
            vaccessFullSelect.Append("MAX(ReadAccess) AS ReadAccess,");
            vaccessFullSelect.Append("MAX(PostAccess) AS PostAccess,");
            vaccessFullSelect.Append("MAX(ReplyAccess) AS ReplyAccess,");
            vaccessFullSelect.Append("MAX(PriorityAccess) AS PriorityAccess,");
            vaccessFullSelect.Append("MAX(PollAccess) AS PollAccess,");
            vaccessFullSelect.Append("MAX(VoteAccess) AS VoteAccess,");
            vaccessFullSelect.Append("MAX(ModeratorAccess) AS ModeratorAccess,");
            vaccessFullSelect.Append("MAX(EditAccess) AS EditAccess,");
            vaccessFullSelect.Append("MAX(DeleteAccess) AS DeleteAccess,");
            vaccessFullSelect.Append("MAX(UploadAccess) AS UploadAccess,");
            vaccessFullSelect.Append("MAX(DownloadAccess) AS DownloadAccess,");
            vaccessFullSelect.Append("MAX(AdminGroup) as AdminGroup");

            vaccessFullSelect.Append(" FROM ( select");

            vaccessFullSelect.Append(
                " UserID, ForumID, ReadAccess, PostAccess, ReplyAccess, PriorityAccess, PollAccess, VoteAccess, ModeratorAccess,");
            vaccessFullSelect.Append(" EditAccess, DeleteAccess, UploadAccess, DownloadAccess, AdminGroup");

            vaccessFullSelect.Append(" from ");
            vaccessFullSelect.AppendFormat(
                "[{0}].[{1}vaccess_user] b",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);

            vaccessFullSelect.Append(" union all select ");

            vaccessFullSelect.Append(
                " UserID, ForumID, ReadAccess, PostAccess, ReplyAccess, PriorityAccess, PollAccess, VoteAccess, ModeratorAccess,");
            vaccessFullSelect.Append(" EditAccess, DeleteAccess, UploadAccess, DownloadAccess, AdminGroup");

            vaccessFullSelect.Append(" from ");
            vaccessFullSelect.AppendFormat(
                "[{0}].[{1}vaccess_group] b",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);

            vaccessFullSelect.Append(" union all select ");

            vaccessFullSelect.Append(
                " UserID, ForumID, ReadAccess, PostAccess, ReplyAccess, PriorityAccess, PollAccess, VoteAccess, ModeratorAccess,");
            vaccessFullSelect.Append(" EditAccess, DeleteAccess, UploadAccess, DownloadAccess, AdminGroup");

            vaccessFullSelect.Append(" from ");
            vaccessFullSelect.AppendFormat(
                "[{0}].[{1}vaccess_null] b",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);

            vaccessFullSelect.Append(" ) access GROUP BY UserID,ForumID");

            dbCommand.Connection.CreateView<vaccessfull>(vaccessFullSelect);

            var vaccessSelect = new StringBuilder();

            vaccessSelect.Append(" select ");

            vaccessSelect.Append(" UserID = a.UserID,");
            vaccessSelect.Append("ForumID = x.ForumID,");
            vaccessSelect.Append("IsAdmin = max(convert(int, b.Flags & 1)),");
            vaccessSelect.Append("IsForumModerator = max(convert(int, b.Flags & 8)),");

            vaccessSelect.AppendFormat(
                "IsModerator = (select count(1) from[{0}].[{1}UserGroup] v1,",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessSelect.AppendFormat("[{0}].[{1}Group] w2,", Config.DatabaseOwner, Config.DatabaseObjectQualifier);
            vaccessSelect.AppendFormat(
                "[{0}].[{1}ForumAccess] x,",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessSelect.AppendFormat("[{0}].[{1}AccessMask] y", Config.DatabaseOwner, Config.DatabaseObjectQualifier);
            vaccessSelect.Append(" where v1.UserID = a.UserID and w2.GroupID = v1.GroupID and x.GroupID = w2.GroupID");
            vaccessSelect.Append(" and y.AccessMaskID = x.AccessMaskID and(y.Flags & 64) <> 0),");

            vaccessSelect.Append("ReadAccess = max(x.ReadAccess),");
            vaccessSelect.Append("PostAccess = max(x.PostAccess),");
            vaccessSelect.Append("ReplyAccess = max(x.ReplyAccess),");
            vaccessSelect.Append("PriorityAccess = max(x.PriorityAccess),");
            vaccessSelect.Append("PollAccess = max(x.PollAccess),");
            vaccessSelect.Append("VoteAccess = max(x.VoteAccess),");
            vaccessSelect.Append("ModeratorAccess = max(x.ModeratorAccess),");
            vaccessSelect.Append("EditAccess = max(x.EditAccess),");
            vaccessSelect.Append("DeleteAccess = max(x.DeleteAccess),");
            vaccessSelect.Append("UploadAccess = max(x.UploadAccess),");
            vaccessSelect.Append("DownloadAccess = max(x.DownloadAccess)");

            vaccessSelect.Append(" from");

            vaccessSelect.AppendFormat(
                " [{0}].[{1}vaccessfull] as x WITH(NOLOCK)",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessSelect.AppendFormat(
                " INNER JOIN [{0}].[{1}UserGroup] a WITH(NOLOCK) on a.UserID=x.UserID",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);
            vaccessSelect.AppendFormat(
                " INNER JOIN [{0}].[{1}Group] b WITH(NOLOCK) on b.GroupID=a.GroupID",
                Config.DatabaseOwner,
                Config.DatabaseObjectQualifier);

            vaccessSelect.Append(" GROUP BY a.UserID,x.ForumID");

            dbCommand.Connection.CreateView<vaccess>(vaccessSelect);

            return true;
        }

        /// <summary>
        /// Create Indexes on Table Views
        /// </summary>
        /// <param name="dbAccess">
        /// The database access.
        /// </param>
        /// <param name="dbCommand">
        /// The database command.
        /// </param>
        public bool CreateIndexViews(IDbAccess dbAccess, IDbCommand dbCommand)
        {
            var selectSql = @"[UserID] ASC,
                              [ForumID] ASC,
                              [AccessMaskID] ASC,
                              [GroupID] ASC";

            dbCommand.Connection.CreateViewIndex<vaccess_user>("UserForum_PK", selectSql);
            dbCommand.Connection.CreateViewIndex<vaccess_null>("UserForum_PK", selectSql);
            dbCommand.Connection.CreateViewIndex<vaccess_group>("UserForum_PK", selectSql);

            return true;
        }
    }
}