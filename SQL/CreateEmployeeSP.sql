USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Employee]    Script Date: 01/03/2022 11:38:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Eddie>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Employee] 
	@ID int ,
	@CompanyId nvarchar(128),
	@CreatedOn datetime,
	@DeletedOn datetime,
	@Email nvarchar(max),
	@Fax nvarchar(max),
	@TestName nvarchar(max),
	@Lastlogin date,
	@Password1 nvarchar(max),
	@PortalId nvarchar(128),
	@RoleId nvarchar(128),
	@StatusId nvarchar(128),
	@Telephone nvarchar(max),
	@UpdatedOn datetime,
	@Username nvarchar(max),
	@type nvarchar(50)
AS
BEGIN
IF (@type='insert')
BEGIN
INSERT INTO tbl_Employee
(

	CompanyId,
	CreatedOn,
	DeletedOn,
	Email,
	Fax,
	TestName,
	Lastlogin,
	Password1,
	PortalId,
	RoleId,
	StatusId,
	Telephone,
	UpdatedOn,
	Username
	
)
VALUES
(
	@CompanyId,
	@CreatedOn,
	@DeletedOn,
	@Email,
	@Fax,
	@TestName,
	@Lastlogin,
	@Password1,
	@PortalId,
	@RoleId,
	@StatusId,
	@Telephone,
	@UpdatedOn,
	@Username
	
)
END
ELSE IF (@type = 'get')
BEGIN
SELECT * FROM tbl_Employee ORDER BY ID desc
END
ELSE IF (@type='getid')
BEGIN
SELECT * FROM tbl_Employee WHERE ID = @ID
END
ELSE IF(@type ='update')
BEGIN
UPDATE tbl_Employee SET
	CompanyId = @CompanyId,
	CreatedOn = @CreatedOn,
	DeletedOn = @DeletedOn,
	Email = @Email,
	Fax = @Fax,
	TestName = @TestName,
	Lastlogin = @Lastlogin,
	Password1 = @Password1,
	PortalId = @PortalId,
	RoleId = @RoleId,
	StatusId = @StatusId,
	Telephone = @Telephone,
	UpdatedOn = @UpdatedOn,
	Username = @Username
WHERE ID = @ID
END
ELSE IF(@type = 'delete')
BEGIN
DELETE FROM tbl_Employee WHERE ID= @ID
END
END
GO

