CREATE TABLE [dbo].[Rating]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [VideoId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Comment] NVARCHAR(4000) NULL,
    [Rating] INT NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GetUtcDate(),
    CONSTRAINT [FK_Rating_ToVideo] FOREIGN KEY ([VideoId]) REFERENCES [Video]([Id]),
    CONSTRAINT [FK_Rating_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [CK_Rating_Rating] CHECK (Rating>=1 AND Rating<=5 )
)
