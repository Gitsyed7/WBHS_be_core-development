USE [wbhealthscheme]
GO

/****** Object:  Table [dbo].[API_KEYS]    Script Date: 29-04-2026 11.25.55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[API_KEYS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[endpoint_url] [varchar](max) NOT NULL,
	[auth_header_name] [varchar](100) NULL,
	[is_active] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[api_key] [varchar](max) NULL,
	[api_secret_encrypted] [varchar](max) NULL,
 CONSTRAINT [PK_API_KEYS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[API_KEYS] ADD  DEFAULT ((1)) FOR [is_active]
GO

ALTER TABLE [dbo].[API_KEYS] ADD  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[API_KEYS] ADD  DEFAULT (getdate()) FOR [updated_at]
GO


