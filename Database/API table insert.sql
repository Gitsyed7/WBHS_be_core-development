USE [wbhealthscheme]
GO

INSERT INTO [dbo].[API_KEYS]
           ([endpoint_url]
           ,[auth_header_name]
           ,[is_active]
           ,[api_key]
           ,[api_secret_encrypted])
     VALUES
           ('api/v1/beneficiary-auth'
           ,'Chat_Bot'
           ,1           
           ,'chat_bot_ben_auth_pkrFLdHYOZo3vdNndmZPbmVcuvADkzw0'
           ,'chat_bot_ben_auth_cksadt+tvAbQh6REqzBmtXxaTU405MVDVVl3JDi/dUtvsZY1VBQBeZc+BjbplJE0')
GO


