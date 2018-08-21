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
ALTER TABLE [dbo].[Account] ADD CONSTRAINT [PK__Account__46A222CD471F24AF] PRIMARY KEY CLUSTERED  ([account_id])
GO
