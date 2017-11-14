CREATE TABLE [dbo].[Category](
    [Id] [varchar](50) ,
    [Name] [varchar](200) NOT NULL,
    [CreateTime] [datetime] ,
    [CreatePerson] [varchar](200) ,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
    [Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]