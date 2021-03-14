CREATE DATABASE DBRecipes
COLLATE Hebrew_CI_AS
GO

Use DBRecipes
GO

-- Drop Table TBRecipes
CREATE TABLE TBRecipes (
Recipe_Id int identity,
Recipe_Name nvarchar(50),
Recipe_Time nvarchar(50),
Recipe_Type nvarchar(20),
Recipe_Category nvarchar(50)
)
GO

Insert into TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) values('שקשוקה', '30 דק', 'רגיל', 'ארוחות בוקר')
Insert into TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) values('פיצה טבעונית', 'שעה', 'טבעוני', 'פיצות')
Insert into TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) values('המבורגר מושלם', '20 דק', 'בשרי', 'בשרים')
