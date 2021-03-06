USE [Accounts DB]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/26/2020 5:19:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](max) NULL,
	[Balance] [float] NULL,
	[ParentAccID] [int] NULL,
	[TypeID] [int] NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountsCategories]    Script Date: 12/26/2020 5:19:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountsCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountsLog]    Script Date: 12/26/2020 5:19:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountsLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [varchar](50) NULL,
	[TableName] [varchar](50) NULL,
	[RecordID] [varchar](50) NULL,
	[ColumnName] [varchar](50) NULL,
	[OriginalValue] [varchar](max) NULL,
	[NewValue] [varchar](max) NULL,
	[Created_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountsTypes]    Script Date: 12/26/2020 5:19:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountsTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [CustomerName], [Balance], [ParentAccID], [TypeID], [CategoryID]) VALUES (29, N'MENNA', 9000, NULL, 1, 1)
INSERT [dbo].[Accounts] ([ID], [CustomerName], [Balance], [ParentAccID], [TypeID], [CategoryID]) VALUES (35, N'Esraa', 80000, 29, 1, 3)
INSERT [dbo].[Accounts] ([ID], [CustomerName], [Balance], [ParentAccID], [TypeID], [CategoryID]) VALUES (36, N'Noor', 800, NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[AccountsCategories] ON 

INSERT [dbo].[AccountsCategories] ([ID], [CategoryName]) VALUES (1, N'Fixed assets')
INSERT [dbo].[AccountsCategories] ([ID], [CategoryName]) VALUES (3, N'Trading expenses')
SET IDENTITY_INSERT [dbo].[AccountsCategories] OFF
SET IDENTITY_INSERT [dbo].[AccountsTypes] ON 

INSERT [dbo].[AccountsTypes] ([ID], [TypeName]) VALUES (1, N'Debit')
INSERT [dbo].[AccountsTypes] ([ID], [TypeName]) VALUES (2, N'Credit')
SET IDENTITY_INSERT [dbo].[AccountsTypes] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[AccountsCategories] ([ID])
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([ParentAccID])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([TypeID])
REFERENCES [dbo].[AccountsTypes] ([ID])
GO
ALTER TABLE [dbo].[AccountsTypes]  WITH CHECK ADD CHECK  (([TypeName]='Credit' OR [TypeName]='Debit'))
GO
