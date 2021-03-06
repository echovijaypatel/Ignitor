USE [IgnitorDB]
GO
/****** Object:  Table [dbo].[User_Master]    Script Date: 06/22/2015 20:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Master](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[mobile] [varchar](15) NOT NULL,
	[token] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User_Master] ON
INSERT [dbo].[User_Master] ([Id], [username], [email], [password], [mobile], [token]) VALUES (1, N'vijay', N'vijay@gmail.com', N'vijay', N'9727566147', N'vvv9')
SET IDENTITY_INSERT [dbo].[User_Master] OFF
/****** Object:  StoredProcedure [dbo].[validate_user]    Script Date: 06/22/2015 20:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[validate_user]
	-- Add the parameters for the stored procedure here
	@username varchar(30)=null,
	@password varchar(30)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT username,password,email,mobile,token from user_master where username=@username and password=@password;
END


--validate_user "vijay", "vijay"
GO
/****** Object:  StoredProcedure [dbo].[total_user]    Script Date: 06/22/2015 20:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[total_user]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) from User_Master;
END


--validate_user "vijay", "vijay"
GO
