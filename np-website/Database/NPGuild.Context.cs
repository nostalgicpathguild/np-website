﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace np_website.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NPGuildEntities : DbContext
    {
        public NPGuildEntities()
            : base("name=NPGuildEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<RaidAttendance> RaidAttendances { get; set; }
        public virtual DbSet<UserLevel> UserLevels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ForumAchievement> ForumAchievements { get; set; }
        public virtual DbSet<ForumAdministrator> ForumAdministrators { get; set; }
        public virtual DbSet<ForumConfig> ForumConfigs { get; set; }
        public virtual DbSet<ForumGroupPermission> ForumGroupPermissions { get; set; }
        public virtual DbSet<ForumGroup> ForumGroups { get; set; }
        public virtual DbSet<ForumMessageRating> ForumMessageRatings { get; set; }
        public virtual DbSet<ForumMessage> ForumMessages { get; set; }
        public virtual DbSet<ForumModerator> ForumModerators { get; set; }
        public virtual DbSet<ForumNewForumMsgSubscription> ForumNewForumMsgSubscriptions { get; set; }
        public virtual DbSet<ForumNewTopicSubscription> ForumNewTopicSubscriptions { get; set; }
        public virtual DbSet<ForumPersonalMessage> ForumPersonalMessages { get; set; }
        public virtual DbSet<ForumPollAnswer> ForumPollAnswers { get; set; }
        public virtual DbSet<ForumPollOption> ForumPollOptions { get; set; }
        public virtual DbSet<ForumPoll> ForumPolls { get; set; }
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<ForumSubforum> ForumSubforums { get; set; }
        public virtual DbSet<ForumSubscription> ForumSubscriptions { get; set; }
        public virtual DbSet<ForumTopic> ForumTopics { get; set; }
        public virtual DbSet<ForumUploadedFile> ForumUploadedFiles { get; set; }
        public virtual DbSet<ForumUploadedPersonalFile> ForumUploadedPersonalFiles { get; set; }
        public virtual DbSet<ForumUserGroup> ForumUserGroups { get; set; }
        public virtual DbSet<ForumUser> ForumUsers { get; set; }
        public virtual DbSet<ForumUsersInGroup> ForumUsersInGroups { get; set; }
        public virtual DbSet<ForumComplaint> ForumComplaints { get; set; }
    }
}
