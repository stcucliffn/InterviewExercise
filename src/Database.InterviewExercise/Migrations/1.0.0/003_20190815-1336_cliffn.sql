-- <Migration ID="a897501b-c66f-4b5e-b2cb-3afbe210b02f" />
GO

PRINT N'Creating [dbo].[TestTableDeleteMe]'
GO
CREATE TABLE [dbo].[TestTableDeleteMe]
(
[Id] [int] NOT NULL
)
GO
PRINT N'Creating primary key [PK__TestTabl__3214EC074DE0DAEF] on [dbo].[TestTableDeleteMe]'
GO
ALTER TABLE [dbo].[TestTableDeleteMe] ADD CONSTRAINT [PK__TestTabl__3214EC074DE0DAEF] PRIMARY KEY CLUSTERED  ([Id])
GO
