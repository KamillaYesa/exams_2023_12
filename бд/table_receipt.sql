USE [DormitoryManagerBD]
GO

/****** Object:  Table [dbo].[Receipt]    Script Date: 15.12.2023 6:26:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Receipt](
	[ID_receipt] [int] NOT NULL,
	[ReceiptTenant] [int] NULL,
	[PayLiving] [money] NULL,
	[PayData] [date] NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ID_receipt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Tenant] FOREIGN KEY([ReceiptTenant])
REFERENCES [dbo].[Tenant] ([ID_tenant])
GO

ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Tenant]
GO

