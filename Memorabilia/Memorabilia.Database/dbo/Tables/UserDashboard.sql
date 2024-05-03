CREATE TABLE [dbo].[UserDashboard] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [UserId]          INT NOT NULL,
    [DashboardItemId] INT NOT NULL,
    CONSTRAINT [PK_UserDashboard] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserDashboard_DashboardItem] FOREIGN KEY ([DashboardItemId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_UserDashboard_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

