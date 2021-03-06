USE [Ofakim]
GO
/****** Object:  Table [dbo].[User_Table]    Script Date: 30/01/2019 09:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BirthDay] [datetime] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_User_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User_Table]    Script Date: 30/01/2019 09:49:30 ******/
ALTER TABLE [dbo].[User_Table] ADD  CONSTRAINT [IX_User_Table] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 30/01/2019 09:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser] 
@FullName nvarchar(30)=null,
@Email nvarchar(30)=null,
@BirthDay datetime=null,
@Phone nvarchar(30)=null,
@Gender bit=null
AS
insert into  User_Table(FullName,BirthDay,Gender,Phone,Email)     values(@FullName,@BirthDay,@Gender,@Phone,@Email)      
GO
