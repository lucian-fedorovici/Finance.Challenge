-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SeedData_tVATCode]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET IDENTITY_INSERT [dbo].[tVATCode] ON;

	MERGE INTO [dbo].[tVATCode] AS [TARGET]
	USING (VALUES
		(1, '101', '6706', 3, '0', 'NB Zero Rate', 1, 0, '2016-05-17 17:30:29.590',	NULL, NULL),
		(2, '101', '6706', 3, '1', 'NB Standard Rate', 1, 0, '2016-05-17 17:30:29.590',	NULL, NULL),
		(3, '101', '6706', 3, '2', 'NB Lower Rate', 1, 0, '2016-05-17 17:30:29.590', NULL, NULL), 
		(4, '101', '6706', 3, '3', 'B Zero Rate', 1, 0,	'2016-05-17 17:30:29.590', NULL, NULL),
		(5, '101', '6706', 3, '4', 'B Lower Rate', 1, 0, '2016-05-17 17:30:29.590', NULL, NULL),
		(6, '101', '6706', 3, '5', 'B Standard Rate', 1, 0, '2016-05-17 17:30:29.590', NULL, NULL),
		(7, '101', '6706', 3, '6', 'NA Zero Rate', 1, 0, '2016-05-17 17:30:29.590', NULL, NULL),
		(8, '101', '6706', 3, '7', 'NA Lower Rate',	1, 0, '2016-05-17 17:30:29.590', NULL, NULL),
		(9, '101', '6706', 3, '8', 'NA Standard Rate', 1, 0, '2016-05-17 17:30:29.590', NULL, NULL),
		(10, '101', '6706', 3, '9', 'Exempt', 1, 0, '2016-05-17 17:30:29.590', NULL, NULL)
	) AS [SOURCE] ([Id], [LACode], [SchoolCode], [CompanyId], [VATCode], [VATCodeDescription], [Active], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
	ON ([TARGET].Id = [SOURCE].Id)
	WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [LACode], [SchoolCode], [CompanyId], [VATCode], [VATCodeDescription], [Active], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
	VALUES ([SOURCE].[Id], [SOURCE].[LACode], [SOURCE].[SchoolCode], [SOURCE].[CompanyId], [SOURCE].[VATCode], [SOURCE].[VATCodeDescription], [SOURCE].[Active], [SOURCE].[CreatedBy], [SOURCE].[CreatedOn], [SOURCE].[UpdatedBy], [SOURCE].[UpdatedOn]);


	SET IDENTITY_INSERT [dbo].[tVATCode] OFF;
	SET NOCOUNT OFF;

END