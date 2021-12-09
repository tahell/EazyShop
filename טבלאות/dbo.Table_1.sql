CREATE TABLE [dbo].[Products](
	[Product_Code] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](50) NULL,
	[category] [nvarchar](50) NULL, 
    [Location_Code] NCHAR(10) NULL, 
    [Price] NCHAR(10) NULL

)
