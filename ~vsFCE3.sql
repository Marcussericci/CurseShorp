create table [Students](
	[id]		[bigint] identity(1,1) not null,
	[Name]		[nvarchar](50) Null,
	[Country]	[nvarchar](50) null,
	[Gender]	[bit]          null,
constraint [PK_Students]	primary key clustered
(
	[Id] asc
)on [Primary]
)