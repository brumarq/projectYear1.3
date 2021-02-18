
use [prjdb21]

CREATE TABLE [dbo].[Students] (
[studentID] INT NOT NULL,
[studentNumber] INT NOT NULL,
[name] VARCHAR (100) NOT NULL,
[telephone] VARCHAR (100) NOT NULL,
[email] VARCHAR (100) NOT NULL
);

CREATE TABLE [dbo].[Drinks]
(
[drinkID] INT NOT NULL PRIMARY KEY,
[stock] INT NOT NULL,
[name] VARCHAR(100) NOT NULL,
[salesPrice] FLOAT NOT NULL,
[drinkType] VARCHAR(100) NOT NULL
);

CREATE TABLE [dbo].[Activities]
(
[activityID] INT NOT NULL PRIMARY KEY,
[name] VARCHAR(100) NOT NULL,
[date] DATE NOT NULL
);

CREATE TABLE [dbo].[Rooms]
(
[roomID] INT NOT NULL PRIMARY KEY,
[roomNumber] INT NOT NULL,
[roomType] VARCHAR(10) NOT NULL
);

CREATE TABLE [dbo].[Teachers]
(
[teacherID] INT NOT NULL PRIMARY KEY,
[name] VARCHAR(100) NOT NULL,
[email] VARCHAR(100) NOT NULL,
[telephone] VARCHAR(100) NOT NULL
);

CREATE TABLE [dbo].[Buy]
(
[studentID] INT NOT NULL FOREIGN KEY REFERENCES Students(studentID),
[drinkID] INT NOT NULL FOREIGN KEY REFERENCES Drinks(drinkID)
);

CREATE TABLE [dbo].[Participate]
(
[studentID] INT NOT NULL FOREIGN KEY REFERENCES Students(studentID),
[activityID] INT NOT NULL FOREIGN KEY REFERENCES Activities(activityID)
);

CREATE TABLE [dbo].[Supervise]
(
[teacherID] INT NOT NULL FOREIGN KEY REFERENCES Teachers(teacherID),
[activityID] INT NOT NULL FOREIGN KEY REFERENCES Activities(activityID)
);

ALTER TABLE [dbo].[Teachers]
    ADD roomID INT
    REFERENCES Rooms(roomID); 

ALTER TABLE [dbo].[Students]
    ADD roomID INT
    REFERENCES Rooms(roomID);


