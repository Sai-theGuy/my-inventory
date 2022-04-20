USE [LifeLineMedical]
GO

/****** Object:  Table [dbo].[SupplierAudit]    Script Date: 20/04/2022 16:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SupplierAudit](
	[SupplierAuditID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[DateAdded] [datetime2](7) NULL,
	[DateModified] [datetime2](7) NULL,
	[ActionType] [nchar](10) NOT NULL,
	[ContactPerson] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_SupplierAudit] PRIMARY KEY CLUSTERED 
(
	[SupplierAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


