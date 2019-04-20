CREATE TABLE [dbo].[RaidAttendance] (
    [RaidAttendanceId] INT            IDENTITY (1, 1) NOT NULL,
    [Group]           INT            NULL,
    [Name]            NVARCHAR (MAX) NULL,
    [Level]           INT            NOT NULL,
    [Class]           NVARCHAR (MAX) NULL,
    [Role]            NVARCHAR (MAX) NULL,
    [Flagged]         BIT            NOT NULL,
    [DumpTime]        DATETIME       NOT NULL,
    [DKP]             INT            CONSTRAINT [DF_RaidAttendance_DKP] DEFAULT ((0)) NOT NULL,
    [Include]         BIT            NOT NULL,
    [Processed]       BIT            CONSTRAINT [DF_RaidAttendance_Processed] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RaidAttendance] PRIMARY KEY CLUSTERED ([RaidAttendanceId] ASC)
);

