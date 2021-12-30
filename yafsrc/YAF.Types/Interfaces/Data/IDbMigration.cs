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
namespace YAF.Types.Interfaces.Data
{
    using System.Data;

    /// <summary>
    /// The Database Migration interface.
    /// </summary>
    public interface IDbMigration
    {
        /// <summary>
        /// The migrate database.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        void MigrateDatabase(IDbAccess dbAccess);

        /// <summary>
        /// The upgrade table access mask.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableAccessMask(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table active.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableActive(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table active access.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableActiveAccess(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table activity.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableActivity(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table admin page user access.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableAdminPageUserAccess(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table attachment.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableAttachment(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table banned email.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableBannedEmail(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table BannedIP.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableBannedIP(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table banned name.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableBannedName(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table bb code.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableBBCode(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table board.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableBoard(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table buddy.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableBuddy(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table category.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableCategory(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table check email.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableCheckEmail(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table choice.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableChoice(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table event log.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableEventLog(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table favorite topic.
        /// </summary>
        /// <param name="dbAccess">
        /// The Database access.
        /// </param>
        /// <param name="dbCommand">
        /// The Database command.
        /// </param>
        void UpgradeTableFavoriteTopic(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table forum.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableForum(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table forum access.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableForumAccess(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table forum read tracking.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableForumReadTracking(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table group.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableGroup(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table group medal.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableGroupMedal(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table ignore user.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableIgnoreUser(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table medal.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableMedal(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table message.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableMessage(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table message history.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableMessageHistory(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table message reported.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableMessageReported(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table message reported audit.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableMessageReportedAudit(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade tables nntp forum.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTablesNntpForum(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade tables nntp server.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTablesNntpServer(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade tables nntp topic.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTablesNntpTopic(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table PMessage.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTablePMessage(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table poll.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTablePoll(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table poll vote.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTablePollVote(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table profile custom.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableProfileCustom(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table profile definition.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableProfileDefinition(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table rank.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableRank(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table registry.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableRegistry(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table replace_ words.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableReplace_Words(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table reputation vote.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableReputationVote(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table spam_ words.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableSpam_Words(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table tag.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableTag(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table thanks.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableThanks(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table topic.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableTopic(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table topic read tracking.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableTopicReadTracking(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table topic tag.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableTopicTag(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table user.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableUser(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table user album.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableUserAlbum(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table user album image.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableUserAlbumImage(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table user forum.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableUserForum(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table user group.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableUserGroup(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table UserPMessage.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableUserPMessage(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table watch forum.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableWatchForum(IDbAccess dbAccess, IDbCommand dbCommand);

        /// <summary>
        /// The upgrade table watch topic.
        /// </summary>
        /// <param name="dbAccess">
        /// The db access.
        /// </param>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        void UpgradeTableWatchTopic(IDbAccess dbAccess, IDbCommand dbCommand);
    }
}