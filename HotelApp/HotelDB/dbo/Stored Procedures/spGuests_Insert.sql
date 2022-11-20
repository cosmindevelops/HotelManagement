CREATE PROCEDURE [dbo].[spGuests_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50)
AS
begin
	set nocount on;
	
	-- If the person does not exist then insert into the database
	if not exists (select 1 from dbo.Guests where FirstName = @firstName and LastName=@lastName)
	begin
		insert into dbo.Guests(FirstName,LastName)
		values(@firstName,@lastName)
	end
	
	-- We use 'top 1' to ensure that we only get one row back
	select top 1 [Id], [FirstName], [LastName]
	from dbo.Guests
	where FirstName = @firstName and LastName=@lastName
end
