﻿/* Yet Another Forum.NET
 * Copyright (C) 2003-2005 Bjørnar Henden
 * Copyright (C) 2006-2013 Jaben Cargman
 * Copyright (C) 2014-2019 Ingo Herbote
 * http://www.yetanotherforum.net/
 *
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at

 * http://www.apache.org/licenses/LICENSE-2.0

 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
namespace YAF.Configuration
{
    using System;
    using System.Web.Security;

    using YAF.Configuration.Pattern;
    using YAF.Types.Constants;

    /// <summary>
    /// The YAF board settings.
    /// </summary>
    public class YafBoardSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YafBoardSettings"/> class.
        /// </summary>
        public YafBoardSettings()
        {
            this._boardID = 0;
            this._reg = new RegistryDictionaryOverride();
            this._regBoard = new RegistryDictionary();

            // set the board dictionary as the override...
            this._reg.OverrideDictionary = this._regBoard;

            this._membershipAppName = Membership.ApplicationName;
            this._rolesAppName = Roles.ApplicationName;
        }

        /// <summary>
        /// Gets or sets the denied user registrations count.
        /// </summary>
        public int DeniedRegistrations
        {
            get => this._regBoard.GetValue<int>("DeniedRegistrations", 0);

            set => this._regBoard.SetValue("DeniedRegistrations", value);
        }

        /// <summary>
        /// Gets or sets the banned users count.
        /// </summary>
        public int BannedUsers
        {
            get => this._regBoard.GetValue<int>("BannedUsers", 0);

            set => this._regBoard.SetValue("BannedUsers", value);
        }

        /// <summary>
        /// Gets or sets the reported spammers count.
        /// </summary>
        public int ReportedSpammers
        {
            get => this._regBoard.GetValue<int>("ReportedSpammers", 0);

            set => this._regBoard.SetValue("ReportedSpammers", value);
        }

        /// <summary>
        /// Gets or sets the guest user id backup.
        /// </summary>
        /// <value>
        /// The guest user id backup.
        /// </value>
        public int? GuestUserIdBackup
        {
            get => this._regBoard.GetValue<int?>("GuestUserIdBackup", null);

            set => this._regBoard.SetValue("GuestUserIdBackup", value);
        }

        // Provider Settings

        /// <summary>
        /// Gets MembershipAppName.
        /// </summary>
        public string MembershipAppName => this._membershipAppName;

        /// <summary>
        /// Gets RolesAppName.
        /// </summary>
        public string RolesAppName => this._rolesAppName;

        /// <summary>
        /// Gets Name.
        /// individual board settings
        /// </summary>
        public string Name => this._legacyBoardSettings.BoardName;

        /// <summary>
        /// Gets the board identifier.
        /// </summary>
        /// <value>
        /// The board identifier.
        /// </value>
        public int BoardID => this._boardID;

        /// <summary>
        /// Gets a value indicating whether AllowThreaded.
        /// </summary>
        public bool AllowThreaded => this._legacyBoardSettings.AllowThreaded;

        /// <summary>
        /// Gets or sets a value indicating whether to enable Display Name.
        /// </summary>
        public bool EnableDisplayName
        {
            get => this._reg.GetValue("EnableDisplayName", false);

            set => this._reg.SetValue("EnableDisplayName", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable topic description.
        /// </summary>
        public bool EnableTopicDescription
        {
            get => this._reg.GetValue("EnableTopicDescription", true);

            set => this._reg.SetValue("EnableTopicDescription", value);
        }

        /// <summary>
        ///  Gets or sets a value indicating whether to use the jQuery scripts from a CDN or locally.
        /// </summary>
        /// <value>
        /// <c>If true use CDN if not use locally</c>.
        /// </value>
        public bool JqueryCDNHosted
        {
            get => this._reg.GetValue("JqueryCDNHosted", true);

            set => this._reg.SetValue("JqueryCDNHosted", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the script manager scripts from a CDN or locally.
        /// </summary>
        /// <value>
        /// <c>If true use CDN if not use locally</c>.
        /// </value>
        public bool ScriptManagerScriptsCDNHosted
        {
            get => this._reg.GetValue("ScriptManagerScriptsCDNHosted", true);

            set => this._reg.SetValue("ScriptManagerScriptsCDNHosted", value);
        }

        /// <summary>
        /// Gets or sets Theme.
        /// </summary>
        public string Theme
        {
            get => this._regBoard.GetValue("Theme", "yaf");

            set => this._regBoard.SetValue("Theme", value);
        }

        /// <summary>
        /// Gets or sets Language.
        /// </summary>
        public string Language
        {
            get => this._regBoard.GetValue("Language", "english.xml");

            set => this._regBoard.SetValue("Language", value);
        }

        /// <summary>
        /// Gets or sets Culture.
        /// </summary>
        public string Culture
        {
            get => this._regBoard.GetValue("Culture", "en-US");

            set => this._regBoard.SetValue("Culture", value);
        }

        /// <summary>
        /// Gets or sets Default Notification Setting.
        /// </summary>
        public UserNotificationSetting DefaultNotificationSetting
        {
            get => this._regBoard.GetValue("DefaultNotificationSetting", UserNotificationSetting.NoNotification);

            set => this._regBoard.SetValue("DefaultNotificationSetting", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Default Send Digest Email.
        /// </summary>
        public bool DefaultSendDigestEmail
        {
            get => this._regBoard.GetValue("DefaultSendDigestEmail", false);

            set => this._regBoard.SetValue("DefaultSendDigestEmail", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Allow Digest Email.
        /// </summary>
        public bool AllowDigestEmail
        {
            get => this._regBoard.GetValue("AllowDigestEmail", false);

            set => this._regBoard.SetValue("AllowDigestEmail", value);
        }

        /// <summary>
        /// Gets or sets ShowTopicsDefault.
        /// </summary>
        public int ShowTopicsDefault
        {
            get => this._regBoard.GetValue("ShowTopicsDefault", 0);

            set => this._regBoard.SetValue("ShowTopicsDefault", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [log error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log error]; otherwise, <c>false</c>.
        /// </value>
        public bool LogError
        {
            get => this._reg.GetValue("LogError", true);

            set => this._reg.SetValue("LogError", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [log warning].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log warning]; otherwise, <c>false</c>.
        /// </value>
        public bool LogWarning
        {
            get => this._reg.GetValue("LogWarning", true);

            set => this._reg.SetValue("LogWarning", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [log banned ip].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log banned ip]; otherwise, <c>false</c>.
        /// </value>
        public bool LogBannedIP
        {
            get => this._reg.GetValue("LogBannedIP", false);

            set => this._reg.SetValue("LogBannedIP", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [log information].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log information]; otherwise, <c>false</c>.
        /// </value>
        public bool LogInformation
        {
            get => this._reg.GetValue("LogInformation", true);

            set => this._reg.SetValue("LogInformation", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [log user deleted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log user deleted]; otherwise, <c>false</c>.
        /// </value>
        public bool LogUserDeleted
        {
            get => this._reg.GetValue("LogUserDeleted", false);

            set => this._reg.SetValue("LogUserDeleted", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [log user suspended unsuspended].
        /// </summary>
        /// <value>
        /// <c>true</c> if [log user suspended unsuspended]; otherwise, <c>false</c>.
        /// </value>
        public bool LogUserSuspendedUnsuspended
        {
            get => this._reg.GetValue("LogUserSuspendedUnsuspended", false);

            set => this._reg.SetValue("LogUserSuspendedUnsuspended", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [log view state error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [log view state error]; otherwise, <c>false</c>.
        /// </value>
        public bool LogViewStateError
        {
            get => this._reg.GetValue("LogViewStateError", false);

            set => this._reg.SetValue("LogViewStateError", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether FileExtensionAreAllowed.
        /// </summary>
        public bool FileExtensionAreAllowed
        {
            get => this._regBoard.GetValue("FileExtensionAreAllowed", true);

            set => this._regBoard.SetValue("FileExtensionAreAllowed", value);
        }

        /// <summary>
        /// Gets or sets NotificationOnUserRegisterEmailList.
        /// </summary>
        public string NotificationOnUserRegisterEmailList
        {
            get => this._regBoard.GetValue<string>("NotificationOnUserRegisterEmailList", null);

            set => this._regBoard.SetValue("NotificationOnUserRegisterEmailList", value);
        }

        /// <summary>
        /// Gets or sets Copyright Removal Domain Key.
        /// </summary>
        public string CopyrightRemovalDomainKey
        {
            get => this._regBoard.GetValue<string>("CopyrightRemovalDomainKey", null);

            set => this._regBoard.SetValue("CopyrightRemovalDomainKey", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Email Moderators On Moderated Post.
        /// </summary>
        public bool EmailModeratorsOnModeratedPost
        {
            get => this._regBoard.GetValue("EmailModeratorsOnModeratedPost", true);

            set => this._regBoard.SetValue("EmailModeratorsOnModeratedPost", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Email Moderators On Reported Post.
        /// </summary>
        public bool EmailModeratorsOnReportedPost
        {
            get => this._regBoard.GetValue("EmailModeratorsOnReportedPost", true);

            set => this._regBoard.SetValue("EmailModeratorsOnReportedPost", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether send an
        /// Email when a Single User is awarded with an Medal.
        /// </summary>
        public bool EmailUserOnMedalAward
        {
            get => this._regBoard.GetValue("EmailUserOnMedalAward", true);

            set => this._regBoard.SetValue("EmailUserOnMedalAward", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show cookie consent].
        /// </summary>
        public bool ShowCookieConsent
        {
            get => this._regBoard.GetValue("ShowCookieConsent", true);

            set => this._regBoard.SetValue("ShowCookieConsent", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// sending the user a welcome notification after register
        /// 0 = No Mail
        /// 1 = Send as Mail Message
        /// 2 = Send as Private Message
        /// </summary>
        public int SendWelcomeNotificationAfterRegister
        {
            get => this._reg.GetValue("SendWelcomeNotificationAfterRegister", 1);

            set => this._reg.SetValue("SendWelcomeNotificationAfterRegister", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// which Spam Service Type should been used
        /// 0 = No Service
        /// 1 = BlogSpam.NET Service
        /// 2 = Akismet.com Service
        /// 3 = Use Internal Spam Check
        /// </summary>
        public int SpamServiceType
        {
            get => this._reg.GetValue("SpamServiceType", 3);

            set => this._reg.SetValue("SpamServiceType", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// which Spam Service Type should been used
        /// 0 = No Service
        /// 1 = StopForumSpam.com Service
        /// 2 = BotScout.com Service
        /// 3 = StopForumSpam.com and BotScout.com Service
        /// 4 = StopForumSpam.com or BotScout.com Service
        /// </summary>
        public int BotSpamServiceType
        {
            get => this._reg.GetValue("BotSpamServiceType", 0);

            set => this._reg.SetValue("BotSpamServiceType", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// what to to with a SPAM Message
        /// 0 = Do nothing
        /// 1 = Flag Message as Unapproved
        /// 2 = Don't allow posting
        /// 3 = Delete and Ban User
        /// </summary>
        public int SpamMessageHandling
        {
            get => this._reg.GetValue("SpamMessageHandling", 0);

            set => this._reg.SetValue("SpamMessageHandling", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// what to to with Bots during Registration
        /// 0 = Disabled
        /// 1 = Log and Send Message to Admins
        /// 2 = Block user from Registration
        /// </summary>
        public int BotHandlingOnRegister
        {
            get => this._reg.GetValue("BotHandlingOnRegister", 0);

            set => this._reg.SetValue("BotHandlingOnRegister", value);
        }

        /// <summary>
        /// Gets or sets the amount of posts a user has to have to be ignored
        /// by the spam check
        /// </summary>
        /// <value>
        /// The ignore spam word check post count.
        /// </value>
        public int IgnoreSpamWordCheckPostCount
        {
            get => this._reg.GetValue("IgnoreSpamWordCheckPostCount", 20);

            set => this._reg.SetValue("IgnoreSpamWordCheckPostCount", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [ban bot IP on detection].
        /// </summary>
        /// <value>
        /// <c>true</c> if [ban bot IP on detection]; otherwise, <c>false</c>.
        /// </value>
        public bool BanBotIpOnDetection
        {
            get => this._reg.GetValue("BanBotIpOnDetection", false);

            set => this._reg.SetValue("BanBotIpOnDetection", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to Use Akismet Service.
        /// </summary>
        public string AkismetApiKey
        {
            get => this._reg.GetValue("AkismetApiKey", string.Empty);

            set => this._reg.SetValue("AkismetApiKey", value);
        }

        /// <summary>
        /// Gets or sets the BotScout.com API key.
        /// </summary>
        /// <value>
        /// The BotScout.com API key.
        /// </value>
        public string BotScoutApiKey
        {
            get => this._reg.GetValue("BotScoutApiKey", string.Empty);

            set => this._reg.SetValue("BotScoutApiKey", value);
        }

        /// <summary>
        /// Gets or sets the StopForumSpam.com API key.
        /// </summary>
        /// <value>
        /// The StopForumSpam.com API key.
        /// </value>
        public string StopForumSpamApiKey
        {
            get => this._reg.GetValue("StopForumSpamApiKey", string.Empty);

            set => this._reg.SetValue("StopForumSpamApiKey", value);
        }

        #region int settings

        /// <summary>
        /// Gets or sets the cdv version.
        /// </summary>
        public int CdvVersion
        {
            get => this._reg.GetValue("CdvVersion", 1);

            set => this._reg.SetValue("CdvVersion", value);
        }

        /// <summary>
        /// Gets or sets the allowed number of URLs before the message is flagged as spam.
        /// </summary>
        /// <value>
        /// The allowed number of URLs.
        /// </value>
        public int AllowedNumberOfUrls
        {
            get => this._reg.GetValue("AllowedNumberOfUrls", 10);

            set => this._reg.SetValue("AllowedNumberOfUrls", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Show Share Topic To.
        /// </summary>
        public int ShowShareTopicTo
        {
            get => this._reg.GetValue("ShowShareTopicTo", 1);

            set => this._reg.SetValue("ShowShareTopicTo", value);
        }

        /// <summary>
        ///  Gets or sets a value indicating whether Show Team Page To or not.
        /// </summary>
        public int ShowTeamTo
        {
            get => this._reg.GetValue("ShowTeamTo", 0);

            set => this._reg.SetValue("ShowTeamTo", value);
        }

        /// <summary>
        ///  Gets or sets a value indicating whether Show Help Page To or not.
        /// </summary>
        public int ShowHelpTo
        {
            get => this._reg.GetValue("ShowHelpTo", 2);

            set => this._reg.SetValue("ShowHelpTo", value);
        }

        /// <summary>
        /// Gets or sets ServerTimeCorrection.
        /// </summary>
        public int ServerTimeCorrection
        {
            get => this._reg.GetValue("ServerTimeCorrection", 0);

            set => this._reg.SetValue("ServerTimeCorrection", value);
        }

        /// <summary>
        /// Gets or sets Member ListPageSize.
        /// </summary>
        public int MemberListPageSize
        {
            get => this._reg.GetValue("MemberListPageSize", 20);

            set => this._reg.SetValue("MemberListPageSize", value);
        }

        /// <summary>
        /// Gets or sets MyTopics List PageSize.
        /// </summary>
        public int MyTopicsListPageSize
        {
            get => this._reg.GetValue("MyTopicsListPageSize", 20);

            set => this._reg.SetValue("MyTopicsListPageSize", value);
        }

        /// <summary>
        /// Gets or sets PostLatestFeedAccess.
        /// </summary>
        public int PostLatestFeedAccess
        {
            get => this._reg.GetValue("PostLatestFeedAccess", 1);

            set => this._reg.SetValue("PostLatestFeedAccess", value);
        }

        /// <summary>
        /// Gets or sets PostsFeedAccess.
        /// </summary>
        public int PostsFeedAccess
        {
            get => this._reg.GetValue("PostsFeedAccess", 1);

            set => this._reg.SetValue("PostsFeedAccess", value);
        }

        /// <summary>
        /// Gets or sets DigestSendEveryXHours.
        /// </summary>
        public int DigestSendEveryXHours
        {
            get => this._reg.GetValue("DigestSendEveryXHours", 24);

            set => this._reg.SetValue("DigestSendEveryXHours", value);
        }

        /// <summary>
        /// Gets or sets TopicsFeedAccess.
        /// </summary>
        public int TopicsFeedAccess
        {
            get => this._reg.GetValue("TopicsFeedAccess", 1);

            set => this._reg.SetValue("TopicsFeedAccess", value);
        }

        /// <summary>
        /// Gets or sets ForumFeedAccess.
        /// </summary>
        public int ForumFeedAccess
        {
            get => this._reg.GetValue("ForumFeedAccess", 1);

            set => this._reg.SetValue("ForumFeedAccess", value);
        }

        /// <summary>
        /// Gets or sets ActiveTopicFeedAccess.
        /// </summary>
        public int ActiveTopicFeedAccess
        {
            get => this._reg.GetValue("ActiveTopicFeedAccess", 1);

            set => this._reg.SetValue("ActiveTopicFeedAccess", value);
        }

        /// <summary>
        /// Gets or sets FavoriteTopicFeedAccess.
        /// </summary>
        public int FavoriteTopicFeedAccess
        {
            get => this._reg.GetValue("FavoriteTopicFeedAccess", 1);

            set => this._reg.SetValue("FavoriteTopicFeedAccess", value);
        }

        /// <summary>
        /// Gets or sets AvatarWidth.
        /// </summary>
        public int AvatarWidth
        {
            get => this._reg.GetValue("AvatarWidth", 50);

            set => this._reg.SetValue("AvatarWidth", value);
        }

        /// <summary>
        /// Gets or sets AvatarHeight.
        /// </summary>
        public int AvatarHeight
        {
            get => this._reg.GetValue("AvatarHeight", 80);

            set => this._reg.SetValue("AvatarHeight", value);
        }

        /// <summary>
        /// Gets or sets AllowCreateTopicsSameName.
        /// </summary>
        public int AllowCreateTopicsSameName
        {
            get => this._reg.GetValue("AllowCreateTopicsSameName", 0);

            set => this._reg.SetValue("AllowCreateTopicsSameName", value);
        }

        /// <summary>
        /// Gets or sets AvatarSize.
        /// </summary>
        public int AvatarSize
        {
            get => this._reg.GetValue("AvatarSize", 50000);

            set => this._reg.SetValue("AvatarSize", value);
        }

        /// <summary>
        /// Gets or sets MaxWordLength. Used in topic names etc. to avoid layout distortions.
        /// </summary>
        public int MaxWordLength
        {
            get => this._reg.GetValue("MaxWordLength", 40);

            set => this._reg.SetValue("MaxWordLength", value);
        }

        /// <summary>
        /// Gets or sets MaxFileSize.
        /// </summary>
        public int MaxFileSize
        {
            get => this._reg.GetValue("MaxFileSize", 0);

            set => this._reg.SetValue("MaxFileSize", value);
        }

        /// <summary>
        /// Gets or sets Message History Days To Trace.
        /// </summary>
        public int MessageHistoryDaysToLog
        {
            get => this._reg.GetValue("MessageHistoryDaysToLog", 30);

            set => this._reg.SetValue("MessageHistoryDaysToLog", value);
        }

        /// <summary>
        /// Gets or sets LockPosts.
        /// </summary>
        public int LockPosts
        {
            get => this._reg.GetValue("LockPosts", 0);

            set => this._reg.SetValue("LockPosts", value);
        }

        /// <summary>
        /// Gets or sets PostsPerPage.
        /// </summary>
        public int PostsPerPage
        {
            get => this._reg.GetValue("PostsPerPage", 20);

            set => this._reg.SetValue("PostsPerPage", value);
        }

        /// <summary>
        /// Gets or sets the amount of Sub Forums In Forums List.
        /// </summary>
        public int SubForumsInForumList
        {
            get => this._reg.GetValue("SubForumsInForumList", 5);

            set => this._reg.SetValue("SubForumsInForumList", value);
        }

        /// <summary>
        /// Gets or sets TopicsPerPage.
        /// </summary>
        public int TopicsPerPage
        {
            get => this._reg.GetValue("TopicsPerPage", 15);

            set => this._reg.SetValue("TopicsPerPage", value);
        }

        /// <summary>
        /// Gets or sets ForumEditor.
        /// </summary>
        public string ForumEditor
        {
            get => this._reg.GetValue("ForumEditor", "1");

            set => this._reg.SetValue("ForumEditor", value);
        }

        /// <summary>
        /// Gets or sets PostFloodDelay.
        /// </summary>
        public int PostFloodDelay
        {
            get => this._reg.GetValue("PostFloodDelay", 30);

            set => this._reg.SetValue("PostFloodDelay", value);
        }

        /// <summary>
        /// Gets or sets AllowedPollChoiceNumber.
        /// </summary>
        public int AllowedPollChoiceNumber
        {
            get => this._reg.GetValue("AllowedPollChoiceNumber", 10);

            set => this._reg.SetValue("AllowedPollChoiceNumber", value);
        }

        /// <summary>
        /// Gets or sets AllowedPollNumber.
        /// </summary>
        public int AllowedPollNumber
        {
            get => this._reg.GetValue("AllowedPollNumber", 3);

            set => this._reg.SetValue("AllowedPollNumber", value);
        }

        /// <summary>
        /// Gets or sets PollImageMaxFileSize.
        /// </summary>
        public int PollImageMaxFileSize
        {
            get => this._reg.GetValue("PollImageMaxFileSize", 100);

            set => this._reg.SetValue("PollImageMaxFileSize", value);
        }

        /// <summary>
        /// Gets or sets CaptchaTypeRegister.
        /// </summary>
        public int CaptchaTypeRegister
        {
            get => this._reg.GetValue("CaptchaTypeRegister", 1);

            set => this._reg.SetValue("CaptchaTypeRegister", value);
        }

        /// <summary>
        /// Gets or sets EditTimeOut.
        /// </summary>
        public int EditTimeOut
        {
            get => this._reg.GetValue("EditTimeOut", 30);

            set => this._reg.SetValue("EditTimeOut", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether someone can report posts as violating forum rules.
        /// </summary>
        public int ReportPostPermissions
        {
            get => this._reg.GetValue("ReportPostPermissions", (int)ViewPermissions.RegisteredUsers);

            set => this._reg.SetValue("ReportPostPermissions", value);
        }

        /// <summary>
        /// Gets or sets CaptchaSize.
        /// </summary>
        public int CaptchaSize
        {
            get => this._reg.GetValue("CaptchaSize", 8);

            set => this._reg.SetValue("CaptchaSize", value);
        }

        /// <summary>
        /// Gets or sets ProfileViewPermissions.
        /// </summary>
        public int ProfileViewPermissions
        {
            get => this._reg.GetValue("ProfileViewPermission", (int)ViewPermissions.RegisteredUsers);

            set => this._reg.SetValue("ProfileViewPermission", value);
        }

        /// <summary>
        /// Gets or sets ReturnSearchMax.
        /// </summary>
        public int ReturnSearchMax
        {
            get => this._reg.GetValue("ReturnSearchMax", 1000);

            set => this._reg.SetValue("ReturnSearchMax", value);
        }

        /// <summary>
        /// Gets or sets ActiveUsersViewPermissions.
        /// </summary>
        public int ActiveUsersViewPermissions
        {
            get => this._reg.GetValue("ActiveUsersViewPermissions", (int)ViewPermissions.RegisteredUsers);

            set => this._reg.SetValue("ActiveUsersViewPermissions", value);
        }

        /// <summary>
        /// Gets or sets MembersListViewPermissions.
        /// </summary>
        public int MembersListViewPermissions
        {
            get => this._reg.GetValue("MembersListViewPermissions", (int)ViewPermissions.RegisteredUsers);

            set => this._reg.SetValue("MembersListViewPermissions", value);
        }

        /// <summary>
        /// Gets or sets ActiveDiscussionsCount.
        /// </summary>
        public int ActiveDiscussionsCount
        {
            get => this._reg.GetValue("ActiveDiscussionsCount", 5);

            set => this._reg.SetValue("ActiveDiscussionsCount", value);
        }

        /// <summary>
        /// Gets or sets ActiveDiscussionsCacheTimeout.
        /// </summary>
        public int ActiveDiscussionsCacheTimeout
        {
            get => this._reg.GetValue("ActiveDiscussionsCacheTimeout", 1);

            set => this._reg.SetValue("ActiveDiscussionsCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets SearchStringMinLength.
        /// </summary>
        public int SearchStringMinLength
        {
            get => this._reg.GetValue("SearchStringMinLength", 4);

            set => this._reg.SetValue("SearchStringMinLength", value);
        }

        /// <summary>
        /// Gets or sets SearchPermissions.
        /// </summary>
        public int SearchPermissions
        {
            get => this._reg.GetValue("SearchPermissions", (int)ViewPermissions.Everyone);

            set => this._reg.SetValue("SearchPermissions", value);
        }

        /// <summary>
        /// Gets or sets BoardPollID.
        /// </summary>
        public int BoardPollID
        {
            get => this._regBoard.GetValue("BoardPollID", 0);

            set => this._regBoard.SetValue("BoardPollID", value);
        }

        /// <summary>
        /// Gets or sets ForumStatisticsCacheTimeout.
        /// </summary>
        public int ForumStatisticsCacheTimeout
        {
            get => this._reg.GetValue("ForumStatisticsCacheTimeout", 60);

            set => this._reg.SetValue("ForumStatisticsCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets BoardUserStatsCacheTimeout.
        /// </summary>
        public int BoardUserStatsCacheTimeout
        {
            get => this._reg.GetValue("BoardUserStatsCacheTimeout", 60);

            set => this._reg.SetValue("BoardUserStatsCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets PrivateMessageMaxRecipients.
        /// </summary>
        public int PrivateMessageMaxRecipients
        {
            get => this._reg.GetValue("PrivateMessageMaxRecipients", 1);

            set => this._reg.SetValue("PrivateMessageMaxRecipients", value);
        }

        /// <summary>
        /// Gets or sets DisableNoFollowLinksAfterDay.
        /// </summary>
        public int DisableNoFollowLinksAfterDay
        {
            get => this._reg.GetValue("DisableNoFollowLinksAfterDay", 0);

            set => this._reg.SetValue("DisableNoFollowLinksAfterDay", value);
        }

        /// <summary>
        /// Gets or sets BoardForumListAllGuestCacheTimeout.
        /// </summary>
        public int BoardForumListAllGuestCacheTimeout
        {
            get => this._reg.GetValue("BoardForumListAllGuestCacheTimeout", 1440);

            set => this._reg.SetValue("BoardForumListAllGuestCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets BoardModeratorsCacheTimeout.
        /// </summary>
        public int BoardModeratorsCacheTimeout
        {
            get => this._reg.GetValue("BoardModeratorsCacheTimeout", 1440);

            set => this._reg.SetValue("BoardModeratorsCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets BoardCategoriesCacheTimeout.
        /// </summary>
        public int BoardCategoriesCacheTimeout
        {
            get => this._reg.GetValue("BoardCategoriesCacheTimeout", 1440);

            set => this._reg.SetValue("BoardCategoriesCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets ReplaceRulesCacheTimeout.
        /// </summary>
        public int ReplaceRulesCacheTimeout
        {
            get => this._reg.GetValue("ReplaceRulesCacheTimeout", 1440);

            set => this._reg.SetValue("ReplaceRulesCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets FirstPostCacheTimeout.
        /// </summary>
        public int FirstPostCacheTimeout
        {
            get => this._reg.GetValue("FirstPostCacheTimeout", 120);

            set => this._reg.SetValue("FirstPostCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets Max. Post Size.
        /// </summary>
        public int MaxPostSize
        {
            get => this._reg.GetValue<int>("MaxPostSize", short.MaxValue);

            set => this._reg.SetValue("MaxPostSize", value);
        }

        /// <summary>
        /// Gets or sets MaxReportPostChars.
        /// </summary>
        public int MaxReportPostChars
        {
            get => this._reg.GetValue("MaxReportPostChars", 128);

            set => this._reg.SetValue("MaxReportPostChars", value);
        }

        /// <summary>
        /// Gets or sets Picture Attachment Display Threshold.
        /// </summary>
        public int PictureAttachmentDisplayTreshold
        {
            get => this._reg.GetValue("PictureAttachmentDisplayTreshold", 262144);

            set => this._reg.SetValue("PictureAttachmentDisplayTreshold", value);
        }

        /// <summary>
        /// Gets or sets ImageAttachmentResizeWidth.
        /// </summary>
        public int ImageAttachmentResizeWidth
        {
            get => this._reg.GetValue("ImageAttachmentResizeWidth", 2000);

            set => this._reg.SetValue("ImageAttachmentResizeWidth", value);
        }

        /// <summary>
        /// Gets or sets ImageAttachmentResizeHeight.
        /// </summary>
        public int ImageAttachmentResizeHeight
        {
            get => this._reg.GetValue("ImageAttachmentResizeHeight", 2000);

            set => this._reg.SetValue("ImageAttachmentResizeHeight", value);
        }

        /// <summary>
        /// Gets or sets the image thumbnail max width.
        /// </summary>
        public int ImageThumbnailMaxWidth
        {
            get => this._reg.GetValue("ImageThumbnailMaxWidth", 200);

            set => this._reg.SetValue("ImageThumbnailMaxWidth", value);
        }

        /// <summary>
        /// Gets or sets the image thumbnail max height.
        /// </summary>
        public int ImageThumbnailMaxHeight
        {
            get => this._reg.GetValue("ImageThumbnailMaxHeight", 200);

            set => this._reg.SetValue("ImageThumbnailMaxHeight", value);
        }

        /// <summary>
        /// Gets or sets ActiveListTime.
        /// </summary>
        public int ActiveListTime
        {
            get => this._regBoard.GetValue("ActiveListTime", 5);

            set => this._regBoard.SetValue("ActiveListTime", value);
        }

        /// <summary>
        /// Gets or sets User Lazy Data Cache Timeout.
        /// </summary>
        public int ActiveUserLazyDataCacheTimeout
        {
            get => this._reg.GetValue("ActiveUserLazyDataCacheTimeout", 10);

            set => this._reg.SetValue("ActiveUserLazyDataCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets OnlineStatusCacheTimeout.
        /// </summary>
        public int OnlineStatusCacheTimeout
        {
            get => this._reg.GetValue("OnlineStatusCacheTimeout", 60000);

            set => this._reg.SetValue("OnlineStatusCacheTimeout", value);
        }

        /// <summary>
        /// Gets or sets User/Display Name Max Length.
        /// </summary>
        public int UserNameMaxLength
        {
            get => this._reg.GetValue("UserNameMaxLength", 50);

            set => this._reg.SetValue("UserNameMaxLength", value);
        }

        /// <summary>
        /// Gets or sets User/Display Name Min Length.
        /// </summary>
        public int DisplayNameMinLength
        {
            get => this._reg.GetValue("DisplayNameMinLength", 3);

            set => this._reg.SetValue("DisplayNameMinLength", value);
        }

        /// <summary>
        /// Gets or sets Event Log Max Messages.
        /// </summary>
        public int EventLogMaxMessages
        {
            get => this._reg.GetValue("EventLogMaxMessages", 1050);

            set => this._reg.SetValue("EventLogMaxMessages", value);
        }

        /// <summary>
        /// Gets or sets Event Log Max Days.
        /// </summary>
        public int EventLogMaxDays
        {
            get => this._reg.GetValue("EventLogMaxDays", 365);

            set => this._reg.SetValue("EventLogMaxDays", value);
        }

        /// <summary>
        /// Gets or sets Message Notification Duration
        /// </summary>
        public int MessageNotifcationDuration
        {
            get => this._reg.GetValue("MessageNotifcationDuration", 30);

            set => this._reg.SetValue("MessageNotifcationDuration", value);
        }

        #endregion

        #region boolean settings

        /// <summary>
        /// Gets or sets a value indicating whether show the edited message.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show edited message]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowEditedMessage
        {
            get => this._reg.GetValue("ShowEditedMessage", true);

            set => this._reg.SetValue("ShowEditedMessage", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowUsersTextEditor.
        /// </summary>
        public bool AllowUsersTextEditor
        {
            get => this._reg.GetValue("AllowUsersTextEditor", false);

            set => this._reg.SetValue("AllowUsersTextEditor", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EmailVerification.
        /// </summary>
        public bool EmailVerification
        {
            get => this._reg.GetValue("EmailVerification", false);

            set => this._reg.SetValue("EmailVerification", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow notification all posts all topics].
        /// </summary>
        public bool AllowNotificationAllPostsAllTopics
        {
            get => this._reg.GetValue("AllowNotificationAllPostsAllTopics", false);

            set => this._reg.SetValue("AllowNotificationAllPostsAllTopics", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow forums with same name].
        /// </summary>
        public bool AllowForumsWithSameName
        {
            get => this._reg.GetValue("AllowForumsWithSameName", false);

            set => this._reg.SetValue("AllowForumsWithSameName", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Use Read Tracking By Database is enabled.
        /// </summary>
        public bool UseReadTrackingByDatabase
        {
            get => this._reg.GetValue("UseReadTrackingByDatabase", false);

            set => this._reg.SetValue("UseReadTrackingByDatabase", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowLastUnreadPost is enabled.
        /// </summary>
        public bool ShowLastUnreadPost
        {
            get => this._reg.GetValue("ShowLastUnreadPost", true);

            set => this._reg.SetValue("ShowLastUnreadPost", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Enable IP Info Service.
        /// </summary>
        public bool EnableIPInfoService
        {
            get => this._reg.GetValue("EnableIPInfoService", false);

            set => this._reg.SetValue("EnableIPInfoService", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EmailVerification.
        /// </summary>
        public bool AbandonSessionsForDontTrack
        {
            get => this._reg.GetValue("AbadonSessionsForDontTrack", false);

            set => this._reg.SetValue("AbadonSessionsForDontTrack", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Use SSL To Log In.
        /// </summary>
        /// <remarks>
        /// vzrus: 10/4/10 SSL registration and login options
        /// </remarks>
        public bool UseSSLToLogIn
        {
            get => this._reg.GetValue("UseSSLToLogIn", false);

            set => this._reg.SetValue("UseSSLToLogIn", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Use SSL To Register.
        /// </summary>
        public bool UseSSLToRegister
        {
            get => this._reg.GetValue("UseSSLToRegister", false);

            set => this._reg.SetValue("UseSSLToRegister", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowMoved.
        /// </summary>
        public bool ShowMoved
        {
            get => this._reg.GetValue("ShowMoved", true);

            set => this._reg.SetValue("ShowMoved", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether if an avatar is should be shown in the topic listings.
        /// </summary>
        public bool ShowAvatarsInTopic
        {
            get => this._reg.GetValue("ShowAvatarsInTopic", false);

            set => this._reg.SetValue("ShowAvatarsInTopic", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Show Guests In Detailed Active List.
        /// </summary>
        public bool ShowGuestsInDetailedActiveList
        {
            get => this._reg.GetValue("ShowGuestsInDetailedActiveList", false);

            set => this._reg.SetValue("ShowGuestsInDetailedActiveList", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Show Crawlers In Active List.
        /// </summary>
        public bool ShowCrawlersInActiveList
        {
            get => this._reg.GetValue("ShowCrawlersInActiveList", false);

            set => this._reg.SetValue("ShowCrawlersInActiveList", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowGroups.
        /// </summary>
        public bool ShowGroups
        {
            get => this._reg.GetValue("ShowGroups", true);

            set => this._reg.SetValue("ShowGroups", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether BlankLinks.
        /// </summary>
        public bool BlankLinks
        {
            get => this._reg.GetValue("BlankLinks", false);

            set => this._reg.SetValue("BlankLinks", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowUserTheme.
        /// </summary>
        public bool AllowUserTheme
        {
            get => this._reg.GetValue("AllowUserTheme", false);

            set => this._reg.SetValue("AllowUserTheme", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowUserHideHimself.
        /// </summary>
        public bool AllowUserHideHimself
        {
            get => this._reg.GetValue("AllowUserHideHimself", false);

            set => this._reg.SetValue("AllowUserHideHimself", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowUserLanguage.
        /// </summary>
        public bool AllowUserLanguage
        {
            get => this._reg.GetValue("AllowUserLanguage", false);

            set => this._reg.SetValue("AllowUserLanguage", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Allow Single Sign On.
        /// </summary>
        public bool AllowSingleSignOn
        {
            get => this._reg.GetValue("AllowSingleSignOn", false);

            set => this._reg.SetValue("AllowSingleSignOn", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowModeratorsViewIPs.
        /// </summary>
        public bool AllowModeratorsViewIPs
        {
            get => this._reg.GetValue("AllowModeratorsViewIPs", false);

            set => this._reg.SetValue("AllowModeratorsViewIPs", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowPMEmailNotification.
        /// </summary>
        public bool AllowPMEmailNotification
        {
            get => this._reg.GetValue("AllowPMEmailNotification", true);

            set => this._reg.SetValue("AllowPMEmailNotification", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowPollChangesAfterFirstVote.
        /// A poll creator can't change choices after the first vote.
        /// </summary>
        public bool AllowPollChangesAfterFirstVote
        {
            get => this._reg.GetValue("AllowPollChangesAfterFirstVote", false);

            set => this._reg.SetValue("AllowPollChangesAfterFirstVote", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowUsersHidePollResults.
        /// </summary>
        public bool AllowUsersHidePollResults
        {
            get => this._reg.GetValue("AllowViewPollVotesIfNoPollAcces", true);

            set => this._reg.SetValue("AllowViewPollVotesIfNoPollAcces", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether if Use Farsi Calendar
        /// </summary>
        public bool UseFarsiCalender
        {
            get => this._reg.GetValue("UseFarsiCalender", false);

            set => this._reg.SetValue("UseFarsiCalender", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether if relative times are used on the forum.
        /// </summary>
        public bool ShowRelativeTime
        {
            get => this._reg.GetValue("ShowRelativeTime", true);

            set => this._reg.SetValue("ShowRelativeTime", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowMultipleChoices.
        /// </summary>
        public bool AllowMultipleChoices
        {
            get => this._reg.GetValue("AllowMultipleChoices", true);

            set => this._reg.SetValue("AllowMultipleChoices", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowGuestsViewPollOptions.
        /// </summary>
        public bool AllowGuestsViewPollOptions
        {
            get => this._reg.GetValue("AllowGuestsViewPollOptions", true);

            set => this._reg.SetValue("AllowGuestsViewPollOptions", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowUsersImagedPoll.
        /// </summary>
        public bool AllowUsersImagedPoll
        {
            get => this._reg.GetValue("AllowUsersImagedPoll", false);

            set => this._reg.SetValue("AllowUsersImagedPoll", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AvatarUpload.
        /// </summary>
        public bool AvatarUpload
        {
            get => this._reg.GetValue("AvatarUpload", false);

            set => this._reg.SetValue("AvatarUpload", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AvatarRemote.
        /// </summary>
        public bool AvatarRemote
        {
            get => this._reg.GetValue("AvatarRemote", false);

            set => this._reg.SetValue("AvatarRemote", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Avatar Gallery.
        /// </summary>
        public bool AvatarGallery
        {
            get => this._reg.GetValue("AvatarGallery", true);

            set => this._reg.SetValue("AvatarGallery", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Avatar Gravatar.
        /// </summary>
        public bool AvatarGravatar
        {
            get => this._reg.GetValue("AvatarGravatar", false);

            set => this._reg.SetValue("AvatarGravatar", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowEmailChange.
        /// </summary>
        public bool AllowEmailChange
        {
            get => this._reg.GetValue("AllowEmailChange", true);

            set => this._reg.SetValue("AllowEmailChange", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowPasswordChange.
        /// </summary>
        public bool AllowPasswordChange
        {
            get => this._reg.GetValue("AllowPasswordChange", true);

            set => this._reg.SetValue("AllowPasswordChange", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether UseFileTable.
        /// </summary>
        public bool UseFileTable
        {
            get => this._reg.GetValue("UseFileTable", false);

            set => this._reg.SetValue("UseFileTable", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowRSSLink.
        /// </summary>
        public bool ShowRSSLink
        {
            get => this._reg.GetValue("ShowRSSLink", true);

            set => this._reg.SetValue("ShowRSSLink", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowAtomLink.
        /// </summary>
        public bool ShowAtomLink
        {
            get => this._reg.GetValue("ShowAtomLink", true);

            set => this._reg.SetValue("ShowAtomLink", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowPageGenerationTime.
        /// </summary>
        public bool ShowPageGenerationTime
        {
            get => this._reg.GetValue("ShowPageGenerationTime", true);

            set => this._reg.SetValue("ShowPageGenerationTime", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowYAFVersion.
        /// </summary>
        public bool ShowYAFVersion
        {
            get => this._reg.GetValue("ShowYAFVersion", true);

            set => this._reg.SetValue("ShowYAFVersion", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowForumJump.
        /// </summary>
        public bool ShowForumJump
        {
            get => this._reg.GetValue("ShowForumJump", true);

            set => this._reg.SetValue("ShowForumJump", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowPrivateMessages.
        /// </summary>
        public bool AllowPrivateMessages
        {
            get => this._reg.GetValue("AllowPrivateMessages", true);

            set => this._reg.SetValue("AllowPrivateMessages", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow private message attachments].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow private message attachments]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowPrivateMessageAttachments
        {
            get => this._reg.GetValue("AllowPrivateMessageAttachments", true);

            set => this._reg.SetValue("AllowPrivateMessageeAttachments", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowEmailSending.
        /// </summary>
        public bool AllowEmailSending
        {
            get => this._reg.GetValue("AllowEmailSending", true);

            set => this._reg.SetValue("AllowEmailSending", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowSignatures.
        /// </summary>
        public bool AllowSignatures
        {
            get => this._reg.GetValue("AllowSignatures", true);

            set => this._reg.SetValue("AllowSignatures", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Enable Quick Search.
        /// </summary>
        public bool ShowQuickSearch
        {
            get => this._reg.GetValue("ShowQuickSearch", false);

            set => this._reg.SetValue("ShowQuickSearch", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether RemoveNestedQuotes.
        /// </summary>
        public bool RemoveNestedQuotes
        {
            get => this._reg.GetValue("RemoveNestedQuotes", false);

            set => this._reg.SetValue("RemoveNestedQuotes", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether DisableRegistrations.
        /// </summary>
        public bool DisableRegistrations
        {
            get => this._reg.GetValue("DisableRegistrations", false);

            set => this._reg.SetValue("DisableRegistrations", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether CreateNntpUsers.
        /// </summary>
        public bool CreateNntpUsers
        {
            get => this._reg.GetValue("CreateNntpUsers", false);

            set => this._reg.SetValue("CreateNntpUsers", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowGroupsProfile.
        /// </summary>
        public bool ShowGroupsProfile
        {
            get => this._reg.GetValue("ShowGroupsProfile", false);

            set => this._reg.SetValue("ShowGroupsProfile", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether PollVoteTiedToIP.
        /// </summary>
        public bool PollVoteTiedToIP
        {
            get => this._reg.GetValue("PollVoteTiedToIP", true);

            set => this._reg.SetValue("PollVoteTiedToIP", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowAdsToSignedInUsers.
        /// </summary>
        public bool ShowAdsToSignedInUsers
        {
            get => this._reg.GetValue("ShowAdsToSignedInUsers", true);

            set => this._reg.SetValue("ShowAdsToSignedInUsers", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Display Reputation Points.
        /// </summary>
        public bool DisplayPoints
        {
            get => this._reg.GetValue("DisplayPoints", false);

            set => this._reg.SetValue("DisplayPoints", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowQuickAnswer.
        /// </summary>
        public bool ShowQuickAnswer
        {
            get => this._reg.GetValue("ShowQuickAnswer", true);

            set => this._reg.SetValue("ShowQuickAnswer", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowDeletedMessages.
        /// </summary>
        public bool ShowDeletedMessages
        {
            get => this._reg.GetValue("ShowDeletedMessages", true);

            set => this._reg.SetValue("ShowDeletedMessages", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowDeletedMessagesToAll.
        /// </summary>
        public bool ShowDeletedMessagesToAll
        {
            get => this._reg.GetValue("ShowDeletedMessagesToAll", false);

            set => this._reg.SetValue("ShowDeletedMessagesToAll", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowModeratorList.
        /// </summary>
        public bool ShowModeratorList
        {
            get => this._reg.GetValue("ShowModeratorList", true);

            set => this._reg.SetValue("ShowModeratorList", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowModeratorList as a separate column.
        /// </summary>
        public bool ShowModeratorListAsColumn
        {
            get => this._reg.GetValue("ShowModeratorListAsColumn", true);

            set => this._reg.SetValue("ShowModeratorListAsColumn", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableCaptchaForPost.
        /// </summary>
        public bool EnableCaptchaForPost
        {
            get => this._reg.GetValue("EnableCaptchaForPost", false);

            set => this._reg.SetValue("EnableCaptchaForPost", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableCaptchaForRegister.
        /// </summary>
        public bool EnableCaptchaForRegister
        {
            get => this._reg.GetValue("EnableCaptchaForRegister", false);

            set => this._reg.SetValue("EnableCaptchaForRegister", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableCaptchaForGuests.
        /// </summary>
        public bool EnableCaptchaForGuests
        {
            get => this._reg.GetValue("EnableCaptchaForGuests", true);

            set => this._reg.SetValue("EnableCaptchaForGuests", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether UseNoFollowLinks.
        /// </summary>
        public bool UseNoFollowLinks
        {
            get => this._reg.GetValue("UseNoFollowLinks", true);

            set => this._reg.SetValue("UseNoFollowLinks", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether DoUrlReferrerSecurityCheck.
        /// </summary>
        public bool DoUrlReferrerSecurityCheck
        {
            get => this._reg.GetValue("DoUrlReferrerSecurityCheck", false);

            set => this._reg.SetValue("DoUrlReferrerSecurityCheck", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableImageAttachmentResize.
        /// </summary>
        public bool EnableImageAttachmentResize
        {
            get => this._reg.GetValue("EnableImageAttachmentResize", true);

            set => this._reg.SetValue("EnableImageAttachmentResize", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Resize Posted Images.
        /// </summary>
        public bool ResizePostedImages
        {
            get => this._reg.GetValue("ResizePostedImages", true);

            set => this._reg.SetValue("ResizePostedImages", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowUserInfoCaching.
        /// </summary>
        public bool AllowUserInfoCaching
        {
            get => this._reg.GetValue("AllowUserInfoCaching", true);

            set => this._reg.SetValue("AllowUserInfoCaching", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether display No-Count Forums In ActiveDiscussions.
        /// </summary>
        public bool NoCountForumsInActiveDiscussions
        {
            get => this._reg.GetValue("NoCountForumsInActiveDiscussions", true);

            set => this._reg.SetValue("NoCountForumsInActiveDiscussions", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether UseStyledNicks.
        /// </summary>
        public bool UseStyledNicks
        {
            get => this._reg.GetValue("UseStyledNicks", false);

            set => this._reg.SetValue("UseStyledNicks", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Use Styled Topic Titles.
        /// </summary>
        public bool UseStyledTopicTitles
        {
            get => this._reg.GetValue("UseStyledTopicTitles", false);

            set => this._reg.SetValue("UseStyledTopicTitles", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowUserOnlineStatus.
        /// </summary>
        public bool ShowUserOnlineStatus
        {
            get => this._reg.GetValue("ShowUserOnlineStatus", false);

            set => this._reg.SetValue("ShowUserOnlineStatus", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowThanksDate.
        /// </summary>
        public bool ShowThanksDate
        {
            get => this._reg.GetValue("ShowThanksDate", true);

            set => this._reg.SetValue("ShowThanksDate", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableThanksMod.
        /// </summary>
        public bool EnableThanksMod
        {
            get => this._reg.GetValue("EnableThanksMod", true);

            set => this._reg.SetValue("EnableThanksMod", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableBuddyList.
        /// </summary>
        public bool EnableBuddyList
        {
            get => this._reg.GetValue("EnableBuddyList", true);

            set => this._reg.SetValue("EnableBuddyList", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableActiveLocationErrorsLog. A temporary debug setting.
        /// </summary>
        public bool EnableActiveLocationErrorsLog
        {
            get => this._reg.GetValue("EnableActiveLocationErrorsLog", false);

            set => this._reg.SetValue("EnableActiveLocationErrorsLog", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Log UserAgent strings unhandled by YAF.
        /// </summary>
        public bool UserAgentBadLog
        {
            get => this._reg.GetValue("UserAgentBadLog", false);

            set => this._reg.SetValue("UserAgentBadLog", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether EnableAlbum.
        /// </summary>
        public bool EnableAlbum
        {
            get => this._reg.GetValue("EnableAlbum", false);

            set => this._reg.SetValue("EnableAlbum", value);
        }

        /// <summary>
        /// Gets or sets AlbumImagesSizeMax.
        /// </summary>
        public int AlbumImagesSizeMax
        {
            get => this._regBoard.GetValue("AlbumImagesSizeMax", 1048576);

            set => this._regBoard.SetValue("AlbumImagesSizeMax", value);
        }

        /// <summary>
        /// Gets or sets AlbumsPerPage.
        /// </summary>
        public int AlbumsPerPage
        {
            get => this._regBoard.GetValue("AlbumsPerPage", 6);

            set => this._regBoard.SetValue("AlbumsPerPage", value);
        }

        /// <summary>
        /// Gets or sets AlbumImagesPerPage.
        /// </summary>
        public int AlbumImagesPerPage
        {
            get => this._regBoard.GetValue("AlbumImagesPerPage", 10);

            set => this._regBoard.SetValue("AlbumImagesPerPage", value);
        }

        /// <summary>
        /// Gets or sets sets the Number of Views a Topic must have to became
        /// Hot.
        /// </summary>
        public int PopularTopicViews
        {
            get => this._regBoard.GetValue("PopularTopicViews", 100);

            set => this._regBoard.SetValue("PopularTopicViews", value);
        }

        /// <summary>
        /// Gets or sets the Number of Replies a Topic must have to became
        /// Hot.
        /// </summary>
        public int PopularTopicReplys
        {
            get => this._regBoard.GetValue("PopularTopicReplys", 10);

            set => this._regBoard.SetValue("PopularTopicReplys", value);
        }

        /// <summary>
        /// Gets or sets the Number of Days a topic must have a Reply in t
        /// remain Hot (Popular)
        /// </summary>
        public int PopularTopicDays
        {
            get => this._regBoard.GetValue("PopularTopicDays", 7);

            set => this._regBoard.SetValue("PopularTopicDays", value);
        }

        /// <summary>
        /// Gets or sets the Number of Topics to show on the Forum Feed
        /// </summary>
        public int TopicsFeedItemsCount
        {
            get => this._regBoard.GetValue("TopicsFeedItemsCount", 20);

            set => this._regBoard.SetValue("TopicsFeedItemsCount", value);
        }

        /// <summary>
        /// Gets or sets the DNN page tab.
        /// </summary>
        /// <value>
        /// The DNN page tab.
        /// </value>
        public int DNNPageTab
        {
            get => this._regBoard.GetValue("DNNPageTab", -1);

            set => this._regBoard.SetValue("DNNPageTab", value);
        }

        /// <summary>
        /// Gets or sets the DNN portal identifier.
        /// </summary>
        /// <value>
        /// The DNN portal identifier.
        /// </value>
        public int DNNPortalId
        {
            get => this._regBoard.GetValue("DNNPortalId", -1);

            set => this._regBoard.SetValue("DNNPortalId", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to AddDynamicPageMetaTags.
        /// </summary>
        public bool AddDynamicPageMetaTags
        {
            get => this._reg.GetValue("AddDynamicPageMetaTags", true);

            set => this._reg.SetValue("AddDynamicPageMetaTags", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow display name modification].
        /// </summary>
        public bool AllowDisplayNameModification
        {
            get => this._reg.GetValue("AllowDisplayNameModification", true);

            set => this._reg.SetValue("AllowDisplayNameModification", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ImageAttachmentResizeCropped.
        /// </summary>
        public bool ImageAttachmentResizeCropped
        {
            get => this._reg.GetValue("ImageAttachmentResizeCropped", false);

            set => this._reg.SetValue("ImageAttachmentResizeCropped", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show connect message in topic].
        /// </summary>
        /// <value>
        /// <c>true</c> if [show connect message in topic]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowConnectMessageInTopic
        {
            get => this._reg.GetValue("ShowConnectMessageInTopic", true);

            set => this._reg.SetValue("ShowConnectMessageInTopic", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether use user info hover Cards.
        /// </summary>
        public bool EnableUserInfoHoverCards
        {
            get => this._reg.GetValue("EnableUserInfoHoverCards", true);

            set => this._reg.SetValue("EnableUserInfoHoverCards", value);
        }

        /// <summary>
        /// Gets or sets the hover card open delay.
        /// </summary>
        /// <value>
        /// The hover card open delay.
        /// </value>
        public int HoverCardOpenDelay
        {
            get => this._reg.GetValue("HoverCardOpenDelay", 2000);

            set => this._reg.SetValue("HoverCardOpenDelay", value);
        }

        #endregion

        #region string settings

        /// <summary>
        /// Gets or sets IPInfo page Url.
        /// </summary>
        public string IPInfoPageURL
        {
            get => this._reg.GetValue("IPInfoPageURL", "http://www.ip2location.com/{0}");

            set => this._reg.SetValue("IPInfoPageURL", value);
        }

        /// <summary>
        /// Gets or sets IP Locator Path.
        /// </summary>
        public string IPLocatorUrlPath
        {
            get => this._reg.GetValue("IPLocatorUrlPath", "http://api.ipinfodb.com/v3/ip-city/?key=<your_api_key>&ip={0}");

            set => this._reg.SetValue("IPLocatorUrlPath", value);
        }

        /// <summary>
        /// Gets or sets IP Locator Results Mapping.
        /// </summary>
        public string IPLocatorResultsMapping
        {
            get => this._reg.GetValue("IPLocatorResultsMapping", "StatusCode,StatusMessage, IpAddress,CountryCode,CountryName,RegionName,CityName,ZipCode,Latitude,Longitude,TimeZone");

            set => this._reg.SetValue("IPLocatorResultsMapping", value);
        }

        /// <summary>
        /// Gets or sets Forum Logo.
        /// </summary>
        public string ForumLogo
        {
            get => this._reg.GetValue("ForumLogo", "YAFLogo.svg");

            set => this._reg.SetValue("ForumLogo", value);
        }

        /// <summary>
        /// Gets or sets ForumEmail.
        /// </summary>
        public string ForumEmail
        {
            get => this._reg.GetValue("ForumEmail", string.Empty);

            set => this._reg.SetValue("ForumEmail", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowGuestsViewReputation.
        /// </summary>
        public bool AllowGuestsViewReputation
        {
            get => this._reg.GetValue("AllowGuestsViewReputation", true);

            set => this._reg.SetValue("AllowGuestsViewReputation", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Enable User Reputation System
        /// </summary>
        public bool EnableUserReputation
        {
            get => this._reg.GetValue("EnableUserReputation", true);

            set => this._reg.SetValue("EnableUserReputation", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Allow Negative Reputation
        /// </summary>
        public bool ReputationAllowNegative
        {
            get => this._reg.GetValue("ReputationAllowNegative", true);

            set => this._reg.SetValue("ReputationAllowNegative", value);
        }

        /// <summary>
        /// Gets or sets ReputationMaxNegative
        /// </summary>
        public int ReputationMaxNegative
        {
            get => this._reg.GetValue("ReputationMaxNegative", -100);

            set => this._reg.SetValue("ReputationMaxNegative", value);
        }

        /// <summary>
        /// Gets or sets ReputationMaxPositive
        /// </summary>
        public int ReputationMaxPositive
        {
            get => this._reg.GetValue("ReputationMaxPositive", 500);

            set => this._reg.SetValue("ReputationMaxPositive", value);
        }

        /// <summary>
        /// Gets or sets Minimum Reputation Value to Allow User to Give Reputation
        /// </summary>
        public int ReputationMinUpVoting
        {
            get => this._reg.GetValue("ReputationMinUpVoting", 1);

            set => this._reg.SetValue("ReputationMinUpVoting", value);
        }

        /// <summary>
        /// Gets or sets Minimum Reputation Value to Allow User to Remove Reputation
        /// </summary>
        public int ReputationMinDownVoting
        {
            get => this._reg.GetValue("ReputationMinDownVoting", 100);

            set => this._reg.SetValue("ReputationMinDownVoting", value);
        }

        /// <summary>
        /// Gets or sets reCAPTCHA Site Key.
        /// </summary>
        public string RecaptchaPublicKey
        {
            get => this._reg.GetValue("RecaptchaPublicKey", string.Empty);

            set => this._reg.SetValue("RecaptchaPublicKey", value);
        }

        /// <summary>
        /// Gets or sets reCAPTCHA Secret Key.
        /// </summary>
        public string RecaptchaPrivateKey
        {
            get => this._reg.GetValue("RecaptchaPrivateKey", string.Empty);

            set => this._reg.SetValue("RecaptchaPrivateKey", value);
        }

        /// <summary>
        /// Gets or sets GravatarRating.
        /// </summary>
        public string GravatarRating
        {
            get => this._reg.GetValue("GravatarRating", "G");

            set => this._reg.SetValue("GravatarRating", value);
        }

        /// <summary>
        /// Gets or sets AcceptedHTML.
        /// </summary>
        public string AcceptedHTML
        {
            get => this._reg.GetValue("AcceptedHTML", "br,hr,b,i,u,a,div,ol,ul,li,blockquote,img,span,p,em,strong,font,pre,h1,h2,h3,h4,h5,h6,address");

            set => this._reg.SetValue("AcceptedHTML", value.ToLower());
        }

        /// <summary>
        /// Gets or sets AdPost.
        /// </summary>
        public string AdPost
        {
            get => this._reg.GetValue<string>("AdPost", null);

            set => this._reg.SetValue("AdPost", value);
        }

        /// <summary>
        /// Gets or sets CustomLoginRedirectUrl.
        /// </summary>
        public string CustomLoginRedirectUrl
        {
            get => this._reg.GetValue<string>("CustomLoginRedirectUrl", null);

            set => this._reg.SetValue("CustomLoginRedirectUrl", value);
        }

        /// <summary>
        /// Gets or sets BaseUrlMask.
        /// </summary>
        public string BaseUrlMask
        {
            get => this._reg.GetValue<string>("BaseUrlMask", null);

            set => this._reg.SetValue("BaseUrlMask", value);
        }

        /// <summary>
        /// Gets or sets WebServiceToken.
        /// </summary>
        public string WebServiceToken
        {
            get => this._reg.GetValue("WebServiceToken", Guid.NewGuid().ToString());

            set => this._reg.SetValue("WebServiceToken", value);
        }

        /* Ederon : 6/16/2007 */

        /// <summary>
        /// Gets or sets a value indicating whether DisplayJoinDate.
        /// </summary>
        public bool DisplayJoinDate
        {
            get => this._reg.GetValue("DisplayJoinDate", true);

            set => this._reg.SetValue("DisplayJoinDate", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowBrowsingUsers.
        /// </summary>
        public bool ShowBrowsingUsers
        {
            get => this._reg.GetValue("ShowBrowsingUsers", true);

            set => this._reg.SetValue("ShowBrowsingUsers", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Show Similar Topics.
        /// </summary>
        public bool ShowSimilarTopics
        {
            get => this._reg.GetValue("ShowSimilarTopics", true);

            set => this._reg.SetValue("ShowSimilarTopics", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowMedals.
        /// </summary>
        public bool ShowMedals
        {
            get => this._reg.GetValue("ShowMedals", true);

            set => this._reg.SetValue("ShowMedals", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowReportPosts.
        /// </summary>
        public bool AllowReportPosts
        {
            get => this._reg.GetValue("AllowReportPosts", true);

            set => this._reg.SetValue("AllowReportPosts", value);
        }

        /* Ederon : 8/29/2007 */

        /// <summary>
        /// Gets or sets a value indicating whether Allow Email Topic.
        /// </summary>
        public bool AllowEmailTopic
        {
            get => this._reg.GetValue("AllowEmailTopic", true);

            set => this._reg.SetValue("AllowEmailTopic", value);
        }

        /* Ederon : 12/9/2007 */

        /// <summary>
        /// Gets or sets a value indicating whether RequireLogin.
        /// </summary>
        public bool RequireLogin
        {
            get => this._reg.GetValue("RequireLogin", false);

            set => this._reg.SetValue("RequireLogin", value);
        }

        /* Ederon : 12/14/2007 */

        /// <summary>
        /// Gets or sets a value indicating whether ShowActiveDiscussions.
        /// </summary>
        public bool ShowActiveDiscussions
        {
            get => this._reg.GetValue("ShowActiveDiscussions", true);

            set => this._reg.SetValue("ShowActiveDiscussions", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowForumStatistics.
        /// </summary>
        public bool ShowForumStatistics
        {
            get => this._reg.GetValue("ShowForumStatistics", true);

            set => this._reg.SetValue("ShowForumStatistics", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether Show Recent Users.
        /// </summary>
        public bool ShowRecentUsers
        {
            get => this._reg.GetValue("ShowRecentUsers", false);

            set => this._reg.SetValue("ShowRecentUsers", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowRulesForRegistration.
        /// </summary>
        public bool ShowRulesForRegistration
        {
            get => this._reg.GetValue("ShowRulesForRegistration", true);

            set => this._reg.SetValue("ShowRulesForRegistration", value);
        }

        /* 6/16/2007 */
        /* Ederon : 7/14/2007 */

        /// <summary>
        /// Gets or sets LastDigestSend.
        /// </summary>
        public string LastDigestSend
        {
            get => this._regBoard.GetValue<string>("LastDigestSend", null);

            set => this._regBoard.SetValue("LastDigestSend", value);
        }

        /// <summary>
        /// Gets or sets TwitterUserName.
        /// </summary>
        public string TwitterUserName
        {
            get => this._regBoard.GetValue<string>("TwitterUserName", null);

            set => this._regBoard.SetValue("TwitterUserName", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether ForceDigestSend.
        /// </summary>
        public bool ForceDigestSend
        {
            get => this._regBoard.GetValue("ForceDigestSend", false);

            set => this._regBoard.SetValue("ForceDigestSend", value);
        }

        #endregion

        /// <summary>
        /// Gets or sets the RegistryDictionaryOverride.
        /// </summary>
        protected virtual RegistryDictionaryOverride _reg { get; set; }

        /// <summary>
        /// Gets or sets the RegistryDictionary.
        /// </summary>
        protected virtual RegistryDictionary _regBoard { get; set; }

        /// <summary>
        ///  Gets or sets the board id.
        /// </summary>
        protected int _boardID { get; set; }

        /// <summary>
        ///  Gets or sets the legacy board settings.
        /// </summary>
        protected virtual YafLegacyBoardSettings _legacyBoardSettings { get; set; }

        /// <summary>
        ///  Gets or sets the membership app name.
        /// </summary>
        protected virtual string _membershipAppName { get; set; }

        /// <summary>
        ///  Gets or sets the roles app name.
        /// </summary>
        protected virtual string _rolesAppName { get; set; }
    }
}