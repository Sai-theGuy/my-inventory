USE [LifeLineMedical]
GO

/****** Object:  Table [dbo].[ProductListingAudit]    Script Date: 20/04/2022 16:24:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductListingAudit](
	[ListingAuditID] [int] IDENTITY(1,1) NOT NULL,
	[ListingID] [int] NOT NULL,
	[DateAdded] [datetime2](7) NULL,
	[DateModified] [datetime2](7) NULL,
	[ActionType] [nchar](10) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[StocksLeft] [int] NOT NULL,
	[UnitMeasurement] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductListingAudit] PRIMARY KEY CLUSTERED 
(
	[ListingAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


