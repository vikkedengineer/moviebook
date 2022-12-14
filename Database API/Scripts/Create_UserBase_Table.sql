
CREATE TABLE [dbo].[UserBase](
	[Id] [int] NOT NULL IDENTITY (1,1),
	[UserName] [nvarchar](255) NULL,
	[UserPassword] [nvarchar](255) NULL,
	[NickName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


