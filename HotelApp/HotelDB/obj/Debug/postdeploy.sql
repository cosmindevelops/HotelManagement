/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


-- If there are no record in the db then insert the default data
if not exists(select 1 from dbo.RoomTypes)
begin
    insert into dbo.RoomTypes(Title,Description,Price)
	values('King Size Bed','A room with a king size bed',100.00),
	('Queen Size Bed','A room with a queen size bed',75.00),
	('Double Bed','A room with two double beds',50.00),
	('Single Bed','A room with a single bed',25.00);
end

if not exists(select 1 from dbo.Rooms)
begin

	declare @roomId1 int;
	declare @roomId2 int;
	declare @roomId3 int;
	declare @roomId4 int;

	-- We insert the Id into a variable so we can use it in the next insert statement
	select @roomId1 = Id from dbo.RoomTypes where title = 'King Size Bed';
	select @roomId2 = Id from dbo.RoomTypes where title = 'Queen Size Bed';
	select @roomId3 = Id from dbo.RoomTypes where title = 'Double Bed';
	select @roomId4 = Id from dbo.RoomTypes where title = 'Single Bed';

	insert into dbo.Rooms(RoomNumber, RoomTypeId)
	values(101, @roomId1),
	(102, @roomId2),
	(103, @roomId3),
	(104, @roomId4),
	(201, @roomId1),
	(202, @roomId2),
	(203, @roomId3),
	(204, @roomId4),
	(301, @roomId1),
	(302, @roomId2),
	(303, @roomId3),
	(304, @roomId4),
	(401, @roomId1),
	(402, @roomId2),
	(403, @roomId3),
	(404, @roomId4);
	
end
GO
