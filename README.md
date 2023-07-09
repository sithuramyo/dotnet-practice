# ASP.NetCoreConsoleAppPractice
Using one to many relationship not physically just logical.Table script is under below.
```sql
CREATE TABLE [dbo].[tbl_car_type](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[car_type] [nvarchar](50) NULL,
 CONSTRAINT [PK_car_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
```sql
CREATE TABLE [dbo].[tbl_car_details](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[car_brand] [nvarchar](50) NULL,
	[car_name] [nvarchar](50) NULL,
	[car_details] [nvarchar](50) NULL,
	[car_type_id] [bigint] NOT NULL,
 CONSTRAINT [PK_tbl_car_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
