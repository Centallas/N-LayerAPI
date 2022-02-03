USE [Test]
GO

/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 01/03/2022 11:36:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [nvarchar](128) NULL,
	[CreatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[Email] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[TestName] [nvarchar](max) NULL,
	[Lastlogin] [datetime] NULL,
	[Password1] [nvarchar](max) NULL,
	[PortalId] [nvarchar](128) NULL,
	[RoleId] [nvarchar](128) NULL,
	[StatusId] [nvarchar](128) NULL,
	[Telephone] [nvarchar](max) NULL,
	[UpdatedOn] [datetime] NULL,
	[Username] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_Employee] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO

