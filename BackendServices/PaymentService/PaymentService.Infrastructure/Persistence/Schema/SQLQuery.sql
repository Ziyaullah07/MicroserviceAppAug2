/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 26-06-2023 09:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentDetails](
	[Id] [varchar](500) NOT NULL,
	[TransactionId] [varchar](max) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Currency] [varchar](10) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[CartId] [int] NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_PaymentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO