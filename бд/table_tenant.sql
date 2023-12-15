USE [DormitoryManagerBD]
GO

/****** Object:  Table [dbo].[Tenant]    Script Date: 15.12.2023 6:26:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tenant](
	[ID_tenant] [int] NOT NULL,
	[TenantFullName] [nvarchar](40) NULL,
	[Room] [int] NULL,
	[Phone] [int] NULL,
	[Email] [nvarchar](40) NULL,
	[DateChecin] [date] NULL,
	[DateEviction] [date] NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[ID_tenant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

