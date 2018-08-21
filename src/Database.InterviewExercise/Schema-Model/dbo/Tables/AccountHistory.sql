CREATE TABLE [dbo].[AccountHistory]
(
[account_id] [int] NOT NULL,
[tran_code] [varchar] (3) NOT NULL,
[amount] [decimal] (14, 2) NOT NULL,
[transaction_timestamp] [smalldatetime] NOT NULL
)
GO
ALTER TABLE [dbo].[AccountHistory] ADD CONSTRAINT [PK__AccountH__46A222CD40642033] PRIMARY KEY CLUSTERED  ([account_id])
GO
