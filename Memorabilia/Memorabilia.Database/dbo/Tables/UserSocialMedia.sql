CREATE TABLE [dbo].[UserSocialMedia] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [SocialMediaTypeId] INT            NOT NULL,
    [Handle]            NVARCHAR (100) NULL,
    [UserId]            INT            NOT NULL,
    CONSTRAINT [PK_UserSocialMedia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserSocialMedia_SocialMediaType] FOREIGN KEY ([SocialMediaTypeId]) REFERENCES [dbo].[SocialMediaType] ([Id]),
    CONSTRAINT [FK_UserSocialMedia_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

