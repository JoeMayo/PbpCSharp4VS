Here are the instructions to set up a database that works with this project. 

Follow the procedures on this page, except Name the database "Meals":

https://msdn.microsoft.com/en-us/library/jj200620.aspx

This will create a LocalDB database named "Meals". 
Since it's a LocalDB in the default location, the connection string in App.config should find it.

Create the following tables:

CREATE TABLE [dbo].[Meal]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MealId] INT NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Ingredient_Meal] FOREIGN KEY ([MealId]) REFERENCES [Meal]([Id])
)

Next, create data:

1. Open via Menu View/Server Explorer.
2. Expand the Meals database and Tables.
3. Right-click on Meal, select Show Table Data, and add Spaghetti, Cow Pat, Schnitzel, and Burrito. 
Ids will increment automatically. Here's the script:

SET IDENTITY_INSERT [dbo].[Meal] ON
INSERT INTO [dbo].[Meal] ([Id], [Name]) VALUES (1, N'Spaghetti')
INSERT INTO [dbo].[Meal] ([Id], [Name]) VALUES (2, N'Cow Pat')
INSERT INTO [dbo].[Meal] ([Id], [Name]) VALUES (3, N'Schnitzel')
INSERT INTO [dbo].[Meal] ([Id], [Name]) VALUES (4, N'Burrito')
SET IDENTITY_INSERT [dbo].[Meal] OFF

4. Right-click on Ingredient and select Show Table Data.
5. The MealID in Ingredient must match the Id of the matching record in the Meal table. 
If during entry, you deleted and added a row, the Id numbers might not be sequential.

I'm going to assume that the auto-generated IDs in your table are (Id, Name):
    1, Spaghetti
    2, Cow Pat
    3, Schnitzel
    4, Burrito

Add the following items (MealId, Description):
    1, Noodles
	1, Tomato Sauce
	2, Rice
	2, Vegetables
	3, Pork
	3, Yager Sauce
	4, Tortilla
	4, Beans

Here's the script:

SET IDENTITY_INSERT [dbo].[Ingredient] ON
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (1, 1, N'Noodles')
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (2, 1, N'Tomato Sauce')
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (3, 2, N'Rice')
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (4, 2, N'Vegetables')
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (5, 3, N'Pork')
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (6, 3, N'Yager Sauce')
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (7, 4, N'Tortilla')
INSERT INTO [dbo].[Ingredient] ([Id], [MealId], [Description]) VALUES (8, 4, N'Beans')
SET IDENTITY_INSERT [dbo].[Ingredient] OFF
