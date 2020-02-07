GO
IF OBJECT_ID('RoomBookings.dbo.RoomUser') IS NOT NULL DROP TABLE RoomBookings.dbo.RoomUser;
CREATE TABLE RoomBookings.dbo.RoomUser
(
    UserID INTEGER IDENTITY PRIMARY KEY 
	,Email NVARCHAR(120)	
);
GO

GO
IF OBJECT_ID('RoomBookings.dbo.Room') IS NOT NULL DROP TABLE RoomBookings.dbo.Room;
CREATE TABLE RoomBookings.dbo.Room
(
    RoomID INTEGER IDENTITY PRIMARY KEY 
	,RoomName NVARCHAR(80)	
	,MaxChairs INTEGER
);
GO

GO
IF OBJECT_ID('RoomBookings.dbo.Bookings') IS NOT NULL DROP TABLE RoomBookings.dbo.Bookings;
CREATE TABLE RoomBookings.dbo.Bookings
(
    BookingID INTEGER IDENTITY PRIMARY KEY 
	,StartTime DATETIME2 NOT NULL	
	,EndTime DATETIME2 NOT NULL
	,RoomID INTEGER NOT NULL
	,RoomUserID INTEGER NOT NULL
	,CONSTRAINT FK_Bookings_Room FOREIGN KEY (RoomID)
	     REFERENCES RoomBookings.dbo.Room (RoomID)
	,CONSTRAINT FK_Bookings_RoomUser FOREIGN KEY (RoomUserID)
	     REFERENCES RoomBookings.dbo.RoomUser (UserID)
    ,CONSTRAINT UN_Bookings UNIQUE (StartTime, EndTime, RoomID)
);
GO

--IF OBJECT_ID('RoomBookings.dbo.RoomUser') IS NOT NULL DROP TABLE RoomBookings.dbo.RoomUser;