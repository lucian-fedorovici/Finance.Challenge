CREATE TABLE [dbo].[tVATCode] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [LACode]             NVARCHAR (10)  COLLATE Latin1_General_CI_AS NOT NULL,
    [SchoolCode]         NVARCHAR (10)  COLLATE Latin1_General_CI_AS NOT NULL,
    [CompanyId]          BIGINT         NOT NULL,
    [VATCode]            NVARCHAR (12)  COLLATE Latin1_General_CI_AS NOT NULL,
    [VATCodeDescription] NVARCHAR (255) COLLATE Latin1_General_CI_AS NOT NULL,
    [Active]             BIT            NOT NULL,
    [CreatedBy]          BIGINT         CONSTRAINT [DF_tVATCode_CreatedBy] DEFAULT ((0)) NOT NULL,
    [CreatedOn]          DATETIME       CONSTRAINT [DF_tVATCode_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]          BIGINT         NULL,
    [UpdatedOn]          DATETIME       NULL,
    CONSTRAINT [PK_tVATCode] PRIMARY KEY CLUSTERED ([Id] ASC)
);

