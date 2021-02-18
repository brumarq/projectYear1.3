CREATE TABLE [dbo].[Students] (
[studentID] INT NOT NULL,
[studentNumber] INT NULL,
[name] VARCHAR (100) NULL,
[telephone] VARCHAR (100) NULL,
[email] VARCHAR (100) NULL,
PRIMARY KEY CLUSTERED ([studentID] ASC)
);

CREATE TABLE [dbo].[Drinks]
(
[drinkID] INT NOT NULL PRIMARY KEY,
[stock] INT NULL,
[name] VARCHAR(100) NULL,
[salesPrice] FLOAT NULL,
[drinkType] VARCHAR(100) NULL
);

CREATE TABLE [dbo].[Activities]
(
[activityID] INT NOT NULL PRIMARY KEY,
[name] VARCHAR(100) NULL,
[date] DATE NULL
);

CREATE TABLE [dbo].[Rooms]
(
[roomID] INT NOT NULL PRIMARY KEY,
[roomNumber] INT NULL,
[roomType] VARCHAR(10) NULL
);

CREATE TABLE [dbo].[Teachers]
(
[teacherID] INT NOT NULL PRIMARY KEY,
[name] VARCHAR(100) NULL,
[email] VARCHAR(100) NULL,
[telephone] VARCHAR(100) NULL
);