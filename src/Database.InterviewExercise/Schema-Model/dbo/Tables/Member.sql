CREATE TABLE [dbo].[Member]
(
[member_id] [int] NOT NULL,
[first_name] [varchar] (100) NULL,
[last_name] [varchar] (100) NULL
)
GO
ALTER TABLE [dbo].[Member] ADD CONSTRAINT [PK__Member__B29B853475FE8907] PRIMARY KEY CLUSTERED  ([member_id])
GO
