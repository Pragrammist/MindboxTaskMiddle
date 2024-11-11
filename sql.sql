-- схема данных
CREATE TABLE [Product] (
  ProductId BIGINT PRIMARY KEY IDENTITY(1,1),
  ProductName NVARCHAR(100) UNIQUE
);

CREATE TABLE Category (
	CategoryId BIGINT PRIMARY KEY IDENTITY(1,1),
	CategoryName NVARCHAR(100) UNIQUE
);

CREATE TABLE ProductCategory(
	ProductId BIGINT REFERENCES [Product] (ProductId),
	CategoryId BIGINT REFERENCES Category (CategoryId)
)

-- инициализация данных
INSERT INTO [Product](ProductName) VALUES ('Tovar 1');
INSERT INTO [Product](ProductName) VALUES ('Tovar 2');
INSERT INTO [Product](ProductName) VALUES ('Tovar 3');
INSERT INTO [Product](ProductName) VALUES ('Tovar 4');
INSERT INTO [Product](ProductName) VALUES ('Tovar 5');
INSERT INTO [Product](ProductName) VALUES ('Tovar 6');
INSERT INTO [Product](ProductName) VALUES ('Tovar 7');
INSERT INTO [Product](ProductName) VALUES ('Tovar 8');
INSERT INTO [Product](ProductName) VALUES ('Tovar 9');
INSERT INTO [Product](ProductName) VALUES ('Tovar 10');

INSERT INTO Category(CategoryName) VALUES ('Category 1');
INSERT INTO Category(CategoryName) VALUES ('Category 2');
INSERT INTO Category(CategoryName) VALUES ('Category 3');
INSERT INTO Category(CategoryName) VALUES ('Category 4');
INSERT INTO Category(CategoryName) VALUES ('Category 5');
INSERT INTO Category(CategoryName) VALUES ('Category 6');
INSERT INTO Category(CategoryName) VALUES ('Category 7');
INSERT INTO Category(CategoryName) VALUES ('Category 8');
INSERT INTO Category(CategoryName) VALUES ('Category 9');
INSERT INTO Category(CategoryName) VALUES ('Category 10');
INSERT INTO ProductCategory(ProductId, CategoryId)
SELECT [Product].ProductId AS ProductId, Category.CategoryId as CategoryId FROM [Product], Category WHERE [Product].ProductId <= 5 AND CategoryId <= 5


--задание
SELECT [Product].ProductName, Category.CategoryName 
	FROM [Product]
	LEFT JOIN ProductCategory ON [Product].ProductId = ProductCategory.ProductId
	LEFT JOIN Category ON ProductCategory.CategoryId = Category.CategoryId
	ORDER BY [Product].ProductId