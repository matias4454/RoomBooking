GO
INSERT INTO RoomBookings.dbo.RoomUser
(    
	Email
)
VALUES ('jdoe@appdomain.com');
GO
GO
INSERT INTO RoomBookings.dbo.RoomUser
(    
	Email
)
VALUES ('cdesmond@appdomain.com');
GO
GO
INSERT INTO RoomBookings.dbo.RoomUser
(    
	Email
)
VALUES ('rmoody@appdomain.com');
GO
GO
INSERT INTO RoomBookings.dbo.Room
(    
	RoomName
	,MaxChairs	

)
VALUES ('Room-small', 6);
GO
GO
INSERT INTO RoomBookings.dbo.Room
(    
	RoomName
	,MaxChairs	

)
VALUES ('Room-medium', 12);
GO
GO
INSERT INTO RoomBookings.dbo.Room
(    
	RoomName
	,MaxChairs	

)
VALUES ('Room-large', 18);
GO
GO
INSERT INTO RoomBookings.dbo.UserCred
(
    UserID
	,CredHash
)
VALUES (1, CONVERT(NVARCHAR(40), HASHBYTES('SHA1', 'jdoesecret'), 2));
GO
GO
INSERT INTO RoomBookings.dbo.UserCred
(
    UserID
	,CredHash
)
VALUES (2, CONVERT(NVARCHAR(40), HASHBYTES('SHA1', 'cdesmondsecret'), 2));
GO
GO
INSERT INTO RoomBookings.dbo.UserCred
(
    UserID
	,CredHash
)
VALUES (3, CONVERT(NVARCHAR(40), HASHBYTES('SHA1', 'rmoodysecret'), 2));
GO


SELECT * FROM RoomBookings.dbo.RoomUser;

SELECT * FROM RoomBookings.dbo.Room;

--Test
/*GO
INSERT INTO RoomBookings.dbo.Bookings
(    
	RoomID
	,RoomUserID
	,StartTime
	,EndTime
	

)
VALUES (1, 1, CONVERT(DATETIME2,'2020-02-07 10:00:00'), CONVERT(DATETIME2,'2020-02-07 11:00:00'));
GO
GO
INSERT INTO RoomBookings.dbo.Bookings
(    
	RoomID
	,RoomUserID
	,StartTime
	,EndTime
	

)
VALUES (1, 2, CONVERT(DATETIME2,'2020-02-07 10:00:00'), CONVERT(DATETIME2,'2020-02-07 11:00:00'));
GO
SELECT CONVERT(DATETIME2,'2020-02-07 10:00:00');*/
--SELECT b.BookingID, b.RoomUserID, b.RoomID, b.StartTime, b.EndTime FROM RoomBookings.dbo.Bookings AS b;
--DROP DATABASE RoomBookings;
--CREATE DATABASE RoomBookings;
--SELECT * FROM RoomBookings.dbo.UserCred
