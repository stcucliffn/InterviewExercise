-- <Migration ID="20ef0c7d-85bf-462c-a69f-cefa8ee8be42" />
GO

PRINT N'Creating [dbo].[AccountHistory]'
GO
CREATE TABLE [dbo].[AccountHistory]
(
[account_id] [int] NOT NULL,
[tran_code] [varchar] (3) NOT NULL,
[amount] [decimal] (14, 2) NOT NULL,
[transaction_timestamp] [smalldatetime] NOT NULL
)
GO
PRINT N'Creating primary key [PK__AccountH__46A222CD40642033] on [dbo].[AccountHistory]'
GO
ALTER TABLE [dbo].[AccountHistory] ADD CONSTRAINT [PK__AccountH__46A222CD40642033] PRIMARY KEY CLUSTERED  ([account_id])
GO
PRINT N'Creating [dbo].[Account]'
GO
CREATE TABLE [dbo].[Account]
(
[account_id] [int] NOT NULL,
[member_id] [int] NOT NULL,
[account_no] [varchar] (10) NOT NULL,
[nickname] [varchar] (50) NOT NULL,
[type] [varchar] (3) NOT NULL,
[status] [varchar] (10) NOT NULL,
[balance] [decimal] (14, 2) NOT NULL
)
GO
PRINT N'Creating primary key [PK__Account__46A222CD471F24AF] on [dbo].[Account]'
GO
ALTER TABLE [dbo].[Account] ADD CONSTRAINT [PK__Account__46A222CD471F24AF] PRIMARY KEY CLUSTERED  ([account_id])
GO
PRINT N'Creating [dbo].[Member]'
GO
CREATE TABLE [dbo].[Member]
(
[member_id] [int] NOT NULL,
[first_name] [varchar] (100) NULL,
[last_name] [varchar] (100) NULL
)
GO
PRINT N'Creating primary key [PK__Member__B29B853475FE8907] on [dbo].[Member]'
GO
ALTER TABLE [dbo].[Member] ADD CONSTRAINT [PK__Member__B29B853475FE8907] PRIMARY KEY CLUSTERED  ([member_id])
GO
